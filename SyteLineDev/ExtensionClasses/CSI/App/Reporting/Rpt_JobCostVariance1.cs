//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobCostVariance1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobCostVariance1 : IRpt_JobCostVariance1
	{
		readonly IApplicationDB appDB;
		
		public Rpt_JobCostVariance1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_JobCostVariance1Sp(
			string JobType,
			string Job,
			int? Suffix,
			DateTime? AsOfDate = null)
		{
			InfobarType _JobType = JobType;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			DateType _AsOfDate = AsOfDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JobCostVariance1Sp";
				
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
