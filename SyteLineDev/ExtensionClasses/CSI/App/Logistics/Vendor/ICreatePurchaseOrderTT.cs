//PROJECT NAME: Logistics
//CLASS NAME: ICreatePurchaseOrderTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICreatePurchaseOrderTT
	{
		(int? ReturnCode, string Infobar) CreatePurchaseOrderTTSp(Guid? PSessionID,
		int? NumTasks,
		int? SkipStageDelete,
		string Infobar);
	}
}

