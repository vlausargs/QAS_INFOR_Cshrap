//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetItemConvQtyOnHand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetItemConvQtyOnHand
	{
		int FTSLGetItemConvQtyOnHandSp(string Whse,
		                               string Item,
		                               string Loc,
		                               string Lot,
		                               string UM,
		                               ref decimal? QtyOnHand,
		                               ref decimal? QtyReserved,
		                               ref string LocType,
		                               ref string Infobar);
	}
	
	public class FTSLGetItemConvQtyOnHand : IFTSLGetItemConvQtyOnHand
	{
		readonly IApplicationDB appDB;
		
		public FTSLGetItemConvQtyOnHand(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLGetItemConvQtyOnHandSp(string Whse,
		                                      string Item,
		                                      string Loc,
		                                      string Lot,
		                                      string UM,
		                                      ref decimal? QtyOnHand,
		                                      ref decimal? QtyReserved,
		                                      ref string LocType,
		                                      ref string Infobar)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			UMType _UM = UM;
			QtyUnitType _QtyOnHand = QtyOnHand;
			QtyUnitType _QtyReserved = QtyReserved;
			LocTypeType _LocType = LocType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLGetItemConvQtyOnHandSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyReserved", _QtyReserved, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LocType", _LocType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyOnHand = _QtyOnHand;
				QtyReserved = _QtyReserved;
				LocType = _LocType;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
