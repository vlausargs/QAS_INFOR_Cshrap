//PROJECT NAME: CSIVendor
//CLASS NAME: POReceiveQtyConvWrapper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPOReceiveQtyConvWrapper
	{
		int POReceiveQtyConvWrapperSp(decimal? UbQtyReceivedConv,
		                              decimal? UbQtyReturnedConv,
		                              decimal? UnitMatCostConv,
		                              decimal? UnitBrokerageCostConv,
		                              decimal? UnitDutyCostConv,
		                              decimal? UnitFreightCostConv,
		                              decimal? UnitInsuranceCostConv,
		                              decimal? UnitLocFrtCostConv,
		                              ref decimal? ItemCostConv,
		                              string Item,
		                              string UM,
		                              string VendNum,
		                              ref decimal? UbQtyReceived,
		                              ref decimal? UbQtyReturned,
		                              ref decimal? UnitMatCost,
		                              ref decimal? UnitBrokerageCost,
		                              ref decimal? UnitDutyCost,
		                              ref decimal? UnitFreightCost,
		                              ref decimal? UnitInsuranceCost,
		                              ref decimal? UnitLocFrtCost,
		                              ref decimal? ItemCost,
		                              ref string Infobar);
	}
	
	public class POReceiveQtyConvWrapper : IPOReceiveQtyConvWrapper
	{
		readonly IApplicationDB appDB;
		
		public POReceiveQtyConvWrapper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int POReceiveQtyConvWrapperSp(decimal? UbQtyReceivedConv,
		                                     decimal? UbQtyReturnedConv,
		                                     decimal? UnitMatCostConv,
		                                     decimal? UnitBrokerageCostConv,
		                                     decimal? UnitDutyCostConv,
		                                     decimal? UnitFreightCostConv,
		                                     decimal? UnitInsuranceCostConv,
		                                     decimal? UnitLocFrtCostConv,
		                                     ref decimal? ItemCostConv,
		                                     string Item,
		                                     string UM,
		                                     string VendNum,
		                                     ref decimal? UbQtyReceived,
		                                     ref decimal? UbQtyReturned,
		                                     ref decimal? UnitMatCost,
		                                     ref decimal? UnitBrokerageCost,
		                                     ref decimal? UnitDutyCost,
		                                     ref decimal? UnitFreightCost,
		                                     ref decimal? UnitInsuranceCost,
		                                     ref decimal? UnitLocFrtCost,
		                                     ref decimal? ItemCost,
		                                     ref string Infobar)
		{
			QtyUnitType _UbQtyReceivedConv = UbQtyReceivedConv;
			QtyUnitType _UbQtyReturnedConv = UbQtyReturnedConv;
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
			CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
			CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
			CostPrcType _UnitInsuranceCostConv = UnitInsuranceCostConv;
			CostPrcType _UnitLocFrtCostConv = UnitLocFrtCostConv;
			CostPrcType _ItemCostConv = ItemCostConv;
			ItemType _Item = Item;
			UMType _UM = UM;
			VendNumType _VendNum = VendNum;
			QtyUnitType _UbQtyReceived = UbQtyReceived;
			QtyUnitType _UbQtyReturned = UbQtyReturned;
			CostPrcType _UnitMatCost = UnitMatCost;
			CostPrcType _UnitBrokerageCost = UnitBrokerageCost;
			CostPrcType _UnitDutyCost = UnitDutyCost;
			CostPrcType _UnitFreightCost = UnitFreightCost;
			CostPrcType _UnitInsuranceCost = UnitInsuranceCost;
			CostPrcType _UnitLocFrtCost = UnitLocFrtCost;
			CostPrcType _ItemCost = ItemCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POReceiveQtyConvWrapperSp";
				
				appDB.AddCommandParameter(cmd, "UbQtyReceivedConv", _UbQtyReceivedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbQtyReturnedConv", _UbQtyReturnedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCostConv", _UnitInsuranceCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCostConv", _UnitLocFrtCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemCostConv", _ItemCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbQtyReceived", _UbQtyReceived, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UbQtyReturned", _UbQtyReturned, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitMatCost", _UnitMatCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCost", _UnitBrokerageCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitDutyCost", _UnitDutyCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCost", _UnitFreightCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCost", _UnitInsuranceCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCost", _UnitLocFrtCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCost", _ItemCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemCostConv = _ItemCostConv;
				UbQtyReceived = _UbQtyReceived;
				UbQtyReturned = _UbQtyReturned;
				UnitMatCost = _UnitMatCost;
				UnitBrokerageCost = _UnitBrokerageCost;
				UnitDutyCost = _UnitDutyCost;
				UnitFreightCost = _UnitFreightCost;
				UnitInsuranceCost = _UnitInsuranceCost;
				UnitLocFrtCost = _UnitLocFrtCost;
				ItemCost = _ItemCost;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
