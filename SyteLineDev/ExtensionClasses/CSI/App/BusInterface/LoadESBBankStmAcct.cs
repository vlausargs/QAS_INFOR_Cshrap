//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmAcct
	{
		int LoadESBBankStmAcctSp(string StmDocumentID,
		                         string AcctLineNumber,
		                         int? AcctElectronicSequence,
		                         int? AcctLegalSequence,
		                         DateTime? AcctStatementPeriodStartDate,
		                         DateTime? AcctStatementPeriodEndDate,
		                         string AcctCopyIndicator,
		                         string AcctDuplicateIndicator,
		                         string AcctBankAccountID,
		                         string AcctIBANID,
		                         string AcctBBANID,
		                         string AcctBankAccountCurrencyCode,
		                         string AcctBankAccountStatusCode,
		                         string AcctBankAccountStatusReasonCode,
		                         DateTime? AcctBankAccountStatusEffectivityDate,
		                         string AcctAccountOwnerPartyID,
		                         string AcctAccountOwnerBIC,
		                         ref string InfoBar);
	}
	
	public class LoadESBBankStmAcct : ILoadESBBankStmAcct
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmAcctSp(string StmDocumentID,
		                                string AcctLineNumber,
		                                int? AcctElectronicSequence,
		                                int? AcctLegalSequence,
		                                DateTime? AcctStatementPeriodStartDate,
		                                DateTime? AcctStatementPeriodEndDate,
		                                string AcctCopyIndicator,
		                                string AcctDuplicateIndicator,
		                                string AcctBankAccountID,
		                                string AcctIBANID,
		                                string AcctBBANID,
		                                string AcctBankAccountCurrencyCode,
		                                string AcctBankAccountStatusCode,
		                                string AcctBankAccountStatusReasonCode,
		                                DateTime? AcctBankAccountStatusEffectivityDate,
		                                string AcctAccountOwnerPartyID,
		                                string AcctAccountOwnerBIC,
		                                ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			IntType _AcctElectronicSequence = AcctElectronicSequence;
			IntType _AcctLegalSequence = AcctLegalSequence;
			DateTimeType _AcctStatementPeriodStartDate = AcctStatementPeriodStartDate;
			DateTimeType _AcctStatementPeriodEndDate = AcctStatementPeriodEndDate;
			MarkupElementValueType _AcctCopyIndicator = AcctCopyIndicator;
			MarkupElementValueType _AcctDuplicateIndicator = AcctDuplicateIndicator;
			MarkupElementValueType _AcctBankAccountID = AcctBankAccountID;
			MarkupElementValueType _AcctIBANID = AcctIBANID;
			MarkupElementValueType _AcctBBANID = AcctBBANID;
			MarkupElementValueType _AcctBankAccountCurrencyCode = AcctBankAccountCurrencyCode;
			MarkupElementValueType _AcctBankAccountStatusCode = AcctBankAccountStatusCode;
			MarkupElementValueType _AcctBankAccountStatusReasonCode = AcctBankAccountStatusReasonCode;
			DateTimeType _AcctBankAccountStatusEffectivityDate = AcctBankAccountStatusEffectivityDate;
			MarkupElementValueType _AcctAccountOwnerPartyID = AcctAccountOwnerPartyID;
			MarkupElementValueType _AcctAccountOwnerBIC = AcctAccountOwnerBIC;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmAcctSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctElectronicSequence", _AcctElectronicSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLegalSequence", _AcctLegalSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctStatementPeriodStartDate", _AcctStatementPeriodStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctStatementPeriodEndDate", _AcctStatementPeriodEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctCopyIndicator", _AcctCopyIndicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctDuplicateIndicator", _AcctDuplicateIndicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctBankAccountID", _AcctBankAccountID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctIBANID", _AcctIBANID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctBBANID", _AcctBBANID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctBankAccountCurrencyCode", _AcctBankAccountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctBankAccountStatusCode", _AcctBankAccountStatusCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctBankAccountStatusReasonCode", _AcctBankAccountStatusReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctBankAccountStatusEffectivityDate", _AcctBankAccountStatusEffectivityDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctAccountOwnerPartyID", _AcctAccountOwnerPartyID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctAccountOwnerBIC", _AcctAccountOwnerBIC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
