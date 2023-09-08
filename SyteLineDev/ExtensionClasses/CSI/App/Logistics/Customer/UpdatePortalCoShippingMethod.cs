//PROJECT NAME: Logistics
//CLASS NAME: UpdatePortalCoShippingMethod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdatePortalCoShippingMethod : IUpdatePortalCoShippingMethod
	{
		readonly IApplicationDB appDB;
		
		
		public UpdatePortalCoShippingMethod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdatePortalCoShippingMethodSp(string CoNum,
		string CoShipMethod)
		{
			CoNumType _CoNum = CoNum;
			ShipMethodType _CoShipMethod = CoShipMethod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdatePortalCoShippingMethodSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoShipMethod", _CoShipMethod, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
