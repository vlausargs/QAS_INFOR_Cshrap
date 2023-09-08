//PROJECT NAME: Logistics
//CLASS NAME: IBiStat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IBiStat
	{
		(int? ReturnCode, string Infobar) BiStatSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string OldStat,
		string NewStat,
		string EdiCoStat,
		string EdiCoblnStat,
		string Item,
		string Whse,
		string RefType,
		decimal? QtyOrdered,
		decimal? OldQtyOrdered,
		decimal? QtyShipped,
		decimal? QtyInvoiced,
		int? UpdateFlag,
		string Infobar,
		int? SkipEdiStatusError = 0);
	}
}

