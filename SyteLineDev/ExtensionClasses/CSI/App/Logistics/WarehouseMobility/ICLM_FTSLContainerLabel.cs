//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLContainerLabel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLContainerLabel
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_FTSLContainerLabelSp(string Whse,
		string FromLoc,
		string ToLoc,
		string FromContainer,
		string ToContainer,
		int? FromRange,
		int? ToRange,
		string Infobar);
	}
}

