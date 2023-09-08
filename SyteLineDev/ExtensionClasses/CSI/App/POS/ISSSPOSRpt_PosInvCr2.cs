//PROJECT NAME: POS
//CLASS NAME: ISSSPOSRpt_PosInvCr2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSRpt_PosInvCr2
	{
		int? SSSPOSRpt_PosInvCr2Sp(
			string tPrintInvNum,
			string tPrintPosmNum,
			int? tTransDomCurr,
			string ParmCurrCode);
	}
}

