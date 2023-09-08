//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLTaskLabel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLTaskLabel
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_FTSLTaskLabelSp(string Type,
		int? FromRange,
		int? ToRange,
		string Infobar);
	}
}

