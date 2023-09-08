//PROJECT NAME: POS
//CLASS NAME: SSSPOSPosSRO_C.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSPosSRO_C : ISSSPOSPosSRO_C
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSPosSRO_C(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TInvNum,
			string Infobar) SSSPOSPosSRO_CSp(
			string POSNum,
			string InvCred,
			string ParmCurrCode,
			string ParmSite,
			decimal? UserID,
			Guid? SessionID,
			string CurUserCode,
			decimal? POSMTotalPrice,
			decimal? POSMTotalBilled,
			decimal? POSMTotalPrepaidAmt,
			string POSMRefNum,
			string POSMRevPOSNum,
			int? POSMCredit,
			string POSMCustNum,
			int? POSMCustSeq,
			decimal? POSMDisc,
			string POSMCustPo,
			Guid? POSMRowPointer,
			string POSMTaxCode1,
			string POSMTaxCode2,
			string POSMShipCode,
			decimal? POSMSalesTax,
			decimal? POSMSalesTax2,
			string POSMFrtTaxCode1,
			string POSMFrtTaxCode2,
			string POSMMscTaxCode1,
			string POSMMscTaxCode2,
			decimal? POSMFreight,
			decimal? POSMMiscCharges,
			string POSMContact,
			string POSMPhone,
			string POSMWhse,
			string POSMCredInvNum,
			Guid? CustomerRowPointer,
			string CustomerBankCode,
			int? CustAddrCorpCredit,
			string CustAddrCurrCode,
			string CustAddrBalMethod,
			string POSMDrawerSRONum,
			string POSMBillCode,
			string POSMSerNum,
			string POSMItem,
			string POSMPriceCode,
			string POSMTermsCode,
			string POSMPartnerID,
			string POSMSlsman,
			string POSMEndUserType,
			string TInvNum,
			string Infobar)
		{
			POSMNumType _POSNum = POSNum;
			StringType _InvCred = InvCred;
			CurrCodeType _ParmCurrCode = ParmCurrCode;
			SiteType _ParmSite = ParmSite;
			TokenType _UserID = UserID;
			RowPointerType _SessionID = SessionID;
			TakenByType _CurUserCode = CurUserCode;
			AmountType _POSMTotalPrice = POSMTotalPrice;
			AmountType _POSMTotalBilled = POSMTotalBilled;
			AmountType _POSMTotalPrepaidAmt = POSMTotalPrepaidAmt;
			POSMRefNumType _POSMRefNum = POSMRefNum;
			POSMNumType _POSMRevPOSNum = POSMRevPOSNum;
			ListYesNoType _POSMCredit = POSMCredit;
			CustNumType _POSMCustNum = POSMCustNum;
			CustSeqType _POSMCustSeq = POSMCustSeq;
			FSPctType _POSMDisc = POSMDisc;
			CustPoType _POSMCustPo = POSMCustPo;
			RowPointerType _POSMRowPointer = POSMRowPointer;
			TaxCodeType _POSMTaxCode1 = POSMTaxCode1;
			TaxCodeType _POSMTaxCode2 = POSMTaxCode2;
			ShipCodeType _POSMShipCode = POSMShipCode;
			AmountType _POSMSalesTax = POSMSalesTax;
			AmountType _POSMSalesTax2 = POSMSalesTax2;
			TaxCodeType _POSMFrtTaxCode1 = POSMFrtTaxCode1;
			TaxCodeType _POSMFrtTaxCode2 = POSMFrtTaxCode2;
			TaxCodeType _POSMMscTaxCode1 = POSMMscTaxCode1;
			TaxCodeType _POSMMscTaxCode2 = POSMMscTaxCode2;
			AmountType _POSMFreight = POSMFreight;
			AmountType _POSMMiscCharges = POSMMiscCharges;
			ContactType _POSMContact = POSMContact;
			PhoneType _POSMPhone = POSMPhone;
			WhseType _POSMWhse = POSMWhse;
			InvNumType _POSMCredInvNum = POSMCredInvNum;
			RowPointerType _CustomerRowPointer = CustomerRowPointer;
			BankCodeType _CustomerBankCode = CustomerBankCode;
			ListYesNoType _CustAddrCorpCredit = CustAddrCorpCredit;
			CurrCodeType _CustAddrCurrCode = CustAddrCurrCode;
			BalMethodType _CustAddrBalMethod = CustAddrBalMethod;
			FSSRONumType _POSMDrawerSRONum = POSMDrawerSRONum;
			FSSROBillCodeType _POSMBillCode = POSMBillCode;
			SerNumType _POSMSerNum = POSMSerNum;
			ItemType _POSMItem = POSMItem;
			PriceCodeType _POSMPriceCode = POSMPriceCode;
			TermsCodeType _POSMTermsCode = POSMTermsCode;
			FSPartnerType _POSMPartnerID = POSMPartnerID;
			SlsmanType _POSMSlsman = POSMSlsman;
			EndUserTypeType _POSMEndUserType = POSMEndUserType;
			InvNumType _TInvNum = TInvNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSPosSRO_CSp";
				
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmSite", _ParmSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurUserCode", _CurUserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMTotalPrice", _POSMTotalPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMTotalBilled", _POSMTotalBilled, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMTotalPrepaidAmt", _POSMTotalPrepaidAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMRefNum", _POSMRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMRevPOSNum", _POSMRevPOSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCredit", _POSMCredit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCustNum", _POSMCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCustSeq", _POSMCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMDisc", _POSMDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCustPo", _POSMCustPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMRowPointer", _POSMRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMTaxCode1", _POSMTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMTaxCode2", _POSMTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMShipCode", _POSMShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMSalesTax", _POSMSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMSalesTax2", _POSMSalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMFrtTaxCode1", _POSMFrtTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMFrtTaxCode2", _POSMFrtTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMscTaxCode1", _POSMMscTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMscTaxCode2", _POSMMscTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMFreight", _POSMFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMiscCharges", _POSMMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMContact", _POSMContact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMPhone", _POSMPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMWhse", _POSMWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCredInvNum", _POSMCredInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerRowPointer", _CustomerRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerBankCode", _CustomerBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustAddrCorpCredit", _CustAddrCorpCredit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustAddrCurrCode", _CustAddrCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustAddrBalMethod", _CustAddrBalMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMDrawerSRONum", _POSMDrawerSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMBillCode", _POSMBillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMSerNum", _POSMSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMItem", _POSMItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMPriceCode", _POSMPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMTermsCode", _POSMTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMPartnerID", _POSMPartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMSlsman", _POSMSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMEndUserType", _POSMEndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInvNum", _TInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TInvNum = _TInvNum;
				Infobar = _Infobar;
				
				return (Severity, TInvNum, Infobar);
			}
		}
	}
}
