//PROJECT NAME: Logistics
//CLASS NAME: IUpdObal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUpdObal
	{
		int? UpdObalSp(string CustNum,
		decimal? Adjust);
	}
}

