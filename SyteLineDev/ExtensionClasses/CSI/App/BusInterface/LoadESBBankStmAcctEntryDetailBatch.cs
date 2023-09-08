//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctEntryDetailBatch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmAcctEntryDetailBatch
	{
		int LoadESBBankStmAcctEntryDetailBatchSp(string StmDocumentID,
		                                         string AcctLineNumber,
		                                         string AcctEntryLineNumber,
		                                         string AcctEntryBatchMessageID,
		                                         string AcctEntryBatchPaymentInformation,
		                                         int? AcctEntryBatchNumberOfTransactions,
		                                         decimal? AcctEntryBatchTotalAmount,
		                                         string AcctEntryBatchTotalAmountCurrencyCode,
		                                         string AcctEntryBatchTotalAmountDebitCreditFlag,
		                                         ref string InfoBar);
	}
	
	public class LoadESBBankStmAcctEntryDetailBatch : ILoadESBBankStmAcctEntryDetailBatch
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmAcctEntryDetailBatch(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmAcctEntryDetailBatchSp(string StmDocumentID,
		                                                string AcctLineNumber,
		                                                string AcctEntryLineNumber,
		                                                string AcctEntryBatchMessageID,
		                                                string AcctEntryBatchPaymentInformation,
		                                                int? AcctEntryBatchNumberOfTransactions,
		                                                decimal? AcctEntryBatchTotalAmount,
		                                                string AcctEntryBatchTotalAmountCurrencyCode,
		                                                string AcctEntryBatchTotalAmountDebitCreditFlag,
		                                                ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _AcctEntryBatchMessageID = AcctEntryBatchMessageID;
			MarkupElementValueType _AcctEntryBatchPaymentInformation = AcctEntryBatchPaymentInformation;
			IntType _AcctEntryBatchNumberOfTransactions = AcctEntryBatchNumberOfTransactions;
			DecimalType _AcctEntryBatchTotalAmount = AcctEntryBatchTotalAmount;
			MarkupElementValueType _AcctEntryBatchTotalAmountCurrencyCode = AcctEntryBatchTotalAmountCurrencyCode;
			MarkupElementValueType _AcctEntryBatchTotalAmountDebitCreditFlag = AcctEntryBatchTotalAmountDebitCreditFlag;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmAcctEntryDetailBatchSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryBatchMessageID", _AcctEntryBatchMessageID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryBatchPaymentInformation", _AcctEntryBatchPaymentInformation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryBatchNumberOfTransactions", _AcctEntryBatchNumberOfTransactions, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryBatchTotalAmount", _AcctEntryBatchTotalAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryBatchTotalAmountCurrencyCode", _AcctEntryBatchTotalAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryBatchTotalAmountDebitCreditFlag", _AcctEntryBatchTotalAmountDebitCreditFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
