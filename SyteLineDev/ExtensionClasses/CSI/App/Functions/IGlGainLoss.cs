//PROJECT NAME: Data
//CLASS NAME: IGlGainLoss.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGlGainLoss
	{
		(int? ReturnCode,
			string Infobar) GlGainLossSp(
			decimal? PAmount,
			string PCurrCode,
			string PRef,
			string PId,
			DateTime? PTransDate,
			string PVendNum = null,
			string PInvNum = null,
			string PVoucher = "0",
			int? PCheckNum = 0,
			DateTime? PCheckDate = null,
			string PFromSite = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string Infobar = null,
			decimal? ExchRate = 1M,
			string BankCode = null,
			decimal? ForAmount = null);
	}
}

