//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmEntryDetailTranRelatedDates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBankStmEntryDetailTranRelatedDates
	{
		int LoadESBBankStmEntryDetailTranRelatedDatesSp(string StmDocumentID,
		                                                string AcctLineNumber,
		                                                string AcctEntryLineNumber,
		                                                string EntryDetailTranLineNumber,
		                                                DateTime? EntryTranDatesAcceptanceDateTime,
		                                                DateTime? EntryTranDatesInterBankSettlementDateTime,
		                                                DateTime? EntryTranDatesStartDateTime,
		                                                DateTime? EntryTranDatesEndDateTime,
		                                                ref string InfoBar);
	}
	
	public class LoadESBBankStmEntryDetailTranRelatedDates : ILoadESBBankStmEntryDetailTranRelatedDates
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBankStmEntryDetailTranRelatedDates(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBankStmEntryDetailTranRelatedDatesSp(string StmDocumentID,
		                                                       string AcctLineNumber,
		                                                       string AcctEntryLineNumber,
		                                                       string EntryDetailTranLineNumber,
		                                                       DateTime? EntryTranDatesAcceptanceDateTime,
		                                                       DateTime? EntryTranDatesInterBankSettlementDateTime,
		                                                       DateTime? EntryTranDatesStartDateTime,
		                                                       DateTime? EntryTranDatesEndDateTime,
		                                                       ref string InfoBar)
		{
			MarkupElementValueType _StmDocumentID = StmDocumentID;
			MarkupElementValueType _AcctLineNumber = AcctLineNumber;
			MarkupElementValueType _AcctEntryLineNumber = AcctEntryLineNumber;
			MarkupElementValueType _EntryDetailTranLineNumber = EntryDetailTranLineNumber;
			DateTimeType _EntryTranDatesAcceptanceDateTime = EntryTranDatesAcceptanceDateTime;
			DateTimeType _EntryTranDatesInterBankSettlementDateTime = EntryTranDatesInterBankSettlementDateTime;
			DateTimeType _EntryTranDatesStartDateTime = EntryTranDatesStartDateTime;
			DateTimeType _EntryTranDatesEndDateTime = EntryTranDatesEndDateTime;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBankStmEntryDetailTranRelatedDatesSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLineNumber", _AcctLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEntryLineNumber", _AcctEntryLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryDetailTranLineNumber", _EntryDetailTranLineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryTranDatesAcceptanceDateTime", _EntryTranDatesAcceptanceDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryTranDatesInterBankSettlementDateTime", _EntryTranDatesInterBankSettlementDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryTranDatesStartDateTime", _EntryTranDatesStartDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EntryTranDatesEndDateTime", _EntryTranDatesEndDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
