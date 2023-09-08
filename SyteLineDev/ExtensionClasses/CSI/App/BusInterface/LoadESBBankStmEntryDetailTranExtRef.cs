//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranExtRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmEntryDetailTranExtRef
	{
		int LoadESBBankStmEntryDetailTranExtRefSp(string StmDocumentID,
		                                          string AcctLineNumber,
		                                          string AcctEntryLineNumber,
		                                          string EntryDetailTranLineNumber,
		                                          string EntryDetailTranExtMessageID,
		                                          string EntryDetailTranExtPaymentInformationID,
		                                          string EntryDetailTranExtInstructionID,
		                                          string EntryDetailTranExtTransactionID,
		                                          string EntryDetailTranExtMandateID,
		                                          string EntryDetailTranExtCheckNumber,
		                                          ref string InfoBar);
	}
	
	public class LoadESBBankStmEntryDetailTranExtRef : ILoadESBBankStmEntryDetailTranExtRef
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmEntryDetailTranExtRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmEntryDetailTranExtRefSp(string StmDocumentID,
		                                                 string AcctLineNumber,
		                                                 string AcctEntryLineNumber,
		                                                 string EntryDetailTranLineNumber,
		                                                 string EntryDetailTranExtMessageID,
		                                                 string EntryDetailTranExtPaymentInformationID,
		                                                 string EntryDetailTranExtInstructionID,
		                                                 string EntryDetailTranExtTransactionID,
		                                                 string EntryDetailTranExtMandateID,
		                                                 string EntryDetailTranExtCheckNumber,
		                                                 ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _EntryDetailTranExtMessageID = EntryDetailTranExtMessageID;
			MarkupElementValueType _EntryDetailTranExtPaymentInformationID = EntryDetailTranExtPaymentInformationID;
			MarkupElementValueType _EntryDetailTranExtInstructionID = EntryDetailTranExtInstructionID;
			MarkupElementValueType _EntryDetailTranExtTransactionID = EntryDetailTranExtTransactionID;
			MarkupElementValueType _EntryDetailTranExtMandateID = EntryDetailTranExtMandateID;
			MarkupElementValueType _EntryDetailTranExtCheckNumber = EntryDetailTranExtCheckNumber;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmEntryDetailTranExtRefSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranExtMessageID", _EntryDetailTranExtMessageID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranExtPaymentInformationID", _EntryDetailTranExtPaymentInformationID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranExtInstructionID", _EntryDetailTranExtInstructionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranExtTransactionID", _EntryDetailTranExtTransactionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranExtMandateID", _EntryDetailTranExtMandateID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranExtCheckNumber", _EntryDetailTranExtCheckNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
