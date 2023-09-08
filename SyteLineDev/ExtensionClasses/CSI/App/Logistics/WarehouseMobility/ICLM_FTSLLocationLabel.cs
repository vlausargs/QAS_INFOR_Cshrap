//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLLocationLabel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLLocationLabel
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_FTSLLocationLabelSp(string FromLoc,
		string ToLoc,
		int? FromRange,
		int? ToRange,
		string Infobar);
	}
}

