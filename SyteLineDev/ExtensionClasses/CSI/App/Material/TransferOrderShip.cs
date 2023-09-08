//PROJECT NAME: Material
//CLASS NAME: TransferOrderShip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class TransferOrderShip : ITransferOrderShip
	{
		readonly IApplicationDB appDB;
		
		
		public TransferOrderShip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) TransferOrderShipSp(string TrnNum,
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
		string DocumentNum = null)
		{
			TrnNumType _TrnNum = TrnNum;
			SiteType _TransferFromSite = TransferFromSite;
			SiteType _TransferToSite = TransferToSite;
			SiteType _TransferFobSite = TransferFobSite;
			WhseType _TransferFromWhse = TransferFromWhse;
			WhseType _TransferToWhse = TransferToWhse;
			TrnLineType _TrnLine = TrnLine;
			QtyUnitType _TQtyShipped = TQtyShipped;
			UMType _TUM = TUM;
			DateType _TShipDate = TShipDate;
			LocType _TFromLoc = TFromLoc;
			LotType _TFromLot = TFromLot;
			LotType _TToLot = TToLot;
			LongListType _Title = Title;
			ListExistingCreateBothType _RemoteSiteLotProcess = RemoteSiteLotProcess;
			ListYesNoType _UseExistingSerials = UseExistingSerials;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			ReasonCodeType _PReasonCode = PReasonCode;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _TImportDocId = TImportDocId;
			ExportDocIdType _ExportDocId = ExportDocId;
			ListYesNoType _MoveZeroCostItem = MoveZeroCostItem;
			EmpNumType _EmpNum = EmpNum;
			CurrentDateType _RecordDate = RecordDate;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransferOrderShipSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFromSite", _TransferFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferToSite", _TransferToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFobSite", _TransferFobSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferFromWhse", _TransferFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransferToWhse", _TransferToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyShipped", _TQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TShipDate", _TShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TFromLoc", _TFromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TFromLot", _TFromLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TToLot", _TToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Title", _Title, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemoteSiteLotProcess", _RemoteSiteLotProcess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExistingSerials", _UseExistingSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonCode", _PReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TImportDocId", _TImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExportDocId", _ExportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MoveZeroCostItem", _MoveZeroCostItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
