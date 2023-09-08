//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLBuildIcTmpPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLBuildIcTmpPickList
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_FTSLBuildIcTmpPickListSp(string Item,
		string Infobar);
	}
}

