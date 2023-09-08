//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROValidCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROValidCust
	{
		(int? ReturnCode, int? CustSeq,
		string BillToAddr,
		string ShipToAddr,
		string BillMgr,
		string BillMgrName,
		string EndUserType,
		string TermsCode,
		string Slsman,
		string Pricecode,
		string ShipCode,
		string CurrCode,
		byte? FixedEuro,
		decimal? ExchRate,
		byte? CreditHold,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		byte? DepositReq,
		byte? ApplyOpenDeposits,
		string Region,
		string RegionDesc,
		string Contact,
		string Email,
		string Phone,
		string Fax,
		string PagerAddr,
		string TxtMsgAddr,
		string Infobar,
		string PriorCode,
		string BillToName,
		string ShipToName,
		string NOTC,
		string DeliveryTerms,
		string CurAmtFormat,
		string CurCstPrcFormat) SSSFSSROValidCustSp(string CustNum,
		int? CustSeq,
		string Level,
		string BillToAddr,
		string ShipToAddr,
		string BillMgr,
		string BillMgrName,
		string EndUserType,
		string TermsCode,
		string Slsman,
		string Pricecode,
		string ShipCode,
		string CurrCode,
		byte? FixedEuro,
		decimal? ExchRate,
		byte? CreditHold,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		byte? DepositReq,
		byte? ApplyOpenDeposits,
		string Region,
		string RegionDesc,
		string Contact,
		string Email,
		string Phone,
		string Fax,
		string PagerAddr,
		string TxtMsgAddr,
		string Infobar,
		string PriorCode,
		string BillToName = null,
		string ShipToName = null,
		string NOTC = null,
		string DeliveryTerms = null,
		string CurAmtFormat = null,
		string CurCstPrcFormat = null,
		string PriorCustNum = null,
		string SRONum = null);
	}
	
	public class SSSFSSROValidCust : ISSSFSSROValidCust
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROValidCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CustSeq,
		string BillToAddr,
		string ShipToAddr,
		string BillMgr,
		string BillMgrName,
		string EndUserType,
		string TermsCode,
		string Slsman,
		string Pricecode,
		string ShipCode,
		string CurrCode,
		byte? FixedEuro,
		decimal? ExchRate,
		byte? CreditHold,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		byte? DepositReq,
		byte? ApplyOpenDeposits,
		string Region,
		string RegionDesc,
		string Contact,
		string Email,
		string Phone,
		string Fax,
		string PagerAddr,
		string TxtMsgAddr,
		string Infobar,
		string PriorCode,
		string BillToName,
		string ShipToName,
		string NOTC,
		string DeliveryTerms,
		string CurAmtFormat,
		string CurCstPrcFormat) SSSFSSROValidCustSp(string CustNum,
		int? CustSeq,
		string Level,
		string BillToAddr,
		string ShipToAddr,
		string BillMgr,
		string BillMgrName,
		string EndUserType,
		string TermsCode,
		string Slsman,
		string Pricecode,
		string ShipCode,
		string CurrCode,
		byte? FixedEuro,
		decimal? ExchRate,
		byte? CreditHold,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		byte? DepositReq,
		byte? ApplyOpenDeposits,
		string Region,
		string RegionDesc,
		string Contact,
		string Email,
		string Phone,
		string Fax,
		string PagerAddr,
		string TxtMsgAddr,
		string Infobar,
		string PriorCode,
		string BillToName = null,
		string ShipToName = null,
		string NOTC = null,
		string DeliveryTerms = null,
		string CurAmtFormat = null,
		string CurCstPrcFormat = null,
		string PriorCustNum = null,
		string SRONum = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			StringType _Level = Level;
			LongAddress _BillToAddr = BillToAddr;
			LongAddress _ShipToAddr = ShipToAddr;
			FSPartnerType _BillMgr = BillMgr;
			NameType _BillMgrName = BillMgrName;
			EndUserTypeType _EndUserType = EndUserType;
			TermsCodeType _TermsCode = TermsCode;
			SlsmanType _Slsman = Slsman;
			PriceCodeType _Pricecode = Pricecode;
			ShipCodeType _ShipCode = ShipCode;
			CurrCodeType _CurrCode = CurrCode;
			ListYesNoType _FixedEuro = FixedEuro;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _CreditHold = CreditHold;
			TaxCodeType _TaxCode1 = TaxCode1;
			DescriptionType _TaxCode1Desc = TaxCode1Desc;
			TaxCodeType _TaxCode2 = TaxCode2;
			DescriptionType _TaxCode2Desc = TaxCode2Desc;
			ListYesNoType _DepositReq = DepositReq;
			ListYesNoType _ApplyOpenDeposits = ApplyOpenDeposits;
			FSRegionType _Region = Region;
			DescriptionType _RegionDesc = RegionDesc;
			ContactType _Contact = Contact;
			EmailType _Email = Email;
			PhoneType _Phone = Phone;
			PhoneType _Fax = Fax;
			EmailType _PagerAddr = PagerAddr;
			EmailType _TxtMsgAddr = TxtMsgAddr;
			InfobarType _Infobar = Infobar;
			FSIncPriorCodeType _PriorCode = PriorCode;
			NameType _BillToName = BillToName;
			NameType _ShipToName = ShipToName;
			TransNatType _NOTC = NOTC;
			DeltermType _DeliveryTerms = DeliveryTerms;
			InputMaskType _CurAmtFormat = CurAmtFormat;
			InputMaskType _CurCstPrcFormat = CurCstPrcFormat;
			CustNumType _PriorCustNum = PriorCustNum;
			FSSRONumType _SRONum = SRONum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROValidCustSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillToAddr", _BillToAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToAddr", _ShipToAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillMgr", _BillMgr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillMgrName", _BillMgrName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndUserType", _EndUserType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FixedEuro", _FixedEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreditHold", _CreditHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DepositReq", _DepositReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ApplyOpenDeposits", _ApplyOpenDeposits, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Region", _Region, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RegionDesc", _RegionDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Fax", _Fax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PagerAddr", _PagerAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TxtMsgAddr", _TxtMsgAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillToName", _BillToName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToName", _ShipToName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NOTC", _NOTC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeliveryTerms", _DeliveryTerms, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurAmtFormat", _CurAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurCstPrcFormat", _CurCstPrcFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriorCustNum", _PriorCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustSeq = _CustSeq;
				BillToAddr = _BillToAddr;
				ShipToAddr = _ShipToAddr;
				BillMgr = _BillMgr;
				BillMgrName = _BillMgrName;
				EndUserType = _EndUserType;
				TermsCode = _TermsCode;
				Slsman = _Slsman;
				Pricecode = _Pricecode;
				ShipCode = _ShipCode;
				CurrCode = _CurrCode;
				FixedEuro = _FixedEuro;
				ExchRate = _ExchRate;
				CreditHold = _CreditHold;
				TaxCode1 = _TaxCode1;
				TaxCode1Desc = _TaxCode1Desc;
				TaxCode2 = _TaxCode2;
				TaxCode2Desc = _TaxCode2Desc;
				DepositReq = _DepositReq;
				ApplyOpenDeposits = _ApplyOpenDeposits;
				Region = _Region;
				RegionDesc = _RegionDesc;
				Contact = _Contact;
				Email = _Email;
				Phone = _Phone;
				Fax = _Fax;
				PagerAddr = _PagerAddr;
				TxtMsgAddr = _TxtMsgAddr;
				Infobar = _Infobar;
				PriorCode = _PriorCode;
				BillToName = _BillToName;
				ShipToName = _ShipToName;
				NOTC = _NOTC;
				DeliveryTerms = _DeliveryTerms;
				CurAmtFormat = _CurAmtFormat;
				CurCstPrcFormat = _CurCstPrcFormat;
				
				return (Severity, CustSeq, BillToAddr, ShipToAddr, BillMgr, BillMgrName, EndUserType, TermsCode, Slsman, Pricecode, ShipCode, CurrCode, FixedEuro, ExchRate, CreditHold, TaxCode1, TaxCode1Desc, TaxCode2, TaxCode2Desc, DepositReq, ApplyOpenDeposits, Region, RegionDesc, Contact, Email, Phone, Fax, PagerAddr, TxtMsgAddr, Infobar, PriorCode, BillToName, ShipToName, NOTC, DeliveryTerms, CurAmtFormat, CurCstPrcFormat);
			}
		}
	}
}
