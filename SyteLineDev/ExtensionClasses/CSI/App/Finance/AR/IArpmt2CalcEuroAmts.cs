//PROJECT NAME: Finance
//CLASS NAME: IArpmt2CalcEuroAmts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmt2CalcEuroAmts
	{
		decimal? Arpmt2CalcEuroAmtsFn(
			string PCustCurrCode,
			string PBnkCurrCode,
			decimal? PForCheckAmount,
			decimal? PDomCheckAmount);
	}
}

