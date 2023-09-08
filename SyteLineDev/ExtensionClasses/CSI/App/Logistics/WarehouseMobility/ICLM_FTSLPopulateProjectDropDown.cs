//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLPopulateProjectDropDown.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLPopulateProjectDropDown
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLPopulateProjectDropDownSp(string CallForm);
	}
}

