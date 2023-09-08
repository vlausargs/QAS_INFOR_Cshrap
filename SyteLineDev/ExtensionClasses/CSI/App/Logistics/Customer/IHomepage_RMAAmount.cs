//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_RMAAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_RMAAmount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_RMAAmountSp(int? DaysBefore = 30);
	}
}

