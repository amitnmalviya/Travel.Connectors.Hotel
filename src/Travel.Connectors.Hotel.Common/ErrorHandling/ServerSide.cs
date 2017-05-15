using System.Net;

namespace Travel.Connectors.Hotel.Common.ErrorHandling
{
    public static partial class Errors 
	{
		public static partial class ServerSide
		{
			
			public static BaseApplicationException System()
			{
				return new SystemException(  FaultCodes.System, FaultMessages.System , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException UnMappedSupplier(string supplier)
			{
				return new BadRequestException(  FaultCodes.UnMappedSupplier, string.Format(FaultMessages.UnMappedSupplier , supplier) , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException SupplierServerDown()
			{
				return new CommunicationException(  FaultCodes.SupplierServerDown, FaultMessages.SupplierServerDown , HttpStatusCode.BadGateway );
			}
		
			public static BaseApplicationException SupplierSystem()
			{
				return new CommunicationException(  FaultCodes.SupplierSystem, FaultMessages.SupplierSystem , HttpStatusCode.BadGateway );
			}
		
			public static BaseApplicationException TimeOut()
			{
				return new CommunicationException(  FaultCodes.TimeOut, FaultMessages.TimeOut , HttpStatusCode.GatewayTimeout );
			}
		
			public static BaseApplicationException Supplier()
			{
				return new CommunicationException(  FaultCodes.Supplier, FaultMessages.Supplier , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException Application()
			{
				return new SystemException(  FaultCodes.Application, FaultMessages.Application , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException ConnectorCallFaulted()
			{
				return new CommunicationException(  FaultCodes.ConnectorCallFaulted, FaultMessages.ConnectorCallFaulted , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException InvalidConfigurations()
			{
				return new ConfigurationException(  FaultCodes.InvalidConfigurations, FaultMessages.InvalidConfigurations , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException RequestProcessingError()
			{
				return new SystemException(  FaultCodes.RequestProcessingError, FaultMessages.RequestProcessingError , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException SessionStoreRead()
			{
				return new CommunicationException(  FaultCodes.SessionStoreRead, FaultMessages.SessionStoreRead , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException SessionStoreWrite()
			{
				return new CommunicationException(  FaultCodes.SessionStoreWrite, FaultMessages.SessionStoreWrite , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException CouldNotResolveType(string type, string error)
			{
				return new SystemException(  FaultCodes.CouldNotResolveType, string.Format(FaultMessages.CouldNotResolveType , type, error) , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException Metadata()
			{
				return new SystemException(  FaultCodes.Metadata, FaultMessages.Metadata , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException ParsingFailure()
			{
				return new SystemException(  FaultCodes.ParsingFailure, FaultMessages.ParsingFailure , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException ServiceCommunication()
			{
				return new CommunicationException(  FaultCodes.ServiceCommunication, FaultMessages.ServiceCommunication , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException ConnectorServiceCommunication()
			{
				return new CommunicationException(  FaultCodes.ConnectorServiceCommunication, FaultMessages.ConnectorServiceCommunication , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException SupplierCommunication()
			{
				return new CommunicationException(  FaultCodes.SupplierCommunication, FaultMessages.SupplierCommunication , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException InvalidConnectorResponse()
			{
				return new SystemException(  FaultCodes.InvalidConnectorResponse, FaultMessages.InvalidConnectorResponse , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException InvalidSupplierResponse()
			{
				return new SystemException(  FaultCodes.InvalidSupplierResponse, FaultMessages.InvalidSupplierResponse , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException TenantConfigurationRead()
			{
				return new ConfigurationException(  FaultCodes.TenantConfigurationRead, FaultMessages.TenantConfigurationRead , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException ContentServiceFaulted()
			{
				return new SystemException(  FaultCodes.ContentServiceFaulted, FaultMessages.ContentServiceFaulted , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException ContentService()
			{
				return new CommunicationException(  FaultCodes.ContentService, FaultMessages.ContentService , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException PricesChanged()
			{
				return new SystemException(  FaultCodes.PricesChanged, FaultMessages.PricesChanged , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException CreditCardFraudDetected()
			{
				return new SystemException(  FaultCodes.CreditCardFraudDetected, FaultMessages.CreditCardFraudDetected , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException TranslationMissing(string typeName)
			{
				return new ConfigurationException(  FaultCodes.TranslationMissing, string.Format(FaultMessages.TranslationMissing , typeName) , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException CancelFailed()
			{
				return new SystemException(  FaultCodes.CancelFailed, FaultMessages.CancelFailed , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException SupplierException()
			{
				return new SystemException(  FaultCodes.SupplierException, FaultMessages.SupplierException , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException ConsumerServiceCommunication(string serviceName)
			{
				return new CommunicationException(  FaultCodes.ConsumerServiceCommunication, string.Format(FaultMessages.ConsumerServiceCommunication , serviceName) , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException UnexpectedSystemException()
			{
				return new UnExpectedSystemException(  FaultCodes.UnexpectedSystemException, FaultMessages.UnexpectedSystemException , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException ConnectorReadFailure(string connectorId)
			{
				return new ConfigurationException(  FaultCodes.ConnectorReadFailure, string.Format(FaultMessages.ConnectorReadFailure , connectorId) , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException ConnectorConfigurationSpecNotFound(string connectorName)
			{
				return new ConfigurationException(  FaultCodes.ConnectorConfigurationSpecNotFound, string.Format(FaultMessages.ConnectorConfigurationSpecNotFound , connectorName) , HttpStatusCode.InternalServerError );
			}
		
			public static BaseApplicationException MissingExternalServiceConfiguration(string configName, string serviceName)
			{
				return new ConfigurationException(  FaultCodes.MissingExternalServiceConfiguration, string.Format(FaultMessages.MissingExternalServiceConfiguration , configName, serviceName) , HttpStatusCode.InternalServerError );
			}

		}
	}
}