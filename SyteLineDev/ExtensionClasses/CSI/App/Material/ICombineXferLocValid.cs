//PROJECT NAME: Material
//CLASS NAME: ICombineXferLocValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICombineXferLocValid
	{
		(int? ReturnCode, decimal? TQtyShipped,
		decimal? TQtyOnhand,
		string Lot,
		string Infobar,
		string ImportDocId) CombineXferLocValidSp(string Whse,
		string Item,
		string Loc,
		string TrnNum,
		int? TrnLine,
		decimal? UomConvFactor,
		decimal? TQtyShipped,
		decimal? TQtyOnhand,
		string Lot,
		string Infobar,
		string ImportDocId);
	}
}

