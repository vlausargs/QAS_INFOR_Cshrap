//PROJECT NAME: Production
//CLASS NAME: ApsIsDemandReady.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsIsDemandReady : IApsIsDemandReady
	{
		readonly IApplicationDB appDB;
		
		public ApsIsDemandReady(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsIsDemandReadyFn(
			string PDemandID)
		{
			ApsOrderType _PDemandID = PDemandID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsIsDemandReady](@PDemandID)";
				
				appDB.AddCommandParameter(cmd, "PDemandID", _PDemandID, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
