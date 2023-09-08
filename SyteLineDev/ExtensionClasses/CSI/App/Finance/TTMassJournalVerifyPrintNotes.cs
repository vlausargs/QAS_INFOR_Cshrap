//PROJECT NAME: Finance
//CLASS NAME: TTMassJournalVerifyPrintNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class TTMassJournalVerifyPrintNotes : ITTMassJournalVerifyPrintNotes
	{
		readonly IApplicationDB appDB;
		
		
		public TTMassJournalVerifyPrintNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CompleteFlag,
		string Infobar) TTMassJournalVerifyPrintNotesSp(string PSessionID,
		int? CompleteFlag,
		string Infobar)
		{
			BGTaskParmsType _PSessionID = PSessionID;
			FlagNyType _CompleteFlag = CompleteFlag;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TTMassJournalVerifyPrintNotesSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompleteFlag", _CompleteFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CompleteFlag = _CompleteFlag;
				Infobar = _Infobar;
				
				return (Severity, CompleteFlag, Infobar);
			}
		}
	}
}
