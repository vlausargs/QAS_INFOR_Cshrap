//PROJECT NAME: Logistics
//CLASS NAME: IGetEcvtItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetEcvtItem
	{
		(int? ReturnCode, string CommCode,
		decimal? UnitWeight,
		string Origin) GetEcvtItemSp(string Item,
		string CommCode,
		decimal? UnitWeight,
		string Origin);
	}
}

