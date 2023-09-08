//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SalespersonForecasts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_SalespersonForecasts
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SalespersonForecastsSP(string SlsMan,
		int? IncludeDirReports,
		string FilterString);
	}
}

