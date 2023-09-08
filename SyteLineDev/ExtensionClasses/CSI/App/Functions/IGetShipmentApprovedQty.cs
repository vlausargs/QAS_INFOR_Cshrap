//PROJECT NAME: Data
//CLASS NAME: IGetShipmentApprovedQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetShipmentApprovedQty
	{
		decimal? GetShipmentApprovedQtyFn(
			string CoNum,
			int? CoLine,
			int? CoRelease);
	}
}

