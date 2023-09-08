//PROJECT NAME: DataCollection
//CLASS NAME: IItemLocAdd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IItemLocAdd
	{
		(int? ReturnCode, Guid? RowPointer,
		string Infobar) ItemLocAddSp(string Whse,
		string Item,
		string Loc,
		int? UcFlag,
		decimal? UnitCost,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		int? SetPermFlag = 0,
		Guid? RowPointer = null,
		string Infobar = null,
		int? PermFlagValue = null,
		int? MrbFlagValue = null,
		int? locMrbFlag = null,
		string locLocType = null,
		string locWC = null);
	}
}

