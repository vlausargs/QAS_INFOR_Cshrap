//PROJECT NAME: Production
//CLASS NAME: ApsGetDemandID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetDemandID : IApsGetDemandID
	{
		readonly IApplicationDB appDB;
		
		public ApsGetDemandID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsGetDemandIDFn(
			string ApsOrderId)
		{
			StringType _ApsOrderId = ApsOrderId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetDemandID](@ApsOrderId)";
				
				appDB.AddCommandParameter(cmd, "ApsOrderId", _ApsOrderId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
