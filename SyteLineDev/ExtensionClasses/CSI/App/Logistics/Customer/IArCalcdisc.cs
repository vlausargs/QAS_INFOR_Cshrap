//PROJECT NAME: Logistics
//CLASS NAME: IArCalcdisc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArCalcdisc
	{
		(int? ReturnCode, decimal? TDisc,
		decimal? TBal,
		decimal? TaxDiscount) ArCalcdiscSp(string PCurApplyCustNum,
		string PCurInvNum,
		DateTime? PPaymentReceiptDate,
		string Site = null,
		decimal? TDisc = null,
		decimal? TBal = null,
		decimal? TaxDiscount = 0);
	}
}

