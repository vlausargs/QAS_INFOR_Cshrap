//PROJECT NAME: Admin
//CLASS NAME: ICLM_PortalMultiUserInbox.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICLM_PortalMultiUserInbox
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PortalMultiUserInboxSp(DateTime? BeginDate = null,
		DateTime? EndDate = null,
		string AppName = null,
		int? RowCount = 200,
		string FilterString = null);
	}
}

