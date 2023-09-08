//PROJECT NAME: Logistics
//CLASS NAME: IRmaItemCompareQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRmaItemCompareQty
	{
		(int? ReturnCode, string Infobar) RmaItemCompareQtySp(string CoNum,
		int? CoLine,
		int? CoRelease,
		decimal? QtyInvoiced,
		string Infobar);
	}
}

