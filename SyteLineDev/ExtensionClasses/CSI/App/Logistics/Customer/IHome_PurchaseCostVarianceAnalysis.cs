//PROJECT NAME: Logistics
//CLASS NAME: IHome_PurchaseCostVarianceAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_PurchaseCostVarianceAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_PurchaseCostVarianceAnalysisSp(string FilterString = null,
		string SiteGroup = null);
	}
}

