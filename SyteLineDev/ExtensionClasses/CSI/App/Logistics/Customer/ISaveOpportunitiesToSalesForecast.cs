//PROJECT NAME: Logistics
//CLASS NAME: ISaveOpportunitiesToSalesForecast.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISaveOpportunitiesToSalesForecast
	{
		(int? ReturnCode, string Infobar) SaveOpportunitiesToSalesForecastSp(string OppList,
		string ForecastId,
		string Infobar);
	}
}

