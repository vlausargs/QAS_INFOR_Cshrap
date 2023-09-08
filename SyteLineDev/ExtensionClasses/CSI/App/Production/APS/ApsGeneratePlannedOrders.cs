//PROJECT NAME: Production
//CLASS NAME: ApsGeneratePlannedOrders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGeneratePlannedOrders : IApsGeneratePlannedOrders
	{
		readonly IApplicationDB appDB;
		
		public ApsGeneratePlannedOrders(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGeneratePlannedOrdersSp(
			int? AltNo)
		{
			ShortType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGeneratePlannedOrdersSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
