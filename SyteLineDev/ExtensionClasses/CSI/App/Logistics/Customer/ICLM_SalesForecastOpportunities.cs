//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SalesForecastOpportunities.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_SalesForecastOpportunities
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_SalesForecastOpportunitiesSp(string Slsman,
		string SalesPeriodId,
		string Infobar);
	}
}

