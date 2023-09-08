//PROJECT NAME: Data
//CLASS NAME: ITrrcvLcrcpt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITrrcvLcrcpt
	{
		(int? ReturnCode,
			string Infobar) TrrcvLcrcptSp(
			string TrnNum,
			int? TrnLine,
			decimal? TrnitemUnitDutyCost,
			decimal? TrnitemUnitFreightCost,
			decimal? TrnitemUnitBrokerageCost,
			decimal? TrnitemUnitInsuranceCost,
			decimal? TrnitemUnitLocFrtCost,
			DateTime? TTransDate,
			decimal? TrnitemQtyReq,
			decimal? TQtyReceived,
			string TransferDutyVendor,
			string TransferFreightVendor,
			string TransferBrokerageVendor,
			string TransferInsuranceVendor,
			string TransferLocFrtVendor,
			decimal? TExchRate,
			string Infobar);
	}
}

