//PROJECT NAME: Production
//CLASS NAME: ApsCoJobBatProdDefID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCoJobBatProdDefID : IApsCoJobBatProdDefID
	{
		readonly IApplicationDB appDB;
		
		public ApsCoJobBatProdDefID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsCoJobBatProdDefIDFn(
			string PJob)
		{
			JobType _PJob = PJob;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCoJobBatProdDefID](@PJob)";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
