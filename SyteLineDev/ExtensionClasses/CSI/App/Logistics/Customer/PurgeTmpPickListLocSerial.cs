//PROJECT NAME: Logistics
//CLASS NAME: PurgeTmpPickListLocSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PurgeTmpPickListLocSerial : IPurgeTmpPickListLocSerial
	{
		readonly IApplicationDB appDB;
		
		
		public PurgeTmpPickListLocSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PurgeTmpPickListLocSerialSp(Guid? processid)
		{
			RowPointerType _processid = processid;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeTmpPickListLocSerialSp";
				
				appDB.AddCommandParameter(cmd, "processid", _processid, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
