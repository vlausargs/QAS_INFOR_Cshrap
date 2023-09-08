//PROJECT NAME: Production
//CLASS NAME: JobOrdersCopyJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobOrdersCopyJob : IJobOrdersCopyJob
	{
		readonly IApplicationDB appDB;
		
		
		public JobOrdersCopyJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PJob,
		int? PSuffix,
		string Infobar) JobOrdersCopyJobSp(string PJob,
		int? PSuffix,
		string JobItem,
		string JobRevision,
		string Infobar)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			ItemType _JobItem = JobItem;
			RevisionType _JobRevision = JobRevision;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobOrdersCopyJobSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRevision", _JobRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PJob = _PJob;
				PSuffix = _PSuffix;
				Infobar = _Infobar;
				
				return (Severity, PJob, PSuffix, Infobar);
			}
		}
	}
}
