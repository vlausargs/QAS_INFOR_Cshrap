//PROJECT NAME: Data
//CLASS NAME: IEvent_PurchaseOrderItemReceived.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEvent_PurchaseOrderItemReceived
	{
		(int? ReturnCode,
			string Infobar) Event_PurchaseOrderItemReceivedSp(
			string Item,
			string PoNum,
			string Infobar);
	}
}

