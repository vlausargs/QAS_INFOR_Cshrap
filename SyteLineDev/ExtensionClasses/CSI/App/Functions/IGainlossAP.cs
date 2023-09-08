//PROJECT NAME: Data
//CLASS NAME: IGainLossAP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGainLossAP
	{
		(int? ReturnCode,
			decimal? rTDomBal,
			decimal? rTForBal,
			decimal? rTGainLoss,
			string rInfobar) GainLossAPSp(
			string pVendNum,
			int? pVoucher,
			string pVendCurrCode,
			int? pUseHistRate,
			DateTime? pPCutoffDate = null,
			string pSite = null,
			int? pCheckNum = 0,
			decimal? rTDomBal = 0,
			decimal? rTForBal = 0,
			decimal? rTGainLoss = 0,
			string rInfobar = null);
	}
}

