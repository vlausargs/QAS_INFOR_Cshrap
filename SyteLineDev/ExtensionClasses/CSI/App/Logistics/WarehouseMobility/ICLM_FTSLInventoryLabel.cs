//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLInventoryLabel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLInventoryLabel
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_FTSLInventoryLabelSp(string Whse,
		string FromLoc,
		string ToLoc,
		string FromItem,
		string ToItem,
		int? FromRange,
		int? ToRange,
		string Infobar);
	}
}

