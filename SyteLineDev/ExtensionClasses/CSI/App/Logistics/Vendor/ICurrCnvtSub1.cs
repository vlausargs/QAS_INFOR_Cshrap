//PROJECT NAME: Logistics
//CLASS NAME: ICurrCnvtSub1Sp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICurrCnvtSub1
	{
		decimal? CurrCnvtSub1Sp(
			int? FromDomestic,
			int? FRateD,
			int? TEuroBasis,
			int? DRateD,
			decimal? Amount,
			decimal? FRate,
			decimal? DRate,
			int? RoundResult,
			int? RoundPlaces);
	}
}

