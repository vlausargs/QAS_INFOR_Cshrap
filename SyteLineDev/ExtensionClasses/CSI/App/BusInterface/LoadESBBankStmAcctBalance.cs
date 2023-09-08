//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctBalance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmAcctBalance
	{
		int LoadESBBankStmAcctBalanceSP(string StmDocumentID,
		                                string AcctLineNumber,
		                                string BalanceType,
		                                string BalanceDebitCreditFlag,
		                                decimal? BalanceAmount,
		                                string BalanceAmountCurrencyID,
		                                DateTime? BalanceDateTime,
		                                ref string InfoBar);
	}
	
	public class LoadESBBankStmAcctBalance : ILoadESBBankStmAcctBalance
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmAcctBalance(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmAcctBalanceSP(string StmDocumentID,
		                                       string AcctLineNumber,
		                                       string BalanceType,
		                                       string BalanceDebitCreditFlag,
		                                       decimal? BalanceAmount,
		                                       string BalanceAmountCurrencyID,
		                                       DateTime? BalanceDateTime,
		                                       ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _BalanceType = BalanceType;
			MarkupElementValueType _BalanceDebitCreditFlag = BalanceDebitCreditFlag;
			DecimalType _BalanceAmount = BalanceAmount;
			MarkupElementValueType _BalanceAmountCurrencyID = BalanceAmountCurrencyID;
			DateTimeType _BalanceDateTime = BalanceDateTime;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmAcctBalanceSP";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalanceType", _BalanceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalanceDebitCreditFlag", _BalanceDebitCreditFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalanceAmount", _BalanceAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalanceAmountCurrencyID", _BalanceAmountCurrencyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalanceDateTime", _BalanceDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
