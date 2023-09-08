//PROJECT NAME: Production
//CLASS NAME: RSQC_DeleteJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class RSQC_DeleteJob : IRSQC_DeleteJob
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_DeleteJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_DeleteJobSp(string i_job,
		int? i_suffix,
		string Infobar)
		{
			JobType _i_job = i_job;
			SuffixType _i_suffix = i_suffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_DeleteJobSp";
				
				appDB.AddCommandParameter(cmd, "i_job", _i_job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_suffix", _i_suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
