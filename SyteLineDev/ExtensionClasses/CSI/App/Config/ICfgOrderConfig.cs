//PROJECT NAME: Config
//CLASS NAME: ICfgOrderConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgOrderConfig
	{
		(int? ReturnCode,
			string Infobar) CfgOrderConfigSp(
			string pConfigId,
			string Infobar);
	}
}

