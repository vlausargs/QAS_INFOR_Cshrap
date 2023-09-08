//PROJECT NAME: CSIMaterial
//CLASS NAME: MisReceiptItemWhseGetCostValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IMisReceiptItemWhseGetCostValues
	{
		(int? ReturnCode, decimal? MatlCost, decimal? LbrCost, decimal? FovhdCost, decimal? VovhdCost, decimal? OutCost, decimal? UnitCost, string Infobar, decimal? MatlCostConv, decimal? LbrCostConv, decimal? FovhdCostConv, decimal? VovhdCostConv, decimal? OutCostConv, decimal? UnitCostConv) MisReceiptItemWhseGetCostValuesSp(string CurWhse,
		string Item,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? UnitCost,
		string Infobar,
		string UM = null,
		decimal? MatlCostConv = null,
		decimal? LbrCostConv = null,
		decimal? FovhdCostConv = null,
		decimal? VovhdCostConv = null,
		decimal? OutCostConv = null,
		decimal? UnitCostConv = null);
	}
	
	public class MisReceiptItemWhseGetCostValues : IMisReceiptItemWhseGetCostValues
	{
		readonly IApplicationDB appDB;
		
		public MisReceiptItemWhseGetCostValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? MatlCost, decimal? LbrCost, decimal? FovhdCost, decimal? VovhdCost, decimal? OutCost, decimal? UnitCost, string Infobar, decimal? MatlCostConv, decimal? LbrCostConv, decimal? FovhdCostConv, decimal? VovhdCostConv, decimal? OutCostConv, decimal? UnitCostConv) MisReceiptItemWhseGetCostValuesSp(string CurWhse,
		string Item,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? UnitCost,
		string Infobar,
		string UM = null,
		decimal? MatlCostConv = null,
		decimal? LbrCostConv = null,
		decimal? FovhdCostConv = null,
		decimal? VovhdCostConv = null,
		decimal? OutCostConv = null,
		decimal? UnitCostConv = null)
		{
			WhseType _CurWhse = CurWhse;
			ItemType _Item = Item;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			CostPrcType _UnitCost = UnitCost;
			InfobarType _Infobar = Infobar;
			UMType _UM = UM;
			CostPrcType _MatlCostConv = MatlCostConv;
			CostPrcType _LbrCostConv = LbrCostConv;
			CostPrcType _FovhdCostConv = FovhdCostConv;
			CostPrcType _VovhdCostConv = VovhdCostConv;
			CostPrcType _OutCostConv = OutCostConv;
			CostPrcType _UnitCostConv = UnitCostConv;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MisReceiptItemWhseGetCostValuesSp";
				
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCostConv", _MatlCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCostConv", _LbrCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCostConv", _FovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCostConv", _VovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCostConv", _OutCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCostConv", _UnitCostConv, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MatlCost = _MatlCost;
				LbrCost = _LbrCost;
				FovhdCost = _FovhdCost;
				VovhdCost = _VovhdCost;
				OutCost = _OutCost;
				UnitCost = _UnitCost;
				Infobar = _Infobar;
				MatlCostConv = _MatlCostConv;
				LbrCostConv = _LbrCostConv;
				FovhdCostConv = _FovhdCostConv;
				VovhdCostConv = _VovhdCostConv;
				OutCostConv = _OutCostConv;
				UnitCostConv = _UnitCostConv;
				
				return (Severity, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, UnitCost, Infobar, MatlCostConv, LbrCostConv, FovhdCostConv, VovhdCostConv, OutCostConv, UnitCostConv);
			}
		}
	}
}
