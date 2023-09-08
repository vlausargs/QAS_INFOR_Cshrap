//PROJECT NAME: Material
//CLASS NAME: IItemFl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemFl
	{
		(int? ReturnCode, string PTrnLot,
		decimal? PUomConvFactor,
		decimal? PQty,
		string Infobar) ItemFlSp(string PSite,
		string PWhse,
		string PItem,
		string PTrnLoc,
		string PTrnNum,
		int? PTrnLine,
		string PTrnLot,
		decimal? PUomConvFactor,
		decimal? PQty,
		string Infobar);
	}
}

