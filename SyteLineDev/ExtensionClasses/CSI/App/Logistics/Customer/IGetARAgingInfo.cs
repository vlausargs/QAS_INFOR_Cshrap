//PROJECT NAME: Logistics
//CLASS NAME: IGetARAgingInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetARAgingInfo
	{
		(int? ReturnCode, decimal? PAgeBal1,
		decimal? PAgeBal2,
		decimal? PAgeBal3,
		decimal? PAgeBal4,
		decimal? PAgeBal5,
		decimal? PAgeBal6) GetARAgingInfoSp(int? PSubordinate,
		string PCustNum,
		int? PSiteQuery,
		decimal? PAgeBal1,
		decimal? PAgeBal2,
		decimal? PAgeBal3,
		decimal? PAgeBal4,
		decimal? PAgeBal5,
		decimal? PAgeBal6);
	}
}

