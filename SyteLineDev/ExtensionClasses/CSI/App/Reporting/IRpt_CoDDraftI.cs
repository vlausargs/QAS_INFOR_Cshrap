//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CoDDraftI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CoDDraftI
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CoDDraftISp(
			string InvCred = null,
			string pInvHdrInvNum = null,
			string pInvHdrCoNum = null,
			string pVoidOrDraft = null,
			string BGSessionId = null,
			string pSite = null);
	}
}

