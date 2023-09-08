//PROJECT NAME: POS
//CLASS NAME: ISSSPOSConInvSubPrtPay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSConInvSubPrtPay
	{
		(int? ReturnCode,
			string tPrintPosmNum,
			decimal? tPrePaidAmount,
			string InfoBar) SSSPOSConInvSubPrtPaySp(
			string tPrintInvNum,
			int? tTransDomCurr,
			string ParmCurrCode,
			string tPrintPosmNum,
			decimal? tPrePaidAmount,
			string InfoBar);
	}
}

