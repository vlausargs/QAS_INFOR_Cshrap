//PROJECT NAME: Material
//CLASS NAME: ITransferOrderShip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITransferOrderShip
	{
		(int? ReturnCode, string Infobar) TransferOrderShipSp(string TrnNum,
		string TransferFromSite,
		string TransferToSite,
		string TransferFobSite,
		string TransferFromWhse,
		string TransferToWhse,
		int? TrnLine,
		decimal? TQtyShipped,
		string TUM,
		DateTime? TShipDate,
		string TFromLoc,
		string TFromLot,
		string TToLot,
		string Title,
		string RemoteSiteLotProcess,
		int? UseExistingSerials,
		string SerialPrefix,
		string PReasonCode,
		string Infobar,
		string TImportDocId,
		string ExportDocId,
		int? MoveZeroCostItem = null,
		string EmpNum = null,
		DateTime? RecordDate = null,
		string DocumentNum = null);
	}
}

