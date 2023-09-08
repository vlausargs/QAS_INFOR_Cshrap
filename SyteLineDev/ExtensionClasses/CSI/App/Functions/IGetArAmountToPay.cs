//PROJECT NAME: Data
//CLASS NAME: IGetArAmountToPaySp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetArAmountToPay
	{
		decimal? GetArAmountToPaySp(
			string CustNum,
			string InvNum,
			string Site = null);
	}
}

