//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetJobMatlSerialUsage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetJobMatlSerialUsage
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetJobMatlSerialUsageSp(string Job = null,
		int? Suffix = null,
		int? OperNum = null,
		string EndItem = null,
		string EndItemSerial = null,
		string JobMatlItem = null,
		string JobMatlSerial = null);
	}
}

