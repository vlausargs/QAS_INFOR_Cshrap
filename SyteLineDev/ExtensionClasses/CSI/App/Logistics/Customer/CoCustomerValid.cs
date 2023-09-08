//PROJECT NAME: Logistics
//CLASS NAME: CoCustomerValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoCustomerValid : ICoCustomerValid
	{
		readonly IApplicationDB appDB;
		
		
		public CoCustomerValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CustNum,
		int? CustSeq,
		int? ShipmentExists,
		string BillToAddress,
		string ShipToAddress,
		string Contact,
		string Phone,
		string BillToContact,
		string BillToPhone,
		string ShipToContact,
		string ShipToPhone,
		string CorpCust,
		string CorpCustName,
		string CorpCustContact,
		string CorpCustPhone,
		int? CorpAddress,
		string CurrCode,
		int? UseExchRate,
		string Whse,
		string ShipCode,
		string ShipCodeDesc,
		int? ShipPartial,
		int? ShipEarly,
		int? Consolidate,
		int? Summarize,
		string InvFreq,
		int? Einvoice,
		string TermsCode,
		string TermsCodeDesc,
		string Slsman,
		string PriceCode,
		string PriceCodeDesc,
		string EndUserType,
		string EndUserTypeDesc,
		int? ApsPullUp,
		string TaxCode1,
		string TaxCode2,
		string TransNat,
		string TransNat2,
		string Delterm,
		string ProcessInd,
		string Infobar,
		int? ShipmentApprovalRequired,
		int? ShipHold,
		decimal? ExchRate,
		int? CurrRateIsFixed) CoCustomerValidSp(string CoNum,
		string OldCustNum,
		Guid? RowPointer,
		string CustNum,
		int? CustSeq,
		int? ShipmentExists,
		string BillToAddress,
		string ShipToAddress,
		string Contact,
		string Phone,
		string BillToContact,
		string BillToPhone,
		string ShipToContact,
		string ShipToPhone,
		string CorpCust,
		string CorpCustName,
		string CorpCustContact,
		string CorpCustPhone,
		int? CorpAddress,
		string CurrCode,
		int? UseExchRate,
		string Whse,
		string ShipCode,
		string ShipCodeDesc,
		int? ShipPartial,
		int? ShipEarly,
		int? Consolidate,
		int? Summarize,
		string InvFreq,
		int? Einvoice,
		string TermsCode,
		string TermsCodeDesc,
		string Slsman,
		string PriceCode,
		string PriceCodeDesc,
		string EndUserType,
		string EndUserTypeDesc,
		int? ApsPullUp,
		string TaxCode1,
		string TaxCode2,
		string TransNat,
		string TransNat2,
		string Delterm,
		string ProcessInd,
		string Infobar,
		int? ShipmentApprovalRequired,
		int? ShipHold,
		decimal? ExchRate,
		int? CurrRateIsFixed)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _OldCustNum = OldCustNum;
			RowPointerType _RowPointer = RowPointer;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			Flag _ShipmentExists = ShipmentExists;
			LongAddress _BillToAddress = BillToAddress;
			LongAddress _ShipToAddress = ShipToAddress;
			ContactType _Contact = Contact;
			PhoneType _Phone = Phone;
			ContactType _BillToContact = BillToContact;
			PhoneType _BillToPhone = BillToPhone;
			ContactType _ShipToContact = ShipToContact;
			PhoneType _ShipToPhone = ShipToPhone;
			CustNumType _CorpCust = CorpCust;
			NameType _CorpCustName = CorpCustName;
			ContactType _CorpCustContact = CorpCustContact;
			PhoneType _CorpCustPhone = CorpCustPhone;
			Flag _CorpAddress = CorpAddress;
			CurrCodeType _CurrCode = CurrCode;
			Flag _UseExchRate = UseExchRate;
			WhseType _Whse = Whse;
			ShipCodeType _ShipCode = ShipCode;
			DescriptionType _ShipCodeDesc = ShipCodeDesc;
			Flag _ShipPartial = ShipPartial;
			Flag _ShipEarly = ShipEarly;
			Flag _Consolidate = Consolidate;
			Flag _Summarize = Summarize;
			InvFreqType _InvFreq = InvFreq;
			Flag _Einvoice = Einvoice;
			TermsCodeType _TermsCode = TermsCode;
			DescriptionType _TermsCodeDesc = TermsCodeDesc;
			SlsmanType _Slsman = Slsman;
			PriceCodeType _PriceCode = PriceCode;
			DescriptionType _PriceCodeDesc = PriceCodeDesc;
			EndUserTypeType _EndUserType = EndUserType;
			DescriptionType _EndUserTypeDesc = EndUserTypeDesc;
			Flag _ApsPullUp = ApsPullUp;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			TransNatType _TransNat = TransNat;
			TransNat2Type _TransNat2 = TransNat2;
			DeltermType _Delterm = Delterm;
			ProcessIndType _ProcessInd = ProcessInd;
			Infobar _Infobar = Infobar;
			ListYesNoType _ShipmentApprovalRequired = ShipmentApprovalRequired;
			Flag _ShipHold = ShipHold;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _CurrRateIsFixed = CurrRateIsFixed;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoCustomerValidSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCustNum", _OldCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipmentExists", _ShipmentExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillToAddress", _BillToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToAddress", _ShipToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillToContact", _BillToContact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillToPhone", _BillToPhone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToContact", _ShipToContact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToPhone", _ShipToPhone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CorpCust", _CorpCust, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CorpCustName", _CorpCustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CorpCustContact", _CorpCustContact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CorpCustPhone", _CorpCustPhone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CorpAddress", _CorpAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseExchRate", _UseExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipCodeDesc", _ShipCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipPartial", _ShipPartial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipEarly", _ShipEarly, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Consolidate", _Consolidate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Summarize", _Summarize, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvFreq", _InvFreq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Einvoice", _Einvoice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TermsCodeDesc", _TermsCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriceCodeDesc", _PriceCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndUserType", _EndUserType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndUserTypeDesc", _EndUserTypeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ApsPullUp", _ApsPullUp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipmentApprovalRequired", _ShipmentApprovalRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipHold", _ShipHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrRateIsFixed", _CurrRateIsFixed, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustNum = _CustNum;
				CustSeq = _CustSeq;
				ShipmentExists = _ShipmentExists;
				BillToAddress = _BillToAddress;
				ShipToAddress = _ShipToAddress;
				Contact = _Contact;
				Phone = _Phone;
				BillToContact = _BillToContact;
				BillToPhone = _BillToPhone;
				ShipToContact = _ShipToContact;
				ShipToPhone = _ShipToPhone;
				CorpCust = _CorpCust;
				CorpCustName = _CorpCustName;
				CorpCustContact = _CorpCustContact;
				CorpCustPhone = _CorpCustPhone;
				CorpAddress = _CorpAddress;
				CurrCode = _CurrCode;
				UseExchRate = _UseExchRate;
				Whse = _Whse;
				ShipCode = _ShipCode;
				ShipCodeDesc = _ShipCodeDesc;
				ShipPartial = _ShipPartial;
				ShipEarly = _ShipEarly;
				Consolidate = _Consolidate;
				Summarize = _Summarize;
				InvFreq = _InvFreq;
				Einvoice = _Einvoice;
				TermsCode = _TermsCode;
				TermsCodeDesc = _TermsCodeDesc;
				Slsman = _Slsman;
				PriceCode = _PriceCode;
				PriceCodeDesc = _PriceCodeDesc;
				EndUserType = _EndUserType;
				EndUserTypeDesc = _EndUserTypeDesc;
				ApsPullUp = _ApsPullUp;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				TransNat = _TransNat;
				TransNat2 = _TransNat2;
				Delterm = _Delterm;
				ProcessInd = _ProcessInd;
				Infobar = _Infobar;
				ShipmentApprovalRequired = _ShipmentApprovalRequired;
				ShipHold = _ShipHold;
				ExchRate = _ExchRate;
				CurrRateIsFixed = _CurrRateIsFixed;
				
				return (Severity, CustNum, CustSeq, ShipmentExists, BillToAddress, ShipToAddress, Contact, Phone, BillToContact, BillToPhone, ShipToContact, ShipToPhone, CorpCust, CorpCustName, CorpCustContact, CorpCustPhone, CorpAddress, CurrCode, UseExchRate, Whse, ShipCode, ShipCodeDesc, ShipPartial, ShipEarly, Consolidate, Summarize, InvFreq, Einvoice, TermsCode, TermsCodeDesc, Slsman, PriceCode, PriceCodeDesc, EndUserType, EndUserTypeDesc, ApsPullUp, TaxCode1, TaxCode2, TransNat, TransNat2, Delterm, ProcessInd, Infobar, ShipmentApprovalRequired, ShipHold, ExchRate, CurrRateIsFixed);
			}
		}
	}
}
