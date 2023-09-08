//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetKanbanLabelPrintingData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetKanbanLabelPrintingData
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetKanbanLabelPrintingDataSp(string KanbanItem);
	}
}

