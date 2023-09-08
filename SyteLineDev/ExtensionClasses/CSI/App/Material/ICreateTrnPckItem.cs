//PROJECT NAME: Material
//CLASS NAME: ICreateTrnPckItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICreateTrnPckItem
	{
		(int? ReturnCode, string Infobar) CreateTrnPckItemSp(int? PackNum,
		string TrnNum,
		int? TrnLine,
		string Item,
		string UM,
		decimal? PackQty,
		string Infobar);
	}
}

