//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransValidSROMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransValidSROMatl : ISSSFSSROTransValidSROMatl
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSROTransValidSROMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? SROLine,
		int? SROOper,
		DateTime? TransDate,
		DateTime? PostDate,
		string PartnerID,
		int? PartnerReimbMatl,
		string Dept,
		string Whse,
		string BillCode,
		string TransType,
		int? RtnToStock,
		string Item,
		string ItemDesc,
		string ItemUM,
		string Unit,
		decimal? QtyConv,
		decimal? UnitCostConv,
		decimal? UnitPriceConv,
		string Lot,
		string Loc,
		string TaxCode1,
		string TaxCode2,
		string VatLabel,
		DateTime? ExchDate,
		string UsageType,
		int? SerialTracked,
		int? LotTracked,
		decimal? MatlCostConv,
		decimal? LaborCostConv,
		decimal? FovhdCostConv,
		decimal? VovhdCostConv,
		decimal? OutCostConv,
		decimal? Disc,
		string PriceCode,
		string PriceCurrCode,
		string Prompt,
		string PromptButtons,
		string Infobar,
		string CustItem,
		string SROCustNum,
		string CurAmtFormat,
		string CurCstPrcFormat,
		string ReimbTaxCode1,
		string ReimbTaxCode2,
		string ReimbMethod,
		int? ItemExists,
		string TrxRestrictCode,
		string Revision,
		int? TrackEcn) SSSFSSROTransValidSROMatlSp(string Table,
		string Level,
		string SRONum,
		int? SROLine,
		int? SROOper,
		DateTime? TransDate,
		DateTime? PostDate,
		string PartnerID,
		int? PartnerReimbMatl,
		string Dept,
		string Whse,
		string BillCode,
		string TransType,
		int? RtnToStock,
		string Item,
		string ItemDesc,
		string ItemUM,
		string Unit,
		decimal? QtyConv,
		decimal? UnitCostConv,
		decimal? UnitPriceConv,
		string Lot,
		string Loc,
		string TaxCode1,
		string TaxCode2,
		string VatLabel,
		DateTime? ExchDate,
		string UsageType,
		int? SerialTracked,
		int? LotTracked,
		decimal? MatlCostConv,
		decimal? LaborCostConv,
		decimal? FovhdCostConv,
		decimal? VovhdCostConv,
		decimal? OutCostConv,
		decimal? Disc,
		string PriceCode,
		string PriceCurrCode,
		string Prompt,
		string PromptButtons,
		string Infobar,
		string CustItem,
		string SROCustNum,
		string CurAmtFormat,
		string CurCstPrcFormat,
		string Type = "A",
		string ReimbTaxCode1 = null,
		string ReimbTaxCode2 = null,
		string ReimbMethod = null,
		int? ItemExists = null,
		string TrxRestrictCode = null,
		string Revision = null,
		int? TrackEcn = 0)
		{
			StringType _Table = Table;
			StringType _Level = Level;
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			DateType _TransDate = TransDate;
			DateType _PostDate = PostDate;
			FSPartnerType _PartnerID = PartnerID;
			ListYesNoType _PartnerReimbMatl = PartnerReimbMatl;
			DeptType _Dept = Dept;
			WhseType _Whse = Whse;
			FSSROBillCodeType _BillCode = BillCode;
			FSSROMatlTransTypeType _TransType = TransType;
			ListYesNoType _RtnToStock = RtnToStock;
			ItemType _Item = Item;
			DescriptionType _ItemDesc = ItemDesc;
			UMType _ItemUM = ItemUM;
			SerNumType _Unit = Unit;
			QtyUnitType _QtyConv = QtyConv;
			CostPrcType _UnitCostConv = UnitCostConv;
			CostPrcType _UnitPriceConv = UnitPriceConv;
			LotType _Lot = Lot;
			LocType _Loc = Loc;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			StringType _VatLabel = VatLabel;
			DateType _ExchDate = ExchDate;
			FSSROMatlUsageTypeType _UsageType = UsageType;
			ListYesNoType _SerialTracked = SerialTracked;
			ListYesNoType _LotTracked = LotTracked;
			CostPrcType _MatlCostConv = MatlCostConv;
			CostPrcType _LaborCostConv = LaborCostConv;
			CostPrcType _FovhdCostConv = FovhdCostConv;
			CostPrcType _VovhdCostConv = VovhdCostConv;
			CostPrcType _OutCostConv = OutCostConv;
			FSPctType _Disc = Disc;
			PriceCodeType _PriceCode = PriceCode;
			CurrCodeType _PriceCurrCode = PriceCurrCode;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			CustItemType _CustItem = CustItem;
			CustNumType _SROCustNum = SROCustNum;
			InputMaskType _CurAmtFormat = CurAmtFormat;
			InputMaskType _CurCstPrcFormat = CurCstPrcFormat;
			StringType _Type = Type;
			TaxCodeType _ReimbTaxCode1 = ReimbTaxCode1;
			TaxCodeType _ReimbTaxCode2 = ReimbTaxCode2;
			FSReimbMethodType _ReimbMethod = ReimbMethod;
			ListYesNoType _ItemExists = ItemExists;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			RevisionType _Revision = Revision;
			ListYesNoType _TrackEcn = TrackEcn;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransValidSROMatlSp";
				
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerReimbMatl", _PartnerReimbMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RtnToStock", _RtnToStock, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Unit", _Unit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCostConv", _UnitCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPriceConv", _UnitPriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VatLabel", _VatLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchDate", _ExchDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UsageType", _UsageType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlCostConv", _MatlCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LaborCostConv", _LaborCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCostConv", _FovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCostConv", _VovhdCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCostConv", _OutCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Disc", _Disc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriceCurrCode", _PriceCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROCustNum", _SROCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurAmtFormat", _CurAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurCstPrcFormat", _CurCstPrcFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReimbTaxCode1", _ReimbTaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReimbTaxCode2", _ReimbTaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReimbMethod", _ReimbMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrackEcn", _TrackEcn, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SROLine = _SROLine;
				SROOper = _SROOper;
				TransDate = _TransDate;
				PostDate = _PostDate;
				PartnerID = _PartnerID;
				PartnerReimbMatl = _PartnerReimbMatl;
				Dept = _Dept;
				Whse = _Whse;
				BillCode = _BillCode;
				TransType = _TransType;
				RtnToStock = _RtnToStock;
				Item = _Item;
				ItemDesc = _ItemDesc;
				ItemUM = _ItemUM;
				Unit = _Unit;
				QtyConv = _QtyConv;
				UnitCostConv = _UnitCostConv;
				UnitPriceConv = _UnitPriceConv;
				Lot = _Lot;
				Loc = _Loc;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				VatLabel = _VatLabel;
				ExchDate = _ExchDate;
				UsageType = _UsageType;
				SerialTracked = _SerialTracked;
				LotTracked = _LotTracked;
				MatlCostConv = _MatlCostConv;
				LaborCostConv = _LaborCostConv;
				FovhdCostConv = _FovhdCostConv;
				VovhdCostConv = _VovhdCostConv;
				OutCostConv = _OutCostConv;
				Disc = _Disc;
				PriceCode = _PriceCode;
				PriceCurrCode = _PriceCurrCode;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				CustItem = _CustItem;
				SROCustNum = _SROCustNum;
				CurAmtFormat = _CurAmtFormat;
				CurCstPrcFormat = _CurCstPrcFormat;
				ReimbTaxCode1 = _ReimbTaxCode1;
				ReimbTaxCode2 = _ReimbTaxCode2;
				ReimbMethod = _ReimbMethod;
				ItemExists = _ItemExists;
				TrxRestrictCode = _TrxRestrictCode;
				Revision = _Revision;
				TrackEcn = _TrackEcn;
				
				return (Severity, SROLine, SROOper, TransDate, PostDate, PartnerID, PartnerReimbMatl, Dept, Whse, BillCode, TransType, RtnToStock, Item, ItemDesc, ItemUM, Unit, QtyConv, UnitCostConv, UnitPriceConv, Lot, Loc, TaxCode1, TaxCode2, VatLabel, ExchDate, UsageType, SerialTracked, LotTracked, MatlCostConv, LaborCostConv, FovhdCostConv, VovhdCostConv, OutCostConv, Disc, PriceCode, PriceCurrCode, Prompt, PromptButtons, Infobar, CustItem, SROCustNum, CurAmtFormat, CurCstPrcFormat, ReimbTaxCode1, ReimbTaxCode2, ReimbMethod, ItemExists, TrxRestrictCode, Revision, TrackEcn);
			}
		}
	}
}
