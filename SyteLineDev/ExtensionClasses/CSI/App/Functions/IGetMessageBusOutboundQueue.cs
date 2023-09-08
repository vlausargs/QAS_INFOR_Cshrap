//PROJECT NAME: Data
//CLASS NAME: IGetMessageBusOutboundQueue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetMessageBusOutboundQueue
	{
		(int? ReturnCode,
			string MessageBusOutboundQueueName) GetMessageBusOutboundQueueSp(
			string MessageBusOutboundQueueName);
	}
}

