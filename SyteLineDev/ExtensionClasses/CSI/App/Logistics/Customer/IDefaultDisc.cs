//PROJECT NAME: Logistics
//CLASS NAME: IDefaultDisc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IDefaultDisc
	{
		(int? ReturnCode, decimal? Disc) DefaultDiscSp(string Item,
		string CustNum,
		string CustType,
		decimal? Disc);
	}
}

