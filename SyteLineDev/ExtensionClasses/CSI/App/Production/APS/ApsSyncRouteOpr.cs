//PROJECT NAME: Production
//CLASS NAME: ApsSyncRouteOpr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncRouteOpr : IApsSyncRouteOpr
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncRouteOpr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncRouteOprSp(
			Guid? Partition)
		{
			GuidType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncRouteOprSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
