//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupReadyForReceipts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupReadyForReceipts
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupReadyForReceiptsSp(
			int? showdetail = null,
			int? displayheader = null);
	}
}

