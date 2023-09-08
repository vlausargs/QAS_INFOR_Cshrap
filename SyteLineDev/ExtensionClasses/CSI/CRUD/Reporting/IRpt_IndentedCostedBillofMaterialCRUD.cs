//PROJECT NAME: Reporting
//CLASS NAME: IRpt_IndentedCostedBillofMaterialCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_IndentedCostedBillofMaterialCRUD
    {
        bool ForExists_Optional_Module();
        void DeclareTable_ALTGEN();
        void InsertOptional_Module1();
        bool ForExists_Tv_ALTGEN();
        (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN1(string ALTGEN_SpName);
        void DeleteTv_ALTGEN2(string ALTGEN_SpName);
        void SetTransaction();
        (int? CostItemAtWhse, string DefaultWhse, int? rowCount) LoadDbo_Invparms(Guid? RptSessionID, string pSite, int? CostItemAtWhse, string DefaultWhse);
        void DeclareTable_loop();
        void DeclareTable_loop2();
        (int? PlacesQtyPer, string QtyPerFormat, int? rowCount) LoadInvparms(string QtyPerFormat, int? PlacesQtyPer);
        (string CstPrcFormat, int? PlacesCp, int? rowCount) LoadCurrency(string CstPrcFormat, int? PlacesCp);
        ICollectionLoadRequest SelectItem(string ItemStarting, string ItemEnding, string ProCodeStarting, string ProCodeEnding, string AlternateIDStarting, string AlternateIDEnding, string MaterialType, string Source, string ABCCode, int? PrintAlternate, int? Stocked2, string DefaultWhse);
        ICollectionLoadRequest SelectItem1(string ItemStarting, string ItemEnding, string ProCodeStarting, string ProCodeEnding, string AlternateIDStarting, string AlternateIDEnding, string MaterialType, string Source, string ABCCode, int? PrintAlternate, int? Stocked2);
        bool ForExists_Jobmatl(string item);
        ICollectionLoadResponse SelectNontable(string Level, string tItem, string tpmt, decimal? tQty, string tum, string tunit, decimal? tLot, string tType, decimal? tMatl, decimal? tOvhd, string tDesc, decimal? tLabor, decimal? tOuts, string QtyPerFormat, int? PlacesQtyPer, string CstPrcFormat, int? PlacesCp, string bom_alternate_id, int? LevelItemCount);
        void DeleteTv_Loop();
        void InsertLoop(int? Level3, DateTime? EffDate, string tJob, int? job_suffix);
        ICollectionLoadResponse SelectTv_Loop1();
        void DeleteTv_LoopTwo();
        ICollectionLoadResponse SelectNontable1(int? Level1, string item1, string job1, int? suffix1, decimal? matlqtyconv1, string um1, string matltype1, string units1, string description1, decimal? cost1);
        void InsertNontable1(ICollectionLoadResponse nonTable1LoadResponse);
        ICollectionLoadResponse SelectJobmatl1(DateTime? EffDate, string item1);
        void InsertJobmatl1(ICollectionLoadResponse jobmatl1LoadResponse);
        void DeleteTv_Loop2();
        void InsertLoop1();
        ICollectionLoadResponse SelectTv_Loop3();
        bool ForExists_Item2(string tItem);
        (string tJob,
             string tDesc,
             string tpmt,
             int? tSuff,
             decimal? tLot,
             decimal? tMatl,
             decimal? tLabor,
             decimal? tOvhd,
             decimal? tOuts,
             string um, int? rowCount) LoadItem3(string tItem, string um, string tpmt, decimal? tLot, decimal? tMatl, decimal? tOvhd, string tDesc, decimal? tLabor, decimal? tOuts, string tJob, int? tSuff, string DefaultWhse);
        (string tJob,
             string tDesc,
             string tpmt,
             int? tSuff,
             decimal? tLot,
             decimal? tMatl,
             decimal? tLabor,
             decimal? tOvhd,
             decimal? tOuts,
             string um, int? rowCount) LoadItem4(string tItem, string um, string tpmt, decimal? tLot, decimal? tMatl, decimal? tOvhd, string tDesc, decimal? tLabor, decimal? tOuts, string tJob, int? tSuff);
        (decimal? convFactor, int? rowCount) LoadU_M_Conv(string um, string tum, string tItem, decimal? convFactor);
        (decimal? convFactor, int? rowCount) LoadU_M_Conv1(string um, string tum, string tItem, decimal? convFactor);
        (decimal? convFactor, int? rowCount) LoadU_M_Conv2(string um, string tum, decimal? convFactor);
        (decimal? convFactor, int? rowCount) LoadU_M_Conv3(string um, string tum, decimal? convFactor);
        ICollectionLoadResponse SelectNontable3(string Level, string tItem, string tpmt, decimal? tQty, string tum, string tunit, decimal? tLot, string tType, decimal? tMatl, decimal? tOvhd, string tDesc, decimal? tLabor, decimal? tOuts, string QtyPerFormat, int? PlacesQtyPer, string CstPrcFormat, int? PlacesCp, string bom_alternate_id, int? LevelItemCount);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_IndentedCostedBillofMaterialSp(string AltExtGenSp, string ItemStarting, string ItemEnding, string ProCodeStarting, string ProCodeEnding, string AlternateIDStarting, string AlternateIDEnding, string MaterialType, string Source, string Stocked, string ABCCode, DateTime? EffDate, string PrBetweenLevel0, int? PrLevelZero, int? DisplayHeader, int? PrintAlternate, int? EffDateOffSet, string pSite);
    }
}

