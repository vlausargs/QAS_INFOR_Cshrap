//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_PercentofMargin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_PercentofMargin
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_PercentofMarginSp(int? DaysBefore = 30);
	}
}

