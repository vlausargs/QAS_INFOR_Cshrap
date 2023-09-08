//PROJECT NAME: Production
//CLASS NAME: ApsPostWhsePlan.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPostWhsePlan : IApsPostWhsePlan
	{
		readonly IApplicationDB appDB;
		
		public ApsPostWhsePlan(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsPostWhsePlanSp(
			string OrderId)
		{
			ApsMaxIDType _OrderId = OrderId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsPostWhsePlanSp";
				
				appDB.AddCommandParameter(cmd, "OrderId", _OrderId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
