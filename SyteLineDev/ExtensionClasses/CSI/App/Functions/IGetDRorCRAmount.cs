//PROJECT NAME: Data
//CLASS NAME: IGetDRorCRAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetDRorCRAmount
	{
		decimal? GetDRorCRAmountFn(
			decimal? DomAmount,
			int? IsDR,
			int? Cancellation);
	}
}

