//PROJECT NAME: Data
//CLASS NAME: IEvent_PurchaseOrderRequisitionAmountUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEvent_PurchaseOrderRequisitionAmountUpdate
	{
		(int? ReturnCode,
			string Infobar) Event_PurchaseOrderRequisitionAmountUpdateSp(
			string ReqNum,
			decimal? ReqCost,
			string Infobar);
	}
}

