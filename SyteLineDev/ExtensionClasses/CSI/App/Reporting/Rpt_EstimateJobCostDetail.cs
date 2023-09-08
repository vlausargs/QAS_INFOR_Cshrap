//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateJobCostDetail.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;
using CSI.Material;
using CSI.Production;
using CSI.Data.Utilities;
using CSI.Data.Cache;

namespace CSI.Reporting
{
    public class Rpt_EstimateJobCostDetail : IRpt_EstimateJobCostDetail
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IGetWinRegDecGroup iGetWinRegDecGroup;
        readonly IFixMaskForCrystal iFixMaskForCrystal;
        readonly IIsAddonAvailable iIsAddonAvailable;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly ICostOperJobCost iCostOperJobCost;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IConvertToUtil convertToUtil;
        readonly IHighCharacter highCharacter;
        readonly ILowCharacter lowCharacter;
        readonly IHighAnyInt iHighAnyInt;
        readonly IStringUtil stringUtil;
        readonly IUnionUtil unionUtil;
        readonly ILowAnyInt iLowAnyInt;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly IQueryLanguage queryLanguage;
        readonly ICache mgSessionVariableBasedCache;
        readonly int pageSize;
        readonly int recordCap;
        readonly LoadType loadType;
        readonly IRecordStreamFactory recordStreamFactory;
        readonly ISortOrderFactory sortOrderFactory;
        readonly IRpt_EstimateJobCostDetailCRUD iRpt_EstimateJobCostDetailCRUD;

        public Rpt_EstimateJobCostDetail(
            IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IGetWinRegDecGroup iGetWinRegDecGroup,
            IFixMaskForCrystal iFixMaskForCrystal,
            IIsAddonAvailable iIsAddonAvailable,
            IApplyDateOffset iApplyDateOffset,
            ICostOperJobCost iCostOperJobCost,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IConvertToUtil convertToUtil,
            IHighCharacter highCharacter,
            ILowCharacter lowCharacter,
            IHighAnyInt iHighAnyInt,
            IStringUtil stringUtil,
            IUnionUtil unionUtil,
            ILowAnyInt iLowAnyInt,
            ISQLValueComparerUtil sQLUtil,
            IDefineProcessVariable defineProcessVariable,
            IGetVariable getVariable,
            IRecordStreamFactory recordStreamFactory,
            ISortOrderFactory sortOrderFactory,
            IQueryLanguage queryLanguage,
            ICache mgSessionVariableBasedCache,
            CachePageSize pageSize,
            IRpt_EstimateJobCostDetailCRUD iRpt_EstimateJobCostDetailCRUD)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.iGetWinRegDecGroup = iGetWinRegDecGroup;
            this.iFixMaskForCrystal = iFixMaskForCrystal;
            this.iIsAddonAvailable = iIsAddonAvailable;
            this.iApplyDateOffset = iApplyDateOffset;
            this.iCostOperJobCost = iCostOperJobCost;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.convertToUtil = convertToUtil;
            this.highCharacter = highCharacter;
            this.lowCharacter = lowCharacter;
            this.iHighAnyInt = iHighAnyInt;
            this.stringUtil = stringUtil;
            this.unionUtil = unionUtil;
            this.iLowAnyInt = iLowAnyInt;
            this.sQLUtil = sQLUtil;
            this.defineProcessVariable = defineProcessVariable;
            this.getVariable = getVariable;
            this.queryLanguage = queryLanguage;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.pageSize = Convert.ToInt32(pageSize);
            recordCap = bunchedLoadCollection.RecordCap;
            if (recordCap == -1)
            {
                recordCap = 200;
            }
            loadType = bunchedLoadCollection.LoadType;
            this.recordStreamFactory = recordStreamFactory;
            this.sortOrderFactory = sortOrderFactory;
            this.iRpt_EstimateJobCostDetailCRUD = iRpt_EstimateJobCostDetailCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Rpt_EstimateJobCostDetailSp(
            string ExOpordnumStarting = null,
            string ExOpordnumENDing = null,
            string ExOptgoOrdType = null,
            int? ExOpsuffixStarting = null,
            int? ExOpsuffixENDing = null,
            string ExOptdfEjobStat = null,
            string ExOptacCostComponent = null,
            string ExOpjobStarting = null,
            string ExOpjobENDing = null,
            string ExOpItemStarting = null,
            string ExOpItemENDing = null,
            string ExOpCustStarting = null,
            string ExOpCustENDing = null,
            DateTime? ExOpJobDateStarting = null,
            DateTime? ExOpJobDateENDing = null,
            int? DateStartingOffset = null,
            int? DateENDingOffset = null,
            int? DisplayHeader = null,
            string StartProspect = null,
            string EndProspect = null,
            string pSite = null)
        {

            ICollectionLoadResponse Data = null;

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                int? rowCount = null; ;
                string LowCharacter = null;
                string HighCharacter = null;
                int? AllExOpjob = null;
                int? AllExOpsuffix = null;
                int? AllExOpItem = null;
                int? AllExOpJobDate = null;
                int? AllExOpCust = null;
                int? AllExOpordnum = null;
                int? AllProspect = null;
                int? Severity = null;
                string TRef = null;
                string SubTRef = null;
                string AccumScrap = null;
                decimal? TcCprPlanMatl = null;
                decimal? TcCprPlanMatlOvhd = null;
                decimal? TcCprPlanOvhd = null;
                decimal? TcCprPlanLbrTot = null;
                decimal? TcCprPlanTot = null;
                decimal? TFmovhdRate = null;
                decimal? TVmovhdRate = null;
                decimal? TcCprPlanLbrOvhd = null;
                decimal? TcCprPlanLbrOvhdF = null;
                decimal? TcCprPlanLbrOvhdV = null;
                decimal? TcCprPlanLbrOvhdL = null;
                decimal? TcCprPlanMchOvhd = null;
                decimal? TcCprPlanMchOvhdV = null;
                decimal? TcCprPlanSetupCost = null;
                decimal? TcCprPlanSetupCostO = null;
                decimal? TcCprPlanRunCost = null;
                decimal? TcCprPlanRunCostO = null;
                decimal? TPlanMchHrs = null;
                decimal? TcAmtPlanSetupCost = null;
                decimal? TcAmtPlanRunCost = null;
                decimal? TcAmtPlanLbrOvhd = null;
                decimal? PlanMatl = null;
                decimal? PlanMatlOvhd = null;
                Guid? JobRowPointer = null;
                string JobOrdType = null;
                string JobOrdNum = null;
                int? JobOrdLine = null;
                int? JobOrdRelease = null;
                string JobJob = null;
                int? JobSuffix = null;
                DateTime? JobJobDate = null;
                string JobCustNum = null;
                string JobProspectId = null;
                decimal? JobQtyReleased = null;
                string JobItem = null;
                string JobStat = null;
                Guid? JobrouteRowPointer = null;
                decimal? JobrouteQtyScrapped = null;
                int? JobrouteOperNum = null;
                string JobrouteWc = null;
                string JobrouteJob = null;
                int? JobrouteSuffix = null;
                decimal? JobrouteEfficiency = null;
                decimal? JobrouteRunRateLbr = null;
                decimal? JobrouteSetupRate = null;
                decimal? JobrouteFixovhdRate = null;
                decimal? JobrouteVarovhdRate = null;
                decimal? JobrouteFovhdRateMch = null;
                decimal? JobrouteVovhdRateMch = null;
                decimal? JrtSchRunTicksLbr = null;
                decimal? JrtSchSetupTicks = null;
                decimal? JrtSchRunTicksMch = null;
                int? WcOutside = null;
                string wcWc = null;
                Guid? JobmatlRowPointer = null;
                string JobmatlItem = null;
                decimal? JobmatlFmatlovhd = null;
                decimal? JobmatlVmatlovhd = null;
                string JobmatlUnits = null;
                decimal? JobmatlMatlQty = null;
                decimal? JobmatlScrapFact = null;
                decimal? JobmatlCost = null;
                string JobmatlRefType = null;
                string JobmatlRefNum = null;
                int? JobmatlRefLineSuf = null;
                int? JobmatlRefRelease = null;
                string JobmatlMatlType = null;
                string JobmatlJob = null;
                int? JobmatlSuffix = null;
                int? JobmatlOperNum = null;
                string JobmatlWc = null;
                Guid? ItemRowPointer = null;
                string ItemDescription = null;
                string WcOverhead = null;
                string jobdescription = null;
                DateTime? jrt_schstartdate = null;
                DateTime? jrt_schENDdate = null;
                string jrt_schJob = null;
                int? jrt_schSuffix = null;
                int? jrt_schOperNum = null;
                int? co_product_mix = null;
                int? MO_co_job = null;
                int? MO_product_cycle = null;
                decimal? MO_qty_per_cycle = null;
                int? MO_shared = null;
                int? MoldingPack = null;
                string XDomCurrency = null;
                string CostPriceFormat = null;
                int? CostPricePlaces = null;
                string CurrencyFormat = null;
                int? CurrencyPlaces = null;

                int processRowCount = 0;
                IRecordReadOnly previousJobItem = null;
                IRecordReadOnly previousJobrouteItem = null;
                IRecordReadOnly previousJobmatlItem = null;

                if (this.iRpt_EstimateJobCostDetailCRUD.Optional_ModuleForExists())
                {
                    //this temp table is a table variable in old stored procedure version.
                    this.iRpt_EstimateJobCostDetailCRUD.DeclareAltgenTable();

                    this.iRpt_EstimateJobCostDetailCRUD.InsertOptional_Module();
                    while (this.iRpt_EstimateJobCostDetailCRUD.Tv_ALTGENForExists())
                    {
                        (ALTGEN_SpName, rowCount) = this.iRpt_EstimateJobCostDetailCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
                        var ALTGEN = this.iRpt_EstimateJobCostDetailCRUD.AltExtGen_Rpt_EstimateJobCostDetailSp(ALTGEN_SpName,
                            ExOpordnumStarting,
                            ExOpordnumENDing,
                            ExOptgoOrdType,
                            ExOpsuffixStarting,
                            ExOpsuffixENDing,
                            ExOptdfEjobStat,
                            ExOptacCostComponent,
                            ExOpjobStarting,
                            ExOpjobENDing,
                            ExOpItemStarting,
                            ExOpItemENDing,
                            ExOpCustStarting,
                            ExOpCustENDing,
                            ExOpJobDateStarting,
                            ExOpJobDateENDing,
                            DateStartingOffset,
                            DateENDingOffset,
                            DisplayHeader,
                            StartProspect,
                            EndProspect,
                            pSite);
                        ALTGEN_Severity = ALTGEN.ReturnCode;

                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN.Data, ALTGEN_Severity);

                        }

                        this.iRpt_EstimateJobCostDetailCRUD.DeleteTv_ALTGEN(ALTGEN_SpName);
                    }

                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_EstimateJobCostDetailSp") != null)
                {
                    var EXTGEN = this.iRpt_EstimateJobCostDetailCRUD.AltExtGen_Rpt_EstimateJobCostDetailSp("dbo.EXTGEN_Rpt_EstimateJobCostDetailSp",
                        ExOpordnumStarting,
                        ExOpordnumENDing,
                        ExOptgoOrdType,
                        ExOpsuffixStarting,
                        ExOpsuffixENDing,
                        ExOptdfEjobStat,
                        ExOptacCostComponent,
                        ExOpjobStarting,
                        ExOpjobENDing,
                        ExOpItemStarting,
                        ExOpItemENDing,
                        ExOpCustStarting,
                        ExOpCustENDing,
                        ExOpJobDateStarting,
                        ExOpJobDateENDing,
                        DateStartingOffset,
                        DateENDingOffset,
                        DisplayHeader,
                        StartProspect,
                        EndProspect,
                        pSite);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                this.iRpt_EstimateJobCostDetailCRUD.SetIsolationLevel();

                AllExOpjob = convertToUtil.ToInt32((ExOpjobStarting == null && ExOpjobENDing == null ? 1 : 0));
                AllExOpsuffix = (int?)((ExOpsuffixStarting == null && ExOpsuffixENDing == null ? 1 : 0));
                AllExOpItem = convertToUtil.ToInt32((ExOpItemStarting == null && ExOpItemENDing == null ? 1 : 0));
                AllExOpJobDate = (int?)((ExOpJobDateStarting == null && ExOpJobDateENDing == null ? 1 : 0));
                AllExOpCust = convertToUtil.ToInt32((ExOpCustStarting == null && ExOpCustENDing == null ? 1 : 0));
                AllExOpordnum = convertToUtil.ToInt32((ExOpordnumStarting == null && ExOpordnumENDing == null ? 1 : 0));
                AllProspect = convertToUtil.ToInt32((StartProspect == null && EndProspect == null ? 1 : 0));
                LowCharacter = convertToUtil.ToString(lowCharacter.LowCharacterFn());
                HighCharacter = convertToUtil.ToString(highCharacter.HighCharacterFn());

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
                    Date: ExOpJobDateStarting,
                    Offset: DateStartingOffset,
                    IsEndDate: 0);
                ExOpJobDateStarting = ApplyDateOffset.Date;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
                    Date: ExOpJobDateENDing,
                    Offset: DateENDingOffset,
                    IsEndDate: 1);
                ExOpJobDateENDing = ApplyDateOffset1.Date;

                #endregion ExecuteMethodCall

                ExOptdfEjobStat = stringUtil.IsNull(
                    ExOptdfEjobStat,
                    "PWH");
                ExOptacCostComponent = stringUtil.IsNull(
                    ExOptacCostComponent,
                    "A");
                ExOptgoOrdType = stringUtil.IsNull(
                    ExOptgoOrdType,
                    " ");
                DisplayHeader = (int?)(stringUtil.IsNull(
                    DisplayHeader,
                    1));
                ExOpCustStarting = (ExOpCustStarting == null ? LowCharacter : this.iExpandKyByType.ExpandKyByTypeFn(
                    "CustNumType",
                    ExOpCustStarting));
                ExOpCustENDing = (ExOpCustENDing == null ? HighCharacter : this.iExpandKyByType.ExpandKyByTypeFn(
                    "CustNumType",
                    ExOpCustENDing));
                ExOpItemStarting = stringUtil.IsNull(
                    ExOpItemStarting,
                    LowCharacter);
                ExOpItemENDing = stringUtil.IsNull(
                    ExOpItemENDing,
                    HighCharacter);
                ExOpjobStarting = (ExOpjobStarting == null ? LowCharacter : this.iExpandKyByType.ExpandKyByTypeFn(
                    "JobType",
                    ExOpjobStarting));
                ExOpjobENDing = (ExOpjobENDing == null ? HighCharacter : this.iExpandKyByType.ExpandKyByTypeFn(
                    "JobType",
                    ExOpjobENDing));
                ExOpsuffixStarting = convertToUtil.ToInt32(stringUtil.IsNull(
                    ExOpsuffixStarting,
                    this.iLowAnyInt.LowAnyIntFn("suffixType")));
                ExOpsuffixENDing = convertToUtil.ToInt32(stringUtil.IsNull(
                    ExOpsuffixENDing,
                    this.iHighAnyInt.HighAnyIntFn("suffixType")));
                ExOpordnumStarting = (ExOpordnumStarting == null ? LowCharacter : this.iExpandKyByType.ExpandKyByTypeFn(
                    "CoProjTrnNumType",
                    ExOpordnumStarting));
                ExOpordnumENDing = (ExOpordnumENDing == null ? HighCharacter : this.iExpandKyByType.ExpandKyByTypeFn(
                    "CoProjTrnNumType",
                    ExOpordnumENDing));
                StartProspect = (StartProspect == null ? LowCharacter : this.iExpandKyByType.ExpandKyByTypeFn(
                    "ProspectIdType",
                    StartProspect));
                EndProspect = (EndProspect == null ? HighCharacter : this.iExpandKyByType.ExpandKyByTypeFn(
                    "ProspectIdType",
                    EndProspect));
                Severity = 0;
                TFmovhdRate = 0;
                TVmovhdRate = 0;
                TcCprPlanLbrOvhd = 0;
                TcCprPlanMchOvhd = 0;
                TcCprPlanSetupCost = 0;
                TcCprPlanRunCost = 0;
                TPlanMchHrs = 0;

                (XDomCurrency, rowCount) = this.iRpt_EstimateJobCostDetailCRUD.LoadCurrparms(XDomCurrency);
                (CostPricePlaces, CostPriceFormat, CurrencyPlaces, CurrencyFormat, rowCount) = this.iRpt_EstimateJobCostDetailCRUD.LoadCurrency(XDomCurrency, CostPriceFormat, CostPricePlaces, CurrencyFormat, CurrencyPlaces);
                CostPriceFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    CostPriceFormat,
                    this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                CurrencyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    CurrencyFormat,
                    this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                MoldingPack = convertToUtil.ToInt32(this.iIsAddonAvailable.IsAddonAvailableFn("MoldingPack"));

                using (IRecordStream jobRecordStream = this.iRpt_EstimateJobCostDetailCRUD.SelectJob(ExOpordnumStarting, ExOpordnumENDing, ExOptgoOrdType, ExOpsuffixStarting, ExOpsuffixENDing, ExOptdfEjobStat, ExOpjobStarting, ExOpjobENDing, ExOpItemStarting, ExOpItemENDing, ExOpCustStarting, ExOpCustENDing, ExOpJobDateStarting, ExOpJobDateENDing, StartProspect, EndProspect, AllExOpjob, AllExOpsuffix, AllExOpItem, AllExOpJobDate, AllExOpCust, AllExOpordnum, AllProspect, pageSize, loadType),
                                     jobrouteRecordStream = this.iRpt_EstimateJobCostDetailCRUD.SelectJobroute(ExOpordnumStarting, ExOpordnumENDing, ExOptgoOrdType, ExOpsuffixStarting, ExOpsuffixENDing, ExOptdfEjobStat, ExOpjobStarting, ExOpjobENDing, ExOpItemStarting, ExOpItemENDing, ExOpCustStarting, ExOpCustENDing, ExOpJobDateStarting, ExOpJobDateENDing, StartProspect, EndProspect, AllExOpjob, AllExOpsuffix, AllExOpItem, AllExOpJobDate, AllExOpCust, AllExOpordnum, AllProspect, pageSize, loadType),
                                     jobmatlRecordStream = this.iRpt_EstimateJobCostDetailCRUD.SelectJobmatl(ExOpordnumStarting, ExOpordnumENDing, ExOptgoOrdType, ExOpsuffixStarting, ExOpsuffixENDing, ExOptdfEjobStat, ExOpjobStarting, ExOpjobENDing, ExOpItemStarting, ExOpItemENDing, ExOpCustStarting, ExOpCustENDing, ExOpJobDateStarting, ExOpJobDateENDing, StartProspect, EndProspect, AllExOpjob, AllExOpsuffix, AllExOpItem, AllExOpJobDate, AllExOpCust, AllExOpordnum, AllProspect, pageSize, loadType))
                {

                    while (jobRecordStream.Read())
                    {
                        var curJobItem = jobRecordStream.Current;

                        JobRowPointer = curJobItem.GetValue<Guid?>(0);
                        JobOrdType = curJobItem.GetValue<string>(1);
                        JobOrdNum = curJobItem.GetValue<string>(2);
                        JobOrdLine = curJobItem.GetValue<int?>(3);
                        JobOrdRelease = curJobItem.GetValue<int?>(4);
                        JobJob = curJobItem.GetValue<string>(5);
                        JobSuffix = curJobItem.GetValue<int?>(6);
                        JobJobDate = curJobItem.GetValue<DateTime?>(7);
                        JobCustNum = curJobItem.GetValue<string>(8);
                        JobProspectId = curJobItem.GetValue<string>(9);
                        JobQtyReleased = curJobItem.GetValue<decimal?>(10);
                        JobItem = curJobItem.GetValue<string>(11);
                        JobStat = curJobItem.GetValue<string>(12);
                        jobdescription = curJobItem.GetValue<string>(13);
                        co_product_mix = curJobItem.GetValue<int?>(14);
                        MO_co_job = curJobItem.GetValue<int?>(15);
                        MO_product_cycle = curJobItem.GetValue<int?>(16);
                        MO_qty_per_cycle = curJobItem.GetValue<decimal?>(17);
                        TRef = curJobItem.GetValue<string>(18);

                        TcAmtPlanSetupCost = 0;
                        TcAmtPlanRunCost = 0;
                        TcAmtPlanLbrOvhd = 0;
                        AccumScrap = "0";
                        if (sQLUtil.SQLBool(sQLUtil.SQLEqual(ExOptacCostComponent, "A")))
                        {

                            do
                            {
                                var jobrouteItem = jobrouteRecordStream.Current;

                                JobrouteRowPointer = jobrouteItem?.GetValue<Guid?>(0);
                                JobrouteQtyScrapped = jobrouteItem?.GetValue<decimal?>(1);
                                JobrouteOperNum = jobrouteItem?.GetValue<int?>(2);
                                JobrouteWc = jobrouteItem?.GetValue<string>(3);
                                WcOverhead = jobrouteItem?.GetValue<string>(4);
                                MO_shared = jobrouteItem?.GetValue<int?>(5);
                                JobrouteJob = jobrouteItem?.GetValue<string>(6);
                                JobrouteSuffix = jobrouteItem?.GetValue<int?>(7);
                                jrt_schstartdate = jobrouteItem?.GetValue<DateTime?>(8);
                                jrt_schENDdate = jobrouteItem?.GetValue<DateTime?>(9);

                                JobrouteEfficiency = jobrouteItem?.GetValue<decimal?>(10);
                                JobrouteRunRateLbr = jobrouteItem?.GetValue<decimal?>(11);
                                JobrouteSetupRate = jobrouteItem?.GetValue<decimal?>(12);
                                JobrouteFixovhdRate = jobrouteItem?.GetValue<decimal?>(13);
                                JobrouteVarovhdRate = jobrouteItem?.GetValue<decimal?>(14);
                                JobrouteFovhdRateMch = jobrouteItem?.GetValue<decimal?>(15);
                                JobrouteVovhdRateMch = jobrouteItem?.GetValue<decimal?>(16);
                                JrtSchRunTicksLbr = jobrouteItem?.GetValue<decimal?>(17);
                                JrtSchSetupTicks = jobrouteItem?.GetValue<decimal?>(18);
                                JrtSchRunTicksMch = jobrouteItem?.GetValue<decimal?>(19);
                                WcOutside = jobrouteItem?.GetValue<int?>(20);
                                wcWc = jobrouteItem?.GetValue<string>(21);
                                if (jobrouteItem == null || string.Compare(JobJob, JobrouteJob, true) > 0 || (JobJob.Equals(JobrouteJob) && JobSuffix > JobrouteSuffix))
                                    continue;

                                if (string.Compare(JobJob, JobrouteJob, true) < 0 || (JobJob.Equals(JobrouteJob) && JobSuffix < JobrouteSuffix))
                                    break;
                                AccumScrap = convertToUtil.ToString(convertToUtil.ToDecimal(AccumScrap) + JobrouteQtyScrapped);
                                TcCprPlanMatl = 0.0M;
                                TcCprPlanMatlOvhd = 0.0M;

                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: CostOperJobCostSp
                                var CostOperJobCostVar = this.iCostOperJobCost.CostOperJobCostSp(
                                    zero_args: 1,
                                    u_qty: JobQtyReleased,
                                    l_qty: 1,
                                    u_outside: TcCprPlanRunCostO,
                                    l_outside: TcCprPlanSetupCostO,
                                    u_run: TcCprPlanRunCost,
                                    l_setup: TcCprPlanSetupCost,
                                    u_fovhd_lbr: TcCprPlanLbrOvhd,
                                    l_fovhd_lbr: TcCprPlanLbrOvhdF,
                                    u_vovhd_lbr: TcCprPlanLbrOvhdV,
                                    l_vovhd_lbr: TcCprPlanLbrOvhdL,
                                    u_fovhd_mch: TcCprPlanMchOvhd,
                                    u_vovhd_mch: TcCprPlanMchOvhdV,
                                    JobrouteEfficiency: JobrouteEfficiency,
                                    JobrouteRunRateLbr: JobrouteRunRateLbr,
                                    JobrouteSetupRate: JobrouteSetupRate,
                                    JobrouteFixovhdRate: JobrouteFixovhdRate,
                                    JobrouteVarovhdRate: JobrouteVarovhdRate,
                                    JobrouteFovhdRateMch: JobrouteFovhdRateMch,
                                    JobrouteVovhdRateMch: JobrouteVovhdRateMch,
                                    JrtSchRunTicksLbr: JrtSchRunTicksLbr,
                                    JrtSchSetupTicks: JrtSchSetupTicks,
                                    JrtSchRunTicksMch: JrtSchRunTicksMch,
                                    wc:wcWc, 
                                    WcOverhead: WcOverhead,
                                    WcOutside: WcOutside,
                                    CostoperUHrsMch: TPlanMchHrs);
                                TcCprPlanRunCostO = CostOperJobCostVar.u_outside;
                                TcCprPlanSetupCostO = CostOperJobCostVar.l_outside;
                                TcCprPlanRunCost = CostOperJobCostVar.u_run;
                                TcCprPlanSetupCost = CostOperJobCostVar.l_setup;
                                TcCprPlanLbrOvhd = CostOperJobCostVar.u_fovhd_lbr;
                                TcCprPlanLbrOvhdF = CostOperJobCostVar.l_fovhd_lbr;
                                TcCprPlanLbrOvhdV = CostOperJobCostVar.u_vovhd_lbr;
                                TcCprPlanLbrOvhdL = CostOperJobCostVar.l_vovhd_lbr;
                                TcCprPlanMchOvhd = CostOperJobCostVar.u_fovhd_mch;
                                TcCprPlanMchOvhdV = CostOperJobCostVar.u_vovhd_mch;
                                TPlanMchHrs = CostOperJobCostVar.CostoperUHrsMch;

                                #endregion ExecuteMethodCall

                                TcCprPlanRunCost = (decimal?)(TcCprPlanRunCost + TcCprPlanRunCostO);
                                TcCprPlanSetupCost = (decimal?)(TcCprPlanSetupCost + TcCprPlanSetupCostO);
                                TcCprPlanLbrOvhd = (decimal?)(TcCprPlanLbrOvhd + TcCprPlanLbrOvhdF + TcCprPlanLbrOvhdV + TcCprPlanLbrOvhdL);
                                TcCprPlanMchOvhd = (decimal?)(TcCprPlanMchOvhd + TcCprPlanMchOvhdV);

                                TcCprPlanOvhd = (decimal?)(TcCprPlanLbrOvhd + TcCprPlanMchOvhd);
                                TcCprPlanTot = (decimal?)(TcCprPlanSetupCost + TcCprPlanRunCost);
                                TcAmtPlanSetupCost = (decimal?)(TcAmtPlanSetupCost + TcCprPlanSetupCost);
                                TcAmtPlanRunCost = (decimal?)(TcAmtPlanRunCost + TcCprPlanRunCost);
                                TcCprPlanLbrTot = (decimal?)(TcCprPlanSetupCost + TcCprPlanRunCost + TcCprPlanLbrOvhd);

                                IList<ICollectionLoadResponse> nonTableLoadResponseList = new List<ICollectionLoadResponse>();
                                var jobmatlCount = 0;
                                do
                                {
                                    var jobmatlItem = jobmatlRecordStream.Current;
                                    JobmatlRowPointer = jobmatlItem?.GetValue<Guid?>(0);
                                    JobmatlItem = jobmatlItem?.GetValue<string>(1);
                                    JobmatlFmatlovhd = jobmatlItem?.GetValue<decimal?>(2);
                                    JobmatlVmatlovhd = jobmatlItem?.GetValue<decimal?>(3);
                                    JobmatlUnits = jobmatlItem?.GetValue<string>(4);
                                    JobmatlMatlQty = jobmatlItem?.GetValue<decimal?>(5);
                                    JobmatlScrapFact = jobmatlItem?.GetValue<decimal?>(6);
                                    JobmatlCost = jobmatlItem?.GetValue<decimal?>(7);
                                    JobmatlRefType = jobmatlItem?.GetValue<string>(8);
                                    JobmatlRefNum = jobmatlItem?.GetValue<string>(9);
                                    JobmatlRefLineSuf = jobmatlItem?.GetValue<int?>(10);
                                    JobmatlRefRelease = jobmatlItem?.GetValue<int?>(11);
                                    JobmatlMatlType = jobmatlItem?.GetValue<string>(12);
                                    JobmatlOperNum = jobmatlItem?.GetValue<int?>(13);
                                    ItemRowPointer = jobmatlItem?.GetValue<Guid?>(16);
                                    ItemDescription = jobmatlItem?.GetValue<string>(17);
                                    jrt_schJob = jobmatlItem?.GetValue<string>(18);
                                    jrt_schSuffix = jobmatlItem?.GetValue<int?>(19);
                                    jrt_schOperNum = jobmatlItem?.GetValue<int?>(20);
                                    SubTRef = jobmatlItem?.GetValue<string>(21);
                                    PlanMatl = jobmatlItem?.GetValue<decimal?>(22);
                                    PlanMatlOvhd = jobmatlItem?.GetValue<decimal?>(23);
                                    JobmatlJob = jobmatlItem?.GetValue<string>(24);
                                    JobmatlSuffix = jobmatlItem?.GetValue<int?>(25);

                                    if (jobmatlItem == null || string.Compare(JobJob, JobmatlJob, true) > 0 || (JobJob.Equals(JobmatlJob) && JobSuffix > JobmatlSuffix)
                                        || (JobJob.Equals(JobmatlJob) && JobSuffix == JobmatlSuffix && JobrouteOperNum > JobmatlOperNum))
                                    {
                                        continue;
                                    }

                                    if (string.Compare(JobJob, JobmatlJob, true) < 0 || (JobJob.Equals(JobmatlJob) && JobSuffix < JobmatlSuffix)
                                        || (JobJob.Equals(JobmatlJob) && JobSuffix == JobmatlSuffix && JobrouteOperNum < JobmatlOperNum))
                                    {                                        
                                        break;
                                    }

                                    jobmatlCount++;
                                    TcCprPlanMatl += PlanMatl;
                                    TcCprPlanMatlOvhd += PlanMatlOvhd;

                                    if (sQLUtil.SQLEqual(JobrouteJob, jrt_schJob) == true && sQLUtil.SQLEqual(JobrouteSuffix, jrt_schSuffix) == true && sQLUtil.SQLEqual(JobrouteOperNum, jrt_schOperNum) == true)
                                    {
                                        TFmovhdRate = 0.0M;
                                        TVmovhdRate = 0.0M;
                                        if (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                                                "M",
                                                WcOverhead), 0) == true)
                                        {
                                            TFmovhdRate = JobmatlFmatlovhd;
                                            TVmovhdRate = JobmatlVmatlovhd;

                                        }
                                        PlanMatlOvhd = (decimal?)((PlanMatl * (TFmovhdRate + TVmovhdRate)));

                                        nonTableLoadResponseList.Add(this.iRpt_EstimateJobCostDetailCRUD.SelectNontable(
                                                Job: JobJob,
                                                JobSuffix: JobSuffix,
                                                JobDate: JobJobDate,
                                                CustNum: JobCustNum,
                                                ProspectId: JobProspectId,
                                                QtyReleased: JobQtyReleased,
                                                Item: JobItem,
                                                Stat: JobStat,
                                                Ref: TRef,
                                                Des: jobdescription,
                                                OperNum: JobrouteOperNum,
                                                Wc: JobrouteWc,
                                                jrt_schStartDate: jrt_schstartdate,
                                                jrt_schEndDate: jrt_schENDdate,
                                                TcCprPlanSetupCost: TcCprPlanSetupCost,
                                                TcCprPlanRunCost: TcCprPlanRunCost,
                                                TcCprPlanMatl: TcCprPlanMatl,
                                                TcCprPlanOvhd: TcCprPlanOvhd,
                                                TcCprPlanTot: TcCprPlanTot,
                                                Setup: TcCprPlanSetupCost,
                                                Run: TcCprPlanRunCost,
                                                Overhead: TcCprPlanLbrOvhd,
                                                Total: TcCprPlanLbrTot,
                                                Machine: TPlanMchHrs,
                                                MACHINEOverhead: TcCprPlanMchOvhd,
                                                Type: JobmatlMatlType,
                                                ItemDetail: JobmatlItem,
                                                Per: JobmatlUnits,
                                                Cost: PlanMatl,
                                                Ovhd: PlanMatlOvhd,
                                                TRef: SubTRef,
                                                ItemDesc: ItemDescription,
                                                CostPriceFormat: CostPriceFormat,
                                                CostPricePlaces: CostPricePlaces,
                                                CurrencyFormat: CurrencyFormat,
                                                CurrencyPlaces: CurrencyPlaces,
                                                co_product_mix: co_product_mix,
                                                MO_co_job: MO_co_job,
                                                MO_product_cycle: MO_product_cycle,
                                                MO_qty_per_cycle: MO_qty_per_cycle,
                                                MO_shared: MO_shared,
                                                MoldingPack: MoldingPack));

                                        processRowCount++;
                                    }
                                    previousJobmatlItem = jobmatlItem;
                                }
                                while (jobmatlRecordStream.Read());

                                if (jobmatlCount == 0)
                                {
                                    TcCprPlanOvhd = (decimal?)(TcCprPlanMatlOvhd + TcCprPlanLbrOvhd + TcCprPlanMchOvhd);
                                    TcCprPlanTot = (decimal?)(TcCprPlanSetupCost + TcCprPlanRunCost + TcCprPlanMatl + TcCprPlanOvhd);
                                    TcCprPlanLbrTot = (decimal?)(TcCprPlanSetupCost + TcCprPlanRunCost + TcCprPlanLbrOvhd);
                                    var nonTableLoadResponse = this.iRpt_EstimateJobCostDetailCRUD.SelectNontable(
                                            Job: JobJob,
                                            JobSuffix: JobSuffix,
                                            JobDate: JobJobDate,
                                            CustNum: JobCustNum,
                                            ProspectId: JobProspectId,
                                            QtyReleased: JobQtyReleased,
                                            Item: JobItem,
                                            Stat: JobStat,
                                            Ref: TRef,
                                            Des: jobdescription,
                                            OperNum: JobrouteOperNum,
                                            Wc: JobrouteWc,
                                            jrt_schStartDate: jrt_schstartdate,
                                            jrt_schEndDate: jrt_schENDdate,
                                            TcCprPlanSetupCost: TcCprPlanSetupCost,
                                            TcCprPlanRunCost: TcCprPlanRunCost,
                                            TcCprPlanMatl: TcCprPlanMatl,
                                            TcCprPlanOvhd: TcCprPlanOvhd,
                                            TcCprPlanTot: TcCprPlanTot,
                                            Setup: TcCprPlanSetupCost,
                                            Run: TcCprPlanRunCost,
                                            Overhead: TcCprPlanLbrOvhd,
                                            Total: TcCprPlanLbrTot,
                                            Machine: TPlanMchHrs,
                                            MACHINEOverhead: TcCprPlanMchOvhd,
                                            CostPriceFormat: CostPriceFormat,
                                            CostPricePlaces: CostPricePlaces,
                                            CurrencyFormat: CurrencyFormat,
                                            CurrencyPlaces: CurrencyPlaces,
                                            co_product_mix: co_product_mix,
                                            MO_co_job: MO_co_job,
                                            MO_product_cycle: MO_product_cycle,
                                            MO_qty_per_cycle: MO_qty_per_cycle,
                                            MO_shared: MO_shared,
                                            MoldingPack: MoldingPack);
                                    unionUtil.Add(nonTableLoadResponse);
                                    processRowCount++;
                                }

                                TcCprPlanOvhd += TcCprPlanMatlOvhd;
                                TcCprPlanTot += TcCprPlanMatl + TcCprPlanOvhd;

                                foreach (var response in nonTableLoadResponseList)
                                {
                                    response.Items[0]?.SetValue<decimal?>("TcCprPlanOvhd", TcCprPlanOvhd);
                                    response.Items[0]?.SetValue<decimal?>("TcCprPlanTot", TcCprPlanTot);
                                    response.Items[0]?.SetValue<decimal?>("TcCprPlanMatl", TcCprPlanMatl);
                                    unionUtil.Add(response);
                                }
                                previousJobrouteItem = jobrouteItem;

                                //Deallocate Cursor Materialjobmatl                              
                            }
                            while (jobrouteRecordStream.Read());

                            //Deallocate Cursor CURJOBROUTE

                        }
                        if (sQLUtil.SQLEqual(ExOptacCostComponent, "M") == true)
                        {
                            
                            do
                            {
                                var jobmatlItem = jobmatlRecordStream.Current;
                                JobmatlRowPointer = jobmatlItem?.GetValue<Guid?>(0);
                                JobmatlItem = jobmatlItem?.GetValue<string>(1);
                                JobmatlFmatlovhd = jobmatlItem?.GetValue<decimal?>(2);
                                JobmatlVmatlovhd = jobmatlItem?.GetValue<decimal?>(3);
                                JobmatlUnits = jobmatlItem?.GetValue<string>(4);
                                JobmatlMatlQty = jobmatlItem?.GetValue<decimal?>(5);
                                JobmatlScrapFact = jobmatlItem?.GetValue<decimal?>(6);
                                JobmatlCost = jobmatlItem?.GetValue<decimal?>(7);
                                JobmatlRefType = jobmatlItem?.GetValue<string>(8);
                                JobmatlRefNum = jobmatlItem?.GetValue<string>(9);
                                JobmatlRefLineSuf = jobmatlItem?.GetValue<int?>(10);
                                JobmatlRefRelease = jobmatlItem?.GetValue<int?>(11);
                                JobmatlMatlType = jobmatlItem?.GetValue<string>(12);
                                JobmatlOperNum = jobmatlItem?.GetValue<int?>(13);
                                ItemRowPointer = jobmatlItem?.GetValue<Guid?>(16);
                                ItemDescription = jobmatlItem?.GetValue<string>(17);
                                jrt_schJob = jobmatlItem?.GetValue<string>(18);
                                jrt_schSuffix = jobmatlItem?.GetValue<int?>(19);
                                jrt_schOperNum = jobmatlItem?.GetValue<int?>(20);
                                SubTRef = jobmatlItem?.GetValue<string>(21);
                                PlanMatl = jobmatlItem?.GetValue<decimal?>(22);
                                var MTcCprPlanMatlOvhd = jobmatlItem?.GetValue<decimal?>(23);
                                JobmatlJob = jobmatlItem?.GetValue<string>(24);
                                JobmatlSuffix = jobmatlItem?.GetValue<int?>(25);
                                JobmatlWc = jobmatlItem?.GetValue<string>(26);
                                MO_shared = jobmatlItem?.GetValue<int?>(28);

                                if (jobmatlItem == null || string.Compare(JobJob, JobmatlJob, true) > 0 || (JobJob.Equals(JobmatlJob) && JobSuffix > JobmatlSuffix))
                                    continue;

                                if (string.Compare(JobJob, JobmatlJob, true) < 0 || (JobJob.Equals(JobmatlJob) && JobSuffix < JobmatlSuffix))
                                    break;

                                if (sQLUtil.SQLEqual(JobmatlJob, jrt_schJob) == true && sQLUtil.SQLEqual(JobmatlSuffix, jrt_schSuffix) == true && sQLUtil.SQLEqual(JobmatlOperNum, jrt_schOperNum) == true) {
                                    unionUtil.Add(this.iRpt_EstimateJobCostDetailCRUD.SelectNontable(
                                                    Job: JobJob,
                                                    JobSuffix: JobSuffix,
                                                    JobDate: JobJobDate,
                                                    CustNum: JobCustNum,
                                                    ProspectId: JobProspectId,
                                                    QtyReleased: JobQtyReleased,
                                                    Item: JobItem,
                                                    Stat: JobStat,
                                                    Ref: TRef,
                                                    Des: jobdescription,
                                                    OperNum: JobmatlOperNum,
                                                    Wc: JobmatlWc,
                                                    MJobmatlMatlType: JobmatlMatlType,
                                                    MJobmatlItem: JobmatlItem,
                                                    MJobmatlUnits: JobmatlUnits,
                                                    MTcCprPlanMatl: PlanMatl,
                                                    MTcCprPlanMatlOvhd: MTcCprPlanMatlOvhd,
                                                    MTRef: SubTRef,
                                                    MItemDescription: ItemDescription,
                                                    CostPriceFormat: CostPriceFormat,
                                                    CostPricePlaces: CostPricePlaces,
                                                    CurrencyFormat: CurrencyFormat,
                                                    CurrencyPlaces: CurrencyPlaces,
                                                    co_product_mix: co_product_mix,
                                                    MO_co_job: MO_co_job,
                                                    MO_product_cycle: MO_product_cycle,
                                                    MO_qty_per_cycle: MO_qty_per_cycle,
                                                    MO_shared: MO_shared,
                                                    MoldingPack: MoldingPack));
                                    processRowCount++;
                                }
                                previousJobmatlItem = jobmatlItem;
                            }
                            while (jobmatlRecordStream.Read());

                        }
                        else
                        {
                            if (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                                    ExOptacCostComponent,
                                    "LC"), 0) == true)
                            {
                                AccumScrap = "0";

                                do
                                {
                                    var jobrouteItem = jobrouteRecordStream.Current;
                                    JobrouteRowPointer = jobrouteItem?.GetValue<Guid?>(0);
                                    JobrouteQtyScrapped = jobrouteItem?.GetValue<decimal?>(1);
                                    JobrouteOperNum = jobrouteItem?.GetValue<int?>(2);
                                    JobrouteWc = jobrouteItem?.GetValue<string>(3);
                                    WcOverhead = jobrouteItem?.GetValue<string>(4);
                                    MO_shared = jobrouteItem?.GetValue<int?>(5);
                                    JobrouteJob = jobrouteItem?.GetValue<string>(6);
                                    JobrouteSuffix = jobrouteItem?.GetValue<int?>(7);
                                    jrt_schstartdate = jobrouteItem?.GetValue<DateTime?>(8);
                                    jrt_schENDdate = jobrouteItem?.GetValue<DateTime?>(9);
                                    JobrouteEfficiency = jobrouteItem?.GetValue<decimal?>(10);
                                    JobrouteRunRateLbr = jobrouteItem?.GetValue<decimal?>(11);
                                    JobrouteSetupRate = jobrouteItem?.GetValue<decimal?>(12);
                                    JobrouteFixovhdRate = jobrouteItem?.GetValue<decimal?>(13);
                                    JobrouteVarovhdRate = jobrouteItem?.GetValue<decimal?>(14);
                                    JobrouteFovhdRateMch = jobrouteItem?.GetValue<decimal?>(15);
                                    JobrouteVovhdRateMch = jobrouteItem?.GetValue<decimal?>(16);
                                    JrtSchRunTicksLbr = jobrouteItem?.GetValue<decimal?>(17);
                                    JrtSchSetupTicks = jobrouteItem?.GetValue<decimal?>(18);
                                    JrtSchRunTicksMch = jobrouteItem?.GetValue<decimal?>(19);
                                    WcOutside = jobrouteItem?.GetValue<int?>(20);
                                    wcWc = jobrouteItem?.GetValue<string>(21);
                                    if (jobrouteItem == null || string.Compare(JobJob, JobrouteJob, true) > 0 || (JobJob.Equals(JobrouteJob) && JobSuffix > JobrouteSuffix))
                                        continue;

                                    if (string.Compare(JobJob, JobrouteJob, true) < 0 || (JobJob.Equals(JobrouteJob) && JobSuffix < JobrouteSuffix))
                                        break;
                                    AccumScrap = convertToUtil.ToString(convertToUtil.ToDecimal(AccumScrap) + JobrouteQtyScrapped);

                                    #region CRUD ExecuteMethodCall

                                    //Please Generate the bounce for this stored procedure: CostOperJobCostSp
                                    var CostOperJobCostVar1 = this.iCostOperJobCost.CostOperJobCostSp(
                                        zero_args: 1,
                                        u_qty: JobQtyReleased,
                                        l_qty: 1,
                                        u_outside: TcCprPlanRunCostO,
                                        l_outside: TcCprPlanSetupCostO,
                                        u_run: TcCprPlanRunCost,
                                        l_setup: TcCprPlanSetupCost,
                                        u_fovhd_lbr: TcCprPlanLbrOvhd,
                                        l_fovhd_lbr: TcCprPlanLbrOvhdF,
                                        u_vovhd_lbr: TcCprPlanLbrOvhdV,
                                        l_vovhd_lbr: TcCprPlanLbrOvhdL,
                                        u_fovhd_mch: TcCprPlanMchOvhd,
                                        u_vovhd_mch: TcCprPlanMchOvhdV,
                                        JobrouteEfficiency: JobrouteEfficiency,
                                        JobrouteRunRateLbr: JobrouteRunRateLbr,
                                        JobrouteSetupRate: JobrouteSetupRate,
                                        JobrouteFixovhdRate: JobrouteFixovhdRate,
                                        JobrouteVarovhdRate: JobrouteVarovhdRate,
                                        JobrouteFovhdRateMch: JobrouteFovhdRateMch,
                                        JobrouteVovhdRateMch: JobrouteVovhdRateMch,
                                        JrtSchRunTicksLbr: JrtSchRunTicksLbr,
                                        JrtSchSetupTicks: JrtSchSetupTicks,
                                        JrtSchRunTicksMch: JrtSchRunTicksMch,
                                        WcOverhead: WcOverhead,
                                        WcOutside: WcOutside,
                                        wc:wcWc,
                                        CostoperUHrsMch: TPlanMchHrs);
                                    TcCprPlanRunCostO = CostOperJobCostVar1.u_outside;
                                    TcCprPlanSetupCostO = CostOperJobCostVar1.l_outside;
                                    TcCprPlanRunCost = CostOperJobCostVar1.u_run;
                                    TcCprPlanSetupCost = CostOperJobCostVar1.l_setup;
                                    TcCprPlanLbrOvhd = CostOperJobCostVar1.u_fovhd_lbr;
                                    TcCprPlanLbrOvhdF = CostOperJobCostVar1.l_fovhd_lbr;
                                    TcCprPlanLbrOvhdV = CostOperJobCostVar1.u_vovhd_lbr;
                                    TcCprPlanLbrOvhdL = CostOperJobCostVar1.l_vovhd_lbr;
                                    TcCprPlanMchOvhd = CostOperJobCostVar1.u_fovhd_mch;
                                    TcCprPlanMchOvhdV = CostOperJobCostVar1.u_vovhd_mch;
                                    TPlanMchHrs = CostOperJobCostVar1.CostoperUHrsMch;

                                    #endregion ExecuteMethodCall

                                    TcCprPlanRunCost = (decimal?)(TcCprPlanRunCost + TcCprPlanRunCostO);
                                    TcCprPlanSetupCost = (decimal?)(TcCprPlanSetupCost + TcCprPlanSetupCostO);
                                    TcCprPlanLbrOvhd = (decimal?)(TcCprPlanLbrOvhd + TcCprPlanLbrOvhdF + TcCprPlanLbrOvhdV + TcCprPlanLbrOvhdL);
                                    TcCprPlanMchOvhd = (decimal?)(TcCprPlanMchOvhd + TcCprPlanMchOvhdV);
                                    TcCprPlanLbrTot = (decimal?)(TcCprPlanSetupCost + TcCprPlanRunCost + TcCprPlanLbrOvhd);
                                    if (sQLUtil.SQLEqual(ExOptacCostComponent, "L") == true)
                                    {
                                        var nonTable2LoadResponse = this.iRpt_EstimateJobCostDetailCRUD.SelectNontable(
                                                Job: JobJob,
                                                JobSuffix: JobSuffix,
                                                JobDate: JobJobDate,
                                                CustNum: JobCustNum,
                                                ProspectId: JobProspectId,
                                                QtyReleased: JobQtyReleased,
                                                Item: JobItem,
                                                Stat: JobStat,
                                                Ref: TRef,
                                                Des: jobdescription,
                                                OperNum: JobrouteOperNum,
                                                Wc: JobrouteWc,
                                                LTcCprPlanSetupCost: TcCprPlanSetupCost,
                                                LTcCprPlanRunCost: TcCprPlanRunCost,
                                                LTcCprPlanLbrOvhd: TcCprPlanLbrOvhd,
                                                LTcCprPlanLbrTot: TcCprPlanLbrTot,
                                                Ljrt_schStartDate: jrt_schstartdate,
                                                Ljrt_schEndDate: jrt_schENDdate,
                                                CostPriceFormat: CostPriceFormat,
                                                CostPricePlaces: CostPricePlaces,
                                                CurrencyFormat: CurrencyFormat,
                                                CurrencyPlaces: CurrencyPlaces,
                                                co_product_mix: co_product_mix,
                                                MO_co_job: MO_co_job,
                                                MO_product_cycle: MO_product_cycle,
                                                MO_qty_per_cycle: MO_qty_per_cycle,
                                                MO_shared: MO_shared,
                                                MoldingPack: MoldingPack);
                                        unionUtil.Add(nonTable2LoadResponse);
                                        processRowCount++;
                                        TcAmtPlanSetupCost = (decimal?)(TcAmtPlanSetupCost + TcCprPlanSetupCost);
                                        TcAmtPlanRunCost = (decimal?)(TcAmtPlanRunCost + TcCprPlanRunCost);
                                        TcAmtPlanLbrOvhd = (decimal?)(TcAmtPlanLbrOvhd + TcCprPlanLbrOvhd);

                                    }
                                    else
                                    {
                                        var nonTable3LoadResponse = this.iRpt_EstimateJobCostDetailCRUD.SelectNontable(
                                                Job: JobJob,
                                                JobSuffix: JobSuffix,
                                                JobDate: JobJobDate,
                                                CustNum: JobCustNum,
                                                ProspectId: JobProspectId,
                                                QtyReleased: JobQtyReleased,
                                                Item: JobItem,
                                                Stat: JobStat,
                                                Ref: TRef,
                                                Des: jobdescription,
                                                OperNum: JobrouteOperNum,
                                                Wc: JobrouteWc,
                                                ETPlanMchHrs: TPlanMchHrs,
                                                ETcCprPlanMchOvhd: TcCprPlanMchOvhd,
                                                Ejrt_schStartDate: jrt_schstartdate,
                                                Ejrt_schEndDate: jrt_schENDdate,
                                                CostPriceFormat: CostPriceFormat,
                                                CostPricePlaces: CostPricePlaces,
                                                CurrencyFormat: CurrencyFormat,
                                                CurrencyPlaces: CurrencyPlaces,
                                                co_product_mix: co_product_mix,
                                                MO_co_job: MO_co_job,
                                                MO_product_cycle: MO_product_cycle,
                                                MO_qty_per_cycle: MO_qty_per_cycle,
                                                MO_shared: MO_shared,
                                                MoldingPack: MoldingPack);
                                        unionUtil.Add(nonTable3LoadResponse);
                                        processRowCount++;
                                    }
                                    previousJobrouteItem = jobrouteItem;

                                }
                                while (jobrouteRecordStream.Read());
                                //Deallocate Cursor CURJOBROUTELC

                            }

                        }

                        previousJobItem = curJobItem;
                        if (recordCap > 0 && processRowCount > recordCap)
                        {
                            unionUtil.Add(this.iRpt_EstimateJobCostDetailCRUD.SelectNontable());                            
                            break;
                        }
                    }


                }
                //Deallocate Cursor CURJOB
                Data = unionUtil.Process();

                if (recordCap > 0 && processRowCount > recordCap)
                {
                    var preJobmatlJob = previousJobmatlItem?.GetValue<string>(24);
                    var preJobmatlSuffix = previousJobmatlItem?.GetValue<int?>(25);

                    var preJobrouteJob = previousJobrouteItem?.GetValue<string>(6);
                    var preJobrouteSuffix = previousJobrouteItem?.GetValue<int?>(7);
                    if ((previousJobmatlItem != null && !preJobmatlJob.Equals(JobmatlJob) || (preJobmatlJob.Equals(JobmatlJob) && preJobmatlSuffix != JobmatlSuffix))
                        || (previousJobrouteItem != null && !preJobrouteJob.Equals(JobrouteJob) || (preJobrouteJob.Equals(JobrouteJob) && preJobrouteSuffix != JobrouteSuffix)))
                    {
                        this.iRpt_EstimateJobCostDetailCRUD.InsertJobmatlBookmark(previousJobmatlItem);
                        this.iRpt_EstimateJobCostDetailCRUD.InsertJobrouteBookmark(previousJobrouteItem);
                        this.iRpt_EstimateJobCostDetailCRUD.InsertJobBookmark(previousJobItem);
                    }
                    
                    defineProcessVariable.DefineProcessVariableSp("RecordCap", (Data.Items.Count - 1).ToString(), null);
                    (int? returnCode, string variableValue, string infobar) = getVariable.GetVariableSp(Enum.GetName(typeof(SQLPagedRecordStreamBookmarkID), SQLPagedRecordStreamBookmarkID.Rpt_EstimateJobCostDetail_Job), "", 0, "", "");
                    defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
                }

                return (Data, Severity);
            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }
    }
}
