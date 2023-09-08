//PROJECT NAME: Logistics
//CLASS NAME: UpdateShipmentValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateShipmentValue : IUpdateShipmentValue
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateShipmentValue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateShipmentValueSp(decimal? Shipment,
		string Infobar)
		{
			ShipmentIDType _Shipment = Shipment;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateShipmentValueSp";
				
				appDB.AddCommandParameter(cmd, "Shipment", _Shipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
