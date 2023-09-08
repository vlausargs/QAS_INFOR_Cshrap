//PROJECT NAME: Logistics
//CLASS NAME: ICurrCnvtSub2Sp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICurrCnvtSub2
	{
		decimal? CurrCnvtSub2Sp(
			int? TRateD,
			int? FromDomestic,
			int? RoundResult,
			int? RoundPlaces,
			decimal? TRate,
			decimal? Amount);
	}
}

