//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_VoucheredPOLinesCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_VoucheredPOLinesCount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_VoucheredPOLinesCountSp(int? DaysBefore = 0, string VendNum = null);
	}
}

