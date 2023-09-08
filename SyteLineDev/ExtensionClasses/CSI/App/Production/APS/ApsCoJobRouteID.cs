//PROJECT NAME: Production
//CLASS NAME: ApsCoJobRouteID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCoJobRouteID : IApsCoJobRouteID
	{
		readonly IApplicationDB appDB;
		
		public ApsCoJobRouteID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsCoJobRouteIDFn(
			string PJob)
		{
			JobType _PJob = PJob;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCoJobRouteID](@PJob)";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
