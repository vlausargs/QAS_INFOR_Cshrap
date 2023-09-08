//PROJECT NAME: Material
//CLASS NAME: IItemLifo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemLifo
	{
		(int? ReturnCode, string Infobar) ItemLifoSp(int? Delete,
		string ItemlifoItem,
		DateTime? ItemlifoTransDate,
		decimal? ItemlifoQty,
		decimal? ItemlifoUnitCost,
		decimal? ItemlifoMatlCost,
		decimal? ItemlifoLbrCost,
		decimal? ItemlifoFovhdCost,
		decimal? ItemlifoVovhdCost,
		decimal? ItemlifoOutCost,
		string ItemlifoInvAcct,
		string ItemlifoLbrAcct,
		string ItemlifoFovhdAcct,
		string ItemlifoVovhdAcct,
		string ItemlifoOutAcct,
		Guid? ItemlifoRowPointer,
		string ItemlifoRecordDate,
		string ItemlifoWhse,
		string Infobar);
	}
}

