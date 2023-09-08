//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLSerialSelect.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLSerialSelect
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_FTSLSerialSelectSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		string Infobar);
	}
}

