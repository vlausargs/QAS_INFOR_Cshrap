//PROJECT NAME: Data
//CLASS NAME: IRepCustomerShipTo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepCustomerShipTo
	{
		(int? ReturnCode,
			string Infobar) RepCustomerShipToSp(
			string PDestSite,
			string PCustNum,
			int? pCustSeq,
			string pShipToShipCode = null,
			string pShipToSlsman = null,
			string pShipToWhse = null,
			string pShipToCharfld1 = null,
			string pShipToCharfld2 = null,
			string pShipToCharfld3 = null,
			string pShipToTaxRegNum2 = null,
			string pShipToBranchId = null,
			string pShipToTaxCode1 = null,
			string pShipToTaxCode2 = null,
			string pShipToLangCode = null,
			string pShipToShipSite = null,
			string pShipToCustBank = null,
			int? pShipToDraftPrintFlag = null,
			int? pShipToRcvInternalEmail = null,
			string pShipToCustomerEmailAddr = null,
			int? pShipToSendCustomerEmail = null,
			int? pShipToapsPullUp = null,
			string pShipToDoInvoice = null,
			int? pShipToConsolidate = null,
			string pShipToInvFreq = null,
			int? pShipToSummarize = null,
			int? pShipToEinvoice = null,
			string pShipToPhone2 = null,
			string pShipToContact2 = null,
			string Infobar = null);
	}
}

