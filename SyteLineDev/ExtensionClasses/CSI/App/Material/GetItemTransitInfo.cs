//PROJECT NAME: Material
//CLASS NAME: GetItemTransitInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetItemTransitInfo : IGetItemTransitInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetItemTransitInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Site,
		string Whse,
		string Item,
		string ItemDescription,
		string UM,
		decimal? UmConvFactor,
		string FromLoc,
		string FromLot,
		string TrnLoc,
		string ToLot,
		int? FromLotTracked,
		int? ToLotTracked,
		string RemoteSiteLotProcess,
		int? FromSerialTracked,
		int? ToSerialTracked,
		int? UseExistingSerials,
		string RemoteSerialPrefix,
		int? RemoteExpandSerial,
		decimal? QtyToShip,
		decimal? QtyOnHand,
		decimal? QtyOnHandConv,
		decimal? QtyReq,
		decimal? QtyReqConv,
		decimal? QtyShipped,
		decimal? QtyShippedConv,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ImportDocId,
		int? TaxFreeMatl,
		DateTime? RecordDate,
		int? TrackPieces) GetItemTransitInfoSp(string TrnNum,
		int? TrnLine,
		string Site,
		string Whse,
		string Item,
		string ItemDescription,
		string UM,
		decimal? UmConvFactor,
		string FromLoc,
		string FromLot,
		string TrnLoc,
		string ToLot,
		int? FromLotTracked,
		int? ToLotTracked,
		string RemoteSiteLotProcess,
		int? FromSerialTracked,
		int? ToSerialTracked,
		int? UseExistingSerials,
		string RemoteSerialPrefix,
		int? RemoteExpandSerial,
		decimal? QtyToShip,
		decimal? QtyOnHand,
		decimal? QtyOnHandConv,
		decimal? QtyReq,
		decimal? QtyReqConv,
		decimal? QtyShipped,
		decimal? QtyShippedConv,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ImportDocId,
		int? TaxFreeMatl,
		DateTime? RecordDate = null,
		int? TrackPieces = null)
		{
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			SiteType _Site = Site;
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			DescriptionType _ItemDescription = ItemDescription;
			UMType _UM = UM;
			UMConvFactorType _UmConvFactor = UmConvFactor;
			LocType _FromLoc = FromLoc;
			LotType _FromLot = FromLot;
			LocType _TrnLoc = TrnLoc;
			LotType _ToLot = ToLot;
			ListYesNoType _FromLotTracked = FromLotTracked;
			ListYesNoType _ToLotTracked = ToLotTracked;
			ListExistingCreateBothType _RemoteSiteLotProcess = RemoteSiteLotProcess;
			ListYesNoType _FromSerialTracked = FromSerialTracked;
			ListYesNoType _ToSerialTracked = ToSerialTracked;
			ListYesNoType _UseExistingSerials = UseExistingSerials;
			SerialPrefixType _RemoteSerialPrefix = RemoteSerialPrefix;
			ListYesNoType _RemoteExpandSerial = RemoteExpandSerial;
			QtyUnitType _QtyToShip = QtyToShip;
			QtyUnitType _QtyOnHand = QtyOnHand;
			QtyUnitType _QtyOnHandConv = QtyOnHandConv;
			QtyUnitType _QtyReq = QtyReq;
			QtyUnitType _QtyReqConv = QtyReqConv;
			QtyUnitType _QtyShipped = QtyShipped;
			QtyUnitType _QtyShippedConv = QtyShippedConv;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _TaxFreeMatl = TaxFreeMatl;
			CurrentDateType _RecordDate = RecordDate;
			ListYesNoType _TrackPieces = TrackPieces;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemTransitInfoSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UmConvFactor", _UmConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrnLoc", _TrnLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromLotTracked", _FromLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToLotTracked", _ToLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteSiteLotProcess", _RemoteSiteLotProcess, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromSerialTracked", _FromSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSerialTracked", _ToSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseExistingSerials", _UseExistingSerials, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteSerialPrefix", _RemoteSerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteExpandSerial", _RemoteExpandSerial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyToShip", _QtyToShip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOnHandConv", _QtyOnHandConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyReq", _QtyReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyReqConv", _QtyReqConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyShippedConv", _QtyShippedConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxFreeMatl", _TaxFreeMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrackPieces", _TrackPieces, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Site = _Site;
				Whse = _Whse;
				Item = _Item;
				ItemDescription = _ItemDescription;
				UM = _UM;
				UmConvFactor = _UmConvFactor;
				FromLoc = _FromLoc;
				FromLot = _FromLot;
				TrnLoc = _TrnLoc;
				ToLot = _ToLot;
				FromLotTracked = _FromLotTracked;
				ToLotTracked = _ToLotTracked;
				RemoteSiteLotProcess = _RemoteSiteLotProcess;
				FromSerialTracked = _FromSerialTracked;
				ToSerialTracked = _ToSerialTracked;
				UseExistingSerials = _UseExistingSerials;
				RemoteSerialPrefix = _RemoteSerialPrefix;
				RemoteExpandSerial = _RemoteExpandSerial;
				QtyToShip = _QtyToShip;
				QtyOnHand = _QtyOnHand;
				QtyOnHandConv = _QtyOnHandConv;
				QtyReq = _QtyReq;
				QtyReqConv = _QtyReqConv;
				QtyShipped = _QtyShipped;
				QtyShippedConv = _QtyShippedConv;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				ImportDocId = _ImportDocId;
				TaxFreeMatl = _TaxFreeMatl;
				RecordDate = _RecordDate;
				TrackPieces = _TrackPieces;
				
				return (Severity, Site, Whse, Item, ItemDescription, UM, UmConvFactor, FromLoc, FromLot, TrnLoc, ToLot, FromLotTracked, ToLotTracked, RemoteSiteLotProcess, FromSerialTracked, ToSerialTracked, UseExistingSerials, RemoteSerialPrefix, RemoteExpandSerial, QtyToShip, QtyOnHand, QtyOnHandConv, QtyReq, QtyReqConv, QtyShipped, QtyShippedConv, PromptMsg, PromptButtons, Infobar, ImportDocId, TaxFreeMatl, RecordDate, TrackPieces);
			}
		}
	}
}
