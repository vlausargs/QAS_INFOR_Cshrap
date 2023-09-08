//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPYield.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPYield
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPYieldSp(
			string begjob = null,
			string endjob = null,
			int? begsuffix = null,
			int? endsuffix = null,
			string BegItem = null,
			string enditem = null,
			DateTime? begjdate = null,
			DateTime? endjdate = null,
			int? DisplayHeader = 0);
	}
}

