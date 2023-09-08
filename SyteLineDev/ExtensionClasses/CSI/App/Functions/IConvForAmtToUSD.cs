//PROJECT NAME: Data
//CLASS NAME: IConvForAmtToUSD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IConvForAmtToUSD
	{
		decimal? ConvForAmtToUSDFn(
			string ForCurrCode,
			DateTime? TransDate,
			decimal? Amount,
			string ISOCountryCode,
			decimal? ForExchRate);
	}
}

