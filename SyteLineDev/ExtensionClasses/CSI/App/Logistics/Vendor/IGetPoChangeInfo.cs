//PROJECT NAME: Logistics
//CLASS NAME: IGetPoChangeInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetPoChangeInfo
	{
		(int? ReturnCode, int? ChgNum,
		DateTime? ChgDate,
		string Stat,
		decimal? UserId) GetPoChangeInfoSp(string PoNum,
		int? ChgNum,
		DateTime? ChgDate,
		string Stat,
		decimal? UserId);
	}
}

