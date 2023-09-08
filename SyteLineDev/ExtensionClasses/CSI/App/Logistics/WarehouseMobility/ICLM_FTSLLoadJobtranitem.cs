//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLLoadJobtranitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLLoadJobtranitem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLLoadJobtranitemSp(decimal? TransNum,
		string Job,
		int? Suffix,
		int? OperNum);
	}
}

