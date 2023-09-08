//PROJECT NAME: POS
//CLASS NAME: SSSPOSCreatePayd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSCreatePayd : ISSSPOSCreatePayd
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSCreatePayd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSPOSCreatePaydSp(
			string PType,
			string CoNum,
			string InvNum,
			decimal? Amount,
			string ArpmtBankCode,
			string ArpmtCustNum,
			string ArpmtPmtType,
			int? ArpmtCheckNum,
			DateTime? ArpmtRecptDate,
			decimal? ArpmtExchRate,
			string CustAddrCurrCode,
			string CustAddrBalMethod,
			string ParmCurrCode,
			string ParmSite,
			string Infobar,
			int? POSMCredit,
			string POSMNum,
			string ArpmtPaymentCurrCode,
			decimal? ArpmtPaymentExchRate)
		{
			StringType _PType = PType;
			CoNumType _CoNum = CoNum;
			InvNumType _InvNum = InvNum;
			AmountType _Amount = Amount;
			BankCodeType _ArpmtBankCode = ArpmtBankCode;
			CustNumType _ArpmtCustNum = ArpmtCustNum;
			ArpmtTypeType _ArpmtPmtType = ArpmtPmtType;
			ArCheckNumType _ArpmtCheckNum = ArpmtCheckNum;
			DateType _ArpmtRecptDate = ArpmtRecptDate;
			ExchRateType _ArpmtExchRate = ArpmtExchRate;
			CurrCodeType _CustAddrCurrCode = CustAddrCurrCode;
			BalMethodType _CustAddrBalMethod = CustAddrBalMethod;
			CurrCodeType _ParmCurrCode = ParmCurrCode;
			SiteType _ParmSite = ParmSite;
			Infobar _Infobar = Infobar;
			ListYesNoType _POSMCredit = POSMCredit;
			POSMNumType _POSMNum = POSMNum;
			CurrCodeType _ArpmtPaymentCurrCode = ArpmtPaymentCurrCode;
			ExchRateType _ArpmtPaymentExchRate = ArpmtPaymentExchRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSCreatePaydSp";
				
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtBankCode", _ArpmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtCustNum", _ArpmtCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtPmtType", _ArpmtPmtType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtCheckNum", _ArpmtCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtRecptDate", _ArpmtRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtExchRate", _ArpmtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustAddrCurrCode", _CustAddrCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustAddrBalMethod", _CustAddrBalMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmSite", _ParmSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POSMCredit", _POSMCredit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMNum", _POSMNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtPaymentCurrCode", _ArpmtPaymentCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtPaymentExchRate", _ArpmtPaymentExchRate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
