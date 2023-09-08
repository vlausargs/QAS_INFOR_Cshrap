//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLPopulateSROLineDropDown.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLPopulateSROLineDropDown
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLPopulateSROLineDropDownSp(string CallForm,
		string SroNum);
	}
}

