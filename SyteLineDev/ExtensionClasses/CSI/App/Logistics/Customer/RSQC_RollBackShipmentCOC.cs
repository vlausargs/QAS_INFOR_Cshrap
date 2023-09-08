//PROJECT NAME: Logistics
//CLASS NAME: RSQC_RollBackShipmentCOC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RSQC_RollBackShipmentCOC : IRSQC_RollBackShipmentCOC
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_RollBackShipmentCOC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_RollBackShipmentCOCSp(decimal? ShipmentId,
		string Infobar)
		{
			ShipmentIDType _ShipmentId = ShipmentId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_RollBackShipmentCOCSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
