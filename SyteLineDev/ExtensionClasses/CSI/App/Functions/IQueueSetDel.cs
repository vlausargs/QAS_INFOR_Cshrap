//PROJECT NAME: Data
//CLASS NAME: IQueueSetDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IQueueSetDel
	{
		int? QueueSetDelSP(
			string Class,
			string strCategory);
	}
}

