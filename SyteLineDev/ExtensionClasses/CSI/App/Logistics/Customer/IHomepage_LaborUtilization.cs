//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_LaborUtilization.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_LaborUtilization
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_LaborUtilizationSp(int? DaysBefore = 30);
	}
}

