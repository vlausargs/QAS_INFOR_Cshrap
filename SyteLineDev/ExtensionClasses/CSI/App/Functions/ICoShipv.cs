//PROJECT NAME: Data
//CLASS NAME: ICOShipv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICOShipv
	{
		(int? ReturnCode,
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
			string POrigProFormaInvoice = null);
	}
}

