//PROJECT NAME: Data
//CLASS NAME: EnableExternalWarehouse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EnableExternalWarehouse : IEnableExternalWarehouse
	{
		readonly IApplicationDB appDB;
		
		public EnableExternalWarehouse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EnableExternalWarehouseFn(
			string PWhse)
		{
			WhseType _PWhse = PWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EnableExternalWarehouse](@PWhse)";
				
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
