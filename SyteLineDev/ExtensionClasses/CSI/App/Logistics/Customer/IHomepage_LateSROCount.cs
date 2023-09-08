//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_LateSROCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_LateSROCount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_LateSROCountSp(int? DaysBefore = 30);
	}
}

