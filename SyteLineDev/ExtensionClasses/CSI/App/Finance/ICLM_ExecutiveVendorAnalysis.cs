//PROJECT NAME: Finance
//CLASS NAME: ICLM_ExecutiveVendorAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_ExecutiveVendorAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutiveVendorAnalysisSp(string FilterString = null,
		string SiteGroup = null);
	}
}

