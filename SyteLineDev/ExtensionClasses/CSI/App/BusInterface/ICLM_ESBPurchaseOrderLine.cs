//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBPurchaseOrderLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBPurchaseOrderLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBPurchaseOrderLineSp(string PoNum);
	}
}

