//PROJECT NAME: Codes
//CLASS NAME: ISiteMgmtProcessAction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ISiteMgmtProcessAction
	{
		(int? ReturnCode, string Infobar) SiteMgmtProcessActionSp(string PSite,
		string PSiteName,
		string PSiteDescription,
		string PSiteType,
		string PSiteTimeZone,
		string PSiteGroup,
		string Infobar);
	}
}

