//PROJECT NAME: CSIConfig
//CLASS NAME: CfgSetConfigId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public interface ICfgSetConfigId
	{
		(int? ReturnCode, string ConfigGid) CfgSetConfigIdSp(string ConfigEntryPoint,
		string Key1,
		string Key2,
		string Key3,
		string ConfigId,
		string ConfigGid,
		byte? IsDocId = (byte)0);
	}
	
	public class CfgSetConfigId : ICfgSetConfigId
	{
		readonly IApplicationDB appDB;
		
		public CfgSetConfigId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ConfigGid) CfgSetConfigIdSp(string ConfigEntryPoint,
		string Key1,
		string Key2,
		string Key3,
		string ConfigId,
		string ConfigGid,
		byte? IsDocId = (byte)0)
		{
			LongListType _ConfigEntryPoint = ConfigEntryPoint;
			LongListType _Key1 = Key1;
			LongListType _Key2 = Key2;
			LongListType _Key3 = Key3;
			ConfigIdType _ConfigId = ConfigId;
			ConfigGIDType _ConfigGid = ConfigGid;
			ListYesNoType _IsDocId = IsDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgSetConfigIdSp";
				
				appDB.AddCommandParameter(cmd, "ConfigEntryPoint", _ConfigEntryPoint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Key1", _Key1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Key2", _Key2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Key3", _Key3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfigId", _ConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfigGid", _ConfigGid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsDocId", _IsDocId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ConfigGid = _ConfigGid;
				
				return (Severity, ConfigGid);
			}
		}
	}
}
