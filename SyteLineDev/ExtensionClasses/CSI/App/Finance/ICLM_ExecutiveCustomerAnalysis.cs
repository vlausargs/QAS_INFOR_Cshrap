//PROJECT NAME: Finance
//CLASS NAME: ICLM_ExecutiveCustomerAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_ExecutiveCustomerAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutiveCustomerAnalysisSp(string FilterString = null,
		string SiteGroup = null);
	}
}

