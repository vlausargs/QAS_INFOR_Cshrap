//PROJECT NAME: Data
//CLASS NAME: COShippingTrxPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class COShippingTrxPost : ICOShippingTrxPost
	{
		readonly IApplicationDB appDB;
		
		public COShippingTrxPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string SOrigProFormaInvoice = null)
		{
			CoNumType _SCoNum = SCoNum;
			CoLineType _SCoLine = SCoLine;
			CoReleaseType _SCoRel = SCoRel;
			DoNumType _SDoNum = SDoNum;
			DoLineType _SDoLine = SDoLine;
			LocType _SLoc = SLoc;
			LotType _SLot = SLot;
			ListYesNoType _OKtoCreateLotLoc = OKtoCreateLotLoc;
			ItemType _SItem = SItem;
			QtyUnitNoNegType _SQty = SQty;
			ListYesNoType _SReturn = SReturn;
			ListYesNoType _SRetToStock = SRetToStock;
			DateType _STransDate = STransDate;
			ReasonCodeType _SReasonCode = SReasonCode;
			ListYesNoType _SConsign = SConsign;
			LongListType _SWorkkey = SWorkkey;
			LongListType _CallArg = CallArg;
			PackNumType _PackNum = PackNum;
			InfobarType _Infobar = Infobar;
			BatchIdType _BatchId = BatchId;
			InvNumType _SOrigInvoice = SOrigInvoice;
			FormEditorType _SReasonText = SReasonText;
			ImportDocIdType _ImportDocId = ImportDocId;
			ExportDocIdType _ExportDocId = ExportDocId;
			ListYesNoType _SkipCreditCheck = SkipCreditCheck;
			ListYesNoType _CredHold = CredHold;
			EmpNumType _EmpNum = EmpNum;
			ContainerNumType _ContainerNum = ContainerNum;
			ShipmentIDType _ShipmentId = ShipmentId;
			DocumentNumType _DocumentNum = DocumentNum;
			AmtTotType _ShipmentValueTotal = ShipmentValueTotal;
			ShipmentLineType _ShipmentLine = ShipmentLine;
			ShipmentSequenceType _ShipmentSeq = ShipmentSeq;
			InvNumType _SOrigProFormaInvoice = SOrigProFormaInvoice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "COShippingTrxPostSp";
				
				appDB.AddCommandParameter(cmd, "SCoNum", _SCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCoLine", _SCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCoRel", _SCoRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SDoNum", _SDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SDoLine", _SDoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLoc", _SLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLot", _SLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OKtoCreateLotLoc", _OKtoCreateLotLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SItem", _SItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SQty", _SQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SReturn", _SReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRetToStock", _SRetToStock, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STransDate", _STransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SReasonCode", _SReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SConsign", _SConsign, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SWorkkey", _SWorkkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallArg", _CallArg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BatchId", _BatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SOrigInvoice", _SOrigInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SReasonText", _SReasonText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExportDocId", _ExportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkipCreditCheck", _SkipCreditCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CredHold", _CredHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentValueTotal", _ShipmentValueTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipmentLine", _ShipmentLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentSeq", _ShipmentSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SOrigProFormaInvoice", _SOrigProFormaInvoice, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				CredHold = _CredHold;
				ShipmentValueTotal = _ShipmentValueTotal;
				
				return (Severity, Infobar, CredHold, ShipmentValueTotal);
			}
		}
	}
}
