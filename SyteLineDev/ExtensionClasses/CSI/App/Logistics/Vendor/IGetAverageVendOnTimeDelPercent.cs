//PROJECT NAME: Logistics
//CLASS NAME: IGetAverageVendOnTimeDelPercent.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetAverageVendOnTimeDelPercent
	{
		(int? ReturnCode, decimal? pAverageOnTimeDelPercent) GetAverageVendOnTimeDelPercentSp(string pVendNum,
		int? pNumberOfMonths,
		decimal? pAverageOnTimeDelPercent);

		decimal? GetAverageVendOnTimeDelPercentFn(
			string VendNum,
			int? NumberOfMonths);
	}
}

