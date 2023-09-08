//PROJECT NAME: Reporting
//CLASS NAME: IRpt_WBSPercentComplete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_WBSPercentComplete
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_WBSPercentCompleteSp(string WBSNumStarting = null,
		string WBSNumEnding = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

