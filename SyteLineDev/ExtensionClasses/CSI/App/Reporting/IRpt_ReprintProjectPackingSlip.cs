//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ReprintProjectPackingSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ReprintProjectPackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ReprintProjectPackingSlipSp(int? start_slip_num = null,
		int? end_slip_num = null,
		int? pr_serial = null,
		int? ShowProject = null,
		int? ShowResource = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

