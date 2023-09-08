//PROJECT NAME: Logistics
//CLASS NAME: ICOShippingPopulateTmpShp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICOShippingPopulateTmpShp
	{
		int? COShippingPopulateTmpShpSP(string CoNum,
		int? CoLine,
		int? CoRelease,
		string UbDoNum,
		int? UbDoLine,
		decimal? UbQtyToShipConv,
		decimal? UbQtyToShip,
		string UbLoc,
		string UbLot,
		int? UbCrReturn,
		int? UbRtnToStk,
		int? UbByCons,
		string UbReasonCode,
		string UbWorkkey,
		DateTime? UbTransDate,
		Guid? RowPointer,
		int? UbSequence,
		string UbOrigInvoice,
		string UbReasonText,
		string UbImportdocId,
		string UbExportDocId,
		int? PackNum,
		string ContainerNum,
		string UM,
		string UbUserName,
		string UbEsigReason,
		Guid? UbEsigRowPointer,
		string UbEsigEncryptedPassword,
		DateTime? RecordDate,
		decimal? ShipmentId = null,
		int? ShipmentLine = null,
		int? ShipmentSeq = null,
        string UbOrigProFormaInvoice = null);
	}
}

