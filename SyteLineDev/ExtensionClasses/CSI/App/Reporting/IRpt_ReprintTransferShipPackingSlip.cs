//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ReprintTransferShipPackingSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ReprintTransferShipPackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ReprintTransferShipPackingSlipSp(int? slip_num = null,
		int? ShowTrans = null,
		int? ShowLine = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

