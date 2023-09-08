//PROJECT NAME: Config
//CLASS NAME: ICfgConfigurationIsForBGJobCreation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgConfigurationIsForBGJobCreation
	{
		int? CfgConfigurationIsForBGJobCreationFn(
			string pConfigId);
	}
}

