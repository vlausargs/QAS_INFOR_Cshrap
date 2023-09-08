//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobCostVariance2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobCostVariance2 : IRpt_JobCostVariance2
	{
		readonly IApplicationDB appDB;
		
		public Rpt_JobCostVariance2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_JobCostVariance2Sp(
			string JobBuffer,
			string JobType,
			string JobJob,
			int? JobSuffix,
			string JobitemItem,
			decimal? JobitemQtyReleased,
			Guid? JobRowPointer,
			DateTime? AsOfDate = null)
		{
			InfobarType _JobBuffer = JobBuffer;
			InfobarType _JobType = JobType;
			JobType _JobJob = JobJob;
			SuffixType _JobSuffix = JobSuffix;
			ItemType _JobitemItem = JobitemItem;
			QtyUnitType _JobitemQtyReleased = JobitemQtyReleased;
			RowPointerType _JobRowPointer = JobRowPointer;
			DateType _AsOfDate = AsOfDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JobCostVariance2Sp";
				
				appDB.AddCommandParameter(cmd, "JobBuffer", _JobBuffer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobJob", _JobJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobitemItem", _JobitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobitemQtyReleased", _JobitemQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRowPointer", _JobRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
