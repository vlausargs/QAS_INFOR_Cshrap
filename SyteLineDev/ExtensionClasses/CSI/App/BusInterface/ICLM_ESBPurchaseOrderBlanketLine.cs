//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBPurchaseOrderBlanketLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBPurchaseOrderBlanketLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBPurchaseOrderBlanketLineSp(string PoNum,
		int? PoLine);
	}
}

