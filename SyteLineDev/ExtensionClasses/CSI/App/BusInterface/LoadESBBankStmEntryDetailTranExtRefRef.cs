//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranExtRefRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmEntryDetailTranExtRefRef
	{
		int LoadESBBankStmEntryDetailTranExtRefRefSp(string StmDocumentID,
		                                             string AcctLineNumber,
		                                             string AcctEntryLineNumber,
		                                             string EntryDetailTranLineNumber,
		                                             string EntryDetailTranExtInstructionID,
		                                             string EntryDetailTranExtRefNameValue,
		                                             string EntryDetailTranExtRefName,
		                                             ref string InfoBar);
	}
	
	public class LoadESBBankStmEntryDetailTranExtRefRef : ILoadESBBankStmEntryDetailTranExtRefRef
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmEntryDetailTranExtRefRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmEntryDetailTranExtRefRefSp(string StmDocumentID,
		                                                    string AcctLineNumber,
		                                                    string AcctEntryLineNumber,
		                                                    string EntryDetailTranLineNumber,
		                                                    string EntryDetailTranExtInstructionID,
		                                                    string EntryDetailTranExtRefNameValue,
		                                                    string EntryDetailTranExtRefName,
		                                                    ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _EntryDetailTranExtInstructionID = EntryDetailTranExtInstructionID;
			MarkupElementValueType _EntryDetailTranExtRefNameValue = EntryDetailTranExtRefNameValue;
			MarkupElementValueType _EntryDetailTranExtRefName = EntryDetailTranExtRefName;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmEntryDetailTranExtRefRefSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranExtInstructionID", _EntryDetailTranExtInstructionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranExtRefNameValue", _EntryDetailTranExtRefNameValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranExtRefName", _EntryDetailTranExtRefName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
