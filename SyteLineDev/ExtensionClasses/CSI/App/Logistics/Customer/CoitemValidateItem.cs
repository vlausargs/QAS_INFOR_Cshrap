//PROJECT NAME: Logistics
//CLASS NAME: CoitemValidateItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoitemValidateItem : ICoitemValidateItem
	{
		readonly IApplicationDB appDB;
		
		
		public CoitemValidateItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ShipSite,
		string ItemItem,
		string ItemUM,
		string ItemDesc,
		string CustItem,
		decimal? Price,
		string FeatStr,
		int? ItemPlanFlag,
		string ItemFeatTempl,
		string ItemCommCode,
		decimal? ItemUnitWeight,
		string ItemOrigin,
		DateTime? DueDate,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		decimal? DiscPct,
		string Infobar,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		int? Kit,
		int? PrintKitComponents,
		int? ItemReservable,
		int? ItemSerialTracked,
		int? ItemOrderConfigurable,
		int? AllowOnPickList) CoitemValidateItemSp(int? NewRecord,
		string CoNum,
		string CoType,
		DateTime? OrderDate,
		string Item,
		string OldItem,
		string CustNum,
		int? CustSeq,
		decimal? QtyOrderedConv,
		string ItemPriceCode,
		string CurrCode,
		string ShipSite,
		string ItemItem,
		string ItemUM,
		string ItemDesc,
		string CustItem,
		decimal? Price,
		string FeatStr,
		int? ItemPlanFlag,
		string ItemFeatTempl,
		string ItemCommCode,
		decimal? ItemUnitWeight,
		string ItemOrigin,
		DateTime? DueDate,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string TaxCode1,
		string TaxCode1Desc,
		string TaxCode2,
		string TaxCode2Desc,
		decimal? DiscPct,
		string Infobar,
		int? CoLine,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		int? Kit,
		int? PrintKitComponents,
		int? ItemReservable,
		int? ItemSerialTracked = 0,
		int? ItemOrderConfigurable = 0,
		int? AllowOnPickList = 0)
		{
			Flag _NewRecord = NewRecord;
			CoNumType _CoNum = CoNum;
			CoTypeType _CoType = CoType;
			DateType _OrderDate = OrderDate;
			ItemType _Item = Item;
			ItemType _OldItem = OldItem;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			QtyUnitType _QtyOrderedConv = QtyOrderedConv;
			PriceCodeType _ItemPriceCode = ItemPriceCode;
			CurrCodeType _CurrCode = CurrCode;
			SiteType _ShipSite = ShipSite;
			ItemType _ItemItem = ItemItem;
			UMType _ItemUM = ItemUM;
			DescriptionType _ItemDesc = ItemDesc;
			CustItemType _CustItem = CustItem;
			AmountType _Price = Price;
			FeatStrType _FeatStr = FeatStr;
			Flag _ItemPlanFlag = ItemPlanFlag;
			FeatTemplateType _ItemFeatTempl = ItemFeatTempl;
			CommodityCodeType _ItemCommCode = ItemCommCode;
			ItemWeightType _ItemUnitWeight = ItemUnitWeight;
			EcCodeType _ItemOrigin = ItemOrigin;
			DateType _DueDate = DueDate;
			RefTypeIJOType _RefType = RefType;
			CoNumJobType _RefNum = RefNum;
			CoLineSuffixType _RefLineSuf = RefLineSuf;
			CoReleaseOperNumType _RefRelease = RefRelease;
			TaxCodeType _TaxCode1 = TaxCode1;
			DescriptionType _TaxCode1Desc = TaxCode1Desc;
			TaxCodeType _TaxCode2 = TaxCode2;
			DescriptionType _TaxCode2Desc = TaxCode2Desc;
			LineDiscType _DiscPct = DiscPct;
			Infobar _Infobar = Infobar;
			CoLineType _CoLine = CoLine;
			ListYesNoType _SupplQtyReq = SupplQtyReq;
			UMConvFactorType _SupplQtyConvFactor = SupplQtyConvFactor;
			ListYesNoType _Kit = Kit;
			ListYesNoType _PrintKitComponents = PrintKitComponents;
			Flag _ItemReservable = ItemReservable;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;
			ListYesNoType _ItemOrderConfigurable = ItemOrderConfigurable;
			ListYesNoType _AllowOnPickList = AllowOnPickList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoitemValidateItemSp";
				
				appDB.AddCommandParameter(cmd, "NewRecord", _NewRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoType", _CoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDate", _OrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldItem", _OldItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPriceCode", _ItemPriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemItem", _ItemItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemPlanFlag", _ItemPlanFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemFeatTempl", _ItemFeatTempl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCommCode", _ItemCommCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUnitWeight", _ItemUnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemOrigin", _ItemOrigin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiscPct", _DiscPct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplQtyReq", _SupplQtyReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyConvFactor", _SupplQtyConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Kit", _Kit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintKitComponents", _PrintKitComponents, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemReservable", _ItemReservable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemOrderConfigurable", _ItemOrderConfigurable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AllowOnPickList", _AllowOnPickList, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ShipSite = _ShipSite;
				ItemItem = _ItemItem;
				ItemUM = _ItemUM;
				ItemDesc = _ItemDesc;
				CustItem = _CustItem;
				Price = _Price;
				FeatStr = _FeatStr;
				ItemPlanFlag = _ItemPlanFlag;
				ItemFeatTempl = _ItemFeatTempl;
				ItemCommCode = _ItemCommCode;
				ItemUnitWeight = _ItemUnitWeight;
				ItemOrigin = _ItemOrigin;
				DueDate = _DueDate;
				RefType = _RefType;
				RefNum = _RefNum;
				RefLineSuf = _RefLineSuf;
				RefRelease = _RefRelease;
				TaxCode1 = _TaxCode1;
				TaxCode1Desc = _TaxCode1Desc;
				TaxCode2 = _TaxCode2;
				TaxCode2Desc = _TaxCode2Desc;
				DiscPct = _DiscPct;
				Infobar = _Infobar;
				SupplQtyReq = _SupplQtyReq;
				SupplQtyConvFactor = _SupplQtyConvFactor;
				Kit = _Kit;
				PrintKitComponents = _PrintKitComponents;
				ItemReservable = _ItemReservable;
				ItemSerialTracked = _ItemSerialTracked;
				ItemOrderConfigurable = _ItemOrderConfigurable;
				AllowOnPickList = _AllowOnPickList;
				
				return (Severity, ShipSite, ItemItem, ItemUM, ItemDesc, CustItem, Price, FeatStr, ItemPlanFlag, ItemFeatTempl, ItemCommCode, ItemUnitWeight, ItemOrigin, DueDate, RefType, RefNum, RefLineSuf, RefRelease, TaxCode1, TaxCode1Desc, TaxCode2, TaxCode2Desc, DiscPct, Infobar, SupplQtyReq, SupplQtyConvFactor, Kit, PrintKitComponents, ItemReservable, ItemSerialTracked, ItemOrderConfigurable, AllowOnPickList);
			}
		}
	}
}
