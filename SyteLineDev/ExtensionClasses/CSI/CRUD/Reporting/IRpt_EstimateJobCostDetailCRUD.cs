//PROJECT NAME: Reporting
//CLASS NAME: IRpt_EstimateJobCostDetailCRUD.cs

using System;
using System.Data;
using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_EstimateJobCostDetailCRUD
    {
        void DeclareAltgenTable();
        bool Optional_ModuleForExists();
        void InsertOptional_Module();
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
        void DeleteTv_ALTGEN(string ALTGEN_SpName);
        void SetIsolationLevel();
        (string XDomCurrency, int? rowCount) LoadCurrparms(string XDomCurrency);
        (int? CostPricePlaces, string CostPriceFormat, int? CurrencyPlaces, string CurrencyFormat, int? rowCount) LoadCurrency(string XDomCurrency, string CostPriceFormat, int? CostPricePlaces, string CurrencyFormat, int? CurrencyPlaces);
        IRecordStream SelectJob(string ExOpordnumStarting, string ExOpordnumENDing, string ExOptgoOrdType, int? ExOpsuffixStarting, int? ExOpsuffixENDing, string ExOptdfEjobStat, string ExOpjobStarting, string ExOpjobENDing, string ExOpItemStarting, string ExOpItemENDing, string ExOpCustStarting, string ExOpCustENDing, DateTime? ExOpJobDateStarting, DateTime? ExOpJobDateENDing, string StartProspect, string EndProspect, int? AllExOpjob, int? AllExOpsuffix, int? AllExOpItem, int? AllExOpJobDate, int? AllExOpCust, int? AllExOpordnum, int? AllProspect, int pageSize, LoadType loadType);
        IRecordStream SelectJobroute(string ExOpordnumStarting, string ExOpordnumENDing, string ExOptgoOrdType, int? ExOpsuffixStarting, int? ExOpsuffixENDing, string ExOptdfEjobStat, string ExOpjobStarting, string ExOpjobENDing, string ExOpItemStarting, string ExOpItemENDing, string ExOpCustStarting, string ExOpCustENDing, DateTime? ExOpJobDateStarting, DateTime? ExOpJobDateENDing, string StartProspect, string EndProspect, int? AllExOpjob, int? AllExOpsuffix, int? AllExOpItem, int? AllExOpJobDate, int? AllExOpCust, int? AllExOpordnum, int? AllProspect, int pageSize, LoadType loadType);
        IRecordStream SelectJobmatl(string ExOpordnumStarting, string ExOpordnumENDing, string ExOptgoOrdType, int? ExOpsuffixStarting, int? ExOpsuffixENDing, string ExOptdfEjobStat, string ExOpjobStarting, string ExOpjobENDing, string ExOpItemStarting, string ExOpItemENDing, string ExOpCustStarting, string ExOpCustENDing, DateTime? ExOpJobDateStarting, DateTime? ExOpJobDateENDing, string StartProspect, string EndProspect, int? AllExOpjob, int? AllExOpsuffix, int? AllExOpItem, int? AllExOpJobDate, int? AllExOpCust, int? AllExOpordnum, int? AllProspect, int pageSize, LoadType loadType);

        ICollectionLoadResponse SelectNontable(
            string Job = null,
            int? JobSuffix = 0,
            DateTime? JobDate = null,
            string CustNum = null,
            string ProspectId = null,
            decimal? QtyReleased = null,
            string Item = null,
            string Stat = null,
            string Ref = null,
            string Des = null,
            int? OperNum = null,
            string Wc = null,
            DateTime? jrt_schStartDate = null,
            DateTime? jrt_schEndDate = null,
            decimal? TcCprPlanSetupCost = null,
            decimal? TcCprPlanRunCost = null,
            decimal? TcCprPlanMatl = null,
            decimal? TcCprPlanOvhd = null,
            decimal? TcCprPlanTot = null,
            decimal? Setup = null,
            decimal? Run = null,
            decimal? Overhead = null,
            decimal? Total = null,
            decimal? Machine = null,
            decimal? MACHINEOverhead = null,
            string Type = null,
            string ItemDetail = null,
            string Per = null,
            decimal? Cost = null,
            decimal? Ovhd = null,
            string TRef = null,
            string ItemDesc = null,
            string MJobmatlMatlType = null,
            string MJobmatlItem = null,
            string MJobmatlUnits = null,
            decimal? MTcCprPlanMatl = null,
            decimal? MTcCprPlanMatlOvhd = null,
            string MTRef = null,
            string MItemDescription = null,
            decimal? LTcCprPlanSetupCost = null,
            decimal? LTcCprPlanRunCost = null,
            decimal? LTcCprPlanLbrOvhd = null,
            decimal? LTcCprPlanLbrTot = null,
            DateTime? Ljrt_schStartDate = null,
            DateTime? Ljrt_schEndDate = null,
            decimal? ETPlanMchHrs = null,
            decimal? ETcCprPlanMchOvhd = null,
            DateTime? Ejrt_schStartDate = null,
            DateTime? Ejrt_schEndDate = null,
            string CostPriceFormat = null,
            int? CostPricePlaces = null,
            string CurrencyFormat = null,
            int? CurrencyPlaces = null,
            int? co_product_mix = null,
            int? MO_co_job = null,
            int? MO_product_cycle = null,
            decimal? MO_qty_per_cycle = null,
            int? MO_shared = null,
            int? MoldingPack = null);
        void InsertJobBookmark(IRecordReadOnly jobItem);
        void InsertJobrouteBookmark(IRecordReadOnly jobItem);
        void InsertJobmatlBookmark(IRecordReadOnly jobItem);
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_EstimateJobCostDetailSp(string AltExtGenSp, string ExOpordnumStarting, string ExOpordnumENDing, string ExOptgoOrdType, int? ExOpsuffixStarting, int? ExOpsuffixENDing, string ExOptdfEjobStat, string ExOptacCostComponent, string ExOpjobStarting, string ExOpjobENDing, string ExOpItemStarting, string ExOpItemENDing, string ExOpCustStarting, string ExOpCustENDing, DateTime? ExOpJobDateStarting, DateTime? ExOpJobDateENDing, int? DateStartingOffset, int? DateENDingOffset, int? DisplayHeader, string StartProspect, string EndProspect, string pSite);
    }
}

