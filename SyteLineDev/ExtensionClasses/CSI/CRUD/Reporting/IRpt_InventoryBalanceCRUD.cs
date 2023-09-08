//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InventoryBalanceCRUD.cs

using System;
using CSI.Data.Cache;
using CSI.Data.CRUD;

namespace CSI.Reporting
{
    public interface IRpt_InventoryBalanceCRUD
    {
        void DeclareAltgenTable();
        bool Optional_ModuleForExists();
        void InsertOptional_Module1();
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN1(string ALTGEN_SpName);
        void DeleteTv_ALTGEN2(string ALTGEN_SpName);
        void SetXact_Abort();
        void SetIsolationLevel();
        void DeclareTmpInvrptSummSetTable();
        void DeclareTmpItemTable();
        void DeclareTmpSumTable();
        void DeclareTmpLotLocTable();
        void DeclareTmpItemLocTable();
        void DeclareTmpItemLifoTable();
        void DeclareTmpMatltranTable();
        (string Site, int? rowCount) LoadParms(string Site);
        (string XDomCurrency,
             int? DomCurrencyPlaces,
             string DomCurrencyFormat,
             string DomTotCurrencyFormat,
             int? CostPricePlaces,
             string CostPriceFormat, int? rowCount) LoadCurrparms(string XDomCurrency, string DomCurrencyFormat, int? DomCurrencyPlaces, string DomTotCurrencyFormat, string CostPriceFormat, int? CostPricePlaces);
        (string UnitQtyFormat, int? UnitQtyPlaces, int? rowCount) LoadINVPARMS(string UnitQtyFormat, int? UnitQtyPlaces);
        (int? CostItemAtWhse, int? rowCount) LoadDbo_Invparms(int? CostItemAtWhse);
        void InsertTmpItem(
            int? CostItemAtWhse,
            int? AllItem,
            int? AllDocumentNum,
            int? IncludeNonNetStk,
            string WhseStarting,
            string WhseEnding,
            string ProductCodeStarting,
            string ProductCodeEnding,
            string ItemStarting,
            string ItemEnding,
            string LocStarting,
            string LocEnding,
            string DocumentNumStarting,
            string DocumentNumEnding);

        void InsertLotloc(string WhseStarting, string WhseEnding, string LocStarting, string LocEnding);
        void InsertItemloc(string WhseStarting, string WhseEnding, string LocStarting, string LocEnding, int? IncludeNonNetStk);
        void InsertItemLifo(int? CostItemAtWhse, string WhseStarting, string WhseEnding);
        void InsertToSum(int? IncludeNonNetStk);
        void InsertToSum1();
        void InsertToSum2(string WhseStarting, string WhseEnding, string LocStarting, string LocEnding, int? IncludeNonNetStk);
        void UpdateItem();

        void InsertMatltran(
            int? IncludeNonNetStk,
            int? AllWhse,
            string LowChar,
            int? AllLoc,
            int? AllReasonCode,
            int? AllDocumentNum,
            DateTime? TransDateStarting,
            DateTime? Today,
            string WhseStarting,
            string WhseEnding,
            string LocStarting,
            string LocEnding,
            string ReasonCodeStarting,
            string ReasonCodeEnding,
            string DocumentNumStarting,
            string DocumentNumEnding);

        void DeclareTmpTranSumTable();
        void InsertTranSum1(int? DomCurrencyPlaces);
        void UpdateTransum2(int? DomCurrencyPlaces);
        void DeleteTv_SUM3();
        void InsertSum4(DateTime? TransDateStarting);
        void UpdateItem1();
        void UpdateItem2();
        void UpdateItem3();
        void Tnsert_Invrpt_Summ_Set(DateTime? TransDateStarting, DateTime? TransDateEnding, int? IncludeMoveTrn);
        void Insert_Invrpt_Summ_Set_others();

        void DeclareTmpMatltranInfoTable();
        void InsertMatltraninfo1(string Site, DateTime? TransDateStarting, DateTime? TransDateEnding);
        void InsertMatltranInfoTemp();
        void InsertMatltraninfo2(string Site);
        void Insert_Invrpt_Det_Summ_Merged(Guid? ProcessId);
        void InsertMatltranInfo3(Guid? ProcessId);
        void DeleteTv_Invrpt_Det_Summ_Merged1(int? IncludeMoveTrn, Guid? ProcessId);
        void InsertInvrpt_Det_Summ_Merged(Guid? ProcessId);
        void UpdateTv_Invrpt_Det_Summ_Merged2(Guid? ProcessId);
        ICollectionLoadResponse SelectTv_Invrpt_Det_Summ_Merged3(DateTime? TransDateStarting,
            DateTime? TransDateEndingOutput,
            string DomCurrencyFormat,
            int? DomCurrencyPlaces,
            string DomTotCurrencyFormat,
            int? DomTotCurrencyPlaces,
            string CostPriceFormat,
            int? CostPricePlaces,
            string UnitQtyFormat,
            int? UnitQtyPlaces,
            int? FeatureRS8938Active,
            Guid? ProcessId,
            LoadType loadType,
            int recordCap);
        void CleanupInventoryBalanceResult(Guid? ProcessId);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_InventoryBalanceSp(string AltExtGenSp, string ProductCodeStarting, string ProductCodeEnding, string ItemStarting, string ItemEnding, string WhseStarting, string WhseEnding, string LocStarting, string LocEnding, DateTime? TransDateStarting, DateTime? TransDateEnding, string ReasonCodeStarting, string ReasonCodeEnding, int? SummaryDtl, int? OneItmPerPg, int? IncludeMoveTrn, int? IncludeNonNetStk, int? DisplayHeader, int? TransDateStartingOffset, int? TransDateEndingOffset, string pSite, string MessageLanguage, string DocumentNumStarting, string DocumentNumEnding);
    }
}

