//PROJECT NAME: Data
//CLASS NAME: IGetForAmtRemaining.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetForAmtRemaining
	{
		decimal? GetForAmtRemainingFn(
			string BankCode,
			string VendNum,
			decimal? CheckSeq,
			decimal? Remaining);
	}
}

