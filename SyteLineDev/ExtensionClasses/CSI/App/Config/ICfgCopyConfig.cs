//PROJECT NAME: Config
//CLASS NAME: ICfgCopyConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgCopyConfig
	{
		(int? ReturnCode, string Infobar) CfgCopyConfigSp(string pOldConfigID,
		string pNewCoNum,
		int? pNewCoLine,
		int? pNewCoRelease,
		string pNewJob,
		int? pNewSuffix,
		string pNewItem,
		string pNewConfigGid,
		string pConfigurator,
		string Infobar);
	}
}

