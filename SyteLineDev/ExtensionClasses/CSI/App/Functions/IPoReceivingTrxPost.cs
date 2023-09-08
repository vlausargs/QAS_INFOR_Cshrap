//PROJECT NAME: Data
//CLASS NAME: IPoReceivingTrxPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoReceivingTrxPost
	{
		(int? ReturnCode,
			int? GRNExists,
			int? GrnLine,
			string Infobar) PoReceivingTrxPostSp(
			DateTime? TransDate,
			string Whse,
			string PoNum,
			int? PoLine,
			int? PoRelease,
			decimal? QtyToReceive,
			decimal? QtyToReject,
			string Tran1UM = null,
			int? Return = null,
			string EcCode = null,
			int? HaveItem = null,
			string Item = null,
			string Loc = null,
			string Lot = null,
			string ReasonCode = null,
			decimal? Cost = null,
			decimal? Material = null,
			decimal? Duty = null,
			decimal? Freight = null,
			decimal? Brokerage = null,
			decimal? Insurance = null,
			decimal? LocFrt = null,
			decimal? TranCost = null,
			decimal? TranMaterial = null,
			decimal? TranDuty = null,
			decimal? TranFreight = null,
			decimal? TranBrokerage = null,
			decimal? TranInsurance = null,
			decimal? TranLocFrt = null,
			decimal? FreightExchRate = 1M,
			decimal? DutyExchRate = 1M,
			decimal? BrokerageExchRate = 1M,
			decimal? InsuranceExchRate = 1M,
			decimal? LocFrtExchRate = 1M,
			int? Consign = null,
			string PackNum = "0",
			string WorkKey = null,
			int? GRNExists = 0,
			string GrnNum = null,
			int? GrnLine = 0,
			string Infobar = null,
			string ImportDocId = null,
			decimal? TaxAmount = null,
			decimal? TaxAmountConv = null,
			string EmpNum = null,
			string ManufacturerId = null,
			string ManufacturerItem = null,
			string ContainerNum = null,
			string VendInvNum = null,
			decimal? UserID = null,
			string CallFrom = null,
			string DocumentNum = null);
	}
}

