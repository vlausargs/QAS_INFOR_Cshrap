//PROJECT NAME: Material
//CLASS NAME: ICombineXferShipReceive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICombineXferShipReceive
	{
		(int? ReturnCode, string Infobar) CombineXferShipReceiveSp(string TrnNum,
		int? TrnLine,
		string Item,
		string FromSite,
		string FromWhse,
		string FromLoc,
		string FromLot,
		string ToSite,
		string ToWhse,
		string ToLoc,
		string ToLot,
		decimal? TQtyShipped,
		string TUM,
		DateTime? TShipDate,
		string Title,
		string RemoteSiteLotProcess,
		int? UseExistingSerials,
		string SerialPrefix,
		string Infobar,
		string ImportDocId,
		string ExportDocId,
		string ReasonCode,
		int? MoveZeroCostItem = null,
		DateTime? RecordDate = null,
		string DocumentNum = null);
	}
}

