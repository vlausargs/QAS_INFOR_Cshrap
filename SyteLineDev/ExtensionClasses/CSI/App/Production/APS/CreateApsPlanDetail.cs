//PROJECT NAME: Production
//CLASS NAME: CreateApsPlanDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class CreateApsPlanDetail : ICreateApsPlanDetail
	{
		readonly IApplicationDB appDB;
		
		public CreateApsPlanDetail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateApsPlanDetailSp(
			string OrderId)
		{
			ApsMaxIDType _OrderId = OrderId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateApsPlanDetailSp";
				
				appDB.AddCommandParameter(cmd, "OrderId", _OrderId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
