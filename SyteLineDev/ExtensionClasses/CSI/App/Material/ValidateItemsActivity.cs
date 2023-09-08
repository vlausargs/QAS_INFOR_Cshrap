//PROJECT NAME: Material
//CLASS NAME: ValidateItemsActivity.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IValidateItemsActivity
	{
		(int? ReturnCode, string Infobar, string PromptObsSlow, string PromptObsSlowButtons, string Description, string UM, byte? ItemSerialTracked, byte? ItemLotTracked, decimal? QtyOnHand, string PromptCheckCntIn, string PromptCheckCntInButtons, string Loc, string Lot, string ImportDocId, string TrxRestrictCode) ValidateItemsActivitySp(string Item,
		byte? WarnIfSlowMoving = (byte)1,
		byte? ErrorIfSlowMoving = (byte)0,
		byte? WarnIfObsolete = (byte)0,
		byte? ErrorIfObsolete = (byte)1,
		string Infobar = null,
		string PromptObsSlow = null,
		string PromptObsSlowButtons = null,
		string Site = null,
		string Whse = null,
		byte? CheckLotTracked = null,
		byte? CheckSerialTracked = null,
		string FormTitle = null,
		string Description = null,
		string UM = null,
		byte? ItemSerialTracked = null,
		byte? ItemLotTracked = null,
		decimal? QtyOnHand = null,
		string PromptCheckCntIn = null,
		string PromptCheckCntInButtons = null,
		string Loc = null,
		string Lot = null,
		string ImportDocId = null,
		string TrxRestrictCode = null);
	}
	
	public class ValidateItemsActivity : IValidateItemsActivity
	{
		readonly IApplicationDB appDB;
		
		public ValidateItemsActivity(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, string PromptObsSlow, string PromptObsSlowButtons, string Description, string UM, byte? ItemSerialTracked, byte? ItemLotTracked, decimal? QtyOnHand, string PromptCheckCntIn, string PromptCheckCntInButtons, string Loc, string Lot, string ImportDocId, string TrxRestrictCode) ValidateItemsActivitySp(string Item,
		byte? WarnIfSlowMoving = (byte)1,
		byte? ErrorIfSlowMoving = (byte)0,
		byte? WarnIfObsolete = (byte)0,
		byte? ErrorIfObsolete = (byte)1,
		string Infobar = null,
		string PromptObsSlow = null,
		string PromptObsSlowButtons = null,
		string Site = null,
		string Whse = null,
		byte? CheckLotTracked = null,
		byte? CheckSerialTracked = null,
		string FormTitle = null,
		string Description = null,
		string UM = null,
		byte? ItemSerialTracked = null,
		byte? ItemLotTracked = null,
		decimal? QtyOnHand = null,
		string PromptCheckCntIn = null,
		string PromptCheckCntInButtons = null,
		string Loc = null,
		string Lot = null,
		string ImportDocId = null,
		string TrxRestrictCode = null)
		{
			ItemType _Item = Item;
			Flag _WarnIfSlowMoving = WarnIfSlowMoving;
			Flag _ErrorIfSlowMoving = ErrorIfSlowMoving;
			Flag _WarnIfObsolete = WarnIfObsolete;
			Flag _ErrorIfObsolete = ErrorIfObsolete;
			Infobar _Infobar = Infobar;
			Infobar _PromptObsSlow = PromptObsSlow;
			Infobar _PromptObsSlowButtons = PromptObsSlowButtons;
			SiteType _Site = Site;
			WhseType _Whse = Whse;
			ListYesNoType _CheckLotTracked = CheckLotTracked;
			ListYesNoType _CheckSerialTracked = CheckSerialTracked;
			LongListType _FormTitle = FormTitle;
			DescriptionType _Description = Description;
			UMType _UM = UM;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			QtyTotlType _QtyOnHand = QtyOnHand;
			Infobar _PromptCheckCntIn = PromptCheckCntIn;
			Infobar _PromptCheckCntInButtons = PromptCheckCntInButtons;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			ImportDocIdType _ImportDocId = ImportDocId;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateItemsActivitySp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarnIfSlowMoving", _WarnIfSlowMoving, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorIfSlowMoving", _ErrorIfSlowMoving, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarnIfObsolete", _WarnIfObsolete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorIfObsolete", _ErrorIfObsolete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptObsSlow", _PromptObsSlow, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptObsSlowButtons", _PromptObsSlowButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckLotTracked", _CheckLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckSerialTracked", _CheckSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FormTitle", _FormTitle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptCheckCntIn", _PromptCheckCntIn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptCheckCntInButtons", _PromptCheckCntInButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PromptObsSlow = _PromptObsSlow;
				PromptObsSlowButtons = _PromptObsSlowButtons;
				Description = _Description;
				UM = _UM;
				ItemSerialTracked = _ItemSerialTracked;
				ItemLotTracked = _ItemLotTracked;
				QtyOnHand = _QtyOnHand;
				PromptCheckCntIn = _PromptCheckCntIn;
				PromptCheckCntInButtons = _PromptCheckCntInButtons;
				Loc = _Loc;
				Lot = _Lot;
				ImportDocId = _ImportDocId;
				TrxRestrictCode = _TrxRestrictCode;
				
				return (Severity, Infobar, PromptObsSlow, PromptObsSlowButtons, Description, UM, ItemSerialTracked, ItemLotTracked, QtyOnHand, PromptCheckCntIn, PromptCheckCntInButtons, Loc, Lot, ImportDocId, TrxRestrictCode);
			}
		}
	}
}
