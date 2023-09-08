//PROJECT NAME: Codes
//CLASS NAME: ISiteMgmtAddSiteResponse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ISiteMgmtAddSiteResponse
	{
		(int? ReturnCode, string Infobar) SiteMgmtAddSiteResponseSp(string PSite,
		string PStatus,
		string Infobar,
		int? CalledFromTMS = 0);
	}
}

