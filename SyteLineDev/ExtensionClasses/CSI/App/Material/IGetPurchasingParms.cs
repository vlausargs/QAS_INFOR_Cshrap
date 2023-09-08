//PROJECT NAME: Material
//CLASS NAME: IGetPurchasingParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetPurchasingParms
	{
		(int? ReturnCode, decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance) GetPurchasingParmsSp(decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		string PSite = null);
	}
}

