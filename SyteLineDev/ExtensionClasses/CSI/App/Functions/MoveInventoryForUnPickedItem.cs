//PROJECT NAME: Data
//CLASS NAME: MoveInventoryForUnPickedItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MoveInventoryForUnPickedItem : IMoveInventoryForUnPickedItem
	{
		readonly IApplicationDB appDB;
		
		public MoveInventoryForUnPickedItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MoveInventoryForUnPickedItemSp(
			decimal? ShipmentID,
			string ShipLoc,
			string Infobar)
		{
			ShipmentIDType _ShipmentID = ShipmentID;
			LocType _ShipLoc = ShipLoc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MoveInventoryForUnPickedItemSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentID", _ShipmentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipLoc", _ShipLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
