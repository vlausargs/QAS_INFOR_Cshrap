//PROJECT NAME: Data
//CLASS NAME: IPoReceivingTrxVariances.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoReceivingTrxVariances
	{
		(int? ReturnCode,
			decimal? BalAdj,
			string Infobar,
			Guid? PeriodsRowPointer,
			decimal? NewPoitemVoucherCostValue) PoReceivingTrxVariancesSp(
			Guid? PPoitemRowPointer,
			string VendNum,
			DateTime? PostDate,
			decimal? ExchRate,
			string CurrCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			decimal? BalAdj = 0,
			string Infobar = null,
			string DocumentNum = null,
			decimal? DiffCurrencyRate = null,
			Guid? PeriodsRowPointer = null,
			int? FeatureRS8518_2Active = null,
			int? PolandEnabled = null,
			int? SkipPoitemVoucherCostUpdate = 0,
			decimal? NewPoitemVoucherCostValue = null,
			DateTime? NewPoitemRcvdDateValue = null);
	}
}

