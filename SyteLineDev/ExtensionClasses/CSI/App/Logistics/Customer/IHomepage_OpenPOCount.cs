//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_OpenPOCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_OpenPOCount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_OpenPOCountSp(int? DaysBefore = 0, int? CountAtLineLevel = 0);
	}
}

