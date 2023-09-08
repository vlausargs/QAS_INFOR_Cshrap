//PROJECT NAME: Logistics
//CLASS NAME: ICLM_PurchaseOrderReceiving.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_PurchaseOrderReceiving
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PurchaseOrderReceivingSp(string CurWhse,
		string PVendNum,
		DateTime? SDueDate,
		DateTime? EDueDate,
		string PGrnNum,
		int? PGrnLine,
		int? PByGrn,
		string PPoNum,
		int? PPoLine,
		int? PPoRelease,
		string PoitemStatuses,
		DateTime? TransDate = null,
		string FilterString = null,
		int? ReturnToTable = 0);
	}
}

