//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetJobMaterialsByPreassignedSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetJobMaterialsByPreassignedSerial
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetJobMaterialsByPreassignedSerialSp(string Job,
		int? Suffix,
		string EndItem,
		string EndItemSerial);
	}
}

