//PROJECT NAME: Config
//CLASS NAME: CfgConfigurationForBGJobCreation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgConfigurationForBGJobCreation : ICfgConfigurationForBGJobCreation
	{
		readonly IApplicationDB appDB;
		
		
		public CfgConfigurationForBGJobCreation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CreateBGFlag) CfgConfigurationForBGJobCreationSp(string pConfigId,
		int? CreateBGFlag)
		{
			ConfigIdType _pConfigId = pConfigId;
			ListYesNoType _CreateBGFlag = CreateBGFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgConfigurationForBGJobCreationSp";
				
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateBGFlag", _CreateBGFlag, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CreateBGFlag = _CreateBGFlag;
				
				return (Severity, CreateBGFlag);
			}
		}
	}
}
