//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLInvCodeLabel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLInvCodeLabel
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_FTSLInvCodeLabelSp(string Type,
		int? FromRange,
		int? ToRange,
		string Infobar);
	}
}

