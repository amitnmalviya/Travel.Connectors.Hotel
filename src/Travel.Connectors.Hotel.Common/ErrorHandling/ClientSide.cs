
using System;
using System.Net;
using System.Collections.Generic;
namespace Travel.Connectors.Hotel.Common.ErrorHandling
{
	public static partial class Errors 
	{
		public static partial class ClientSide
		{
			
			public static BaseApplicationException InvalidSessionId()
			{
				return new BadRequestException(  FaultCodes.InvalidSessionId, FaultMessages.InvalidSessionId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidAccountId()
			{
				return new BadRequestException(  FaultCodes.InvalidAccountId, FaultMessages.InvalidAccountId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCurrency()
			{
				return new BadRequestException(  FaultCodes.InvalidCurrency, FaultMessages.InvalidCurrency , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidPosId()
			{
				return new BadRequestException(  FaultCodes.InvalidPosId, FaultMessages.InvalidPosId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidRequest()
			{
				return new BadRequestException(  FaultCodes.InvalidRequest, FaultMessages.InvalidRequest , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException RequestNotFound()
			{
				return new BadRequestException(  FaultCodes.RequestNotFound, FaultMessages.RequestNotFound , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingSessionId()
			{
				return new BadRequestException(  FaultCodes.MissingSessionId, FaultMessages.MissingSessionId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingSupplierDetails()
			{
				return new BadRequestException(  FaultCodes.MissingSupplierDetails, FaultMessages.MissingSupplierDetails , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingSupplierId()
			{
				return new BadRequestException(  FaultCodes.MissingSupplierId, FaultMessages.MissingSupplierId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingSupplierName()
			{
				return new BadRequestException(  FaultCodes.MissingSupplierName, FaultMessages.MissingSupplierName , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingSupplierConfigurations()
			{
				return new BadRequestException(  FaultCodes.MissingSupplierConfigurations, FaultMessages.MissingSupplierConfigurations , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingSupplierConfiguration(List<string> configuration)
			{
				return new BadRequestException(  FaultCodes.MissingSupplierConfiguration, string.Format(FaultMessages.MissingSupplierConfiguration , string.Join(", ",configuration)) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCheckInDate()
			{
				return new BadRequestException(  FaultCodes.InvalidCheckInDate, FaultMessages.InvalidCheckInDate , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException ConnectorMetadataNotFound(List<string> supplier)
			{
				return new BadRequestException(  FaultCodes.ConnectorMetadataNotFound, string.Format(FaultMessages.ConnectorMetadataNotFound , string.Join(", ",supplier)) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidVersion()
			{
				return new BadRequestException(  FaultCodes.InvalidVersion, FaultMessages.InvalidVersion , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCredentials()
			{
				return new BadRequestException(  FaultCodes.InvalidCredentials, FaultMessages.InvalidCredentials , HttpStatusCode.Unauthorized );
			}
		
			public static BaseApplicationException InvalidCircularRegion()
			{
				return new BadRequestException(  FaultCodes.InvalidCircularRegion, FaultMessages.InvalidCircularRegion , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException ValidationFailure()
			{
				return new BadRequestException(  FaultCodes.ValidationFailure, FaultMessages.ValidationFailure , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidGeocodes()
			{
				return new BadRequestException(  FaultCodes.InvalidGeocodes, FaultMessages.InvalidGeocodes , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingRoomRate()
			{
				return new BadRequestException(  FaultCodes.MissingRoomRate, FaultMessages.MissingRoomRate , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingRateReferenceId()
			{
				return new BadRequestException(  FaultCodes.MissingRateReferenceId, FaultMessages.MissingRateReferenceId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCountryCode()
			{
				return new BadRequestException(  FaultCodes.InvalidCountryCode, FaultMessages.InvalidCountryCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidRadius()
			{
				return new BadRequestException(  FaultCodes.InvalidRadius, FaultMessages.InvalidRadius , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidRateIdFormat()
			{
				return new BadRequestException(  FaultCodes.InvalidRateIdFormat, FaultMessages.InvalidRateIdFormat , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingRateIds()
			{
				return new BadRequestException(  FaultCodes.MissingRateIds, FaultMessages.MissingRateIds , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidSupplierIdInSupplierSpecificOptions(string supplierId)
			{
				return new BadRequestException(  FaultCodes.InvalidSupplierIdInSupplierSpecificOptions, string.Format(FaultMessages.InvalidSupplierIdInSupplierSpecificOptions , supplierId) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException TenantNotFound(string tenantId)
			{
				return new BadRequestException(  FaultCodes.TenantNotFound, string.Format(FaultMessages.TenantNotFound , tenantId) , HttpStatusCode.NotFound );
			}
		
			public static BaseApplicationException InvalidCulture()
			{
				return new BadRequestException(  FaultCodes.InvalidCulture, FaultMessages.InvalidCulture , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException SupplierConfigurationNotAvailable(List<string> supplierId)
			{
				return new BadRequestException(  FaultCodes.SupplierConfigurationNotAvailable, string.Format(FaultMessages.SupplierConfigurationNotAvailable , string.Join(", ",supplierId)) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingConnectorMetadata(List<string> missingDetails)
			{
				return new BadRequestException(  FaultCodes.MissingConnectorMetadata, string.Format(FaultMessages.MissingConnectorMetadata , string.Join(", ",missingDetails)) , HttpStatusCode.NotFound );
			}
		
			public static BaseApplicationException UnSupportedCulture(string culture)
			{
				return new BadRequestException(  FaultCodes.UnSupportedCulture, string.Format(FaultMessages.UnSupportedCulture , culture) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException UnSupportedRateTypes(List<string> ratetypes)
			{
				return new BadRequestException(  FaultCodes.UnSupportedRateTypes, string.Format(FaultMessages.UnSupportedRateTypes , string.Join(", ",ratetypes)) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCreditCardIssuedBy()
			{
				return new BadRequestException(  FaultCodes.InvalidCreditCardIssuedBy, FaultMessages.InvalidCreditCardIssuedBy , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CreditCardNotRequired()
			{
				return new BadRequestException(  FaultCodes.CreditCardNotRequired, FaultMessages.CreditCardNotRequired , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CreditCardRequired()
			{
				return new BadRequestException(  FaultCodes.CreditCardRequired, FaultMessages.CreditCardRequired , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException UnSupportedSpecialRequest()
			{
				return new BadRequestException(  FaultCodes.UnSupportedSpecialRequest, FaultMessages.UnSupportedSpecialRequest , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException UnSupportedLoyaltyMembership()
			{
				return new BadRequestException(  FaultCodes.UnSupportedLoyaltyMembership, FaultMessages.UnSupportedLoyaltyMembership , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException FirstNameLengthExceeded(string length)
			{
				return new BadRequestException(  FaultCodes.FirstNameLengthExceeded, string.Format(FaultMessages.FirstNameLengthExceeded , length) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException LastNameLengthExceeded(string length)
			{
				return new BadRequestException(  FaultCodes.LastNameLengthExceeded, string.Format(FaultMessages.LastNameLengthExceeded , length) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidFirstName()
			{
				return new BadRequestException(  FaultCodes.InvalidFirstName, FaultMessages.InvalidFirstName , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidLastName()
			{
				return new BadRequestException(  FaultCodes.InvalidLastName, FaultMessages.InvalidLastName , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingBookingContactNameInformation(string fieldName)
			{
				return new BadRequestException(  FaultCodes.MissingBookingContactNameInformation, string.Format(FaultMessages.MissingBookingContactNameInformation , fieldName) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingContactFirstName()
			{
				return new BadRequestException(  FaultCodes.MissingContactFirstName, FaultMessages.MissingContactFirstName , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingContactLastName()
			{
				return new BadRequestException(  FaultCodes.MissingContactLastName, FaultMessages.MissingContactLastName , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidContactInformation()
			{
				return new BadRequestException(  FaultCodes.InvalidContactInformation, FaultMessages.InvalidContactInformation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidPhoneInformation(string parentName)
			{
				return new BadRequestException(  FaultCodes.InvalidPhoneInformation, string.Format(FaultMessages.InvalidPhoneInformation , parentName) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidAddressInformation()
			{
				return new BadRequestException(  FaultCodes.InvalidAddressInformation, FaultMessages.InvalidAddressInformation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingAddressLine()
			{
				return new BadRequestException(  FaultCodes.MissingAddressLine, FaultMessages.MissingAddressLine , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingCityInformation()
			{
				return new BadRequestException(  FaultCodes.MissingCityInformation, FaultMessages.MissingCityInformation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingCountryCode()
			{
				return new BadRequestException(  FaultCodes.MissingCountryCode, FaultMessages.MissingCountryCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingEmailInformation()
			{
				return new BadRequestException(  FaultCodes.MissingEmailInformation, FaultMessages.MissingEmailInformation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidMembershipInformation()
			{
				return new BadRequestException(  FaultCodes.InvalidMembershipInformation, FaultMessages.InvalidMembershipInformation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingCreditCardNumber()
			{
				return new BadRequestException(  FaultCodes.MissingCreditCardNumber, FaultMessages.MissingCreditCardNumber , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingNameOnCreditCard()
			{
				return new BadRequestException(  FaultCodes.MissingNameOnCreditCard, FaultMessages.MissingNameOnCreditCard , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingCreditCardExpiryDate()
			{
				return new BadRequestException(  FaultCodes.MissingCreditCardExpiryDate, FaultMessages.MissingCreditCardExpiryDate , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CreditCardExpired()
			{
				return new BadRequestException(  FaultCodes.CreditCardExpired, FaultMessages.CreditCardExpired , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingCreditCardCvv()
			{
				return new BadRequestException(  FaultCodes.MissingCreditCardCvv, FaultMessages.MissingCreditCardCvv , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingCreditCardBillingAddress()
			{
				return new BadRequestException(  FaultCodes.MissingCreditCardBillingAddress, FaultMessages.MissingCreditCardBillingAddress , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingBillingAddressLine1()
			{
				return new BadRequestException(  FaultCodes.MissingBillingAddressLine1, FaultMessages.MissingBillingAddressLine1 , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingBillingAddressCity()
			{
				return new BadRequestException(  FaultCodes.MissingBillingAddressCity, FaultMessages.MissingBillingAddressCity , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingBillingAddressCountryCode()
			{
				return new BadRequestException(  FaultCodes.MissingBillingAddressCountryCode, FaultMessages.MissingBillingAddressCountryCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingBillingAddressPostalCode()
			{
				return new BadRequestException(  FaultCodes.MissingBillingAddressPostalCode, FaultMessages.MissingBillingAddressPostalCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingCreditCardStateDetails()
			{
				return new BadRequestException(  FaultCodes.MissingCreditCardStateDetails, FaultMessages.MissingCreditCardStateDetails , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCreditCardExpiryMonth()
			{
				return new BadRequestException(  FaultCodes.InvalidCreditCardExpiryMonth, FaultMessages.InvalidCreditCardExpiryMonth , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCreditCardExpiryYear()
			{
				return new BadRequestException(  FaultCodes.InvalidCreditCardExpiryYear, FaultMessages.InvalidCreditCardExpiryYear , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException SupplierValidation()
			{
				return new BadRequestException(  FaultCodes.SupplierValidation, FaultMessages.SupplierValidation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCreditCardDetails()
			{
				return new BadRequestException(  FaultCodes.InvalidCreditCardDetails, FaultMessages.InvalidCreditCardDetails , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CreditCardDeclined()
			{
				return new BadRequestException(  FaultCodes.CreditCardDeclined, FaultMessages.CreditCardDeclined , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCreditCardSecurityValue()
			{
				return new BadRequestException(  FaultCodes.InvalidCreditCardSecurityValue, FaultMessages.InvalidCreditCardSecurityValue , HttpStatusCode.Unauthorized );
			}
		
			public static BaseApplicationException InvalidCreditCardSecureCode()
			{
				return new BadRequestException(  FaultCodes.InvalidCreditCardSecureCode, FaultMessages.InvalidCreditCardSecureCode , HttpStatusCode.Unauthorized );
			}
		
			public static BaseApplicationException MissingDetailsInCancellation(List<string> details)
			{
				return new BadRequestException(  FaultCodes.MissingDetailsInCancellation, string.Format(FaultMessages.MissingDetailsInCancellation , string.Join(", ",details)) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException BookingDoesNotExist()
			{
				return new BadRequestException(  FaultCodes.BookingDoesNotExist, FaultMessages.BookingDoesNotExist , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException BookingAlreadyCancelled()
			{
				return new BadRequestException(  FaultCodes.BookingAlreadyCancelled, FaultMessages.BookingAlreadyCancelled , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException StateNotFound()
			{
				return new BadRequestException(  FaultCodes.StateNotFound, FaultMessages.StateNotFound , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidBookingConfirmation()
			{
				return new BadRequestException(  FaultCodes.InvalidBookingConfirmation, FaultMessages.InvalidBookingConfirmation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingCustomerName()
			{
				return new BadRequestException(  FaultCodes.MissingCustomerName, FaultMessages.MissingCustomerName , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CancellationNotSupported(string supplier)
			{
				return new BadRequestException(  FaultCodes.CancellationNotSupported, string.Format(FaultMessages.CancellationNotSupported , supplier) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CustomerInformationRequiredInCancellation(string supplier)
			{
				return new BadRequestException(  FaultCodes.CustomerInformationRequiredInCancellation, string.Format(FaultMessages.CustomerInformationRequiredInCancellation , supplier) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidAdultAge(int adultAgeLowerLimit, int adultAgeUpperLimit)
			{
				return new BadRequestException(  FaultCodes.InvalidAdultAge, string.Format(FaultMessages.InvalidAdultAge , adultAgeLowerLimit, adultAgeUpperLimit) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidSearchDate(int numberOfDays)
			{
				return new BadRequestException(  FaultCodes.InvalidSearchDate, string.Format(FaultMessages.InvalidSearchDate , numberOfDays) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidValueInRequest(string fieldName)
			{
				return new BadRequestException(  FaultCodes.InvalidValueInRequest, string.Format(FaultMessages.InvalidValueInRequest , fieldName) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidSupplierId()
			{
				return new BadRequestException(  FaultCodes.InvalidSupplierId, FaultMessages.InvalidSupplierId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingTenantId()
			{
				return new BadRequestException(  FaultCodes.MissingTenantId, FaultMessages.MissingTenantId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException NoResultsOrAllResultsFilteredOut()
			{
				return new ContentNotFoundException(  FaultCodes.NoResultsOrAllResultsFilteredOut, FaultMessages.NoResultsOrAllResultsFilteredOut , HttpStatusCode.NotFound );
			}
		
			public static BaseApplicationException MissingCustomerInformationInBooking()
			{
				return new BadRequestException(  FaultCodes.MissingCustomerInformationInBooking, FaultMessages.MissingCustomerInformationInBooking , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingTitleInName()
			{
				return new BadRequestException(  FaultCodes.MissingTitleInName, FaultMessages.MissingTitleInName , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingLocationCode(string locationType)
			{
				return new BadRequestException(  FaultCodes.MissingLocationCode, string.Format(FaultMessages.MissingLocationCode , locationType) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingLocationName(string locationType)
			{
				return new BadRequestException(  FaultCodes.MissingLocationName, string.Format(FaultMessages.MissingLocationName , locationType) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingStateInformation()
			{
				return new BadRequestException(  FaultCodes.MissingStateInformation, FaultMessages.MissingStateInformation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidEmailAddress()
			{
				return new BadRequestException(  FaultCodes.InvalidEmailAddress, FaultMessages.InvalidEmailAddress , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingNationality()
			{
				return new BadRequestException(  FaultCodes.MissingNationality, FaultMessages.MissingNationality , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDateOfBirth()
			{
				return new BadRequestException(  FaultCodes.MissingDateOfBirth, FaultMessages.MissingDateOfBirth , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingCurrency()
			{
				return new BadRequestException(  FaultCodes.MissingCurrency, FaultMessages.MissingCurrency , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidAmountInBookingRequest()
			{
				return new BadRequestException(  FaultCodes.InvalidAmountInBookingRequest, FaultMessages.InvalidAmountInBookingRequest , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCurrencyInBookingRequest()
			{
				return new BadRequestException(  FaultCodes.InvalidCurrencyInBookingRequest, FaultMessages.InvalidCurrencyInBookingRequest , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CardOwnerPhoneNumbersMissing()
			{
				return new BadRequestException(  FaultCodes.CardOwnerPhoneNumbersMissing, FaultMessages.CardOwnerPhoneNumbersMissing , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CardOwnerPhoneNumberInvalid()
			{
				return new BadRequestException(  FaultCodes.CardOwnerPhoneNumberInvalid, FaultMessages.CardOwnerPhoneNumberInvalid , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingTenantConfigurations(List<string> details)
			{
				return new BadRequestException(  FaultCodes.MissingTenantConfigurations, string.Format(FaultMessages.MissingTenantConfigurations , string.Join(", ",details)) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException ConnectorIdentifierMissingInMetadataRequest()
			{
				return new BadRequestException(  FaultCodes.ConnectorIdentifierMissingInMetadataRequest, FaultMessages.ConnectorIdentifierMissingInMetadataRequest , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidProductNameInMetadataRequest()
			{
				return new BadRequestException(  FaultCodes.InvalidProductNameInMetadataRequest, FaultMessages.InvalidProductNameInMetadataRequest , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException WrongConnectorIdentifier(string connectorIdentifier)
			{
				return new BadRequestException(  FaultCodes.WrongConnectorIdentifier, string.Format(FaultMessages.WrongConnectorIdentifier , connectorIdentifier) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingCriteria()
			{
				return new BadRequestException(  FaultCodes.MissingCriteria, FaultMessages.MissingCriteria , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingPaymentType()
			{
				return new BadRequestException(  FaultCodes.MissingPaymentType, FaultMessages.MissingPaymentType , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingBillingAddressCityName()
			{
				return new BadRequestException(  FaultCodes.MissingBillingAddressCityName, FaultMessages.MissingBillingAddressCityName , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingBillingAddressStateCode()
			{
				return new BadRequestException(  FaultCodes.MissingBillingAddressStateCode, FaultMessages.MissingBillingAddressStateCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidBookingContactAge(string fieldName)
			{
				return new BadRequestException(  FaultCodes.InvalidBookingContactAge, string.Format(FaultMessages.InvalidBookingContactAge , fieldName) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCashFormOfPayment()
			{
				return new BadRequestException(  FaultCodes.InvalidCashFormOfPayment, FaultMessages.InvalidCashFormOfPayment , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCreditCardNumberLength(int length)
			{
				return new BadRequestException(  FaultCodes.InvalidCreditCardNumberLength, string.Format(FaultMessages.InvalidCreditCardNumberLength , length) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingBookingContactPhoneNumber()
			{
				return new BadRequestException(  FaultCodes.MissingBookingContactPhoneNumber, FaultMessages.MissingBookingContactPhoneNumber , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingBookingContactPhoneDetails()
			{
				return new BadRequestException(  FaultCodes.MissingBookingContactPhoneDetails, FaultMessages.MissingBookingContactPhoneDetails , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidTitleInName()
			{
				return new BadRequestException(  FaultCodes.InvalidTitleInName, FaultMessages.InvalidTitleInName , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidPhoneType()
			{
				return new BadRequestException(  FaultCodes.InvalidPhoneType, FaultMessages.InvalidPhoneType , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidDate(string dateProperty)
			{
				return new BadRequestException(  FaultCodes.InvalidDate, string.Format(FaultMessages.InvalidDate , dateProperty) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingCreditCardIssuedBy()
			{
				return new BadRequestException(  FaultCodes.MissingCreditCardIssuedBy, FaultMessages.MissingCreditCardIssuedBy , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException NonCancellableBooking()
			{
				return new BadRequestException(  FaultCodes.NonCancellableBooking, FaultMessages.NonCancellableBooking , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException IpAddressMissingOrInvalid()
			{
				return new BadRequestException(  FaultCodes.IpAddressMissingOrInvalid, FaultMessages.IpAddressMissingOrInvalid , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidDateTimeFormat(string path, string property)
			{
				return new BadRequestException(  FaultCodes.InvalidDateTimeFormat, string.Format(FaultMessages.InvalidDateTimeFormat , path, property) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidTimeFormat(string time)
			{
				return new BadRequestException(  FaultCodes.InvalidTimeFormat, string.Format(FaultMessages.InvalidTimeFormat , time) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingAirportCode()
			{
				return new BadRequestException(  FaultCodes.MissingAirportCode, FaultMessages.MissingAirportCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException NoSupportForOnlineCancellation()
			{
				return new BadRequestException(  FaultCodes.NoSupportForOnlineCancellation, FaultMessages.NoSupportForOnlineCancellation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException LookUpFailed(string dataType, string Id)
			{
				return new BadRequestException(  FaultCodes.LookUpFailed, string.Format(FaultMessages.LookUpFailed , dataType, Id) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCorrelationId()
			{
				return new BadRequestException(  FaultCodes.InvalidCorrelationId, FaultMessages.InvalidCorrelationId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingPickupLocation()
			{
				return new BadRequestException(  FaultCodes.MissingPickupLocation, FaultMessages.MissingPickupLocation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDropoffLocation()
			{
				return new BadRequestException(  FaultCodes.MissingDropoffLocation, FaultMessages.MissingDropoffLocation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingPickupAirportOrRentalLocationCode()
			{
				return new BadRequestException(  FaultCodes.MissingPickupAirportOrRentalLocationCode, FaultMessages.MissingPickupAirportOrRentalLocationCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingPickupDate()
			{
				return new BadRequestException(  FaultCodes.MissingPickupDate, FaultMessages.MissingPickupDate , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidPickupDate()
			{
				return new BadRequestException(  FaultCodes.InvalidPickupDate, FaultMessages.InvalidPickupDate , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidPickupTimeFormat()
			{
				return new BadRequestException(  FaultCodes.InvalidPickupTimeFormat, FaultMessages.InvalidPickupTimeFormat , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDropoffAirportOrRentalLocationCode()
			{
				return new BadRequestException(  FaultCodes.MissingDropoffAirportOrRentalLocationCode, FaultMessages.MissingDropoffAirportOrRentalLocationCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDropoffDate()
			{
				return new BadRequestException(  FaultCodes.MissingDropoffDate, FaultMessages.MissingDropoffDate , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidDropoffDate()
			{
				return new BadRequestException(  FaultCodes.InvalidDropoffDate, FaultMessages.InvalidDropoffDate , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidDropoffTimeFormat()
			{
				return new BadRequestException(  FaultCodes.InvalidDropoffTimeFormat, FaultMessages.InvalidDropoffTimeFormat , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidPickupCriteria()
			{
				return new BadRequestException(  FaultCodes.InvalidPickupCriteria, FaultMessages.InvalidPickupCriteria , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidDropoffCriteria()
			{
				return new BadRequestException(  FaultCodes.InvalidDropoffCriteria, FaultMessages.InvalidDropoffCriteria , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDriverInfo()
			{
				return new BadRequestException(  FaultCodes.MissingDriverInfo, FaultMessages.MissingDriverInfo , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDriverAge()
			{
				return new BadRequestException(  FaultCodes.MissingDriverAge, FaultMessages.MissingDriverAge , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidVehicleTypeFilter()
			{
				return new BadRequestException(  FaultCodes.InvalidVehicleTypeFilter, FaultMessages.InvalidVehicleTypeFilter , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidVehicleCategoryFilter()
			{
				return new BadRequestException(  FaultCodes.InvalidVehicleCategoryFilter, FaultMessages.InvalidVehicleCategoryFilter , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidVendorFilter()
			{
				return new BadRequestException(  FaultCodes.InvalidVendorFilter, FaultMessages.InvalidVendorFilter , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException DropOffPriorToPickupDate()
			{
				return new BadRequestException(  FaultCodes.DropOffPriorToPickupDate, FaultMessages.DropOffPriorToPickupDate , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCarSearchCriteria()
			{
				return new BadRequestException(  FaultCodes.InvalidCarSearchCriteria, FaultMessages.InvalidCarSearchCriteria , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCriteriaFound()
			{
				return new BadRequestException(  FaultCodes.InvalidCriteriaFound, FaultMessages.InvalidCriteriaFound , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException RateLimitExceeded()
			{
				return new BadRequestException(  FaultCodes.RateLimitExceeded, FaultMessages.RateLimitExceeded , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidDriverNationality()
			{
				return new BadRequestException(  FaultCodes.InvalidDriverNationality, FaultMessages.InvalidDriverNationality , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingVendorCode()
			{
				return new BadRequestException(  FaultCodes.MissingVendorCode, FaultMessages.MissingVendorCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingVehicleDetails()
			{
				return new BadRequestException(  FaultCodes.MissingVehicleDetails, FaultMessages.MissingVehicleDetails , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingVehicleSippCode()
			{
				return new BadRequestException(  FaultCodes.MissingVehicleSippCode, FaultMessages.MissingVehicleSippCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidDropoffLocation()
			{
				return new BadRequestException(  FaultCodes.InvalidDropoffLocation, FaultMessages.InvalidDropoffLocation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingRateCode()
			{
				return new BadRequestException(  FaultCodes.MissingRateCode, FaultMessages.MissingRateCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidRateCode()
			{
				return new BadRequestException(  FaultCodes.InvalidRateCode, FaultMessages.InvalidRateCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidIATANumber()
			{
				return new BadRequestException(  FaultCodes.InvalidIATANumber, FaultMessages.InvalidIATANumber , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidDriverAge(int minAge, int maxAge)
			{
				return new BadRequestException(  FaultCodes.InvalidDriverAge, string.Format(FaultMessages.InvalidDriverAge , minAge, maxAge) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidSearchLocations()
			{
				return new BadRequestException(  FaultCodes.InvalidSearchLocations, FaultMessages.InvalidSearchLocations , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCarSearchPattern()
			{
				return new BadRequestException(  FaultCodes.InvalidCarSearchPattern, FaultMessages.InvalidCarSearchPattern , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCarSearchSupplierIds()
			{
				return new BadRequestException(  FaultCodes.InvalidCarSearchSupplierIds, FaultMessages.InvalidCarSearchSupplierIds , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException NoRentalLocationsForGivenCriteria()
			{
				return new BadRequestException(  FaultCodes.NoRentalLocationsForGivenCriteria, FaultMessages.NoRentalLocationsForGivenCriteria , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidPickupLocation()
			{
				return new BadRequestException(  FaultCodes.InvalidPickupLocation, FaultMessages.InvalidPickupLocation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidDiscount()
			{
				return new BadRequestException(  FaultCodes.InvalidDiscount, FaultMessages.InvalidDiscount , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCarGroup()
			{
				return new BadRequestException(  FaultCodes.InvalidCarGroup, FaultMessages.InvalidCarGroup , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException BlockedRateCode()
			{
				return new BadRequestException(  FaultCodes.BlockedRateCode, FaultMessages.BlockedRateCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException BlockedDiscountCode()
			{
				return new BadRequestException(  FaultCodes.BlockedDiscountCode, FaultMessages.BlockedDiscountCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException BlockedIATANumber()
			{
				return new BadRequestException(  FaultCodes.BlockedIATANumber, FaultMessages.BlockedIATANumber , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidRentalLocation()
			{
				return new BadRequestException(  FaultCodes.InvalidRentalLocation, FaultMessages.InvalidRentalLocation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidAirportCode()
			{
				return new BadRequestException(  FaultCodes.InvalidAirportCode, FaultMessages.InvalidAirportCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidVendorName()
			{
				return new BadRequestException(  FaultCodes.InvalidVendorName, FaultMessages.InvalidVendorName , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidMethodOfPayment()
			{
				return new BadRequestException(  FaultCodes.InvalidMethodOfPayment, FaultMessages.InvalidMethodOfPayment , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CarTypeNotSupported()
			{
				return new BadRequestException(  FaultCodes.CarTypeNotSupported, FaultMessages.CarTypeNotSupported , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCoverageType()
			{
				return new BadRequestException(  FaultCodes.InvalidCoverageType, FaultMessages.InvalidCoverageType , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException RetrieveReservationFailed()
			{
				return new BadRequestException(  FaultCodes.RetrieveReservationFailed, FaultMessages.RetrieveReservationFailed , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException ReservationFailed()
			{
				return new BadRequestException(  FaultCodes.ReservationFailed, FaultMessages.ReservationFailed , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CancellationFailed()
			{
				return new BadRequestException(  FaultCodes.CancellationFailed, FaultMessages.CancellationFailed , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MatchingVehicleNotFound()
			{
				return new BadRequestException(  FaultCodes.MatchingVehicleNotFound, FaultMessages.MatchingVehicleNotFound , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException VehicleTypeNotSupported()
			{
				return new BadRequestException(  FaultCodes.VehicleTypeNotSupported, FaultMessages.VehicleTypeNotSupported , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException VehicleClassNotSupported()
			{
				return new BadRequestException(  FaultCodes.VehicleClassNotSupported, FaultMessages.VehicleClassNotSupported , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException RateNotAvailble()
			{
				return new BadRequestException(  FaultCodes.RateNotAvailble, FaultMessages.RateNotAvailble , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException UnableToTransact()
			{
				return new BadRequestException(  FaultCodes.UnableToTransact, FaultMessages.UnableToTransact , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CreditCardNotAccepted()
			{
				return new BadRequestException(  FaultCodes.CreditCardNotAccepted, FaultMessages.CreditCardNotAccepted , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException StationClosed()
			{
				return new BadRequestException(  FaultCodes.StationClosed, FaultMessages.StationClosed , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException RentalPeriodLimitExceeds()
			{
				return new BadRequestException(  FaultCodes.RentalPeriodLimitExceeds, FaultMessages.RentalPeriodLimitExceeds , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCarType()
			{
				return new BadRequestException(  FaultCodes.InvalidCarType, FaultMessages.InvalidCarType , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCreditCard()
			{
				return new BadRequestException(  FaultCodes.InvalidCreditCard, FaultMessages.InvalidCreditCard , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException ModifiedCreditCard()
			{
				return new BadRequestException(  FaultCodes.ModifiedCreditCard, FaultMessages.ModifiedCreditCard , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException PackageUnavailable()
			{
				return new BadRequestException(  FaultCodes.PackageUnavailable, FaultMessages.PackageUnavailable , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCreditId()
			{
				return new BadRequestException(  FaultCodes.InvalidCreditId, FaultMessages.InvalidCreditId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException DatesNotAvailable()
			{
				return new BadRequestException(  FaultCodes.DatesNotAvailable, FaultMessages.DatesNotAvailable , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CarSoldOut()
			{
				return new BadRequestException(  FaultCodes.CarSoldOut, FaultMessages.CarSoldOut , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException RentalIncludeWeekend()
			{
				return new BadRequestException(  FaultCodes.RentalIncludeWeekend, FaultMessages.RentalIncludeWeekend , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException RentalIncludeWeekday()
			{
				return new BadRequestException(  FaultCodes.RentalIncludeWeekday, FaultMessages.RentalIncludeWeekday , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CarsNotAvailable()
			{
				return new BadRequestException(  FaultCodes.CarsNotAvailable, FaultMessages.CarsNotAvailable , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException ModelNotAvailable()
			{
				return new BadRequestException(  FaultCodes.ModelNotAvailable, FaultMessages.ModelNotAvailable , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CarGroupNotAvailable()
			{
				return new BadRequestException(  FaultCodes.CarGroupNotAvailable, FaultMessages.CarGroupNotAvailable , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidReservation()
			{
				return new BadRequestException(  FaultCodes.InvalidReservation, FaultMessages.InvalidReservation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException AdvancedReservation()
			{
				return new BadRequestException(  FaultCodes.AdvancedReservation, FaultMessages.AdvancedReservation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidToken()
			{
				return new BadRequestException(  FaultCodes.InvalidToken, FaultMessages.InvalidToken , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingVehicleCategory()
			{
				return new BadRequestException(  FaultCodes.MissingVehicleCategory, FaultMessages.MissingVehicleCategory , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingVehicleType()
			{
				return new BadRequestException(  FaultCodes.MissingVehicleType, FaultMessages.MissingVehicleType , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingVehicleTransmission()
			{
				return new BadRequestException(  FaultCodes.MissingVehicleTransmission, FaultMessages.MissingVehicleTransmission , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDriverNationality()
			{
				return new BadRequestException(  FaultCodes.MissingDriverNationality, FaultMessages.MissingDriverNationality , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingRentalLocationId()
			{
				return new BadRequestException(  FaultCodes.MissingRentalLocationId, FaultMessages.MissingRentalLocationId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException DropOffTimeMustBeGreaterThanPickupTime()
			{
				return new BadRequestException(  FaultCodes.DropOffTimeMustBeGreaterThanPickupTime, FaultMessages.DropOffTimeMustBeGreaterThanPickupTime , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidRentalDuration(int days)
			{
				return new BadRequestException(  FaultCodes.InvalidRentalDuration, string.Format(FaultMessages.InvalidRentalDuration , days) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDiscountCodes()
			{
				return new BadRequestException(  FaultCodes.MissingDiscountCodes, FaultMessages.MissingDiscountCodes , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingAllowedVehicleCategoriesInFilter()
			{
				return new BadRequestException(  FaultCodes.MissingAllowedVehicleCategoriesInFilter, FaultMessages.MissingAllowedVehicleCategoriesInFilter , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingAllowedVehicleTypesInFilter()
			{
				return new BadRequestException(  FaultCodes.MissingAllowedVehicleTypesInFilter, FaultMessages.MissingAllowedVehicleTypesInFilter , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDisAllowedVehicleCategoriesInFilter()
			{
				return new BadRequestException(  FaultCodes.MissingDisAllowedVehicleCategoriesInFilter, FaultMessages.MissingDisAllowedVehicleCategoriesInFilter , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDisAllowedVehicleTypesInFilter()
			{
				return new BadRequestException(  FaultCodes.MissingDisAllowedVehicleTypesInFilter, FaultMessages.MissingDisAllowedVehicleTypesInFilter , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidVendorSpecificOptions()
			{
				return new BadRequestException(  FaultCodes.InvalidVendorSpecificOptions, FaultMessages.InvalidVendorSpecificOptions , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidFieldValue(string path)
			{
				return new BadRequestException(  FaultCodes.InvalidFieldValue, string.Format(FaultMessages.InvalidFieldValue , path) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingField(string path)
			{
				return new BadRequestException(  FaultCodes.MissingField, string.Format(FaultMessages.MissingField , path) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingRentalId()
			{
				return new BadRequestException(  FaultCodes.MissingRentalId, FaultMessages.MissingRentalId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidRentalId()
			{
				return new BadRequestException(  FaultCodes.InvalidRentalId, FaultMessages.InvalidRentalId , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException EquipmentUnavailable()
			{
				return new BadRequestException(  FaultCodes.EquipmentUnavailable, FaultMessages.EquipmentUnavailable , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException OneWayRentalNotPermitted()
			{
				return new BadRequestException(  FaultCodes.OneWayRentalNotPermitted, FaultMessages.OneWayRentalNotPermitted , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException TravelBetweenStationsNotPermitted()
			{
				return new BadRequestException(  FaultCodes.TravelBetweenStationsNotPermitted, FaultMessages.TravelBetweenStationsNotPermitted , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidCreditCardName()
			{
				return new BadRequestException(  FaultCodes.InvalidCreditCardName, FaultMessages.InvalidCreditCardName , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException BookingVehicleAllocated()
			{
				return new BadRequestException(  FaultCodes.BookingVehicleAllocated, FaultMessages.BookingVehicleAllocated , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException PhoneCancellation()
			{
				return new BadRequestException(  FaultCodes.PhoneCancellation, FaultMessages.PhoneCancellation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException HighEquipmentQuantity()
			{
				return new BadRequestException(  FaultCodes.HighEquipmentQuantity, FaultMessages.HighEquipmentQuantity , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException AfterHourService()
			{
				return new BadRequestException(  FaultCodes.AfterHourService, FaultMessages.AfterHourService , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CancellationNotPossible()
			{
				return new BadRequestException(  FaultCodes.CancellationNotPossible, FaultMessages.CancellationNotPossible , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException RentalTermsNotAvailable()
			{
				return new BadRequestException(  FaultCodes.RentalTermsNotAvailable, FaultMessages.RentalTermsNotAvailable , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException ReservationCancelled()
			{
				return new BadRequestException(  FaultCodes.ReservationCancelled, FaultMessages.ReservationCancelled , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException ReservationExists()
			{
				return new BadRequestException(  FaultCodes.ReservationExists, FaultMessages.ReservationExists , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException AllowDisallowFilterConstraint(string filterCategory)
			{
				return new BadRequestException(  FaultCodes.AllowDisallowFilterConstraint, string.Format(FaultMessages.AllowDisallowFilterConstraint , filterCategory) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CancellationAlreadyAttempted()
			{
				return new BadRequestException(  FaultCodes.CancellationAlreadyAttempted, FaultMessages.CancellationAlreadyAttempted , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException NoBookingFoundForCancellation()
			{
				return new BadRequestException(  FaultCodes.NoBookingFoundForCancellation, FaultMessages.NoBookingFoundForCancellation , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException CannotCancelFailedOrUnconfirmedBooking()
			{
				return new BadRequestException(  FaultCodes.CannotCancelFailedOrUnconfirmedBooking, FaultMessages.CannotCancelFailedOrUnconfirmedBooking , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDoorCount()
			{
				return new BadRequestException(  FaultCodes.MissingDoorCount, FaultMessages.MissingDoorCount , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MultiFormOfPaymentNotAllowed()
			{
				return new BadRequestException(  FaultCodes.MultiFormOfPaymentNotAllowed, FaultMessages.MultiFormOfPaymentNotAllowed , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidDoorCount()
			{
				return new BadRequestException(  FaultCodes.InvalidDoorCount, FaultMessages.InvalidDoorCount , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidVehicleType(string path)
			{
				return new BadRequestException(  FaultCodes.InvalidVehicleType, string.Format(FaultMessages.InvalidVehicleType , path) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidVehicleCategory(string path)
			{
				return new BadRequestException(  FaultCodes.InvalidVehicleCategory, string.Format(FaultMessages.InvalidVehicleCategory , path) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingPickupRentalLocationCode()
			{
				return new BadRequestException(  FaultCodes.MissingPickupRentalLocationCode, FaultMessages.MissingPickupRentalLocationCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingDropoffRentalLocationCode()
			{
				return new BadRequestException(  FaultCodes.MissingDropoffRentalLocationCode, FaultMessages.MissingDropoffRentalLocationCode , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidMinPriceFilter()
			{
				return new BadRequestException(  FaultCodes.InvalidMinPriceFilter, FaultMessages.InvalidMinPriceFilter , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidMaxPriceFilter()
			{
				return new BadRequestException(  FaultCodes.InvalidMaxPriceFilter, FaultMessages.InvalidMaxPriceFilter , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MinPriceGreaterThanMax()
			{
				return new BadRequestException(  FaultCodes.MinPriceGreaterThanMax, FaultMessages.MinPriceGreaterThanMax , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingAddressPostalCode(string parentName)
			{
				return new BadRequestException(  FaultCodes.MissingAddressPostalCode, string.Format(FaultMessages.MissingAddressPostalCode , parentName) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingAddressCountryCode(string parentName)
			{
				return new BadRequestException(  FaultCodes.MissingAddressCountryCode, string.Format(FaultMessages.MissingAddressCountryCode , parentName) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingAddressLine1(string parentName)
			{
				return new BadRequestException(  FaultCodes.MissingAddressLine1, string.Format(FaultMessages.MissingAddressLine1 , parentName) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException MissingAddressCity(string parentName)
			{
				return new BadRequestException(  FaultCodes.MissingAddressCity, string.Format(FaultMessages.MissingAddressCity , parentName) , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidSearchLocationFormat()
			{
				return new BadRequestException(  FaultCodes.InvalidSearchLocationFormat, FaultMessages.InvalidSearchLocationFormat , HttpStatusCode.BadRequest );
			}
		
			public static BaseApplicationException InvalidRadiusForCarSearch(int minRadius, int maxRadius)
			{
				return new BadRequestException(  FaultCodes.InvalidRadiusForCarSearch, string.Format(FaultMessages.InvalidRadiusForCarSearch , minRadius, maxRadius) , HttpStatusCode.BadRequest );
			}

		}
	}
}