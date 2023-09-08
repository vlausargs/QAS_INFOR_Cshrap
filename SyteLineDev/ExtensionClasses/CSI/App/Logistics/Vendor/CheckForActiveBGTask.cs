//PROJECT NAME: Logistics
//CLASS NAME: CheckForActiveBGTask.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckForActiveBGTask : ICheckForActiveBGTask
	{
		readonly IApplicationDB appDB;
		
		
		public CheckForActiveBGTask(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CheckForActiveBGTaskSp(string TaskName,
		string Infobar)
		{
			BGTaskNameType _TaskName = TaskName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckForActiveBGTaskSp";
				
				appDB.AddCommandParameter(cmd, "TaskName", _TaskName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
