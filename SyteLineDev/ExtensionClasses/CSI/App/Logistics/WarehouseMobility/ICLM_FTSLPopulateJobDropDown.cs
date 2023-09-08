//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLPopulateJobDropDown.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLPopulateJobDropDown
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLPopulateJobDropDownSp(string CallForm,
		int? TTImplemented = 0);
	}
}

