//PROJECT NAME: Production
//CLASS NAME: ValidateEcnValForJobOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ValidateEcnValForJobOper : IValidateEcnValForJobOper
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateEcnValForJobOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ValidateEcnValForJobOperSp(string Job,
		int? Suffix,
		string JobType,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobTypeType _JobType = JobType;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateEcnValForJobOperSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
