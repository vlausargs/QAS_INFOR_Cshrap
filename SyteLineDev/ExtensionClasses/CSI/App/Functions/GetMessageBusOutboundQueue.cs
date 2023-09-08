//PROJECT NAME: Data
//CLASS NAME: GetMessageBusOutboundQueue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetMessageBusOutboundQueue : IGetMessageBusOutboundQueue
	{
		readonly IApplicationDB appDB;
		
		public GetMessageBusOutboundQueue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string MessageBusOutboundQueueName) GetMessageBusOutboundQueueSp(
			string MessageBusOutboundQueueName)
		{
			QueueNameType _MessageBusOutboundQueueName = MessageBusOutboundQueueName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetMessageBusOutboundQueueSp";
				
				appDB.AddCommandParameter(cmd, "MessageBusOutboundQueueName", _MessageBusOutboundQueueName, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MessageBusOutboundQueueName = _MessageBusOutboundQueueName;
				
				return (Severity, MessageBusOutboundQueueName);
			}
		}
	}
}
