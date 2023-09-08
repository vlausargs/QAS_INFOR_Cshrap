//PROJECT NAME: Production
//CLASS NAME: ApsResyncRouteOpr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsResyncRouteOpr : IApsResyncRouteOpr
	{
		readonly IApplicationDB appDB;
		
		public ApsResyncRouteOpr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsResyncRouteOprSp(
			Guid? Partition)
		{
			GuidType _Partition = Partition;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsResyncRouteOprSp";
				
				appDB.AddCommandParameter(cmd, "Partition", _Partition, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
