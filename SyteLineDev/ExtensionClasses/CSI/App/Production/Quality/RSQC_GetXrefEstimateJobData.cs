//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefEstimateJobData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefEstimateJobData : IRSQC_GetXrefEstimateJobData
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetXrefEstimateJobData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefEstimateJobDataSp(string i_job,
		string o_desc,
		string Infobar)
		{
			JobType _i_job = i_job;
			DescriptionType _o_desc = o_desc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetXrefEstimateJobDataSp";
				
				appDB.AddCommandParameter(cmd, "i_job", _i_job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_desc", _o_desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_desc = _o_desc;
				Infobar = _Infobar;
				
				return (Severity, o_desc, Infobar);
			}
		}
	}
}
