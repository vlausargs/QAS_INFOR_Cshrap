//PROJECT NAME: CSIConfig
//CLASS NAME: GetQueueConfiguration.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Config
{
	public interface IGetQueueConfiguration
	{
		int GetQueueConfigurationSp(string ConfigId,
		                            ref string QueuePostConfiguration,
		                            ref string QueuePostConfigurationMessage,
		                            ref string QueueRequestID,
		                            ref string QueueStatus,
		                            ref string QueueType);
	}
	
	public class GetQueueConfiguration : IGetQueueConfiguration
	{
		readonly IApplicationDB appDB;
		
		public GetQueueConfiguration(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetQueueConfigurationSp(string ConfigId,
		                                   ref string QueuePostConfiguration,
		                                   ref string QueuePostConfigurationMessage,
		                                   ref string QueueRequestID,
		                                   ref string QueueStatus,
		                                   ref string QueueType)
		{
			ConfigIdType _ConfigId = ConfigId;
			ConfigAttrValueType _QueuePostConfiguration = QueuePostConfiguration;
			ConfigAttrValueType _QueuePostConfigurationMessage = QueuePostConfigurationMessage;
			ConfigAttrValueType _QueueRequestID = QueueRequestID;
			ConfigAttrValueType _QueueStatus = QueueStatus;
			ConfigAttrValueType _QueueType = QueueType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetQueueConfigurationSp";
				
				appDB.AddCommandParameter(cmd, "ConfigId", _ConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QueuePostConfiguration", _QueuePostConfiguration, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QueuePostConfigurationMessage", _QueuePostConfigurationMessage, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QueueRequestID", _QueueRequestID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QueueStatus", _QueueStatus, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QueueType", _QueueType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QueuePostConfiguration = _QueuePostConfiguration;
				QueuePostConfigurationMessage = _QueuePostConfigurationMessage;
				QueueRequestID = _QueueRequestID;
				QueueStatus = _QueueStatus;
				QueueType = _QueueType;
				
				return Severity;
			}
		}
	}
}
