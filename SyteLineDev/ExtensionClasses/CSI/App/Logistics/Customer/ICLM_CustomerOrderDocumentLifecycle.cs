//PROJECT NAME: Logistics
//CLASS NAME: ICLM_CustomerOrderDocumentLifecycle.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_CustomerOrderDocumentLifecycle
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_CustomerOrderDocumentLifecycleSp(string RecType,
		string CoNum = null,
		string InvNum = null,
		string EstNum = null,
		string RmaNum = null);
	}
}

