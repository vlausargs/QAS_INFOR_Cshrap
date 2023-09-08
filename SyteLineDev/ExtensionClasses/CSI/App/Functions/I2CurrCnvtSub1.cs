//PROJECT NAME: Data
//CLASS NAME: I2CurrCnvtSub1Sp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface I2CurrCnvtSub1
	{
		decimal? TwoCurrCnvtSub1Sp(
			int? TRateD,
			int? RoundResult,
			int? RoundPlaces,
			decimal? TRate,
			decimal? Amount);
	}
}

