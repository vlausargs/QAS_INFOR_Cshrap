//PROJECT NAME: Config
//CLASS NAME: ICfgShipSiteInsert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgShipSiteInsert
	{
		(int? ReturnCode, string Infobar) CfgShipSiteInsertSp(string co_num,
		string co_line,
		string config_type,
		string site,
		string Infobar);
	}
}

