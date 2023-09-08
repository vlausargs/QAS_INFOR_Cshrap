//PROJECT NAME: Logistics
//CLASS NAME: EstCustomerValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EstCustomerValid : IEstCustomerValid
	{
		readonly IApplicationDB appDB;
		
		
		public EstCustomerValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CustSeq,
		string Contact,
		string Phone,
		string Slsman,
		string CustType,
		string TermsCode,
		string Pricecode,
		string TaxCode1,
		string TaxCode2,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		int? UseExchRate,
		int? ShipEarly,
		int? ShipPartial,
		string ShipCode,
		string BillToAddress,
		string ShipToAddress,
		string PCur0AmtFormat,
		string Infobar) EstCustomerValidSp(string CustNum,
		int? CustSeq,
		string Contact,
		string Phone,
		string Slsman,
		string CustType,
		string TermsCode,
		string Pricecode,
		string TaxCode1,
		string TaxCode2,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		int? UseExchRate,
		int? ShipEarly,
		int? ShipPartial,
		string ShipCode,
		string BillToAddress,
		string ShipToAddress,
		string PCur0AmtFormat,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			ContactType _Contact = Contact;
			PhoneType _Phone = Phone;
			SlsmanType _Slsman = Slsman;
			CustTypeType _CustType = CustType;
			TermsCodeType _TermsCode = TermsCode;
			PriceCodeType _Pricecode = Pricecode;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			CurrCodeType _CurrCode = CurrCode;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _CurrRateIsFixed = CurrRateIsFixed;
			ListYesNoType _UseExchRate = UseExchRate;
			ListYesNoType _ShipEarly = ShipEarly;
			ListYesNoType _ShipPartial = ShipPartial;
			ShipCodeType _ShipCode = ShipCode;
			LongAddress _BillToAddress = BillToAddress;
			LongAddress _ShipToAddress = ShipToAddress;
			InputMaskType _PCur0AmtFormat = PCur0AmtFormat;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstCustomerValidSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustType", _CustType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrRateIsFixed", _CurrRateIsFixed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseExchRate", _UseExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipEarly", _ShipEarly, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipPartial", _ShipPartial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillToAddress", _BillToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToAddress", _ShipToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCur0AmtFormat", _PCur0AmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustSeq = _CustSeq;
				Contact = _Contact;
				Phone = _Phone;
				Slsman = _Slsman;
				CustType = _CustType;
				TermsCode = _TermsCode;
				Pricecode = _Pricecode;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				CurrCode = _CurrCode;
				ExchRate = _ExchRate;
				CurrRateIsFixed = _CurrRateIsFixed;
				UseExchRate = _UseExchRate;
				ShipEarly = _ShipEarly;
				ShipPartial = _ShipPartial;
				ShipCode = _ShipCode;
				BillToAddress = _BillToAddress;
				ShipToAddress = _ShipToAddress;
				PCur0AmtFormat = _PCur0AmtFormat;
				Infobar = _Infobar;
				
				return (Severity, CustSeq, Contact, Phone, Slsman, CustType, TermsCode, Pricecode, TaxCode1, TaxCode2, CurrCode, ExchRate, CurrRateIsFixed, UseExchRate, ShipEarly, ShipPartial, ShipCode, BillToAddress, ShipToAddress, PCur0AmtFormat, Infobar);
			}
		}
	}
}
