//PROJECT NAME: Logistics
//CLASS NAME: IVerifyPackedNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IVerifyPackedNum
	{
		(int? ReturnCode, int? Flag) VerifyPackedNumSp(string OrderNum,
		int? OrderLine,
		int? OrderRelease,
		decimal? OrderQty,
		int? Flag);
	}
}

