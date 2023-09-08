//PROJECT NAME: Material
//CLASS NAME: IMrpWbGetPoInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpWbGetPoInfo
	{
		(int? ReturnCode, string VendNum,
		decimal? BlanketUnitCost,
		int? IsBlanket,
		string Infobar,
		string Whse) MrpWbGetPoInfoSp(string PoNum,
		DateTime? DueDate,
		string Item,
		string VendNum,
		decimal? BlanketUnitCost,
		int? IsBlanket,
		string Infobar,
		string Whse);
	}
}

