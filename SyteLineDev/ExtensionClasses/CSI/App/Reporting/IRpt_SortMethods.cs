//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SortMethods.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_SortMethods
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SortMethodsSp(string ReportID = null,
		string ReportType = "M",
		string SiteGroup = null,
		int? AcctDetail = 0,
		int? Unit1Detail = 0,
		int? Unit2Detail = 0,
		int? Unit3Detail = 0,
		int? Unit4Detail = 0,
		string SAcctUnit1 = null,
		string SAcctUnit2 = null,
		string SAcctUnit3 = null,
		string SAcctUnit4 = null,
		string EAcctUnit1 = null,
		string EAcctUnit2 = null,
		string EAcctUnit3 = null,
		string EAcctUnit4 = null,
		int? AcctSort__1 = 0,
		int? AcctSort__2 = 0,
		int? AcctSort__3 = 0,
		int? AcctSort__4 = 0,
		int? AcctSort__5 = 0,
		string pSite = null,
		string BGUser = null);
	}
}

