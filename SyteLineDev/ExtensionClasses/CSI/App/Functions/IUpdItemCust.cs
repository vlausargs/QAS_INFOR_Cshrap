//PROJECT NAME: Data
//CLASS NAME: IUpdItemCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdItemCust
	{
		(int? ReturnCode,
			string Infobar) UpdItemCustSp(
			string CoNum,
			string CoCustNum,
			string NewStat,
			decimal? OldQtyOrderedConv,
			decimal? OldQtyOrdered,
			string OldUM,
			string OldWhse,
			string NewWhse,
			decimal? OldQtyShipped,
			string OldStatus,
			decimal? NewQtyOrderedConv,
			decimal? NewQtyOrdered,
			string NewItem,
			string NewUM,
			string CustItem,
			int? NewRecord,
			string Infobar);
	}
}

