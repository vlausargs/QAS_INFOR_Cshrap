//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_MeanTimetoRepair.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_MeanTimetoRepair
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_MeanTimetoRepairSp(int? DaysBefore = 30);
	}
}

