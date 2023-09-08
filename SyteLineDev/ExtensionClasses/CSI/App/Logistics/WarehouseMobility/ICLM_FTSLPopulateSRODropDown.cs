//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLPopulateSRODropDown.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLPopulateSRODropDown
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLPopulateSRODropDownSp(string CallForm);
	}
}

