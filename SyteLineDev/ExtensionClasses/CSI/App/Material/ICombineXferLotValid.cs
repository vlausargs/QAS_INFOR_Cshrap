//PROJECT NAME: Material
//CLASS NAME: ICombineXferLotValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICombineXferLotValid
	{
		(int? ReturnCode, decimal? TQtyShipped,
		decimal? TQtyOnhand,
		string Infobar) CombineXferLotValidSp(string Whse,
		string Item,
		string Loc,
		string TrnNum,
		int? TrnLine,
		decimal? UomConvFactor,
		string Lot,
		decimal? TQtyShipped,
		decimal? TQtyOnhand,
		string Infobar);
	}
}

