//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROMatlDCItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROMatlDCItem
	{
		(int? ReturnCode, string Description, string UM, string Loc, string Lot, byte? LotTracked, byte? SerialTracked, decimal? UnitCostConv, decimal? UnitPriceConv, string CurrCode, string CustNum, string Pricecode, string Infobar, string CustItem, string LotPrefix, string Prompt, string PromptButtons) SSSFSSROMatlDCItemSp(string PartnerId,
		string SroNum,
		int? SroLine,
		int? SroOper,
		DateTime? TransDate,
		string Item,
		string Whse,
		decimal? QtyConv,
		string BillCode,
		string TransType,
		string Description,
		string UM,
		string Loc,
		string Lot,
		byte? LotTracked,
		byte? SerialTracked,
		decimal? UnitCostConv,
		decimal? UnitPriceConv,
		string CurrCode,
		string CustNum,
		string Pricecode,
		string Infobar,
		string CustItem,
		string LotPrefix,
		string Prompt = null,
		string PromptButtons = null,
		byte? ValidteItemExistsFlag = (byte)1);
	}
	
	public class SSSFSSROMatlDCItem : ISSSFSSROMatlDCItem
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROMatlDCItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Description, string UM, string Loc, string Lot, byte? LotTracked, byte? SerialTracked, decimal? UnitCostConv, decimal? UnitPriceConv, string CurrCode, string CustNum, string Pricecode, string Infobar, string CustItem, string LotPrefix, string Prompt, string PromptButtons) SSSFSSROMatlDCItemSp(string PartnerId,
		string SroNum,
		int? SroLine,
		int? SroOper,
		DateTime? TransDate,
		string Item,
		string Whse,
		decimal? QtyConv,
		string BillCode,
		string TransType,
		string Description,
		string UM,
		string Loc,
		string Lot,
		byte? LotTracked,
		byte? SerialTracked,
		decimal? UnitCostConv,
		decimal? UnitPriceConv,
		string CurrCode,
		string CustNum,
		string Pricecode,
		string Infobar,
		string CustItem,
		string LotPrefix,
		string Prompt = null,
		string PromptButtons = null,
		byte? ValidteItemExistsFlag = (byte)1)
		{
			FSPartnerType _PartnerId = PartnerId;
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			DateType _TransDate = TransDate;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			QtyUnitType _QtyConv = QtyConv;
			FSSROBillCodeType _BillCode = BillCode;
			FSSROMatlTransTypeType _TransType = TransType;
			DescriptionType _Description = Description;
			UMType _UM = UM;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _SerialTracked = SerialTracked;
			CostPrcType _UnitCostConv = UnitCostConv;
			CostPrcType _UnitPriceConv = UnitPriceConv;
			CurrCodeType _CurrCode = CurrCode;
			CustNumType _CustNum = CustNum;
			PriceCodeType _Pricecode = Pricecode;
			InfobarType _Infobar = Infobar;
			CustItemType _CustItem = CustItem;
			LotPrefixType _LotPrefix = LotPrefix;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			ListYesNoType _ValidteItemExistsFlag = ValidteItemExistsFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROMatlDCItemSp";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCostConv", _UnitCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPriceConv", _UnitPriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotPrefix", _LotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ValidteItemExistsFlag", _ValidteItemExistsFlag, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				UM = _UM;
				Loc = _Loc;
				Lot = _Lot;
				LotTracked = _LotTracked;
				SerialTracked = _SerialTracked;
				UnitCostConv = _UnitCostConv;
				UnitPriceConv = _UnitPriceConv;
				CurrCode = _CurrCode;
				CustNum = _CustNum;
				Pricecode = _Pricecode;
				Infobar = _Infobar;
				CustItem = _CustItem;
				LotPrefix = _LotPrefix;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				
				return (Severity, Description, UM, Loc, Lot, LotTracked, SerialTracked, UnitCostConv, UnitPriceConv, CurrCode, CustNum, Pricecode, Infobar, CustItem, LotPrefix, Prompt, PromptButtons);
			}
		}
	}
}
