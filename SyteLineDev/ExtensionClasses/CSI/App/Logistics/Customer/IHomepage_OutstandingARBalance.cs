//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_OutstandingARBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_OutstandingARBalance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_OutstandingARBalanceSp(int? DaysBefore = 30, string CustNum = null);
	}
}

