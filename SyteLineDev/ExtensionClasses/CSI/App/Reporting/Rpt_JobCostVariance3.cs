//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobCostVariance3.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobCostVariance3 : IRpt_JobCostVariance3
	{
		readonly IApplicationDB appDB;
		
		public Rpt_JobCostVariance3(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_JobCostVariance3Sp(
			string JobBuffer,
			string JobType,
			string JobJob,
			int? JobSuffix,
			string JobitemItem,
			decimal? JobitemQtyReleased,
			DateTime? AsOfDate = null)
		{
			InfobarType _JobBuffer = JobBuffer;
			InfobarType _JobType = JobType;
			JobType _JobJob = JobJob;
			SuffixType _JobSuffix = JobSuffix;
			ItemType _JobitemItem = JobitemItem;
			QtyUnitType _JobitemQtyReleased = JobitemQtyReleased;
			DateType _AsOfDate = AsOfDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JobCostVariance3Sp";
				
				appDB.AddCommandParameter(cmd, "JobBuffer", _JobBuffer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobJob", _JobJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobitemItem", _JobitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobitemQtyReleased", _JobitemQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
