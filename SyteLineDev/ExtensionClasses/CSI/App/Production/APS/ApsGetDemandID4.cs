//PROJECT NAME: Production
//CLASS NAME: ApsGetDemandID4.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetDemandID4 : IApsGetDemandID4
	{
		readonly IApplicationDB appDB;
		
		public ApsGetDemandID4(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsGetDemandID4Fn(
			string ApsOrderId,
			string ApsOrderTable)
		{
			StringType _ApsOrderId = ApsOrderId;
			StringType _ApsOrderTable = ApsOrderTable;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetDemandID4](@ApsOrderId, @ApsOrderTable)";
				
				appDB.AddCommandParameter(cmd, "ApsOrderId", _ApsOrderId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsOrderTable", _ApsOrderTable, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
