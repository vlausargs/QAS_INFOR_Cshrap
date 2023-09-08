//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctEntry.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmAcctEntry
	{
		int LoadESBBankStmAcctEntrySp(string StmDocumentID,
		                              string AcctLineNumber,
		                              string AcctEntryLineNumber,
		                              string AcctEntryAccountServicerNote,
		                              decimal? AcctEntryAmount,
		                              string AcctEntryAmountCurrencyCode,
		                              string AcctEntryAmountDebitCreditFlag,
		                              string AcctEntryReversalIndicator,
		                              string AcctEntryStatusCode,
		                              string AcctEntryStatusReasonCode,
		                              DateTime? AcctEntryStatusEffectiveDateTime,
		                              DateTime? AcctEntryBookingDateTime,
		                              DateTime? AcctEntryValueDateTime,
		                              ref string InfoBar);
	}
	
	public class LoadESBBankStmAcctEntry : ILoadESBBankStmAcctEntry
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmAcctEntry(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmAcctEntrySp(string StmDocumentID,
		                                     string AcctLineNumber,
		                                     string AcctEntryLineNumber,
		                                     string AcctEntryAccountServicerNote,
		                                     decimal? AcctEntryAmount,
		                                     string AcctEntryAmountCurrencyCode,
		                                     string AcctEntryAmountDebitCreditFlag,
		                                     string AcctEntryReversalIndicator,
		                                     string AcctEntryStatusCode,
		                                     string AcctEntryStatusReasonCode,
		                                     DateTime? AcctEntryStatusEffectiveDateTime,
		                                     DateTime? AcctEntryBookingDateTime,
		                                     DateTime? AcctEntryValueDateTime,
		                                     ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _AcctEntryAccountServicerNote = AcctEntryAccountServicerNote;
			DecimalType _AcctEntryAmount = AcctEntryAmount;
			MarkupElementValueType _AcctEntryAmountCurrencyCode = AcctEntryAmountCurrencyCode;
			MarkupElementValueType _AcctEntryAmountDebitCreditFlag = AcctEntryAmountDebitCreditFlag;
			MarkupElementValueType _AcctEntryReversalIndicator = AcctEntryReversalIndicator;
			MarkupElementValueType _AcctEntryStatusCode = AcctEntryStatusCode;
			MarkupElementValueType _AcctEntryStatusReasonCode = AcctEntryStatusReasonCode;
			DateTimeType _AcctEntryStatusEffectiveDateTime = AcctEntryStatusEffectiveDateTime;
			DateTimeType _AcctEntryBookingDateTime = AcctEntryBookingDateTime;
			DateTimeType _AcctEntryValueDateTime = AcctEntryValueDateTime;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmAcctEntrySp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryAccountServicerNote", _AcctEntryAccountServicerNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryAmount", _AcctEntryAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryAmountCurrencyCode", _AcctEntryAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryAmountDebitCreditFlag", _AcctEntryAmountDebitCreditFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryReversalIndicator", _AcctEntryReversalIndicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryStatusCode", _AcctEntryStatusCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryStatusReasonCode", _AcctEntryStatusReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryStatusEffectiveDateTime", _AcctEntryStatusEffectiveDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryBookingDateTime", _AcctEntryBookingDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryValueDateTime", _AcctEntryValueDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
