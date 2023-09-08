//PROJECT NAME: Admin
//CLASS NAME: AppWorkflowUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class AppWorkflowUpdate : IAppWorkflowUpdate
	{
		IApplicationDB appDB;
		
		
		public AppWorkflowUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? AppWorkflowUpdateSp(Guid? EventHandlerRP,
		int? Active,
		string AppName,
		int? CreateTrigger)
		{
			RowPointerType _EventHandlerRP = EventHandlerRP;
			ListYesNoType _Active = Active;
			ApplicationNameType _AppName = AppName;
			ListYesNoType _CreateTrigger = CreateTrigger;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppWorkflowUpdateSp";
				
				appDB.AddCommandParameter(cmd, "EventHandlerRP", _EventHandlerRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Active", _Active, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppName", _AppName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateTrigger", _CreateTrigger, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
