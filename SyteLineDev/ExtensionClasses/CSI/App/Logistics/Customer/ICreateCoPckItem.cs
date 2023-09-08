//PROJECT NAME: Logistics
//CLASS NAME: ICreateCoPckItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICreateCoPckItem
	{
		(int? ReturnCode, string Infobar) CreateCoPckItemSp(int? PackNum,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string Item,
		string UM,
		decimal? PackQty,
		string ProcessId,
		string Infobar);
	}
}

