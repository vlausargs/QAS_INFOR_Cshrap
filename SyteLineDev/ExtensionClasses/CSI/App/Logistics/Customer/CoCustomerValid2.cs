//PROJECT NAME: Logistics
//CLASS NAME: CoCustomerValid2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoCustomerValid2 : ICoCustomerValid2
	{
		readonly IApplicationDB appDB;
		
		
		public CoCustomerValid2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? ExchRate,
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
		string TaxDesc1,
		string TaxCode2,
		string TaxDesc2,
		string FrtTaxCode1,
		string FrtTaxDesc1,
		string FrtTaxCode2,
		string FrtTaxDesc2,
		string MiscTaxCode1,
		string MiscTaxDesc1,
		string MiscTaxCode2,
		string MiscTaxDesc2,
		string TransNat,
		string TransNat2,
		string Delterm,
		string ProcessInd,
		int? CusLcrReqd,
		int? CusUseExchRate,
		int? OnCreditHold,
		string Infobar,
		int? ShipmentApprovalRequired,
		int? ShipHold,
		int? CurAllowOver,
		int? CurpAllowOver,
		int? CustIncludePrice,
		int? ConsignableOrder,
		decimal? shipped_over_ordered_qty_tolerance,
		decimal? shipped_under_ordered_qty_tolerance,
		int? days_shipped_after_due_date_tolerance,
		int? days_shipped_before_due_date_tolerance,
		int? EdiOrder,
		int? LcrRequired,
		int? EnableOrderType,
		int? EnableConsolidate,
		int? EnableEffExpDate) CoCustomerValid2Sp(string CoNum,
		string OldCustNum,
		Guid? RowPointer,
		DateTime? OrderDate,
		decimal? ExchRate,
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
		string TaxCode1Type,
		string TaxCode1,
		string TaxDesc1,
		string TaxCode2Type,
		string TaxCode2,
		string TaxDesc2,
		string FrtTaxCode1Type,
		string FrtTaxCode1,
		string FrtTaxDesc1,
		string FrtTaxCode2Type,
		string FrtTaxCode2,
		string FrtTaxDesc2,
		string MiscTaxCode1Type,
		string MiscTaxCode1,
		string MiscTaxDesc1,
		string MiscTaxCode2Type,
		string MiscTaxCode2,
		string MiscTaxDesc2,
		string TransNat,
		string TransNat2,
		string Delterm,
		string ProcessInd,
		int? CusLcrReqd,
		int? CusUseExchRate,
		int? OnCreditHold,
		string Infobar,
		int? ShipmentApprovalRequired,
		int? ShipHold,
		int? CurAllowOver = null,
		int? CurpAllowOver = null,
		int? CustIncludePrice = null,
		int? Consignment = null,
		int? ConsignableOrder = null,
		decimal? shipped_over_ordered_qty_tolerance = null,
		decimal? shipped_under_ordered_qty_tolerance = null,
		int? days_shipped_after_due_date_tolerance = null,
		int? days_shipped_before_due_date_tolerance = null,
		int? EdiOrder = null,
		int? LcrRequired = null,
		int? EnableOrderType = null,
		int? EnableConsolidate = null,
		int? EnableEffExpDate = null,
		DateTime? CoOrderDate = null)
		{
			CoNumType _CoNum = CoNum;
			CustNumType _OldCustNum = OldCustNum;
			RowPointerType _RowPointer = RowPointer;
			DateType _OrderDate = OrderDate;
			ExchRateType _ExchRate = ExchRate;
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
			LongListType _TaxCode1Type = TaxCode1Type;
			TaxCodeType _TaxCode1 = TaxCode1;
			DescriptionType _TaxDesc1 = TaxDesc1;
			LongListType _TaxCode2Type = TaxCode2Type;
			TaxCodeType _TaxCode2 = TaxCode2;
			DescriptionType _TaxDesc2 = TaxDesc2;
			LongListType _FrtTaxCode1Type = FrtTaxCode1Type;
			TaxCodeType _FrtTaxCode1 = FrtTaxCode1;
			DescriptionType _FrtTaxDesc1 = FrtTaxDesc1;
			LongListType _FrtTaxCode2Type = FrtTaxCode2Type;
			TaxCodeType _FrtTaxCode2 = FrtTaxCode2;
			DescriptionType _FrtTaxDesc2 = FrtTaxDesc2;
			LongListType _MiscTaxCode1Type = MiscTaxCode1Type;
			TaxCodeType _MiscTaxCode1 = MiscTaxCode1;
			DescriptionType _MiscTaxDesc1 = MiscTaxDesc1;
			LongListType _MiscTaxCode2Type = MiscTaxCode2Type;
			TaxCodeType _MiscTaxCode2 = MiscTaxCode2;
			DescriptionType _MiscTaxDesc2 = MiscTaxDesc2;
			TransNatType _TransNat = TransNat;
			TransNat2Type _TransNat2 = TransNat2;
			DeltermType _Delterm = Delterm;
			ProcessIndType _ProcessInd = ProcessInd;
			ListYesNoType _CusLcrReqd = CusLcrReqd;
			ListYesNoType _CusUseExchRate = CusUseExchRate;
			ListYesNoType _OnCreditHold = OnCreditHold;
			LongListType _Infobar = Infobar;
			ListYesNoType _ShipmentApprovalRequired = ShipmentApprovalRequired;
			Flag _ShipHold = ShipHold;
			Flag _CurAllowOver = CurAllowOver;
			Flag _CurpAllowOver = CurpAllowOver;
			ListYesNoType _CustIncludePrice = CustIncludePrice;
			ListYesNoType _Consignment = Consignment;
			ListYesNoType _ConsignableOrder = ConsignableOrder;
			TolerancePercentType _shipped_over_ordered_qty_tolerance = shipped_over_ordered_qty_tolerance;
			TolerancePercentType _shipped_under_ordered_qty_tolerance = shipped_under_ordered_qty_tolerance;
			ToleranceDaysType _days_shipped_after_due_date_tolerance = days_shipped_after_due_date_tolerance;
			ToleranceDaysType _days_shipped_before_due_date_tolerance = days_shipped_before_due_date_tolerance;
			ListYesNoType _EdiOrder = EdiOrder;
			ListYesNoType _LcrRequired = LcrRequired;
			ListYesNoType _EnableOrderType = EnableOrderType;
			ListYesNoType _EnableConsolidate = EnableConsolidate;
			ListYesNoType _EnableEffExpDate = EnableEffExpDate;
			DateType _CoOrderDate = CoOrderDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoCustomerValid2Sp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCustNum", _OldCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDate", _OrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
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
				appDB.AddCommandParameter(cmd, "TaxCode1Type", _TaxCode1Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxDesc1", _TaxDesc1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2Type", _TaxCode2Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxDesc2", _TaxDesc2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FrtTaxCode1Type", _FrtTaxCode1Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrtTaxCode1", _FrtTaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FrtTaxDesc1", _FrtTaxDesc1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FrtTaxCode2Type", _FrtTaxCode2Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrtTaxCode2", _FrtTaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FrtTaxDesc2", _FrtTaxDesc2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscTaxCode1Type", _MiscTaxCode1Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscTaxCode1", _MiscTaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscTaxDesc1", _MiscTaxDesc1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscTaxCode2Type", _MiscTaxCode2Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscTaxCode2", _MiscTaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscTaxDesc2", _MiscTaxDesc2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CusLcrReqd", _CusLcrReqd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CusUseExchRate", _CusUseExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OnCreditHold", _OnCreditHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipmentApprovalRequired", _ShipmentApprovalRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipHold", _ShipHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurAllowOver", _CurAllowOver, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurpAllowOver", _CurpAllowOver, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustIncludePrice", _CustIncludePrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Consignment", _Consignment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsignableOrder", _ConsignableOrder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "shipped_over_ordered_qty_tolerance", _shipped_over_ordered_qty_tolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "shipped_under_ordered_qty_tolerance", _shipped_under_ordered_qty_tolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "days_shipped_after_due_date_tolerance", _days_shipped_after_due_date_tolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "days_shipped_before_due_date_tolerance", _days_shipped_before_due_date_tolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EdiOrder", _EdiOrder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LcrRequired", _LcrRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableOrderType", _EnableOrderType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableConsolidate", _EnableConsolidate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnableEffExpDate", _EnableEffExpDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoOrderDate", _CoOrderDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExchRate = _ExchRate;
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
				TaxDesc1 = _TaxDesc1;
				TaxCode2 = _TaxCode2;
				TaxDesc2 = _TaxDesc2;
				FrtTaxCode1 = _FrtTaxCode1;
				FrtTaxDesc1 = _FrtTaxDesc1;
				FrtTaxCode2 = _FrtTaxCode2;
				FrtTaxDesc2 = _FrtTaxDesc2;
				MiscTaxCode1 = _MiscTaxCode1;
				MiscTaxDesc1 = _MiscTaxDesc1;
				MiscTaxCode2 = _MiscTaxCode2;
				MiscTaxDesc2 = _MiscTaxDesc2;
				TransNat = _TransNat;
				TransNat2 = _TransNat2;
				Delterm = _Delterm;
				ProcessInd = _ProcessInd;
				CusLcrReqd = _CusLcrReqd;
				CusUseExchRate = _CusUseExchRate;
				OnCreditHold = _OnCreditHold;
				Infobar = _Infobar;
				ShipmentApprovalRequired = _ShipmentApprovalRequired;
				ShipHold = _ShipHold;
				CurAllowOver = _CurAllowOver;
				CurpAllowOver = _CurpAllowOver;
				CustIncludePrice = _CustIncludePrice;
				ConsignableOrder = _ConsignableOrder;
				shipped_over_ordered_qty_tolerance = _shipped_over_ordered_qty_tolerance;
				shipped_under_ordered_qty_tolerance = _shipped_under_ordered_qty_tolerance;
				days_shipped_after_due_date_tolerance = _days_shipped_after_due_date_tolerance;
				days_shipped_before_due_date_tolerance = _days_shipped_before_due_date_tolerance;
				EdiOrder = _EdiOrder;
				LcrRequired = _LcrRequired;
				EnableOrderType = _EnableOrderType;
				EnableConsolidate = _EnableConsolidate;
				EnableEffExpDate = _EnableEffExpDate;
				
				return (Severity, ExchRate, CustNum, CustSeq, ShipmentExists, BillToAddress, ShipToAddress, Contact, Phone, BillToContact, BillToPhone, ShipToContact, ShipToPhone, CorpCust, CorpCustName, CorpCustContact, CorpCustPhone, CorpAddress, CurrCode, UseExchRate, Whse, ShipCode, ShipCodeDesc, ShipPartial, ShipEarly, Consolidate, Summarize, InvFreq, Einvoice, TermsCode, TermsCodeDesc, Slsman, PriceCode, PriceCodeDesc, EndUserType, EndUserTypeDesc, ApsPullUp, TaxCode1, TaxDesc1, TaxCode2, TaxDesc2, FrtTaxCode1, FrtTaxDesc1, FrtTaxCode2, FrtTaxDesc2, MiscTaxCode1, MiscTaxDesc1, MiscTaxCode2, MiscTaxDesc2, TransNat, TransNat2, Delterm, ProcessInd, CusLcrReqd, CusUseExchRate, OnCreditHold, Infobar, ShipmentApprovalRequired, ShipHold, CurAllowOver, CurpAllowOver, CustIncludePrice, ConsignableOrder, shipped_over_ordered_qty_tolerance, shipped_under_ordered_qty_tolerance, days_shipped_after_due_date_tolerance, days_shipped_before_due_date_tolerance, EdiOrder, LcrRequired, EnableOrderType, EnableConsolidate, EnableEffExpDate);
			}
		}
	}
}
