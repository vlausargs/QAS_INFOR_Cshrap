//PROJECT NAME: Logistics
//CLASS NAME: ICLM_PurchaseOrderDocumentLifecycleTree.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_PurchaseOrderDocumentLifecycleTree
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PurchaseOrderDocumentLifecycleTreeSp(string ParentLevel,
		string PoNum = null,
		string ReqNum = null,
		int? Voucher = null);
	}
}

