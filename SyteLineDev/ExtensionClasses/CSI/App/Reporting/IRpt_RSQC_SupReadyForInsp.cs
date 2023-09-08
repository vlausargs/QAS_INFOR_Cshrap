//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupReadyForInsp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupReadyForInsp
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupReadyForInspSp(
			int? showdetail = null,
			int? openreconly = null,
			int? displayheader = null);
	}
}

