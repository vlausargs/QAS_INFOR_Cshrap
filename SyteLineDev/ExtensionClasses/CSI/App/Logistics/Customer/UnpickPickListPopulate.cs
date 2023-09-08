//PROJECT NAME: Logistics
//CLASS NAME: UnpickPickListPopulate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UnpickPickListPopulate : IUnpickPickListPopulate
	{
		readonly IApplicationDB appDB;
		
		
		public UnpickPickListPopulate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) UnpickPickListPopulateSp(decimal? picklistid,
		Guid? processid,
		string InfoBar)
		{
			PickListIDType _picklistid = picklistid;
			RowPointerType _processid = processid;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UnpickPickListPopulateSp";
				
				appDB.AddCommandParameter(cmd, "picklistid", _picklistid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "processid", _processid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
