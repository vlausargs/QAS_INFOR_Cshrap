//PROJECT NAME: Data
//CLASS NAME: IJobOrdersEnableItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobOrdersEnableItem
	{
		int? JobOrdersEnableItemFn(
			string Stat,
			string Job,
			int? Suffix);
	}
}

