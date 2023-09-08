//PROJECT NAME: Production
//CLASS NAME: UpdatePsitemHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class UpdatePsitemHeader : IUpdatePsitemHeader
	{
		readonly IApplicationDB appDB;
		
		
		public UpdatePsitemHeader(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdatePsitemHeaderSp(string Job,
		string JobWhse,
		string JobRevision)
		{
			JobType _Job = Job;
			WhseType _JobWhse = JobWhse;
			RevisionType _JobRevision = JobRevision;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdatePsitemHeaderSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobWhse", _JobWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRevision", _JobRevision, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
