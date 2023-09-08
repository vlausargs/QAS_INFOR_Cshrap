//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_UpcomingProductionDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_UpcomingProductionDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_UpcomingProductionDetailSp(
			DateTime? DueDate,
			string Type = "E");
	}
}

