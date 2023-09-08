//PROJECT NAME: Data
//CLASS NAME: IReceivingTrxLC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IReceivingTrxLC
	{
		(int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			decimal? OldControlNumber,
			string Infobar) ReceivingTrxLCSp(
			string Mode,
			decimal? MatltranTransNum,
			string Num,
			int? Line,
			int? Release = 0,
			string Reference = null,
			DateTime? TransDate = null,
			int? Return = null,
			decimal? Qty = null,
			decimal? Material = null,
			decimal? Duty = null,
			decimal? Freight = null,
			decimal? Brokerage = null,
			decimal? Insurance = null,
			decimal? LocFrt = null,
			string DutyCurrCode = null,
			string FreightCurrCode = null,
			string BrokerageCurrCode = null,
			string InsuranceCurrCode = null,
			string LocFrtCurrCode = null,
			decimal? DutyExchRate = null,
			decimal? FreightExchRate = null,
			decimal? BrokerageExchRate = null,
			decimal? InsuranceExchRate = null,
			decimal? LocFrtExchRate = null,
			decimal? AmountPosted = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			decimal? OldControlNumber = null,
			string Infobar = null,
			string DutyVendNum = null,
			string FreightVendNum = null,
			string BrokerageVendNum = null,
			string InsuranceVendNum = null,
			string LocFrtVendNum = null);
	}
}

