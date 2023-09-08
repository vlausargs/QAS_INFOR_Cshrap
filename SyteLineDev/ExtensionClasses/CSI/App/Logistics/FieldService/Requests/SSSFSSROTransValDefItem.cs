//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransValDefItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransValDefItem : ISSSFSSROTransValDefItem
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSROTransValDefItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Whse,
		string Item,
		string ItemDesc,
		string ItemUM,
		int? RtnToStock,
		decimal? UnitCostConv,
		decimal? UnitPriceConv,
		string Lot,
		string Loc,
		decimal? ConvFactor,
		int? SerialTracked,
		int? LotTracked,
		decimal? MatlCostConv,
		decimal? LaborCostConv,
		decimal? FovhdCostConv,
		decimal? VovhdCostConv,
		decimal? OutCostConv,
		decimal? Disc,
		string Prompt,
		string PromptButtons,
		string Infobar,
		string RefType,
		string TaxCode1,
		string TaxCode2,
		int? ItemExists,
		string CustItem,
		string SROCustNum,
		string CostType,
		string LotPrefix,
		string SerialPrefix,
		string TrxRestrictCode,
		string Revision) SSSFSSROTransValDefItemSp(string Table,
		string SRONum,
		int? SROLine,
		int? SROOper,
		DateTime? TransDate,
		string Whse,
		string BillCode,
		string TransType,
		string Item,
		decimal? QtyConv,
		string PriceCurrCode,
		string Pricecode,
		int? ReimbMatl,
		string ItemDesc,
		string ItemUM,
		int? RtnToStock,
		decimal? UnitCostConv,
		decimal? UnitPriceConv,
		string Lot,
		string Loc,
		decimal? ConvFactor,
		int? SerialTracked,
		int? LotTracked,
		decimal? MatlCostConv,
		decimal? LaborCostConv,
		decimal? FovhdCostConv,
		decimal? VovhdCostConv,
		decimal? OutCostConv,
		decimal? Disc,
		string Prompt,
		string PromptButtons,
		string Infobar,
		string RefType = null,
		string Type = "A",
		string TaxCode1 = null,
		string TaxCode2 = null,
		int? ItemExists = null,
		string CustItem = null,
		string SROCustNum = null,
		string CostType = null,
		string LotPrefix = null,
		string SerialPrefix = null,
		int? ValidteItemExistsFlag = 1,
		string TrxRestrictCode = null,
		string Revision = null)
		{
			StringType _Table = Table;
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			DateType _TransDate = TransDate;
			WhseType _Whse = Whse;
			FSSROBillCodeType _BillCode = BillCode;
			FSSROMatlTransTypeType _TransType = TransType;
			ItemType _Item = Item;
			QtyUnitType _QtyConv = QtyConv;
			CurrCodeType _PriceCurrCode = PriceCurrCode;
			PriceCodeType _Pricecode = Pricecode;
			ListYesNoType _ReimbMatl = ReimbMatl;
			DescriptionType _ItemDesc = ItemDesc;
			UMType _ItemUM = ItemUM;
			ListYesNoType _RtnToStock = RtnToStock;
			CostPrcType _UnitCostConv = UnitCostConv;
			CostPrcType _UnitPriceConv = UnitPriceConv;
			LotType _Lot = Lot;
			LocType _Loc = Loc;
			UMConvFactorType _ConvFactor = ConvFactor;
			ListYesNoType _SerialTracked = SerialTracked;
			ListYesNoType _LotTracked = LotTracked;
			CostPrcType _MatlCostConv = MatlCostConv;
			CostPrcType _LaborCostConv = LaborCostConv;
			CostPrcType _FovhdCostConv = FovhdCostConv;
			CostPrcType _VovhdCostConv = VovhdCostConv;
			CostPrcType _OutCostConv = OutCostConv;
			FSPctType _Disc = Disc;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			RefTypeIJKPRTType _RefType = RefType;
			StringType _Type = Type;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			ListYesNoType _ItemExists = ItemExists;
			CustItemType _CustItem = CustItem;
			CustNumType _SROCustNum = SROCustNum;
			CostTypeType _CostType = CostType;
			LotPrefixType _LotPrefix = LotPrefix;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			ListYesNoType _ValidteItemExistsFlag = ValidteItemExistsFlag;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			RevisionType _Revision = Revision;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransValDefItemSp";
				
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceCurrCode", _PriceCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReimbMatl", _ReimbMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RtnToStock", _RtnToStock, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCostConv", _UnitCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPriceConv", _UnitPriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConvFactor", _ConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlCostConv", _MatlCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LaborCostConv", _LaborCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCostConv", _FovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCostConv", _VovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCostConv", _OutCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Disc", _Disc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROCustNum", _SROCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostType", _CostType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotPrefix", _LotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ValidteItemExistsFlag", _ValidteItemExistsFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Whse = _Whse;
				Item = _Item;
				ItemDesc = _ItemDesc;
				ItemUM = _ItemUM;
				RtnToStock = _RtnToStock;
				UnitCostConv = _UnitCostConv;
				UnitPriceConv = _UnitPriceConv;
				Lot = _Lot;
				Loc = _Loc;
				ConvFactor = _ConvFactor;
				SerialTracked = _SerialTracked;
				LotTracked = _LotTracked;
				MatlCostConv = _MatlCostConv;
				LaborCostConv = _LaborCostConv;
				FovhdCostConv = _FovhdCostConv;
				VovhdCostConv = _VovhdCostConv;
				OutCostConv = _OutCostConv;
				Disc = _Disc;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				RefType = _RefType;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				ItemExists = _ItemExists;
				CustItem = _CustItem;
				SROCustNum = _SROCustNum;
				CostType = _CostType;
				LotPrefix = _LotPrefix;
				SerialPrefix = _SerialPrefix;
				TrxRestrictCode = _TrxRestrictCode;
				Revision = _Revision;
				
				return (Severity, Whse, Item, ItemDesc, ItemUM, RtnToStock, UnitCostConv, UnitPriceConv, Lot, Loc, ConvFactor, SerialTracked, LotTracked, MatlCostConv, LaborCostConv, FovhdCostConv, VovhdCostConv, OutCostConv, Disc, Prompt, PromptButtons, Infobar, RefType, TaxCode1, TaxCode2, ItemExists, CustItem, SROCustNum, CostType, LotPrefix, SerialPrefix, TrxRestrictCode, Revision);
			}
		}
	}
}
