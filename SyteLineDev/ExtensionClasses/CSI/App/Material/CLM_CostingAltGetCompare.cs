//PROJECT NAME: Material
//CLASS NAME: CLM_CostingAltGetCompare.cs

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

namespace CSI.Material
{
    public class CLM_CostingAltGetCompare : ICLM_CostingAltGetCompare
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly ISQLCollectionLoad sQLCollectionLoad;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public CLM_CostingAltGetCompare(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            ISQLCollectionLoad sQLCollectionLoad,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.sQLCollectionLoad = sQLCollectionLoad;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_CostingAltGetCompareSp(
            string CostingAlt,
            string CostType = null,
            string Whse = null,
            string CostingAlt2Compare = null,
            string ItemCompare = null,
            string FilterString = null,
            string Infobar = null)
        {

            WhseType _Whse = Whse;
            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {

                ICollectionLoadResponse Data = null;

                StringType _ALTGEN_SpName = DBNull.Value;
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                int? Severity = null;
                ListYesNoType _ItemCostInWhse = DBNull.Value;
                int? ItemCostInWhse = null;
                WhseType _ItemWhse = DBNull.Value;
                string ItemWhse = null;
                string SQLString = null;
                ItemType _Item = DBNull.Value;
                int? JobSuffix = null;
                string SelectionClause = null;
                string FromClause = null;
                string WhereClause = null;
                string AdditionalClause = null;
                string KeyColumns = null;
                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_CostingAltGetCompareSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
                {
                    //BEGIN
                    //this temp table is a table variable in old stored procedure version.
                    this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					[SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");

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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_CostingAltGetCompareSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord


                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_CostingAltGetCompareSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
                        //BEGIN

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

                        var ALTGEN = AltExtGen_CLM_CostingAltGetCompareSp(ALTGEN_SpName,
                            CostingAlt,
                            CostType,
                            Whse,
                            CostingAlt2Compare,
                            ItemCompare,
                            FilterString,
                            Infobar);
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
                        tableName: "#tv_ALTGEN", 
                        loadForChange: true, 
                        lockingType: LockingType.None,
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
                        //END

                    }
                    //END

                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_CostingAltGetCompareSp") != null)
                {
                    var EXTGEN = AltExtGen_CLM_CostingAltGetCompareSp("dbo.EXTGEN_CLM_CostingAltGetCompareSp",
                        CostingAlt,
                        CostType,
                        Whse,
                        CostingAlt2Compare,
                        ItemCompare,
                        FilterString,
                        Infobar);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                Severity = 0;
                Infobar = null;

                #region CRUD LoadToVariable
                var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ItemCostInWhse,"invparms.cost_item_at_whse"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "invparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var invparmsLoadResponse = this.appDB.Load(invparmsLoadRequest);
                if (invparmsLoadResponse.Items.Count > 0)
                {
                    ItemCostInWhse = _ItemCostInWhse;
                }
                #endregion  LoadToVariable


                #region CRUD LoadToVariable
                var costing_altAScaLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ItemWhse,"ca.whse"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "costing_alt AS ca",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("ca.costing_alt = {0}", CostingAlt),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var costing_altAScaLoadResponse = this.appDB.Load(costing_altAScaLoadRequest);
                if (costing_altAScaLoadResponse.Items.Count > 0)
                {
                    ItemWhse = _ItemWhse;
                }
                #endregion  LoadToVariable

                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#tempOutput") == null)
                {

                    this.sQLExpressionExecutor.Execute(@"Declare
					@Item ItemType
					,@ItmDescription DescriptionType
					,@UM UMType
					,@CostingAltResult CostingAlternativeType
					,@ProductCode ProductCodeType
					,@Job JobType
					,@Suffix SuffixType
					,@MatlCost CostPrcType
					,@LbrCost CostPrcType
					,@FovhdCost CostPrcType
					,@VovhdCost CostPrcType
					,@OutCost CostPrcType
					,@DerUnitCost CostPrcType
					,@DerMarkup MarkupType
					,@DerUnitPrice CostPrcType
					,@DerMargin CostPrcType
					,@CostRollUpFlag ListYesNoType
					,@CompSetup CostPrcType
					,@CompRun CostPrcType
					,@CompMatl CostPrcType
					,@CompTool CostPrcType
					,@CompFixture CostPrcType
					,@CompOther CostPrcType
					,@CompFixed CostPrcType
					,@CompVar CostPrcType
					,@CompOutside CostPrcType
					,@AsmSetup CostPrcType
					,@AsmRun CostPrcType
					,@AsmMatl CostPrcType
					,@AsmTool CostPrcType
					,@AsmFixture CostPrcType
					,@AsmOther CostPrcType
					,@AsmFixed CostPrcType
					,@AsmVar CostPrcType
					,@AsmOutside CostPrcType
					SELECT @Item AS Item,
					@ItmDescription AS ItmDescription,
					@UM AS UM,
					@CostingAltResult AS CostingAlt,
					@ProductCode AS ProductCode,
					@Job AS [Job],
					@Suffix AS Suffix,
					@MatlCost AS MatlCost,
					@LbrCost AS LbrCost,
					@FovhdCost AS FovhdCost,
					@VovhdCost AS VovhdCost,
					@OutCost AS OutCost,
					@DerUnitCost AS DerUnitCost,
					@DerMarkup AS DerMarkup,
					@DerUnitPrice AS DerUnitPrice,
					@DerMargin AS DerMargin,
					@CostRollUpFlag AS CostRollUpFlag,
					@CompSetup AS CompSetup,
					@CompRun AS CompRun,
					@CompMatl AS CompMatl,
					@CompTool AS CompTool,
					@CompFixture AS CompFixture,
					@CompOther AS CompOther,
					@CompFixed AS CompFixed,
					@CompVar AS CompVar,
					@CompOutside AS CompOutside,
					@AsmSetup AS AsmSetup,
					@AsmRun AS AsmRun,
					@AsmMatl AS AsmMatl,
					@AsmTool AS AsmTool,
					@AsmFixture AS AsmFixture,
					@AsmOther AS AsmOther,
					@AsmFixed AS AsmFixed,
					@AsmVar AS AsmVar,
					@AsmOutside AS AsmOutside
					INTO   #tempOutput
					WHERE  1 = 2");

                }
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#Results") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #Results");

                }

                this.sQLExpressionExecutor.Execute(@"Declare
				@Item ItemType
				,@ItmDescription DescriptionType
				,@ProductCode ProductCodeType
				,@Job JobType
				,@Suffix SuffixType
				,@MatlCost CostPrcType
				,@LbrCost CostPrcType
				,@FovhdCost CostPrcType
				,@VovhdCost CostPrcType
				,@OutCost CostPrcType
				,@DerUnitCost CostPrcType
				,@DerMarkup MarkupType
				,@DerUnitPrice CostPrcType
				,@DerMargin CostPrcType
				,@CostRollUpFlag ListYesNoType
				,@CompSetup CostPrcType
				,@CompRun CostPrcType
				,@CompMatl CostPrcType
				,@CompTool CostPrcType
				,@CompFixture CostPrcType
				,@CompOther CostPrcType
				,@CompFixed CostPrcType
				,@CompVar CostPrcType
				,@CompOutside CostPrcType
				,@AsmSetup CostPrcType
				,@AsmRun CostPrcType
				,@AsmMatl CostPrcType
				,@AsmTool CostPrcType
				,@AsmFixture CostPrcType
				,@AsmOther CostPrcType
				,@AsmFixed CostPrcType
				,@AsmVar CostPrcType
				,@AsmOutside CostPrcType
				,@UM UMType
				,@CostingAltResult CostingAlternativeType
				SELECT @Item AS Item,
				@ItmDescription AS ItmDescription,
				@ProductCode AS ProductCode,
				@Job AS [Job],
				@Suffix AS Suffix,
				@MatlCost AS MatlCost,
				@LbrCost AS LbrCost,
				@FovhdCost AS FovhdCost,
				@VovhdCost AS VovhdCost,
				@OutCost AS OutCost,
				@DerUnitCost AS DerUnitCost,
				@DerMarkup AS DerMarkup,
				@DerUnitPrice AS DerUnitPrice,
				@DerMargin AS DerMargin,
				@CostRollUpFlag AS CostRollUpFlag,
				@CompSetup AS CompSetup,
				@CompRun AS CompRun,
				@CompMatl AS CompMatl,
				@CompTool AS CompTool,
				@CompFixture AS CompFixture,
				@CompOther AS CompOther,
				@CompFixed AS CompFixed,
				@CompVar AS CompVar,
				@CompOutside AS CompOutside,
				@AsmSetup AS AsmSetup,
				@AsmRun AS AsmRun,
				@AsmMatl AS AsmMatl,
				@AsmTool AS AsmTool,
				@AsmFixture AS AsmFixture,
				@AsmOther AS AsmOther,
				@AsmFixed AS AsmFixed,
				@AsmVar AS AsmVar,
				@AsmOutside AS AsmOutside,
				@UM AS UM,
				@CostingAltResult AS CostingAlt
				INTO   #Results
				WHERE  1 = 2");
                if (CostType != null)
                {
                    //BEGIN
                    if (sQLUtil.SQLEqual(CostType, "A") == true)
                    {
                        //BEGIN
                        JobSuffix = 0;
                        //END

                    }
                    if (sQLUtil.SQLEqual(CostType, "S") == true)
                    {
                        //BEGIN
                        JobSuffix = 1;
                        //END

                    }
                    if (sQLUtil.SQLEqual(ItemCostInWhse, 1) == true)
                    {
                        //BEGIN

                        #region CRUD LoadToRecord
                        var itemwhseLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"Item","iw.item"},
                            {"ItmDescription","itm.description"},
                            {"UM","itm.u_m"},
                            {"CostingAlt","CAST (NULL AS NVARCHAR)"},
                            {"ProductCode","itm.product_code"},
                            {"Job","job.[job]"},
                            {"Suffix","job.suffix"},
                            {"MatlCost","CAST (NULL AS DECIMAL)"},
                            {"LbrCost","CAST (NULL AS DECIMAL)"},
                            {"FovhdCost","CAST (NULL AS DECIMAL)"},
                            {"VovhdCost","CAST (NULL AS DECIMAL)"},
                            {"OutCost","CAST (NULL AS DECIMAL)"},
                            {"DerUnitCost","CAST (NULL AS INT)"},
                            {"DerMarkup","prd.markup"},
                            {"DerUnitPrice","CAST (NULL AS INT)"},
                            {"DerMargin","CAST (NULL AS INT)"},
                            {"CostRollUpFlag","CAST (NULL AS INT)"},
                            {"CompSetup","CAST (NULL AS DECIMAL)"},
                            {"CompRun","CAST (NULL AS DECIMAL)"},
                            {"CompMatl","CAST (NULL AS DECIMAL)"},
                            {"CompTool","CAST (NULL AS DECIMAL)"},
                            {"CompFixture","CAST (NULL AS DECIMAL)"},
                            {"CompOther","CAST (NULL AS DECIMAL)"},
                            {"CompFixed","CAST (NULL AS DECIMAL)"},
                            {"CompVar","CAST (NULL AS DECIMAL)"},
                            {"CompOutside","CAST (NULL AS DECIMAL)"},
                            {"AsmSetup","CAST (NULL AS DECIMAL)"},
                            {"AsmRun","CAST (NULL AS DECIMAL)"},
                            {"AsmMatl","CAST (NULL AS DECIMAL)"},
                            {"AsmTool","CAST (NULL AS DECIMAL)"},
                            {"AsmFixture","CAST (NULL AS DECIMAL)"},
                            {"AsmOther","CAST (NULL AS DECIMAL)"},
                            {"AsmFixed","CAST (NULL AS DECIMAL)"},
                            {"AsmVar","CAST (NULL AS DECIMAL)"},
                            {"AsmOutside","CAST (NULL AS DECIMAL)"},
                            {"u0","iw.matl_cost"},
                            {"u1","iw.cur_matl_cost"},
                            {"u2","iw.lbr_cost"},
                            {"u3","iw.cur_lbr_cost"},
                            {"u4","iw.fovhd_cost"},
                            {"u5","iw.cur_fovhd_cost"},
                            {"u6","iw.vovhd_cost"},
                            {"u7","iw.cur_vovhd_cost"},
                            {"u8","iw.out_cost"},
                            {"u9","iw.cur_out_cost"},
                            {"u10","cost.comp_setup"},
                            {"u11","iw.comp_setup"},
                            {"u12","cost.comp_run"},
                            {"u13","iw.comp_run"},
                            {"u14","cost.comp_matl"},
                            {"u15","iw.comp_matl"},
                            {"u16","cost.comp_tool"},
                            {"u17","iw.comp_tool"},
                            {"u18","cost.comp_fixture"},
                            {"u19","iw.comp_fixture"},
                            {"u20","cost.comp_other"},
                            {"u21","iw.comp_other"},
                            {"u22","cost.comp_fixed"},
                            {"u23","iw.comp_fixed"},
                            {"u24","cost.comp_var"},
                            {"u25","iw.comp_var"},
                            {"u26","cost.comp_outside"},
                            {"u27","iw.comp_outside"},
                            {"u28","cost.asm_setup"},
                            {"u29","iw.asm_setup"},
                            {"u30","cost.asm_run"},
                            {"u31","iw.asm_run"},
                            {"u32","cost.asm_matl"},
                            {"u33","iw.asm_matl"},
                            {"u34","cost.asm_tool"},
                            {"u35","iw.asm_tool"},
                            {"u36","cost.asm_fixture"},
                            {"u37","iw.asm_fixture"},
                            {"u38","cost.asm_other"},
                            {"u39","iw.asm_other"},
                            {"u40","cost.asm_fixed"},
                            {"u41","iw.asm_fixed"},
                            {"u42","cost.asm_var"},
                            {"u43","iw.asm_var"},
                            {"u44","cost.asm_Outside"},
                            {"u45","iw.asm_Outside"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "itemwhse",
                        fromClause: collectionLoadRequestFactory.Clause(@" as iw left outer join frzcost as cost on iw.item = cost.item left outer join item as itm on itm.item = iw.item left outer join prodcode as prd on prd.product_code = itm.product_code inner join job on job.job = itm.job
						and job.item = itm.item
						and job.suffix = {0}
						and job.type = 's'
						and iw.whse = {1}", JobSuffix, Whse),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(" itm.item"));
                        var itemwhseLoadResponse = this.appDB.Load(itemwhseLoadRequest);
                        #endregion  LoadToRecord


                        #region CRUD InsertByRecords
                        foreach (var itemwhseItem in itemwhseLoadResponse.Items)
                        {
                            itemwhseItem.SetValue<string>("Item", itemwhseItem.GetValue<string>("Item"));
                            itemwhseItem.SetValue<string>("ItmDescription", itemwhseItem.GetValue<string>("ItmDescription"));
                            itemwhseItem.SetValue<string>("UM", itemwhseItem.GetValue<string>("UM"));
                            itemwhseItem.SetValue<string>("CostingAlt", "");
                            itemwhseItem.SetValue<string>("ProductCode", itemwhseItem.GetValue<string>("ProductCode"));
                            itemwhseItem.SetValue<string>("Job", itemwhseItem.GetValue<string>("Job"));
                            itemwhseItem.SetValue<int?>("Suffix", itemwhseItem.GetValue<int?>("Suffix"));
                            itemwhseItem.SetValue<decimal?>("MatlCost", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u0")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u1"))));
                            itemwhseItem.SetValue<decimal?>("LbrCost", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u2")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u3"))));
                            itemwhseItem.SetValue<decimal?>("FovhdCost", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u4")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u5"))));
                            itemwhseItem.SetValue<decimal?>("VovhdCost", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u6")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u7"))));
                            itemwhseItem.SetValue<decimal?>("OutCost", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u8")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u9"))));
                            itemwhseItem.SetValue<int?>("DerUnitCost", 0);
                            itemwhseItem.SetValue<decimal?>("DerMarkup", itemwhseItem.GetValue<decimal?>("DerMarkup"));
                            itemwhseItem.SetValue<int?>("DerUnitPrice", 0);
                            itemwhseItem.SetValue<int?>("DerMargin", 0);
                            itemwhseItem.SetValue<int?>("CostRollUpFlag", 0);
                            itemwhseItem.SetValue<decimal?>("CompSetup", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u10")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u11"))));
                            itemwhseItem.SetValue<decimal?>("CompRun", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u12")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u13"))));
                            itemwhseItem.SetValue<decimal?>("CompMatl", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u14")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u15"))));
                            itemwhseItem.SetValue<decimal?>("CompTool", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u16")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u17"))));
                            itemwhseItem.SetValue<decimal?>("CompFixture", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u18")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u19"))));
                            itemwhseItem.SetValue<decimal?>("CompOther", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u20")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u21"))));
                            itemwhseItem.SetValue<decimal?>("CompFixed", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u22")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u23"))));
                            itemwhseItem.SetValue<decimal?>("CompVar", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u24")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u25"))));
                            itemwhseItem.SetValue<decimal?>("CompOutside", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u26")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u27"))));
                            itemwhseItem.SetValue<decimal?>("AsmSetup", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u28")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u29"))));
                            itemwhseItem.SetValue<decimal?>("AsmRun", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u30")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u31"))));
                            itemwhseItem.SetValue<decimal?>("AsmMatl", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u32")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u33"))));
                            itemwhseItem.SetValue<decimal?>("AsmTool", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u34")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u35"))));
                            itemwhseItem.SetValue<decimal?>("AsmFixture", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u36")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u37"))));
                            itemwhseItem.SetValue<decimal?>("AsmOther", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u38")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u39"))));
                            itemwhseItem.SetValue<decimal?>("AsmFixed", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u40")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u41"))));
                            itemwhseItem.SetValue<decimal?>("AsmVar", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u42")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u43"))));
                            itemwhseItem.SetValue<decimal?>("AsmOutside", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u44")) : convertToUtil.ToDecimal(itemwhseItem.GetValue<decimal?>("u45"))));
                        };

                        var itemwhseRequiredColumns = new List<string>() { "Item", "ItmDescription", "UM", "CostingAlt", "ProductCode", "Job", "Suffix", "MatlCost", "LbrCost", "FovhdCost", "VovhdCost", "OutCost", "DerUnitCost", "DerMarkup", "DerUnitPrice", "DerMargin", "CostRollUpFlag", "CompSetup", "CompRun", "CompMatl", "CompTool", "CompFixture", "CompOther", "CompFixed", "CompVar", "CompOutside", "AsmSetup", "AsmRun", "AsmMatl", "AsmTool", "AsmFixture", "AsmOther", "AsmFixed", "AsmVar", "AsmOutside" };

                        itemwhseLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(itemwhseLoadResponse, itemwhseRequiredColumns);

                        var itemwhseInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tempOutput",
                            items: itemwhseLoadResponse.Items);

                        this.appDB.Insert(itemwhseInsertRequest);
                        #endregion InsertByRecords

                        //END

                    }
                    else
                    {
                        //BEGIN

                        #region CRUD LoadToRecord
                        var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"Item","itm.item"},
                            {"ItmDescription","itm.description"},
                            {"UM","itm.u_m"},
                            {"CostingAlt","CAST (NULL AS NVARCHAR)"},
                            {"ProductCode","itm.product_code"},
                            {"Job","job.[job]"},
                            {"Suffix","job.suffix"},
                            {"MatlCost","CAST (NULL AS DECIMAL)"},
                            {"LbrCost","CAST (NULL AS DECIMAL)"},
                            {"FovhdCost","CAST (NULL AS DECIMAL)"},
                            {"VovhdCost","CAST (NULL AS DECIMAL)"},
                            {"OutCost","CAST (NULL AS DECIMAL)"},
                            {"DerUnitCost","CAST (NULL AS INT)"},
                            {"DerMarkup","prd.markup"},
                            {"DerUnitPrice","CAST (NULL AS INT)"},
                            {"DerMargin","CAST (NULL AS INT)"},
                            {"CostRollUpFlag","CAST (NULL AS INT)"},
                            {"CompSetup","CAST (NULL AS DECIMAL)"},
                            {"CompRun","CAST (NULL AS DECIMAL)"},
                            {"CompMatl","CAST (NULL AS DECIMAL)"},
                            {"CompTool","CAST (NULL AS DECIMAL)"},
                            {"CompFixture","CAST (NULL AS DECIMAL)"},
                            {"CompOther","CAST (NULL AS DECIMAL)"},
                            {"CompFixed","CAST (NULL AS DECIMAL)"},
                            {"CompVar","CAST (NULL AS DECIMAL)"},
                            {"CompOutside","CAST (NULL AS DECIMAL)"},
                            {"AsmSetup","CAST (NULL AS DECIMAL)"},
                            {"AsmRun","CAST (NULL AS DECIMAL)"},
                            {"AsmMatl","CAST (NULL AS DECIMAL)"},
                            {"AsmTool","CAST (NULL AS DECIMAL)"},
                            {"AsmFixture","CAST (NULL AS DECIMAL)"},
                            {"AsmOther","CAST (NULL AS DECIMAL)"},
                            {"AsmFixed","CAST (NULL AS DECIMAL)"},
                            {"AsmVar","CAST (NULL AS DECIMAL)"},
                            {"AsmOutside","CAST (NULL AS DECIMAL)"},
                            {"u0","itm.matl_cost"},
                            {"u1","itm.cur_matl_cost"},
                            {"u2","itm.lbr_cost"},
                            {"u3","itm.cur_lbr_cost"},
                            {"u4","itm.fovhd_cost"},
                            {"u5","itm.cur_fovhd_cost"},
                            {"u6","itm.vovhd_cost"},
                            {"u7","itm.cur_vovhd_cost"},
                            {"u8","itm.out_cost"},
                            {"u9","itm.cur_out_cost"},
                            {"u10","cost.comp_setup"},
                            {"u11","itm.comp_setup"},
                            {"u12","cost.comp_run"},
                            {"u13","itm.comp_run"},
                            {"u14","cost.comp_matl"},
                            {"u15","itm.comp_matl"},
                            {"u16","cost.comp_tool"},
                            {"u17","itm.comp_tool"},
                            {"u18","cost.comp_fixture"},
                            {"u19","itm.comp_fixture"},
                            {"u20","cost.comp_other"},
                            {"u21","itm.comp_other"},
                            {"u22","cost.comp_fixed"},
                            {"u23","itm.comp_fixed"},
                            {"u24","cost.comp_var"},
                            {"u25","itm.comp_var"},
                            {"u26","cost.comp_outside"},
                            {"u27","itm.comp_outside"},
                            {"u28","cost.asm_setup"},
                            {"u29","itm.asm_setup"},
                            {"u30","cost.asm_run"},
                            {"u31","itm.asm_run"},
                            {"u32","cost.asm_matl"},
                            {"u33","itm.asm_matl"},
                            {"u34","cost.asm_tool"},
                            {"u35","itm.asm_tool"},
                            {"u36","cost.asm_fixture"},
                            {"u37","itm.asm_fixture"},
                            {"u38","cost.asm_other"},
                            {"u39","itm.asm_other"},
                            {"u40","cost.asm_fixed"},
                            {"u41","itm.asm_fixed"},
                            {"u42","cost.asm_var"},
                            {"u43","itm.asm_var"},
                            {"u44","cost.asm_Outside"},
                            {"u45","itm.asm_Outside"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "item",
                        fromClause: collectionLoadRequestFactory.Clause(@" as itm left outer join frzcost as cost on itm.item = cost.item left outer join prodcode as prd on prd.product_code = itm.product_code inner join job on job.job = itm.job
						and job.item = itm.item
						and job.suffix = {0}
						and job.type = 's'", JobSuffix),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(" itm.item"));
                        var itemLoadResponse = this.appDB.Load(itemLoadRequest);
                        #endregion  LoadToRecord


                        #region CRUD InsertByRecords
                        foreach (var itemItem in itemLoadResponse.Items)
                        {
                            itemItem.SetValue<string>("Item", itemItem.GetValue<string>("Item"));
                            itemItem.SetValue<string>("ItmDescription", itemItem.GetValue<string>("ItmDescription"));
                            itemItem.SetValue<string>("UM", itemItem.GetValue<string>("UM"));
                            itemItem.SetValue<string>("CostingAlt", "");
                            itemItem.SetValue<string>("ProductCode", itemItem.GetValue<string>("ProductCode"));
                            itemItem.SetValue<string>("Job", itemItem.GetValue<string>("Job"));
                            itemItem.SetValue<int?>("Suffix", itemItem.GetValue<int?>("Suffix"));
                            itemItem.SetValue<decimal?>("MatlCost", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u0")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u1"))));
                            itemItem.SetValue<decimal?>("LbrCost", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u2")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u3"))));
                            itemItem.SetValue<decimal?>("FovhdCost", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u4")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u5"))));
                            itemItem.SetValue<decimal?>("VovhdCost", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u6")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u7"))));
                            itemItem.SetValue<decimal?>("OutCost", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u8")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u9"))));
                            itemItem.SetValue<int?>("DerUnitCost", 0);
                            itemItem.SetValue<decimal?>("DerMarkup", itemItem.GetValue<decimal?>("DerMarkup"));
                            itemItem.SetValue<int?>("DerUnitPrice", 0);
                            itemItem.SetValue<int?>("DerMargin", 0);
                            itemItem.SetValue<int?>("CostRollUpFlag", 0);
                            itemItem.SetValue<decimal?>("CompSetup", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u10")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u11"))));
                            itemItem.SetValue<decimal?>("CompRun", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u12")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u13"))));
                            itemItem.SetValue<decimal?>("CompMatl", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u14")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u15"))));
                            itemItem.SetValue<decimal?>("CompTool", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u16")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u17"))));
                            itemItem.SetValue<decimal?>("CompFixture", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u18")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u19"))));
                            itemItem.SetValue<decimal?>("CompOther", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u20")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u21"))));
                            itemItem.SetValue<decimal?>("CompFixed", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u22")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u23"))));
                            itemItem.SetValue<decimal?>("CompVar", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u24")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u25"))));
                            itemItem.SetValue<decimal?>("CompOutside", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u26")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u27"))));
                            itemItem.SetValue<decimal?>("AsmSetup", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u28")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u29"))));
                            itemItem.SetValue<decimal?>("AsmRun", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u30")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u31"))));
                            itemItem.SetValue<decimal?>("AsmMatl", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u32")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u33"))));
                            itemItem.SetValue<decimal?>("AsmTool", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u34")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u35"))));
                            itemItem.SetValue<decimal?>("AsmFixture", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u36")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u37"))));
                            itemItem.SetValue<decimal?>("AsmOther", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u38")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u39"))));
                            itemItem.SetValue<decimal?>("AsmFixed", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u40")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u41"))));
                            itemItem.SetValue<decimal?>("AsmVar", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u42")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u43"))));
                            itemItem.SetValue<decimal?>("AsmOutside", (sQLUtil.SQLEqual(CostType, "S") == true ? convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u44")) : convertToUtil.ToDecimal(itemItem.GetValue<decimal?>("u45"))));
                        };

                        var itemRequiredColumns = new List<string>() { "Item", "ItmDescription", "UM", "CostingAlt", "ProductCode", "Job", "Suffix", "MatlCost", "LbrCost", "FovhdCost", "VovhdCost", "OutCost", "DerUnitCost", "DerMarkup", "DerUnitPrice", "DerMargin", "CostRollUpFlag", "CompSetup", "CompRun", "CompMatl", "CompTool", "CompFixture", "CompOther", "CompFixed", "CompVar", "CompOutside", "AsmSetup", "AsmRun", "AsmMatl", "AsmTool", "AsmFixture", "AsmOther", "AsmFixed", "AsmVar", "AsmOutside" };

                        itemLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(itemLoadResponse, itemRequiredColumns);

                        var itemInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tempOutput",
                            items: itemLoadResponse.Items);

                        this.appDB.Insert(itemInsertRequest);
                        #endregion InsertByRecords

                        //END

                    }
                    //END

                }
                else
                {
                    //BEGIN

                    #region CRUD LoadToRecord
                    var costing_alt_itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"Item","cai.item"},
                        {"ItmDescription","itm.description"},
                        {"UM","itm.u_m"},
                        {"CostingAlt","cai.costing_alt"},
                        {"ProductCode","cai.product_code"},
                        {"Job","cai.[job]"},
                        {"Suffix","cai.suffix"},
                        {"MatlCost","cai.matl_cost"},
                        {"LbrCost","cai.lbr_cost"},
                        {"FovhdCost","cai.fovhd_cost"},
                        {"VovhdCost","cai.vovhd_cost"},
                        {"OutCost","cai.out_cost"},
                        {"DerUnitCost","CAST (NULL AS INT)"},
                        {"DerMarkup","CAST (NULL AS DECIMAL)"},
                        {"DerUnitPrice","CAST (NULL AS INT)"},
                        {"DerMargin","CAST (NULL AS INT)"},
                        {"CostRollUpFlag","cai.cost_roll_up_flag"},
                        {"CompSetup","cai.comp_setup"},
                        {"CompRun","cai.comp_run"},
                        {"CompMatl","cai.comp_matl"},
                        {"CompTool","cai.comp_tool"},
                        {"CompFixture","cai.comp_fixture"},
                        {"CompOther","cai.comp_other"},
                        {"CompFixed","cai.comp_fixed"},
                        {"CompVar","cai.comp_var"},
                        {"CompOutside","cai.comp_outside"},
                        {"AsmSetup","cai.asm_setup"},
                        {"AsmRun","cai.asm_run"},
                        {"AsmMatl","cai.asm_matl"},
                        {"AsmTool","cai.asm_tool"},
                        {"AsmFixture","cai.asm_fixture"},
                        {"AsmOther","cai.asm_other"},
                        {"AsmFixed","cai.asm_fixed"},
                        {"AsmVar","cai.asm_var"},
                        {"AsmOutside","cai.asm_Outside"},
                        {"u0","caprd.markup"},
                        {"u1","prd.markup"},
                    },
                    loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "costing_alt_item",
                    fromClause: collectionLoadRequestFactory.Clause(@" AS cai LEFT OUTER JOIN costing_alt_product_code AS caprd ON caprd.product_code = cai.product_code
					AND caprd.costing_alt = cai.costing_alt LEFT OUTER JOIN item AS itm ON itm.item = cai.item LEFT OUTER JOIN prodcode AS prd ON prd.product_code = cai.product_code"),
                    whereClause: collectionLoadRequestFactory.Clause("cai.costing_alt = {0}", CostingAlt2Compare),
                    orderByClause: collectionLoadRequestFactory.Clause(" cai.costing_alt, cai.item"));
                    var costing_alt_itemLoadResponse = this.appDB.Load(costing_alt_itemLoadRequest);
                    #endregion  LoadToRecord


                    #region CRUD InsertByRecords
                    foreach (var costing_alt_itemItem in costing_alt_itemLoadResponse.Items)
                    {
                        costing_alt_itemItem.SetValue<string>("Item", costing_alt_itemItem.GetValue<string>("Item"));
                        costing_alt_itemItem.SetValue<string>("ItmDescription", costing_alt_itemItem.GetValue<string>("ItmDescription"));
                        costing_alt_itemItem.SetValue<string>("UM", costing_alt_itemItem.GetValue<string>("UM"));
                        costing_alt_itemItem.SetValue<string>("CostingAlt", costing_alt_itemItem.GetValue<string>("CostingAlt"));
                        costing_alt_itemItem.SetValue<string>("ProductCode", costing_alt_itemItem.GetValue<string>("ProductCode"));
                        costing_alt_itemItem.SetValue<string>("Job", costing_alt_itemItem.GetValue<string>("Job"));
                        costing_alt_itemItem.SetValue<int?>("Suffix", costing_alt_itemItem.GetValue<int?>("Suffix"));
                        costing_alt_itemItem.SetValue<decimal?>("MatlCost", costing_alt_itemItem.GetValue<decimal?>("MatlCost"));
                        costing_alt_itemItem.SetValue<decimal?>("LbrCost", costing_alt_itemItem.GetValue<decimal?>("LbrCost"));
                        costing_alt_itemItem.SetValue<decimal?>("FovhdCost", costing_alt_itemItem.GetValue<decimal?>("FovhdCost"));
                        costing_alt_itemItem.SetValue<decimal?>("VovhdCost", costing_alt_itemItem.GetValue<decimal?>("VovhdCost"));
                        costing_alt_itemItem.SetValue<decimal?>("OutCost", costing_alt_itemItem.GetValue<decimal?>("OutCost"));
                        costing_alt_itemItem.SetValue<int?>("DerUnitCost", 0);
                        costing_alt_itemItem.SetValue<decimal?>("DerMarkup", stringUtil.Coalesce<decimal?>(costing_alt_itemItem.GetValue<decimal?>("u0"), costing_alt_itemItem.GetValue<decimal?>("u1")));
                        costing_alt_itemItem.SetValue<int?>("DerUnitPrice", 0);
                        costing_alt_itemItem.SetValue<int?>("DerMargin", 0);
                        costing_alt_itemItem.SetValue<int?>("CostRollUpFlag", costing_alt_itemItem.GetValue<int?>("CostRollUpFlag"));
                        costing_alt_itemItem.SetValue<decimal?>("CompSetup", costing_alt_itemItem.GetValue<decimal?>("CompSetup"));
                        costing_alt_itemItem.SetValue<decimal?>("CompRun", costing_alt_itemItem.GetValue<decimal?>("CompRun"));
                        costing_alt_itemItem.SetValue<decimal?>("CompMatl", costing_alt_itemItem.GetValue<decimal?>("CompMatl"));
                        costing_alt_itemItem.SetValue<decimal?>("CompTool", costing_alt_itemItem.GetValue<decimal?>("CompTool"));
                        costing_alt_itemItem.SetValue<decimal?>("CompFixture", costing_alt_itemItem.GetValue<decimal?>("CompFixture"));
                        costing_alt_itemItem.SetValue<decimal?>("CompOther", costing_alt_itemItem.GetValue<decimal?>("CompOther"));
                        costing_alt_itemItem.SetValue<decimal?>("CompFixed", costing_alt_itemItem.GetValue<decimal?>("CompFixed"));
                        costing_alt_itemItem.SetValue<decimal?>("CompVar", costing_alt_itemItem.GetValue<decimal?>("CompVar"));
                        costing_alt_itemItem.SetValue<decimal?>("CompOutside", costing_alt_itemItem.GetValue<decimal?>("CompOutside"));
                        costing_alt_itemItem.SetValue<decimal?>("AsmSetup", costing_alt_itemItem.GetValue<decimal?>("AsmSetup"));
                        costing_alt_itemItem.SetValue<decimal?>("AsmRun", costing_alt_itemItem.GetValue<decimal?>("AsmRun"));
                        costing_alt_itemItem.SetValue<decimal?>("AsmMatl", costing_alt_itemItem.GetValue<decimal?>("AsmMatl"));
                        costing_alt_itemItem.SetValue<decimal?>("AsmTool", costing_alt_itemItem.GetValue<decimal?>("AsmTool"));
                        costing_alt_itemItem.SetValue<decimal?>("AsmFixture", costing_alt_itemItem.GetValue<decimal?>("AsmFixture"));
                        costing_alt_itemItem.SetValue<decimal?>("AsmOther", costing_alt_itemItem.GetValue<decimal?>("AsmOther"));
                        costing_alt_itemItem.SetValue<decimal?>("AsmFixed", costing_alt_itemItem.GetValue<decimal?>("AsmFixed"));
                        costing_alt_itemItem.SetValue<decimal?>("AsmVar", costing_alt_itemItem.GetValue<decimal?>("AsmVar"));
                        costing_alt_itemItem.SetValue<decimal?>("AsmOutside", costing_alt_itemItem.GetValue<decimal?>("AsmOutside"));
                    };

                    var costing_alt_itemRequiredColumns = new List<string>() { "Item", "ItmDescription", "UM", "CostingAlt", "ProductCode", "Job", "Suffix", "MatlCost", "LbrCost", "FovhdCost", "VovhdCost", "OutCost", "DerUnitCost", "DerMarkup", "DerUnitPrice", "DerMargin", "CostRollUpFlag", "CompSetup", "CompRun", "CompMatl", "CompTool", "CompFixture", "CompOther", "CompFixed", "CompVar", "CompOutside", "AsmSetup", "AsmRun", "AsmMatl", "AsmTool", "AsmFixture", "AsmOther", "AsmFixed", "AsmVar", "AsmOutside" };

                    costing_alt_itemLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(costing_alt_itemLoadResponse, costing_alt_itemRequiredColumns);

                    var costing_alt_itemInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tempOutput",
                        items: costing_alt_itemLoadResponse.Items);

                    this.appDB.Insert(costing_alt_itemInsertRequest);
                    #endregion InsertByRecords

                    //END

                }
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tempOutput ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tempOutput1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"DerUnitCost","#tempOutput.DerUnitCost"},
                    {"u0","MatlCost"},
                    {"u1","LbrCost"},
                    {"u2","FovhdCost"},
                    {"u3","VovhdCost"},
                    {"u4","OutCost"},
                },
                tableName: "#tempOutput", 
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var tempOutput1LoadResponse = this.appDB.Load(tempOutput1LoadRequest);
                #endregion  LoadToRecord


                #region CRUD UpdateByRecord
                foreach (var tempOutput1Item in tempOutput1LoadResponse.Items)
                {
                    tempOutput1Item.SetValue<decimal?>("DerUnitCost", tempOutput1Item.GetDeletedValue<decimal?>("u0") + tempOutput1Item.GetDeletedValue<decimal?>("u1") + tempOutput1Item.GetDeletedValue<decimal?>("u2") + tempOutput1Item.GetDeletedValue<decimal?>("u3") + tempOutput1Item.GetDeletedValue<decimal?>("u4"));
                };

                var tempOutput1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tempOutput",
                    items: tempOutput1LoadResponse.Items);

                this.appDB.Update(tempOutput1RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tempOutput DROP COLUMN tempTableId");
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tempOutput ADD tempTableId INT IDENTITY");

                #region CRUD LoadToRecord
                var tempOutput2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"DerUnitPrice","#tempOutput.DerUnitPrice"},
                    {"DerMargin","#tempOutput.DerMargin"},
                    {"u0","DerUnitCost"},
                    {"u1","DerMarkup"},
                    {"u2","DerUnitCost"},
                    {"u3","DerMarkup"},
                },
                tableName: "#tempOutput", 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var tempOutput2LoadResponse = this.appDB.Load(tempOutput2LoadRequest);
                #endregion  LoadToRecord


                #region CRUD UpdateByRecord
                foreach (var tempOutput2Item in tempOutput2LoadResponse.Items)
                {
                    tempOutput2Item.SetValue<decimal?>("DerUnitPrice", tempOutput2Item.GetDeletedValue<decimal?>("u0") * tempOutput2Item.GetDeletedValue<decimal?>("u1"));
                    tempOutput2Item.SetValue<decimal?>("DerMargin", tempOutput2Item.GetDeletedValue<decimal?>("u2") * tempOutput2Item.GetDeletedValue<decimal?>("u3") - tempOutput2Item.GetDeletedValue<decimal?>("u2"));
                };

                var tempOutput2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tempOutput",
                    items: tempOutput2LoadResponse.Items);

                this.appDB.Update(tempOutput2RequestUpdate);
                #endregion UpdateByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tempOutput DROP COLUMN tempTableId");
                SQLString = @"
				INSERT INTO #Results
				SELECT
				Item,
				ItmDescription,
				ProductCode,
				[Job],
				Suffix,
				MatlCost,
				LbrCost,
				FovhdCost,
				VovhdCost,
				OutCost,
				DerUnitCost,
				DerMarkup,
				DerUnitPrice,
				DerMargin,
				CostRollUpFlag,
				CompSetup,
				CompRun,
				CompMatl,
				CompTool,
				CompFixture,
				CompOther,
				CompFixed,
				CompVar,
				CompOutside,
				AsmSetup,
				AsmRun,
				AsmMatl,
				AsmTool,
				AsmFixture,
				AsmOther,
				AsmFixed,
				AsmVar,
				AsmOutside,
				UM,
				CostingAlt
				FROM #tempOutput WHERE 1 = 1 ";
                if (ItemCompare != null)
                {
                    //BEGIN
                    SQLString = stringUtil.Concat(SQLString, " AND Item = @ItemCompare");
                    if (CostingAlt2Compare != null)
                    {
                        SQLString = stringUtil.Concat(SQLString, " AND CostingAlt = @CostingAlt2Compare");

                    }
                    //END

                }

                var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQLString
                , "@ItemCompare ItemType, @CostingAlt2Compare CostingAlternativeType"
                , ItemCompare
                , CostingAlt2Compare);
                /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */

                SelectionClause = "";
                FromClause = "";
                WhereClause = "";
                AdditionalClause = "";
                KeyColumns = "";
                SelectionClause = "SELECT *";
                FromClause = "FROM #Results";
                WhereClause = "WHERE 1=1";
                AdditionalClause = "ORDER BY Item";
                KeyColumns = "Item";
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#DynamicParameters") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters");

                }

                this.sQLExpressionExecutor.Execute(@"Declare
				@SelectionClause VeryLongListType
				,@FromClause VeryLongListType
				,@WhereClause VeryLongListType
				,@AdditionalClause VeryLongListType
				,@KeyColumns VeryLongListType
				,@FilterString LongListType
				SELECT @SelectionClause AS SelectionClause,
				@FromClause AS FromClause,
				@WhereClause AS WhereClause,
				@AdditionalClause AS AdditionalClause,
				@KeyColumns AS KeyColumns,
				@FilterString AS FilterString
				INTO   #DynamicParameters
				WHERE 1 = 2");

                #region CRUD LoadArbitrary
                var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SelectionClause",$"{variableUtil.GetQuotedValue<string>(SelectionClause)}"},
                    {"FromClause",$"{variableUtil.GetQuotedValue<string>(FromClause)}"},
                    {"WhereClause",$"{variableUtil.GetQuotedValue<string>(WhereClause)}"},
                    {"AdditionalClause",$"{variableUtil.GetQuotedValue<string>(AdditionalClause)}"},
                    {"KeyColumns",$"{variableUtil.GetQuotedValue<string>(KeyColumns)}"},
                    {"FilterString",$"{variableUtil.GetQuotedValue<string>(FilterString)}"},
                },
                selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));

                var DynamicParametersLoadResponse = this.appDB.Load(DynamicParametersLoadRequest);
                Data = DynamicParametersLoadResponse;
                #endregion  LoadArbitrary


                #region CRUD InsertByRecords
                var DynamicParametersInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
                    items: DynamicParametersLoadResponse.Items);

                this.appDB.Insert(DynamicParametersInsertRequest);
                #endregion InsertByRecords


                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
                var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
                    NeedGetMoreRows: 1,
                    Infobar: Infobar);
                Severity = ExecuteDynamicSQL.ReturnCode;
                Data = ExecuteDynamicSQL.Data;
                Infobar = ExecuteDynamicSQL.Infobar;

                #endregion ExecuteMethodCall

                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#Results") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #Results");

                }
                return (Data, Severity);

            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }
        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_CLM_CostingAltGetCompareSp(
            string AltExtGenSp,
            string CostingAlt,
            string CostType = null,
            string Whse = null,
            string CostingAlt2Compare = null,
            string ItemCompare = null,
            string FilterString = null,
            string Infobar = null)
        {
            CostingAlternativeType _CostingAlt = CostingAlt;
            CostTypeType _CostType = CostType;
            WhseType _Whse = Whse;
            CostingAlternativeType _CostingAlt2Compare = CostingAlt2Compare;
            ItemType _ItemCompare = ItemCompare;
            LongListType _FilterString = FilterString;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "CostingAlt", _CostingAlt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CostType", _CostType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CostingAlt2Compare", _CostingAlt2Compare, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemCompare", _ItemCompare, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);

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
