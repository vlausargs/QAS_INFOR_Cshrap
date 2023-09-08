//PROJECT NAME: Logistics
//CLASS NAME: ISumCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISumCo
	{
		(int? ReturnCode, string Infobar,
		decimal? NewTotalPrice,
		decimal? PlannedDiscountOffset) SumCoSp(string PCoNum,
		string Infobar,
		decimal? NewTotalPrice = 0,
		decimal? PlannedDiscountOffset = 0);
	}
}

