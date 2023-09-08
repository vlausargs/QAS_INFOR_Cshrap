//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLKanbanPickListDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLKanbanPickListDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLKanbanPickListDetailSp(string PickFromWhse = null,
		string KbItem = null);
	}
}

