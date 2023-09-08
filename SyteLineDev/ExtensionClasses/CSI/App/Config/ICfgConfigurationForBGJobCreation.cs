//PROJECT NAME: Config
//CLASS NAME: ICfgConfigurationForBGJobCreation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgConfigurationForBGJobCreation
	{
		(int? ReturnCode, int? CreateBGFlag) CfgConfigurationForBGJobCreationSp(string pConfigId,
		int? CreateBGFlag);
	}
}

