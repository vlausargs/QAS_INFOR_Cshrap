//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_POCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_POCount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_POCountSp(int? DaysBefore = 0, string PoStat = null);
	}
}

