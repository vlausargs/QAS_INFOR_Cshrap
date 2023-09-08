//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLPopulateSROOperationDropDown.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLPopulateSROOperationDropDown
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLPopulateSROOperationDropDownSp(string CallForm,
		string SroNum,
		int? SroLine);
	}
}

