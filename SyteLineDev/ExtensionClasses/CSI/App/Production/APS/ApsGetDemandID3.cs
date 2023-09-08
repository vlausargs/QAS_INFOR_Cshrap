//PROJECT NAME: Production
//CLASS NAME: ApsGetDemandID3.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetDemandID3 : IApsGetDemandID3
	{
		readonly IApplicationDB appDB;
		
		public ApsGetDemandID3(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsGetDemandID3Fn(
			string ApsOrderId)
		{
			StringType _ApsOrderId = ApsOrderId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetDemandID3](@ApsOrderId)";
				
				appDB.AddCommandParameter(cmd, "ApsOrderId", _ApsOrderId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
