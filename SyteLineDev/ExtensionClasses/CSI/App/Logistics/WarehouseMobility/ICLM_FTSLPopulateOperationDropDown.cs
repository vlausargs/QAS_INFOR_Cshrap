//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLPopulateOperationDropDown.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLPopulateOperationDropDown
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLPopulateOperationDropDownSp(int? TTImplemented = 0,
		string Job = null);
	}
}

