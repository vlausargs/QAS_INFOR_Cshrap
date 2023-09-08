//PROJECT NAME: Logistics
//CLASS NAME: ICoItemPriceBreakMarkupCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoItemPriceBreakMarkupCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string Site, int? rowCount) ParmsLoad(string Site);
		(string CurrparmsCurrCode, int? rowCount) CurrparmsLoad(string CurrparmsCurrCode);
		(string CoCurrCode, DateTime? CoOrderDate, int? CoFixedRate, decimal? CoExchRate, int? rowCount) CoLoad(string CoNum, string CoCurrCode, DateTime? CoOrderDate, int? CoFixedRate, decimal? CoExchRate);
		(string Item, decimal? QtyPerCycle, decimal? ItemQty, int? rowCount) Prod_MixLoad(string CoProductMix, decimal? ProdCycles, decimal? ItemQty, decimal? QtyPerCycle, string Item);
		bool CoitemForExists(string CoNum, string Item);
		ICollectionLoadResponse Coitem1Select(string CoNum);
		void Coitem1Delete(ICollectionLoadResponse coitem1LoadResponse);
		bool JobForExists(string BOMType, string CoNum, int? CoLine, string Item);
		bool Job1ForExists(string BOMType, string CoNum, string CoProductMix);
		bool Coitem2ForExists(string CoNum);
		ICollectionLoadResponse Job_Price_BreakSelect(string CoNum, int? CoLine);
		void Job_Price_BreakDelete(ICollectionLoadResponse job_price_breakLoadResponse);
		ICollectionLoadResponse JobitemSelect(string CoNum, int? CoLine);
		void JobitemDelete(ICollectionLoadResponse jobitemLoadResponse);
		ICollectionLoadResponse Job2Select(string CoNum, int? CoLine);
		void Job2Delete(ICollectionLoadResponse job2LoadResponse);
		bool Job3ForExists(string CoNum, int? CoLine);
		ICollectionLoadResponse Job4Select(string CoNum, int? CoLine);
		void Job4Update(decimal? ProdCycles, decimal? QtyPerCycle, string CoProductMix, ICollectionLoadResponse job4LoadResponse);
		(string job, int? suffix, decimal? PriceBasisValue, decimal? ProdcodeMarkup, decimal? CoDisc, int? rowCount) Job5Load(string CoNum, int? CoLine, string Item, decimal? PriceBasisValue, decimal? CoDisc, string job, int? suffix, decimal? ProdcodeMarkup);
        (decimal? MatlCost, decimal? Fixture, decimal? material, decimal? Tool, decimal? Other, decimal? RunCost, decimal? FixOvhdCost, decimal? VarOvhdCost, decimal? OutSideCost) CostSelect(string CoNum, int? CoLine, decimal? ItemQty, string Item, decimal? RunCost, decimal? FixOvhdCost, decimal? VarOvhdCost, decimal? OutSideCost);
		bool Job_Price_Break1ForExists(string PriceBasis, decimal? ItemQty, string job, int? suffix);
		decimal? JbpSelect(string CoNum, int? CoLine, decimal? ItemQty, string Item, decimal? Fixture, decimal? material, decimal? Other, decimal? Tool, decimal? SetupCost, decimal? RunCost, decimal? FixOvhdCost, decimal? VarOvhdCost, decimal? OutSideCost);
		decimal? ValSelect(decimal? PriceBasisValue, decimal? ProdcodeMarkup, decimal? OutSideCost, decimal? FixOvhdCost, decimal? VarOvhdCost, string PriceBasis, decimal? SetupCost, decimal? material, decimal? RunCost, decimal? Fixture, decimal? ItemQty, decimal? CoDisc, decimal? Other, decimal? Tool, string CoNum, int? CoLine, string Item);
		ICollectionLoadResponse Coitem3Select(string CoNum);
		void Coitem3Update(decimal? ItemQty, string PriceBasis, decimal? PriceBasisValue, decimal? CoDisc, decimal? UnitFixture, decimal? Unitmaterial, decimal? UnitOther, decimal? UnitTool, decimal? unitSetupCost, decimal? UnitRunCost, decimal? UnitFixOvhdCost, decimal? UnitVarOvhdCost, decimal? UnitOutSideCost, decimal? UnitMarkedup, decimal? Yield, string job, int? suffix, ICollectionLoadResponse coitem3LoadResponse);
		ICollectionLoadResponse Coitem4Select(string CoNum, int? CoLine);
		void Coitem4Update(decimal? ItemQty, string PriceBasis, decimal? PriceBasisValue, decimal? CoDisc, decimal? UnitFixture, decimal? Unitmaterial, decimal? UnitOther, decimal? UnitTool, decimal? unitSetupCost, decimal? UnitRunCost, decimal? UnitFixOvhdCost, decimal? UnitVarOvhdCost, decimal? UnitOutSideCost, decimal? UnitMarkedup, string job, int? suffix, ICollectionLoadResponse coitem4LoadResponse);
		(int? ReturnCode, string InfoBar) AltExtGen_CoItemPriceBreakMarkupSp(string AltExtGenSp, string CoNum, int? CoLine, int? VendorPriceBreaks, decimal? ItemQty, decimal? ProdCycles, decimal? QtyPerCycle, string Item, DateTime? DueDate, string Whse, string BOMType, string Resource, string CoProductMix, string AlternateID, string PriceBasis, decimal? PriceBasisValue, decimal? CoDisc, string InfoBar);
	}
}