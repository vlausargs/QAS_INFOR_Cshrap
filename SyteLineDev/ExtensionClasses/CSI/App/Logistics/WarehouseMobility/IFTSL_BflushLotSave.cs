//PROJECT NAME: Logistics
//CLASS NAME: IFTSL_BflushLotSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSL_BflushLotSave
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTSL_BflushLotSaveSp(decimal? TransNum,
		string Whse,
		string Lot,
		int? Selected,
		string Job,
		string JobMatlItem,
		string Loc);
	}
}

