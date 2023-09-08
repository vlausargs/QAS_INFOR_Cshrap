//PROJECT NAME: Production
//CLASS NAME: IRSQC_CLM_SupVendorPerformance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CLM_SupVendorPerformance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_CLM_SupVendorPerformanceSp(string TVendNum = null,
		string TItem = null,
		DateTime? begtdate = null,
		DateTime? endtdate = null);
	}
}

