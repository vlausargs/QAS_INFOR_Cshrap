//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_SROAwaiting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_SROAwaiting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_SROAwaitingSp(int? DaysBefore = 30);
	}
}

