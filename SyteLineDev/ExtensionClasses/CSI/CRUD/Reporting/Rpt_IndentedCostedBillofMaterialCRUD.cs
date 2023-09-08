//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IndentedCostedBillofMaterialCRUD.cs

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

namespace CSI.Reporting
{
    public class Rpt_IndentedCostedBillofMaterialCRUD : IRpt_IndentedCostedBillofMaterialCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
        readonly ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ITransactionFactory transactionFactory;

        public Rpt_IndentedCostedBillofMaterialCRUD(IApplicationDB appDB,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
            ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory,
            IGetIsolationLevel iGetIsolationLevel,
            ISQLValueComparerUtil sQLUtil,
            ITransactionFactory transactionFactory
            )
        {
            this.appDB = appDB;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
            this.collectionNonTriggerDeleteRequestFactory = collectionNonTriggerDeleteRequestFactory;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.sQLUtil = sQLUtil;
            this.transactionFactory = transactionFactory;


        }

        public bool ForExists_Optional_Module()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_IndentedCostedBillofMaterialSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
        }

        public void DeclareTable_ALTGEN()
        {
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
        }

        public void InsertOptional_Module1()
        {
            var optional_module1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#tv_ALTGEN",
                targetColumns: new List<string>()
                {
                    { "SpName" },
                },
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    { "SpName" , collectionNonTriggerInsertRequestFactory.Clause("QUOTENAME(OBJECT_NAME(@@PROCID) + CHAR(95) + om.ModuleName)")},
                },
                fromClause: collectionNonTriggerInsertRequestFactory.Clause("optional_module om"),
                whereClause: collectionNonTriggerInsertRequestFactory.Clause("ISNULL(om.is_enabled, 0) = 1 AND OBJECT_ID(QUOTENAME(OBJECT_NAME(@@PROCID) + CHAR(95) + om.ModuleName)) IS NOT NULL"),
                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                );

            this.appDB.InsertWithoutTrigger(optional_module1NonTriggerInsertRequest);
        }

        public bool ForExists_Tv_ALTGEN()
        {
            return existsChecker.Exists(tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""));
        }

        public (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN1(string ALTGEN_SpName)
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

        public void DeleteTv_ALTGEN2(string ALTGEN_SpName)
        {
            var tv_ALTGEN2NonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                tableName: "#tv_ALTGEN",
                fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
                whereClause: collectionNonTriggerDeleteRequestFactory.Clause("SpName = {0}", ALTGEN_SpName)
            );

            this.appDB.DeleteWithoutTrigger(tv_ALTGEN2NonTriggerDeleteRequest);
        }

        public void SetTransaction()
        {

            this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("IndentedCostedBillOfMaterialReport"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            }
        }

        public (int? CostItemAtWhse, string DefaultWhse, int? rowCount) LoadDbo_Invparms(Guid? RptSessionID, string pSite, int? CostItemAtWhse, string DefaultWhse)
        {
            ListYesNoType _CostItemAtWhse = DBNull.Value;
            WhseType _DefaultWhse = DBNull.Value;

            var dbo_invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CostItemAtWhse,"ISNULL(invparms.cost_item_at_whse, 0)"},
                    {_DefaultWhse,"def_whse"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "dbo.invparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var dbo_invparmsLoadResponse = this.appDB.Load(dbo_invparmsLoadRequest);
            if (dbo_invparmsLoadResponse.Items.Count > 0)
            {
                CostItemAtWhse = _CostItemAtWhse;
                DefaultWhse = _DefaultWhse;
            }

            int rowCount = dbo_invparmsLoadResponse.Items.Count;
            return (CostItemAtWhse, DefaultWhse, rowCount);
        }
        public void DeclareTable_loop()
        {
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @loop TABLE (
				    seq           INT              IDENTITY,
				    level         INT             ,
				    item          NVARCHAR (30)   ,
				    job           NVARCHAR (30)   ,
				    suffix        INT             ,
				    matl_qty_conv FLOAT           ,
				    u_m           NVARCHAR (3)    ,
				    matl_type     NCHAR (1)       ,
				    units         NCHAR (1)       ,
				    description   NVARCHAR (100)  ,
				    cost          DECIMAL (25, 10));
				SELECT * into #tv_loop from @loop
				ALTER TABLE #tv_loop ADD PRIMARY KEY (seq)");
        }

        public void DeclareTable_loop2()
        {
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @loop2 TABLE (
				    seq           INT              IDENTITY,
				    level         INT             ,
				    item          NVARCHAR (30)   ,
				    job           NVARCHAR (30)   ,
				    suffix        INT             ,
				    matl_qty_conv DECIMAL (25, 10),
				    u_m           NVARCHAR (3)    ,
				    matl_type     NCHAR (1)       ,
				    units         NCHAR (1)       ,
				    description   NVARCHAR (100)  ,
				    cost          DECIMAL (25, 10));
				SELECT * into #tv_loop2 from @loop2
				ALTER TABLE #tv_loop2 ADD PRIMARY KEY (seq)");
        }


        public (int? PlacesQtyPer, string QtyPerFormat, int? rowCount) LoadInvparms(string QtyPerFormat, int? PlacesQtyPer)
        {
            DecimalPlacesType _PlacesQtyPer = DBNull.Value;
            InputMaskType _QtyPerFormat = DBNull.Value;

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

            int rowCount = invparmsLoadResponse.Items.Count;
            return (PlacesQtyPer, QtyPerFormat, rowCount);
        }

        public (string CstPrcFormat, int? PlacesCp, int? rowCount) LoadCurrency(string CstPrcFormat, int? PlacesCp)
        {
            InputMaskType _CstPrcFormat = DBNull.Value;
            DecimalPlacesType _PlacesCp = DBNull.Value;

            var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CstPrcFormat,"cst_prc_format"},
                    {_PlacesCp,"places_cp"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "currency",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("curr_code = (SELECT curr_code FROM currparms)"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var currencyLoadResponse = this.appDB.Load(currencyLoadRequest);
            if (currencyLoadResponse.Items.Count > 0)
            {
                CstPrcFormat = _CstPrcFormat;
                PlacesCp = _PlacesCp;
            }

            int rowCount = currencyLoadResponse.Items.Count;
            return (CstPrcFormat, PlacesCp, rowCount);
        }

        public ICollectionLoadRequest SelectItem(string ItemStarting, string ItemEnding, string ProCodeStarting, string ProCodeEnding, string AlternateIDStarting, string AlternateIDEnding, string MaterialType, string Source, string ABCCode, int? PrintAlternate, int? Stocked2, string DefaultWhse)
        {
            var itemCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"item.item","item.item"},
                    {"item.job","item.job"},
                    {"item.description","item.description"},
                    {"item.p_m_t_code","item.p_m_t_code"},
                    {"item.suffix","item.suffix"},
                    {"item.lot_size","item.lot_size"},
                    {"matl","itemwhse.comp_matl + itemwhse.comp_fixture + itemwhse.comp_tool + itemwhse.comp_other "},
                    {"labor","itemwhse.comp_setup + itemwhse.comp_run"},
                    {"ovhd","itemwhse.comp_fixed + itemwhse.comp_var"},
                    {"itemwhse.comp_outside","itemwhse.comp_outside"},
                    {"job.MO_bom_alternate_id","job.MO_bom_alternate_id"},
                    {"job.suffix","job.suffix"},
                    {"itemwhse.whse","itemwhse.whse"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "item",
                fromClause: collectionLoadRequestFactory.Clause(@" inner join itemwhse on item.item = itemwhse.item
					and itemwhse.whse = {0} left outer join job on job.job = item.job", DefaultWhse),
                whereClause: collectionLoadRequestFactory.Clause("(item.item BETWEEN {5} AND {7}) AND (product_code BETWEEN {2} AND {4}) AND CHARINDEX(matl_type, {6}) > 0 AND CHARINDEX(p_m_t_code, {10}) > 0 AND (stocked = {8} OR ISNULL({8}, -1) = -1) AND CHARINDEX(abc_code, {9}) > 0 AND (({3} = 1 AND job.MO_bom_alternate_id BETWEEN {0} AND {1}) OR job.suffix = 0 OR job.suffix IS NULL)", AlternateIDStarting, AlternateIDEnding, ProCodeStarting, PrintAlternate, ProCodeEnding, ItemStarting, MaterialType, ItemEnding, Stocked2, ABCCode, Source),
                orderByClause: collectionLoadRequestFactory.Clause(" job.MO_bom_alternate_id,item.item, itemwhse.whse, item.job,job.suffix "));

            return itemCursorLoadRequestForCursor;

        }

        public ICollectionLoadRequest SelectItem1(string ItemStarting, string ItemEnding, string ProCodeStarting, string ProCodeEnding, string AlternateIDStarting, string AlternateIDEnding, string MaterialType, string Source, string ABCCode, int? PrintAlternate, int? Stocked2)
        {
            var itemCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"item.item","item.item"},
                        {"item.job","item.job"},
                        {"item.description","item.description"},
                        {"item.p_m_t_code","item.p_m_t_code"},
                        {"item.suffix","item.suffix"},
                        {"item.lot_size","item.lot_size"},
                        {"matl","comp_matl + comp_fixture + comp_tool + comp_other"},
                        {"labor","comp_setup + comp_run"},
                        {"ovhd","comp_fixed + comp_var"},
                        {"comp_outside","item.comp_outside"},
                        {"job.MO_bom_alternate_id","job.MO_bom_alternate_id"},
                        {"job.suffix","job.suffix"},
                    },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "item",
                fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN job ON job.job = item.job"),
                whereClause: collectionLoadRequestFactory.Clause("(item.item BETWEEN {5} AND {7}) AND (product_code BETWEEN {2} AND {4}) AND CHARINDEX(matl_type, {6}) > 0 AND CHARINDEX(p_m_t_code, {10}) > 0 AND (stocked = {8} OR ISNULL({8}, -1) = -1) AND CHARINDEX(abc_code, {9}) > 0 AND (({3} = 1 AND job.MO_bom_alternate_id BETWEEN {0} AND {1}) OR job.suffix = 0 OR job.suffix IS NULL)", AlternateIDStarting, AlternateIDEnding, ProCodeStarting, PrintAlternate, ProCodeEnding, ItemStarting, MaterialType, ItemEnding, Stocked2, ABCCode, Source),
                orderByClause: collectionLoadRequestFactory.Clause("job.MO_bom_alternate_id,item.item, item.job,job.suffix"));

            return itemCursorLoadRequestForCursor;
        }
        public bool ForExists_Jobmatl(string item)
        {
            return existsChecker.Exists(tableName: "jobmatl",
                fromClause: collectionLoadRequestFactory.Clause(@" AS jm INNER JOIN job AS j ON j.job = jm.job
						AND j.suffix = jm.suffix"),
                whereClause: collectionLoadRequestFactory.Clause("jm.item = {0} AND j.type = 'S'", item));
        }

        public ICollectionLoadResponse SelectNontable(string Level, string tItem, string tpmt, decimal? tQty, string tum, string tunit, decimal? tLot, string tType, decimal? tMatl, decimal? tOvhd, string tDesc, decimal? tLabor, decimal? tOuts, string QtyPerFormat, int? PlacesQtyPer, string CstPrcFormat, int? PlacesCp, string bom_alternate_id, int? LevelItemCount)
        {
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                {
                        { "tLevel", Level},
                        { "tItem", tItem},
                        { "tpmt", tpmt},
                        { "tQty", tQty},
                        { "tum", tum},
                        { "tunit", tunit},
                        { "tLot", tLot},
                        { "tType", tType},
                        { "tMatl", tMatl},
                        { "tOvhd", tOvhd},
                        { "tDesc", tDesc},
                        { "tLabor", tLabor},
                        { "tOuts", tOuts},
                        { "QtyPerFormat", QtyPerFormat},
                        { "PlacesQtyPer", PlacesQtyPer},
                        { "CstPrcFormat", CstPrcFormat},
                        { "PlacesCp", PlacesCp},
                        { "bom_alternate_id", bom_alternate_id},
                        { "sequence", 0},
                        { "LevelItemCount", LevelItemCount},
                });

            return this.appDB.Load(nonTableLoadRequest);
        }

        public void DeleteTv_Loop()
        {
            var tv_loopNonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                tableName: "#tv_loop",
                fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
                whereClause: collectionNonTriggerDeleteRequestFactory.Clause("")
            );

            this.appDB.DeleteWithoutTrigger(tv_loopNonTriggerDeleteRequest);
        }

        public void InsertLoop(int? Level3, DateTime? EffDate, string tJob, int? job_suffix)
        {
            var optional_module1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#tv_loop",
                targetColumns: new List<string>()
                {
                        { "level" },
                        { "item" },
                        { "job" },
                        { "suffix" },
                        { "matl_qty_conv" },
                        { "u_m" },
                        { "matl_type" },
                        { "units" },
                        { "description" },
                        { "cost" },
                },
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    { "level" , collectionNonTriggerInsertRequestFactory.Clause($"{variableUtil.GetQuotedValue<int?>(Level3)}")},
                    { "item" , collectionNonTriggerInsertRequestFactory.Clause("jm.item")},
                    { "job" , collectionNonTriggerInsertRequestFactory.Clause("jm.job")},
                    { "suffix" , collectionNonTriggerInsertRequestFactory.Clause("jm.suffix")},
                    { "matl_qty_conv" , collectionNonTriggerInsertRequestFactory.Clause("jm.matl_qty_conv")},
                    { "u_m" , collectionNonTriggerInsertRequestFactory.Clause("jm.u_m")},
                    { "matl_type" , collectionNonTriggerInsertRequestFactory.Clause("jm.matl_type")},
                    { "units" , collectionNonTriggerInsertRequestFactory.Clause("jm.units")},
                    { "description" , collectionNonTriggerInsertRequestFactory.Clause("jm.description")},
                    { "cost" , collectionNonTriggerInsertRequestFactory.Clause("jm.cost_conv")},
                },
                fromClause: collectionNonTriggerInsertRequestFactory.Clause("jobmatl jm INNER JOIN jobroute jr ON jr.job = jm.job AND jr.suffix = jm.suffix AND jr.oper_num = jm.oper_num INNER JOIN job j ON j.job = jr.job AND j.suffix = jr.suffix"),
                whereClause: collectionNonTriggerInsertRequestFactory.Clause("jm.job = {2} AND jm.alt_group_rank = 0 AND jm.suffix = {0} AND (jm.effect_date <= {1} OR jm.effect_date IS NULL) AND (jm.obs_date > {1} OR jm.obs_date IS NULL) AND (jr.effect_date <= {1} OR jr.effect_date IS NULL) AND (jr.obs_date > {1} OR jr.obs_date IS NULL) AND j.type = 'S'", job_suffix, EffDate, tJob),
                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("jm.bom_seq, jm.oper_num, jm.sequence")
                );

            this.appDB.InsertWithoutTrigger(optional_module1NonTriggerInsertRequest);

        }

        public ICollectionLoadResponse SelectTv_Loop1()
        {
            var aCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"level","level"},
                        {"item","item"},
                        {"job","job"},
                        {"suffix","suffix"},
                        {"matl_qty_conv","matl_qty_conv"},
                        {"u_m","u_m"},
                        {"matl_type","matl_type"},
                        {"units","units"},
                        {"description","description"},
                        {"cost","cost"},
                    },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#tv_loop",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(" seq"));

            return this.appDB.Load(aCursorLoadRequestForCursor);
        }

        public void DeleteTv_LoopTwo()
        {
            var Tv_LoopTwoDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                tableName: "#tv_loop2",
                fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
                whereClause: collectionNonTriggerDeleteRequestFactory.Clause("")
            );

            this.appDB.DeleteWithoutTrigger(Tv_LoopTwoDeleteRequest);
        }

        public ICollectionLoadResponse SelectNontable1(int? Level1, string item1, string job1, int? suffix1, decimal? matlqtyconv1, string um1, string matltype1, string units1, string description1, decimal? cost1)
        {
            var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                {
                        { "level", Level1},
                        { "item", item1},
                        { "job", job1},
                        { "suffix", suffix1},
                        { "matl_qty_conv", matlqtyconv1},
                        { "u_m", um1},
                        { "matl_type", matltype1},
                        { "units", units1},
                        { "description", description1},
                        { "cost", cost1},
                });

            return this.appDB.Load(nonTable1LoadRequest);
        }
        public void InsertNontable1(ICollectionLoadResponse nonTable1LoadResponse)
        {
            var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_loop2",
                items: nonTable1LoadResponse.Items);

            this.appDB.Insert(nonTable1InsertRequest);
        }

        public ICollectionLoadResponse SelectJobmatl1(DateTime? EffDate, string item1)
        {
            var jobmatl1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"level","CAST (NULL AS INT)"},
                        {"item","jobmatl.item"},
                        {"job","jobmatl.job"},
                        {"suffix","jobmatl.suffix"},
                        {"matl_qty_conv","jobmatl.matl_qty_conv"},
                        {"u_m","jobmatl.u_m"},
                        {"matl_type","jobmatl.matl_type"},
                        {"units","jobmatl.units"},
                        {"description","jobmatl.description"},
                        {"cost","jobmatl.cost_conv"},
                    },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "jobmatl",
                fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN jobroute AS jr ON jr.job = jobmatl.job
						AND jr.suffix = jobmatl.suffix
						AND jr.oper_num = jobmatl.oper_num"),
                whereClause: collectionLoadRequestFactory.Clause("EXISTS (SELECT 1 FROM item WHERE item.item = {1} AND item.job = jobmatl.job AND jobmatl.suffix = item.suffix AND jobmatl.alt_group_rank = 0 AND (jobmatl.effect_date <= {0} OR jobmatl.effect_date IS NULL) AND (jobmatl.obs_date > {0} OR jobmatl.obs_date IS NULL) AND (jr.effect_date <= {0} OR jr.effect_date IS NULL) AND (jr.obs_date > {0} OR jr.obs_date IS NULL))", EffDate, item1),
                orderByClause: collectionLoadRequestFactory.Clause(" bom_seq, jobmatl.oper_num, sequence"));
            return this.appDB.Load(jobmatl1LoadRequest);
        }

        public void InsertJobmatl1(ICollectionLoadResponse jobmatl1LoadResponse)
        {
            var jobmatl1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_loop2",
                items: jobmatl1LoadResponse.Items);

            this.appDB.Insert(jobmatl1InsertRequest);
        }

        public void DeleteTv_Loop2()
        {
            var tv_loopNonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                tableName: "#tv_loop",
                fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
                whereClause: collectionNonTriggerDeleteRequestFactory.Clause("")
            );

            this.appDB.DeleteWithoutTrigger(tv_loopNonTriggerDeleteRequest);
        }

        public void InsertLoop1()
        {
            var optional_module1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                targetTableName: "#tv_loop",
                targetColumns: new List<string>()
                {
                    {"level"},
                    {"item" },
                    {"job" },
                    {"suffix" },
                    {"matl_qty_conv" },
                    {"u_m" },
                    {"matl_type" },
                    {"units" },
                    {"description" },
                    {"cost" },
                },
                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    {"level" , collectionNonTriggerInsertRequestFactory.Clause("level")},
                    {"item", collectionNonTriggerInsertRequestFactory.Clause("item")},
                    {"job", collectionNonTriggerInsertRequestFactory.Clause("job")},
                    {"suffix",collectionNonTriggerInsertRequestFactory.Clause("suffix")},
                    {"matl_qty_conv", collectionNonTriggerInsertRequestFactory.Clause("matl_qty_conv")},
                    {"u_m", collectionNonTriggerInsertRequestFactory.Clause("u_m")},
                    {"matl_type", collectionNonTriggerInsertRequestFactory.Clause("matl_type")},
                    {"units", collectionNonTriggerInsertRequestFactory.Clause("units")},
                    {"description", collectionNonTriggerInsertRequestFactory.Clause("description")},
                    {"cost", collectionNonTriggerInsertRequestFactory.Clause("cost")},

                },
                fromClause: collectionNonTriggerInsertRequestFactory.Clause("#tv_loop2"),
                whereClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("seq")
            );

            this.appDB.InsertWithoutTrigger(optional_module1NonTriggerInsertRequest);
        }

        public ICollectionLoadResponse SelectTv_Loop3()
        {
            var jobmatlCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"jm.level","jm.level"},
                        {"jm.item","jm.item"},
                        {"jm.matl_qty_conv","jm.matl_qty_conv"},
                        {"jm.u_m","jm.u_m"},
                        {"jm.matl_type","jm.matl_type"},
                        {"jm.units","jm.units"},
                        {"jm.description","jm.description"},
                        {"jm.cost","jm.cost"},
                    },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#tv_loop",
                fromClause: collectionLoadRequestFactory.Clause(" jm"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(" seq"));

            return this.appDB.Load(jobmatlCursorLoadRequestForCursor);
        }
        public bool ForExists_Item2(string tItem)
        {
            return existsChecker.Exists(tableName: "item",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("item.item = {0}", tItem));
        }

        public (string tJob,
            string tDesc,
            string tpmt,
            int? tSuff,
            decimal? tLot,
            decimal? tMatl,
            decimal? tLabor,
            decimal? tOvhd,
            decimal? tOuts,
            string um, int? rowCount)
        LoadItem3(string tItem,
            string um,
            string tpmt,
            decimal? tLot,
            decimal? tMatl,
            decimal? tOvhd,
            string tDesc,
            decimal? tLabor,
            decimal? tOuts,
            string tJob,
            int? tSuff,
            string DefaultWhse)
        {
            JobType _tJob = DBNull.Value;
            StringType _tDesc = DBNull.Value;
            PMTCodeType _tpmt = DBNull.Value;
            SuffixType _tSuff = DBNull.Value;
            QtyPerType _tLot = DBNull.Value;
            AmtTotType _tMatl = DBNull.Value;
            AmtTotType _tLabor = DBNull.Value;
            AmtTotType _tOvhd = DBNull.Value;
            AmtTotType _tOuts = DBNull.Value;
            UMType _um = DBNull.Value;

            var item3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_tJob,"item.job"},
                        {_tDesc,"item.description"},
                        {_tpmt,"p_m_t_Code"},
                        {_tSuff,"item.suffix"},
                        {_tLot,"lot_size"},
                        {_tMatl,"itemwhse.comp_matl + itemwhse.comp_fixture + itemwhse.comp_tool + itemwhse.comp_other"},
                        {_tLabor,"itemwhse.comp_setup + itemwhse.comp_run"},
                        {_tOvhd,"itemwhse.comp_fixed + itemwhse.comp_var"},
                        {_tOuts,"itemwhse.comp_outside"},
                        {_um,"u_m"},
                    },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "item",
                fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN itemwhse ON item.item = itemwhse.item
						AND itemwhse.whse = {0}", DefaultWhse),
                whereClause: collectionLoadRequestFactory.Clause("item.item = {0}", tItem),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var item3LoadResponse = this.appDB.Load(item3LoadRequest);
            if (item3LoadResponse.Items.Count > 0)
            {
                tJob = _tJob;
                tDesc = _tDesc;
                tpmt = _tpmt;
                tSuff = _tSuff;
                tLot = _tLot;
                tMatl = _tMatl;
                tLabor = _tLabor;
                tOvhd = _tOvhd;
                tOuts = _tOuts;
                um = _um;
            }

            int rowCount = item3LoadResponse.Items.Count;
            return (tJob, tDesc, tpmt, tSuff, tLot, tMatl, tLabor, tOvhd, tOuts, um, rowCount);
        }

        public (string tJob,
            string tDesc,
            string tpmt,
            int? tSuff,
            decimal? tLot,
            decimal? tMatl,
            decimal? tLabor,
            decimal? tOvhd,
            decimal? tOuts,
            string um, int? rowCount)
        LoadItem4(string tItem,
            string um,
            string tpmt,
            decimal? tLot,
            decimal? tMatl,
            decimal? tOvhd,
            string tDesc,
            decimal? tLabor,
            decimal? tOuts,
            string tJob,
            int? tSuff)
        {
            JobType _tJob = DBNull.Value;
            StringType _tDesc = DBNull.Value;
            PMTCodeType _tpmt = DBNull.Value;
            SuffixType _tSuff = DBNull.Value;
            QtyPerType _tLot = DBNull.Value;
            AmtTotType _tMatl = DBNull.Value;
            AmtTotType _tLabor = DBNull.Value;
            AmtTotType _tOvhd = DBNull.Value;
            AmtTotType _tOuts = DBNull.Value;
            UMType _um = DBNull.Value;

            var item4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_tJob,"item.job"},
                        {_tDesc,"item.description"},
                        {_tpmt,"p_m_t_Code"},
                        {_tSuff,"item.suffix"},
                        {_tLot,"lot_size"},
                        {_tMatl,"comp_matl + comp_fixture + comp_tool + comp_other"},
                        {_tLabor,"comp_setup + comp_run"},
                        {_tOvhd,"comp_fixed + comp_var"},
                        {_tOuts,"comp_outside"},
                        {_um,"u_m"},
                    },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "item",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("item.item = {0}", tItem),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var item4LoadResponse = this.appDB.Load(item4LoadRequest);
            if (item4LoadResponse.Items.Count > 0)
            {
                tJob = _tJob;
                tDesc = _tDesc;
                tpmt = _tpmt;
                tSuff = _tSuff;
                tLot = _tLot;
                tMatl = _tMatl;
                tLabor = _tLabor;
                tOvhd = _tOvhd;
                tOuts = _tOuts;
                um = _um;
            }

            int rowCount = item4LoadResponse.Items.Count;
            return (tJob, tDesc, tpmt, tSuff, tLot, tMatl, tLabor, tOvhd, tOuts, um, rowCount);
        }

        public (decimal? convFactor, int? rowCount) LoadU_M_Conv(string um, string tum, string tItem, decimal? convFactor)
        {
            UMConvFactorType _convFactor = DBNull.Value;

            var u_m_convLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_convFactor,"conv_factor"},
                    },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "u_m_conv",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("from_u_m = {2} AND to_u_m = {1} AND item = {0}", tItem, tum, um),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var u_m_convLoadResponse = this.appDB.Load(u_m_convLoadRequest);
            if (u_m_convLoadResponse.Items.Count > 0)
            {
                convFactor = _convFactor;
            }

            int rowCount = u_m_convLoadResponse.Items.Count;
            return (convFactor, rowCount);
        }

        public (decimal? convFactor, int? rowCount) LoadU_M_Conv1(string um, string tum, string tItem, decimal? convFactor)
        {
            UMConvFactorType _convFactor = DBNull.Value;

            var u_m_conv1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_convFactor,"1.0 / conv_factor"},
                    },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "u_m_conv",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("from_u_m = {1} AND to_u_m = {2} AND item = {0}", tItem, tum, um),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var u_m_conv1LoadResponse = this.appDB.Load(u_m_conv1LoadRequest);
            if (u_m_conv1LoadResponse.Items.Count > 0)
            {
                convFactor = _convFactor;
            }

            int rowCount = u_m_conv1LoadResponse.Items.Count;
            return (convFactor, rowCount);
        }

        public (decimal? convFactor, int? rowCount) LoadU_M_Conv2(string um, string tum, decimal? convFactor)
        {
            UMConvFactorType _convFactor = DBNull.Value;

            var u_m_conv2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_convFactor,"conv_factor"},
                    },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "u_m_conv",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("from_u_m = {1} AND to_u_m = {0} AND type = 'G'", tum, um),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var u_m_conv2LoadResponse = this.appDB.Load(u_m_conv2LoadRequest);
            if (u_m_conv2LoadResponse.Items.Count > 0)
            {
                convFactor = _convFactor;
            }

            int rowCount = u_m_conv2LoadResponse.Items.Count;
            return (convFactor, rowCount);
        }

        public (decimal? convFactor, int? rowCount) LoadU_M_Conv3(string um, string tum, decimal? convFactor)
        {
            UMConvFactorType _convFactor = DBNull.Value;

            var u_m_conv3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_convFactor,"1.0 / conv_factor"},
                    },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "u_m_conv",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("from_u_m = {0} AND to_u_m = {1} AND type = 'G'", tum, um),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var u_m_conv3LoadResponse = this.appDB.Load(u_m_conv3LoadRequest);
            if (u_m_conv3LoadResponse.Items.Count > 0)
            {
                convFactor = _convFactor;
            }

            int rowCount = u_m_conv3LoadResponse.Items.Count;
            return (convFactor, rowCount);
        }

        public ICollectionLoadResponse SelectNontable3(string Level, string tItem, string tpmt, decimal? tQty, string tum, string tunit, decimal? tLot, string tType, decimal? tMatl, decimal? tOvhd, string tDesc, decimal? tLabor, decimal? tOuts, string QtyPerFormat, int? PlacesQtyPer, string CstPrcFormat, int? PlacesCp, string bom_alternate_id, int? LevelItemCount)
        {
            var nonTable3LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                {
                        { "tLevel", Level},
                        { "tItem", tItem},
                        { "tpmt", tpmt},
                        { "tQty", tQty},
                        { "tum", tum},
                        { "tunit", tunit},
                        { "tLot", tLot},
                        { "tType", tType},
                        { "tMatl", tMatl},
                        { "tOvhd", tOvhd},
                        { "tDesc", tDesc},
                        { "tLabor", tLabor},
                        { "tOuts", tOuts},
                        { "QtyPerFormat", QtyPerFormat},
                        { "PlacesQtyPer", PlacesQtyPer},
                        { "CstPrcFormat", CstPrcFormat},
                        { "PlacesCp", PlacesCp},
                        { "bom_alternate_id", bom_alternate_id},
                        { "sequence", 0},
                        { "LevelItemCount", LevelItemCount},
                });

            return this.appDB.Load(nonTable3LoadRequest);
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_Rpt_IndentedCostedBillofMaterialSp(
            string AltExtGenSp,
            string ItemStarting = null,
            string ItemEnding = null,
            string ProCodeStarting = null,
            string ProCodeEnding = null,
            string AlternateIDStarting = null,
            string AlternateIDEnding = null,
            string MaterialType = null,
            string Source = null,
            string Stocked = null,
            string ABCCode = null,
            DateTime? EffDate = null,
            string PrBetweenLevel0 = null,
            int? PrLevelZero = null,
            int? DisplayHeader = null,
            int? PrintAlternate = null,
            int? EffDateOffSet = null,
            string pSite = null)
        {
            ItemType _ItemStarting = ItemStarting;
            ItemType _ItemEnding = ItemEnding;
            ProductCodeType _ProCodeStarting = ProCodeStarting;
            ProductCodeType _ProCodeEnding = ProCodeEnding;
            MO_BOMAlternateType _AlternateIDStarting = AlternateIDStarting;
            MO_BOMAlternateType _AlternateIDEnding = AlternateIDEnding;
            StringType _MaterialType = MaterialType;
            StringType _Source = Source;
            StringType _Stocked = Stocked;
            StringType _ABCCode = ABCCode;
            DateType _EffDate = EffDate;
            StringType _PrBetweenLevel0 = PrBetweenLevel0;
            ListYesNoType _PrLevelZero = PrLevelZero;
            ListYesNoType _DisplayHeader = DisplayHeader;
            ListYesNoType _PrintAlternate = PrintAlternate;
            DateOffsetType _EffDateOffSet = EffDateOffSet;
            SiteType _pSite = pSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProCodeStarting", _ProCodeStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProCodeEnding", _ProCodeEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlternateIDStarting", _AlternateIDStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AlternateIDEnding", _AlternateIDEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MaterialType", _MaterialType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Stocked", _Stocked, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ABCCode", _ABCCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EffDate", _EffDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrBetweenLevel0", _PrBetweenLevel0, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrLevelZero", _PrLevelZero, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintAlternate", _PrintAlternate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EffDateOffSet", _EffDateOffSet, ParameterDirection.Input);
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
