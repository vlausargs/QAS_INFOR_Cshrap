//PROJECT NAME: Admin
//CLASS NAME: ICLM_PortalExpiredMessages.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICLM_PortalExpiredMessages
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PortalExpiredMessagesSp(DateTime? BeginDate = null,
		DateTime? EndDate = null,
		string AppName = null,
		string FilterString = null);
	}
}

