//PROJECT NAME: Material
//CLASS NAME: CombineXferShipReceive.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CombineXferShipReceive : ICombineXferShipReceive
	{
		readonly IApplicationDB appDB;
		
		
		public CombineXferShipReceive(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CombineXferShipReceiveSp(string TrnNum,
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
		string DocumentNum = null)
		{
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			ItemType _Item = Item;
			SiteType _FromSite = FromSite;
			WhseType _FromWhse = FromWhse;
			LocType _FromLoc = FromLoc;
			LotType _FromLot = FromLot;
			SiteType _ToSite = ToSite;
			WhseType _ToWhse = ToWhse;
			LocType _ToLoc = ToLoc;
			LotType _ToLot = ToLot;
			QtyUnitType _TQtyShipped = TQtyShipped;
			UMType _TUM = TUM;
			DateType _TShipDate = TShipDate;
			LongListType _Title = Title;
			ListExistingCreateBothType _RemoteSiteLotProcess = RemoteSiteLotProcess;
			ListYesNoType _UseExistingSerials = UseExistingSerials;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			ExportDocIdType _ExportDocId = ExportDocId;
			ReasonCodeType _ReasonCode = ReasonCode;
			ListYesNoType _MoveZeroCostItem = MoveZeroCostItem;
			CurrentDateType _RecordDate = RecordDate;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CombineXferShipReceiveSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyShipped", _TQtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUM", _TUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TShipDate", _TShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Title", _Title, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemoteSiteLotProcess", _RemoteSiteLotProcess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExistingSerials", _UseExistingSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExportDocId", _ExportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MoveZeroCostItem", _MoveZeroCostItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
