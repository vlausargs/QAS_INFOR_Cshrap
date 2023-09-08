//PROJECT NAME: Config
//CLASS NAME: CfgStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgStatus : ICfgStatus
	{
		readonly IApplicationDB appDB;
		
		public CfgStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CfgStatusFn(
			string pConfigId)
		{
			ConfigIdType _pConfigId = pConfigId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CfgStatus](@pConfigId)";
				
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
