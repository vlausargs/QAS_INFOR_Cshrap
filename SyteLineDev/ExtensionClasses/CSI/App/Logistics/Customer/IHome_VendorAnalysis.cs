//PROJECT NAME: Logistics
//CLASS NAME: IHome_VendorAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_VendorAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_VendorAnalysisSp(string FilterString = null,
		string SiteGroup = null);
	}
}

