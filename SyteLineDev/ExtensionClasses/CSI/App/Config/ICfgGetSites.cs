//PROJECT NAME: Config
//CLASS NAME: ICfgGetSites.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgGetSites
	{
		(int? ReturnCode, string FromSite,
		string ToSite,
		string Infobar) CfgGetSitesSp(string RefNum,
		string FromSite,
		string ToSite,
		string Infobar);
	}
}

