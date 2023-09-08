//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_PastDueDatePO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_PastDueDatePO
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_PastDueDatePOSp(int? IsPastDueDatePO = 0);
	}
}

