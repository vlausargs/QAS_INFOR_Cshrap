//PROJECT NAME: Config
//CLASS NAME: GetDocCfgParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class GetDocCfgParms : IGetDocCfgParms
	{
		readonly IApplicationDB appDB;
		
		
		public GetDocCfgParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string DocConfigServerId,
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
		string Site = null)
		{
			ConfiguratorServerIdType _DocConfigServerId = DocConfigServerId;
			ConfigNameSpaceType _DocConfigNameSpace = DocConfigNameSpace;
			ConfiguratorType _Configurator = Configurator;
			URLType _ConfiguratorURL = ConfiguratorURL;
			OSLocationType _MetadataInstance = MetadataInstance;
			ConfiguratorAuthKeyType _AuthenticationKey = AuthenticationKey;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDocCfgParmsSp";
				
				appDB.AddCommandParameter(cmd, "DocConfigServerId", _DocConfigServerId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocConfigNameSpace", _DocConfigNameSpace, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Configurator", _Configurator, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConfiguratorURL", _ConfiguratorURL, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MetadataInstance", _MetadataInstance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AuthenticationKey", _AuthenticationKey, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DocConfigServerId = _DocConfigServerId;
				DocConfigNameSpace = _DocConfigNameSpace;
				Configurator = _Configurator;
				ConfiguratorURL = _ConfiguratorURL;
				MetadataInstance = _MetadataInstance;
				AuthenticationKey = _AuthenticationKey;
				
				return (Severity, DocConfigServerId, DocConfigNameSpace, Configurator, ConfiguratorURL, MetadataInstance, AuthenticationKey);
			}
		}
	}
}
