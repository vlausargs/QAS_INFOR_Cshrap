//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_TimePhasedItemQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_TimePhasedItemQty
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Homepage_TimePhasedItemQtySp(
			string Item,
			string Whse);
	}
}

