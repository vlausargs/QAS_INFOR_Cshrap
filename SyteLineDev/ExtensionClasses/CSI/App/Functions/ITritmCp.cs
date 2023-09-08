//PROJECT NAME: Data
//CLASS NAME: ITritmCp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITritmCp
	{
		(int? ReturnCode,
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
			string UETListPairs = null);
	}
}

