//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupItemDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupItemDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupItemDetailSp(
			string begitem = null,
			string enditem = null,
			string begvend = null,
			string endvend = null,
			int? numsamples = null,
			int? printworksheet = null,
			int? displayheader = null,
			int? PrintInternal = null,
			int? PrintExternal = null);
	}
}

