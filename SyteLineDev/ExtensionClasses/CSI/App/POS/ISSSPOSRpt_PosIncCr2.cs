//PROJECT NAME: POS
//CLASS NAME: ISSSPOSRpt_PosIncCr2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSRpt_PosIncCr2
	{
		int? SSSPOSRpt_PosIncCr2Sp(
			string tPrintInvNum,
			string tPrintPosmNum,
			int? tTransDomCurr,
			string ParmCurrCode);
	}
}

