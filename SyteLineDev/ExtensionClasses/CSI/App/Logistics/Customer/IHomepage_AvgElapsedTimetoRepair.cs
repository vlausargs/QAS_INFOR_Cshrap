//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_AvgElapsedTimetoRepair.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_AvgElapsedTimetoRepair
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_AvgElapsedTimetoRepairSp(int? DaysBefore = 30);
	}
}

