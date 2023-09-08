//PROJECT NAME: Logistics
//CLASS NAME: ShipmentMerge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ShipmentMerge : IShipmentMerge
	{
		readonly IApplicationDB appDB;
		
		
		public ShipmentMerge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ShipmentMergeSp(decimal? OldShipment,
		decimal? NewShipment,
		string Infobar)
		{
			ShipmentIDType _OldShipment = OldShipment;
			ShipmentIDType _NewShipment = NewShipment;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShipmentMergeSp";
				
				appDB.AddCommandParameter(cmd, "OldShipment", _OldShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewShipment", _NewShipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
