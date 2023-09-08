//PROJECT NAME: Data
//CLASS NAME: JobMaterialCostAlert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobMaterialCostAlert : IJobMaterialCostAlert
	{
		readonly IApplicationDB appDB;
		
		public JobMaterialCostAlert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobMaterialCostAlertSp(
			string AJob,
			int? ASuffix,
			decimal? CurrentItemCost,
			decimal? AcutalCost,
			string Infobar)
		{
			JobType _AJob = AJob;
			SuffixType _ASuffix = ASuffix;
			CostPrcType _CurrentItemCost = CurrentItemCost;
			CostPrcType _AcutalCost = AcutalCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobMaterialCostAlertSp";
				
				appDB.AddCommandParameter(cmd, "AJob", _AJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ASuffix", _ASuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentItemCost", _CurrentItemCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcutalCost", _AcutalCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
