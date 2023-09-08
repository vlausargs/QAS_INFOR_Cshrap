//PROJECT NAME: Production
//CLASS NAME: ApsSyncRouteEffectivity.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncRouteEffectivity : IApsSyncRouteEffectivity
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncRouteEffectivity(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncRouteEffectivitySp(
			Guid? Partition)
		{
			GuidType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncRouteEffectivitySp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
