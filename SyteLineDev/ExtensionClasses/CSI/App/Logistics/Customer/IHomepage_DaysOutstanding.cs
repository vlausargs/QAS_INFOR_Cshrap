//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_DaysOutstanding.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_DaysOutstanding
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_DaysOutstandingSp();
	}
}

