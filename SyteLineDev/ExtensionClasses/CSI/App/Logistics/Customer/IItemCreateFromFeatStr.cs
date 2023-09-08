//PROJECT NAME: Logistics
//CLASS NAME: IItemCreateFromFeatStr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IItemCreateFromFeatStr
	{
		(int? ReturnCode, string NewItem,
		string Infobar) ItemCreateFromFeatStrSp(string FeatStr,
		string Item,
		string CurrCode,
		decimal? ContractPrice,
		string CoNum,
		int? CoLine,
		decimal? IncPrice,
		string NewItem,
		string Infobar,
		string Site = null);
	}
}

