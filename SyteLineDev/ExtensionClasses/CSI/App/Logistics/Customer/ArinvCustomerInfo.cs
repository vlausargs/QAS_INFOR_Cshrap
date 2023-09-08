//PROJECT NAME: Logistics
//CLASS NAME: ArinvCustomerInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArinvCustomerInfo : IArinvCustomerInfo
	{
		readonly IApplicationDB appDB;
		
		
		public ArinvCustomerInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? DueDate,
		string CustType,
		string TermsCode,
		string PayType,
		string TaxCode1,
		string TaxCode2,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		int? UseExchRate,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string Infobar,
		int? IsControl) ArinvCustomerInfoSp(string CustNum,
		string ArinvType,
		DateTime? InvoiceDate,
		DateTime? DueDate,
		string CustType,
		string TermsCode,
		string PayType,
		string TaxCode1,
		string TaxCode2,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		int? UseExchRate,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string Infobar,
		string App_To_Inv_Num,
		int? IsControl)
		{
			CustNumType _CustNum = CustNum;
			ArinvTypeType _ArinvType = ArinvType;
			DateType _InvoiceDate = InvoiceDate;
			DateType _DueDate = DueDate;
			CustTypeType _CustType = CustType;
			TermsCodeType _TermsCode = TermsCode;
			CustPayTypeType _PayType = PayType;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			CurrCodeType _CurrCode = CurrCode;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _CurrRateIsFixed = CurrRateIsFixed;
			ListYesNoType _UseExchRate = UseExchRate;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			UnitCodeAccessType _AccessUnit1 = AccessUnit1;
			UnitCodeAccessType _AccessUnit2 = AccessUnit2;
			UnitCodeAccessType _AccessUnit3 = AccessUnit3;
			UnitCodeAccessType _AccessUnit4 = AccessUnit4;
			Infobar _Infobar = Infobar;
			InvNumType _App_To_Inv_Num = App_To_Inv_Num;
			ListYesNoType _IsControl = IsControl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArinvCustomerInfoSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArinvType", _ArinvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustType", _CustType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrRateIsFixed", _CurrRateIsFixed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseExchRate", _UseExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit1", _AccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit2", _AccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit3", _AccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit4", _AccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "App_To_Inv_Num", _App_To_Inv_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsControl", _IsControl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DueDate = _DueDate;
				CustType = _CustType;
				TermsCode = _TermsCode;
				PayType = _PayType;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				CurrCode = _CurrCode;
				ExchRate = _ExchRate;
				CurrRateIsFixed = _CurrRateIsFixed;
				UseExchRate = _UseExchRate;
				Acct = _Acct;
				AcctUnit1 = _AcctUnit1;
				AcctUnit2 = _AcctUnit2;
				AcctUnit3 = _AcctUnit3;
				AcctUnit4 = _AcctUnit4;
				AccessUnit1 = _AccessUnit1;
				AccessUnit2 = _AccessUnit2;
				AccessUnit3 = _AccessUnit3;
				AccessUnit4 = _AccessUnit4;
				Infobar = _Infobar;
				IsControl = _IsControl;
				
				return (Severity, DueDate, CustType, TermsCode, PayType, TaxCode1, TaxCode2, CurrCode, ExchRate, CurrRateIsFixed, UseExchRate, Acct, AcctUnit1, AcctUnit2, AcctUnit3, AcctUnit4, AccessUnit1, AccessUnit2, AccessUnit3, AccessUnit4, Infobar, IsControl);
			}
		}
	}
}
