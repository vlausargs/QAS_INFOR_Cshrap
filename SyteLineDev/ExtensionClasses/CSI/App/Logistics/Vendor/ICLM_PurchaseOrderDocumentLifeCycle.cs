//PROJECT NAME: Logistics
//CLASS NAME: ICLM_PurchaseOrderDocumentLifeCycle.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_PurchaseOrderDocumentLifeCycle
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PurchaseOrderDocumentLifeCycleSp(string RecType,
		string PoNum = null,
		int? VchNum = null,
		string ReqNum = null);
	}
}

