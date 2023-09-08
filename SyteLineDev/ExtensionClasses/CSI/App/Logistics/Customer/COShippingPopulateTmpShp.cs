//PROJECT NAME: Logistics
//CLASS NAME: COShippingPopulateTmpShp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class COShippingPopulateTmpShp : ICOShippingPopulateTmpShp
	{
		readonly IApplicationDB appDB;
		
		
		public COShippingPopulateTmpShp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? COShippingPopulateTmpShpSP(string CoNum,
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
        string UbOrigProFormaInvoice = null)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			DoNumType _UbDoNum = UbDoNum;
			DoLineType _UbDoLine = UbDoLine;
			QtyUnitNoNegType _UbQtyToShipConv = UbQtyToShipConv;
			QtyUnitNoNegType _UbQtyToShip = UbQtyToShip;
			LocType _UbLoc = UbLoc;
			LotType _UbLot = UbLot;
			FlagNyType _UbCrReturn = UbCrReturn;
			FlagNyType _UbRtnToStk = UbRtnToStk;
			FlagNyType _UbByCons = UbByCons;
			ReasonCodeType _UbReasonCode = UbReasonCode;
			RefStrType _UbWorkkey = UbWorkkey;
			CurrentDateType _UbTransDate = UbTransDate;
			RowPointerType _RowPointer = RowPointer;
			IntType _UbSequence = UbSequence;
			InvNumType _UbOrigInvoice = UbOrigInvoice;
			FormEditorType _UbReasonText = UbReasonText;
			ImportDocIdType _UbImportdocId = UbImportdocId;
			ExportDocIdType _UbExportDocId = UbExportDocId;
			PackNumType _PackNum = PackNum;
			ContainerNumType _ContainerNum = ContainerNum;
			UMType _UM = UM;
			UsernameType _UbUserName = UbUserName;
			ReasonCodeType _UbEsigReason = UbEsigReason;
			RowPointerType _UbEsigRowPointer = UbEsigRowPointer;
			EncryptedClientPasswordType _UbEsigEncryptedPassword = UbEsigEncryptedPassword;
			DateTimeType _RecordDate = RecordDate;
			ShipmentIDType _ShipmentId = ShipmentId;
			ShipmentLineType _ShipmentLine = ShipmentLine;
			ShipmentSequenceType _ShipmentSeq = ShipmentSeq;
            InvNumType _UbOrigProFormaInvoice = UbOrigProFormaInvoice;

            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "COShippingPopulateTmpShpSP";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbDoNum", _UbDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbDoLine", _UbDoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbQtyToShipConv", _UbQtyToShipConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbQtyToShip", _UbQtyToShip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbLoc", _UbLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbLot", _UbLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbCrReturn", _UbCrReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbRtnToStk", _UbRtnToStk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbByCons", _UbByCons, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbReasonCode", _UbReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbWorkkey", _UbWorkkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbTransDate", _UbTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbSequence", _UbSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbOrigInvoice", _UbOrigInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbReasonText", _UbReasonText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbImportdocId", _UbImportdocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbExportDocId", _UbExportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbUserName", _UbUserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbEsigReason", _UbEsigReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbEsigRowPointer", _UbEsigRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UbEsigEncryptedPassword", _UbEsigEncryptedPassword, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentLine", _ShipmentLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentSeq", _ShipmentSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UbOrigProFormaInvoice", _UbOrigProFormaInvoice, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
    }
}
