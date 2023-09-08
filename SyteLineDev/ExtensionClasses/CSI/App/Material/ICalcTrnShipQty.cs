//PROJECT NAME: Material
//CLASS NAME: ICalcTrnShipQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICalcTrnShipQty
	{
		(int? ReturnCode, decimal? QtyToShip,
		decimal? QtyOnHandConv,
		decimal? QtyOnHand,
		string Infobar) CalcTrnShipQtySp(string TrnNum,
		int? TrnLine,
		string Item,
		string Whse,
		string Lot,
		string Loc,
		decimal? UmConvFactor,
		decimal? QtyToShip,
		decimal? QtyOnHandConv,
		decimal? QtyOnHand,
		string Infobar,
		string ImportDocId);
	}
}

