//PROJECT NAME: Data
//CLASS NAME: RepCustomerBillTo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepCustomerBillTo : IRepCustomerBillTo
	{
		readonly IApplicationDB appDB;
		
		public RepCustomerBillTo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string pBillToTransNat2 = null)
		{
			SiteType _pDestSite = pDestSite;
			CustNumType _PCustNum = PCustNum;
			ContactType _pBillToContact1 = pBillToContact1;
			ContactType _pBillToContact2 = pBillToContact2;
			ContactType _pBillToContact3 = pBillToContact3;
			PhoneType _pBillToPhone1 = pBillToPhone1;
			PhoneType _pBillToPhone2 = pBillToPhone2;
			PhoneType _pBillToPhone3 = pBillToPhone3;
			CustTypeType _pBillToCustType = pBillToCustType;
			TermsCodeType _pBillToTermsCode = pBillToTermsCode;
			ShipCodeType _pBillToShipCode = pBillToShipCode;
			SlsmanType _pBillToSlsman = pBillToSlsman;
			StatementCycleType _pBillToStateCycle = pBillToStateCycle;
			ListYesNoType _pBillToFinChg = pBillToFinChg;
			WhseType _pBillToWhse = pBillToWhse;
			UserCharFldType _pBillToCharfld1 = pBillToCharfld1;
			UserCharFldType _pBillToCharfld2 = pBillToCharfld2;
			UserCharFldType _pBillToCharfld3 = pBillToCharfld3;
			UserDeciFldType _pBillToDecifld1 = pBillToDecifld1;
			UserDeciFldType _pBillToDecifld2 = pBillToDecifld2;
			UserDeciFldType _pBillToDecifld3 = pBillToDecifld3;
			UserLogiFldType _pBillToLogifld = pBillToLogifld;
			UserDateFldType _pBillToDatefld = pBillToDatefld;
			TaxRegNumType _pBillToTaxRegNum2 = pBillToTaxRegNum2;
			CustPayTypeType _pBillToPayType = pBillToPayType;
			ListYesNoType _pBillToEdiCust = pBillToEdiCust;
			BranchIdType _pBillToBranchId = pBillToBranchId;
			TransNatType _pBillToTransNat = pBillToTransNat;
			DeltermType _pBillToDelterm = pBillToDelterm;
			ProcessIndType _pBillToProcessInd = pBillToProcessInd;
			ListYesNoType _pBillToUseExchRate = pBillToUseExchRate;
			TaxCodeType _pBillToTaxCode1 = pBillToTaxCode1;
			TaxCodeType _pBillToTaxCode2 = pBillToTaxCode2;
			PriceCodeType _pBillToPricecode = pBillToPricecode;
			ListYesNoType _pBillToShipEarly = pBillToShipEarly;
			ListYesNoType _pBillToShipPartial = pBillToShipPartial;
			LangCodeType _pBillToLangCode = pBillToLangCode;
			EndUserTypeType _pBillToEndUserType = pBillToEndUserType;
			SiteType _pBillToShipSite = pBillToShipSite;
			ListYesNoType _pBillToLcrReqd = pBillToLcrReqd;
			BankCodeType _pBillToCustBank = pBillToCustBank;
			ListYesNoType _pBillToDraftPrintFlag = pBillToDraftPrintFlag;
			ListYesNoType _pBillToRcvInternalEmail = pBillToRcvInternalEmail;
			EmailType _pBillToCustomerEmailAddr = pBillToCustomerEmailAddr;
			ListYesNoType _pBillToSendCustomerEmail = pBillToSendCustomerEmail;
			ListYesNoType _pBillToApsPullUp = pBillToApsPullUp;
			DoInvoiceType _pBillToDoInvoice = pBillToDoInvoice;
			ListYesNoType _pBillToConsolidate = pBillToConsolidate;
			InvFreqType _pBillToInvFreq = pBillToInvFreq;
			ListYesNoType _pBillToSummarize = pBillToSummarize;
			ListYesNoType _pBillToEinvoice = pBillToEinvoice;
			BankCodeType _pBillToBankCode = pBillToBankCode;
			InfobarType _infobar = infobar;
			TransNat2Type _pBillToTransNat2 = pBillToTransNat2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepCustomerBillToSp";
				
				appDB.AddCommandParameter(cmd, "pDestSite", _pDestSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToContact1", _pBillToContact1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToContact2", _pBillToContact2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToContact3", _pBillToContact3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToPhone1", _pBillToPhone1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToPhone2", _pBillToPhone2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToPhone3", _pBillToPhone3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToCustType", _pBillToCustType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToTermsCode", _pBillToTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToShipCode", _pBillToShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToSlsman", _pBillToSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToStateCycle", _pBillToStateCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToFinChg", _pBillToFinChg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToWhse", _pBillToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToCharfld1", _pBillToCharfld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToCharfld2", _pBillToCharfld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToCharfld3", _pBillToCharfld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToDecifld1", _pBillToDecifld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToDecifld2", _pBillToDecifld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToDecifld3", _pBillToDecifld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToLogifld", _pBillToLogifld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToDatefld", _pBillToDatefld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToTaxRegNum2", _pBillToTaxRegNum2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToPayType", _pBillToPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToEdiCust", _pBillToEdiCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToBranchId", _pBillToBranchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToTransNat", _pBillToTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToDelterm", _pBillToDelterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToProcessInd", _pBillToProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToUseExchRate", _pBillToUseExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToTaxCode1", _pBillToTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToTaxCode2", _pBillToTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToPricecode", _pBillToPricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToShipEarly", _pBillToShipEarly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToShipPartial", _pBillToShipPartial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToLangCode", _pBillToLangCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToEndUserType", _pBillToEndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToShipSite", _pBillToShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToLcrReqd", _pBillToLcrReqd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToCustBank", _pBillToCustBank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToDraftPrintFlag", _pBillToDraftPrintFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToRcvInternalEmail", _pBillToRcvInternalEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToCustomerEmailAddr", _pBillToCustomerEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToSendCustomerEmail", _pBillToSendCustomerEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToApsPullUp", _pBillToApsPullUp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToDoInvoice", _pBillToDoInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToConsolidate", _pBillToConsolidate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToInvFreq", _pBillToInvFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToSummarize", _pBillToSummarize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToEinvoice", _pBillToEinvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBillToBankCode", _pBillToBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "infobar", _infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pBillToTransNat2", _pBillToTransNat2, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				infobar = _infobar;
				
				return (Severity, infobar);
			}
		}
	}
}
