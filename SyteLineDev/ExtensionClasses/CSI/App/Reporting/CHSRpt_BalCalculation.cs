//PROJECT NAME: Reporting
//CLASS NAME: CHSRpt_BalCalculation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class CHSRpt_BalCalculation : ICHSRpt_BalCalculation
	{
		readonly IApplicationDB appDB;
		
		public CHSRpt_BalCalculation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? DDebitAmount,
			decimal? FDebitAmount,
			decimal? DCreditAmount,
			decimal? FCreditAmount,
			decimal? DebitCredit,
			decimal? BalAmount,
			decimal? DBalAmount,
			decimal? FBalAmount,
			decimal? DPrevYearBalance,
			decimal? FPrevYearBalance,
			decimal? ExRate,
			string InfoBar) CHSRpt_BalCalculationSp(
			string Acct,
			int? SortMethod,
			string CurrCode,
			int? FrgnCurr,
			DateTime? StartPeriod,
			DateTime? ENDDate,
			DateTime? BeginDate,
			string Unit1,
			string Unit2,
			string Unit3,
			string Unit4,
			string TempType,
			decimal? DDebitAmount,
			decimal? FDebitAmount,
			decimal? DCreditAmount,
			decimal? FCreditAmount,
			decimal? DebitCredit,
			decimal? BalAmount,
			decimal? DBalAmount,
			decimal? FBalAmount,
			decimal? DPrevYearBalance,
			decimal? FPrevYearBalance,
			decimal? ExRate,
			string InfoBar)
		{
			AcctType _Acct = Acct;
			SortMethodType _SortMethod = SortMethod;
			CurrCodeType _CurrCode = CurrCode;
			FlagNyType _FrgnCurr = FrgnCurr;
			DateType _StartPeriod = StartPeriod;
			DateType _ENDDate = ENDDate;
			DateType _BeginDate = BeginDate;
			UnitCode1Type _Unit1 = Unit1;
			UnitCode2Type _Unit2 = Unit2;
			UnitCode3Type _Unit3 = Unit3;
			UnitCode4Type _Unit4 = Unit4;
			RetCodeType _TempType = TempType;
			AmountType _DDebitAmount = DDebitAmount;
			AmountType _FDebitAmount = FDebitAmount;
			AmountType _DCreditAmount = DCreditAmount;
			AmountType _FCreditAmount = FCreditAmount;
			AmountType _DebitCredit = DebitCredit;
			AmountType _BalAmount = BalAmount;
			AmountType _DBalAmount = DBalAmount;
			AmountType _FBalAmount = FBalAmount;
			AmountType _DPrevYearBalance = DPrevYearBalance;
			AmountType _FPrevYearBalance = FPrevYearBalance;
			DecimalType _ExRate = ExRate;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_BalCalculationSp";
				
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortMethod", _SortMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FrgnCurr", _FrgnCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPeriod", _StartPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ENDDate", _ENDDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginDate", _BeginDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit1", _Unit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit2", _Unit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit3", _Unit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit4", _Unit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TempType", _TempType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DDebitAmount", _DDebitAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FDebitAmount", _FDebitAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DCreditAmount", _DCreditAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FCreditAmount", _FCreditAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DebitCredit", _DebitCredit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BalAmount", _BalAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DBalAmount", _DBalAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FBalAmount", _FBalAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DPrevYearBalance", _DPrevYearBalance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FPrevYearBalance", _FPrevYearBalance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExRate", _ExRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DDebitAmount = _DDebitAmount;
				FDebitAmount = _FDebitAmount;
				DCreditAmount = _DCreditAmount;
				FCreditAmount = _FCreditAmount;
				DebitCredit = _DebitCredit;
				BalAmount = _BalAmount;
				DBalAmount = _DBalAmount;
				FBalAmount = _FBalAmount;
				DPrevYearBalance = _DPrevYearBalance;
				FPrevYearBalance = _FPrevYearBalance;
				ExRate = _ExRate;
				InfoBar = _InfoBar;
				
				return (Severity, DDebitAmount, FDebitAmount, DCreditAmount, FCreditAmount, DebitCredit, BalAmount, DBalAmount, FBalAmount, DPrevYearBalance, FPrevYearBalance, ExRate, InfoBar);
			}
		}
	}
}
