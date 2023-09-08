//PROJECT NAME: Material
//CLASS NAME: IGetItemTransitInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetItemTransitInfo
	{
		(int? ReturnCode, string Site,
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
		int? TrackPieces = null);
	}
}

