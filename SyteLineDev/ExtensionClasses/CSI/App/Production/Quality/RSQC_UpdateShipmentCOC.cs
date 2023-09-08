//PROJECT NAME: Production
//CLASS NAME: RSQC_UpdateShipmentCOC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_UpdateShipmentCOC : IRSQC_UpdateShipmentCOC
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_UpdateShipmentCOC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RSQC_UpdateShipmentCOCSp(decimal? ShipmentId,
		int? ShipmentLine,
		decimal? Qty,
		string Infobar)
		{
			ShipmentIDType _ShipmentId = ShipmentId;
			ShipmentLineType _ShipmentLine = ShipmentLine;
			QtyUnitType _Qty = Qty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_UpdateShipmentCOCSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentLine", _ShipmentLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
