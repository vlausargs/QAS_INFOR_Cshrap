//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InventoryCostCRUD.cs

using System;
using System.Data;
using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_InventoryCostCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string ParmsCurrCode, int? rowCount) CurrparmsLoad(string ParmsCurrCode);
		(int? CostPricePlaces, string CostPriceFormat, int? rowCount) CurrencyLoad(string ParmsCurrCode, string CostPriceFormat, int? CostPricePlaces);
		(int? CostItemAtWhse, int? rowCount) Dbo_InvparmsLoad(int? CostItemAtWhse);
		void SelectInsert_Tv_ItemGeneral(Guid? processId, string ExbegWhse, string ExendWhse, string ExbegLoc, string ExendLoc, string ExbegProductcode, string ExendProductcode,
			string ExbegItem, string ExendItem, string ExOptgoItemStat, string ExOptgoMatlType, string ExOptprPMTCode, string ExOptacAbcCode, int? TStock,
			string ParmsCurrCode, DateTime? GetSiteDate, int? ExOptprPrZeroQty, string CostPriceFormat, int? CostPricePlaces);
		void SelectInsert1_Tv_ItemGeneral(Guid? processId, string ExbegWhse, string ExendWhse, string ExbegLoc, string ExendLoc, string ExbegProductcode, string ExendProductcode,
			string ExbegItem, string ExendItem, string ExOptgoItemStat, string ExOptgoMatlType, string ExOptprPMTCode, string ExOptacAbcCode, int? TStock,
			string ParmsCurrCode, DateTime? GetSiteDate, int? ExOptprPrZeroQty, string CostPriceFormat, int? CostPricePlaces);
		void UpdateTmpItemGeneral0(Guid? processId);
		void UpdateTmpItemGeneral1(Guid? processId);
		void UpdateTmpItemGeneral2(Guid? processId);
		void UpdateTmpItemGeneral3(Guid? processId);
		ICollectionLoadResponse NontableSelect(string Description);
		void NontableInsert(ICollectionLoadResponse nonTableLoadResponse);
		ICollectionLoadResponse Nontable1Select(string Description);
		void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse);
		ICollectionLoadResponse Nontable2Select(string Description);
		void Nontable2Insert(ICollectionLoadResponse nonTable2LoadResponse);
		ICollectionLoadResponse Nontable3Select(string Description);
		void Nontable3Insert(ICollectionLoadResponse nonTable3LoadResponse);
		ICollectionLoadResponse Nontable4Select(string Description);
		void Nontable4Insert(ICollectionLoadResponse nonTable4LoadResponse);
		ICollectionLoadResponse Nontable5Select(string Description);
		void Nontable5Insert(ICollectionLoadResponse nonTable5LoadResponse);
		ICollectionLoadResponse Nontable6Select(string Description);
		void Nontable6Insert(ICollectionLoadResponse nonTable6LoadResponse);
		ICollectionLoadResponse Nontable7Select(string Description);
		void Nontable7Insert(ICollectionLoadResponse nonTable7LoadResponse);
		ICollectionLoadResponse Nontable8Select(string Description);
		void Nontable8Insert(ICollectionLoadResponse nonTable8LoadResponse);
		ICollectionLoadResponse Nontable9Select(string Description);
		void Nontable9Insert(ICollectionLoadResponse nonTable9LoadResponse);
		ICollectionLoadResponse Nontable10Select(string Description);
		void Nontable10Insert(ICollectionLoadResponse nonTable10LoadResponse);
		ICollectionLoadResponse SelectBunchPageFromStaging(Guid? processId, int recordCap, LoadType loadType, int? printCost);
		void CleanupStagingTable(Guid? processId);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_InventoryCostSp(string AltExtGenSp, string ExbegWhse, string ExendWhse, string ExbegLoc, string ExendLoc, string ExbegProductcode, string ExendProductcode, string ExbegItem, string ExendItem, string ExOptgoItemStat, string ExOptgoMatlType, string ExOptprPMTCode, string ExOptszStocked, string ExOptacAbcCode, int? ExOptprPrZeroQty, int? ShowDetail, int? PrintCost, int? DisplayHeader, string PMessageLanguage, string pSite, Guid? ProcessID);
	}
}