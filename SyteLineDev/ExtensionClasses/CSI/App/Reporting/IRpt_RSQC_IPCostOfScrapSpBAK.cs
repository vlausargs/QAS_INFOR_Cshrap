//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPCostOfScrapSpBAK.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPCostOfScrapSpBAK
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPCostOfScrapSpBAKSp(
			string BegItem = null,
			string EndItem = null,
			string begjob = null,
			string endjob = null,
			DateTime? begtdate = null,
			DateTime? endtdate = null,
			string begreason = null,
			string endreason = null,
			int? DisplayHeader = 0);
	}
}

