//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_RequisitionCountbyStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_RequisitionCountbyStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_RequisitionCountbyStatusSp(int? DaysBefore = 0, string Item = null);
	}
}

