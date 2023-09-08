//PROJECT NAME: Codes
//CLASS NAME: ISiteMgmtNotify.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ISiteMgmtNotify
	{
		int? SiteMgmtNotifySp(string PSite,
		int? PSuccess,
		string PErrorMsg,
		string PUsername,
		string PNotificationEmailAddress,
		string PQueueSite);
	}
}

