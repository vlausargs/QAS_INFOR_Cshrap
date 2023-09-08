//PROJECT NAME: Data
//CLASS NAME: IDisplayDRorCRAmountTotal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayDRorCRAmountTotal
	{
		decimal? DisplayDRorCRAmountTotalFn(
			decimal? DomDrAmount,
			decimal? DomCrAmount,
			int? IsDR,
			int? pSeperateDRandCRtot);
	}
}

