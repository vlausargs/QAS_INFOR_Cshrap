//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsUMV1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CurrentMaterialsUMV1 : ICurrentMaterialsUMV1
	{
		readonly IApplicationDB appDB;
		
		
		public CurrentMaterialsUMV1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? MatlQtyConv,
		string VDerUM,
		decimal? VDerUOMConvFactor,
		decimal? VMatlQty,
		decimal? VCost,
		decimal? VIncPrice,
		decimal? VMatlCost,
		decimal? VLbrCost,
		decimal? VFovhdCost,
		decimal? VVovhdCost,
		decimal? VOutCost,
		string Infobar,
		string Prompt,
		string PromptButtons) CurrentMaterialsUMV1Sp(string UM,
		string Item,
		string ItemUM,
		decimal? Cost,
		decimal? IncPrice,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		string DerUM,
		decimal? MatlQtyConv,
		string VDerUM,
		decimal? VDerUOMConvFactor,
		decimal? VMatlQty,
		decimal? VCost,
		decimal? VIncPrice,
		decimal? VMatlCost,
		decimal? VLbrCost,
		decimal? VFovhdCost,
		decimal? VVovhdCost,
		decimal? VOutCost,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null)
		{
			UMType _UM = UM;
			ItemType _Item = Item;
			UMType _ItemUM = ItemUM;
			CostPrcType _Cost = Cost;
			CostPrcType _IncPrice = IncPrice;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			UMType _DerUM = DerUM;
			QtyPerType _MatlQtyConv = MatlQtyConv;
			UMType _VDerUM = VDerUM;
			UMConvFactorType _VDerUOMConvFactor = VDerUOMConvFactor;
			QtyPerType _VMatlQty = VMatlQty;
			CostPrcType _VCost = VCost;
			CostPrcType _VIncPrice = VIncPrice;
			CostPrcType _VMatlCost = VMatlCost;
			CostPrcType _VLbrCost = VLbrCost;
			CostPrcType _VFovhdCost = VFovhdCost;
			CostPrcType _VVovhdCost = VVovhdCost;
			CostPrcType _VOutCost = VOutCost;
			Infobar _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CurrentMaterialsUMV1Sp";
				
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cost", _Cost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncPrice", _IncPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerUM", _DerUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlQtyConv", _MatlQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VDerUM", _VDerUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VDerUOMConvFactor", _VDerUOMConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VMatlQty", _VMatlQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VCost", _VCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VIncPrice", _VIncPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VMatlCost", _VMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VLbrCost", _VLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VFovhdCost", _VFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VVovhdCost", _VVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VOutCost", _VOutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MatlQtyConv = _MatlQtyConv;
				VDerUM = _VDerUM;
				VDerUOMConvFactor = _VDerUOMConvFactor;
				VMatlQty = _VMatlQty;
				VCost = _VCost;
				VIncPrice = _VIncPrice;
				VMatlCost = _VMatlCost;
				VLbrCost = _VLbrCost;
				VFovhdCost = _VFovhdCost;
				VVovhdCost = _VVovhdCost;
				VOutCost = _VOutCost;
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				
				return (Severity, MatlQtyConv, VDerUM, VDerUOMConvFactor, VMatlQty, VCost, VIncPrice, VMatlCost, VLbrCost, VFovhdCost, VVovhdCost, VOutCost, Infobar, Prompt, PromptButtons);
			}
		}
	}
}
