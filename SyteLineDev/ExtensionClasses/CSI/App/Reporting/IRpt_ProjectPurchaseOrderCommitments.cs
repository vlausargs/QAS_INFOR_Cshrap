//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectPurchaseOrderCommitments.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectPurchaseOrderCommitments
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectPurchaseOrderCommitmentsSp(string ProjNumStarting = null,
		string ProjNumEnding = null,
		int? TaskNumStarting = null,
		int? TaskNumEnding = null,
		string ProjectStatus = null,
		string POLineResStatus = null,
		string JobStarting = null,
		string JobEnding = null,
		int? JobStartSuffix = null,
		int? JobEndSuffix = null,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

