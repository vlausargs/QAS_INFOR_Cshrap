//PROJECT NAME: Material
//CLASS NAME: IItemVlValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemVlValid
	{
		(int? ReturnCode, decimal? PQty,
		string Infobar) ItemVlValidSp(string PWhse,
		string PItem,
		string PTrnLoc,
		string PTrnLot,
		int? PReturn,
		decimal? PQty,
		string Infobar,
		int? UseSite = 0,
		string Site = null);
	}
}

