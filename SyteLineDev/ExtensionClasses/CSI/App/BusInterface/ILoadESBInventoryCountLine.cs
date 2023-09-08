//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBInventoryCountLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBInventoryCountLine
	{
		(int? ReturnCode, string InfoBar) LoadESBInventoryCountLineSP(string BODNOUN,
		string DocumentID,
		string Item,
		string Warehouse,
		string SerializedLotID,
		DateTime? SerializedLotExpDate,
		decimal? Qty,
		string ISOUM,
		string HoldCode,
		decimal? CountSequence,
		int? LineNumber,
		DateTime? TransDate,
		string ReasonCode,
		string InfoBar);
	}
}

