//PROJECT NAME: Logistics
//CLASS NAME: UnpackInventory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UnpackInventory : IUnpackInventory
	{
		readonly IApplicationDB appDB;
		
		
		public UnpackInventory(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UnpackInventorySp(Guid? ProcessId,
		int? ReturnToPickList,
		int? ReduceQuantityOnly,
		string Infobar,
		int? DeleteEmptyShipment = 0)
		{
			RowPointerType _ProcessId = ProcessId;
			ListYesNoType _ReturnToPickList = ReturnToPickList;
			ListYesNoType _ReduceQuantityOnly = ReduceQuantityOnly;
			InfobarType _Infobar = Infobar;
			ListYesNoType _DeleteEmptyShipment = DeleteEmptyShipment;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UnpackInventorySp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReturnToPickList", _ReturnToPickList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReduceQuantityOnly", _ReduceQuantityOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeleteEmptyShipment", _DeleteEmptyShipment, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
