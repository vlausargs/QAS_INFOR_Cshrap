//PROJECT NAME: Data
//CLASS NAME: DeleteApsPlanData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DeleteApsPlanData : IDeleteApsPlanData
	{
		readonly IApplicationDB appDB;
		
		public DeleteApsPlanData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DeleteApsPlanDataSp(
			string OrderId)
		{
			ApsMaxIDType _OrderId = OrderId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteApsPlanDataSp";
				
				appDB.AddCommandParameter(cmd, "OrderId", _OrderId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
