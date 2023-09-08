//PROJECT NAME: Data
//CLASS NAME: PickItemByLocLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PickItemByLocLot : IPickItemByLocLot
	{
		readonly IApplicationDB appDB;
		
		public PickItemByLocLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PickItemByLocLotSp(
			string KitItem,
			string KitComponent,
			decimal? KitCompReqdQty,
			decimal? KitCompIssuedQty,
			string Whse,
			int? PrintSecondaryLocation = null)
		{
			ItemType _KitItem = KitItem;
			ItemType _KitComponent = KitComponent;
			QtyUnitType _KitCompReqdQty = KitCompReqdQty;
			QtyUnitType _KitCompIssuedQty = KitCompIssuedQty;
			WhseType _Whse = Whse;
			IntType _PrintSecondaryLocation = PrintSecondaryLocation;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PickItemByLocLotSp";
				
				appDB.AddCommandParameter(cmd, "KitItem", _KitItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KitComponent", _KitComponent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KitCompReqdQty", _KitCompReqdQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KitCompIssuedQty", _KitCompIssuedQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSecondaryLocation", _PrintSecondaryLocation, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
