//PROJECT NAME: Codes
//CLASS NAME: ISiteMgmtValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ISiteMgmtValidate
	{
		(int? ReturnCode, string Infobar,
		string PUsername,
		string PQueueSite) SiteMgmtValidateSp(string PSite,
		string PNotificationEmailAddress,
		string SiteManagementAction,
		string Infobar,
		string PUsername,
		string PQueueSite);
	}
}

