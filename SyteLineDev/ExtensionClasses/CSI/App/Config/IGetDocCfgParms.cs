//PROJECT NAME: Config
//CLASS NAME: IGetDocCfgParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface IGetDocCfgParms
	{
		(int? ReturnCode, string DocConfigServerId,
		string DocConfigNameSpace,
		string Configurator,
		string ConfiguratorURL,
		string MetadataInstance,
		string AuthenticationKey) GetDocCfgParmsSp(string DocConfigServerId = "",
		string DocConfigNameSpace = "",
		string Configurator = "",
		string ConfiguratorURL = "",
		string MetadataInstance = "",
		string AuthenticationKey = "",
		string Site = null);
	}
}

