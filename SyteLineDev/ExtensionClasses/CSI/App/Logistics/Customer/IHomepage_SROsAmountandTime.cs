//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_SROsAmountandTime.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_SROsAmountandTime
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Homepage_SROsAmountandTimeSp(
			int? MonthCount = 6,
			string DisplayCategory = "A");
	}
}

