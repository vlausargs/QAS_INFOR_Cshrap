//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateJobCostDetailCRUD.cs

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
using CSI.Data.Cache;

namespace CSI.Reporting
{
    public class Rpt_EstimateJobCostDetailCRUD : IRpt_EstimateJobCostDetailCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ITransactionFactory transactionFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IQueryLanguage queryLanguage;
        readonly ICache mgSessionVariableBasedCache;
        readonly IRecordStreamFactory recordStreamFactory;
        readonly ISortOrderFactory sortOrderFactory;
        readonly IBookmarkFactory bookmarkFactory;
        readonly ISortOrder jobSortOrder;
        readonly ISortOrder jobrouteSortOrder;
        readonly ISortOrder jobmatlSortOrder;


        public Rpt_EstimateJobCostDetailCRUD(IApplicationDB appDB,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ITransactionFactory transactionFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IGetIsolationLevel iGetIsolationLevel,
            IExistsChecker existsChecker,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IRecordStreamFactory recordStreamFactory,
            ISortOrderFactory sortOrderFactory,
            IBookmarkFactory bookmarkFactory,
            IQueryLanguage queryLanguage,
            ICache mgSessionVariableBasedCache)
        {
            this.appDB = appDB;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.transactionFactory = transactionFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.queryLanguage = queryLanguage;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.recordStreamFactory = recordStreamFactory;
            this.sortOrderFactory = sortOrderFactory;
            this.bookmarkFactory = bookmarkFactory;

            Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
            dicSortOrder.Add("job.job", SortOrderDirection.Ascending);
            dicSortOrder.Add("job.suffix", SortOrderDirection.Ascending);
            this.jobSortOrder = sortOrderFactory.Create(dicSortOrder);

            Dictionary<string, SortOrderDirection> jobrouteDicSortOrder = new Dictionary<string, SortOrderDirection>();
            jobrouteDicSortOrder.Add("J.job", SortOrderDirection.Ascending);
            jobrouteDicSortOrder.Add("J.suffix", SortOrderDirection.Ascending);
            jobrouteDicSortOrder.Add("J.oper_num", SortOrderDirection.Ascending);
            jobrouteDicSortOrder.Add("J.wc", SortOrderDirection.Ascending);
            this.jobrouteSortOrder = sortOrderFactory.Create(jobrouteDicSortOrder);

            Dictionary<string, SortOrderDirection> jobmatlDicSortOrder = new Dictionary<string, SortOrderDirection>();
            jobmatlDicSortOrder.Add("jobmatl.job", SortOrderDirection.Ascending);
            jobmatlDicSortOrder.Add("jobmatl.suffix", SortOrderDirection.Ascending);
            jobmatlDicSortOrder.Add("jobmatl.oper_num", SortOrderDirection.Ascending);
            jobmatlDicSortOrder.Add("jobmatl.sequence", SortOrderDirection.Ascending);
            jobmatlDicSortOrder.Add("jobmatl.item", SortOrderDirection.Ascending);
            jobmatlDicSortOrder.Add("wc.wc", SortOrderDirection.Ascending);
            this.jobmatlSortOrder = sortOrderFactory.Create(jobmatlDicSortOrder);
        }

        public void DeclareAltgenTable()
        {
            this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
        }

        public bool Optional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_EstimateJobCostDetailSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
        }

        public void InsertOptional_Module()
        {
            var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SpName","CAST (NULL AS NVARCHAR)"},
                    {"u0","[om].[ModuleName]"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_EstimateJobCostDetailSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_EstimateJobCostDetailSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
            };

            var optional_module1RequiredColumns = new List<string>() { "SpName" };

            optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

            var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                items: optional_module1LoadResponse.Items);

            this.appDB.Insert(optional_module1InsertRequest);
        }

        public bool Tv_ALTGENForExists()
        {
            return existsChecker.Exists(tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""));
        }

        public (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName)
        {
            StringType _ALTGEN_SpName = DBNull.Value;

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

            int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
            return (ALTGEN_SpName, rowCount);
        }


        public void DeleteTv_ALTGEN(string ALTGEN_SpName)
        {
            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
            /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
            var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"[SpName]","[SpName]"},
                },
                tableName: "#tv_ALTGEN",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);

            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                items: tv_ALTGEN2LoadResponse.Items);
            this.appDB.Delete(tv_ALTGEN2DeleteRequest);
            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
        }

        public void SetIsolationLevel()
        {
            this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("EstimateJobCostDetailReport"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");

            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");

            }
        }

        public (string XDomCurrency, int? rowCount) LoadCurrparms(string XDomCurrency)
        {
            CurrCodeType _XDomCurrency = DBNull.Value;

            var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_XDomCurrency,"currparms.curr_code"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "currparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
            if (currparmsLoadResponse.Items.Count > 0)
            {
                XDomCurrency = _XDomCurrency;
            }

            int rowCount = currparmsLoadResponse.Items.Count;
            return (XDomCurrency, rowCount);
        }

        public (int? CostPricePlaces, string CostPriceFormat, int? CurrencyPlaces, string CurrencyFormat, int? rowCount) LoadCurrency(string XDomCurrency, string CostPriceFormat, int? CostPricePlaces, string CurrencyFormat, int? CurrencyPlaces)
        {
            DecimalPlacesType _CostPricePlaces = DBNull.Value;
            InputMaskType _CostPriceFormat = DBNull.Value;
            DecimalPlacesType _CurrencyPlaces = DBNull.Value;
            InputMaskType _CurrencyFormat = DBNull.Value;

            var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CostPricePlaces,"places_cp"},
                    {_CostPriceFormat,"cst_prc_format"},
                    {_CurrencyPlaces,"places"},
                    {_CurrencyFormat,"amt_format"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "currency",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("currency.curr_code = {0}", XDomCurrency),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var currencyLoadResponse = this.appDB.Load(currencyLoadRequest);
            if (currencyLoadResponse.Items.Count > 0)
            {
                CostPricePlaces = _CostPricePlaces;
                CostPriceFormat = _CostPriceFormat;
                CurrencyPlaces = _CurrencyPlaces;
                CurrencyFormat = _CurrencyFormat;
            }

            int rowCount = currencyLoadResponse.Items.Count;
            return (CostPricePlaces, CostPriceFormat, CurrencyPlaces, CurrencyFormat, rowCount);
        }

        public IRecordStream SelectJob(string ExOpordnumStarting, string ExOpordnumENDing, string ExOptgoOrdType, int? ExOpsuffixStarting, int? ExOpsuffixENDing, string ExOptdfEjobStat, string ExOpjobStarting, string ExOpjobENDing, string ExOpItemStarting, string ExOpItemENDing, string ExOpCustStarting, string ExOpCustENDing, DateTime? ExOpJobDateStarting, DateTime? ExOpJobDateENDing, string StartProspect, string EndProspect, int? AllExOpjob, int? AllExOpsuffix, int? AllExOpItem, int? AllExOpJobDate, int? AllExOpCust, int? AllExOpordnum, int? AllProspect, int pageSize, LoadType loadType)
        {
            var CURJOBLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"job.RowPointer","job.RowPointer"},
                    {"job.ord_type","job.ord_type"},
                    {"job.ord_num","job.ord_num"},
                    {"job.ord_line","job.ord_line"},
                    {"job.ord_release","job.ord_release"},
                    {"job.job","job.job"},
                    {"job.suffix","job.suffix"},
                    {"job.job_date","job.job_date"},
                    {"job.cust_num","job.cust_num"},
                    {"job.prospect_id","job.prospect_id"},
                    {"job.qty_released","job.qty_released"},
                    {"job.item","job.item"},
                    {"job.stat","job.stat"},
                    {"job.Description","job.Description"},
                    {"job.co_product_mix","job.co_product_mix"},
                    {"job.MO_co_job","job.MO_co_job"},
                    {"job.MO_product_cycle","job.MO_product_cycle"},
                    {"job.MO_qty_per_cycle","job.MO_qty_per_cycle"},
                    {"TRef",@"case when job.ord_num is null then job.ord_type
                                   when job.ord_release = 0 and job.ord_type = 'J' then job.ord_type + ' ' + job.ord_num + '-' + isnull(replicate('0', 4 - LEN(CAST(job.ord_line AS NVARCHAR))) + CAST(job.ord_line AS NVARCHAR), '????')
                                   when job.ord_release = 0 and job.ord_type <> 'S' then job.ord_type + ' ' + job.ord_num + ' ' + CAST(job.ord_line AS NVARCHAR)
	                               when job.ord_release <> 0 and job.ord_type = 'J'  then job.ord_type + ' ' + job.ord_num + '-' + isnull(replicate('0', 4 - LEN(CAST(job.ord_line AS NVARCHAR))) + CAST(job.ord_line AS NVARCHAR), '????') + ' ' + CAST(job.ord_release AS NVARCHAR(4))	 
	                               when job.ord_release <> 0 and job.ord_type in ('O', 'P') then job.ord_type + ' ' + job.ord_num + ' ' + CAST(job.ord_line AS NVARCHAR) + '-' + CAST(job.ord_release AS NVARCHAR(4)) 
                                   when job.ord_release <> 0 and job.ord_type <> 'S' then job.ord_type + ' ' + job.ord_num + ' ' + CAST(job.ord_line AS NVARCHAR) + ' ' + CAST(job.ord_release AS NVARCHAR(4)) 
	                               when job.ord_release <> 0 then job.ord_type + ' ' + job.ord_num + ' ' + CAST(job.ord_release AS NVARCHAR(4)) 
	                               else job.ord_type + ' ' + job.ord_num end"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "job",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("job.type = 'E' AND (job.job BETWEEN {8} AND {14} OR {22} = 1) AND (job.suffix BETWEEN {1} AND {4} OR {15} = 1) AND (job.item BETWEEN {5} AND {10} OR {18} = 1) AND (job.job_date BETWEEN {0} AND {3} OR {11} = 1) AND (isnull(job.cust_num, '') BETWEEN {6} AND {12} OR {19} = 1) AND (isnull(job.ord_num, '') BETWEEN {2} AND {7} OR {16} = 1) AND ((CASE WHEN {13} = ' ' THEN 1 ELSE CASE WHEN job.ord_type = {13} THEN 1 ELSE 0 END END) <> 0) AND CHARINDEX(job.stat, {9}) <> 0 AND (job.prospect_id BETWEEN {17} AND {20} OR {21} = 1)", ExOpJobDateStarting, ExOpsuffixStarting, ExOpordnumStarting, ExOpJobDateENDing, ExOpsuffixENDing, ExOpItemStarting, ExOpCustStarting, ExOpordnumENDing, ExOpjobStarting, ExOptdfEjobStat, ExOpItemENDing, AllExOpJobDate, ExOpCustENDing, ExOptgoOrdType, ExOpjobENDing, AllExOpsuffix, AllExOpordnum, StartProspect, AllExOpItem, AllExOpCust, EndProspect, AllProspect, AllExOpjob),
                orderByClause: collectionLoadRequestFactory.Clause("job.job, job.suffix"));

            return recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache,
                                        collectionLoadRequestFactory, CURJOBLoadRequestForCursor, this.jobSortOrder, SQLPagedRecordStreamBookmarkID.Rpt_EstimateJobCostDetail_Job, pageSize, loadType);
        }

        public IRecordStream SelectJobroute(string ExOpordnumStarting, string ExOpordnumENDing, string ExOptgoOrdType, int? ExOpsuffixStarting, int? ExOpsuffixENDing, string ExOptdfEjobStat, string ExOpjobStarting, string ExOpjobENDing, string ExOpItemStarting, string ExOpItemENDing, string ExOpCustStarting, string ExOpCustENDing, DateTime? ExOpJobDateStarting, DateTime? ExOpJobDateENDing, string StartProspect, string EndProspect, int? AllExOpjob, int? AllExOpsuffix, int? AllExOpItem, int? AllExOpJobDate, int? AllExOpCust, int? AllExOpordnum, int? AllProspect, int pageSize, LoadType loadType)
        {
            var CURJOBROUTELoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"J.RowPointer","J.RowPointer"},
                    {"J.qty_scrapped","J.qty_scrapped"},
                    {"J.oper_num","J.oper_num"},
                    {"J.wc","J.wc"},
                    {"wc.overhead","wc.overhead"},
                    {"J.MO_shared","J.MO_shared"},
                    {"J.job","J.job"},
                    {"J.suffix","J.suffix"},
                    {"jrt_sch.start_date","jrt_sch.start_date"},
                    {"jrt_sch.END_date","jrt_sch.END_date"},
                    {"J.efficiency","J.efficiency"},
                    {"J.run_rate_lbr","J.run_rate_lbr"},
                    {"J.setup_rate","J.setup_rate"},
                    {"J.fixovhd_rate","J.fixovhd_rate"},
                    {"J.varovhd_rate","J.varovhd_rate"},
                    {"J.fovhd_rate_mch","J.fovhd_rate_mch"},
                    {"J.vovhd_rate_mch","J.vovhd_rate_mch"},
                    {"jrt_sch.run_ticks_lbr","jrt_sch.run_ticks_lbr"},
                    {"jrt_sch.setup_ticks","jrt_sch.setup_ticks"},
                    {"jrt_sch.run_ticks_mch","jrt_sch.run_ticks_mch"},
                    {"wc.outside","wc.outside"},
                    {"wc.wc","wc.wc"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "jobroute",
                fromClause: collectionLoadRequestFactory.Clause(" AS J LEFT OUTER JOIN WC WITH (READUNCOMMITTED) ON J.WC = WC.WC inner join job on J.job = job.job and J.suffix = job.suffix INNER JOIN jrt_sch ON J.job = jrt_sch.Job AND J.suffix = jrt_sch.Suffix AND J.oper_num = jrt_sch.Oper_Num"),
                whereClause: collectionLoadRequestFactory.Clause("job.type = 'E' AND (job.job BETWEEN {8} AND {14} OR {22} = 1) AND (job.suffix BETWEEN {1} AND {4} OR {15} = 1) AND (job.item BETWEEN {5} AND {10} OR {18} = 1) AND (job.job_date BETWEEN {0} AND {3} OR {11} = 1) AND (isnull(job.cust_num, '') BETWEEN {6} AND {12} OR {19} = 1) AND (isnull(job.ord_num, '') BETWEEN {2} AND {7} OR {16} = 1) AND ((CASE WHEN {13} = ' ' THEN 1 ELSE CASE WHEN job.ord_type = {13} THEN 1 ELSE 0 END END) <> 0) AND CHARINDEX(job.stat, {9}) <> 0 AND (job.prospect_id BETWEEN {17} AND {20} OR {21} = 1)", ExOpJobDateStarting, ExOpsuffixStarting, ExOpordnumStarting, ExOpJobDateENDing, ExOpsuffixENDing, ExOpItemStarting, ExOpCustStarting, ExOpordnumENDing, ExOpjobStarting, ExOptdfEjobStat, ExOpItemENDing, AllExOpJobDate, ExOpCustENDing, ExOptgoOrdType, ExOpjobENDing, AllExOpsuffix, AllExOpordnum, StartProspect, AllExOpItem, AllExOpCust, EndProspect, AllProspect, AllExOpjob),
                orderByClause: collectionLoadRequestFactory.Clause("J.job, J.suffix, J.oper_num, J.wc"));

            return recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache,
                                        collectionLoadRequestFactory, CURJOBROUTELoadRequestForCursor, this.jobrouteSortOrder, SQLPagedRecordStreamBookmarkID.Rpt_EstimateJobCostDetail_Jobroute, pageSize, loadType);
        }

        public IRecordStream SelectJobmatl(string ExOpordnumStarting, string ExOpordnumENDing, string ExOptgoOrdType, int? ExOpsuffixStarting, int? ExOpsuffixENDing, string ExOptdfEjobStat, string ExOpjobStarting, string ExOpjobENDing, string ExOpItemStarting, string ExOpItemENDing, string ExOpCustStarting, string ExOpCustENDing, DateTime? ExOpJobDateStarting, DateTime? ExOpJobDateENDing, string StartProspect, string EndProspect, int? AllExOpjob, int? AllExOpsuffix, int? AllExOpItem, int? AllExOpJobDate, int? AllExOpCust, int? AllExOpordnum, int? AllProspect, int pageSize, LoadType loadType)
        {
            var MaterialjobmatlLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"jobmatl.RowPointer","jobmatl.RowPointer"},
                    {"jobmatl.item","jobmatl.item"},
                    {"jobmatl.fmatlovhd","jobmatl.fmatlovhd"},
                    {"jobmatl.vmatlovhd","jobmatl.vmatlovhd"},
                    {"jobmatl.units","jobmatl.units"},
                    {"jobmatl.matl_qty","jobmatl.matl_qty"},
                    {"jobmatl.scrap_fact","jobmatl.scrap_fact"},
                    {"jobmatl.cost","jobmatl.cost"},
                    {"jobmatl.ref_type","jobmatl.ref_type"},
                    {"jobmatl.ref_num","jobmatl.ref_num"},
                    {"jobmatl.ref_line_suf","jobmatl.ref_line_suf"},
                    {"jobmatl.ref_release","jobmatl.ref_release"},
                    {"jobmatl.matl_type","jobmatl.matl_type"},
                    {"jobmatl.oper_num","jobmatl.oper_num"},
                    {"jrt_sch.start_date","jrt_sch.start_date"},
                    {"jrt_sch.END_date","jrt_sch.END_date"},
                    {"item.RowPointer","item.RowPointer"},
                    {"item.description","item.description"},
                    {"jrt_sch.job","jrt_sch.job"},
                    {"jrt_sch.suffix","jrt_sch.suffix"},
                    {"jrt_sch.oper_num","jrt_sch.oper_num"},
                    {"SubTRef",@"case when jobmatl.ref_num is null then jobmatl.ref_type
                                      when jobmatl.ref_release = 0 and jobmatl.ref_type = 'J' then jobmatl.ref_type + ' ' + jobmatl.ref_num + '-' + isnull(replicate('0', 4 - LEN(CAST(jobmatl.ref_line_suf AS NVARCHAR))) + CAST(jobmatl.ref_line_suf AS NVARCHAR), '????')
                                      when jobmatl.ref_release = 0 and jobmatl.ref_type <> 'S' then jobmatl.ref_type + ' ' + jobmatl.ref_num + ' ' + CAST(jobmatl.ref_line_suf AS NVARCHAR)
	                                  when jobmatl.ref_release <> 0 and jobmatl.ref_type = 'J'  then jobmatl.ref_type + ' ' + jobmatl.ref_num + '-' + isnull(replicate('0', 4 - LEN(CAST(jobmatl.ref_line_suf AS NVARCHAR))) + CAST(jobmatl.ref_line_suf AS NVARCHAR), '????') + ' ' + CAST(jobmatl.ref_release AS NVARCHAR(4))	 
	                                  when jobmatl.ref_release <> 0 and jobmatl.ref_type in ('O', 'P') then jobmatl.ref_type + ' ' + jobmatl.ref_num + ' ' + CAST(jobmatl.ref_line_suf AS NVARCHAR) + '-' + CAST(jobmatl.ref_release AS NVARCHAR(4)) 
                                      when jobmatl.ref_release <> 0 and jobmatl.ref_type <> 'S' then jobmatl.ref_type + ' ' + jobmatl.ref_num + ' ' + CAST(jobmatl.ref_line_suf AS NVARCHAR) + ' ' + CAST(jobmatl.ref_release AS NVARCHAR(4)) 
	                                  when jobmatl.ref_release <> 0 then jobmatl.ref_type + ' ' + jobmatl.ref_num + ' ' + CAST(jobmatl.ref_release AS NVARCHAR(4)) 
	                                  else jobmatl.ref_type + ' ' + jobmatl.ref_num end"},
                    {"PlanMatl",$"(cast(case when jobmatl.units='U' then (job.qty_released*jobmatl.matl_qty)/(1.0-jobmatl.scrap_fact) else jobmatl.matl_qty/(1.0-jobmatl.scrap_fact) end as decimal(20,8))*jobmatl.cost)"},
                    {"MTcCprPlanMatlOvhd",$"(cast(case when jobmatl.units='U' then (job.qty_released*jobmatl.matl_qty)/(1.0-jobmatl.scrap_fact) else jobmatl.matl_qty/(1.0-jobmatl.scrap_fact) end as decimal(20,8))*jobmatl.cost) * Case When CHARINDEX( 'M', wc.overhead) > 0 Then (jobmatl.fmatlovhd + jobmatl.vmatlovhd) Else 0 End"},
                    {"jobmatl.job","jobmatl.job"},
                    {"jobmatl.suffix","jobmatl.suffix"},
                    {"wc.wc","wc.wc"},
                    {"jobmatl.sequence","jobmatl.sequence"},
                    {"jobroute.MO_shared","jobroute.MO_shared"},
            },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "jobmatl",
                fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN jrt_sch ON jobmatl.job = jrt_sch.Job
					AND jobmatl.suffix = jrt_sch.suffix
					AND jobmatl.oper_num = jrt_sch.oper_num LEFT OUTER JOIN item ON jobmatl.item = item.Item
                    inner join jobroute on jobmatl.job = jobroute.job and jobmatl.suffix=jobroute.suffix and jobmatl.oper_num=jobroute.oper_num 
                    inner join job on job.job = jobroute.job and job.suffix=jobroute.suffix
                    INNER JOIN WC ON jobroute.WC = WC.WC"),
                whereClause: collectionLoadRequestFactory.Clause("job.type = 'E' AND (job.job BETWEEN {8} AND {14} OR {22} = 1) AND (job.suffix BETWEEN {1} AND {4} OR {15} = 1) AND (job.item BETWEEN {5} AND {10} OR {18} = 1) AND (job.job_date BETWEEN {0} AND {3} OR {11} = 1) AND (isnull(job.cust_num, '') BETWEEN {6} AND {12} OR {19} = 1) AND (isnull(job.ord_num, '') BETWEEN {2} AND {7} OR {16} = 1) AND ((CASE WHEN {13} = ' ' THEN 1 ELSE CASE WHEN job.ord_type = {13} THEN 1 ELSE 0 END END) <> 0) AND CHARINDEX(job.stat, {9}) <> 0 AND (job.prospect_id BETWEEN {17} AND {20} OR {21} = 1)", ExOpJobDateStarting, ExOpsuffixStarting, ExOpordnumStarting, ExOpJobDateENDing, ExOpsuffixENDing, ExOpItemStarting, ExOpCustStarting, ExOpordnumENDing, ExOpjobStarting, ExOptdfEjobStat, ExOpItemENDing, AllExOpJobDate, ExOpCustENDing, ExOptgoOrdType, ExOpjobENDing, AllExOpsuffix, AllExOpordnum, StartProspect, AllExOpItem, AllExOpCust, EndProspect, AllProspect, AllExOpjob),
                orderByClause: collectionLoadRequestFactory.Clause("jobmatl.job, jobmatl.suffix, jobmatl.oper_num, jobmatl.sequence, jobmatl.item, wc.wc"));

            return recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache,
                                        collectionLoadRequestFactory, MaterialjobmatlLoadRequestForCursor, this.jobmatlSortOrder, SQLPagedRecordStreamBookmarkID.Rpt_EstimateJobCostDetail_Jobmatl, pageSize, loadType);
        }

        public ICollectionLoadResponse SelectNontable(
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
            int? MoldingPack = null)
        {
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "Id", Guid.NewGuid()},
                    { "Job", Job},
                    { "JobSuffix", stringUtil.Right(stringUtil.Concat("000", Convert.ToString(JobSuffix)),4)},
                    { "JobDate", JobDate},
                    { "CustNum", CustNum},
                    { "ProspectId", ProspectId},
                    { "QtyReleased", QtyReleased},
                    { "Item", Item},
                    { "Stat", Stat},
                    { "Ref", Ref},
                    { "Des", Des},
                    { "OperNum", OperNum},
                    { "Wc", Wc},
                    { "jrt_schstartdate", jrt_schStartDate},
                    { "jrt_schEND_date", jrt_schEndDate},
                    { "TcCprPlanSetupCost", TcCprPlanSetupCost},
                    { "TcCprPlanRunCost", TcCprPlanRunCost},
                    { "TcCprPlanMatl", TcCprPlanMatl},
                    { "TcCprPlanOvhd", TcCprPlanOvhd},
                    { "TcCprPlanTot", TcCprPlanTot},
                    { "Setup", Setup},
                    { "Run", Run},
                    { "Overhead", Overhead},
                    { "Total", Total},
                    { "Machine", Machine},
                    { "MACHINEOverhead", MACHINEOverhead},
                    { "Type", Type},
                    { "ItemDetail", ItemDetail},
                    { "Per", Per},
                    { "Cost", Cost},
                    { "Ovhd", Ovhd},
                    { "TRef", TRef},
                    { "ItemDesc", ItemDesc},
                    { "MJobmatlMatlType", MJobmatlMatlType},
                    { "MJobmatlItem", MJobmatlItem},
                    { "MJobmatlUnits", MJobmatlUnits},
                    { "MTcCprPlanMatl", MTcCprPlanMatl},
                    { "MTcCprPlanMatlOvhd", MTcCprPlanMatlOvhd},
                    { "MTRef", MTRef},
                    { "MItemDescription", MItemDescription},
                    { "LTcCprPlanSetupCost", LTcCprPlanSetupCost},
                    { "LTcCprPlanRunCost", LTcCprPlanRunCost},
                    { "LTcCprPlanLbrOvhd", LTcCprPlanLbrOvhd},
                    { "LTcCprPlanLbrTot", LTcCprPlanLbrTot},
                    { "Ljrt_schstartdate", Ljrt_schStartDate},
                    { "Ljrt_schENDdate", Ljrt_schEndDate},
                    { "ETPlanMchHrs", ETPlanMchHrs},
                    { "ETcCprPlanMchOvhd", ETcCprPlanMchOvhd},
                    { "Ejrt_schstartdate", Ejrt_schStartDate},
                    { "Ejrt_schENDdate", Ejrt_schEndDate},
                    { "CostPriceFormat", CostPriceFormat},
                    { "CostPricePlaces", CostPricePlaces},
                    { "CurrencyFormat", CurrencyFormat},
                    { "CurrencyPlaces", CurrencyPlaces},
                    { "co_product_mix", co_product_mix},
                    { "MO_co_job", MO_co_job},
                    { "MO_product_cycle", MO_product_cycle},
                    { "MO_qty_per_cycle", MO_qty_per_cycle},
                    { "MO_shared", MO_shared},
                    { "MoldingPack", MoldingPack},
            });

            return this.appDB.Load(nonTableLoadRequest);
        }

        public void InsertJobBookmark(IRecordReadOnly jobItem)
        {
            if(jobItem != null)
                mgSessionVariableBasedCache.Insert(Enum.GetName(typeof(SQLPagedRecordStreamBookmarkID), SQLPagedRecordStreamBookmarkID.Rpt_EstimateJobCostDetail_Job), (ICachable)bookmarkFactory.Create(jobItem, jobSortOrder));
        }

        public void InsertJobrouteBookmark(IRecordReadOnly jobrouteItem)
        {
            if (jobrouteItem != null)
                mgSessionVariableBasedCache.Insert(Enum.GetName(typeof(SQLPagedRecordStreamBookmarkID), SQLPagedRecordStreamBookmarkID.Rpt_EstimateJobCostDetail_Jobroute), (ICachable)bookmarkFactory.Create(jobrouteItem, jobrouteSortOrder));
        }

        public void InsertJobmatlBookmark(IRecordReadOnly jobmatlItem)
        {
            if (jobmatlItem != null)
                mgSessionVariableBasedCache.Insert(Enum.GetName(typeof(SQLPagedRecordStreamBookmarkID), SQLPagedRecordStreamBookmarkID.Rpt_EstimateJobCostDetail_Jobmatl), (ICachable)bookmarkFactory.Create(jobmatlItem, jobmatlSortOrder));
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_Rpt_EstimateJobCostDetailSp(
            string AltExtGenSp,
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
            CoProjTrnNumType _ExOpordnumStarting = ExOpordnumStarting;
            CoProjTrnNumType _ExOpordnumENDing = ExOpordnumENDing;
            RefTypeIKOTType _ExOptgoOrdType = ExOptgoOrdType;
            SuffixType _ExOpsuffixStarting = ExOpsuffixStarting;
            SuffixType _ExOpsuffixENDing = ExOpsuffixENDing;
            InfobarType _ExOptdfEjobStat = ExOptdfEjobStat;
            InfobarType _ExOptacCostComponent = ExOptacCostComponent;
            JobType _ExOpjobStarting = ExOpjobStarting;
            JobType _ExOpjobENDing = ExOpjobENDing;
            ItemType _ExOpItemStarting = ExOpItemStarting;
            ItemType _ExOpItemENDing = ExOpItemENDing;
            CustNumType _ExOpCustStarting = ExOpCustStarting;
            CustNumType _ExOpCustENDing = ExOpCustENDing;
            DateType _ExOpJobDateStarting = ExOpJobDateStarting;
            DateType _ExOpJobDateENDing = ExOpJobDateENDing;
            DateOffsetType _DateStartingOffset = DateStartingOffset;
            DateOffsetType _DateENDingOffset = DateENDingOffset;
            ListYesNoType _DisplayHeader = DisplayHeader;
            ProspectIDType _StartProspect = StartProspect;
            ProspectIDType _EndProspect = EndProspect;
            SiteType _pSite = pSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "ExOpordnumStarting", _ExOpordnumStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOpordnumENDing", _ExOpordnumENDing, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptgoOrdType", _ExOptgoOrdType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOpsuffixStarting", _ExOpsuffixStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOpsuffixENDing", _ExOpsuffixENDing, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptdfEjobStat", _ExOptdfEjobStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptacCostComponent", _ExOptacCostComponent, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOpjobStarting", _ExOpjobStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOpjobENDing", _ExOpjobENDing, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOpItemStarting", _ExOpItemStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOpItemENDing", _ExOpItemENDing, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOpCustStarting", _ExOpCustStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOpCustENDing", _ExOpCustENDing, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOpJobDateStarting", _ExOpJobDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOpJobDateENDing", _ExOpJobDateENDing, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DateStartingOffset", _DateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DateENDingOffset", _DateENDingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartProspect", _StartProspect, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndProspect", _EndProspect, ParameterDirection.Input);
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
