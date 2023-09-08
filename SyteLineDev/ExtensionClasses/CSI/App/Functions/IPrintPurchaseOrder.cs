//PROJECT NAME: Data
//CLASS NAME: IPrintPurchaseOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrintPurchaseOrder
	{
		int? PrintPurchaseOrderSp(
			string StartPoNum = null,
			string EndPoNum = null,
			int? StartPoLine = null,
			int? EndPoLine = null,
			string UserName = null,
			string LangCode = null);
	}
}

