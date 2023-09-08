//PROJECT NAME: Production
//CLASS NAME: CreateApsCPLNData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CreateApsCPLNData : ICreateApsCPLNData
	{
		readonly IApplicationDB appDB;
		
		public CreateApsCPLNData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateApsCPLNDataSp(
			string OrderId)
		{
			ApsMaxIDType _OrderId = OrderId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateApsCPLNDataSp";
				
				appDB.AddCommandParameter(cmd, "OrderId", _OrderId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
