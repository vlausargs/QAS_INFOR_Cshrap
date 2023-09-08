//PROJECT NAME: Data
//CLASS NAME: ICOShippingTrxPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICOShippingTrxPost
	{
		(int? ReturnCode,
			string Infobar,
			int? CredHold,
			decimal? ShipmentValueTotal) COShippingTrxPostSp(
			string SCoNum,
			int? SCoLine,
			int? SCoRel,
			string SDoNum,
			int? SDoLine,
			string SLoc,
			string SLot,
			int? OKtoCreateLotLoc = 0,
			string SItem = null,
			decimal? SQty = null,
			int? SReturn = null,
			int? SRetToStock = null,
			DateTime? STransDate = null,
			string SReasonCode = null,
			int? SConsign = null,
			string SWorkkey = null,
			string CallArg = null,
			int? PackNum = null,
			string Infobar = null,
			int? BatchId = null,
			string SOrigInvoice = null,
			string SReasonText = null,
			string ImportDocId = null,
			string ExportDocId = null,
			int? SkipCreditCheck = 0,
			int? CredHold = 0,
			string EmpNum = null,
			string ContainerNum = null,
			decimal? ShipmentId = null,
			string DocumentNum = null,
			decimal? ShipmentValueTotal = 0,
			int? ShipmentLine = null,
			int? ShipmentSeq = null,
			string SOrigProFormaInvoice = null);
	}
}

