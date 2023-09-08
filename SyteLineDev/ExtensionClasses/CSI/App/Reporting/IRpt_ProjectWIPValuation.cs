//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectWIPValuation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectWIPValuation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectWIPValuationSp(string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string ProjNumStarting = null,
		string ProjNumEnding = null,
		string ProjectStatus = null,
		int? DisplayReportHeader = 1,
		string pSite = null);
	}
}

