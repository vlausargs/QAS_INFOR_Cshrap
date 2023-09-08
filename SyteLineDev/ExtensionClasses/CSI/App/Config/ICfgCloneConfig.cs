//PROJECT NAME: Config
//CLASS NAME: ICfgCloneConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgCloneConfig
	{
		(int? ReturnCode,
			string pNewConfigGID,
			string Infobar) CfgCloneConfigSp(
			string pNewConfigID,
			string pOldConfigGID,
			string pNewConfigGID,
			string Infobar);
	}
}

