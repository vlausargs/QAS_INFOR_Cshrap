//PROJECT NAME: Data
//CLASS NAME: TritmCp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TritmCp : ITritmCp
	{
		readonly IApplicationDB appDB;
		
		public TritmCp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TritmCpSp(
			string TrnitemTrnNum,
			int? TrnitemTrnLine,
			decimal? TrnitemQtyReceived,
			decimal? TrnitemQtyReq,
			decimal? TrnitemQtyShipped,
			string TrnitemStat,
			string TrnitemItem,
			DateTime? TrnitemSchRcvDate,
			DateTime? TrnitemShipDate,
			DateTime? TrnitemRcvdDate,
			decimal? TrnitemQtyLoss,
			decimal? TrnitemQtyPacked,
			DateTime? TrnitemSchShipDate,
			DateTime? TrnitemPickDate,
			decimal? TrnitemQtyReqConv,
			string TrnitemUM,
			string TrnitemTrnLoc,
			string TrnitemPricecode,
			decimal? TrnitemUnitWeight,
			string TrnitemFrmRefType,
			string TrnitemToRefType,
			string TrnitemFromSite,
			string TrnitemFromWhse,
			string TrnitemToSite,
			string TrnitemToWhse,
			int? TrnitemCrossSite,
			string TrnitemTransNat,
			string TrnitemDelterm,
			string TrnitemProcessInd,
			string TrnitemEcCode,
			string TrnitemOrigin,
			string TrnitemCommCode,
			decimal? TrnitemSupplQtyConvFactor,
			decimal? TrnitemExportValue,
			int? TrnitemConsNum,
			decimal? TrnitemUnitPrice,
			decimal? TrnitemUnitCost,
			decimal? TrnitemMatlCost,
			decimal? TrnitemUnitMatCost,
			decimal? TrnitemUnitMatCostConv,
			decimal? TrnitemUnitDutyCost,
			decimal? TrnitemUnitBrokerageCost,
			decimal? TrnitemUnitFreightCost,
			decimal? TrnitemUnitInsCost,
			decimal? TrnitemUnitLocFrtCost,
			decimal? TrnitemLbrCost,
			decimal? TrnitemFovhdCost,
			decimal? TrnitemVovhdCost,
			decimal? TrnitemOutCost,
			int? PUpdate,
			decimal? PExchRate,
			string PCurrCode,
			int? PTextOnly,
			string Infobar,
			string TrnitemTransNat2,
			int? PlanOnSave,
			DateTime? TrnitemProjectedDate,
			int? TrnitemPreassignLots,
			int? TrnitemPreassignSerials,
			int? RepFromTrigger = 0,
			int? ApsMode = 0,
			string UETListPairs = null)
		{
			TrnNumType _TrnitemTrnNum = TrnitemTrnNum;
			TrnLineType _TrnitemTrnLine = TrnitemTrnLine;
			QtyUnitType _TrnitemQtyReceived = TrnitemQtyReceived;
			QtyUnitType _TrnitemQtyReq = TrnitemQtyReq;
			QtyUnitType _TrnitemQtyShipped = TrnitemQtyShipped;
			TransferStatusType _TrnitemStat = TrnitemStat;
			ItemType _TrnitemItem = TrnitemItem;
			DateType _TrnitemSchRcvDate = TrnitemSchRcvDate;
			DateType _TrnitemShipDate = TrnitemShipDate;
			DateType _TrnitemRcvdDate = TrnitemRcvdDate;
			QtyUnitType _TrnitemQtyLoss = TrnitemQtyLoss;
			QtyUnitType _TrnitemQtyPacked = TrnitemQtyPacked;
			DateType _TrnitemSchShipDate = TrnitemSchShipDate;
			DateType _TrnitemPickDate = TrnitemPickDate;
			QtyUnitType _TrnitemQtyReqConv = TrnitemQtyReqConv;
			UMType _TrnitemUM = TrnitemUM;
			LocType _TrnitemTrnLoc = TrnitemTrnLoc;
			PriceCodeType _TrnitemPricecode = TrnitemPricecode;
			UnitWeightType _TrnitemUnitWeight = TrnitemUnitWeight;
			RefTypeIJPRType _TrnitemFrmRefType = TrnitemFrmRefType;
			RefTypeIJOType _TrnitemToRefType = TrnitemToRefType;
			SiteType _TrnitemFromSite = TrnitemFromSite;
			WhseType _TrnitemFromWhse = TrnitemFromWhse;
			SiteType _TrnitemToSite = TrnitemToSite;
			WhseType _TrnitemToWhse = TrnitemToWhse;
			ListYesNoType _TrnitemCrossSite = TrnitemCrossSite;
			TransNatType _TrnitemTransNat = TrnitemTransNat;
			DeltermType _TrnitemDelterm = TrnitemDelterm;
			ProcessIndType _TrnitemProcessInd = TrnitemProcessInd;
			EcCodeType _TrnitemEcCode = TrnitemEcCode;
			EcCodeType _TrnitemOrigin = TrnitemOrigin;
			CommodityCodeType _TrnitemCommCode = TrnitemCommCode;
			UMConvFactorType _TrnitemSupplQtyConvFactor = TrnitemSupplQtyConvFactor;
			AmountType _TrnitemExportValue = TrnitemExportValue;
			ConsignmentsType _TrnitemConsNum = TrnitemConsNum;
			CostPrcType _TrnitemUnitPrice = TrnitemUnitPrice;
			CostPrcType _TrnitemUnitCost = TrnitemUnitCost;
			CostPrcType _TrnitemMatlCost = TrnitemMatlCost;
			CostPrcType _TrnitemUnitMatCost = TrnitemUnitMatCost;
			CostPrcType _TrnitemUnitMatCostConv = TrnitemUnitMatCostConv;
			CostPrcType _TrnitemUnitDutyCost = TrnitemUnitDutyCost;
			CostPrcType _TrnitemUnitBrokerageCost = TrnitemUnitBrokerageCost;
			CostPrcType _TrnitemUnitFreightCost = TrnitemUnitFreightCost;
			CostPrcType _TrnitemUnitInsCost = TrnitemUnitInsCost;
			CostPrcType _TrnitemUnitLocFrtCost = TrnitemUnitLocFrtCost;
			CostPrcType _TrnitemLbrCost = TrnitemLbrCost;
			CostPrcType _TrnitemFovhdCost = TrnitemFovhdCost;
			CostPrcType _TrnitemVovhdCost = TrnitemVovhdCost;
			CostPrcType _TrnitemOutCost = TrnitemOutCost;
			FlagNyType _PUpdate = PUpdate;
			ExchRateType _PExchRate = PExchRate;
			CurrCodeType _PCurrCode = PCurrCode;
			FlagNyType _PTextOnly = PTextOnly;
			InfobarType _Infobar = Infobar;
			TransNat2Type _TrnitemTransNat2 = TrnitemTransNat2;
			ListYesNoType _PlanOnSave = PlanOnSave;
			DateType _TrnitemProjectedDate = TrnitemProjectedDate;
			ListYesNoType _TrnitemPreassignLots = TrnitemPreassignLots;
			ListYesNoType _TrnitemPreassignSerials = TrnitemPreassignSerials;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			ListYesNoType _ApsMode = ApsMode;
			VeryLongListType _UETListPairs = UETListPairs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TritmCpSp";
				
				appDB.AddCommandParameter(cmd, "TrnitemTrnNum", _TrnitemTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemTrnLine", _TrnitemTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemQtyReceived", _TrnitemQtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemQtyReq", _TrnitemQtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemQtyShipped", _TrnitemQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemStat", _TrnitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemItem", _TrnitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemSchRcvDate", _TrnitemSchRcvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemShipDate", _TrnitemShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemRcvdDate", _TrnitemRcvdDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemQtyLoss", _TrnitemQtyLoss, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemQtyPacked", _TrnitemQtyPacked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemSchShipDate", _TrnitemSchShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemPickDate", _TrnitemPickDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemQtyReqConv", _TrnitemQtyReqConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUM", _TrnitemUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemTrnLoc", _TrnitemTrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemPricecode", _TrnitemPricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitWeight", _TrnitemUnitWeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFrmRefType", _TrnitemFrmRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemToRefType", _TrnitemToRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFromSite", _TrnitemFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFromWhse", _TrnitemFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemToSite", _TrnitemToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemToWhse", _TrnitemToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemCrossSite", _TrnitemCrossSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemTransNat", _TrnitemTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemDelterm", _TrnitemDelterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemProcessInd", _TrnitemProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemEcCode", _TrnitemEcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemOrigin", _TrnitemOrigin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemCommCode", _TrnitemCommCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemSupplQtyConvFactor", _TrnitemSupplQtyConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemExportValue", _TrnitemExportValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemConsNum", _TrnitemConsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitPrice", _TrnitemUnitPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitCost", _TrnitemUnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemMatlCost", _TrnitemMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitMatCost", _TrnitemUnitMatCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitMatCostConv", _TrnitemUnitMatCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitDutyCost", _TrnitemUnitDutyCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitBrokerageCost", _TrnitemUnitBrokerageCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitFreightCost", _TrnitemUnitFreightCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitInsCost", _TrnitemUnitInsCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemUnitLocFrtCost", _TrnitemUnitLocFrtCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemLbrCost", _TrnitemLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemFovhdCost", _TrnitemFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemVovhdCost", _TrnitemVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemOutCost", _TrnitemOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUpdate", _PUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTextOnly", _PTextOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrnitemTransNat2", _TrnitemTransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanOnSave", _PlanOnSave, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemProjectedDate", _TrnitemProjectedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemPreassignLots", _TrnitemPreassignLots, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnitemPreassignSerials", _TrnitemPreassignSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepFromTrigger", _RepFromTrigger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsMode", _ApsMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UETListPairs", _UETListPairs, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
