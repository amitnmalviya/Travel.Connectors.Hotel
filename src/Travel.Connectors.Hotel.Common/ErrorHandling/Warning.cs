
using System;
using System.Net;
using System.Collections.Generic;

namespace Travel.Connectors.Hotel.Common.ErrorHandling
{
	public static partial class Errors 
	{
		public static partial class Warning
		{
			
			public static BaseApplicationException NoResultsForSearchCriteria()
			{
				return new ContentNotFoundException(  FaultCodes.NoResultsForSearchCriteria, FaultMessages.NoResultsForSearchCriteria , HttpStatusCode.OK );
			}
		
			public static BaseApplicationException SupplierDisabled(string supplierName)
			{
				return new BadRequestException(  FaultCodes.SupplierDisabled, string.Format(FaultMessages.SupplierDisabled , supplierName) , HttpStatusCode.BadRequest );
			}

		}
	}
}