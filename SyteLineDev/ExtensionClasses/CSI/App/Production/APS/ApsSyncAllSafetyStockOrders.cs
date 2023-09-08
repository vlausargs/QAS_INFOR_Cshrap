//PROJECT NAME: Production
//CLASS NAME: ApsSyncAllSafetyStockOrders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSyncAllSafetyStockOrders : IApsSyncAllSafetyStockOrders
	{
		readonly IApplicationDB appDB;
		
		public ApsSyncAllSafetyStockOrders(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSyncAllSafetyStockOrdersSp(
			int? AltNo)
		{
			ShortType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSyncAllSafetyStockOrdersSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
