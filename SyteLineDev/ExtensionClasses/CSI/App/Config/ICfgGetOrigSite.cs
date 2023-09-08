//PROJECT NAME: Config
//CLASS NAME: ICfgGetOrigSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgGetOrigSite
	{
		(int? ReturnCode, string OrigSite,
		string Infobar) CfgGetOrigSiteSp(string CoNum,
		string OrigSite,
		string Infobar);
	}
}

