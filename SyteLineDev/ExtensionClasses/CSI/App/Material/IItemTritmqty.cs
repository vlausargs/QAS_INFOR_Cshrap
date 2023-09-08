//PROJECT NAME: Material
//CLASS NAME: IItemTritmqty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemTritmqty
	{
		(int? ReturnCode, string Infobar) ItemTritmqtySp(string PItem,
		decimal? PQty,
		string Infobar,
		string PSite = null);
	}
}

