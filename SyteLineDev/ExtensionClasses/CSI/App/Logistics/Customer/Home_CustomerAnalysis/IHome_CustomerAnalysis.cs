//PROJECT NAME: Logistics
//CLASS NAME: IHome_CustomerAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_CustomerAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Home_CustomerAnalysisSp(string FilterString = null,
			string SiteGroup = null,
			string Infobar = null);
	}
}

