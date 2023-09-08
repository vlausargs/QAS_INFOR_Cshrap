//PROJECT NAME: Codes
//CLASS NAME: IGetPortalAlertParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetPortalAlertParms
	{
		(int? ReturnCode, string SiteRef,
		string Infobar,
		int? UsePortalEmail,
		string AdminUser,
		string PortalURL,
		int? LocaleID) GetPortalAlertParmsSp(string PortalType = null,
		string SiteRef = null,
		string Infobar = null,
		int? UsePortalEmail = 0,
		string AdminUser = null,
		string PortalURL = null,
		int? LocaleID = null);
	}
}

