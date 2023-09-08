//PROJECT NAME: Logistics
//CLASS NAME: IGetAPAgingInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetAPAgingInfo
	{
		(int? ReturnCode, string PAgeDesc1,
		string PAgeDesc2,
		string PAgeDesc3,
		string PAgeDesc4,
		string PAgeDesc5,
		decimal? PAgeBal1,
		decimal? PAgeBal2,
		decimal? PAgeBal3,
		decimal? PAgeBal4,
		decimal? PAgeBal5,
		decimal? PAgeBal6,
		string Infobar) GetAPAgingInfoSp(string PVendNum,
		string PCurrCode,
		int? PTransDom,
		int? PSiteQuery,
		string PAgeDesc1,
		string PAgeDesc2,
		string PAgeDesc3,
		string PAgeDesc4,
		string PAgeDesc5,
		decimal? PAgeBal1,
		decimal? PAgeBal2,
		decimal? PAgeBal3,
		decimal? PAgeBal4,
		decimal? PAgeBal5,
		decimal? PAgeBal6,
		string Infobar);
	}
}

