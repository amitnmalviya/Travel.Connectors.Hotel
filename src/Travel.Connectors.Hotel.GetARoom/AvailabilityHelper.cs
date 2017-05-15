using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using Travel.Connectors.Hotel.ErrorMapping;
using Travel.Connectors.Hotel.GetARoom.Models;
using Travel.Connectors.Hotel.Entities;
using Travel.Connectors.Hotel.Metadata.Models;
using Travel.Connectors.Hotel.ErrorMapping.Models;
using Tavisca.Platform.Common.Logging;
using Travel.Connectors.Hotel.Logger;
using Travel.Connectors.Hotel.Common;
using Tavisca.Platform.Common.Profiling;

namespace Travel.Connectors.Hotel.GetARoom
{
    public class AvailabilityHelper
    {
        private readonly USGSearchRequest _usgSearchRequest = null;
        private readonly MetadataResponse _metadataResponse = null;
        private readonly CommonLogParameters _commonParameters = null;
        private readonly ILogWriter _logWriter = null;
        private readonly IConnectorError _connectorError;
        public AvailabilityHelper(USGSearchRequest usgAvailabilityRequest, ILogWriter logWriter,
            MetadataResponse getARoomMetadata, CommonLogParameters commonLogParameters, IConnectorError errorMap)
        {
            _usgSearchRequest = usgAvailabilityRequest;
            _metadataResponse = getARoomMetadata;
            _commonParameters = commonLogParameters;
            _logWriter = logWriter;
            _connectorError = errorMap;
        }

        public string GetSearchRequest()
        {
            StringBuilder searchRequest = new StringBuilder();

            using (var profileScope = new ProfileContext("AvailabilityHelper.GetSearchRequest", false))
            {
                searchRequest.Append(ApplicationConstants.api + ApplicationConstants.ApiVersion);
                searchRequest.Append(ApplicationConstants.room_availability);
                searchRequest.Append(ApplicationConstants.check_in + WebUtility.UrlEncode(_usgSearchRequest.Criteria.CheckIn.ToString(ApplicationConstants.dateFormat, CultureInfo.InvariantCulture)));
                searchRequest.Append(ApplicationConstants.check_out + WebUtility.UrlEncode(_usgSearchRequest.Criteria.CheckOut.ToString(ApplicationConstants.dateFormat, CultureInfo.InvariantCulture)));

                if (_usgSearchRequest.OptionalFields != null && _usgSearchRequest.OptionalFields.Count > 0 && _usgSearchRequest.OptionalFields[0].Equals(ApplicationConstants.OptionalFieldAll, StringComparison.OrdinalIgnoreCase))
                    searchRequest.Append(ApplicationConstants.cancellation_rules + WebUtility.UrlEncode(ApplicationConstants.CancellationRulesTrue));
                else
                    searchRequest.Append(ApplicationConstants.cancellation_rules + WebUtility.UrlEncode(ApplicationConstants.CancellationRulesFalse));

                searchRequest.Append(ApplicationConstants.api_key + WebUtility.UrlEncode(_usgSearchRequest.Supplier.Configurations.ApiKey));
                searchRequest.Append(ApplicationConstants.auth_token + WebUtility.UrlEncode(_usgSearchRequest.Supplier.Configurations.AuthToken));
                searchRequest.Append(ApplicationConstants.rinfo);

                string roomRequest = GetRoomRequest();

                searchRequest.Append(WebUtility.UrlEncode(roomRequest));
                searchRequest.Append(ApplicationConstants.transaction_id + WebUtility.UrlEncode(Guid.NewGuid().ToString()));
            }
            return searchRequest.ToString();
        }

        private string GetRoomRequest()
        {
            StringBuilder roomRequest = new StringBuilder();
            roomRequest.Append(ApplicationConstants.openSquareBracket);
            foreach (RoomOccupancy occupancy in _usgSearchRequest.Criteria.Occupancies)
            {
                roomRequest.Append(ApplicationConstants.openSquareBracket);

                for (int age = 0; age < occupancy.NumOfAdults; age++)
                    roomRequest.Append(ApplicationConstants.adultAge);

                if (occupancy.ChildAges != null)
                {
                    foreach (int childAge in occupancy.ChildAges)
                        roomRequest.Append(childAge + ",");
                }
                roomRequest.Remove(roomRequest.Length - 1, 1);
                roomRequest.Append(ApplicationConstants.closeSquareBracket);
                roomRequest.Append(",");
            }
            roomRequest.Remove(roomRequest.Length - 1, 1);
            roomRequest.Append(ApplicationConstants.closeSquareBracket);

            return roomRequest.ToString();
        }

        public USGSearchResponse MergeSearchReposne(GetARoomSearchResponse getARoomSearchResponse)
        {
            USGSearchResponse usgSearchResponse = new USGSearchResponse();
            using (var profileScope = new ProfileContext("AvailabilityHelper.MergeSearchReposne", false))
            {
                List<Warning> warnings = new List<Warning>();
                try
                {
                    if (getARoomSearchResponse?.status?.errors?.error != null)
                    {
                        if (!string.IsNullOrEmpty(getARoomSearchResponse.status.errors.error.code))
                        {
                            UsgError usgError = _connectorError.GetUsgMappedError(getARoomSearchResponse.status.errors.error.code);
                            if (usgError != null)
                            {
                                if (usgError.ErrorCategory.Equals(ApplicationConstants.ErrorCategoryWarning))
                                {
                                    Warning warningInfo = new Warning
                                    {
                                        Code = usgError.ErrorCode,
                                        Message = usgError.ErrorMessage
                                    };
                                    warnings.Add(warningInfo);
                                    usgSearchResponse.warnings = warnings;
                                }
                                else
                                {
                                    ErrorInfo errorInfo = new ErrorInfo
                                    {
                                        code = usgError.ErrorCode,
                                        message = usgError.ErrorMessage,
                                        info = null
                                    };
                                    usgSearchResponse.errorInfo = errorInfo;
                                }

                                usgSearchResponse.HttpStatusCode = Convert.ToInt32(usgError.HttpStatusCode);
                            }
                        }
                    }
                    else if (getARoomSearchResponse != null)
                    {
                        if (!string.IsNullOrEmpty(getARoomSearchResponse.transactionid))
                            usgSearchResponse.sessionId = getARoomSearchResponse.transactionid;

                        if (getARoomSearchResponse.roomstay != null && getARoomSearchResponse.roomstay.Count > 0)
                        {
                            List<Itinerary> itineraries = new List<Itinerary>();

                            GetARoomSearchResponse supplierSearchResponse = getARoomSearchResponse;

                            foreach (RoomStay getARoomStay in getARoomSearchResponse.roomstay)
                            {
                                try
                                {
                                    Itinerary itinaryItinerary = itineraries.Find(itinerary => itinerary.hotelInfo.id.Equals(getARoomStay.room.hotelid));
                                    if (itinaryItinerary == null)
                                    {
                                        List<RoomStay> roomStayList = supplierSearchResponse.roomstay.FindAll(supplierRoomStay => supplierRoomStay.room.hotelid == getARoomStay.room.hotelid);
                                        if (roomStayList != null && roomStayList.Count > 0)
                                        {
                                            Itinerary itinerary = new Itinerary();
                                            itinerary.hotelInfo = new HotelInfo();
                                            if (!string.IsNullOrEmpty(roomStayList[0].room.hotelid))
                                                itinerary.hotelInfo.id = roomStayList[0].room.hotelid;

                                            itinerary.rate = GetRate(roomStayList);

                                            itinerary.occupancies = GetOccupencies(_usgSearchRequest.Criteria.Occupancies);
                                            List<RoomOption> roomOptions = new List<RoomOption>();
                                            List<PerBookingRates> perBookingRates = new List<PerBookingRates>();
                                            foreach (RoomStay roomStay in roomStayList)
                                            {
                                                if (roomStay.room != null)
                                                {
                                                    roomOptions = AddRoomOption(roomStay, roomOptions);
                                                    PerBookingRates perBookingRate = GetPerBookingRates(roomStay, itinerary, roomOptions);
                                                    if (perBookingRate != null)
                                                    {
                                                        perBookingRates.Add(perBookingRate);
                                                    }
                                                }
                                            }
                                            itinerary.roomOptions = roomOptions;
                                            RoomRate roomRate = new RoomRate();
                                            roomRate.perBookingRates = perBookingRates;
                                            itinerary.roomRate = roomRate;
                                            itineraries.Add(itinerary);
                                        }
                                    }
                                }
                                catch (Exception exception)
                                {
                                    ErrorLogEntry errorLogEntry = LogEntryBuilder.GetErrorLogEntry(exception, _commonParameters);
                                    _logWriter.WriteAsync(errorLogEntry);
                                }
                            }
                            usgSearchResponse.itineraries = itineraries;
                            usgSearchResponse.HttpStatusCode = 200;
                        }
                        else
                        {
                            UsgError usgError = _connectorError.GetUsgError(ApplicationConstants.NoResultsFound);
                            if (usgError != null)
                            {
                                Warning warningInfo = new Warning
                                {
                                    Code = usgError.ErrorCode,
                                    Message = usgError.ErrorMessage
                                };
                                warnings.Add(warningInfo);
                                usgSearchResponse.warnings = warnings;
                                usgSearchResponse.HttpStatusCode = Convert.ToInt32(usgError.HttpStatusCode);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    ErrorLogEntry errorLogEntry = LogEntryBuilder.GetErrorLogEntry(exception, _commonParameters);
                    _logWriter.WriteAsync(errorLogEntry);
                }
            }
            return usgSearchResponse;
        }

        private Rate GetRate(List<RoomStay> roomStayList)
        {
            Rate rate = new Rate();
            if (roomStayList[0].bookingpricing != null && !string.IsNullOrEmpty(roomStayList[0].bookingpricing.currency))
                rate.currency = roomStayList[0].bookingpricing.currency;
            else if (roomStayList[0].displaypricing != null && !string.IsNullOrEmpty(roomStayList[0].displaypricing.currency))
                rate.currency = roomStayList[0].displaypricing.currency;

            rate.minDailyRate = roomStayList.Min(supplierRoomStay => supplierRoomStay.lowestaverage);

            string[] arrInventoryTypes = new string[1];
            if (_metadataResponse.inventoryTypes != null && _metadataResponse.inventoryTypes.Length > 0)
                arrInventoryTypes[0] = _metadataResponse.inventoryTypes[0];
            rate.inventoryTypes = arrInventoryTypes;

            return rate;
        }

        private List<RoomOption> AddRoomOption(RoomStay roomStay, List<RoomOption> roomOptionList)
        {
            List<RoomOption> roomOptions = roomOptionList;
            RoomOption rOption = roomOptionList.Find(roomOption => roomOption.code == roomStay.room.roomid);

            if (rOption == null)
            {
                RoomOption roomOption = new RoomOption();
                roomOption.refId = Guid.NewGuid().ToString();

                if (!string.IsNullOrEmpty(roomStay.room.roomid))
                    roomOption.code = roomStay.room.roomid;

                if (!string.IsNullOrEmpty(roomStay.room.description))
                    roomOption.desc = roomStay.room.description;

                if (!string.IsNullOrEmpty(roomStay.RoomsLeft))
                    roomOption.availableRooms = Int32.Parse(roomStay.RoomsLeft);
                else
                    roomOption.availableRooms = null;

                if (!string.IsNullOrEmpty(roomStay.room.title))
                    roomOption.name = roomStay.room.title;

                if (
                    roomStay.room.title.IndexOf(ApplicationConstants.NonSmokeWithSpace,
                        StringComparison.OrdinalIgnoreCase) >= 0 ||
                    roomStay.room.title.IndexOf(ApplicationConstants.NonSmokeWithOutSpace,
                        StringComparison.OrdinalIgnoreCase) >= 0 ||
                    roomStay.room.title.IndexOf(ApplicationConstants.NonSmokeWithDash,
                        StringComparison.OrdinalIgnoreCase) >= 0)
                    roomOption.smokingPreference = SmokingPreference.nonSmoking.ToString();
                else if (
                    roomStay.room.title.IndexOf(ApplicationConstants.Smoke,
                        StringComparison.OrdinalIgnoreCase) >=
                    0)
                    roomOption.smokingPreference = SmokingPreference.smoking.ToString();
                else
                    roomOption.smokingPreference = SmokingPreference.unknown.ToString();
                roomOptionList.Add(roomOption);
            }
            return roomOptions;
        }

        private Occupancy[] GetOccupencies(RoomOccupancy[] usgRequestOccupancies)
        {
            Occupancy[] occupancies = new Occupancy[usgRequestOccupancies.Length];

            for (int occupancyCount = 0; occupancyCount < usgRequestOccupancies.Length; occupancyCount++)
            {
                Occupancy occupancy = new Occupancy();
                occupancy.refId = Guid.NewGuid().ToString();
                occupancy.adults = usgRequestOccupancies[occupancyCount].NumOfAdults;

                if (usgRequestOccupancies[occupancyCount].ChildAges != null && usgRequestOccupancies[occupancyCount].ChildAges.Length > 0)
                    occupancy.children = usgRequestOccupancies[occupancyCount].ChildAges.Length;
                occupancies[occupancyCount] = occupancy;
            }
            return occupancies;
        }

        private PerBookingRates GetPerBookingRates(RoomStay roomStay, Itinerary itinerary, List<RoomOption> roomOptions)
        {
            List<RoomOption> rooms = roomOptions.FindAll(roomOption => roomOption.code.Equals(roomStay.room.roomid));
            if (rooms != null && rooms.Count > 0)
            {
                PerBookingRates perBookingRate = new PerBookingRates();
                perBookingRate.rateOccupancies = new List<RateOccupancy>();

                for (int iRoomOptionCount = 0; iRoomOptionCount < itinerary.occupancies.Length; iRoomOptionCount++)
                {
                    RateOccupancy rateOccupancies = new RateOccupancy();
                    rateOccupancies.refId = Guid.NewGuid().ToString();
                    rateOccupancies.roomRefId = rooms[0].refId;
                    rateOccupancies.occupancyRefId = itinerary.occupancies[iRoomOptionCount].refId;
                    perBookingRate.rateOccupancies.Add(rateOccupancies);
                }

                perBookingRate.code = rooms[0].code;
                perBookingRate.desc = rooms[0].desc;

                if (!string.IsNullOrEmpty(roomStay.rateplantype))
                    perBookingRate.type = RateTypeMapper.GetRateType(roomStay.rateplantype);

                if (_metadataResponse.inventoryTypes != null && _metadataResponse.inventoryTypes.Length > 0)
                    perBookingRate.inventoryType = _metadataResponse.inventoryTypes[0];

                DisplayPricing pricing = null;
                if (roomStay.bookingpricing != null)
                    pricing = roomStay.bookingpricing;
                else
                    pricing = roomStay.displaypricing;

                if (!string.IsNullOrEmpty(pricing.currency))
                    perBookingRate.currency = pricing.currency;

                perBookingRate.total = pricing.total;
                perBookingRate.breakup = GetPerBookingBreakup(pricing);
                perBookingRate.dailyRoomRates = GetDailyRoomRates(pricing);

                perBookingRate.bookingRequirement = null;

                if (roomStay.refundable != null)
                    perBookingRate.refundable = roomStay.refundable;

                perBookingRate.offer = GetOffer(roomStay);

                perBookingRate.boardBasis = GetBoardBasis(roomStay);
                perBookingRate.inclusions = GetInclusions(roomStay);

                perBookingRate.additionalCharges = GetAdditionalCharges(roomStay);

                return perBookingRate;
            }
            else
                return null;
        }

        private Breakup GetPerBookingBreakup(DisplayPricing pricing)
        {
            Breakup perBookingBreakup = new Breakup();
            perBookingBreakup.baseRate = pricing.subtotal;
            TaxesAndFees[] taxesAndFees = new TaxesAndFees[1];
            taxesAndFees[0] = new TaxesAndFees();
            taxesAndFees[0].amount = pricing.taxes + pricing.fees;
            taxesAndFees[0].isIncludedInBase = false;
            perBookingBreakup.taxesAndFees = taxesAndFees;

            return perBookingBreakup;
        }

        private DailyRoomRates GetDailyRoomRates(DisplayPricing pricing)
        {
            DailyRoomRates dailyRoomRates = new DailyRoomRates();
            dailyRoomRates.taxIncluded = false;
            if (pricing.nightlyrates != null && pricing.nightlyrates.nightlyrate != null && pricing.nightlyrates.nightlyrate.Length > 0)
            {
                NightlyRate[] nightlyrates = pricing.nightlyrates.nightlyrate;
                Roombreakup[] roombreakups = new Roombreakup[nightlyrates.Length];
                for (int iNightRateCount = 0; iNightRateCount < nightlyrates.Length; iNightRateCount++)
                {
                    roombreakups[iNightRateCount] = new Roombreakup();
                    roombreakups[iNightRateCount].date = nightlyrates[iNightRateCount].perNightDate;
                    roombreakups[iNightRateCount].amount = nightlyrates[iNightRateCount].rate;
                }

                dailyRoomRates.breakup = roombreakups;
            }
            return dailyRoomRates;
        }

        private BoardBasis GetBoardBasis(RoomStay roomStay)
        {
            BoardBasis boardBasis = null;
            if (roomStay.valueadds != null && roomStay.valueadds.valueadd != null && roomStay.valueadds.valueadd.Length > 0)
            {
                foreach (ValueAdd valueAdd in roomStay.valueadds.valueadd)
                {
                    if (!string.IsNullOrEmpty(valueAdd.code) && valueAdd.code.IndexOf(ApplicationConstants.freeBreakfast,
                            StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        boardBasis = new BoardBasis();
                        boardBasis.code = ApplicationConstants.boardBasisCode;
                        if (!string.IsNullOrEmpty(valueAdd.name))
                            boardBasis.desc = valueAdd.name;

                        if (!string.IsNullOrEmpty(valueAdd.code))
                            boardBasis.code = valueAdd.code;

                        boardBasis.amount = 0;
                        boardBasis.amountIncludedInRate = true;
                    }
                }
            }
            return boardBasis;
        }

        private List<string> GetInclusions(RoomStay roomStay)
        {
            List<string> inclusionsList = null;
            if (roomStay.valueadds != null && roomStay.valueadds.valueadd != null && roomStay.valueadds.valueadd.Length > 0)
            {
                inclusionsList = new List<string>();
                foreach (ValueAdd valueAdd in roomStay.valueadds.valueadd)
                {
                    if (!string.IsNullOrEmpty(valueAdd.code) && valueAdd.code.IndexOf(ApplicationConstants.freeBreakfast,
                            StringComparison.OrdinalIgnoreCase) <= 0)
                    {
                        if (!string.IsNullOrEmpty(valueAdd.name))
                            inclusionsList.Add(valueAdd.name);
                    }
                }
            }
            return inclusionsList;
        }

        private string[] GetAdditionalCharges(RoomStay roomStay)
        {
            string[] arrAdditionalCharges = null;
            StringBuilder additionalCharges = null;
            if (roomStay.feesCollectedAtProperty != null && roomStay.feesCollectedAtProperty.fee != null)
            {
                arrAdditionalCharges = new string[1];
                additionalCharges = new StringBuilder();
                if (roomStay.feesCollectedAtProperty.fee.name != null)
                {
                    additionalCharges.Append(roomStay.feesCollectedAtProperty.fee.name + ApplicationConstants.colon);
                    additionalCharges.Append(roomStay.feesCollectedAtProperty.fee.amount);
                    if (!string.IsNullOrEmpty(roomStay.feesCollectedAtProperty.fee.currency))
                        additionalCharges.Append(ApplicationConstants.emptySpace + roomStay.feesCollectedAtProperty.fee.currency + ApplicationConstants.emptySpace);
                }

                if (roomStay.feesCollectedAtProperty.fee.total > 0)
                {
                    additionalCharges.Append(ApplicationConstants.resortFeeName);
                    additionalCharges.Append(roomStay.feesCollectedAtProperty.fee.total);
                    if (!string.IsNullOrEmpty(roomStay.feesCollectedAtProperty.fee.currency))
                        additionalCharges.Append(ApplicationConstants.emptySpace + roomStay.feesCollectedAtProperty.fee.currency);
                    additionalCharges.Append(ApplicationConstants.closingBracket);
                }
                arrAdditionalCharges[0] = additionalCharges.ToString();
            }

            return (additionalCharges != null && additionalCharges.Length > 0) ? arrAdditionalCharges : null;
        }

        private Offer GetOffer(RoomStay roomStay)
        {
            Offer offer = null;

            if (!string.IsNullOrEmpty(roomStay.promotionaltext) || !string.IsNullOrEmpty(roomStay.promotiondetails))
            {
                offer = new Offer();
                if (!string.IsNullOrEmpty(roomStay.promotionaltext))
                    offer.title = roomStay.promotionaltext;

                if (!string.IsNullOrEmpty(roomStay.promotiondetails))
                    offer.desc = roomStay.promotiondetails;
            }
            return offer;
        }

    }
}
