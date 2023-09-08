//PROJECT NAME: Data
//CLASS NAME: IRepCustomerBillTo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepCustomerBillTo
	{
		(int? ReturnCode,
			string infobar) RepCustomerBillToSp(
			string pDestSite,
			string PCustNum,
			string pBillToContact1 = null,
			string pBillToContact2 = null,
			string pBillToContact3 = null,
			string pBillToPhone1 = null,
			string pBillToPhone2 = null,
			string pBillToPhone3 = null,
			string pBillToCustType = null,
			string pBillToTermsCode = null,
			string pBillToShipCode = null,
			string pBillToSlsman = null,
			string pBillToStateCycle = null,
			int? pBillToFinChg = null,
			string pBillToWhse = null,
			string pBillToCharfld1 = null,
			string pBillToCharfld2 = null,
			string pBillToCharfld3 = null,
			decimal? pBillToDecifld1 = null,
			decimal? pBillToDecifld2 = null,
			decimal? pBillToDecifld3 = null,
			int? pBillToLogifld = null,
			DateTime? pBillToDatefld = null,
			string pBillToTaxRegNum2 = null,
			string pBillToPayType = null,
			int? pBillToEdiCust = null,
			string pBillToBranchId = null,
			string pBillToTransNat = null,
			string pBillToDelterm = null,
			string pBillToProcessInd = null,
			int? pBillToUseExchRate = null,
			string pBillToTaxCode1 = null,
			string pBillToTaxCode2 = null,
			string pBillToPricecode = null,
			int? pBillToShipEarly = null,
			int? pBillToShipPartial = null,
			string pBillToLangCode = null,
			string pBillToEndUserType = null,
			string pBillToShipSite = null,
			int? pBillToLcrReqd = null,
			string pBillToCustBank = null,
			int? pBillToDraftPrintFlag = null,
			int? pBillToRcvInternalEmail = null,
			string pBillToCustomerEmailAddr = null,
			int? pBillToSendCustomerEmail = null,
			int? pBillToApsPullUp = null,
			string pBillToDoInvoice = null,
			int? pBillToConsolidate = null,
			string pBillToInvFreq = null,
			int? pBillToSummarize = null,
			int? pBillToEinvoice = null,
			string pBillToBankCode = null,
			string infobar = null,
			string pBillToTransNat2 = null);
	}
}

