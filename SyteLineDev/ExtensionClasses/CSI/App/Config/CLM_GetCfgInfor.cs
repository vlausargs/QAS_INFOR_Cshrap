//PROJECT NAME: CSIConfig
//CLASS NAME: CLM_GetCfgInf.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Config
{
	public interface ICLM_GetCfgInf
	{
		DataTable CLM_GetCfgInfor(string ConfigId);
	}
	
	public class CLM_GetCfgInf : ICLM_GetCfgInf
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_GetCfgInf(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_GetCfgInfor(string ConfigId)
		{
			ConfigIdType _ConfigId = ConfigId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_GetCfgInfor";
				
				appDB.AddCommandParameter(cmd, "ConfigId", _ConfigId, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
