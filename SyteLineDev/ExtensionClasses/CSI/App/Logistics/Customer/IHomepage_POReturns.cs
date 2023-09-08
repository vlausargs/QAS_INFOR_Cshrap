//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_POReturns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_POReturns
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_POReturnsSp(int? MonthCount = 6, string VendNum = null);
	}
}

