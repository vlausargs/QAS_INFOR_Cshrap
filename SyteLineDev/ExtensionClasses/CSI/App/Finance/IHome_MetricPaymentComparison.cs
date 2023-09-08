//PROJECT NAME: Finance
//CLASS NAME: IHome_MetricPaymentComparison.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IHome_MetricPaymentComparison
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Home_MetricPaymentComparisonSp(
			string SiteGroup = null);
	}
}

