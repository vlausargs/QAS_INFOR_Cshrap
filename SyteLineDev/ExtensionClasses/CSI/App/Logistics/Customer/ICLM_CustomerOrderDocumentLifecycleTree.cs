//PROJECT NAME: Logistics
//CLASS NAME: ICLM_CustomerOrderDocumentLifecycleTree.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_CustomerOrderDocumentLifecycleTree
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_CustomerOrderDocumentLifecycleTreeSp(string ParentLevel,
		string CoNum = null,
		string InvNum = null,
		string EstNum = null,
		string RmaNum = null);
	}
}

