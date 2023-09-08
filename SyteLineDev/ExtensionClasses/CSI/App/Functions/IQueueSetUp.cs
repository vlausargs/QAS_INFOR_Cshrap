//PROJECT NAME: Data
//CLASS NAME: IQueueSetUp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IQueueSetUp
	{
		int? QueueSetUpSP(
			string Class,
			string QueueType,
			string strCategory);
	}
}

