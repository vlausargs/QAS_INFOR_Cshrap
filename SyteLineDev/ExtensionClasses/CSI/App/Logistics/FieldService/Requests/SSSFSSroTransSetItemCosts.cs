//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroTransSetItemCosts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroTransSetItemCosts
	{
		int SSSFSSroTransSetItemCostsSp(string SRONum,
		                                int? SROLine,
		                                int? SROOper,
		                                string Item,
		                                string UM,
		                                string Whse,
		                                byte? ReimbMatl,
		                                byte? RtnToStock,
		                                string TransType,
		                                string Type,
		                                ref decimal? UnitCostConv,
		                                ref decimal? MatlCostConv,
		                                ref decimal? LaborCostConv,
		                                ref decimal? FovhdCostConv,
		                                ref decimal? VovhdCostConv,
		                                ref decimal? OutCostConv,
		                                ref string Infobar,
		                                decimal? QtyConv,
		                                string Loc,
		                                string Lot);
	}
	
	public class SSSFSSroTransSetItemCosts : ISSSFSSroTransSetItemCosts
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroTransSetItemCosts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSroTransSetItemCostsSp(string SRONum,
		                                       int? SROLine,
		                                       int? SROOper,
		                                       string Item,
		                                       string UM,
		                                       string Whse,
		                                       byte? ReimbMatl,
		                                       byte? RtnToStock,
		                                       string TransType,
		                                       string Type,
		                                       ref decimal? UnitCostConv,
		                                       ref decimal? MatlCostConv,
		                                       ref decimal? LaborCostConv,
		                                       ref decimal? FovhdCostConv,
		                                       ref decimal? VovhdCostConv,
		                                       ref decimal? OutCostConv,
		                                       ref string Infobar,
		                                       decimal? QtyConv,
		                                       string Loc,
		                                       string Lot)
		{
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			ItemType _Item = Item;
			UMType _UM = UM;
			WhseType _Whse = Whse;
			ListYesNoType _ReimbMatl = ReimbMatl;
			ListYesNoType _RtnToStock = RtnToStock;
			FSSROMatlTransTypeType _TransType = TransType;
			StringType _Type = Type;
			CostPrcType _UnitCostConv = UnitCostConv;
			CostPrcType _MatlCostConv = MatlCostConv;
			CostPrcType _LaborCostConv = LaborCostConv;
			CostPrcType _FovhdCostConv = FovhdCostConv;
			CostPrcType _VovhdCostConv = VovhdCostConv;
			CostPrcType _OutCostConv = OutCostConv;
			InfobarType _Infobar = Infobar;
			QtyUnitType _QtyConv = QtyConv;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroTransSetItemCostsSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReimbMatl", _ReimbMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RtnToStock", _RtnToStock, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCostConv", _UnitCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlCostConv", _MatlCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LaborCostConv", _LaborCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCostConv", _FovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCostConv", _VovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCostConv", _OutCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnitCostConv = _UnitCostConv;
				MatlCostConv = _MatlCostConv;
				LaborCostConv = _LaborCostConv;
				FovhdCostConv = _FovhdCostConv;
				VovhdCostConv = _VovhdCostConv;
				OutCostConv = _OutCostConv;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
