//PROJECT NAME: Data
//CLASS NAME: JobOverProductionAlert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobOverProductionAlert : IJobOverProductionAlert
	{
		readonly IApplicationDB appDB;
		
		public JobOverProductionAlert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobOverProductionAlertSp(
			string AJob,
			int? ASuffix,
			decimal? AQtyReleased,
			decimal? AQtyComplete,
			string Infobar)
		{
			JobType _AJob = AJob;
			SuffixType _ASuffix = ASuffix;
			QtyUnitType _AQtyReleased = AQtyReleased;
			QtyUnitType _AQtyComplete = AQtyComplete;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobOverProductionAlertSp";
				
				appDB.AddCommandParameter(cmd, "AJob", _AJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ASuffix", _ASuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AQtyReleased", _AQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AQtyComplete", _AQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
