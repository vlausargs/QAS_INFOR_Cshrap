//PROJECT NAME: LoadProcessQuoteCopyToOrder
//CLASS NAME: ILoadProcessQuoteCopyToOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.LoadProcessQuoteCopyToOrder
{
	public interface ILoadProcessQuoteCopyToOrder
	{
		(int? ReturnCode,
			string NewCoNum,
			string Infobar) LoadProcessQuoteCopyToOrderSp(
			string pEstNum,
			string pQuoteStatus,
			string NewCoNum,
			string Infobar);
	}
}

