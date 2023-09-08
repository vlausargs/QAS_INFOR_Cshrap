//PROJECT NAME: Production
//CLASS NAME: ApsIsOrderFrozen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsIsOrderFrozen : IApsIsOrderFrozen
	{
		readonly IApplicationDB appDB;
		
		public ApsIsOrderFrozen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsIsOrderFrozenFn(
			string POrder)
		{
			ApsOrderType _POrder = POrder;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsIsOrderFrozen](@POrder)";
				
				appDB.AddCommandParameter(cmd, "POrder", _POrder, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
