//PROJECT NAME: CSIVendor
//CLASS NAME: POReceivingConvertCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPOReceivingConvertCost
	{
		(int? ReturnCode, decimal? UnitDutyCost, decimal? UnitFreightCost, decimal? UnitBrokerageCost, decimal? UnitInsuranceCost, decimal? UnitLocFrtCost, decimal? UnitDutyCostConv, decimal? UnitFreightCostConv, decimal? UnitBrokerageCostConv, decimal? UnitInsuranceCostConv, decimal? UnitLocFrtCostConv, decimal? LUnitDutyCost, decimal? LUnitFreightCost, decimal? LUnitBrokerageCost, decimal? LUnitInsuranceCost, decimal? LUnitLocFrtCost, decimal? ItemCost, decimal? ItemCostConv, decimal? UnitMatCost, decimal? UnitMatCostConv, string Infobar) POReceivingConvertCostSp(string PoVendNum,
		string PoNum = null,
		decimal? UnitDutyCost = 0,
		decimal? UnitFreightCost = 0,
		decimal? UnitBrokerageCost = 0,
		decimal? UnitInsuranceCost = 0,
		decimal? UnitLocFrtCost = 0,
		decimal? UnitDutyCostConv = 0,
		decimal? UnitFreightCostConv = 0,
		decimal? UnitBrokerageCostConv = 0,
		decimal? UnitInsuranceCostConv = 0,
		decimal? UnitLocFrtCostConv = 0,
		decimal? LUnitDutyCost = 0,
		decimal? LUnitFreightCost = 0,
		decimal? LUnitBrokerageCost = 0,
		decimal? LUnitInsuranceCost = 0,
		decimal? LUnitLocFrtCost = 0,
		decimal? DutyExchRate = null,
		decimal? FreightExchRate = null,
		decimal? BrokerageExchRate = null,
		decimal? InsuranceExchRate = null,
		decimal? LocFrtExchRate = null,
		string DutyCurrCode = null,
		string FreightCurrCode = null,
		string BrokerageCurrCode = null,
		string InsuranceCurrCode = null,
		string LocFrtCurrCode = null,
		decimal? ItemCost = 0,
		decimal? ItemCostConv = 0,
		decimal? UnitMatCost = 0,
		decimal? UnitMatCostConv = 0,
		string RequiredCostTypes = null,
		string ChangedCostType = "D",
		string UM = null,
		string Item = null,
		string Infobar = null,
		DateTime? TransDate = null);
	}
	
	public class POReceivingConvertCost : IPOReceivingConvertCost
	{
		readonly IApplicationDB appDB;
		
		public POReceivingConvertCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? UnitDutyCost, decimal? UnitFreightCost, decimal? UnitBrokerageCost, decimal? UnitInsuranceCost, decimal? UnitLocFrtCost, decimal? UnitDutyCostConv, decimal? UnitFreightCostConv, decimal? UnitBrokerageCostConv, decimal? UnitInsuranceCostConv, decimal? UnitLocFrtCostConv, decimal? LUnitDutyCost, decimal? LUnitFreightCost, decimal? LUnitBrokerageCost, decimal? LUnitInsuranceCost, decimal? LUnitLocFrtCost, decimal? ItemCost, decimal? ItemCostConv, decimal? UnitMatCost, decimal? UnitMatCostConv, string Infobar) POReceivingConvertCostSp(string PoVendNum,
		string PoNum = null,
		decimal? UnitDutyCost = 0,
		decimal? UnitFreightCost = 0,
		decimal? UnitBrokerageCost = 0,
		decimal? UnitInsuranceCost = 0,
		decimal? UnitLocFrtCost = 0,
		decimal? UnitDutyCostConv = 0,
		decimal? UnitFreightCostConv = 0,
		decimal? UnitBrokerageCostConv = 0,
		decimal? UnitInsuranceCostConv = 0,
		decimal? UnitLocFrtCostConv = 0,
		decimal? LUnitDutyCost = 0,
		decimal? LUnitFreightCost = 0,
		decimal? LUnitBrokerageCost = 0,
		decimal? LUnitInsuranceCost = 0,
		decimal? LUnitLocFrtCost = 0,
		decimal? DutyExchRate = null,
		decimal? FreightExchRate = null,
		decimal? BrokerageExchRate = null,
		decimal? InsuranceExchRate = null,
		decimal? LocFrtExchRate = null,
		string DutyCurrCode = null,
		string FreightCurrCode = null,
		string BrokerageCurrCode = null,
		string InsuranceCurrCode = null,
		string LocFrtCurrCode = null,
		decimal? ItemCost = 0,
		decimal? ItemCostConv = 0,
		decimal? UnitMatCost = 0,
		decimal? UnitMatCostConv = 0,
		string RequiredCostTypes = null,
		string ChangedCostType = "D",
		string UM = null,
		string Item = null,
		string Infobar = null,
		DateTime? TransDate = null)
		{
			VendNumType _PoVendNum = PoVendNum;
			PoNumType _PoNum = PoNum;
			CostPrcType _UnitDutyCost = UnitDutyCost;
			CostPrcType _UnitFreightCost = UnitFreightCost;
			CostPrcType _UnitBrokerageCost = UnitBrokerageCost;
			CostPrcType _UnitInsuranceCost = UnitInsuranceCost;
			CostPrcType _UnitLocFrtCost = UnitLocFrtCost;
			CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
			CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
			CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
			CostPrcType _UnitInsuranceCostConv = UnitInsuranceCostConv;
			CostPrcType _UnitLocFrtCostConv = UnitLocFrtCostConv;
			CostPrcType _LUnitDutyCost = LUnitDutyCost;
			CostPrcType _LUnitFreightCost = LUnitFreightCost;
			CostPrcType _LUnitBrokerageCost = LUnitBrokerageCost;
			CostPrcType _LUnitInsuranceCost = LUnitInsuranceCost;
			CostPrcType _LUnitLocFrtCost = LUnitLocFrtCost;
			ExchRateType _DutyExchRate = DutyExchRate;
			ExchRateType _FreightExchRate = FreightExchRate;
			ExchRateType _BrokerageExchRate = BrokerageExchRate;
			ExchRateType _InsuranceExchRate = InsuranceExchRate;
			ExchRateType _LocFrtExchRate = LocFrtExchRate;
			CurrCodeType _DutyCurrCode = DutyCurrCode;
			CurrCodeType _FreightCurrCode = FreightCurrCode;
			CurrCodeType _BrokerageCurrCode = BrokerageCurrCode;
			CurrCodeType _InsuranceCurrCode = InsuranceCurrCode;
			CurrCodeType _LocFrtCurrCode = LocFrtCurrCode;
			CostPrcType _ItemCost = ItemCost;
			CostPrcType _ItemCostConv = ItemCostConv;
			CostPrcType _UnitMatCost = UnitMatCost;
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			StringType _RequiredCostTypes = RequiredCostTypes;
			StringType _ChangedCostType = ChangedCostType;
			UMType _UM = UM;
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			DateType _TransDate = TransDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POReceivingConvertCostSp";
				
				appDB.AddCommandParameter(cmd, "PoVendNum", _PoVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitDutyCost", _UnitDutyCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCost", _UnitFreightCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCost", _UnitBrokerageCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCost", _UnitInsuranceCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCost", _UnitLocFrtCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCostConv", _UnitInsuranceCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCostConv", _UnitLocFrtCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LUnitDutyCost", _LUnitDutyCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LUnitFreightCost", _LUnitFreightCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LUnitBrokerageCost", _LUnitBrokerageCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LUnitInsuranceCost", _LUnitInsuranceCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LUnitLocFrtCost", _LUnitLocFrtCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DutyExchRate", _DutyExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightExchRate", _FreightExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrokerageExchRate", _BrokerageExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsuranceExchRate", _InsuranceExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocFrtExchRate", _LocFrtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DutyCurrCode", _DutyCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FreightCurrCode", _FreightCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrokerageCurrCode", _BrokerageCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsuranceCurrCode", _InsuranceCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocFrtCurrCode", _LocFrtCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemCost", _ItemCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCostConv", _ItemCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitMatCost", _UnitMatCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RequiredCostTypes", _RequiredCostTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChangedCostType", _ChangedCostType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnitDutyCost = _UnitDutyCost;
				UnitFreightCost = _UnitFreightCost;
				UnitBrokerageCost = _UnitBrokerageCost;
				UnitInsuranceCost = _UnitInsuranceCost;
				UnitLocFrtCost = _UnitLocFrtCost;
				UnitDutyCostConv = _UnitDutyCostConv;
				UnitFreightCostConv = _UnitFreightCostConv;
				UnitBrokerageCostConv = _UnitBrokerageCostConv;
				UnitInsuranceCostConv = _UnitInsuranceCostConv;
				UnitLocFrtCostConv = _UnitLocFrtCostConv;
				LUnitDutyCost = _LUnitDutyCost;
				LUnitFreightCost = _LUnitFreightCost;
				LUnitBrokerageCost = _LUnitBrokerageCost;
				LUnitInsuranceCost = _LUnitInsuranceCost;
				LUnitLocFrtCost = _LUnitLocFrtCost;
				ItemCost = _ItemCost;
				ItemCostConv = _ItemCostConv;
				UnitMatCost = _UnitMatCost;
				UnitMatCostConv = _UnitMatCostConv;
				Infobar = _Infobar;
				
				return (Severity, UnitDutyCost, UnitFreightCost, UnitBrokerageCost, UnitInsuranceCost, UnitLocFrtCost, UnitDutyCostConv, UnitFreightCostConv, UnitBrokerageCostConv, UnitInsuranceCostConv, UnitLocFrtCostConv, LUnitDutyCost, LUnitFreightCost, LUnitBrokerageCost, LUnitInsuranceCost, LUnitLocFrtCost, ItemCost, ItemCostConv, UnitMatCost, UnitMatCostConv, Infobar);
			}
		}
	}
}
