//PROJECT NAME: Production
//CLASS NAME: ApsRouteEffectivityId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsRouteEffectivityId : IApsRouteEffectivityId
	{
		readonly IApplicationDB appDB;
		
		public ApsRouteEffectivityId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsRouteEffectivityIdFn(
			string PJob,
			int? PSuffix)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsRouteEffectivityId](@PJob, @PSuffix)";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
