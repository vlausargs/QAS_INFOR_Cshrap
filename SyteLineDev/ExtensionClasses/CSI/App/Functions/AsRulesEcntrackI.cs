//PROJECT NAME: Data
//CLASS NAME: AsRulesEcntrackI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class AsRulesEcntrackI : IAsRulesEcntrackI
	{
		readonly IApplicationDB appDB;
		
		public AsRulesEcntrackI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? EcnTrack,
			string Infobar) AsRulesEcntrackISp(
			string Job,
			int? JobSuffix,
			string JobType,
			int? EcnTrack,
			string Infobar)
		{
			JobType _Job = Job;
			SuffixType _JobSuffix = JobSuffix;
			JobTypeType _JobType = JobType;
			ListYesNoType _EcnTrack = EcnTrack;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AsRulesEcntrackISp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcnTrack", _EcnTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EcnTrack = _EcnTrack;
				Infobar = _Infobar;
				
				return (Severity, EcnTrack, Infobar);
			}
		}
	}
}
