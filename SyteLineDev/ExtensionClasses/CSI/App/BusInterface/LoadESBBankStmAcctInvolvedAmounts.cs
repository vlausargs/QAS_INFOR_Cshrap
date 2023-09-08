//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctInvolvedAmounts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmAcctInvolvedAmounts
	{
		int LoadESBBankStmAcctInvolvedAmountsSp(string StmDocumentID,
		                                        string AcctLineNumber,
		                                        string AcctEntryLineNumber,
		                                        string EntryDetailTranLineNumber,
		                                        decimal? InvolvedAmountsAmount,
		                                        string InvolvedAmountsAmountCurrencyCode,
		                                        string InvolvedAmountsSourceCurrencyCode,
		                                        decimal? InvolvedAmountsSourceUnitBaseNumeric,
		                                        string InvolvedAmountsTargetCurrencyCode,
		                                        decimal? InvolvedAmountsTargetUnitBaseNumeric,
		                                        decimal? InvolvedAmountsRateNumeric,
		                                        DateTime? InvolvedAmountsEffectiveStartDateTime,
		                                        DateTime? InvolvedAmountsEffectiveEndDateTime,
		                                        ref string InfoBar);
	}
	
	public class LoadESBBankStmAcctInvolvedAmounts : ILoadESBBankStmAcctInvolvedAmounts
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmAcctInvolvedAmounts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmAcctInvolvedAmountsSp(string StmDocumentID,
		                                               string AcctLineNumber,
		                                               string AcctEntryLineNumber,
		                                               string EntryDetailTranLineNumber,
		                                               decimal? InvolvedAmountsAmount,
		                                               string InvolvedAmountsAmountCurrencyCode,
		                                               string InvolvedAmountsSourceCurrencyCode,
		                                               decimal? InvolvedAmountsSourceUnitBaseNumeric,
		                                               string InvolvedAmountsTargetCurrencyCode,
		                                               decimal? InvolvedAmountsTargetUnitBaseNumeric,
		                                               decimal? InvolvedAmountsRateNumeric,
		                                               DateTime? InvolvedAmountsEffectiveStartDateTime,
		                                               DateTime? InvolvedAmountsEffectiveEndDateTime,
		                                               ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			DecimalType _InvolvedAmountsAmount = InvolvedAmountsAmount;
			MarkupElementValueType _InvolvedAmountsAmountCurrencyCode = InvolvedAmountsAmountCurrencyCode;
			MarkupElementValueType _InvolvedAmountsSourceCurrencyCode = InvolvedAmountsSourceCurrencyCode;
			DecimalType _InvolvedAmountsSourceUnitBaseNumeric = InvolvedAmountsSourceUnitBaseNumeric;
			MarkupElementValueType _InvolvedAmountsTargetCurrencyCode = InvolvedAmountsTargetCurrencyCode;
			DecimalType _InvolvedAmountsTargetUnitBaseNumeric = InvolvedAmountsTargetUnitBaseNumeric;
			DecimalType _InvolvedAmountsRateNumeric = InvolvedAmountsRateNumeric;
			DateTimeType _InvolvedAmountsEffectiveStartDateTime = InvolvedAmountsEffectiveStartDateTime;
			DateTimeType _InvolvedAmountsEffectiveEndDateTime = InvolvedAmountsEffectiveEndDateTime;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmAcctInvolvedAmountsSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvolvedAmountsAmount", _InvolvedAmountsAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvolvedAmountsAmountCurrencyCode", _InvolvedAmountsAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvolvedAmountsSourceCurrencyCode", _InvolvedAmountsSourceCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvolvedAmountsSourceUnitBaseNumeric", _InvolvedAmountsSourceUnitBaseNumeric, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvolvedAmountsTargetCurrencyCode", _InvolvedAmountsTargetCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvolvedAmountsTargetUnitBaseNumeric", _InvolvedAmountsTargetUnitBaseNumeric, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvolvedAmountsRateNumeric", _InvolvedAmountsRateNumeric, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvolvedAmountsEffectiveStartDateTime", _InvolvedAmountsEffectiveStartDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvolvedAmountsEffectiveEndDateTime", _InvolvedAmountsEffectiveEndDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
