//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranRemittance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmEntryDetailTranRemittance
	{
		int LoadESBBankStmEntryDetailTranRemittanceSp(string StmDocumentID,
		                                              string AcctLineNumber,
		                                              string AcctEntryLineNumber,
		                                              string EntryDetailTranLineNumber,
		                                              string EntryDetailTranRemitRemittanceID,
		                                              ref string InfoBar);
	}
	
	public class LoadESBBankStmEntryDetailTranRemittance : ILoadESBBankStmEntryDetailTranRemittance
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmEntryDetailTranRemittance(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmEntryDetailTranRemittanceSp(string StmDocumentID,
		                                                     string AcctLineNumber,
		                                                     string AcctEntryLineNumber,
		                                                     string EntryDetailTranLineNumber,
		                                                     string EntryDetailTranRemitRemittanceID,
		                                                     ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			MarkupElementValueType _EntryDetailTranRemitRemittanceID = EntryDetailTranRemitRemittanceID;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmEntryDetailTranRemittanceSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranRemitRemittanceID", _EntryDetailTranRemitRemittanceID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
