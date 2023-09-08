//PROJECT NAME: Codes
//CLASS NAME: ISiteMgmtAddSiteCleanup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ISiteMgmtAddSiteCleanup
	{
		(int? ReturnCode, string Infobar) SiteMgmtAddSiteCleanupSp(string PSite,
		string Infobar);
	}
}

