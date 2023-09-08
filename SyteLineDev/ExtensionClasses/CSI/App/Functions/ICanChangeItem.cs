//PROJECT NAME: Data
//CLASS NAME: ICanChangeItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICanChangeItem
	{
		int? CanChangeItemFn(
			string CoNum,
			int? CoLine,
			string Status,
			decimal? QtyConv,
			string Table);
	}
}

