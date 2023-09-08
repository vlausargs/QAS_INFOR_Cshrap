//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SubTaxCodePurchaseOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_SubTaxCodePurchaseOrder
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SubTaxCodePurchaseOrderSp(string pPoNumStart = null,
		string pPoNumEnd = null,
		int? pSummary = 0,
		string pSubTaxXMLData = null);
	}
}

