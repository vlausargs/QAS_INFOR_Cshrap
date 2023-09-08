//PROJECT NAME: Material
//CLASS NAME: Whse05RI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class Whse05RI : IWhse05RI
	{
		readonly IApplicationDB appDB;
		
		public Whse05RI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? ItemlifoQty,
			Guid? ItemlifoRowPointer,
			decimal? ItemlifoUnitCost,
			decimal? TcAmtExtCost,
			decimal? TcCprUnitCost,
			decimal? TcQttTotTrans,
			decimal? TcQtuQtyOnHand,
			decimal? TcTotCost,
			decimal? TcTotLocCost,
			decimal? TcTotWhseCost,
			decimal? TQtyMove,
			decimal? TQtyRem,
			int? NextRank,
			string Infobar) Whse05RISp(
			decimal? FileQtyOnHand,
			decimal? FileUnitCost,
			int? CurrencyPlaces,
			string ItemCostMethod,
			int? ItemLotTracked,
			decimal? ItemUnitCost,
			string ItemLocWhse,
			string ItemLocItem,
			string ItemLocLoc,
			string XItemlocWhse,
			string XItemlocLoc,
			string Lot,
			int? ItemSerialTracked,
			string ItemCostType,
			string ItemlocInvAcct,
			string ItemlocLbrAcct,
			string ItemlocFovhdAcct,
			string ItemlocVovhdAcct,
			string ItemlocOutAcct,
			decimal? ItemlifoQty,
			Guid? ItemlifoRowPointer,
			decimal? ItemlifoUnitCost,
			decimal? TcAmtExtCost,
			decimal? TcCprUnitCost,
			decimal? TcQttTotTrans,
			decimal? TcQtuQtyOnHand,
			decimal? TcTotCost,
			decimal? TcTotLocCost,
			decimal? TcTotWhseCost,
			decimal? TQtyMove,
			decimal? TQtyRem,
			int? NextRank,
			string Infobar,
			DateTime? Today = null,
			Guid? SessionId = null)
		{
			QtyUnitType _FileQtyOnHand = FileQtyOnHand;
			CostPrcType _FileUnitCost = FileUnitCost;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			CostMethodType _ItemCostMethod = ItemCostMethod;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			CostPrcType _ItemUnitCost = ItemUnitCost;
			WhseType _ItemLocWhse = ItemLocWhse;
			ItemType _ItemLocItem = ItemLocItem;
			LocType _ItemLocLoc = ItemLocLoc;
			WhseType _XItemlocWhse = XItemlocWhse;
			LocType _XItemlocLoc = XItemlocLoc;
			LotType _Lot = Lot;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;
			CostTypeType _ItemCostType = ItemCostType;
			AcctType _ItemlocInvAcct = ItemlocInvAcct;
			AcctType _ItemlocLbrAcct = ItemlocLbrAcct;
			AcctType _ItemlocFovhdAcct = ItemlocFovhdAcct;
			AcctType _ItemlocVovhdAcct = ItemlocVovhdAcct;
			AcctType _ItemlocOutAcct = ItemlocOutAcct;
			QtyUnitType _ItemlifoQty = ItemlifoQty;
			RowPointerType _ItemlifoRowPointer = ItemlifoRowPointer;
			CostPrcType _ItemlifoUnitCost = ItemlifoUnitCost;
			CostPrcType _TcAmtExtCost = TcAmtExtCost;
			CostPrcType _TcCprUnitCost = TcCprUnitCost;
			QtyUnitType _TcQttTotTrans = TcQttTotTrans;
			QtyUnitType _TcQtuQtyOnHand = TcQtuQtyOnHand;
			CostPrcType _TcTotCost = TcTotCost;
			CostPrcType _TcTotLocCost = TcTotLocCost;
			CostPrcType _TcTotWhseCost = TcTotWhseCost;
			QtyUnitType _TQtyMove = TQtyMove;
			QtyUnitType _TQtyRem = TQtyRem;
			ItemlocRankType _NextRank = NextRank;
			InfobarType _Infobar = Infobar;
			DateType _Today = Today;
			RowPointerType _SessionId = SessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Whse05RISp";
				
				appDB.AddCommandParameter(cmd, "FileQtyOnHand", _FileQtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FileUnitCost", _FileUnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemCostMethod", _ItemCostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemUnitCost", _ItemUnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLocWhse", _ItemLocWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLocItem", _ItemLocItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLocLoc", _ItemLocLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocWhse", _XItemlocWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XItemlocLoc", _XItemlocLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemCostType", _ItemCostType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocInvAcct", _ItemlocInvAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocLbrAcct", _ItemlocLbrAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocFovhdAcct", _ItemlocFovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocVovhdAcct", _ItemlocVovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlocOutAcct", _ItemlocOutAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemlifoQty", _ItemlifoQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemlifoRowPointer", _ItemlifoRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemlifoUnitCost", _ItemlifoUnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcAmtExtCost", _TcAmtExtCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcCprUnitCost", _TcCprUnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcQttTotTrans", _TcQttTotTrans, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcQtuQtyOnHand", _TcQtuQtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcTotCost", _TcTotCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcTotLocCost", _TcTotLocCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcTotWhseCost", _TcTotWhseCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQtyMove", _TQtyMove, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQtyRem", _TQtyRem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NextRank", _NextRank, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Today", _Today, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemlifoQty = _ItemlifoQty;
				ItemlifoRowPointer = _ItemlifoRowPointer;
				ItemlifoUnitCost = _ItemlifoUnitCost;
				TcAmtExtCost = _TcAmtExtCost;
				TcCprUnitCost = _TcCprUnitCost;
				TcQttTotTrans = _TcQttTotTrans;
				TcQtuQtyOnHand = _TcQtuQtyOnHand;
				TcTotCost = _TcTotCost;
				TcTotLocCost = _TcTotLocCost;
				TcTotWhseCost = _TcTotWhseCost;
				TQtyMove = _TQtyMove;
				TQtyRem = _TQtyRem;
				NextRank = _NextRank;
				Infobar = _Infobar;
				
				return (Severity, ItemlifoQty, ItemlifoRowPointer, ItemlifoUnitCost, TcAmtExtCost, TcCprUnitCost, TcQttTotTrans, TcQtuQtyOnHand, TcTotCost, TcTotLocCost, TcTotWhseCost, TQtyMove, TQtyRem, NextRank, Infobar);
			}
		}
	}
}
