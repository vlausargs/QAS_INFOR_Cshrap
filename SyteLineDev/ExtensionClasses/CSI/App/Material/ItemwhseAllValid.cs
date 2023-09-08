//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemwhseAllValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemwhseAllValid
	{
		(int? ReturnCode, string Item, string ItemDescription, string UM, byte? FromSiteSerialTracked, byte? FromSiteLotTracked, byte? ToSiteSerialTracked, byte? ToSiteLotTracked, string FromLoc, string FromLot, string ToLoc, string ToLot, string RemoteFromLotProcess, string RemoteToLotProcess, string ToSiteSerialPrefix, byte? ToSiteExpandSerial, string PromptMsg, string PromptButtons, string Infobar, string ImportDocId, byte? TaxFreeMatl, string FromLotAttributeGroup, string ToLotAttributeGroup, string FromSiteDimensionGroup, string ToSiteDimensionGroup, byte? FromSiteTrackPieces, byte? ToSiteTrackPieces, string ToSiteLotPrefix, string FromSiteLotTrxRestrictCode) ItemwhseAllValidSp(string ValidationType,
		string FromSite,
		string FromWhse,
		string ToSite,
		string ToWhse,
		string Item,
		string ItemDescription,
		string UM,
		byte? FromSiteSerialTracked,
		byte? FromSiteLotTracked,
		byte? ToSiteSerialTracked,
		byte? ToSiteLotTracked,
		string FromLoc,
		string FromLot,
		string ToLoc,
		string ToLot,
		string RemoteFromLotProcess,
		string RemoteToLotProcess,
		string ToSiteSerialPrefix,
		byte? ToSiteExpandSerial,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ImportDocId,
		byte? TaxFreeMatl = (byte)0,
		string FromLotAttributeGroup = null,
		string ToLotAttributeGroup = null,
		string FromSiteDimensionGroup = null,
		string ToSiteDimensionGroup = null,
		byte? FromSiteTrackPieces = null,
		byte? ToSiteTrackPieces = null,
		string ToSiteLotPrefix = null,
		string FromSiteLotTrxRestrictCode = null);
	}
	
	public class ItemwhseAllValid : IItemwhseAllValid
	{
		readonly IApplicationDB appDB;
		
		public ItemwhseAllValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item, string ItemDescription, string UM, byte? FromSiteSerialTracked, byte? FromSiteLotTracked, byte? ToSiteSerialTracked, byte? ToSiteLotTracked, string FromLoc, string FromLot, string ToLoc, string ToLot, string RemoteFromLotProcess, string RemoteToLotProcess, string ToSiteSerialPrefix, byte? ToSiteExpandSerial, string PromptMsg, string PromptButtons, string Infobar, string ImportDocId, byte? TaxFreeMatl, string FromLotAttributeGroup, string ToLotAttributeGroup, string FromSiteDimensionGroup, string ToSiteDimensionGroup, byte? FromSiteTrackPieces, byte? ToSiteTrackPieces, string ToSiteLotPrefix, string FromSiteLotTrxRestrictCode) ItemwhseAllValidSp(string ValidationType,
		string FromSite,
		string FromWhse,
		string ToSite,
		string ToWhse,
		string Item,
		string ItemDescription,
		string UM,
		byte? FromSiteSerialTracked,
		byte? FromSiteLotTracked,
		byte? ToSiteSerialTracked,
		byte? ToSiteLotTracked,
		string FromLoc,
		string FromLot,
		string ToLoc,
		string ToLot,
		string RemoteFromLotProcess,
		string RemoteToLotProcess,
		string ToSiteSerialPrefix,
		byte? ToSiteExpandSerial,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ImportDocId,
		byte? TaxFreeMatl = (byte)0,
		string FromLotAttributeGroup = null,
		string ToLotAttributeGroup = null,
		string FromSiteDimensionGroup = null,
		string ToSiteDimensionGroup = null,
		byte? FromSiteTrackPieces = null,
		byte? ToSiteTrackPieces = null,
		string ToSiteLotPrefix = null,
		string FromSiteLotTrxRestrictCode = null)
		{
			StringType _ValidationType = ValidationType;
			SiteType _FromSite = FromSite;
			WhseType _FromWhse = FromWhse;
			SiteType _ToSite = ToSite;
			WhseType _ToWhse = ToWhse;
			ItemType _Item = Item;
			DescriptionType _ItemDescription = ItemDescription;
			UMType _UM = UM;
			ListYesNoType _FromSiteSerialTracked = FromSiteSerialTracked;
			ListYesNoType _FromSiteLotTracked = FromSiteLotTracked;
			ListYesNoType _ToSiteSerialTracked = ToSiteSerialTracked;
			ListYesNoType _ToSiteLotTracked = ToSiteLotTracked;
			LocType _FromLoc = FromLoc;
			LotType _FromLot = FromLot;
			LocType _ToLoc = ToLoc;
			LotType _ToLot = ToLot;
			ListExistingCreateBothType _RemoteFromLotProcess = RemoteFromLotProcess;
			ListExistingCreateBothType _RemoteToLotProcess = RemoteToLotProcess;
			SerialPrefixType _ToSiteSerialPrefix = ToSiteSerialPrefix;
			ListYesNoType _ToSiteExpandSerial = ToSiteExpandSerial;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			ListYesNoType _TaxFreeMatl = TaxFreeMatl;
			AttributeGroupType _FromLotAttributeGroup = FromLotAttributeGroup;
			AttributeGroupType _ToLotAttributeGroup = ToLotAttributeGroup;
			AttributeGroupType _FromSiteDimensionGroup = FromSiteDimensionGroup;
			AttributeGroupType _ToSiteDimensionGroup = ToSiteDimensionGroup;
			ListYesNoType _FromSiteTrackPieces = FromSiteTrackPieces;
			ListYesNoType _ToSiteTrackPieces = ToSiteTrackPieces;
			LotPrefixType _ToSiteLotPrefix = ToSiteLotPrefix;
			TransRestrictionCodeType _FromSiteLotTrxRestrictCode = FromSiteLotTrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemwhseAllValidSp";
				
				appDB.AddCommandParameter(cmd, "ValidationType", _ValidationType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromSiteSerialTracked", _FromSiteSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromSiteLotTracked", _FromSiteLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSiteSerialTracked", _ToSiteSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSiteLotTracked", _ToSiteLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteFromLotProcess", _RemoteFromLotProcess, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RemoteToLotProcess", _RemoteToLotProcess, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSiteSerialPrefix", _ToSiteSerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSiteExpandSerial", _ToSiteExpandSerial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxFreeMatl", _TaxFreeMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromLotAttributeGroup", _FromLotAttributeGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToLotAttributeGroup", _ToLotAttributeGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromSiteDimensionGroup", _FromSiteDimensionGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSiteDimensionGroup", _ToSiteDimensionGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromSiteTrackPieces", _FromSiteTrackPieces, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSiteTrackPieces", _ToSiteTrackPieces, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSiteLotPrefix", _ToSiteLotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromSiteLotTrxRestrictCode", _FromSiteLotTrxRestrictCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				ItemDescription = _ItemDescription;
				UM = _UM;
				FromSiteSerialTracked = _FromSiteSerialTracked;
				FromSiteLotTracked = _FromSiteLotTracked;
				ToSiteSerialTracked = _ToSiteSerialTracked;
				ToSiteLotTracked = _ToSiteLotTracked;
				FromLoc = _FromLoc;
				FromLot = _FromLot;
				ToLoc = _ToLoc;
				ToLot = _ToLot;
				RemoteFromLotProcess = _RemoteFromLotProcess;
				RemoteToLotProcess = _RemoteToLotProcess;
				ToSiteSerialPrefix = _ToSiteSerialPrefix;
				ToSiteExpandSerial = _ToSiteExpandSerial;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				ImportDocId = _ImportDocId;
				TaxFreeMatl = _TaxFreeMatl;
				FromLotAttributeGroup = _FromLotAttributeGroup;
				ToLotAttributeGroup = _ToLotAttributeGroup;
				FromSiteDimensionGroup = _FromSiteDimensionGroup;
				ToSiteDimensionGroup = _ToSiteDimensionGroup;
				FromSiteTrackPieces = _FromSiteTrackPieces;
				ToSiteTrackPieces = _ToSiteTrackPieces;
				ToSiteLotPrefix = _ToSiteLotPrefix;
				FromSiteLotTrxRestrictCode = _FromSiteLotTrxRestrictCode;
				
				return (Severity, Item, ItemDescription, UM, FromSiteSerialTracked, FromSiteLotTracked, ToSiteSerialTracked, ToSiteLotTracked, FromLoc, FromLot, ToLoc, ToLot, RemoteFromLotProcess, RemoteToLotProcess, ToSiteSerialPrefix, ToSiteExpandSerial, PromptMsg, PromptButtons, Infobar, ImportDocId, TaxFreeMatl, FromLotAttributeGroup, ToLotAttributeGroup, FromSiteDimensionGroup, ToSiteDimensionGroup, FromSiteTrackPieces, ToSiteTrackPieces, ToSiteLotPrefix, FromSiteLotTrxRestrictCode);
			}
		}
	}
}
