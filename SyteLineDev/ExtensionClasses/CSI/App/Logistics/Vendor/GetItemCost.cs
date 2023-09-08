//PROJECT NAME: Logistics
//CLASS NAME: GetItemCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetItemCost : IGetItemCost
	{
		readonly IApplicationDB appDB;
		
		
		public GetItemCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? UnitMatCost,
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
		string Infobar,
		int? DispMsg) GetItemCostSp(string Item,
		string UM,
		string VendNum,
		string VendorCurrCode,
		decimal? ExchRate,
		decimal? QtyOrderedConv,
		DateTime? EffectiveDate,
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
		string Infobar,
		string PoNum,
		int? DispMsg = 0,
		string Site = null,
		string Whse = null,
		int? PoLine = null,
		string AUContractPriceMethod = null,
		string ContractID = null)
		{
			ItemType _Item = Item;
			UMType _UM = UM;
			VendNumType _VendNum = VendNum;
			CurrCodeType _VendorCurrCode = VendorCurrCode;
			ExchRateType _ExchRate = ExchRate;
			QtyUnitNoNegType _QtyOrderedConv = QtyOrderedConv;
			DateType _EffectiveDate = EffectiveDate;
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
			Infobar _Infobar = Infobar;
			PoNumType _PoNum = PoNum;
			ListYesNoType _DispMsg = DispMsg;
			SiteType _Site = Site;
			WhseType _Whse = Whse;
			PoLineType _PoLine = PoLine;
			AU_ContractPriceMethodType _AUContractPriceMethod = AUContractPriceMethod;
			AU_ContractIDType _ContractID = ContractID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemCostSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorCurrCode", _VendorCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispMsg", _DispMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AUContractPriceMethod", _AUContractPriceMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContractID", _ContractID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
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
				Infobar = _Infobar;
				DispMsg = _DispMsg;
				
				return (Severity, UnitMatCost, UnitMatCostConv, UnitFreightCost, UnitFreightCostConv, UnitDutyCost, UnitDutyCostConv, UnitBrokerageCost, UnitBrokerageCostConv, UnitInsuranceCost, UnitInsuranceCostConv, UnitLocFrtCost, UnitLocFrtCostConv, Infobar, DispMsg);
			}
		}
	}
}
