//PROJECT NAME: Material
//CLASS NAME: IItemVl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemVl
	{
		(int? ReturnCode, decimal? PQty,
		string Infobar) ItemVlSp(string PSite,
		string PWhse,
		string PItem,
		string PTrnLoc,
		string PTrnLot,
		int? PReturn,
		decimal? PQty,
		string Infobar);
	}
}

