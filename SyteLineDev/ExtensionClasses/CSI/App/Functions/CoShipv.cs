//PROJECT NAME: Data
//CLASS NAME: COShipv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class COShipv : ICOShipv
	{
		readonly IApplicationDB appDB;
		
		public COShipv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? FirstSequenceWithError,
			int? RecordsPosted,
			string Infobar,
			decimal? ShipmentValueTotal) COShipvSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			string PDoNum,
			int? PDoLine,
			decimal? PQtyToShip,
			string PLoc,
			string PLot,
			int? PCrReturn,
			int? PRtnToStk,
			int? PByCons,
			string PReasonCode,
			string PWorkKey,
			DateTime? PTransDate,
			int? PSequence,
			int? PackNum,
			int? FirstSequenceWithError,
			int? RecordsPosted,
			string Infobar,
			int? BatchId = null,
			string POrigInvoice = null,
			string PReasonText = null,
			string PImportDocId = null,
			string PExportDocId = null,
			string PContainerNum = null,
			decimal? PShipmentId = null,
			string DocumentNum = null,
			decimal? ShipmentValueTotal = 0,
			int? SkipCreditCheck = 0,
			int? ShipmentLine = null,
			int? ShipmentSeq = null,
			string POrigProFormaInvoice = null)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			DoNumType _PDoNum = PDoNum;
			DoLineType _PDoLine = PDoLine;
			QtyUnitNoNegType _PQtyToShip = PQtyToShip;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			FlagNyType _PCrReturn = PCrReturn;
			FlagNyType _PRtnToStk = PRtnToStk;
			FlagNyType _PByCons = PByCons;
			ReasonCodeType _PReasonCode = PReasonCode;
			RefStrType _PWorkKey = PWorkKey;
			CurrentDateType _PTransDate = PTransDate;
			IntType _PSequence = PSequence;
			PackNumType _PackNum = PackNum;
			IntType _FirstSequenceWithError = FirstSequenceWithError;
			IntType _RecordsPosted = RecordsPosted;
			InfobarType _Infobar = Infobar;
			BatchIdType _BatchId = BatchId;
			InvNumType _POrigInvoice = POrigInvoice;
			FormEditorType _PReasonText = PReasonText;
			ImportDocIdType _PImportDocId = PImportDocId;
			ExportDocIdType _PExportDocId = PExportDocId;
			ContainerNumType _PContainerNum = PContainerNum;
			ShipmentIDType _PShipmentId = PShipmentId;
			DocumentNumType _DocumentNum = DocumentNum;
			AmtTotType _ShipmentValueTotal = ShipmentValueTotal;
			ListYesNoType _SkipCreditCheck = SkipCreditCheck;
			ShipmentLineType _ShipmentLine = ShipmentLine;
			ShipmentSequenceType _ShipmentSeq = ShipmentSeq;
			InvNumType _POrigProFormaInvoice = POrigProFormaInvoice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "COShipvSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDoNum", _PDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDoLine", _PDoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyToShip", _PQtyToShip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCrReturn", _PCrReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRtnToStk", _PRtnToStk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PByCons", _PByCons, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonCode", _PReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWorkKey", _PWorkKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSequence", _PSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirstSequenceWithError", _FirstSequenceWithError, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecordsPosted", _RecordsPosted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BatchId", _BatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrigInvoice", _POrigInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonText", _PReasonText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PImportDocId", _PImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExportDocId", _PExportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PContainerNum", _PContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShipmentId", _PShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentValueTotal", _ShipmentValueTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SkipCreditCheck", _SkipCreditCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentLine", _ShipmentLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentSeq", _ShipmentSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrigProFormaInvoice", _POrigProFormaInvoice, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FirstSequenceWithError = _FirstSequenceWithError;
				RecordsPosted = _RecordsPosted;
				Infobar = _Infobar;
				ShipmentValueTotal = _ShipmentValueTotal;
				
				return (Severity, FirstSequenceWithError, RecordsPosted, Infobar, ShipmentValueTotal);
			}
		}
	}
}
