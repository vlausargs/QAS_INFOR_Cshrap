//PROJECT NAME: Production
//CLASS NAME: CreateApsPlan.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CreateApsPlan : ICreateApsPlan
	{
		readonly IApplicationDB appDB;
		
		public CreateApsPlan(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateApsPlanSp(
			string OrderId)
		{
			ApsMaxIDType _OrderId = OrderId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateApsPlanSp";
				
				appDB.AddCommandParameter(cmd, "OrderId", _OrderId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
