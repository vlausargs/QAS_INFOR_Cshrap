//PROJECT NAME: Production
//CLASS NAME: ApsSyncBomEffectivity.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncBomEffectivity : IApsSyncBomEffectivity
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncBomEffectivity(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncBomEffectivitySp(
			Guid? Partition)
		{
			GuidType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncBomEffectivitySp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
