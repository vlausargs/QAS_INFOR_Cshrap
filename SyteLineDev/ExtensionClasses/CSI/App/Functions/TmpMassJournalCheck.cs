//PROJECT NAME: Data
//CLASS NAME: TmpMassJournalCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TmpMassJournalCheck : ITmpMassJournalCheck
	{
		readonly IApplicationDB appDB;
		
		public TmpMassJournalCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TmpMassJournalCheckSp(
			Guid? StartingSessionId,
			int? StartingNestingLevel,
			string Infobar)
		{
			RowPointerType _StartingSessionId = StartingSessionId;
			IntType _StartingNestingLevel = StartingNestingLevel;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TmpMassJournalCheckSp";
				
				appDB.AddCommandParameter(cmd, "StartingSessionId", _StartingSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingNestingLevel", _StartingNestingLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
