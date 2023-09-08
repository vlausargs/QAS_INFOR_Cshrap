//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLPopulateProjectTaskDropDown.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLPopulateProjectTaskDropDown
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLPopulateProjectTaskDropDownSp(string ProjNum);
	}
}

