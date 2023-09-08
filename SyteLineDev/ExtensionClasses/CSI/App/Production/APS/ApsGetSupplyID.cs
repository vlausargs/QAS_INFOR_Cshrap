//PROJECT NAME: Production
//CLASS NAME: ApsGetSupplyID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetSupplyID : IApsGetSupplyID
	{
		readonly IApplicationDB appDB;
		
		public ApsGetSupplyID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsGetSupplyIDFn(
			string ApsOrderId)
		{
			ApsOrderType _ApsOrderId = ApsOrderId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetSupplyID](@ApsOrderId)";
				
				appDB.AddCommandParameter(cmd, "ApsOrderId", _ApsOrderId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
