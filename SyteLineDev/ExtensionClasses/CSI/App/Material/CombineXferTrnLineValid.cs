//PROJECT NAME: Material
//CLASS NAME: CombineXferTrnLineValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CombineXferTrnLineValid : ICombineXferTrnLineValid
	{
		readonly IApplicationDB appDB;
		
		
		public CombineXferTrnLineValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item,
		string ItemDescription,
		string UM,
		decimal? QtyReqConv,
		decimal? QtyShippedConv,
		decimal? ConvFactor,
		string FromLoc,
		string FromLot,
		int? LotTracked,
		int? RemoteLotTracked,
		string RemoteSiteLotProcess,
		int? SerialTracked,
		int? RemoteSerialTracked,
		int? UseExistingSerials,
		string RemoteSerialPrefix,
		int? RemoteExpandSerial,
		string ToLoc,
		decimal? UnitCost,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ImportDocId,
		int? TaxFreeMatl,
		int? TrackPieces,
		string DimensionGroup,
		int? UbToTrackPieces,
		string UbToDimentionGroup,
		string UbFromLotAttributeGroup,
		string UbToLotAttributeGroup,
		string RemoteLotPrefix,
		int? PreassignLots,
		int? PreassignSerials,
		decimal? UbQtyOnHandConv) CombineXferTrnLineValidSp(string TrnNum,
		int? TrnLine,
		string FromSite,
		string FromWhse,
		string ToSite,
		string ToWhse,
		string Item,
		string ItemDescription,
		string UM,
		decimal? QtyReqConv,
		decimal? QtyShippedConv,
		decimal? ConvFactor,
		string FromLoc,
		string FromLot,
		int? LotTracked,
		int? RemoteLotTracked,
		string RemoteSiteLotProcess,
		int? SerialTracked,
		int? RemoteSerialTracked,
		int? UseExistingSerials,
		string RemoteSerialPrefix,
		int? RemoteExpandSerial,
		string ToLoc,
		decimal? UnitCost,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ImportDocId,
		int? TaxFreeMatl,
		int? TrackPieces = null,
		string DimensionGroup = null,
		int? UbToTrackPieces = null,
		string UbToDimentionGroup = null,
		string UbFromLotAttributeGroup = null,
		string UbToLotAttributeGroup = null,
		string RemoteLotPrefix = null,
		int? PreassignLots = null,
		int? PreassignSerials = null,
		decimal? UbQtyOnHandConv = null)
		{
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			SiteType _FromSite = FromSite;
			WhseType _FromWhse = FromWhse;
			SiteType _ToSite = ToSite;
			WhseType _ToWhse = ToWhse;
			ItemType _Item = Item;
			DescriptionType _ItemDescription = ItemDescription;
			UMType _UM = UM;
			QtyUnitType _QtyReqConv = QtyReqConv;
			QtyUnitType _QtyShippedConv = QtyShippedConv;
			UMConvFactorType _ConvFactor = ConvFactor;
			LocType _FromLoc = FromLoc;
			LotType _FromLot = FromLot;
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _RemoteLotTracked = RemoteLotTracked;
			ListExistingCreateBothType _RemoteSiteLotProcess = RemoteSiteLotProcess;
			ListYesNoType _SerialTracked = SerialTracked;
			ListYesNoType _RemoteSerialTracked = RemoteSerialTracked;
			ListYesNoType _UseExistingSerials = UseExistingSerials;
			SerialPrefixType _RemoteSerialPrefix = RemoteSerialPrefix;
			ListYesNoType _RemoteExpandSerial = RemoteExpandSerial;
			LocType _ToLoc = ToLoc;
			CostPrcType _UnitCost = UnitCost;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _TaxFreeMatl = TaxFreeMatl;
			ListYesNoType _TrackPieces = TrackPieces;
			AttributeGroupType _DimensionGroup = DimensionGroup;
			ListYesNoType _UbToTrackPieces = UbToTrackPieces;
			AttributeGroupType _UbToDimentionGroup = UbToDimentionGroup;
			AttributeGroupType _UbFromLotAttributeGroup = UbFromLotAttributeGroup;
			AttributeGroupType _UbToLotAttributeGroup = UbToLotAttributeGroup;
			LotPrefixType _RemoteLotPrefix = RemoteLotPrefix;
			ListYesNoType _PreassignLots = PreassignLots;
			ListYesNoType _PreassignSerials = PreassignSerials;
			QtyUnitType _UbQtyOnHandConv = UbQtyOnHandConv;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CombineXferTrnLineValidSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyReqConv", _QtyReqConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyShippedConv", _QtyShippedConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConvFactor", _ConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteLotTracked", _RemoteLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteSiteLotProcess", _RemoteSiteLotProcess, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteSerialTracked", _RemoteSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseExistingSerials", _UseExistingSerials, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteSerialPrefix", _RemoteSerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteExpandSerial", _RemoteExpandSerial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxFreeMatl", _TaxFreeMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrackPieces", _TrackPieces, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DimensionGroup", _DimensionGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UbToTrackPieces", _UbToTrackPieces, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UbToDimentionGroup", _UbToDimentionGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UbFromLotAttributeGroup", _UbFromLotAttributeGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UbToLotAttributeGroup", _UbToLotAttributeGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteLotPrefix", _RemoteLotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UbQtyOnHandConv", _UbQtyOnHandConv, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				ItemDescription = _ItemDescription;
				UM = _UM;
				QtyReqConv = _QtyReqConv;
				QtyShippedConv = _QtyShippedConv;
				ConvFactor = _ConvFactor;
				FromLoc = _FromLoc;
				FromLot = _FromLot;
				LotTracked = _LotTracked;
				RemoteLotTracked = _RemoteLotTracked;
				RemoteSiteLotProcess = _RemoteSiteLotProcess;
				SerialTracked = _SerialTracked;
				RemoteSerialTracked = _RemoteSerialTracked;
				UseExistingSerials = _UseExistingSerials;
				RemoteSerialPrefix = _RemoteSerialPrefix;
				RemoteExpandSerial = _RemoteExpandSerial;
				ToLoc = _ToLoc;
				UnitCost = _UnitCost;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				ImportDocId = _ImportDocId;
				TaxFreeMatl = _TaxFreeMatl;
				TrackPieces = _TrackPieces;
				DimensionGroup = _DimensionGroup;
				UbToTrackPieces = _UbToTrackPieces;
				UbToDimentionGroup = _UbToDimentionGroup;
				UbFromLotAttributeGroup = _UbFromLotAttributeGroup;
				UbToLotAttributeGroup = _UbToLotAttributeGroup;
				RemoteLotPrefix = _RemoteLotPrefix;
				PreassignLots = _PreassignLots;
				PreassignSerials = _PreassignSerials;
				UbQtyOnHandConv = _UbQtyOnHandConv;
				
				return (Severity, Item, ItemDescription, UM, QtyReqConv, QtyShippedConv, ConvFactor, FromLoc, FromLot, LotTracked, RemoteLotTracked, RemoteSiteLotProcess, SerialTracked, RemoteSerialTracked, UseExistingSerials, RemoteSerialPrefix, RemoteExpandSerial, ToLoc, UnitCost, PromptMsg, PromptButtons, Infobar, ImportDocId, TaxFreeMatl, TrackPieces, DimensionGroup, UbToTrackPieces, UbToDimentionGroup, UbFromLotAttributeGroup, UbToLotAttributeGroup, RemoteLotPrefix, PreassignLots, PreassignSerials, UbQtyOnHandConv);
			}
		}
	}
}
