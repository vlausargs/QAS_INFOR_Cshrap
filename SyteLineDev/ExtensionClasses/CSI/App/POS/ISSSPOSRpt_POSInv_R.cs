//PROJECT NAME: POS
//CLASS NAME: ISSSPOSRpt_POSInv_R.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSRpt_POSInv_R
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSPOSRpt_POSInv_RSp(
			string tPrintInvNum,
			string tPrintPosmNum,
			int? tTransDomCurr,
			string ParmCurrCode);
	}
}

