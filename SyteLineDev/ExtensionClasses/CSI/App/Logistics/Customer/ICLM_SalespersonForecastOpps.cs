//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SalespersonForecastOpps.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_SalespersonForecastOpps
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SalespersonForecastOppsSP(string ForecastId,
			int? IncludeDirReports,
			string FilterString);
	}
}

