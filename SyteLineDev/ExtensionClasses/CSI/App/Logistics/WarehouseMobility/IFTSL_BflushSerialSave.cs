//PROJECT NAME: Logistics
//CLASS NAME: IFTSL_BflushSerialSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSL_BflushSerialSave
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTSL_BflushSerialSaveSp(decimal? TransNum,
		string Whse,
		string Lot,
		int? Selected,
		string JobMatlItem,
		string Loc,
		string SerNum);
	}
}

