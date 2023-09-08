//PROJECT NAME: Data
//CLASS NAME: IValidateLCR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateLCR
	{
		(int? ReturnCode,
			string rInfobar) ValidateLCRSp(
			string pText,
			string pCoNum,
			DateTime? pDate = null,
			string pParmsSite = null,
			DateTime? pBegDueDate = null,
			DateTime? pEndDueDate = null,
			string pWarehouse = null,
			int? pSuppressErrorWhenCustomerLcrNotReqd = null,
			string rInfobar = null);
	}
}

