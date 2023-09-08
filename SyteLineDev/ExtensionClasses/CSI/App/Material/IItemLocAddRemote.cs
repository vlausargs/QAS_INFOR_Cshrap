//PROJECT NAME: Material
//CLASS NAME: IItemLocAddRemote.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemLocAddRemote
	{
		(int? ReturnCode, Guid? RowPointer,
		string Infobar) ItemLocAddRemoteSp(string Whse,
		string Item,
		string Loc,
		int? UcFlag,
		decimal? UnitCost,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		int? SetPermFlag,
		string Site = null,
		Guid? RowPointer = null,
		string Infobar = null);
	}
}

