//PROJECT NAME: Data
//CLASS NAME: IHasPoReceived.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHasPoReceived
	{
		int? HasPoReceivedFn(
			string PoNum);
	}
}

