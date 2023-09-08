//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLJobStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLJobStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLJobStatusSp(string JobStart,
		string JobEnd,
		int? SuffixStart,
		int? SuffixEnd,
		string WorkCenterStart,
		string WorkCenterEnd,
		DateTime? StartDate,
		DateTime? EndDate,
		int? SortBy,
		int? Clear);
	}
}

