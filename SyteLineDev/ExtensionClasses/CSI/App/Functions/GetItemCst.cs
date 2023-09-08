//PROJECT NAME: Data
//CLASS NAME: GetItemCst.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetItemCst : IGetItemCst
	{
		readonly IApplicationDB appDB;
		
		public GetItemCst(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? UnitCost,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovhdCost,
			decimal? VovhdCost,
			decimal? OutCost,
			decimal? UnitPrice,
			decimal? UnitDutyCost,
			decimal? UnitFreightCost,
			decimal? UnitBrokerageCost,
			decimal? UnitInsuranceCost,
			decimal? UnitLocFrtCost,
			decimal? UnitWeight,
			string Origin,
			decimal? UnitMatCost,
			string Infobar) GetItemCstSp(
			int? PriceOnly,
			string Item,
			string Pricecode,
			decimal? QtyReq,
			decimal? UnitCost,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovhdCost,
			decimal? VovhdCost,
			decimal? OutCost,
			decimal? UnitPrice,
			decimal? UnitDutyCost,
			decimal? UnitFreightCost,
			decimal? UnitBrokerageCost,
			decimal? UnitInsuranceCost,
			decimal? UnitLocFrtCost,
			decimal? UnitWeight,
			string Origin,
			decimal? UnitMatCost,
			string Infobar,
			string TransferFromSite = null,
			string TransferToSite = null,
			decimal? TransferExchRate = null,
			DateTime? TransferOrderDate = null,
			string Whse = null)
		{
			FlagNyType _PriceOnly = PriceOnly;
			ItemType _Item = Item;
			PriceCodeType _Pricecode = Pricecode;
			QtyUnitType _QtyReq = QtyReq;
			CostPrcType _UnitCost = UnitCost;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			CostPrcType _UnitPrice = UnitPrice;
			CostPrcType _UnitDutyCost = UnitDutyCost;
			CostPrcType _UnitFreightCost = UnitFreightCost;
			CostPrcType _UnitBrokerageCost = UnitBrokerageCost;
			CostPrcType _UnitInsuranceCost = UnitInsuranceCost;
			CostPrcType _UnitLocFrtCost = UnitLocFrtCost;
			UnitWeightType _UnitWeight = UnitWeight;
			EcCodeType _Origin = Origin;
			CostPrcType _UnitMatCost = UnitMatCost;
			InfobarType _Infobar = Infobar;
			SiteType _TransferFromSite = TransferFromSite;
			SiteType _TransferToSite = TransferToSite;
			ExchRateType _TransferExchRate = TransferExchRate;
			DateType _TransferOrderDate = TransferOrderDate;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemCstSp";
				
				appDB.AddCommandParameter(cmd, "PriceOnly", _PriceOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReq", _QtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPrice", _UnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitDutyCost", _UnitDutyCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCost", _UnitFreightCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCost", _UnitBrokerageCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCost", _UnitInsuranceCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCost", _UnitLocFrtCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitMatCost", _UnitMatCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransferFromSite", _TransferFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferToSite", _TransferToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferExchRate", _TransferExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferOrderDate", _TransferOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UnitCost = _UnitCost;
				MatlCost = _MatlCost;
				LbrCost = _LbrCost;
				FovhdCost = _FovhdCost;
				VovhdCost = _VovhdCost;
				OutCost = _OutCost;
				UnitPrice = _UnitPrice;
				UnitDutyCost = _UnitDutyCost;
				UnitFreightCost = _UnitFreightCost;
				UnitBrokerageCost = _UnitBrokerageCost;
				UnitInsuranceCost = _UnitInsuranceCost;
				UnitLocFrtCost = _UnitLocFrtCost;
				UnitWeight = _UnitWeight;
				Origin = _Origin;
				UnitMatCost = _UnitMatCost;
				Infobar = _Infobar;
				
				return (Severity, UnitCost, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, UnitPrice, UnitDutyCost, UnitFreightCost, UnitBrokerageCost, UnitInsuranceCost, UnitLocFrtCost, UnitWeight, Origin, UnitMatCost, Infobar);
			}
		}
	}
}
