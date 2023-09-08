//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobOperationListing.cs

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
using CSI.Config;
using CSI.Material;
using CSI.Production;
using CSI.Adapters;
using CSI.Data.Cache;
using CSI.Data.Utilities;

namespace CSI.Reporting
{
    public class Rpt_JobOperationListing : IRpt_JobOperationListing
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICfgGetConfigValues iCfgGetConfigValues;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly ITransactionFactory transactionFactory;
        readonly IGetWinRegDecGroup iGetWinRegDecGroup;
        readonly IFixMaskForCrystal iFixMaskForCrystal;
        readonly IReportNotesExist iReportNotesExist;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IDataTableUtil dataTableUtil;
        readonly IVariableUtil variableUtil;
        readonly IHighAnyInt iHighAnyInt;
        readonly IRefSetDesc iRefSetDesc;
        readonly IStringUtil stringUtil;
        readonly ILowAnyInt iLowAnyInt;
        readonly IStringOf iStringOf;
        readonly IGetCode iGetCode;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;
        readonly IRefFmt iRefFmt;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly IUnionUtil unionUtil;
        readonly IQueryLanguage queryLanguage;
        readonly ICache mgSessionVariableBasedCache;
        readonly int pageSize;
        readonly int recordCap;
        int processedRowCount = 0;
        readonly LoadType loadType;
        readonly IRecordStreamFactory recordStreamFactory;
        readonly ISortOrder jobOperSortOrder;
        readonly ILowString lowString;
        readonly IHighString highString;
        public Rpt_JobOperationListing(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICfgGetConfigValues iCfgGetConfigValues,
            IGetIsolationLevel iGetIsolationLevel,
            ITransactionFactory transactionFactory,
            IGetWinRegDecGroup iGetWinRegDecGroup,
            IFixMaskForCrystal iFixMaskForCrystal,
            IReportNotesExist iReportNotesExist,
            IApplyDateOffset iApplyDateOffset,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IDataTableUtil dataTableUtil,
            IVariableUtil variableUtil,
            IHighAnyInt iHighAnyInt,
            IRefSetDesc iRefSetDesc,
            IStringUtil stringUtil,
            ILowAnyInt iLowAnyInt,
            IStringOf iStringOf,
            IGetCode iGetCode,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp,
            IRefFmt iRefFmt,
            IDefineProcessVariable defineProcessVariable,
            IGetVariable getVariable,
            IUnionUtil unionUtil,
            IRecordStreamFactory recordStreamFactory,
            ISortOrder jobOperSortOrder,
            IQueryLanguage queryLanguage,
            ICache mgSessionVariableBasedCache,
            CachePageSize pageSize,
            ILowString lowString,
            IHighString highString)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iCfgGetConfigValues = iCfgGetConfigValues;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.transactionFactory = transactionFactory;
            this.iGetWinRegDecGroup = iGetWinRegDecGroup;
            this.iFixMaskForCrystal = iFixMaskForCrystal;
            this.iReportNotesExist = iReportNotesExist;
            this.iApplyDateOffset = iApplyDateOffset;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.dataTableUtil = dataTableUtil;
            this.variableUtil = variableUtil;
            this.iHighAnyInt = iHighAnyInt;
            this.iRefSetDesc = iRefSetDesc;
            this.stringUtil = stringUtil;
            this.iLowAnyInt = iLowAnyInt;
            this.iStringOf = iStringOf;
            this.iGetCode = iGetCode;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
            this.iRefFmt = iRefFmt;
            this.defineProcessVariable = defineProcessVariable;
            this.getVariable = getVariable;
            this.unionUtil = unionUtil;
            this.queryLanguage = queryLanguage;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.pageSize = Convert.ToInt32(pageSize);
            recordCap = bunchedLoadCollection.RecordCap;
            loadType = bunchedLoadCollection.LoadType;
            this.recordStreamFactory = recordStreamFactory;
            this.jobOperSortOrder = jobOperSortOrder;
            this.lowString = lowString;
            this.highString = highString;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Rpt_JobOperationListingSp(
            string StartJob = null,
            string EndJob = null,
            int? StartSuffix = null,
            int? EndSuffix = null,
            string JobStat = null,
            string StartItem = null,
            string EndItem = null,
            string StartProdMix = null,
            string EndProdMix = null,
            DateTime? StartJobDate = null,
            DateTime? EndJobDate = null,
            int? StartOpera = null,
            int? EndOpera = null,
            int? OperLstDate = null,
            int? OperLstHr = null,
            string OperLstBC = null,
            string PrintCfgDetail = null,
            int? PrintBCFmt = null,
            int? PageOpera = null,
            int? DisplayRefFields = null,
            int? StartJobDateOffset = null,
            int? EndJobDateOffset = null,
            int? ShowInternal = null,
            int? ShowExternal = null,
            int? JobRouteNotes = null,
            int? JobMatlNotes = null,
            int? DisplayHeader = null,
            string BGSessionId = null,
            string pSite = null)
        {
            ICollectionLoadResponse Data = null;
            bunchedLoadCollection.StartBunching();

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            string job_job = null;
            int? job_suffix = null;
            string job_description = null;
            string job_revision = null;
            string job_stat = null;
            string job_ord_type = null;
            string job_ord_num = null;
            int? job_ord_line = null;
            int? job_ord_release = null;
            decimal? job_qty_released = null;
            int? job_co_product_mix = null;
            string job_prod_mix = null;
            string job_item = null;
            DateTime? job_job_date = null;
            string job_cust_num = null;
            string job_config_id = null;
            Guid? jobroute_rowpointer = null;
            int? jobroute_noteexistsflag = null;
            int? jobroute_oper_num = null;
            string bc_oper_num = null;
            string jobroute_wc = null;
            int? jobroute_cntrl_point = null;
            string jobroute_run_basis_lbr = null;
            string jobroute_run_basis_mch = null;
            decimal? jrt_sch_move_ticks = null;
            decimal? jrt_sch_queue_ticks = null;
            decimal? jrt_sch_setup_ticks = null;
            DateTime? jrt_sch_start_date = null;
            DateTime? jrt_sch_end_date = null;
            decimal? jrt_sch_pcs_per_lbr_hr = null;
            decimal? jrt_sch_run_ticks_lbr = null;
            decimal? jrt_sch_pcs_per_mch_hr = null;
            decimal? jrt_sch_run_ticks_mch = null;
            decimal? jrt_sch_sched_ticks = null;
            decimal? jrt_sch_sched_off = null;
            DescriptionType _wc_description = DBNull.Value;
            string wc_description = null;
            string wc_wc = null;
            Guid? jobmatl_rowpointer = null;
            int? jobmatl_sequence = null;
            int? jobmatl_noteexistsflag = null;
            string jobmatl_matl_type = null;
            string jobmatl_item = null;
            decimal? jobmatl_matl_qty_conv = null;
            string jobmatl_units = null;
            string jobmatl_ref_type = null;
            string jobmatl_ref_num = null;
            int? jobmatl_ref_line_suf = null;
            int? jobmatl_ref_rel = null;
            string jobmatl_description = null;
            string jobmatl_u_m = null;
            string t_status_desc = null;
            DescriptionType _t_prod_mix_desc = DBNull.Value;
            string t_prod_mix_desc = null;
            NameType _custaddr_name = DBNull.Value;
            string custaddr_name = null;
            string t_desc = null;
            RunBasisType _run_basis = DBNull.Value;
            string run_basis = null;
            int? rpt_set_fk = null;
            string t_ref = null;
            int? jobroute_note_exists_flag = null;
            int? jobmatl_note_exists_flag = null;
            string RefDesignator = null;
            string BubbleNum = null;
            string AssemblySeq = null;
            string NotInMaster = null;
            int? PrevOperNum = null;
            int? PrevSequence = null;
            int? FirstOfJobRef = null;
            string jobmatl_ref = null;
            string jobmatl_ref_type1 = null;
            decimal? Lbr = null;
            decimal? Mch = null;
            InputMaskType _QtyPerFormat = DBNull.Value;
            string QtyPerFormat = null;
            DecimalPlacesType _PlacesQtyPer = DBNull.Value;
            int? PlacesQtyPer = null;
            bool IsGroupFirstRow = true;
            int? JobRelChanged = null;
            ICollectionLoadRequest job06_crsLoadRequestForCursor = null;
            int? Severity = null;

            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_JobOperationListingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
                        [SpName] SYSNAME);
                    SELECT * into #tv_ALTGEN from @ALTGEN ");

                #region CRUD LoadToRecord
                var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"SpName","CAST (NULL AS NVARCHAR)"},
                        {"u0","[om].[ModuleName]"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_JobOperationListingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_JobOperationListingSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                    items: optional_module1LoadResponse.Items);

                this.appDB.Insert(optional_module1InsertRequest);
                #endregion InsertByRecords

                while (existsChecker.Exists(tableName: "#tv_ALTGEN",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("")))
                {
                    #region CRUD LoadToVariable
                    var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_ALTGEN_SpName,"[SpName]"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        maximumRows: 1,
                        tableName: "#tv_ALTGEN",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
                    if (tv_ALTGEN1LoadResponse.Items.Count > 0)
                    {
                        ALTGEN_SpName = _ALTGEN_SpName;
                    }
                    #endregion  LoadToVariable

                    var ALTGEN = AltExtGen_Rpt_JobOperationListingSp(_ALTGEN_SpName,
                        StartJob,
                        EndJob,
                        StartSuffix,
                        EndSuffix,
                        JobStat,
                        StartItem,
                        EndItem,
                        StartProdMix,
                        EndProdMix,
                        StartJobDate,
                        EndJobDate,
                        StartOpera,
                        EndOpera,
                        OperLstDate,
                        OperLstHr,
                        OperLstBC,
                        PrintCfgDetail,
                        PrintBCFmt,
                        PageOpera,
                        DisplayRefFields,
                        StartJobDateOffset,
                        EndJobDateOffset,
                        ShowInternal,
                        ShowExternal,
                        JobRouteNotes,
                        JobMatlNotes,
                        DisplayHeader,
                        BGSessionId,
                        pSite);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);
                    }

                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    #region CRUD LoadToRecord
                    var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"[SpName]","[SpName]"},
                        },
                        loadForChange: true, 
                        lockingType: LockingType.None,
                        tableName: "#tv_ALTGEN",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD DeleteByRecord
                    var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                    items: tv_ALTGEN2LoadResponse.Items);
                    this.appDB.Delete(tv_ALTGEN2DeleteRequest);
                    #endregion DeleteByRecord

                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
                }
            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_JobOperationListingSp") != null)
            {
                var EXTGEN = AltExtGen_Rpt_JobOperationListingSp("dbo.EXTGEN_Rpt_JobOperationListingSp",
                    StartJob,
                    EndJob,
                    StartSuffix,
                    EndSuffix,
                    JobStat,
                    StartItem,
                    EndItem,
                    StartProdMix,
                    EndProdMix,
                    StartJobDate,
                    EndJobDate,
                    StartOpera,
                    EndOpera,
                    OperLstDate,
                    OperLstHr,
                    OperLstBC,
                    PrintCfgDetail,
                    PrintBCFmt,
                    PageOpera,
                    DisplayRefFields,
                    StartJobDateOffset,
                    EndJobDateOffset,
                    ShowInternal,
                    ShowExternal,
                    JobRouteNotes,
                    JobMatlNotes,
                    DisplayHeader,
                    BGSessionId,
                    pSite);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("JobOperationListingReport"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            }

            StartJob = stringUtil.IsNull(
                this.iExpandKyByType.ExpandKyByTypeFn(
                    "JobType",
                    StartJob),
                this.lowString.LowStringFn("JobType"));
            EndJob = stringUtil.IsNull(
                this.iExpandKyByType.ExpandKyByTypeFn(
                    "JobType",
                    EndJob),
                this.highString.HighStringFn("JobType"));
            StartSuffix = convertToUtil.ToInt32(stringUtil.IsNull(
                StartSuffix,
                this.iLowAnyInt.LowAnyIntFn("SuffixType")));
            EndSuffix = convertToUtil.ToInt32(stringUtil.IsNull(
                EndSuffix,
                this.iHighAnyInt.HighAnyIntFn("SuffixType")));
            JobStat = stringUtil.IsNull(
                JobStat,
                "FRSCH");
            StartItem = stringUtil.IsNull(
                StartItem,
                this.lowString.LowStringFn("ItemType"));
            EndItem = stringUtil.IsNull(
                EndItem,
                this.highString.HighStringFn("ItemType"));
            StartProdMix = stringUtil.IsNull(
                StartProdMix,
                this.lowString.LowStringFn("ProdMixType"));
            EndProdMix = stringUtil.IsNull(
                EndProdMix,
                this.highString.HighStringFn("ProdMixType"));
            StartOpera = (int?)(stringUtil.IsNull(
                StartOpera,
                0));
            EndOpera = (int?)(stringUtil.IsNull(
                EndOpera,
                0));
            StartOpera = convertToUtil.ToInt32(stringUtil.IsNull(
                StartOpera == 0 ? null : StartOpera,
                this.iLowAnyInt.LowAnyIntFn("OperNumType")));
            EndOpera = convertToUtil.ToInt32(stringUtil.IsNull(
                EndOpera == 0 ? null : EndOpera,
                this.iHighAnyInt.HighAnyIntFn("OperNumType")));
            OperLstDate = (int?)(stringUtil.IsNull(
                OperLstDate,
                0));
            OperLstHr = (int?)(stringUtil.IsNull(
                OperLstHr,
                0));
            OperLstBC = stringUtil.IsNull(
                OperLstBC,
                "C");
            PrintCfgDetail = stringUtil.IsNull(
                PrintCfgDetail,
                "E");
            PrintBCFmt = (int?)(stringUtil.IsNull(
                PrintBCFmt,
                0));
            PageOpera = (int?)(stringUtil.IsNull(
                PageOpera,
                0));
            DisplayRefFields = (int?)(stringUtil.IsNull(
                DisplayRefFields,
                0));

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
                Date: StartJobDate,
                Offset: StartJobDateOffset,
                IsEndDate: 0);
            StartJobDate = ApplyDateOffset.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
                Date: EndJobDate,
                Offset: EndJobDateOffset,
                IsEndDate: 1);
            EndJobDate = ApplyDateOffset1.Date;

            #endregion ExecuteMethodCall

            IsGroupFirstRow = true;
            JobRelChanged = 1;

            #region CRUD LoadToVariable
            var sfcparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_run_basis,"sfcparms.run_basis"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "sfcparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var sfcparmsLoadResponse = this.appDB.Load(sfcparmsLoadRequest);
            if (sfcparmsLoadResponse.Items.Count > 0)
            {
                run_basis = _run_basis;
            }
            #endregion  LoadToVariable


            #region CRUD LoadToVariable
            var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_PlacesQtyPer,"places_qty_per"},
                    {_QtyPerFormat,"qty_per_format"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "invparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var invparmsLoadResponse = this.appDB.Load(invparmsLoadRequest);
            if (invparmsLoadResponse.Items.Count > 0)
            {
                PlacesQtyPer = _PlacesQtyPer;
                QtyPerFormat = _QtyPerFormat;
            }
            #endregion  LoadToVariable

            QtyPerFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                QtyPerFormat,
                this.iGetWinRegDecGroup.GetWinRegDecGroupFn());

            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @ConfigSet TABLE (
                    CompOperNum  OperNumType        ,
                    CompSequence JobmatlSequenceType,
                    CompCompName ConfigCompNameType ,
                    CompQty      QtyUnitType        ,
                    CompPrice    CostPrcType        ,
                    AttrName     ConfigAttrNameType ,
                    AttrValue    ConfigAttrValueType);
                SELECT * into #tv_ConfigSet from @ConfigSet ");
            #region Cursor Statement

            #region CRUD LoadToRecord
            job06_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"job.job","job.job"},
                    {"job.suffix","job.suffix"},
                    {"description","job.description"},
                    {"revision","job.revision"},
                    {"stat","job.stat"},
                    {"ord_type","job.ord_type"},
                    {"ord_num","job.ord_num"},
                    {"ord_line","job.ord_line"},
                    {"ord_release","job.ord_release"},
                    {"qty_released","job.qty_released"},
                    {"co_product_mix","job.co_product_mix"},
                    {"prod_mix","job.prod_mix"},
                    {"item","job.item"},
                    {"job_date","job.job_date"},
                    {"cust_num","job.cust_num"},
                    {"config_id","job.config_id"},
                    {"rowpointer","jobroute.rowpointer"},
                    {"noteexistsflag","jobroute.noteexistsflag"},
                    {"jobroute.oper_num","jobroute.oper_num"},
                    {"wc","jobroute.wc"},
                    {"cntrl_point","jobroute.cntrl_point"},
                    {"run_basis_lbr","jobroute.run_basis_lbr"},
                    {"run_basis_mch","jobroute.run_basis_mch"},
                    {"move_ticks","jrt_sch.move_ticks"},
                    {"queue_ticks","jrt_sch.queue_ticks"},
                    {"setup_ticks","jrt_sch.setup_ticks"},
                    {"start_date","jrt_sch.start_date"},
                    {"end_date","jrt_sch.end_date"},
                    {"pcs_per_lbr_hr","jrt_sch.pcs_per_lbr_hr"},
                    {"run_ticks_lbr","jrt_sch.run_ticks_lbr"},
                    {"pcs_per_mch_hr","jrt_sch.pcs_per_mch_hr"},
                    {"run_ticks_mch","jrt_sch.run_ticks_mch"},
                    {"sched_ticks","jrt_sch.sched_ticks"},
                    {"sched_off","jrt_sch.sched_off"},
                    {"description_","wc.description"},
                    {"wc.wc","wc.wc"},
                    {"rowpointer_","jobmatl.rowpointer"},
                    {"jobmatl.sequence","jobmatl.sequence"},
                    {"noteexistsflag_","jobmatl.noteexistsflag"},
                    {"matl_type","jobmatl.matl_type"},
                    {"jobmatl.item","jobmatl.item"},
                    {"matl_qty_conv","jobmatl.matl_qty_conv"},
                    {"units","jobmatl.units"},
                    {"ref_type","jobmatl.ref_type"},
                    {"ref_num","jobmatl.ref_num"},
                    {"ref_line_suf","jobmatl.ref_line_suf"},
                    {"ref_release","jobmatl.ref_release"},
                    {"col0",$"CAST (NULL AS NVARCHAR)"},
                    {"u_m","jobmatl.u_m"},
                    {"ref_des","job_ref.ref_des"},
                    {"bubble","job_ref.bubble"},
                    {"assy_seq","job_ref.assy_seq"},
                    {"JobRelChanged","LEAD(0, 1, 1) OVER(PARTITION BY job.job, job.suffix ORDER BY job.job, job.suffix, jobroute.oper_num, wc.wc,jobmatl.item, jobmatl.sequence)"},
                    {"u0","item.rowpointer"},
                    {"u1","jobmatl.description"},
                    {"u2","item.description"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "job",
                fromClause: collectionLoadRequestFactory.Clause(@" left outer join jobroute on jobroute.job = job.job 
                    and jobroute.suffix = job.suffix 
                    and (jobroute.oper_num >= {0} 
                         and jobroute.oper_num <= {1}) inner join jrt_sch on jrt_sch.job = jobroute.job 
                    and jrt_sch.suffix = jobroute.suffix 
                    and jrt_sch.oper_num = jobroute.oper_num left outer join wc on wc.wc = jobroute.wc left outer join jobmatl on jobmatl.job = jobroute.job 
                    and jobmatl.suffix = jobroute.suffix 
                    and jobmatl.oper_num = jobroute.oper_num left outer join item on item.item = jobmatl.item left outer join job_ref on job_ref.job = jobmatl.job 
                    and job_ref.suffix = jobmatl.suffix 
                    and job_ref.oper_num = jobmatl.oper_num 
                    and job_ref.sequence = jobmatl.sequence", StartOpera, EndOpera),
                whereClause: collectionLoadRequestFactory.Clause("job.type = 'J' AND job.job >= {8} AND job.job <= {11} AND job.suffix >= CASE WHEN job.job = {8} THEN {3} ELSE dbo.LowAnyInt('SuffixType') END AND job.suffix <= CASE WHEN job.job = {11} THEN {6} ELSE dbo.HighAnyInt('SuffixType') END AND job.item BETWEEN {7} AND {9} AND isnull(job.prod_mix, {0}) BETWEEN {1} AND {4} AND job.job_date BETWEEN {2} AND {5} AND CHARINDEX(job.stat, {10}) <> 0", this.lowString.LowStringFn("ProdMixType"), StartProdMix, StartJobDate, StartSuffix, EndProdMix, EndJobDate, EndSuffix, StartItem, StartJob, EndItem, JobStat, EndJob),
                orderByClause: collectionLoadRequestFactory.Clause(" job.job, job.suffix, jobroute.oper_num, wc.wc,jobmatl.item, jobmatl.sequence"));
            #endregion  LoadToRecord

            #endregion Cursor Statement

            using (IRecordStream sQLPagedRecordStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache,
                    collectionLoadRequestFactory, job06_crsLoadRequestForCursor, jobOperSortOrder, SQLPagedRecordStreamBookmarkID.MyReport_Rpt, pageSize, loadType))
            {
                while (sQLPagedRecordStream.Read())
                {
                    var jobItem = sQLPagedRecordStream.Current;
                    job_job = jobItem.GetValue<string>("job.job");
                    job_suffix = jobItem.GetValue<int?>("job.suffix");
                    job_description = jobItem.GetValue<string>("description");
                    job_revision = jobItem.GetValue<string>("revision");
                    job_stat = jobItem.GetValue<string>("stat");
                    job_ord_type = jobItem.GetValue<string>("ord_type");
                    job_ord_num = jobItem.GetValue<string>("ord_num");
                    job_ord_line = jobItem.GetValue<int?>("ord_line");
                    job_ord_release = jobItem.GetValue<int?>("ord_release");
                    job_qty_released = jobItem.GetValue<decimal?>("qty_released");
                    job_co_product_mix = jobItem.GetValue<int?>("co_product_mix");
                    job_prod_mix = jobItem.GetValue<string>("prod_mix");
                    job_item = jobItem.GetValue<string>("item");
                    job_job_date = jobItem.GetValue<DateTime?>("job_date");
                    job_cust_num = jobItem.GetValue<string>("cust_num");
                    job_config_id = jobItem.GetValue<string>("config_id");
                    jobroute_rowpointer = jobItem.GetValue<Guid?>("rowpointer");
                    jobroute_noteexistsflag = jobItem.GetValue<int?>("noteexistsflag");
                    jobroute_oper_num = jobItem.GetValue<int?>("jobroute.oper_num");
                    jobroute_wc = jobItem.GetValue<string>("wc");
                    jobroute_cntrl_point = jobItem.GetValue<int?>("cntrl_point");
                    jobroute_run_basis_lbr = jobItem.GetValue<string>("run_basis_lbr");
                    jobroute_run_basis_mch = jobItem.GetValue<string>("run_basis_mch");
                    jrt_sch_move_ticks = jobItem.GetValue<decimal?>("move_ticks");
                    jrt_sch_queue_ticks = jobItem.GetValue<decimal?>("queue_ticks");
                    jrt_sch_setup_ticks = jobItem.GetValue<decimal?>("setup_ticks");
                    jrt_sch_start_date = jobItem.GetValue<DateTime?>("start_date");
                    jrt_sch_end_date = jobItem.GetValue<DateTime?>("end_date");
                    jrt_sch_pcs_per_lbr_hr = jobItem.GetValue<decimal?>("pcs_per_lbr_hr");
                    jrt_sch_run_ticks_lbr = jobItem.GetValue<decimal?>("run_ticks_lbr");
                    jrt_sch_pcs_per_mch_hr = jobItem.GetValue<decimal?>("pcs_per_mch_hr");
                    jrt_sch_run_ticks_mch = jobItem.GetValue<decimal?>("run_ticks_mch");
                    jrt_sch_sched_ticks = jobItem.GetValue<decimal?>("sched_ticks");
                    jrt_sch_sched_off = jobItem.GetValue<decimal?>("sched_off");
                    wc_description = jobItem.GetValue<string>("description_");
                    wc_wc = jobItem.GetValue<string>("wc.wc");
                    jobmatl_rowpointer = jobItem.GetValue<Guid?>("rowpointer_");
                    jobmatl_sequence = jobItem.GetValue<int?>("jobmatl.sequence");
                    jobmatl_noteexistsflag = jobItem.GetValue<int?>("noteexistsflag_");
                    jobmatl_matl_type = jobItem.GetValue<string>("matl_type");
                    jobmatl_item = jobItem.GetValue<string>("jobmatl.item");
                    jobmatl_matl_qty_conv = jobItem.GetValue<decimal?>("matl_qty_conv");
                    jobmatl_units = jobItem.GetValue<string>("units");
                    jobmatl_ref_type = jobItem.GetValue<string>("ref_type");
                    jobmatl_ref_num = jobItem.GetValue<string>("ref_num");
                    jobmatl_ref_line_suf = jobItem.GetValue<int?>("ref_line_suf");
                    jobmatl_ref_rel = jobItem.GetValue<int?>("ref_release");
                    jobmatl_description = (jobItem.GetValue<Guid?>("u0") == null ? jobItem.GetValue<string>("u1") : jobItem.GetValue<string>("u2"));
                    jobmatl_u_m = jobItem.GetValue<string>("u_m");
                    RefDesignator = jobItem.GetValue<string>("ref_des");
                    BubbleNum = jobItem.GetValue<string>("bubble");
                    AssemblySeq = jobItem.GetValue<string>("assy_seq");
                    JobRelChanged = jobItem.GetValue<int?>("JobRelChanged");

                    if (IsGroupFirstRow)
                    {
                        if (job_description != null)
                        {
                            t_desc = job_description;
                        }
                        else
                        {
                            if (NotInMaster == null)
                            {

                                #region CRUD ExecuteMethodCall

                                var MsgApp = this.iMsgApp.MsgAppSp(
                                    Infobar: NotInMaster,
                                    BaseMsg: "E=NotInMaster",
                                    Parm1: "@notes");
                                NotInMaster = MsgApp.Infobar;

                                #endregion ExecuteMethodCall


                            }
                            t_desc = NotInMaster;
                        }

                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: GetCodeSp
                        var GetCode = this.iGetCode.GetCodeSp(
                            PClass: "job.stat",
                            PCode: job_stat,
                            PDesc: t_status_desc);
                        t_status_desc = GetCode.PDesc;

                        #endregion ExecuteMethodCall

                        t_ref = this.iRefFmt.RefFmtSp(
                            job_ord_type,
                            job_ord_num,
                            job_ord_line,
                            job_ord_release);
                        custaddr_name = null;

                        #region CRUD LoadToVariable
                        var custaddrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_custaddr_name,"ISNULL(custaddr.name, '')"},
                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "custaddr",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("NULLIF (custaddr.cust_num, {0}) IS NULL AND custaddr.cust_seq = 0", job_cust_num),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var custaddrLoadResponse = this.appDB.Load(custaddrLoadRequest);
                        if (custaddrLoadResponse.Items.Count > 0)
                        {
                            custaddr_name = _custaddr_name;
                        }
                        #endregion  LoadToVariable

                        if (custaddr_name == null)
                        {
                            #region CRUD LoadToVariable
                            var custaddr1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                {
                                    {_custaddr_name,"ISNULL(custaddr.name, '')"},
                                },
                                loadForChange: false, 
                                lockingType: LockingType.None,
                                tableName: "custaddr",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("custaddr.cust_num = '' AND custaddr.cust_seq = 0"),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var custaddr1LoadResponse = this.appDB.Load(custaddr1LoadRequest);
                            if (custaddr1LoadResponse.Items.Count > 0)
                            {
                                custaddr_name = _custaddr_name;
                            }
                            #endregion  LoadToVariable
                        }
                        custaddr_name = stringUtil.IsNull(
                            custaddr_name,
                            "");
                        t_prod_mix_desc = "";
                        if (sQLUtil.SQLEqual(job_co_product_mix, 1) == true)
                        {
                            #region CRUD LoadToVariable
                            var prod_mixLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                {
                                    {_t_prod_mix_desc,"ISNULL(prod_mix.description, '')"},
                                },
                                loadForChange: false,
                                lockingType: LockingType.None,
                                tableName: "prod_mix",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("NULLIF (prod_mix.prod_mix, {0}) IS NULL", job_prod_mix),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var prod_mixLoadResponse = this.appDB.Load(prod_mixLoadRequest);
                            if (prod_mixLoadResponse.Items.Count > 0)
                            {
                                t_prod_mix_desc = _t_prod_mix_desc;
                            }
                            #endregion  LoadToVariable
                        }
                        rpt_set_fk = this.scalarFunction.Execute<int>("@@IDENTITY");
                        if (sQLUtil.SQLNotEqual(PrintCfgDetail, "N") == true && job_config_id != null)
                        {
                            //Please Generate the bounce for this function: CfgGetConfigValues.
                            iCfgGetConfigValues.CfgGetConfigValuesFn(job_config_id, PrintCfgDetail);

                            #region CRUD LoadToRecord
                            var ReportSet1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                            {
                                {"job_prefix",$"{variableUtil.GetValue<string>(job_job)}"},
                                {"job_suffix",$"{variableUtil.GetValue<int?>(job_suffix)}"},
                                {"is_routing",$"0"},
                                {"oper_num","CompOperNum"},
                                {"bc_oper_num", "CAST (NULL AS nchar)"},
                                {"job_date",$"CAST ({variableUtil.GetValue<DateTime?>(job_job_date)} AS DateTime)"},
                                {"status",$"{variableUtil.GetValue<string>(job_stat)}"},
                                {"stat_desc",$"{variableUtil.GetValue<string>(t_status_desc)}"},
                                {"prod_mix",$"{variableUtil.GetValue<string>(job_prod_mix)}"},
                                {"prod_mix_desc",$"{variableUtil.GetValue<string>(t_prod_mix_desc)}"},
                                {"item1",$"{variableUtil.GetValue<string>(job_item)}"},
                                {"released",$"{variableUtil.GetValue<decimal?>(job_qty_released)}"},
                                {"job_desc",$"{variableUtil.GetValue<string>(t_desc)}"},
                                {"revision",$"{variableUtil.GetValue<string>(job_revision)}"},
                                {"cust_num",$"{variableUtil.GetValue<string>(job_cust_num)}"},
                                {"reference",$"{variableUtil.GetValue<string>(t_ref)}"},
                                {"cust_name",$"{variableUtil.GetValue<string>(custaddr_name)}"},
                                {"co_product_flag",$"{variableUtil.GetValue<int?>(job_co_product_mix)}"},
                                {"rpt_set1_fk", "CAST (NULL AS int)"},
                                {"wc", "CAST (NULL AS nvarchar)"},
                                {"wc_desc", "CAST (NULL AS nvarchar)"},
                                {"move_hrs", "CAST (NULL AS decimal)"},
                                {"queue_hrs", "CAST (NULL AS decimal)"},
                                {"setup_hrs", "CAST (NULL AS decimal)"},
                                {"start_date", "CAST (NULL AS DateTime)"},
                                {"end_date", "CAST (NULL AS DateTime)"},
                                {"control", "CAST (NULL AS int)"},
                                {"basis_lbr", "CAST (NULL AS nvarchar)"},
                                {"pcs_per_lbr_hr", "CAST (NULL AS decimal)"},
                                {"basis_mch", "CAST (NULL AS nvarchar)"},
                                {"pcs_per_mch_hr", "CAST (NULL AS decimal)"},
                                {"sch_hrs", "CAST (NULL AS decimal)"},
                                {"offset_hrs", "CAST (NULL AS decimal)"},
                                {"jobroute_rowpointer", "CAST (NULL AS nvarchar)"},
                                {"jobroute_noteexistsflag", "CAST (NULL AS int)"},
                                {"sequence","CompSequence"},
                                {"type", "CAST (NULL AS nvarchar)"},
                                {"item3", "CAST (NULL AS nvarchar)"},
                                {"qty", "CAST (NULL AS decimal)"},
                                {"per", "CAST (NULL AS nvarchar)"},
                                {"jobmatl_ref", "CAST (NULL AS nvarchar)"},
                                {"item3_desc", "CAST (NULL AS nvarchar)"},
                                {"u_m", "CAST (NULL AS nvarchar)"},
                                {"jobmatl_rowpointer", "CAST (NULL AS nvarchar)"},
                                {"jobmatl_noteexistsflag", "CAST (NULL AS int)"},
                                {"cfg_comp_comp_name","CompCompName"},
                                {"cfg_comp_qty","CompQty"},
                                {"cfg_comp_price","CompPrice"},
                                {"cfg_attr_attr_name","AttrName"},
                                {"cfg_attr_attr_value","AttrValue"},
                                {"RefDesignator", "CAST (NULL AS nvarchar)"},
                                {"BubbleNum", "CAST (NULL AS nvarchar)"},
                                {"AssemblySeq", "CAST (NULL AS nvarchar)"},
                                {"run_basis",$"{variableUtil.GetValue<string>(run_basis)}"},
                                {"QtyPerFormat", "CAST (NULL AS nvarchar)"},
                                {"PlacesQtyPer", "CAST (NULL AS int)"},

                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "#fnt_CfgGetConfigValues",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause(""),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                            var ReportSet1LoadResponse = this.appDB.Load(ReportSet1LoadRequest);
                            #endregion  LoadToRecord

                            #region CRUD InsertByRecords
                            unionUtil.Add(ReportSet1LoadResponse);
                            processedRowCount += ReportSet1LoadResponse.Items.Count;
                            #endregion InsertByRecords
                        }
                        PrevOperNum = 0;
                        PrevSequence = 0;
                        FirstOfJobRef = 1;
                    }

                    if (wc_wc == null)
                    {

                        #region CRUD LoadToVariable
                        var wcLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_wc_description,"wc.description"},
                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "wc",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("wc.wc = ''"),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var wcLoadResponse = this.appDB.Load(wcLoadRequest);
                        if (wcLoadResponse.Items.Count > 0)
                        {
                            wc_description = _wc_description;
                        }
                        #endregion  LoadToVariable

                    }
                    if (sQLUtil.SQLEqual(JobRouteNotes, 1) == true)
                    {
                        jobroute_note_exists_flag = 0;
                        if (sQLUtil.SQLEqual(ShowInternal, 1) == true || sQLUtil.SQLEqual(ShowExternal, 1) == true)
                        {
                            jobroute_note_exists_flag = convertToUtil.ToInt32(this.iReportNotesExist.ReportNotesExistFn(
                                "jobroute",
                                jobroute_rowpointer,
                                ShowInternal,
                                ShowExternal,
                                jobroute_noteexistsflag));

                        }
                    }
                    if (sQLUtil.SQLEqual(JobMatlNotes, 1) == true)
                    {
                        jobmatl_note_exists_flag = 0;
                        if (sQLUtil.SQLEqual(ShowInternal, 1) == true || sQLUtil.SQLEqual(ShowExternal, 1) == true)
                        {
                            jobmatl_note_exists_flag = convertToUtil.ToInt32(this.iReportNotesExist.ReportNotesExistFn(
                                "jobmatl",
                                jobmatl_rowpointer,
                                ShowInternal,
                                ShowExternal,
                                jobmatl_noteexistsflag));

                        }
                    }
                    jobmatl_ref_type1 = stringUtil.Concat("@:RefTypeIJKPRT:", jobmatl_ref_type);
                    jobmatl_ref = this.iRefSetDesc.RefSetDescSp(
                        jobmatl_ref_type,
                        this.iStringOf.StringOfFn(jobmatl_ref_type1),
                        jobmatl_ref_num,
                        jobmatl_ref_line_suf,
                        jobmatl_ref_rel);
                    bc_oper_num = convertToUtil.ToString(stringUtil.LTrim(jobroute_oper_num));
                    if (sQLUtil.SQLNotEqual(PrevOperNum, jobroute_oper_num) == true || sQLUtil.SQLNotEqual(PrevSequence, jobmatl_sequence) == true)
                    {
                        PrevOperNum = jobroute_oper_num;
                        PrevSequence = jobmatl_sequence;
                        FirstOfJobRef = 1;
                    }
                    else
                    {
                        FirstOfJobRef = 0;
                    }
                    if (sQLUtil.SQLEqual(jobroute_run_basis_lbr, "H") == true)
                    {
                        Lbr = (decimal?)(convertToUtil.ToDecimal(jrt_sch_run_ticks_lbr) / 100M);
                    }
                    else
                    {
                        Lbr = jrt_sch_pcs_per_lbr_hr;
                    }
                    if (sQLUtil.SQLEqual(jobroute_run_basis_mch, "H") == true)
                    {
                        Mch = (decimal?)(convertToUtil.ToDecimal(jrt_sch_run_ticks_mch) / 100M);
                    }
                    else
                    {
                        Mch = jrt_sch_pcs_per_mch_hr;
                    }

                    #region CRUD LoadResponseWithoutTable
                    var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                    {

                        { "job_prefix", job_job},
                        { "job_suffix", job_suffix},
                        { "is_routing", 1},
                        { "oper_num", jobroute_oper_num},
                        { "bc_oper_num", bc_oper_num},
                        { "job_date", job_job_date},
                        { "status", job_stat},
                        { "stat_desc", t_status_desc},
                        { "prod_mix", job_prod_mix},
                        { "prod_mix_desc", t_prod_mix_desc},
                        { "item1", job_item},
                        { "released", job_qty_released},
                        { "job_desc", t_desc},
                        { "revision", job_revision},
                        { "cust_num", job_cust_num},
                        { "reference", t_ref},
                        { "cust_name", custaddr_name},
                        { "co_product_flag", job_co_product_mix},
                        { "rpt_set1_fk", null},
                        { "wc", jobroute_wc},
                        { "wc_desc", wc_description},
                        { "move_hrs", sQLUtil.SQLEqual(OperLstHr, 1) == true ? convertToUtil.ToDecimal(jrt_sch_move_ticks) / 100M : null},
                        { "queue_hrs", sQLUtil.SQLEqual(OperLstHr, 1) == true ? convertToUtil.ToDecimal(jrt_sch_queue_ticks) / 100M : null},
                        { "setup_hrs", sQLUtil.SQLEqual(OperLstHr, 1) == true ? convertToUtil.ToDecimal(jrt_sch_setup_ticks) / 100M : null},
                        { "start_date", sQLUtil.SQLEqual(OperLstDate, 1) == true ? jrt_sch_start_date : convertToUtil.ToDateTime<string>(null)},
                        { "end_date", sQLUtil.SQLEqual(OperLstDate, 1) == true ? jrt_sch_end_date : convertToUtil.ToDateTime<string>(null)},
                        { "control", jobroute_cntrl_point},
                        { "basis_lbr", sQLUtil.SQLEqual(OperLstHr, 1) == true ? (sQLUtil.SQLEqual(run_basis, jobroute_run_basis_lbr) == true ? " " : jobroute_run_basis_lbr) : convertToUtil.ToString<string>(null)},
                        { "pcs_per_lbr_hr", sQLUtil.SQLEqual(OperLstHr, 1) == true ? Lbr : null},
                        { "basis_mch", sQLUtil.SQLEqual(OperLstHr, 1) == true ? (sQLUtil.SQLEqual(run_basis, jobroute_run_basis_mch) == true ? " " : jobroute_run_basis_mch) : convertToUtil.ToString<string>(null)},
                        { "pcs_per_mch_hr", sQLUtil.SQLEqual(OperLstHr, 1) == true ? Mch : null},
                        { "sch_hrs", sQLUtil.SQLEqual(OperLstHr, 1) == true ? convertToUtil.ToDecimal(jrt_sch_sched_ticks) / 100M : null},
                        { "offset_hrs", sQLUtil.SQLEqual(OperLstHr, 1) == true ? convertToUtil.ToDecimal(jrt_sch_sched_off) / 100M : null},
                        { "jobroute_rowpointer", sQLUtil.SQLEqual(JobRouteNotes, 1) == true ? jobroute_rowpointer : convertToUtil.ToGuid<string>(null)},
                        { "jobroute_noteexistsflag", sQLUtil.SQLEqual(JobRouteNotes, 1) == true ? jobroute_note_exists_flag : null},
                        { "sequence", jobmatl_sequence},
                        { "type", sQLUtil.SQLEqual(FirstOfJobRef, 1) == true ? jobmatl_matl_type : convertToUtil.ToString<string>(null)},
                        { "item3", jobmatl_item},
                        { "qty", jobmatl_matl_qty_conv},
                        { "per", jobmatl_units},
                        { "jobmatl_ref", jobmatl_ref},
                        { "item3_desc", jobmatl_description},
                        { "u_m", jobmatl_u_m},
                        { "jobmatl_rowpointer", sQLUtil.SQLEqual(JobMatlNotes, 1) == true ? jobmatl_rowpointer : convertToUtil.ToGuid<string>(null)},
                        { "jobmatl_noteexistsflag", sQLUtil.SQLEqual(JobMatlNotes, 1) == true ? jobmatl_note_exists_flag : null},
                        { "cfg_comp_comp_name", null},
                        { "cfg_comp_qty", null},
                        { "cfg_comp_price", null},
                        { "cfg_attr_attr_name", null},
                        { "cfg_attr_attr_value", null},
                        { "RefDesignator", RefDesignator},
                        { "BubbleNum", BubbleNum},
                        { "AssemblySeq", AssemblySeq},
                        { "run_basis", run_basis},
                        { "QtyPerFormat", QtyPerFormat},
                        { "PlacesQtyPer", PlacesQtyPer},
                    });

                    var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);

                    #endregion CRUD LoadResponseWithoutTable

                    #region CRUD InsertByRecords
                    unionUtil.Add(nonTableLoadResponse);
                    processedRowCount += nonTableLoadResponse.Items.Count;
                    #endregion InsertByRecords

                    if(processedRowCount > recordCap)
                    {
                        // Insert one more row so that get more row is enabled.
                        var nonTableLoadRequest2 = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                        {
                            { "job_prefix", this.highString.HighStringFn("JobType")},
                            { "job_suffix", 0},
                            { "is_routing", 0},
                            { "oper_num", 0},
                            { "bc_oper_num", ""},
                            { "job_date", null},
                            { "status", ""},
                            { "stat_desc", ""},
                            { "prod_mix", ""},
                            { "prod_mix_desc", ""},
                            { "item1", ""},
                            { "released", 0M},
                            { "job_desc", ""},
                            { "revision", ""},
                            { "cust_num", ""},
                            { "reference", ""},
                            { "cust_name", ""},
                            { "co_product_flag", 0},
                            { "rpt_set1_fk", null},
                            { "wc", ""},
                            { "wc_desc", ""},
                            { "move_hrs", 0M},
                            { "queue_hrs", 0M},
                            { "setup_hrs", 0M},
                            { "start_date", null},
                            { "end_date", null},
                            { "control", 0},
                            { "basis_lbr",""},
                            { "pcs_per_lbr_hr", 0M},
                            { "basis_mch", ""},
                            { "pcs_per_mch_hr", 0M},
                            { "sch_hrs", 0M},
                            { "offset_hrs", 0M},
                            { "jobroute_rowpointer", null},
                            { "jobroute_noteexistsflag", 0},
                            { "sequence", 0},
                            { "type", ""},
                            { "item3", ""},
                            { "qty", 0M},
                            { "per", ""},
                            { "jobmatl_ref", ""},
                            { "item3_desc", ""},
                            { "u_m", ""},
                            { "jobmatl_rowpointer", null},
                            { "jobmatl_noteexistsflag", 0},
                            { "cfg_comp_comp_name", null},
                            { "cfg_comp_qty", null},
                            { "cfg_comp_price", null},
                            { "cfg_attr_attr_name", null},
                            { "cfg_attr_attr_value", null},
                            { "RefDesignator", ""},
                            { "BubbleNum", ""},
                            { "AssemblySeq", ""},
                            { "run_basis", ""},
                            { "QtyPerFormat", ""},
                            { "PlacesQtyPer", 0},
                        });
                        var nonTableLoadResponse2 = this.appDB.Load(nonTableLoadRequest2);

                        unionUtil.Add(nonTableLoadResponse2);
                        break;
                    }

                    IsGroupFirstRow = JobRelChanged == 1;
                }
            }
            //Deallocate Cursor job06_crs

            Data = unionUtil.Process();

            #region CRUD ExecuteMethodCall

            #endregion ExecuteMethodCall
            defineProcessVariable.DefineProcessVariableSp("RecordCap", (Data.Items.Count - 1).ToString(), null);
            (int? returnCode, string variableValue, string infobar) = getVariable.GetVariableSp("MyReport_Rpt", "", 0, "", "");
            defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
            bunchedLoadCollection.EndBunching();

            return (Data, Severity);
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_Rpt_JobOperationListingSp(
            string AltExtGenSp,
            string StartJob = null,
            string EndJob = null,
            int? StartSuffix = null,
            int? EndSuffix = null,
            string JobStat = null,
            string StartItem = null,
            string EndItem = null,
            string StartProdMix = null,
            string EndProdMix = null,
            DateTime? StartJobDate = null,
            DateTime? EndJobDate = null,
            int? StartOpera = null,
            int? EndOpera = null,
            int? OperLstDate = null,
            int? OperLstHr = null,
            string OperLstBC = null,
            string PrintCfgDetail = null,
            int? PrintBCFmt = null,
            int? PageOpera = null,
            int? DisplayRefFields = null,
            int? StartJobDateOffset = null,
            int? EndJobDateOffset = null,
            int? ShowInternal = null,
            int? ShowExternal = null,
            int? JobRouteNotes = null,
            int? JobMatlNotes = null,
            int? DisplayHeader = null,
            string BGSessionId = null,
            string pSite = null)
        {
            JobType _StartJob = StartJob;
            JobType _EndJob = EndJob;
            SuffixType _StartSuffix = StartSuffix;
            SuffixType _EndSuffix = EndSuffix;
            StringType _JobStat = JobStat;
            ItemType _StartItem = StartItem;
            ItemType _EndItem = EndItem;
            ProdMixType _StartProdMix = StartProdMix;
            ProdMixType _EndProdMix = EndProdMix;
            GenericDateType _StartJobDate = StartJobDate;
            GenericDateType _EndJobDate = EndJobDate;
            OperNumType _StartOpera = StartOpera;
            OperNumType _EndOpera = EndOpera;
            ListYesNoType _OperLstDate = OperLstDate;
            ListYesNoType _OperLstHr = OperLstHr;
            StringType _OperLstBC = OperLstBC;
            StringType _PrintCfgDetail = PrintCfgDetail;
            ListYesNoType _PrintBCFmt = PrintBCFmt;
            ListYesNoType _PageOpera = PageOpera;
            ListYesNoType _DisplayRefFields = DisplayRefFields;
            DateOffsetType _StartJobDateOffset = StartJobDateOffset;
            DateOffsetType _EndJobDateOffset = EndJobDateOffset;
            ListYesNoType _ShowInternal = ShowInternal;
            ListYesNoType _ShowExternal = ShowExternal;
            ListYesNoType _JobRouteNotes = JobRouteNotes;
            ListYesNoType _JobMatlNotes = JobMatlNotes;
            ListYesNoType _DisplayHeader = DisplayHeader;
            StringType _BGSessionId = BGSessionId;
            SiteType _pSite = pSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "StartJob", _StartJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndJob", _EndJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartSuffix", _StartSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndSuffix", _EndSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobStat", _JobStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartProdMix", _StartProdMix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndProdMix", _EndProdMix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartJobDate", _StartJobDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndJobDate", _EndJobDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartOpera", _StartOpera, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndOpera", _EndOpera, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OperLstDate", _OperLstDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OperLstHr", _OperLstHr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OperLstBC", _OperLstBC, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintCfgDetail", _PrintCfgDetail, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintBCFmt", _PrintBCFmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PageOpera", _PageOpera, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayRefFields", _DisplayRefFields, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartJobDateOffset", _StartJobDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndJobDateOffset", _EndJobDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobRouteNotes", _JobRouteNotes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobMatlNotes", _JobMatlNotes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
                var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;

                return (resultSet, returnCode);
            }
        }
    }
}
