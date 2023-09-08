//PROJECT NAME: Admin
//CLASS NAME: ICLM_PortalPendingApproval.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICLM_PortalPendingApproval
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PortalPendingApprovalSp(DateTime? BeginDate = null,
		DateTime? EndDate = null,
		string AppName = null,
		string FilterString = null);
	}
}

