//PROJECT NAME: Data
//CLASS NAME: JobOperationHoursAlert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobOperationHoursAlert : IJobOperationHoursAlert
	{
		readonly IApplicationDB appDB;
		
		public JobOperationHoursAlert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobOperationHoursAlertSp(
			string AJob,
			int? ASuffix,
			int? AOperNum,
			decimal? PlannedRunHrs,
			decimal? ActualRunHrs,
			string Infobar)
		{
			JobType _AJob = AJob;
			SuffixType _ASuffix = ASuffix;
			OperNumType _AOperNum = AOperNum;
			TotalHoursType _PlannedRunHrs = PlannedRunHrs;
			TotalHoursType _ActualRunHrs = ActualRunHrs;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobOperationHoursAlertSp";
				
				appDB.AddCommandParameter(cmd, "AJob", _AJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ASuffix", _ASuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AOperNum", _AOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannedRunHrs", _PlannedRunHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActualRunHrs", _ActualRunHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
