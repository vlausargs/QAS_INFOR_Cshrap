//PROJECT NAME: Production
//CLASS NAME: RSQC_HomeAlerts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_HomeAlerts : IRSQC_HomeAlerts
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_HomeAlerts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PastDueSReceivers,
		int? PastDueOReceivers,
		int? PastDueRReceivers,
		int? PastDueJReceivers,
		int? PastDuePReceivers,
		int? PastDueMRR,
		int? PastDueCAR,
		int? PastDueTRR,
		int? PastDueCMR,
		int? PastDueCOC,
		int? PastDueTM,
		int? PastDueCM,
		int? PastDueCC,
		int? PastDueGages1,
		int? PastDueGages2) RSQC_HomeAlertsSp(int? PastDueSReceivers,
		int? PastDueOReceivers,
		int? PastDueRReceivers,
		int? PastDueJReceivers,
		int? PastDuePReceivers,
		int? PastDueMRR,
		int? PastDueCAR,
		int? PastDueTRR,
		int? PastDueCMR,
		int? PastDueCOC,
		int? PastDueTM,
		int? PastDueCM,
		int? PastDueCC,
		int? PastDueGages1,
		int? PastDueGages2)
		{
			NumberOfLinesType _PastDueSReceivers = PastDueSReceivers;
			NumberOfLinesType _PastDueOReceivers = PastDueOReceivers;
			NumberOfLinesType _PastDueRReceivers = PastDueRReceivers;
			NumberOfLinesType _PastDueJReceivers = PastDueJReceivers;
			NumberOfLinesType _PastDuePReceivers = PastDuePReceivers;
			NumberOfLinesType _PastDueMRR = PastDueMRR;
			NumberOfLinesType _PastDueCAR = PastDueCAR;
			NumberOfLinesType _PastDueTRR = PastDueTRR;
			NumberOfLinesType _PastDueCMR = PastDueCMR;
			NumberOfLinesType _PastDueCOC = PastDueCOC;
			NumberOfLinesType _PastDueTM = PastDueTM;
			NumberOfLinesType _PastDueCM = PastDueCM;
			NumberOfLinesType _PastDueCC = PastDueCC;
			NumberOfLinesType _PastDueGages1 = PastDueGages1;
			NumberOfLinesType _PastDueGages2 = PastDueGages2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_HomeAlertsSp";
				
				appDB.AddCommandParameter(cmd, "PastDueSReceivers", _PastDueSReceivers, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueOReceivers", _PastDueOReceivers, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueRReceivers", _PastDueRReceivers, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueJReceivers", _PastDueJReceivers, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDuePReceivers", _PastDuePReceivers, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueMRR", _PastDueMRR, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueCAR", _PastDueCAR, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueTRR", _PastDueTRR, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueCMR", _PastDueCMR, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueCOC", _PastDueCOC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueTM", _PastDueTM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueCM", _PastDueCM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueCC", _PastDueCC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueGages1", _PastDueGages1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueGages2", _PastDueGages2, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PastDueSReceivers = _PastDueSReceivers;
				PastDueOReceivers = _PastDueOReceivers;
				PastDueRReceivers = _PastDueRReceivers;
				PastDueJReceivers = _PastDueJReceivers;
				PastDuePReceivers = _PastDuePReceivers;
				PastDueMRR = _PastDueMRR;
				PastDueCAR = _PastDueCAR;
				PastDueTRR = _PastDueTRR;
				PastDueCMR = _PastDueCMR;
				PastDueCOC = _PastDueCOC;
				PastDueTM = _PastDueTM;
				PastDueCM = _PastDueCM;
				PastDueCC = _PastDueCC;
				PastDueGages1 = _PastDueGages1;
				PastDueGages2 = _PastDueGages2;
				
				return (Severity, PastDueSReceivers, PastDueOReceivers, PastDueRReceivers, PastDueJReceivers, PastDuePReceivers, PastDueMRR, PastDueCAR, PastDueTRR, PastDueCMR, PastDueCOC, PastDueTM, PastDueCM, PastDueCC, PastDueGages1, PastDueGages2);
			}
		}
	}
}
