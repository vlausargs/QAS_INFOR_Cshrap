//PROJECT NAME: Reporting
//CLASS NAME: CHSRpt_DebitCreditAssign.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class CHSRpt_DebitCreditAssign : ICHSRpt_DebitCreditAssign
	{
		readonly IApplicationDB appDB;
		
		public CHSRpt_DebitCreditAssign(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? DebitValue,
			decimal? CreditValue,
			decimal? FDebitValue,
			decimal? FCreditValue,
			decimal? BalanceValue,
			decimal? FBalanceValue,
			string InfoBar) CHSRpt_DebitCreditAssignSp(
			int? AcctStatus,
			decimal? DomAmount,
			decimal? ForAmount,
			int? Rubric,
			decimal? DebitValue,
			decimal? CreditValue,
			decimal? FDebitValue,
			decimal? FCreditValue,
			decimal? BalanceValue,
			decimal? FBalanceValue,
			string InfoBar)
		{
			FlagNyType _AcctStatus = AcctStatus;
			AmountType _DomAmount = DomAmount;
			AmountType _ForAmount = ForAmount;
			FlagNyType _Rubric = Rubric;
			AmountType _DebitValue = DebitValue;
			AmountType _CreditValue = CreditValue;
			AmountType _FDebitValue = FDebitValue;
			AmountType _FCreditValue = FCreditValue;
			AmountType _BalanceValue = BalanceValue;
			AmountType _FBalanceValue = FBalanceValue;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_DebitCreditAssignSp";
				
				appDB.AddCommandParameter(cmd, "AcctStatus", _AcctStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomAmount", _DomAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAmount", _ForAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rubric", _Rubric, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DebitValue", _DebitValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreditValue", _CreditValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FDebitValue", _FDebitValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FCreditValue", _FCreditValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BalanceValue", _BalanceValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FBalanceValue", _FBalanceValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DebitValue = _DebitValue;
				CreditValue = _CreditValue;
				FDebitValue = _FDebitValue;
				FCreditValue = _FCreditValue;
				BalanceValue = _BalanceValue;
				FBalanceValue = _FBalanceValue;
				InfoBar = _InfoBar;
				
				return (Severity, DebitValue, CreditValue, FDebitValue, FCreditValue, BalanceValue, FBalanceValue, InfoBar);
			}
		}
	}
}
