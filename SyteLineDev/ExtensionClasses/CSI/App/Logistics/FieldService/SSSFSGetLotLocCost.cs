//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSGetLotLocCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetLotLocCost
	{
		int SSSFSGetLotLocCostSp(string Whse,
		                         string Item,
		                         string Lot,
		                         string Loc,
		                         string UM,
		                         ref decimal? UnitCostConv,
		                         ref decimal? MatlCostConv,
		                         ref decimal? LbrCostConv,
		                         ref decimal? FovCostConv,
		                         ref decimal? VovCostConv,
		                         ref decimal? OutCostConv,
		                         ref string Infobar);
	}
	
	public class SSSFSGetLotLocCost : ISSSFSGetLotLocCost
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetLotLocCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSGetLotLocCostSp(string Whse,
		                                string Item,
		                                string Lot,
		                                string Loc,
		                                string UM,
		                                ref decimal? UnitCostConv,
		                                ref decimal? MatlCostConv,
		                                ref decimal? LbrCostConv,
		                                ref decimal? FovCostConv,
		                                ref decimal? VovCostConv,
		                                ref decimal? OutCostConv,
		                                ref string Infobar)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LotType _Lot = Lot;
			LocType _Loc = Loc;
			UMType _UM = UM;
			CostPrcType _UnitCostConv = UnitCostConv;
			CostPrcType _MatlCostConv = MatlCostConv;
			CostPrcType _LbrCostConv = LbrCostConv;
			CostPrcType _FovCostConv = FovCostConv;
			CostPrcType _VovCostConv = VovCostConv;
			CostPrcType _OutCostConv = OutCostConv;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetLotLocCostSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCostConv", _UnitCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlCostConv", _MatlCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCostConv", _LbrCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovCostConv", _FovCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovCostConv", _VovCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCostConv", _OutCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnitCostConv = _UnitCostConv;
				MatlCostConv = _MatlCostConv;
				LbrCostConv = _LbrCostConv;
				FovCostConv = _FovCostConv;
				VovCostConv = _VovCostConv;
				OutCostConv = _OutCostConv;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
