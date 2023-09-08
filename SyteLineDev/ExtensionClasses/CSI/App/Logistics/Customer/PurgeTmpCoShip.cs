//PROJECT NAME: Logistics
//CLASS NAME: PurgeTmpCoShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PurgeTmpCoShip : IPurgeTmpCoShip
	{
		readonly IApplicationDB appDB;
		
		
		public PurgeTmpCoShip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PurgeTmpCoShipSp(Guid? ProcessId)
		{
			RowPointerType _ProcessId = ProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeTmpCoShipSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
