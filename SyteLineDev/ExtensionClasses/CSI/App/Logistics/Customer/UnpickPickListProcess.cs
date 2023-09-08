//PROJECT NAME: Logistics
//CLASS NAME: UnpickPickListProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UnpickPickListProcess : IUnpickPickListProcess
	{
		readonly IApplicationDB appDB;
		
		
		public UnpickPickListProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) UnpickPickListProcessSp(Guid? processid,
		string InfoBar)
		{
			RowPointerType _processid = processid;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UnpickPickListProcessSp";
				
				appDB.AddCommandParameter(cmd, "processid", _processid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
