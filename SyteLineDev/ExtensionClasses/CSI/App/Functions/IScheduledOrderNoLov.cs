//PROJECT NAME: Data
//CLASS NAME: IScheduledOrderNoLov.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IScheduledOrderNoLov
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ScheduledOrderNoLovSp(
			string OrderNo = null,
			string OrderCode = null);
	}
}

