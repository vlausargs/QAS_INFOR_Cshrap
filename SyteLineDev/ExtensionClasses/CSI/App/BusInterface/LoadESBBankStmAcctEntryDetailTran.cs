//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmAcctEntryDetailTran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmAcctEntryDetailTran
	{
		int LoadESBBankStmAcctEntryDetailTranSp(string StmDocumentID,
		                                        string AcctLineNumber,
		                                        string AcctEntryLineNumber,
		                                        string EntryDetailTranLineNumber,
		                                        decimal? EntryDetalTranTotalAmount,
		                                        string EntryDetalTranTotalAmountCurrencyCode,
		                                        string EntryDetailTranDebitCreditFlag,
		                                        string EntryDetailTranPaymentPurposeCode,
		                                        ref string InfoBar);
	}
	
	public class LoadESBBankStmAcctEntryDetailTran : ILoadESBBankStmAcctEntryDetailTran
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmAcctEntryDetailTran(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmAcctEntryDetailTranSp(string StmDocumentID,
		                                               string AcctLineNumber,
		                                               string AcctEntryLineNumber,
		                                               string EntryDetailTranLineNumber,
		                                               decimal? EntryDetalTranTotalAmount,
		                                               string EntryDetalTranTotalAmountCurrencyCode,
		                                               string EntryDetailTranDebitCreditFlag,
		                                               string EntryDetailTranPaymentPurposeCode,
		                                               ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			DecimalType _EntryDetalTranTotalAmount = EntryDetalTranTotalAmount;
			MarkupElementValueType _EntryDetalTranTotalAmountCurrencyCode = EntryDetalTranTotalAmountCurrencyCode;
			MarkupElementValueType _EntryDetailTranDebitCreditFlag = EntryDetailTranDebitCreditFlag;
			MarkupElementValueType _EntryDetailTranPaymentPurposeCode = EntryDetailTranPaymentPurposeCode;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmAcctEntryDetailTranSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetalTranTotalAmount", _EntryDetalTranTotalAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetalTranTotalAmountCurrencyCode", _EntryDetalTranTotalAmountCurrencyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranDebitCreditFlag", _EntryDetailTranDebitCreditFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranPaymentPurposeCode", _EntryDetailTranPaymentPurposeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
