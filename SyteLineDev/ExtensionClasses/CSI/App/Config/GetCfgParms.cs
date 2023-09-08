//PROJECT NAME: CSIConfig
//CLASS NAME: GetCfgParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public interface IGetCfgParms
	{
		(int? ReturnCode, string ConfigServerId, string ConfigHeaderNameSpace, string Configurator, string ConfiguratorURL, string MetadataInstance, string AuthenticationKey) GetCfgParmsSp(string ConfigServerId = "",
		string ConfigHeaderNameSpace = "",
		string Configurator = "",
		string ConfiguratorURL = "",
		string MetadataInstance = "",
		string AuthenticationKey = "",
		string Site = null);
	}
	
	public class GetCfgParms : IGetCfgParms
	{
		readonly IApplicationDB appDB;
		
		public GetCfgParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ConfigServerId, string ConfigHeaderNameSpace, string Configurator, string ConfiguratorURL, string MetadataInstance, string AuthenticationKey) GetCfgParmsSp(string ConfigServerId = "",
		string ConfigHeaderNameSpace = "",
		string Configurator = "",
		string ConfiguratorURL = "",
		string MetadataInstance = "",
		string AuthenticationKey = "",
		string Site = null)
		{
			ConfiguratorServerIdType _ConfigServerId = ConfigServerId;
			ConfigNameSpaceType _ConfigHeaderNameSpace = ConfigHeaderNameSpace;
			ConfiguratorType _Configurator = Configurator;
			URLType _ConfiguratorURL = ConfiguratorURL;
			OSLocationType _MetadataInstance = MetadataInstance;
			ConfiguratorAuthKeyType _AuthenticationKey = AuthenticationKey;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCfgParmsSp";
				
				appDB.AddCommandParameter(cmd, "ConfigServerId", _ConfigServerId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConfigHeaderNameSpace", _ConfigHeaderNameSpace, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Configurator", _Configurator, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConfiguratorURL", _ConfiguratorURL, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MetadataInstance", _MetadataInstance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AuthenticationKey", _AuthenticationKey, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ConfigServerId = _ConfigServerId;
				ConfigHeaderNameSpace = _ConfigHeaderNameSpace;
				Configurator = _Configurator;
				ConfiguratorURL = _ConfiguratorURL;
				MetadataInstance = _MetadataInstance;
				AuthenticationKey = _AuthenticationKey;
				
				return (Severity, ConfigServerId, ConfigHeaderNameSpace, Configurator, ConfiguratorURL, MetadataInstance, AuthenticationKey);
			}
		}
	}
}
