//PROJECT NAME: Material
//CLASS NAME: IGetItemMatlTrackQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetItemMatlTrackQty
	{
		(int? ReturnCode, decimal? PQty,
		decimal? PQtyConv,
		string Infobar,
		decimal? PQtyWithOutLotConv) GetItemMatlTrackQtySp(string PItem,
		string PUM,
		string PRefType,
		string PRefNum = null,
		int? PRefLineSuf = null,
		int? PRefRelease = null,
		string PWhse = null,
		string PLoc = null,
		string PLot = null,
		decimal? PQty = null,
		decimal? PQtyConv = null,
		string Infobar = null,
		decimal? PQtyWithOutLotConv = null);
	}
}

