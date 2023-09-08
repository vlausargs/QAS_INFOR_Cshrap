//PROJECT NAME: Data
//CLASS NAME: IItemECNTracked.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemECNTracked
	{
		int? ItemECNTrackedFn(
			string Item);
	}
}

