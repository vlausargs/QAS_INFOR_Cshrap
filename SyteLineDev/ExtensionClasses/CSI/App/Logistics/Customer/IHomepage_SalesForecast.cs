//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_SalesForecast.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_SalesForecast
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_SalesForecastSp(string Salesperson = null,
			int? IncludeDirectReports = 1,
			string SalesPeriod = null);
	}
}

