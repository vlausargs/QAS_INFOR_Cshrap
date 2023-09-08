//PROJECT NAME: Data
//CLASS NAME: IGetNegShipmentQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetNegShipmentQty
	{
		decimal? GetNegShipmentQtyFn(
			string CoNum,
			int? CoLine,
			int? CoRelease);
	}
}

