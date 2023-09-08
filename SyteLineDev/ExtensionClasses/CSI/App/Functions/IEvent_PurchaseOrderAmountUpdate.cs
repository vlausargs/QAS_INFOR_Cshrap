//PROJECT NAME: Data
//CLASS NAME: IEvent_PurchaseOrderAmountUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEvent_PurchaseOrderAmountUpdate
	{
		(int? ReturnCode,
			string Infobar) Event_PurchaseOrderAmountUpdateSp(
			string PoNum,
			string PoCost,
			string Infobar);
	}
}

