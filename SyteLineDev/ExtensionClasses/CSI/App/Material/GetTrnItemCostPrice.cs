//PROJECT NAME: Material
//CLASS NAME: GetTrnItemCostPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetTrnItemCostPrice : IGetTrnItemCostPrice
	{
		readonly IApplicationDB appDB;
		
		
		public GetTrnItemCostPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Origin,
		decimal? UnitWeight,
		decimal? UnitCost,
		decimal? UnitCostConv,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? UnitPrice,
		decimal? UnitPriceConv,
		decimal? UnitMatCost,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCost,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCost,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCost,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCost,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCost,
		decimal? UnitLocFrtCostConv,
		decimal? UnitTotalCost,
		decimal? ExtPrice,
		string Infobar) GetTrnItemCostPriceSp(string TrnNum,
		string Item,
		string Pricecode,
		decimal? QtyReq,
		int? PriceOnly,
		int? Update,
		int? TrnLine,
		string FromSite,
		string ToSite,
		string UM,
		string Origin,
		decimal? UnitWeight,
		decimal? UnitCost,
		decimal? UnitCostConv,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? UnitPrice,
		decimal? UnitPriceConv,
		decimal? UnitMatCost,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCost,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCost,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCost,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCost,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCost,
		decimal? UnitLocFrtCostConv,
		decimal? UnitTotalCost,
		decimal? ExtPrice,
		string Infobar,
		string Whse)
		{
			TrnNumType _TrnNum = TrnNum;
			ItemType _Item = Item;
			PriceCodeType _Pricecode = Pricecode;
			QtyUnitType _QtyReq = QtyReq;
			Flag _PriceOnly = PriceOnly;
			Flag _Update = Update;
			TrnLineType _TrnLine = TrnLine;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			UMType _UM = UM;
			EcCodeType _Origin = Origin;
			UnitWeightType _UnitWeight = UnitWeight;
			CostPrcType _UnitCost = UnitCost;
			CostPrcType _UnitCostConv = UnitCostConv;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			CostPrcType _UnitPrice = UnitPrice;
			CostPrcType _UnitPriceConv = UnitPriceConv;
			CostPrcType _UnitMatCost = UnitMatCost;
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			CostPrcType _UnitFreightCost = UnitFreightCost;
			CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
			CostPrcType _UnitDutyCost = UnitDutyCost;
			CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
			CostPrcType _UnitBrokerageCost = UnitBrokerageCost;
			CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
			CostPrcType _UnitInsuranceCost = UnitInsuranceCost;
			CostPrcType _UnitInsuranceCostConv = UnitInsuranceCostConv;
			CostPrcType _UnitLocFrtCost = UnitLocFrtCost;
			CostPrcType _UnitLocFrtCostConv = UnitLocFrtCostConv;
			CostPrcType _UnitTotalCost = UnitTotalCost;
			CostPrcType _ExtPrice = ExtPrice;
			InfobarType _Infobar = Infobar;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTrnItemCostPriceSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReq", _QtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceOnly", _PriceOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Update", _Update, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCostConv", _UnitCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPrice", _UnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPriceConv", _UnitPriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitMatCost", _UnitMatCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCost", _UnitFreightCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitDutyCost", _UnitDutyCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCost", _UnitBrokerageCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCost", _UnitInsuranceCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCostConv", _UnitInsuranceCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCost", _UnitLocFrtCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCostConv", _UnitLocFrtCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitTotalCost", _UnitTotalCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtPrice", _ExtPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Origin = _Origin;
				UnitWeight = _UnitWeight;
				UnitCost = _UnitCost;
				UnitCostConv = _UnitCostConv;
				MatlCost = _MatlCost;
				LbrCost = _LbrCost;
				FovhdCost = _FovhdCost;
				VovhdCost = _VovhdCost;
				OutCost = _OutCost;
				UnitPrice = _UnitPrice;
				UnitPriceConv = _UnitPriceConv;
				UnitMatCost = _UnitMatCost;
				UnitMatCostConv = _UnitMatCostConv;
				UnitFreightCost = _UnitFreightCost;
				UnitFreightCostConv = _UnitFreightCostConv;
				UnitDutyCost = _UnitDutyCost;
				UnitDutyCostConv = _UnitDutyCostConv;
				UnitBrokerageCost = _UnitBrokerageCost;
				UnitBrokerageCostConv = _UnitBrokerageCostConv;
				UnitInsuranceCost = _UnitInsuranceCost;
				UnitInsuranceCostConv = _UnitInsuranceCostConv;
				UnitLocFrtCost = _UnitLocFrtCost;
				UnitLocFrtCostConv = _UnitLocFrtCostConv;
				UnitTotalCost = _UnitTotalCost;
				ExtPrice = _ExtPrice;
				Infobar = _Infobar;
				
				return (Severity, Origin, UnitWeight, UnitCost, UnitCostConv, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, UnitPrice, UnitPriceConv, UnitMatCost, UnitMatCostConv, UnitFreightCost, UnitFreightCostConv, UnitDutyCost, UnitDutyCostConv, UnitBrokerageCost, UnitBrokerageCostConv, UnitInsuranceCost, UnitInsuranceCostConv, UnitLocFrtCost, UnitLocFrtCostConv, UnitTotalCost, ExtPrice, Infobar);
			}
		}
	}
}
