//PROJECT NAME: Config
//CLASS NAME: ICfgRepRemoteConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgRepRemoteConfig
	{
		(int? ReturnCode,
			string Infobar) CfgRepRemoteConfigSp(
			string pFromSite,
			string pFromCoNum,
			int? pFromCoLine,
			int? pFromCoRelease,
			string Infobar);
	}
}

