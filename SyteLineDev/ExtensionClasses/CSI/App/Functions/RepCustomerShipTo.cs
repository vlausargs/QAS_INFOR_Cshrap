//PROJECT NAME: Data
//CLASS NAME: RepCustomerShipTo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepCustomerShipTo : IRepCustomerShipTo
	{
		readonly IApplicationDB appDB;
		
		public RepCustomerShipTo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string Infobar = null)
		{
			SiteType _PDestSite = PDestSite;
			CustNumType _PCustNum = PCustNum;
			CustSeqType _pCustSeq = pCustSeq;
			ShipCodeType _pShipToShipCode = pShipToShipCode;
			SlsmanType _pShipToSlsman = pShipToSlsman;
			WhseType _pShipToWhse = pShipToWhse;
			UserCharFldType _pShipToCharfld1 = pShipToCharfld1;
			UserCharFldType _pShipToCharfld2 = pShipToCharfld2;
			UserCharFldType _pShipToCharfld3 = pShipToCharfld3;
			TaxRegNumType _pShipToTaxRegNum2 = pShipToTaxRegNum2;
			BranchIdType _pShipToBranchId = pShipToBranchId;
			TaxCodeType _pShipToTaxCode1 = pShipToTaxCode1;
			TaxCodeType _pShipToTaxCode2 = pShipToTaxCode2;
			LangCodeType _pShipToLangCode = pShipToLangCode;
			SiteType _pShipToShipSite = pShipToShipSite;
			BankCodeType _pShipToCustBank = pShipToCustBank;
			ListYesNoType _pShipToDraftPrintFlag = pShipToDraftPrintFlag;
			ListYesNoType _pShipToRcvInternalEmail = pShipToRcvInternalEmail;
			EmailType _pShipToCustomerEmailAddr = pShipToCustomerEmailAddr;
			ListYesNoType _pShipToSendCustomerEmail = pShipToSendCustomerEmail;
			ListYesNoType _pShipToapsPullUp = pShipToapsPullUp;
			DoInvoiceType _pShipToDoInvoice = pShipToDoInvoice;
			ListYesNoType _pShipToConsolidate = pShipToConsolidate;
			InvFreqType _pShipToInvFreq = pShipToInvFreq;
			ListYesNoType _pShipToSummarize = pShipToSummarize;
			ListYesNoType _pShipToEinvoice = pShipToEinvoice;
			PhoneType _pShipToPhone2 = pShipToPhone2;
			ContactType _pShipToContact2 = pShipToContact2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepCustomerShipToSp";
				
				appDB.AddCommandParameter(cmd, "PDestSite", _PDestSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustSeq", _pCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToShipCode", _pShipToShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToSlsman", _pShipToSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToWhse", _pShipToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToCharfld1", _pShipToCharfld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToCharfld2", _pShipToCharfld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToCharfld3", _pShipToCharfld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToTaxRegNum2", _pShipToTaxRegNum2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToBranchId", _pShipToBranchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToTaxCode1", _pShipToTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToTaxCode2", _pShipToTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToLangCode", _pShipToLangCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToShipSite", _pShipToShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToCustBank", _pShipToCustBank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToDraftPrintFlag", _pShipToDraftPrintFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToRcvInternalEmail", _pShipToRcvInternalEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToCustomerEmailAddr", _pShipToCustomerEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToSendCustomerEmail", _pShipToSendCustomerEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToapsPullUp", _pShipToapsPullUp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToDoInvoice", _pShipToDoInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToConsolidate", _pShipToConsolidate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToInvFreq", _pShipToInvFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToSummarize", _pShipToSummarize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToEinvoice", _pShipToEinvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToPhone2", _pShipToPhone2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipToContact2", _pShipToContact2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
