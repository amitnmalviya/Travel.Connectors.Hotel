using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
namespace Travel.Connectors.Hotel.Common.ErrorHandling
{
	public static partial class ErrorMessages
	{
		
		public static string InvalidSessionId()
		{
				return FaultMessages.InvalidSessionId;
		}
		
		public static string InvalidAccountId()
		{
				return FaultMessages.InvalidAccountId;
		}
		
		public static string InvalidCurrency()
		{
				return FaultMessages.InvalidCurrency;
		}
		
		public static string InvalidPosId()
		{
				return FaultMessages.InvalidPosId;
		}
		
		public static string InvalidRequest()
		{
				return FaultMessages.InvalidRequest;
		}
		
		public static string RequestNotFound()
		{
				return FaultMessages.RequestNotFound;
		}
		
		public static string MissingSessionId()
		{
				return FaultMessages.MissingSessionId;
		}
		
		public static string MissingSupplierDetails()
		{
				return FaultMessages.MissingSupplierDetails;
		}
		
		public static string MissingSupplierId()
		{
				return FaultMessages.MissingSupplierId;
		}
		
		public static string MissingSupplierName()
		{
				return FaultMessages.MissingSupplierName;
		}
		
		public static string MissingSupplierConfigurations()
		{
				return FaultMessages.MissingSupplierConfigurations;
		}
		
		public static string MissingSupplierConfiguration(List<string> configuration)
		{
				return string.Format(FaultMessages.MissingSupplierConfiguration , string.Join(", ",configuration)); 
		}
		
		public static string InvalidCheckInDate()
		{
				return FaultMessages.InvalidCheckInDate;
		}
		
		public static string ConnectorMetadataNotFound(List<string> supplier)
		{
				return string.Format(FaultMessages.ConnectorMetadataNotFound , string.Join(", ",supplier)); 
		}
		
		public static string InvalidVersion()
		{
				return FaultMessages.InvalidVersion;
		}
		
		public static string InvalidCredentials()
		{
				return FaultMessages.InvalidCredentials;
		}
		
		public static string InvalidCircularRegion()
		{
				return FaultMessages.InvalidCircularRegion;
		}
		
		public static string ValidationFailure()
		{
				return FaultMessages.ValidationFailure;
		}
		
		public static string InvalidGeocodes()
		{
				return FaultMessages.InvalidGeocodes;
		}
		
		public static string MissingRoomRate()
		{
				return FaultMessages.MissingRoomRate;
		}
		
		public static string MissingRateReferenceId()
		{
				return FaultMessages.MissingRateReferenceId;
		}
		
		public static string InvalidCountryCode()
		{
				return FaultMessages.InvalidCountryCode;
		}
		
		public static string InvalidRadius()
		{
				return FaultMessages.InvalidRadius;
		}
		
		public static string InvalidRateIdFormat()
		{
				return FaultMessages.InvalidRateIdFormat;
		}
		
		public static string MissingRateIds()
		{
				return FaultMessages.MissingRateIds;
		}
		
		public static string InvalidSupplierIdInSupplierSpecificOptions(string supplierId)
		{
				return string.Format(FaultMessages.InvalidSupplierIdInSupplierSpecificOptions , supplierId); 
		}
		
		public static string TenantNotFound(string tenantId)
		{
				return string.Format(FaultMessages.TenantNotFound , tenantId); 
		}
		
		public static string InvalidCulture()
		{
				return FaultMessages.InvalidCulture;
		}
		
		public static string SupplierConfigurationNotAvailable(List<string> supplierId)
		{
				return string.Format(FaultMessages.SupplierConfigurationNotAvailable , string.Join(", ",supplierId)); 
		}
		
		public static string MissingConnectorMetadata(List<string> missingDetails)
		{
				return string.Format(FaultMessages.MissingConnectorMetadata , string.Join(", ",missingDetails)); 
		}
		
		public static string UnSupportedCulture(string culture)
		{
				return string.Format(FaultMessages.UnSupportedCulture , culture); 
		}
		
		public static string UnSupportedRateTypes(List<string> ratetypes)
		{
				return string.Format(FaultMessages.UnSupportedRateTypes , string.Join(", ",ratetypes)); 
		}
		
		public static string InvalidCreditCardIssuedBy()
		{
				return FaultMessages.InvalidCreditCardIssuedBy;
		}
		
		public static string CreditCardNotRequired()
		{
				return FaultMessages.CreditCardNotRequired;
		}
		
		public static string CreditCardRequired()
		{
				return FaultMessages.CreditCardRequired;
		}
		
		public static string UnSupportedSpecialRequest()
		{
				return FaultMessages.UnSupportedSpecialRequest;
		}
		
		public static string UnSupportedLoyaltyMembership()
		{
				return FaultMessages.UnSupportedLoyaltyMembership;
		}
		
		public static string FirstNameLengthExceeded(string length)
		{
				return string.Format(FaultMessages.FirstNameLengthExceeded , length); 
		}
		
		public static string LastNameLengthExceeded(string length)
		{
				return string.Format(FaultMessages.LastNameLengthExceeded , length); 
		}
		
		public static string InvalidFirstName()
		{
				return FaultMessages.InvalidFirstName;
		}
		
		public static string InvalidLastName()
		{
				return FaultMessages.InvalidLastName;
		}
		
		public static string MissingBookingContactNameInformation(string fieldName)
		{
				return string.Format(FaultMessages.MissingBookingContactNameInformation , fieldName); 
		}
		
		public static string MissingContactFirstName()
		{
				return FaultMessages.MissingContactFirstName;
		}
		
		public static string MissingContactLastName()
		{
				return FaultMessages.MissingContactLastName;
		}
		
		public static string InvalidContactInformation()
		{
				return FaultMessages.InvalidContactInformation;
		}
		
		public static string InvalidPhoneInformation(string parentName)
		{
				return string.Format(FaultMessages.InvalidPhoneInformation , parentName); 
		}
		
		public static string InvalidAddressInformation()
		{
				return FaultMessages.InvalidAddressInformation;
		}
		
		public static string MissingAddressLine()
		{
				return FaultMessages.MissingAddressLine;
		}
		
		public static string MissingCityInformation()
		{
				return FaultMessages.MissingCityInformation;
		}
		
		public static string MissingCountryCode()
		{
				return FaultMessages.MissingCountryCode;
		}
		
		public static string MissingEmailInformation()
		{
				return FaultMessages.MissingEmailInformation;
		}
		
		public static string InvalidMembershipInformation()
		{
				return FaultMessages.InvalidMembershipInformation;
		}
		
		public static string MissingCreditCardNumber()
		{
				return FaultMessages.MissingCreditCardNumber;
		}
		
		public static string MissingNameOnCreditCard()
		{
				return FaultMessages.MissingNameOnCreditCard;
		}
		
		public static string MissingCreditCardExpiryDate()
		{
				return FaultMessages.MissingCreditCardExpiryDate;
		}
		
		public static string CreditCardExpired()
		{
				return FaultMessages.CreditCardExpired;
		}
		
		public static string MissingCreditCardCvv()
		{
				return FaultMessages.MissingCreditCardCvv;
		}
		
		public static string MissingCreditCardBillingAddress()
		{
				return FaultMessages.MissingCreditCardBillingAddress;
		}
		
		public static string MissingBillingAddressLine1()
		{
				return FaultMessages.MissingBillingAddressLine1;
		}
		
		public static string MissingBillingAddressCity()
		{
				return FaultMessages.MissingBillingAddressCity;
		}
		
		public static string MissingBillingAddressCountryCode()
		{
				return FaultMessages.MissingBillingAddressCountryCode;
		}
		
		public static string MissingBillingAddressPostalCode()
		{
				return FaultMessages.MissingBillingAddressPostalCode;
		}
		
		public static string MissingCreditCardStateDetails()
		{
				return FaultMessages.MissingCreditCardStateDetails;
		}
		
		public static string InvalidCreditCardExpiryMonth()
		{
				return FaultMessages.InvalidCreditCardExpiryMonth;
		}
		
		public static string InvalidCreditCardExpiryYear()
		{
				return FaultMessages.InvalidCreditCardExpiryYear;
		}
		
		public static string SupplierValidation()
		{
				return FaultMessages.SupplierValidation;
		}
		
		public static string InvalidCreditCardDetails()
		{
				return FaultMessages.InvalidCreditCardDetails;
		}
		
		public static string CreditCardDeclined()
		{
				return FaultMessages.CreditCardDeclined;
		}
		
		public static string InvalidCreditCardSecurityValue()
		{
				return FaultMessages.InvalidCreditCardSecurityValue;
		}
		
		public static string InvalidCreditCardSecureCode()
		{
				return FaultMessages.InvalidCreditCardSecureCode;
		}
		
		public static string MissingDetailsInCancellation(List<string> details)
		{
				return string.Format(FaultMessages.MissingDetailsInCancellation , string.Join(", ",details)); 
		}
		
		public static string BookingDoesNotExist()
		{
				return FaultMessages.BookingDoesNotExist;
		}
		
		public static string BookingAlreadyCancelled()
		{
				return FaultMessages.BookingAlreadyCancelled;
		}
		
		public static string StateNotFound()
		{
				return FaultMessages.StateNotFound;
		}
		
		public static string InvalidBookingConfirmation()
		{
				return FaultMessages.InvalidBookingConfirmation;
		}
		
		public static string MissingCustomerName()
		{
				return FaultMessages.MissingCustomerName;
		}
		
		public static string CancellationNotSupported(string supplier)
		{
				return string.Format(FaultMessages.CancellationNotSupported , supplier); 
		}
		
		public static string CustomerInformationRequiredInCancellation(string supplier)
		{
				return string.Format(FaultMessages.CustomerInformationRequiredInCancellation , supplier); 
		}
		
		public static string InvalidAdultAge(int adultAgeLowerLimit, int adultAgeUpperLimit)
		{
				return string.Format(FaultMessages.InvalidAdultAge , adultAgeLowerLimit, adultAgeUpperLimit); 
		}
		
		public static string InvalidSearchDate(int numberOfDays)
		{
				return string.Format(FaultMessages.InvalidSearchDate , numberOfDays); 
		}
		
		public static string InvalidValueInRequest(string fieldName)
		{
				return string.Format(FaultMessages.InvalidValueInRequest , fieldName); 
		}
		
		public static string InvalidSupplierId()
		{
				return FaultMessages.InvalidSupplierId;
		}
		
		public static string MissingTenantId()
		{
				return FaultMessages.MissingTenantId;
		}
		
		public static string NoResultsOrAllResultsFilteredOut()
		{
				return FaultMessages.NoResultsOrAllResultsFilteredOut;
		}
		
		public static string MissingCustomerInformationInBooking()
		{
				return FaultMessages.MissingCustomerInformationInBooking;
		}
		
		public static string MissingTitleInName()
		{
				return FaultMessages.MissingTitleInName;
		}
		
		public static string MissingLocationCode(string locationType)
		{
				return string.Format(FaultMessages.MissingLocationCode , locationType); 
		}
		
		public static string MissingLocationName(string locationType)
		{
				return string.Format(FaultMessages.MissingLocationName , locationType); 
		}
		
		public static string MissingStateInformation()
		{
				return FaultMessages.MissingStateInformation;
		}
		
		public static string InvalidEmailAddress()
		{
				return FaultMessages.InvalidEmailAddress;
		}
		
		public static string MissingNationality()
		{
				return FaultMessages.MissingNationality;
		}
		
		public static string MissingDateOfBirth()
		{
				return FaultMessages.MissingDateOfBirth;
		}
		
		public static string MissingCurrency()
		{
				return FaultMessages.MissingCurrency;
		}
		
		public static string InvalidAmountInBookingRequest()
		{
				return FaultMessages.InvalidAmountInBookingRequest;
		}
		
		public static string InvalidCurrencyInBookingRequest()
		{
				return FaultMessages.InvalidCurrencyInBookingRequest;
		}
		
		public static string CardOwnerPhoneNumbersMissing()
		{
				return FaultMessages.CardOwnerPhoneNumbersMissing;
		}
		
		public static string CardOwnerPhoneNumberInvalid()
		{
				return FaultMessages.CardOwnerPhoneNumberInvalid;
		}
		
		public static string MissingTenantConfigurations(List<string> details)
		{
				return string.Format(FaultMessages.MissingTenantConfigurations , string.Join(", ",details)); 
		}
		
		public static string ConnectorIdentifierMissingInMetadataRequest()
		{
				return FaultMessages.ConnectorIdentifierMissingInMetadataRequest;
		}
		
		public static string InvalidProductNameInMetadataRequest()
		{
				return FaultMessages.InvalidProductNameInMetadataRequest;
		}
		
		public static string WrongConnectorIdentifier(string connectorIdentifier)
		{
				return string.Format(FaultMessages.WrongConnectorIdentifier , connectorIdentifier); 
		}
		
		public static string MissingCriteria()
		{
				return FaultMessages.MissingCriteria;
		}
		
		public static string MissingPaymentType()
		{
				return FaultMessages.MissingPaymentType;
		}
		
		public static string MissingBillingAddressCityName()
		{
				return FaultMessages.MissingBillingAddressCityName;
		}
		
		public static string MissingBillingAddressStateCode()
		{
				return FaultMessages.MissingBillingAddressStateCode;
		}
		
		public static string InvalidBookingContactAge(string fieldName)
		{
				return string.Format(FaultMessages.InvalidBookingContactAge , fieldName); 
		}
		
		public static string InvalidCashFormOfPayment()
		{
				return FaultMessages.InvalidCashFormOfPayment;
		}
		
		public static string InvalidCreditCardNumberLength(int length)
		{
				return string.Format(FaultMessages.InvalidCreditCardNumberLength , length); 
		}
		
		public static string MissingBookingContactPhoneNumber()
		{
				return FaultMessages.MissingBookingContactPhoneNumber;
		}
		
		public static string MissingBookingContactPhoneDetails()
		{
				return FaultMessages.MissingBookingContactPhoneDetails;
		}
		
		public static string InvalidTitleInName()
		{
				return FaultMessages.InvalidTitleInName;
		}
		
		public static string InvalidPhoneType()
		{
				return FaultMessages.InvalidPhoneType;
		}
		
		public static string InvalidDate(string dateProperty)
		{
				return string.Format(FaultMessages.InvalidDate , dateProperty); 
		}
		
		public static string MissingCreditCardIssuedBy()
		{
				return FaultMessages.MissingCreditCardIssuedBy;
		}
		
		public static string NonCancellableBooking()
		{
				return FaultMessages.NonCancellableBooking;
		}
		
		public static string IpAddressMissingOrInvalid()
		{
				return FaultMessages.IpAddressMissingOrInvalid;
		}
		
		public static string InvalidDateTimeFormat(string path, string property)
		{
				return string.Format(FaultMessages.InvalidDateTimeFormat , path, property); 
		}
		
		public static string InvalidTimeFormat(string time)
		{
				return string.Format(FaultMessages.InvalidTimeFormat , time); 
		}
		
		public static string MissingAirportCode()
		{
				return FaultMessages.MissingAirportCode;
		}
		
		public static string NoSupportForOnlineCancellation()
		{
				return FaultMessages.NoSupportForOnlineCancellation;
		}
		
		public static string LookUpFailed(string dataType, string Id)
		{
				return string.Format(FaultMessages.LookUpFailed , dataType, Id); 
		}
		
		public static string InvalidCorrelationId()
		{
				return FaultMessages.InvalidCorrelationId;
		}
		
		public static string MissingPickupLocation()
		{
				return FaultMessages.MissingPickupLocation;
		}
		
		public static string MissingDropoffLocation()
		{
				return FaultMessages.MissingDropoffLocation;
		}
		
		public static string MissingPickupAirportOrRentalLocationCode()
		{
				return FaultMessages.MissingPickupAirportOrRentalLocationCode;
		}
		
		public static string MissingPickupDate()
		{
				return FaultMessages.MissingPickupDate;
		}
		
		public static string InvalidPickupDate()
		{
				return FaultMessages.InvalidPickupDate;
		}
		
		public static string InvalidPickupTimeFormat()
		{
				return FaultMessages.InvalidPickupTimeFormat;
		}
		
		public static string MissingDropoffAirportOrRentalLocationCode()
		{
				return FaultMessages.MissingDropoffAirportOrRentalLocationCode;
		}
		
		public static string MissingDropoffDate()
		{
				return FaultMessages.MissingDropoffDate;
		}
		
		public static string InvalidDropoffDate()
		{
				return FaultMessages.InvalidDropoffDate;
		}
		
		public static string InvalidDropoffTimeFormat()
		{
				return FaultMessages.InvalidDropoffTimeFormat;
		}
		
		public static string InvalidPickupCriteria()
		{
				return FaultMessages.InvalidPickupCriteria;
		}
		
		public static string InvalidDropoffCriteria()
		{
				return FaultMessages.InvalidDropoffCriteria;
		}
		
		public static string MissingDriverInfo()
		{
				return FaultMessages.MissingDriverInfo;
		}
		
		public static string MissingDriverAge()
		{
				return FaultMessages.MissingDriverAge;
		}
		
		public static string InvalidVehicleTypeFilter()
		{
				return FaultMessages.InvalidVehicleTypeFilter;
		}
		
		public static string InvalidVehicleCategoryFilter()
		{
				return FaultMessages.InvalidVehicleCategoryFilter;
		}
		
		public static string InvalidVendorFilter()
		{
				return FaultMessages.InvalidVendorFilter;
		}
		
		public static string DropOffPriorToPickupDate()
		{
				return FaultMessages.DropOffPriorToPickupDate;
		}
		
		public static string InvalidCarSearchCriteria()
		{
				return FaultMessages.InvalidCarSearchCriteria;
		}
		
		public static string InvalidCriteriaFound()
		{
				return FaultMessages.InvalidCriteriaFound;
		}
		
		public static string RateLimitExceeded()
		{
				return FaultMessages.RateLimitExceeded;
		}
		
		public static string InvalidDriverNationality()
		{
				return FaultMessages.InvalidDriverNationality;
		}
		
		public static string MissingVendorCode()
		{
				return FaultMessages.MissingVendorCode;
		}
		
		public static string MissingVehicleDetails()
		{
				return FaultMessages.MissingVehicleDetails;
		}
		
		public static string MissingVehicleSippCode()
		{
				return FaultMessages.MissingVehicleSippCode;
		}
		
		public static string InvalidDropoffLocation()
		{
				return FaultMessages.InvalidDropoffLocation;
		}
		
		public static string MissingRateCode()
		{
				return FaultMessages.MissingRateCode;
		}
		
		public static string InvalidRateCode()
		{
				return FaultMessages.InvalidRateCode;
		}
		
		public static string InvalidIATANumber()
		{
				return FaultMessages.InvalidIATANumber;
		}
		
		public static string InvalidDriverAge(int minAge, int maxAge)
		{
				return string.Format(FaultMessages.InvalidDriverAge , minAge, maxAge); 
		}
		
		public static string InvalidSearchLocations()
		{
				return FaultMessages.InvalidSearchLocations;
		}
		
		public static string InvalidCarSearchPattern()
		{
				return FaultMessages.InvalidCarSearchPattern;
		}
		
		public static string InvalidCarSearchSupplierIds()
		{
				return FaultMessages.InvalidCarSearchSupplierIds;
		}
		
		public static string NoRentalLocationsForGivenCriteria()
		{
				return FaultMessages.NoRentalLocationsForGivenCriteria;
		}
		
		public static string InvalidPickupLocation()
		{
				return FaultMessages.InvalidPickupLocation;
		}
		
		public static string InvalidDiscount()
		{
				return FaultMessages.InvalidDiscount;
		}
		
		public static string InvalidCarGroup()
		{
				return FaultMessages.InvalidCarGroup;
		}
		
		public static string BlockedRateCode()
		{
				return FaultMessages.BlockedRateCode;
		}
		
		public static string BlockedDiscountCode()
		{
				return FaultMessages.BlockedDiscountCode;
		}
		
		public static string BlockedIATANumber()
		{
				return FaultMessages.BlockedIATANumber;
		}
		
		public static string InvalidRentalLocation()
		{
				return FaultMessages.InvalidRentalLocation;
		}
		
		public static string InvalidAirportCode()
		{
				return FaultMessages.InvalidAirportCode;
		}
		
		public static string InvalidVendorName()
		{
				return FaultMessages.InvalidVendorName;
		}
		
		public static string InvalidMethodOfPayment()
		{
				return FaultMessages.InvalidMethodOfPayment;
		}
		
		public static string CarTypeNotSupported()
		{
				return FaultMessages.CarTypeNotSupported;
		}
		
		public static string InvalidCoverageType()
		{
				return FaultMessages.InvalidCoverageType;
		}
		
		public static string RetrieveReservationFailed()
		{
				return FaultMessages.RetrieveReservationFailed;
		}
		
		public static string ReservationFailed()
		{
				return FaultMessages.ReservationFailed;
		}
		
		public static string CancellationFailed()
		{
				return FaultMessages.CancellationFailed;
		}
		
		public static string MatchingVehicleNotFound()
		{
				return FaultMessages.MatchingVehicleNotFound;
		}
		
		public static string VehicleTypeNotSupported()
		{
				return FaultMessages.VehicleTypeNotSupported;
		}
		
		public static string VehicleClassNotSupported()
		{
				return FaultMessages.VehicleClassNotSupported;
		}
		
		public static string RateNotAvailble()
		{
				return FaultMessages.RateNotAvailble;
		}
		
		public static string UnableToTransact()
		{
				return FaultMessages.UnableToTransact;
		}
		
		public static string CreditCardNotAccepted()
		{
				return FaultMessages.CreditCardNotAccepted;
		}
		
		public static string StationClosed()
		{
				return FaultMessages.StationClosed;
		}
		
		public static string RentalPeriodLimitExceeds()
		{
				return FaultMessages.RentalPeriodLimitExceeds;
		}
		
		public static string InvalidCarType()
		{
				return FaultMessages.InvalidCarType;
		}
		
		public static string InvalidCreditCard()
		{
				return FaultMessages.InvalidCreditCard;
		}
		
		public static string ModifiedCreditCard()
		{
				return FaultMessages.ModifiedCreditCard;
		}
		
		public static string PackageUnavailable()
		{
				return FaultMessages.PackageUnavailable;
		}
		
		public static string InvalidCreditId()
		{
				return FaultMessages.InvalidCreditId;
		}
		
		public static string DatesNotAvailable()
		{
				return FaultMessages.DatesNotAvailable;
		}
		
		public static string CarSoldOut()
		{
				return FaultMessages.CarSoldOut;
		}
		
		public static string RentalIncludeWeekend()
		{
				return FaultMessages.RentalIncludeWeekend;
		}
		
		public static string RentalIncludeWeekday()
		{
				return FaultMessages.RentalIncludeWeekday;
		}
		
		public static string CarsNotAvailable()
		{
				return FaultMessages.CarsNotAvailable;
		}
		
		public static string ModelNotAvailable()
		{
				return FaultMessages.ModelNotAvailable;
		}
		
		public static string CarGroupNotAvailable()
		{
				return FaultMessages.CarGroupNotAvailable;
		}
		
		public static string InvalidReservation()
		{
				return FaultMessages.InvalidReservation;
		}
		
		public static string AdvancedReservation()
		{
				return FaultMessages.AdvancedReservation;
		}
		
		public static string InvalidToken()
		{
				return FaultMessages.InvalidToken;
		}
		
		public static string MissingVehicleCategory()
		{
				return FaultMessages.MissingVehicleCategory;
		}
		
		public static string MissingVehicleType()
		{
				return FaultMessages.MissingVehicleType;
		}
		
		public static string MissingVehicleTransmission()
		{
				return FaultMessages.MissingVehicleTransmission;
		}
		
		public static string MissingDriverNationality()
		{
				return FaultMessages.MissingDriverNationality;
		}
		
		public static string MissingRentalLocationId()
		{
				return FaultMessages.MissingRentalLocationId;
		}
		
		public static string DropOffTimeMustBeGreaterThanPickupTime()
		{
				return FaultMessages.DropOffTimeMustBeGreaterThanPickupTime;
		}
		
		public static string InvalidRentalDuration(int days)
		{
				return string.Format(FaultMessages.InvalidRentalDuration , days); 
		}
		
		public static string MissingDiscountCodes()
		{
				return FaultMessages.MissingDiscountCodes;
		}
		
		public static string MissingAllowedVehicleCategoriesInFilter()
		{
				return FaultMessages.MissingAllowedVehicleCategoriesInFilter;
		}
		
		public static string MissingAllowedVehicleTypesInFilter()
		{
				return FaultMessages.MissingAllowedVehicleTypesInFilter;
		}
		
		public static string MissingDisAllowedVehicleCategoriesInFilter()
		{
				return FaultMessages.MissingDisAllowedVehicleCategoriesInFilter;
		}
		
		public static string MissingDisAllowedVehicleTypesInFilter()
		{
				return FaultMessages.MissingDisAllowedVehicleTypesInFilter;
		}
		
		public static string InvalidVendorSpecificOptions()
		{
				return FaultMessages.InvalidVendorSpecificOptions;
		}
		
		public static string InvalidFieldValue(string path)
		{
				return string.Format(FaultMessages.InvalidFieldValue , path); 
		}
		
		public static string MissingField(string path)
		{
				return string.Format(FaultMessages.MissingField , path); 
		}
		
		public static string MissingRentalId()
		{
				return FaultMessages.MissingRentalId;
		}
		
		public static string InvalidRentalId()
		{
				return FaultMessages.InvalidRentalId;
		}
		
		public static string EquipmentUnavailable()
		{
				return FaultMessages.EquipmentUnavailable;
		}
		
		public static string OneWayRentalNotPermitted()
		{
				return FaultMessages.OneWayRentalNotPermitted;
		}
		
		public static string TravelBetweenStationsNotPermitted()
		{
				return FaultMessages.TravelBetweenStationsNotPermitted;
		}
		
		public static string InvalidCreditCardName()
		{
				return FaultMessages.InvalidCreditCardName;
		}
		
		public static string BookingVehicleAllocated()
		{
				return FaultMessages.BookingVehicleAllocated;
		}
		
		public static string PhoneCancellation()
		{
				return FaultMessages.PhoneCancellation;
		}
		
		public static string HighEquipmentQuantity()
		{
				return FaultMessages.HighEquipmentQuantity;
		}
		
		public static string AfterHourService()
		{
				return FaultMessages.AfterHourService;
		}
		
		public static string CancellationNotPossible()
		{
				return FaultMessages.CancellationNotPossible;
		}
		
		public static string RentalTermsNotAvailable()
		{
				return FaultMessages.RentalTermsNotAvailable;
		}
		
		public static string ReservationCancelled()
		{
				return FaultMessages.ReservationCancelled;
		}
		
		public static string ReservationExists()
		{
				return FaultMessages.ReservationExists;
		}
		
		public static string AllowDisallowFilterConstraint(string filterCategory)
		{
				return string.Format(FaultMessages.AllowDisallowFilterConstraint , filterCategory); 
		}
		
		public static string CancellationAlreadyAttempted()
		{
				return FaultMessages.CancellationAlreadyAttempted;
		}
		
		public static string NoBookingFoundForCancellation()
		{
				return FaultMessages.NoBookingFoundForCancellation;
		}
		
		public static string CannotCancelFailedOrUnconfirmedBooking()
		{
				return FaultMessages.CannotCancelFailedOrUnconfirmedBooking;
		}
		
		public static string MissingDoorCount()
		{
				return FaultMessages.MissingDoorCount;
		}
		
		public static string MultiFormOfPaymentNotAllowed()
		{
				return FaultMessages.MultiFormOfPaymentNotAllowed;
		}
		
		public static string InvalidDoorCount()
		{
				return FaultMessages.InvalidDoorCount;
		}
		
		public static string InvalidVehicleType(string path)
		{
				return string.Format(FaultMessages.InvalidVehicleType , path); 
		}
		
		public static string InvalidVehicleCategory(string path)
		{
				return string.Format(FaultMessages.InvalidVehicleCategory , path); 
		}
		
		public static string MissingPickupRentalLocationCode()
		{
				return FaultMessages.MissingPickupRentalLocationCode;
		}
		
		public static string MissingDropoffRentalLocationCode()
		{
				return FaultMessages.MissingDropoffRentalLocationCode;
		}
		
		public static string InvalidMinPriceFilter()
		{
				return FaultMessages.InvalidMinPriceFilter;
		}
		
		public static string InvalidMaxPriceFilter()
		{
				return FaultMessages.InvalidMaxPriceFilter;
		}
		
		public static string MinPriceGreaterThanMax()
		{
				return FaultMessages.MinPriceGreaterThanMax;
		}
		
		public static string MissingAddressPostalCode(string parentName)
		{
				return string.Format(FaultMessages.MissingAddressPostalCode , parentName); 
		}
		
		public static string MissingAddressCountryCode(string parentName)
		{
				return string.Format(FaultMessages.MissingAddressCountryCode , parentName); 
		}
		
		public static string MissingAddressLine1(string parentName)
		{
				return string.Format(FaultMessages.MissingAddressLine1 , parentName); 
		}
		
		public static string MissingAddressCity(string parentName)
		{
				return string.Format(FaultMessages.MissingAddressCity , parentName); 
		}
		
		public static string InvalidSearchLocationFormat()
		{
				return FaultMessages.InvalidSearchLocationFormat;
		}
		
		public static string InvalidRadiusForCarSearch(int minRadius, int maxRadius)
		{
				return string.Format(FaultMessages.InvalidRadiusForCarSearch , minRadius, maxRadius); 
		}
		
		public static string System()
		{
				return FaultMessages.System;
		}
		
		public static string UnMappedSupplier(string supplier)
		{
				return string.Format(FaultMessages.UnMappedSupplier , supplier); 
		}
		
		public static string SupplierServerDown()
		{
				return FaultMessages.SupplierServerDown;
		}
		
		public static string SupplierSystem()
		{
				return FaultMessages.SupplierSystem;
		}
		
		public static string TimeOut()
		{
				return FaultMessages.TimeOut;
		}
		
		public static string Supplier()
		{
				return FaultMessages.Supplier;
		}
		
		public static string Application()
		{
				return FaultMessages.Application;
		}
		
		public static string ConnectorCallFaulted()
		{
				return FaultMessages.ConnectorCallFaulted;
		}
		
		public static string InvalidConfigurations()
		{
				return FaultMessages.InvalidConfigurations;
		}
		
		public static string RequestProcessingError()
		{
				return FaultMessages.RequestProcessingError;
		}
		
		public static string SessionStoreRead()
		{
				return FaultMessages.SessionStoreRead;
		}
		
		public static string SessionStoreWrite()
		{
				return FaultMessages.SessionStoreWrite;
		}
		
		public static string CouldNotResolveType(string type, string error)
		{
				return string.Format(FaultMessages.CouldNotResolveType , type, error); 
		}
		
		public static string Metadata()
		{
				return FaultMessages.Metadata;
		}
		
		public static string ParsingFailure()
		{
				return FaultMessages.ParsingFailure;
		}
		
		public static string ServiceCommunication()
		{
				return FaultMessages.ServiceCommunication;
		}
		
		public static string ConnectorServiceCommunication()
		{
				return FaultMessages.ConnectorServiceCommunication;
		}
		
		public static string SupplierCommunication()
		{
				return FaultMessages.SupplierCommunication;
		}
		
		public static string InvalidConnectorResponse()
		{
				return FaultMessages.InvalidConnectorResponse;
		}
		
		public static string InvalidSupplierResponse()
		{
				return FaultMessages.InvalidSupplierResponse;
		}
		
		public static string TenantConfigurationRead()
		{
				return FaultMessages.TenantConfigurationRead;
		}
		
		public static string ContentServiceFaulted()
		{
				return FaultMessages.ContentServiceFaulted;
		}
		
		public static string ContentService()
		{
				return FaultMessages.ContentService;
		}
		
		public static string PricesChanged()
		{
				return FaultMessages.PricesChanged;
		}
		
		public static string CreditCardFraudDetected()
		{
				return FaultMessages.CreditCardFraudDetected;
		}
		
		public static string TranslationMissing(string typeName)
		{
				return string.Format(FaultMessages.TranslationMissing , typeName); 
		}
		
		public static string CancelFailed()
		{
				return FaultMessages.CancelFailed;
		}
		
		public static string SupplierException()
		{
				return FaultMessages.SupplierException;
		}
		
		public static string ConsumerServiceCommunication(string serviceName)
		{
				return string.Format(FaultMessages.ConsumerServiceCommunication , serviceName); 
		}
		
		public static string UnexpectedSystemException()
		{
				return FaultMessages.UnexpectedSystemException;
		}
		
		public static string ConnectorReadFailure(string connectorId)
		{
				return string.Format(FaultMessages.ConnectorReadFailure , connectorId); 
		}
		
		public static string ConnectorConfigurationSpecNotFound(string connectorName)
		{
				return string.Format(FaultMessages.ConnectorConfigurationSpecNotFound , connectorName); 
		}
		
		public static string MissingExternalServiceConfiguration(string configName, string serviceName)
		{
				return string.Format(FaultMessages.MissingExternalServiceConfiguration , configName, serviceName); 
		}
		
		public static string NoResultsForSearchCriteria()
		{
				return FaultMessages.NoResultsForSearchCriteria;
		}
		
		public static string SupplierDisabled(string supplierName)
		{
				return string.Format(FaultMessages.SupplierDisabled , supplierName); 
		}
			}
}