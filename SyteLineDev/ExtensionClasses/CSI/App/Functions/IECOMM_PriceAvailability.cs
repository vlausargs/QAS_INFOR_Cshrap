//PROJECT NAME: Data
//CLASS NAME: IECOMM_PriceAvailability.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IECOMM_PriceAvailability
	{
		(int? ReturnCode,
			decimal? QuantityAvailable,
			decimal? Price,
			string Infobar) ECOMM_PriceAvailabilitySp(
			string CustomerNumber,
			int? ShipToNumber,
			int? DefaultWhseOnly,
			string Item,
			decimal? OrderQty,
			int? CalculatePrices,
			string UnitOfMeasure,
			string Warehouse,
			decimal? QuantityAvailable,
			decimal? Price,
			string Infobar);
	}
}

