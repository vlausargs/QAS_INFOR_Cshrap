//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSupplyUsage.cs

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
using CSI.CRUD.Production.APS;

namespace CSI.Production.APS
{
    public class CLM_ApsGetSupplyUsage : ICLM_ApsGetSupplyUsage
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ICLM_ApsGetSupplyUsageCRUD iCLM_ApsGetSupplyUsageCRUD;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly ISQLCollectionLoad sQLCollectionLoad;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IMidnightOf iMidnightOf;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public CLM_ApsGetSupplyUsage(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ICLM_ApsGetSupplyUsageCRUD iCLM_ApsGetSupplyUsageCRUD,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            ISQLCollectionLoad sQLCollectionLoad,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IMidnightOf iMidnightOf,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.iCLM_ApsGetSupplyUsageCRUD = iCLM_ApsGetSupplyUsageCRUD;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.sQLCollectionLoad = sQLCollectionLoad;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.iMidnightOf = iMidnightOf;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_ApsGetSupplyUsageSp(
            string SupplyType,
            string SupplyID,
            int? SupplyMatltag,
            Guid? SupplyRowPtr,
            string Item,
            DateTime? DueDate,
            string WildCardChar,
            int? AltNo,
            string FilterString)
        {

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {

                ICollectionLoadResponse Data = null;

                StringType _ALTGEN_SpName = DBNull.Value;
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                int? Severity = null;
                string SQLStr = null;
                string MATLDELV = null;
                string MATLPLAN = null;
                string INVPLAN = null;
                string ORDER = null;
                string MSLPLAN = null;
                string Infobar = null;
                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ApsGetSupplyUsageSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
                )
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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ApsGetSupplyUsageSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_ApsGetSupplyUsageSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                    };

                    var optional_module1RequiredColumns = new List<string>() { "SpName" };

                    optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                    var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                        items: optional_module1LoadResponse.Items);

                    this.appDB.Insert(optional_module1InsertRequest);
                    #endregion InsertByRecords

                    while (existsChecker.Exists(tableName: "#tv_ALTGEN",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""))
                    )
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

                        var ALTGEN = AltExtGen_CLM_ApsGetSupplyUsageSp(ALTGEN_SpName,
                            SupplyType,
                            SupplyID,
                            SupplyMatltag,
                            SupplyRowPtr,
                            Item,
                            DueDate,
                            WildCardChar,
                            AltNo,
                            FilterString);
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
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ApsGetSupplyUsageSp") != null)
                {
                    var EXTGEN = AltExtGen_CLM_ApsGetSupplyUsageSp("dbo.EXTGEN_CLM_ApsGetSupplyUsageSp",
                        SupplyType,
                        SupplyID,
                        SupplyMatltag,
                        SupplyRowPtr,
                        Item,
                        DueDate,
                        WildCardChar,
                        AltNo,
                        FilterString);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                Severity = 0;
                MATLDELV = stringUtil.Concat("MATLDELV", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                MATLPLAN = stringUtil.Concat("MATLPLAN", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                INVPLAN = stringUtil.Concat("INVPLAN", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                ORDER = stringUtil.Concat("ORDER", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                MSLPLAN = stringUtil.Concat("MSLPLAN", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#tempdbl") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #tempdbl");

                }
                iCLM_ApsGetSupplyUsageCRUD.CreateTempSupplyUsageTable();
                if (SupplyMatltag == null)
                {
                    SupplyMatltag = 0;

                }
                if ((sQLUtil.SQLEqual(SupplyMatltag, 0) == true) && (SupplyRowPtr == null))
                {
                    //BEGIN
                    WildCardChar = stringUtil.IsNull(
                        WildCardChar,
                        "*");
                    if (SupplyID != null)
                    {
                        SupplyID = stringUtil.Replace(
                            SupplyID,
                            WildCardChar,
                            "%");

                    }
                    if (Item != null)
                    {
                        Item = stringUtil.Replace(
                            Item,
                            WildCardChar,
                            "%");

                    }
                    else
                    {
                        Item = "%";

                    }
                    if (DueDate != null)
                    {
                        DueDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(DueDate));

                    }
                    //END

                }
                SQLStr = stringUtil.Concat(@"
					SELECT
					  CASE OrderTable
					    WHEN 'poitem' THEN 'PO'
					    WHEN 'preqitem' THEN 'PREQ'
					    WHEN 'trnitem' THEN 'TRNS'
					  END AS SupplyType,
					  CASE OrderTable
					    WHEN 'poitem' THEN
					      CASE
					        WHEN poitem.po_release = 0 THEN
					          LTRIM(CONVERT(nvarchar, poitem.po_num)) + '-' +
					          LTRIM(CONVERT(nvarchar, poitem.po_line))
					        ELSE
					          LTRIM(CONVERT(nvarchar, poitem.po_num)) + '-' +
					          LTRIM(CONVERT(nvarchar, poitem.po_line)) + '-' +
					          LTRIM(CONVERT(nvarchar, poitem.po_release))
					      END
					    WHEN 'preqitem' THEN
					      LTRIM(CONVERT(nvarchar, preqitem.req_num)) + '-' +
					      LTRIM(CONVERT(nvarchar, preqitem.req_line))
					    WHEN 'trnitem' THEN
					      LTRIM(CONVERT(nvarchar, trnitem.trn_num)) + '-' +
					      LTRIM(CONVERT(nvarchar, trnitem.trn_line))
					  END AS SupplyID,
					  mp.MATLTAG AS SupplyMatltag,
					  item.item,
					  ip.SUPPLY AS SupplyQuantity,
					  md.DELVDATE AS DueDate,
					  md.ORDERID AS ApsSupplyID,
					  md.RowPointer,
					  0 AS IsConsolidatedPLN
					FROM ", stringUtil.QuoteName(MATLDELV), @" md
					  JOIN item (nolock) ON item.item = md.MATERIALID
					  JOIN ", stringUtil.QuoteName(MATLPLAN), @" mp ON md.ORDERID = mp.ORDERID AND mp.PMATLTAG = 0
					  JOIN ", stringUtil.QuoteName(INVPLAN), @" ip ON mp.MATLTAG = ip.MATLTAG AND ip.SUPPLY > 0
					  LEFT JOIN poitem ON poitem.RowPointer = OrderRowPointer
					  LEFT JOIN preqitem ON preqitem.RowPointer = OrderRowPointer
					  LEFT JOIN trnitem ON trnitem.RowPointer = OrderRowPointer");
                SQLStr = stringUtil.Concat(SQLStr, @"
					   WHERE OrderTable ", (sQLUtil.SQLEqual(SupplyType, "PO") == true ? "= 'poitem' " : sQLUtil.SQLEqual(SupplyType, "PREQ") == true ? "= 'preqitem' " : sQLUtil.SQLEqual(SupplyType, "TRNS") == true ? "= 'trnitem' " : sQLUtil.SQLEqual(SupplyType, "MPS") == true ? "= '' " : sQLUtil.SQLEqual(SupplyType, "JOB") == true ? "= '' " : sQLUtil.SQLEqual(SupplyType, "PS") == true ? "= '' " : sQLUtil.SQLEqual(SupplyType, "INV") == true ? "= '' " : sQLUtil.SQLEqual(SupplyType, "PLN") == true ? "= '' " : "IN ('poitem', 'preqitem', 'trnitem') "));
                if (sQLUtil.SQLGreaterThan(SupplyMatltag, 0) == true)
                {
                    SQLStr = stringUtil.Concat(SQLStr, "AND mp.MATLTAG = @pSupplyMatltag ");

                }
                else
                {
                    //BEGIN
                    if (SupplyType != null && SupplyRowPtr != null)
                    {
                        SQLStr = stringUtil.Concat(SQLStr, "AND ", (sQLUtil.SQLEqual(SupplyType, "PO") == true ? "poitem.RowPointer = @pSupplyRowPtr " : sQLUtil.SQLEqual(SupplyType, "PREQ") == true ? "preqitem.RowPointer = @pSupplyRowPtr " : sQLUtil.SQLEqual(SupplyType, "TRNS") == true ? "trnitem.RowPointer = @pSupplyRowPtr " : "1=0 "));

                    }
                    else
                    {
                        //BEGIN
                        if (SupplyType != null && SupplyID != null)
                        {
                            SQLStr = stringUtil.Concat(SQLStr, (sQLUtil.SQLEqual(SupplyType, "PO") == true ? "AND poitem.po_num LIKE '%' + @pSupplyID " : sQLUtil.SQLEqual(SupplyType, "PREQ") == true ? "AND preqitem.req_num LIKE '%' + @pSupplyID " : sQLUtil.SQLEqual(SupplyType, "TRNS") == true ? "AND trnitem.trn_num LIKE '%' + @pSupplyID " : ""));

                        }
                        if (Item != null)
                        {
                            SQLStr = stringUtil.Concat(SQLStr, "AND item.item LIKE @pItem ");

                        }
                        if (DueDate != null)
                        {
                            SQLStr = stringUtil.Concat(SQLStr, "AND dbo.MidnightOf(md.DELVDATE) = @pDueDate ");

                        }
                        //END

                    }
                    //END

                }
                SQLStr = stringUtil.Concat(SQLStr, @" UNION
					SELECT
					  CASE OrderTable
					    WHEN 'rcpts' THEN 'MPS'
					    WHEN 'job' THEN CASE WHEN job.type <> 'J' THEN 'PS' ELSE 'JOB' END
					  END AS SupplyType,
					  CASE OrderTable
					    WHEN 'rcpts' THEN
					      LTRIM(CONVERT(nvarchar, rcpts.item)) + '-' +
					      LTRIM(CONVERT(nvarchar, rcpts.ref_num))
					    WHEN 'job' THEN
					      CASE WHEN job.type <> 'J' THEN
					        LTRIM(CONVERT(nvarchar, job.ps_num)) + '-' +
					        LTRIM(CONVERT(nvarchar, job.item)) + ' ' +
					        LTRIM(CONVERT(nvarchar, job_sch.end_date, 101))
					      ELSE
					        LTRIM(CONVERT(nvarchar, job.job)) + '-' +
					        LTRIM(CONVERT(nvarchar, job.suffix))
					      END
					  END AS SupplyID,
					  mp.MATLTAG AS SupplyMatltag,
					  item.item,
					  ip.Supply AS SupplyQuantity,
					  o.DUEDATE AS DueDate,
					  o.ORDERID AS ApsSupplyID,
					  o.RowPointer,
					  0 AS IsConsolidatedPLN
					FROM ", stringUtil.QuoteName(ORDER), @" o
					  JOIN item (nolock) ON item.item = o.MATERIALID
					  JOIN ", stringUtil.QuoteName(MATLPLAN), @" mp ON o.ORDERID = mp.ORDERID AND mp.PMATLTAG = 0 AND mp.MATERIALID = o.MATERIALID
					  JOIN ", stringUtil.QuoteName(INVPLAN), @" ip ON mp.MATLTAG = ip.MATLTAG AND ip.SUPPLY > 0
					  LEFT JOIN rcpts ON rcpts.RowPointer = OrderRowPointer
					  LEFT JOIN job ON job.RowPointer = OrderRowPointer
					  LEFT JOIN job_sch ON job_sch.job = job.job AND job_sch.suffix = job.suffix");
                SQLStr = stringUtil.Concat(SQLStr, @"
					   WHERE ", (sQLUtil.SQLEqual(SupplyType, "MPS") == true ? "OrderTable = 'rcpts' " : sQLUtil.SQLEqual(SupplyType, "JOB") == true ? "OrderTable = 'job' AND job.type = 'J' " : sQLUtil.SQLEqual(SupplyType, "PS") == true ? "OrderTable = 'job' AND job.type <> 'J' " : sQLUtil.SQLEqual(SupplyType, "PO") == true ? "OrderTable = '' " : sQLUtil.SQLEqual(SupplyType, "PREQ") == true ? "OrderTable = '' " : sQLUtil.SQLEqual(SupplyType, "TRNS") == true ? "OrderTable = '' " : sQLUtil.SQLEqual(SupplyType, "INV") == true ? "OrderTable = '' " : sQLUtil.SQLEqual(SupplyType, "PLN") == true ? "OrderTable = '' " : stringUtil.Concat("((OrderTable = 'rcpts') OR ", "((OrderTable = 'job'))) ")));
                if (sQLUtil.SQLGreaterThan(SupplyMatltag, 0) == true)
                {
                    SQLStr = stringUtil.Concat(SQLStr, "AND mp.MATLTAG = @pSupplyMatltag ");

                }
                else
                {
                    //BEGIN
                    if (SupplyType != null && SupplyRowPtr != null)
                    {
                        SQLStr = stringUtil.Concat(SQLStr, "AND ", (sQLUtil.SQLEqual(SupplyType, "MPS") == true ? "rcpts.RowPointer = @pSupplyRowPtr " : sQLUtil.SQLEqual(SupplyType, "JOB") == true ? "job.RowPointer = @pSupplyRowPtr " : sQLUtil.SQLEqual(SupplyType, "PS") == true ? "job.RowPointer = @pSupplyRowPtr " : "1=0 "));

                    }
                    else
                    {
                        //BEGIN
                        if (SupplyType != null && SupplyID != null)
                        {
                            if (sQLUtil.SQLEqual(SupplyType, "MPS") == true)
                            {
                                SQLStr = stringUtil.Concat(SQLStr, "AND rcpts.item LIKE '%' + @pSupplyID ");

                            }

                        }
                        if (sQLUtil.SQLEqual(SupplyType, "JOB") == true && sQLUtil.SQLEqual(stringUtil.CharIndex(
                                "-",
                                SupplyID), 0) == true)
                        {
                            SQLStr = stringUtil.Concat(SQLStr, "AND job.job LIKE '%' + @pSupplyID ");

                        }
                        if (sQLUtil.SQLEqual(SupplyType, "JOB") == true && sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                                "-",
                                SupplyID), 0) == true)
                        {
                            SQLStr = stringUtil.Concat(SQLStr, "AND LTRIM(job.job) = LEFT(@pSupplyID, CHARINDEX('-', @pSupplyID) - 1) AND job.suffix = SUBSTRING(@pSupplyID, CHARINDEX('-', @pSupplyID) + 1, LEN(@pSupplyID) - CHARINDEX('-', @pSupplyID)) ");

                        }
                        if (sQLUtil.SQLEqual(SupplyType, "PS") == true)
                        {
                            SQLStr = stringUtil.Concat(SQLStr, "AND job.ps_num LIKE '%' + @pSupplyID ");

                        }
                        if (Item != null)
                        {
                            SQLStr = stringUtil.Concat(SQLStr, "AND item.item LIKE @pItem ");

                        }
                        if (DueDate != null)
                        {
                            SQLStr = stringUtil.Concat(SQLStr, "AND dbo.MidnightOf(o.DUEDATE) = @pDueDate ");

                        }
                        //END

                    }
                    //END

                }
                if ((SupplyType == null) || (sQLUtil.SQLEqual(SupplyType, "PLN") == true))
                {
                    //BEGIN
                    SQLStr = stringUtil.Concat(SQLStr, @" UNION
						SELECT
						  'PLN' AS SupplyType,
						  apd.ref_num AS SupplyID,
						  apd.matltag AS SupplyMatltag,
						  apd.item,
						  apd.qty AS SupplyQuantity,
						  apd.due_date AS DueDate,
						  apd.ref_num AS ApsSupplyID,
						  apd.RowPointer,
						  CASE WHEN (mp.FLAGS & power(2,9)) > 0 THEN 1 ELSE 0 END AS IsConsolidatedPLN
						FROM apsplandetail apd
						  JOIN ", stringUtil.QuoteName(MATLPLAN), @" mp ON apd.matltag = mp.MATLTAG
						WHERE apd.ref_type = 'N' AND apd.is_demand = 0 AND apd.qty > 0");
                    if (sQLUtil.SQLGreaterThan(SupplyMatltag, 0) == true)
                    {
                        SQLStr = stringUtil.Concat(SQLStr, "AND apd.matltag = @pSupplyMatltag ");

                    }
                    else
                    {
                        //BEGIN
                        if (sQLUtil.SQLEqual(SupplyType, "PLN") == true && SupplyID != null)
                        {
                            SQLStr = stringUtil.Concat(SQLStr, "AND apd.ref_num = @pSupplyID ");

                        }
                        else
                        {
                            //BEGIN
                            if (Item != null)
                            {
                                SQLStr = stringUtil.Concat(SQLStr, "AND apd.item LIKE @pItem ");

                            }
                            if (DueDate != null)
                            {
                                SQLStr = stringUtil.Concat(SQLStr, "AND dbo.MidnightOf(apd.due_date) = @pDueDate ");

                            }
                            //END

                        }
                        //END

                    }
                    //END

                }
                if ((sQLUtil.SQLEqual(SupplyMatltag, 0) == true) && ((SupplyType == null) || (sQLUtil.SQLEqual(SupplyType, "INV") == true)))
                {
                    //BEGIN
                    SQLStr = stringUtil.Concat(SQLStr, @" UNION
						SELECT
						  'INV' AS SupplyType,
						  item.item AS SupplyID,
						  0 AS SupplyMatltag,
						  item.item,
						  mp.STARTLEV AS SupplyQuantity,
						  NULL AS DueDate,
						  mp.MATERIALID AS ApsSupplyID,
						  mp.RowPointer,
						  0 AS IsConsolidatedPLN
						FROM ", stringUtil.QuoteName(MSLPLAN), " mp JOIN item (nolock) ON item.item = mp.MATERIALID ");
                    if (Item != null)
                    {
                        SQLStr = stringUtil.Concat(SQLStr, "WHERE item.item LIKE @pItem ");

                    }
                    //END

                }
                SQLStr = stringUtil.Concat(SQLStr, "ORDER BY DueDate, SupplyID ");

                #region CRUD InsertByMethodCall
                (int? Severity, ICollectionLoadResponse Data) tempdblExecResult = iCLM_ApsGetSupplyUsageCRUD.LoadTempSupplyUsage(SupplyID, SupplyMatltag, SupplyRowPtr, Item, DueDate, SQLStr);
                Severity = tempdblExecResult.Severity;
                var tempdblLoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(tempdblExecResult.Data,
                    new List<string>() { "SupplyType",
                            "SupplyID",
                            "SupplyMatltag",
                            "Item",
                            "SupplyQuantity",
                            "DueDate",
                            "ApsSupplyID",
                            "RowPointer",
                            "IsConsolidatedPLN" });
                var tempdblInsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#tempdbl",
                    items: tempdblLoadResponse.Items);

                this.appDB.Insert(tempdblInsertRequest);

                #endregion InsertByMethodCall

                this.sQLExpressionExecutor.Execute(@"Declare
					@FilterString LongListType
					SELECT 'SELECT *' AS SelectionClause,
					       'FROM #tempdbl' AS FromClause,
					       '' AS WhereClause,
					       'ORDER BY DueDate, SupplyID' AS AdditionalClause,
					       'DueDate, SupplyID' AS KeyColumns,
					       @FilterString AS FilterString
					INTO   #DynamicParameters
					WHERE 1 = 2");

                #region CRUD LoadArbitrary
                var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"SelectionClause","'SELECT *'"},
                        {"FromClause","'FROM #tempdbl'"},
                        {"WhereClause","''"},
                        {"AdditionalClause","'ORDER BY DueDate, SupplyID'"},
                        {"KeyColumns","'DueDate, SupplyID'"},
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
        AltExtGen_CLM_ApsGetSupplyUsageSp(
            string AltExtGenSp,
            string SupplyType,
            string SupplyID,
            int? SupplyMatltag,
            Guid? SupplyRowPtr,
            string Item,
            DateTime? DueDate,
            string WildCardChar,
            int? AltNo,
            string FilterString)
        {
            RefType _SupplyType = SupplyType;
            OrderRefStrType _SupplyID = SupplyID;
            ApsItemTagType _SupplyMatltag = SupplyMatltag;
            RowPointerType _SupplyRowPtr = SupplyRowPtr;
            ItemType _Item = Item;
            DateType _DueDate = DueDate;
            StringType _WildCardChar = WildCardChar;
            ApsAltNoType _AltNo = AltNo;
            LongListType _FilterString = FilterString;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "SupplyType", _SupplyType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SupplyID", _SupplyID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SupplyMatltag", _SupplyMatltag, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SupplyRowPtr", _SupplyRowPtr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WildCardChar", _WildCardChar, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);

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
