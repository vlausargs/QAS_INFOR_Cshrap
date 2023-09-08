//PROJECT NAME: Admin
//CLASS NAME: AppWorkflowCreateEventTrigger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class AppWorkflowCreateEventTrigger : IAppWorkflowCreateEventTrigger
	{
		readonly IApplicationDB appDB;
		
		public AppWorkflowCreateEventTrigger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) AppWorkflowCreateEventTriggerSp(
			Guid? EventHandlerRowPointer,
			string Infobar)
		{
			RowPointerType _EventHandlerRowPointer = EventHandlerRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppWorkflowCreateEventTriggerSp";
				
				appDB.AddCommandParameter(cmd, "EventHandlerRowPointer", _EventHandlerRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
