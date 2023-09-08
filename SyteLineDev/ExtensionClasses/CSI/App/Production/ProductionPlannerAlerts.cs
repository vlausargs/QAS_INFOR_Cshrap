//PROJECT NAME: Production
//CLASS NAME: ProductionPlannerAlerts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ProductionPlannerAlerts : IProductionPlannerAlerts
	{
		readonly IApplicationDB appDB;
		
		
		public ProductionPlannerAlerts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PastDueJobs,
		int? ProductionDueJobs,
		int? NumberOfUserTasks,
		int? NumberOfEventMessages) ProductionPlannerAlertsSp(int? PastDueJobs,
		int? ProductionDueJobs,
		int? NumberOfUserTasks,
		int? NumberOfEventMessages)
		{
			NumberOfLinesType _PastDueJobs = PastDueJobs;
			NumberOfLinesType _ProductionDueJobs = ProductionDueJobs;
			NumberOfLinesType _NumberOfUserTasks = NumberOfUserTasks;
			NumberOfLinesType _NumberOfEventMessages = NumberOfEventMessages;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProductionPlannerAlertsSp";
				
				appDB.AddCommandParameter(cmd, "PastDueJobs", _PastDueJobs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProductionDueJobs", _ProductionDueJobs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumberOfUserTasks", _NumberOfUserTasks, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumberOfEventMessages", _NumberOfEventMessages, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PastDueJobs = _PastDueJobs;
				ProductionDueJobs = _ProductionDueJobs;
				NumberOfUserTasks = _NumberOfUserTasks;
				NumberOfEventMessages = _NumberOfEventMessages;
				
				return (Severity, PastDueJobs, ProductionDueJobs, NumberOfUserTasks, NumberOfEventMessages);
			}
		}
	}
}
