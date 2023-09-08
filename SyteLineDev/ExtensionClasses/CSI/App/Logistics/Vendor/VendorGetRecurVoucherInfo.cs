//PROJECT NAME: Logistics
//CLASS NAME: VendorGetRecurVoucherInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendorGetRecurVoucherInfo : IVendorGetRecurVoucherInfo
	{
		readonly IApplicationDB appDB;
		
		
		public VendorGetRecurVoucherInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string RTaxCode1,
		string RTaxCode1Desc,
		string RTaxCode2,
		string RTaxCode2Desc,
		string RCurrCode,
		decimal? RExchRate,
		int? RProxCode,
		int? RProxDay,
		decimal? RDiscPct,
		int? RDiscDays,
		DateTime? RDiscDate,
		int? RDueDays,
		DateTime? RDueDate,
		string RApAcct,
		string RApAcctUnit1,
		string RApAcctUnit2,
		string RApAcctUnit3,
		string RApAcctUnit4,
		string RApAcctDesc,
		string RTermsCode,
		string Infobar,
		int? RApAcctIsControl) VendorGetRecurVoucherInfoSp(string PVendNum,
		DateTime? PInvoiceDate,
		string RTaxCode1,
		string RTaxCode1Desc,
		string RTaxCode2,
		string RTaxCode2Desc,
		string RCurrCode,
		decimal? RExchRate,
		int? RProxCode,
		int? RProxDay,
		decimal? RDiscPct,
		int? RDiscDays,
		DateTime? RDiscDate,
		int? RDueDays,
		DateTime? RDueDate,
		string RApAcct,
		string RApAcctUnit1,
		string RApAcctUnit2,
		string RApAcctUnit3,
		string RApAcctUnit4,
		string RApAcctDesc,
		string RTermsCode,
		string Infobar,
		int? RApAcctIsControl)
		{
			VendNumType _PVendNum = PVendNum;
			DateType _PInvoiceDate = PInvoiceDate;
			TaxCodeType _RTaxCode1 = RTaxCode1;
			DescriptionType _RTaxCode1Desc = RTaxCode1Desc;
			TaxCodeType _RTaxCode2 = RTaxCode2;
			DescriptionType _RTaxCode2Desc = RTaxCode2Desc;
			CurrCodeType _RCurrCode = RCurrCode;
			ExchRateType _RExchRate = RExchRate;
			ProxCodeType _RProxCode = RProxCode;
			ProxDayType _RProxDay = RProxDay;
			ApDiscType _RDiscPct = RDiscPct;
			DiscDaysType _RDiscDays = RDiscDays;
			DateType _RDiscDate = RDiscDate;
			DueDaysType _RDueDays = RDueDays;
			DateType _RDueDate = RDueDate;
			AcctType _RApAcct = RApAcct;
			UnitCode1Type _RApAcctUnit1 = RApAcctUnit1;
			UnitCode2Type _RApAcctUnit2 = RApAcctUnit2;
			UnitCode3Type _RApAcctUnit3 = RApAcctUnit3;
			UnitCode4Type _RApAcctUnit4 = RApAcctUnit4;
			DescriptionType _RApAcctDesc = RApAcctDesc;
			TermsCodeType _RTermsCode = RTermsCode;
			InfobarType _Infobar = Infobar;
			ListYesNoType _RApAcctIsControl = RApAcctIsControl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendorGetRecurVoucherInfoSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvoiceDate", _PInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RTaxCode1", _RTaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RTaxCode1Desc", _RTaxCode1Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RTaxCode2", _RTaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RTaxCode2Desc", _RTaxCode2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RCurrCode", _RCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RExchRate", _RExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RProxCode", _RProxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RProxDay", _RProxDay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RDiscPct", _RDiscPct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RDiscDays", _RDiscDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RDiscDate", _RDiscDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RDueDays", _RDueDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RDueDate", _RDueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RApAcct", _RApAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RApAcctUnit1", _RApAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RApAcctUnit2", _RApAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RApAcctUnit3", _RApAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RApAcctUnit4", _RApAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RApAcctDesc", _RApAcctDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RTermsCode", _RTermsCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RApAcctIsControl", _RApAcctIsControl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RTaxCode1 = _RTaxCode1;
				RTaxCode1Desc = _RTaxCode1Desc;
				RTaxCode2 = _RTaxCode2;
				RTaxCode2Desc = _RTaxCode2Desc;
				RCurrCode = _RCurrCode;
				RExchRate = _RExchRate;
				RProxCode = _RProxCode;
				RProxDay = _RProxDay;
				RDiscPct = _RDiscPct;
				RDiscDays = _RDiscDays;
				RDiscDate = _RDiscDate;
				RDueDays = _RDueDays;
				RDueDate = _RDueDate;
				RApAcct = _RApAcct;
				RApAcctUnit1 = _RApAcctUnit1;
				RApAcctUnit2 = _RApAcctUnit2;
				RApAcctUnit3 = _RApAcctUnit3;
				RApAcctUnit4 = _RApAcctUnit4;
				RApAcctDesc = _RApAcctDesc;
				RTermsCode = _RTermsCode;
				Infobar = _Infobar;
				RApAcctIsControl = _RApAcctIsControl;
				
				return (Severity, RTaxCode1, RTaxCode1Desc, RTaxCode2, RTaxCode2Desc, RCurrCode, RExchRate, RProxCode, RProxDay, RDiscPct, RDiscDays, RDiscDate, RDueDays, RDueDate, RApAcct, RApAcctUnit1, RApAcctUnit2, RApAcctUnit3, RApAcctUnit4, RApAcctDesc, RTermsCode, Infobar, RApAcctIsControl);
			}
		}
	}
}
