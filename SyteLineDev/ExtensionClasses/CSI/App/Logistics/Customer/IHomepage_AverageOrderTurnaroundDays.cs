//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_AverageOrderTurnaroundDays.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_AverageOrderTurnaroundDays
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_AverageOrderTurnaroundDaysSp(int? DaysBefore = 30);
	}
}

