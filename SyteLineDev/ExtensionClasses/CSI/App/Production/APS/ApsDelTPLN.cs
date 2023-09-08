//PROJECT NAME: Production
//CLASS NAME: ApsDelTPLN.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsDelTPLN : IApsDelTPLN
	{
		readonly IApplicationDB appDB;
		
		public ApsDelTPLN(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsDelTPLNSp(
			string OrderId)
		{
			ApsMaxIDType _OrderId = OrderId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsDelTPLNSp";
				
				appDB.AddCommandParameter(cmd, "OrderId", _OrderId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
