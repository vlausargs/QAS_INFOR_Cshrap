//PROJECT NAME: Material
//CLASS NAME: IGetItemPar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetItemPar
	{
		(int? ReturnCode, string ApsParmApsmode,
		int? TrackTaxFreeimports,
		string RUserCode,
		decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		string Infobar) GetItemParSp(string ApsParmApsmode,
		int? TrackTaxFreeimports,
		string RUserCode,
		decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		string Infobar,
		string PSite = null);
	}
}

