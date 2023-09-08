//PROJECT NAME: Logistics
//CLASS NAME: CreateReplenPOReleaseforItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CreateReplenPOReleaseforItem : ICreateReplenPOReleaseforItem
	{
		readonly IApplicationDB appDB;
		
		
		public CreateReplenPOReleaseforItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PPoLine,
		int? PPoRelease,
		decimal? PExchRate,
		decimal? PUnitMatCostConv,
		decimal? PUnitBrokerageCostConv,
		decimal? PUnitFreightCostConv,
		decimal? PUnitInsuranceCostConv,
		decimal? PUnitDutyCostConv,
		decimal? PUnitLocFrtCostConv,
		decimal? PUnitMatCost,
		decimal? PUnitBrokerageCost,
		decimal? PUnitFreightCost,
		decimal? PUnitInsuranceCost,
		decimal? PUnitDutyCost,
		decimal? PUnitLocFrtCost,
		decimal? PItemCostConv,
		decimal? PExtendedItemCostConv,
		string PUbWorkKey,
		Guid? PPoitemRowPointer,
		string Infobar) CreateReplenPOReleaseforItemSp(string CurWhse,
		string PoNum,
		string Item,
		string VendNum,
		decimal? ReqQty,
		string UM,
		int? PPoLine,
		int? PPoRelease,
		decimal? PExchRate,
		decimal? PUnitMatCostConv,
		decimal? PUnitBrokerageCostConv,
		decimal? PUnitFreightCostConv,
		decimal? PUnitInsuranceCostConv,
		decimal? PUnitDutyCostConv,
		decimal? PUnitLocFrtCostConv,
		decimal? PUnitMatCost,
		decimal? PUnitBrokerageCost,
		decimal? PUnitFreightCost,
		decimal? PUnitInsuranceCost,
		decimal? PUnitDutyCost,
		decimal? PUnitLocFrtCost,
		decimal? PItemCostConv,
		decimal? PExtendedItemCostConv,
		string PUbWorkKey,
		Guid? PPoitemRowPointer,
		string Infobar)
		{
			WhseType _CurWhse = CurWhse;
			PoNumType _PoNum = PoNum;
			ItemType _Item = Item;
			VendNumType _VendNum = VendNum;
			QtyTotlNoNegType _ReqQty = ReqQty;
			UMType _UM = UM;
			PoLineType _PPoLine = PPoLine;
			PoReleaseType _PPoRelease = PPoRelease;
			ExchRateType _PExchRate = PExchRate;
			CostPrcType _PUnitMatCostConv = PUnitMatCostConv;
			CostPrcType _PUnitBrokerageCostConv = PUnitBrokerageCostConv;
			CostPrcType _PUnitFreightCostConv = PUnitFreightCostConv;
			CostPrcType _PUnitInsuranceCostConv = PUnitInsuranceCostConv;
			CostPrcType _PUnitDutyCostConv = PUnitDutyCostConv;
			CostPrcType _PUnitLocFrtCostConv = PUnitLocFrtCostConv;
			CostPrcType _PUnitMatCost = PUnitMatCost;
			CostPrcType _PUnitBrokerageCost = PUnitBrokerageCost;
			CostPrcType _PUnitFreightCost = PUnitFreightCost;
			CostPrcType _PUnitInsuranceCost = PUnitInsuranceCost;
			CostPrcType _PUnitDutyCost = PUnitDutyCost;
			CostPrcType _PUnitLocFrtCost = PUnitLocFrtCost;
			CostPrcType _PItemCostConv = PItemCostConv;
			CostPrcType _PExtendedItemCostConv = PExtendedItemCostConv;
			StringType _PUbWorkKey = PUbWorkKey;
			RowPointerType _PPoitemRowPointer = PPoitemRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateReplenPOReleaseforItemSp";
				
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqQty", _ReqQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoLine", _PPoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPoRelease", _PPoRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitMatCostConv", _PUnitMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitBrokerageCostConv", _PUnitBrokerageCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitFreightCostConv", _PUnitFreightCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitInsuranceCostConv", _PUnitInsuranceCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitDutyCostConv", _PUnitDutyCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitLocFrtCostConv", _PUnitLocFrtCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitMatCost", _PUnitMatCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitBrokerageCost", _PUnitBrokerageCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitFreightCost", _PUnitFreightCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitInsuranceCost", _PUnitInsuranceCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitDutyCost", _PUnitDutyCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUnitLocFrtCost", _PUnitLocFrtCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemCostConv", _PItemCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExtendedItemCostConv", _PExtendedItemCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUbWorkKey", _PUbWorkKey, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPoitemRowPointer", _PPoitemRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPoLine = _PPoLine;
				PPoRelease = _PPoRelease;
				PExchRate = _PExchRate;
				PUnitMatCostConv = _PUnitMatCostConv;
				PUnitBrokerageCostConv = _PUnitBrokerageCostConv;
				PUnitFreightCostConv = _PUnitFreightCostConv;
				PUnitInsuranceCostConv = _PUnitInsuranceCostConv;
				PUnitDutyCostConv = _PUnitDutyCostConv;
				PUnitLocFrtCostConv = _PUnitLocFrtCostConv;
				PUnitMatCost = _PUnitMatCost;
				PUnitBrokerageCost = _PUnitBrokerageCost;
				PUnitFreightCost = _PUnitFreightCost;
				PUnitInsuranceCost = _PUnitInsuranceCost;
				PUnitDutyCost = _PUnitDutyCost;
				PUnitLocFrtCost = _PUnitLocFrtCost;
				PItemCostConv = _PItemCostConv;
				PExtendedItemCostConv = _PExtendedItemCostConv;
				PUbWorkKey = _PUbWorkKey;
				PPoitemRowPointer = _PPoitemRowPointer;
				Infobar = _Infobar;
				
				return (Severity, PPoLine, PPoRelease, PExchRate, PUnitMatCostConv, PUnitBrokerageCostConv, PUnitFreightCostConv, PUnitInsuranceCostConv, PUnitDutyCostConv, PUnitLocFrtCostConv, PUnitMatCost, PUnitBrokerageCost, PUnitFreightCost, PUnitInsuranceCost, PUnitDutyCost, PUnitLocFrtCost, PItemCostConv, PExtendedItemCostConv, PUbWorkKey, PPoitemRowPointer, Infobar);
			}
		}
	}
}
