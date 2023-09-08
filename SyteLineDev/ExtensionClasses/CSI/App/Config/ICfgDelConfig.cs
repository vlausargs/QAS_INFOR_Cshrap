//PROJECT NAME: Config
//CLASS NAME: ICfgDelConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgDelConfig
	{
		(int? ReturnCode,
			string Infobar) CfgDelConfigSp(
			string pDeleteFrom,
			string pConfigId,
			string Infobar);
	}
}

