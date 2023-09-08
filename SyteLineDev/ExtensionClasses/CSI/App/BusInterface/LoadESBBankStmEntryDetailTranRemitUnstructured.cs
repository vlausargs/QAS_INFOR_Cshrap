//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranRemitUnstructured.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmEntryDetailTranRemitUnstructured
	{
		int LoadESBBankStmEntryDetailTranRemitUnstructuredSp(string StmDocumentID,
		                                                     string AcctLineNumber,
		                                                     string AcctEntryLineNumber,
		                                                     string EntryDetailTranLineNumber,
		                                                     string EntryDetailTranRemitRemittanceID,
		                                                     string EntryDetailTranRemitUnstructuredRemittanceText,
		                                                     ref string InfoBar);
	}
	
	public class LoadESBBankStmEntryDetailTranRemitUnstructured : ILoadESBBankStmEntryDetailTranRemitUnstructured
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmEntryDetailTranRemitUnstructured(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmEntryDetailTranRemitUnstructuredSp(string StmDocumentID,
		                                                            string AcctLineNumber,
		                                                            string AcctEntryLineNumber,
		                                                            string EntryDetailTranLineNumber,
		                                                            string EntryDetailTranRemitRemittanceID,
		                                                            string EntryDetailTranRemitUnstructuredRemittanceText,
		                                                            ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _EntryDetailTranRemitRemittanceID = EntryDetailTranRemitRemittanceID;
			StringType _EntryDetailTranRemitUnstructuredRemittanceText = EntryDetailTranRemitUnstructuredRemittanceText;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmEntryDetailTranRemitUnstructuredSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranRemitRemittanceID", _EntryDetailTranRemitRemittanceID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranRemitUnstructuredRemittanceText", _EntryDetailTranRemitUnstructuredRemittanceText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
