//PROJECT NAME: Data
//CLASS NAME: IAutoShipCoFromPo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAutoShipCoFromPo
	{
		(int? ReturnCode,
			string Infobar) AutoShipCoFromPoSp(
			string DemandingPO,
			int? PoLine,
			int? PoRelease,
			string Loc,
			string Lot,
			decimal? Qty,
			decimal? QtyConv,
			string Infobar,
			DateTime? TransDate);
	}
}

