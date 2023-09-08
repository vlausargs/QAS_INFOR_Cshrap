//PROJECT NAME: Production
//CLASS NAME: SyncJobSubJobDueDates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class SyncJobSubJobDueDates : ISyncJobSubJobDueDates
	{
		readonly IApplicationDB appDB;
		
		
		public SyncJobSubJobDueDates(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SyncJobSubJobDueDatesSp(string PJob,
		int? PSuffix,
		int? PPerformSync,
		int? POverwriteDates,
		string Infobar)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			ListYesNoType _PPerformSync = PPerformSync;
			ListYesNoType _POverwriteDates = POverwriteDates;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SyncJobSubJobDueDatesSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPerformSync", _PPerformSync, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POverwriteDates", _POverwriteDates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
