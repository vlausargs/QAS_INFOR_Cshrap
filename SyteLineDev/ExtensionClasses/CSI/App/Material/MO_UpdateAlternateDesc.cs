//PROJECT NAME: Material
//CLASS NAME: MO_UpdateAlternateDesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MO_UpdateAlternateDesc : IMO_UpdateAlternateDesc
	{
		readonly IApplicationDB appDB;
		
		
		public MO_UpdateAlternateDesc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MO_UpdateAlternateDescSp(string Job,
		int? JobSuffix,
		string AlternateDescription = null)
		{
			JobType _Job = Job;
			SuffixType _JobSuffix = JobSuffix;
			DescriptionType _AlternateDescription = AlternateDescription;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_UpdateAlternateDescSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateDescription", _AlternateDescription, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
