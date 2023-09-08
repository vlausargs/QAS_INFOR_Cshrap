//PROJECT NAME: CSIConfig
//CLASS NAME: UpdateCfgStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Config
{
	public interface IUpdateCfgStatus
	{
		int UpdateCfgStatusSp(string ConfigId,
		                      string StatusAttrValue,
		                      string MsgAttrValue,
		                      string QueueIDValue);
	}
	
	public class UpdateCfgStatus : IUpdateCfgStatus
	{
		readonly IApplicationDB appDB;
		
		public UpdateCfgStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int UpdateCfgStatusSp(string ConfigId,
		                             string StatusAttrValue,
		                             string MsgAttrValue,
		                             string QueueIDValue)
		{
			ConfigIdType _ConfigId = ConfigId;
			ConfigAttrValueType _StatusAttrValue = StatusAttrValue;
			ConfigAttrValueType _MsgAttrValue = MsgAttrValue;
			ConfigAttrValueType _QueueIDValue = QueueIDValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateCfgStatusSp";
				
				appDB.AddCommandParameter(cmd, "ConfigId", _ConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatusAttrValue", _StatusAttrValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsgAttrValue", _MsgAttrValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QueueIDValue", _QueueIDValue, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
