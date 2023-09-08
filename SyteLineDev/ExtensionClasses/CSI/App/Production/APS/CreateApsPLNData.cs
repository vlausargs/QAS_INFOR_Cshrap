//PROJECT NAME: Production
//CLASS NAME: CreateApsPLNData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CreateApsPLNData : ICreateApsPLNData
	{
		readonly IApplicationDB appDB;
		
		public CreateApsPLNData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateApsPLNDataSp(
			string OrderId)
		{
			ApsMaxIDType _OrderId = OrderId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateApsPLNDataSp";
				
				appDB.AddCommandParameter(cmd, "OrderId", _OrderId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
