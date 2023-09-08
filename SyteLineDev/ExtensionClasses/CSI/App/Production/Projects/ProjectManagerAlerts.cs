//PROJECT NAME: CSIProjects
//CLASS NAME: ProjectManagerAlerts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjectManagerAlerts
	{
		int ProjectManagerAlertsSp(ref int? PastDueProjects,
		                           ref int? PastDueProjectTasks,
		                           ref int? EstimatesToExpire,
		                           ref int? NumberOfUserTasks,
		                           ref int? NumberOfEventMessages);
	}
	
	public class ProjectManagerAlerts : IProjectManagerAlerts
	{
		readonly IApplicationDB appDB;
		
		public ProjectManagerAlerts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjectManagerAlertsSp(ref int? PastDueProjects,
		                                  ref int? PastDueProjectTasks,
		                                  ref int? EstimatesToExpire,
		                                  ref int? NumberOfUserTasks,
		                                  ref int? NumberOfEventMessages)
		{
			NumberOfLinesType _PastDueProjects = PastDueProjects;
			NumberOfLinesType _PastDueProjectTasks = PastDueProjectTasks;
			NumberOfLinesType _EstimatesToExpire = EstimatesToExpire;
			NumberOfLinesType _NumberOfUserTasks = NumberOfUserTasks;
			NumberOfLinesType _NumberOfEventMessages = NumberOfEventMessages;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjectManagerAlertsSp";
				
				appDB.AddCommandParameter(cmd, "PastDueProjects", _PastDueProjects, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueProjectTasks", _PastDueProjectTasks, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EstimatesToExpire", _EstimatesToExpire, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumberOfUserTasks", _NumberOfUserTasks, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumberOfEventMessages", _NumberOfEventMessages, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PastDueProjects = _PastDueProjects;
				PastDueProjectTasks = _PastDueProjectTasks;
				EstimatesToExpire = _EstimatesToExpire;
				NumberOfUserTasks = _NumberOfUserTasks;
				NumberOfEventMessages = _NumberOfEventMessages;
				
				return Severity;
			}
		}
	}
}
