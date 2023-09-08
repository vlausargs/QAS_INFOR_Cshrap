//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetShortages.cs

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
using System.Linq;
using CSI.CRUD.Production.APS;

namespace CSI.Production.APS
{
    public class CLM_ApsGetShortages : ICLM_ApsGetShortages
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ICLM_ApsGetShortagesCRUD iCLM_ApsGetShortagesCRUD;
        readonly IApsTransferOutOrderId iApsTransferOutOrderId;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICLM_ApsGetDemandId iCLM_ApsGetDemandId;
        readonly IApsForecastOrderId iApsForecastOrderId;
        readonly ISSSFSApsSROOrderID iSSSFSApsSROOrderID;
        readonly ITransactionFactory transactionFactory;
        readonly IApsProjectOrderId iApsProjectOrderId;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly ISQLCollectionLoad sQLCollectionLoad;
        readonly IExpandKyByType iExpandKyByType;
        readonly IApsGetOrderID2 iApsGetOrderID2;
        readonly IScalarFunction scalarFunction;
        readonly IApsMpsOrderId iApsMpsOrderId;
        readonly IApsJobOrderId iApsJobOrderId;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IApsOrderId iApsOrderId;
        readonly IStringUtil stringUtil;
        readonly IDayEndOf iDayEndOf;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IApsSafetyStockOrderId iApsSafetyStockOrderId;

        public CLM_ApsGetShortages(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ICLM_ApsGetShortagesCRUD iCLM_ApsGetShortagesCRUD,
            IApsTransferOutOrderId iApsTransferOutOrderId,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICLM_ApsGetDemandId iCLM_ApsGetDemandId,
            IApsForecastOrderId iApsForecastOrderId,
            ISSSFSApsSROOrderID iSSSFSApsSROOrderID,
            ITransactionFactory transactionFactory,
            IApsProjectOrderId iApsProjectOrderId,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            ISQLCollectionLoad sQLCollectionLoad,
            IExpandKyByType iExpandKyByType,
            IApsGetOrderID2 iApsGetOrderID2,
            IScalarFunction scalarFunction,
            IApsMpsOrderId iApsMpsOrderId,
            IApsJobOrderId iApsJobOrderId,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IDateTimeUtil dateTimeUtil,
            IApsOrderId iApsOrderId,
            IStringUtil stringUtil,
            IDayEndOf iDayEndOf,
            ISQLValueComparerUtil sQLUtil,
            IApsSafetyStockOrderId iApsSafetyStockOrderId)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.iCLM_ApsGetShortagesCRUD = iCLM_ApsGetShortagesCRUD;
            this.iApsTransferOutOrderId = iApsTransferOutOrderId;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iCLM_ApsGetDemandId = iCLM_ApsGetDemandId;
            this.iApsForecastOrderId = iApsForecastOrderId;
            this.iSSSFSApsSROOrderID = iSSSFSApsSROOrderID;
            this.transactionFactory = transactionFactory;
            this.iApsProjectOrderId = iApsProjectOrderId;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.sQLCollectionLoad = sQLCollectionLoad;
            this.iExpandKyByType = iExpandKyByType;
            this.iApsGetOrderID2 = iApsGetOrderID2;
            this.scalarFunction = scalarFunction;
            this.iApsMpsOrderId = iApsMpsOrderId;
            this.iApsJobOrderId = iApsJobOrderId;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.dateTimeUtil = dateTimeUtil;
            this.iApsOrderId = iApsOrderId;
            this.stringUtil = stringUtil;
            this.iDayEndOf = iDayEndOf;
            this.sQLUtil = sQLUtil;
            this.iApsSafetyStockOrderId = iApsSafetyStockOrderId;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_ApsGetShortagesSp(
            string DemandType,
            string DemandRef,
            string Item,
            string PlannerCode,
            DateTime? StartDate,
            DateTime? DueDate,
            int? AltNo,
            string ProductCode = null,
            string FilterString = null)
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
                string ParmList = null;
                string ORDER = null;
                string MATLPLAN = null;
                string MATL = null;
                string INVPLAN = null;
                string ORDPLAN = null;
                string ApsOrderID = null;
                string WhereClause = null;
                string SHORTSPLAN = null;
                int? DemandRefNumber = null;
                int? iPos = null;
                string Chunk = null;
                int? iHyphen = null;
                string Part1 = null;
                string Part2 = null;
                string Part3 = null;
                string Part4 = null;
                ApsOrderType _OrderID = DBNull.Value;
                string OrderID = null;
                string OrderNum = null;
                int? OrderLine = null;
                int? OrderRelease = null;
                string ParseItem = null;
                DateTime? Date = null;
                string DateStr = null;
                JobType _Job = DBNull.Value;
                string Job = null;
                SuffixType _Suffix = DBNull.Value;
                int? Suffix = null;
                string SQLGuessCmd = null;
                string SQLGuessParms = null;
                int? RecordFound = null;
                string Whse = null;
                string CustNum = null;
                string Infobar = null;
                string SelectionClause = null;
                string FromClause = null;
                string AdditionalClause = null;
                string KeyColumns = null;
                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ApsGetShortagesSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ApsGetShortagesSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_ApsGetShortagesSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                        var ALTGEN = AltExtGen_CLM_ApsGetShortagesSp(ALTGEN_SpName,
                            DemandType,
                            DemandRef,
                            Item,
                            PlannerCode,
                            StartDate,
                            DueDate,
                            AltNo,
                            ProductCode,
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
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ApsGetShortagesSp") != null)
                {
                    var EXTGEN = AltExtGen_CLM_ApsGetShortagesSp("dbo.EXTGEN_CLM_ApsGetShortagesSp",
                        DemandType,
                        DemandRef,
                        Item,
                        PlannerCode,
                        StartDate,
                        DueDate,
                        AltNo,
                        ProductCode,
                        FilterString);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                Severity = 0;
                SQLStr = "";
                ORDER = stringUtil.Concat("ORDER", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                ORDER = stringUtil.QuoteName(ORDER);
                INVPLAN = stringUtil.Concat("INVPLAN", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                INVPLAN = stringUtil.QuoteName(INVPLAN);
                MATLPLAN = stringUtil.Concat("MATLPLAN", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                MATLPLAN = stringUtil.QuoteName(MATLPLAN);
                MATL = stringUtil.Concat("MATL", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                MATL = stringUtil.QuoteName(MATL);
                ORDPLAN = stringUtil.Concat("ORDPLAN", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                ORDPLAN = stringUtil.QuoteName(ORDPLAN);
                SHORTSPLAN = stringUtil.Concat("SHORTSPLAN", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                SHORTSPLAN = stringUtil.QuoteName(SHORTSPLAN);
                this.sQLExpressionExecutor.Execute(@"CREATE TABLE #Demands (
					    DemandTag  INT          ,
					    DemandType NVARCHAR (10) COLLATE DATABASE_DEFAULT,
					    DemandRef  NVARCHAR (80) COLLATE DATABASE_DEFAULT,
					    DemandId   NVARCHAR (80) COLLATE DATABASE_DEFAULT PRIMARY KEY (DemandTag)
					)");
                if (sQLUtil.SQLEqual(stringUtil.IsNull(
                        DemandType,
                        ""), "PLN2") == true)
                {
                    //BEGIN
                    DemandType = "PLN";
                    DemandRef = stringUtil.Reverse(stringUtil.RTrim(DemandRef));
                    iPos = convertToUtil.ToInt32(stringUtil.CharIndex(
                        "(",
                            DemandRef));
                    if (sQLUtil.SQLGreaterThan(iPos, 0) == true)
                    {
                        //BEGIN
                        DemandRef = stringUtil.Reverse(stringUtil.Substring(
                            DemandRef,
                            2,
                            iPos - 2));
                        DemandRefNumber = convertToUtil.ToInt32((sQLUtil.SQLEqual(stringUtil.IsNumeric(DemandRef), 1) == true ? convertToUtil.ToInt32(DemandRef) : -1));
                        //END

                    }
                    else
                    {
                        DemandRefNumber = -1;

                    }
                    //END

                }
                else
                {
                    if (sQLUtil.SQLEqual(stringUtil.IsNull(
                            DemandType,
                            ""), "PLN") == true)
                    {
                        //BEGIN
                        DemandRefNumber = convertToUtil.ToInt32((sQLUtil.SQLEqual(stringUtil.IsNumeric(DemandRef), 1) == true ? convertToUtil.ToInt32(DemandRef) : -1));
                        //END

                    }

                }
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#MATLPLAN") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #MATLPLAN");

                }

                this.sQLExpressionExecutor.Execute(@"SELECT CONVERT (NVARCHAR (10), 'PLN') AS DemandType,
					       CONVERT (NVARCHAR (80), mp1.MATLTAG) AS DemandRef,
					       CONVERT (NVARCHAR (80), mp1.MATLTAG) AS DemandId,
					       mp1.MATLTAG AS Matltag,
					       i1.item AS Item,
					       i1.description AS ItemDescr,
					       i1.low_level AS LowLevel,
					       i1.plan_code AS PlannerCode,
					       i1.product_code AS ProductCode,
					       mp1.ORIGQTY AS Quantity,
					       mp1.STARTDATE AS StartDate,
					       mp1.ENDDATE AS DueDate,
					       CONVERT (FLOAT, 0.0) AS DaysLate,
					       mp1.RowPointer AS RowPointer
					INTO   #MATLPLAN
					FROM   SHORTSPLAN000 AS sh
					       INNER JOIN
					       MATLPLAN000 AS mp1
					       ON sh.MATLTAG = mp1.MATLTAG
					          AND sh.ORDERID = mp1.ORDERID
					       INNER JOIN
					       item AS i1 WITH (NOLOCK)
					       ON i1.item = mp1.materialid
					WHERE  1 = 2");
                Severity = 0;
                if (DueDate != null)
                {
                    DueDate = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(DueDate));

                }
                if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLNotEqual(stringUtil.IsNull(
                            DemandType,
                            ""), ""), sQLUtil.SQLNotEqual(stringUtil.IsNull(
                            DemandRef,
                            ""), ""))))
                {
                    //BEGIN
                    this.sQLExpressionExecutor.Execute(@"CREATE TABLE #DemandRefs (
						    OrderId NVARCHAR (80) COLLATE DATABASE_DEFAULT
						)");

                    #region CRUD InsertByMethodCall
                    //Please Generate the bounce for this stored procedure:CLM_ApsGetDemandIdSp
                    var DemandRefsExecResult = this.iCLM_ApsGetDemandId.CLM_ApsGetDemandIdSp(
                        PDemandType: DemandType,
                        AltNo: AltNo);
                    var DemandRefsLoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(DemandRefsExecResult.Data,
                        new List<string>() { "OrderId" });
                    var DemandRefsInsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#DemandRefs",
                        items: DemandRefsLoadResponse.Items);

                    this.appDB.Insert(DemandRefsInsertRequest);

                    #endregion InsertByMethodCall

                    if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(tableName: "#DemandRefs",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("OrderId = {0}", DemandRef))
                        )))
                    {
                        //BEGIN
                        this.sQLExpressionExecutor.Execute("DROP TABLE #Demands");
                        this.sQLExpressionExecutor.Execute("DROP TABLE #DemandRefs");
                        return (Data, Severity);//END

                    }
                    this.sQLExpressionExecutor.Execute("DROP TABLE #DemandRefs");
                    //END

                }
                if (DemandType == null && DemandRef != null)
                {
                    //BEGIN
                    Chunk = stringUtil.Reverse(DemandRef);
                    iHyphen = convertToUtil.ToInt32(stringUtil.CharIndex(
                        "-",
                        Chunk));
                    if (sQLUtil.SQLGreaterThan(iHyphen, 0) == true)
                    {
                        //BEGIN
                        Part1 = stringUtil.Substring(
                            Chunk,
                            1,
                            iHyphen - 1);
                        Chunk = stringUtil.Substring(
                            Chunk,
                            iHyphen + 1,
                            99);
                        iHyphen = convertToUtil.ToInt32(stringUtil.CharIndex(
                            "-",
                            Chunk));
                        //END

                    }
                    else
                    {
                        //BEGIN
                        Part1 = Chunk;
                        Chunk = null;
                        //END

                    }
                    if (sQLUtil.SQLGreaterThan(iHyphen, 0) == true)
                    {
                        //BEGIN
                        Part2 = stringUtil.Substring(
                            Chunk,
                            1,
                            iHyphen - 1);
                        Chunk = stringUtil.Substring(
                            Chunk,
                            iHyphen + 1,
                            99);
                        iHyphen = convertToUtil.ToInt32(stringUtil.CharIndex(
                            "-",
                            Chunk));
                        //END

                    }
                    else
                    {
                        //BEGIN
                        Part2 = Chunk;
                        Chunk = null;
                        //END

                    }
                    if (sQLUtil.SQLGreaterThan(iHyphen, 0) == true)
                    {
                        //BEGIN
                        Part3 = stringUtil.Substring(
                            Chunk,
                            1,
                            iHyphen - 1);
                        Chunk = stringUtil.Substring(
                            Chunk,
                            iHyphen + 1,
                            99);
                        iHyphen = convertToUtil.ToInt32(stringUtil.CharIndex(
                            "-",
                            Chunk));
                        //END

                    }
                    else
                    {
                        //BEGIN
                        Part3 = Chunk;
                        Chunk = null;
                        //END

                    }
                    Part1 = stringUtil.Reverse(Part1);
                    Part2 = stringUtil.Reverse(Part2);
                    Part3 = stringUtil.Reverse(Part3);
                    Part4 = stringUtil.Reverse(Chunk);
                    if (Part3 == null)
                    {
                        //BEGIN
                        Chunk = Part1;
                        Part1 = Part2;
                        Part2 = Chunk;
                        //END

                    }
                    else
                    {
                        if (Part4 == null)
                        {
                            //BEGIN
                            Chunk = Part1;
                            Part1 = Part3;
                            Part3 = Chunk;
                            //END

                        }
                        else
                        {
                            //BEGIN
                            Chunk = Part1;
                            Part1 = Part4;
                            Part4 = Chunk;
                            Chunk = Part2;
                            Part2 = Part3;
                            Part3 = Chunk;
                            //END

                        }

                    }
                    SQLGuessCmd = stringUtil.Concat(@"SELECT ORDERID FROM ", MATLPLAN, " WHERE ORDERID = @OrderID");
                    SQLGuessParms = "@OrderID ApsOrderType";
                    OrderNum = this.iExpandKyByType.ExpandKyByTypeFn(
                        "CoNumType",
                        Part1);
                    if (sQLUtil.SQLEqual(stringUtil.IsNumeric(Part2), 1) == true)
                    {
                        //BEGIN
                        OrderLine = convertToUtil.ToInt32(Part2);
                        OrderRelease = stringUtil.IsNull(
                            convertToUtil.ToInt32(Part3),
                            0);
                        OrderID = this.iApsOrderId.ApsOrderIdFn(
                            OrderNum,
                            OrderLine,
                            OrderRelease);

                        RecordFound = 0;
                        var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQLGuessCmd
                        , SQLGuessParms
                        , OrderID);
                        /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */

                        if (!(execResult.Data is null))
                            RecordFound = 1;
                        if (sQLUtil.SQLEqual(RecordFound, 1) == true)
                        {
                            //BEGIN
                            DemandType = "CO";
                            goto END_OF_DEMAND_REF;
                            //END

                        }
                        //END

                    }
                    iHyphen = convertToUtil.ToInt32(stringUtil.CharIndex(
                        " ",
                        DemandRef));
                    if (sQLUtil.SQLGreaterThan(iHyphen, 0) == true)
                    {
                        //BEGIN
                        DateStr = stringUtil.Substring(
                            DemandRef,
                            iHyphen + 1,
                            99);
                        if (sQLUtil.SQLEqual(dateTimeUtil.IsDate(DateStr), 1) == true)
                        {
                            //BEGIN
                            Date = convertToUtil.ToDateTime(DateStr);
                            ParseItem = stringUtil.Substring(
                                DemandRef,
                                1,
                                iHyphen - 1);
                            OrderID = this.iApsForecastOrderId.ApsForecastOrderIdFn(
                                ParseItem,
                                Whse,
                                CustNum,
                                Date);

                            RecordFound = 0;
                            var execResult1 = sQLCollectionLoad.ExecuteDynamicQuery(SQLGuessCmd
                            , SQLGuessParms
                            , OrderID);
                            /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */
                            if (!(execResult1.Data is null))
                                RecordFound = 1;
                            if (sQLUtil.SQLEqual(RecordFound, 1) == true)
                            {
                                //BEGIN
                                DemandType = "FCST";
                                goto END_OF_DEMAND_REF;
                                //END

                            }
                            //END

                        }
                        //END

                    }
                    OrderNum = this.iExpandKyByType.ExpandKyByTypeFn(
                        "ProjNumType",
                        Part1);
                    if (sQLUtil.SQLEqual(stringUtil.IsNumeric(Part2), 1) == true)
                    {
                        //BEGIN
                        OrderLine = convertToUtil.ToInt32(Part2);
                        OrderRelease = stringUtil.IsNull(
                            convertToUtil.ToInt32(Part3),
                            0);
                        OrderID = this.iApsProjectOrderId.ApsProjectOrderIdFn(
                            OrderNum,
                            OrderLine,
                            OrderRelease);

                        RecordFound = 0;
                        var execResult2 = sQLCollectionLoad.ExecuteDynamicQuery(SQLGuessCmd
                        , SQLGuessParms
                        , OrderID);
                        /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */
                        if (!(execResult2.Data is null))
                            RecordFound = 1;
                        if (sQLUtil.SQLEqual(RecordFound, 1) == true)
                        {
                            //BEGIN
                            DemandType = "PROJ";
                            goto END_OF_DEMAND_REF;
                            //END

                        }
                        //END

                    }
                    OrderNum = this.iExpandKyByType.ExpandKyByTypeFn(
                        "TrnNumType",
                        Part1);
                    if (sQLUtil.SQLEqual(stringUtil.IsNumeric(Part2), 1) == true)
                    {
                        //BEGIN
                        OrderLine = convertToUtil.ToInt32(Part2);
                        OrderID = this.iApsTransferOutOrderId.ApsTransferOutOrderIdFn(
                            OrderNum,
                            OrderLine);
                        if (existsChecker.Exists(tableName: "MATLPLAN000",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("ORDERID = {0}", OrderID))
                        )
                        {
                            //BEGIN
                            DemandType = "TRNS";
                            goto END_OF_DEMAND_REF;
                            //END

                        }
                        //END

                    }
                    DemandRef = stringUtil.Reverse(DemandRef);
                    iHyphen = convertToUtil.ToInt32(stringUtil.CharIndex(
                        "-",
                        DemandRef));
                    if (sQLUtil.SQLGreaterThan(iHyphen, 0) == true)
                    {
                        //BEGIN
                        Chunk = stringUtil.Reverse(stringUtil.Substring(
                            DemandRef,
                            1,
                            iHyphen - 1));
                        ParseItem = stringUtil.Reverse(stringUtil.Substring(
                            DemandRef,
                            iHyphen + 1,
                            99));
                        DemandRef = stringUtil.Reverse(DemandRef);
                        OrderID = this.iApsMpsOrderId.ApsMpsOrderIdFn(
                            ParseItem,
                            Chunk);

                        RecordFound = 0;
                        var execResult3 = sQLCollectionLoad.ExecuteDynamicQuery(SQLGuessCmd
                        , SQLGuessParms
                        , OrderID);
                        /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */
                        if (!(execResult3.Data is null))
                            RecordFound = 1;
                        if (sQLUtil.SQLEqual(RecordFound, 1) == true)
                        {
                            //BEGIN
                            DemandType = "MPS";
                            goto END_OF_DEMAND_REF;
                            //END

                        }
                        //END

                    }
                    else
                    {
                        DemandRef = stringUtil.Reverse(DemandRef);

                    }

                    #region CRUD LoadToRecord
                    var invparmsLoadRequestForScalarSubQuery = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        { "col0","CAST (NULL AS NVARCHAR)"},
                        { "u0","invparms.def_whse"},
                    },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "invparms",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("invparms.parm_key = 0"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));

                    var invparmsLoadResponseForScalarSubQuery = this.appDB.Load(invparmsLoadRequestForScalarSubQuery);

                    #endregion  LoadToRecord
                    foreach (var invparmsItem in invparmsLoadResponseForScalarSubQuery.Items)
                    {
                        invparmsItem.SetValue("col0", this.iApsSafetyStockOrderId.ApsSafetyStockOrderIdFn(DemandRef, invparmsItem.GetValue<string>("u0")));
                    };
                    OrderID = ((invparmsLoadResponseForScalarSubQuery.Items != null && invparmsLoadResponseForScalarSubQuery.Items.Count != 0) ? (invparmsLoadResponseForScalarSubQuery.Items.FirstOrDefault().GetValue<string>("col0")) : null);

                    RecordFound = 0;
                    var execResult4 = sQLCollectionLoad.ExecuteDynamicQuery(SQLGuessCmd
                    , SQLGuessParms
                    , OrderID);
                    /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */
                    if (!(execResult4.Data is null))
                        RecordFound = 1;
                    if (sQLUtil.SQLEqual(RecordFound, 1) == true)
                    {
                        //BEGIN
                        DemandType = "SSD";
                        goto END_OF_DEMAND_REF;
                        //END

                    }
                    iHyphen = convertToUtil.ToInt32(stringUtil.CharIndex(
                        "-",
                        DemandRef));
                    if (sQLUtil.SQLGreaterThan(iHyphen, 0) == true)
                    {
                        //BEGIN
                        OrderNum = stringUtil.Substring(
                            DemandRef,
                            1,
                            iHyphen - 1);
                        Chunk = stringUtil.Substring(
                            DemandRef,
                            iHyphen + 1,
                            99);
                        iHyphen = convertToUtil.ToInt32(stringUtil.Len(Chunk));
                        if (sQLUtil.SQLGreaterThan(iHyphen, 10) == true)
                        {
                            //BEGIN
                            ParseItem = stringUtil.Substring(
                                Chunk,
                                1,
                                iHyphen - 10);
                            DateStr = stringUtil.Substring(
                                Chunk,
                                iHyphen - 10 + 1,
                                10);
                            if (sQLUtil.SQLEqual(dateTimeUtil.IsDate(DateStr), 1) == true)
                            {
                                //BEGIN
                                Date = convertToUtil.ToDateTime(DateStr);

                                #region CRUD LoadToVariable
                                var jobLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_Job,"job.job"},
                                        {_Suffix,"job.suffix"},
                                    },
                                    loadForChange: false,
                                    lockingType: LockingType.None,
                                    tableName: "job",
                                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                                    whereClause: collectionLoadRequestFactory.Clause("job.ps_num = {0} AND job.midnight_of_job_sch_end_date = {1}", OrderNum, Date),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var jobLoadResponse = this.appDB.Load(jobLoadRequest);
                                if (jobLoadResponse.Items.Count > 0)
                                {
                                    Job = _Job;
                                    Suffix = _Suffix;
                                }
                                #endregion  LoadToVariable

                                OrderID = this.iApsJobOrderId.ApsJobOrderIdFn(
                                    Job,
                                    Suffix);

                                RecordFound = 0;
                                var execResult5 = sQLCollectionLoad.ExecuteDynamicQuery(SQLGuessCmd
                                , SQLGuessParms
                                , OrderID);
                                /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */
                                if (!(execResult5.Data is null))
                                    RecordFound = 1;
                                if (sQLUtil.SQLEqual(RecordFound, 1) == true)
                                {
                                    //BEGIN
                                    DemandType = "PS";
                                    goto END_OF_DEMAND_REF;
                                    //END

                                }
                                //END

                            }
                            //END

                        }
                        //END

                    }
                    OrderNum = this.iExpandKyByType.ExpandKyByTypeFn(
                        "TrnNumType",
                        Part1);
                    if (sQLUtil.SQLEqual(stringUtil.IsNumeric(Part2), 1) == true)
                    {
                        //BEGIN
                        OrderLine = convertToUtil.ToInt32(Part2);
                        OrderID = this.iApsJobOrderId.ApsJobOrderIdFn(
                            OrderNum,
                            OrderLine);

                        RecordFound = 0;
                        var execResult6 = sQLCollectionLoad.ExecuteDynamicQuery(SQLGuessCmd
                        , SQLGuessParms
                        , OrderID);
                        /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */
                        if (!(execResult6.Data is null))
                            RecordFound = 1;
                        if (sQLUtil.SQLEqual(RecordFound, 1) == true)
                        {
                            //BEGIN
                            DemandType = "JOB";
                            goto END_OF_DEMAND_REF;
                            //END

                        }
                        //END

                    }
                    if (sQLUtil.SQLEqual(stringUtil.IsNumeric(Part4), 1) == true)
                    {
                        //BEGIN
                        OrderNum = this.iExpandKyByType.ExpandKyByTypeFn(
                            "FSSRONumType",
                            Part1);
                        OrderID = this.iSSSFSApsSROOrderID.SSSFSApsSROOrderIDFn(
                            OrderNum,
                            convertToUtil.ToInt32(Part2),
                            convertToUtil.ToInt32(Part3),
                            convertToUtil.ToInt32(Part4));

                        RecordFound = 0;
                        var execResult7 = sQLCollectionLoad.ExecuteDynamicQuery(SQLGuessCmd
                        , SQLGuessParms
                        , OrderID);
                        /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */
                        if (!(execResult7.Data is null))
                            RecordFound = 1;

                        if (sQLUtil.SQLEqual(RecordFound, 1) == true)
                        {
                            //BEGIN
                            DemandType = "SRO";
                            goto END_OF_DEMAND_REF;
                            //END

                        }
                        //END

                    }
                END_OF_DEMAND_REF:;
                    //END

                }
                if (sQLUtil.SQLNotEqual(stringUtil.IsNull(
                        DemandType,
                        ""), "PLN") == true)
                {
                    //BEGIN
                    ApsOrderID = this.iApsGetOrderID2.ApsGetOrderID2Fn(
                        DemandType,
                        DemandRef);
                    if (sQLUtil.SQLEqual(stringUtil.IsNull(
                            ApsOrderID,
                            ""), "%") == true)
                    {
                        ApsOrderID = null;

                    }
                    SQLStr = stringUtil.Concat(@"INSERT INTO #Demands
						   SELECT DISTINCT
						      mpdemand.matltag as DemandTag,
						      '' as DemandType,
						      '' as DemandRef,
						      dbo.ApsGetDemandID(o.ORDERID) AS DemandId
						   FROM ", SHORTSPLAN, @"sh
						      JOIN ", ORDER, @" o ON o.ORDERID = sh.ORDERID
						      JOIN ", ORDPLAN, @" op ON op.ORDERID = o.ORDERID
						      JOIN ", MATLPLAN, @" mp ON mp.MATLTAG = sh.MATLTAG
						      JOIN ", MATLPLAN, @" mpdemand ON mpdemand.ORDERID = o.ORDERID and mpdemand.MATERIALID = o.MATERIALID
						      LEFT JOIN item (nolock) enditem ON enditem.item = o.MATERIALID
						   WHERE 1=1 ", (ProductCode == null ? "" : stringUtil.Concat(@"
						      AND ISNULL(enditem.product_code, '') ", (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                        "%",
                        ProductCode), 0) == true ? "LIKE" : "="), " @PRC")), (PlannerCode == null ? "" : stringUtil.Concat(@"
						      AND ISNULL(enditem.plan_code, '') ", (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                        "%",
                        PlannerCode), 0) == true ? "LIKE" : "="), " @PLC")), " AND (mp.PMATLTAG <> 0 or mp.MATERIALID <> o.MATERIALID)", (Item == null ? "" : stringUtil.Concat(@"
						      AND o.MATERIALID ", (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                        "%",
                        Item), 0) == true ? "LIKE" : "="), " @IT")), (StartDate == null ? "" : @"
						      AND mp.STARTDATE >= @SD"), (DueDate == null ? "" : @"
						      AND op.DUEDATE <= @DD"), @"
						      AND o.ORDERID ", (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                        "%",
                        ApsOrderID), 0) == true ? "LIKE" : "="), " ISNULL(@OID, o.ORDERID)");
                    ParmList = @"@IT ItemType, @PLC UserCodeType, @PRC ProductCodeType, @SD DateType, @DD DateType, @DT RefType, @OID ApsOrderType";

                    var execResult8 = sQLCollectionLoad.ExecuteDynamicQuery(SQLStr
                    , ParmList
                    , Item
                    , PlannerCode
                    , ProductCode
                    , StartDate
                    , DueDate
                    , DemandType
                    , ApsOrderID);
                    Severity = execResult8.Severity;
                    /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */

                    //END

                }
                else
                {
                    //BEGIN
                    SQLStr = stringUtil.Concat(@"
						   ;WITH refbom (orderid, materialid, plntag, matltag, pmatltag) AS
						   (
						       SELECT mp.ORDERID, mp.materialid, mp.matltag, mp.matltag, -1
						          FROM ", MATLPLAN, @" mp with (readuncommitted)
						          WHERE (mp.matltag = @DRN OR (@DRN = -1 AND mp.pmatltag <> 0))
									AND EXISTS(SELECT 1 FROM ", INVPLAN, @" ip WHERE ip.matltag = mp.matltag AND ip.schtype IN (4,6,7,8) AND (ip.schflags & power(2,6) = 0))

						       UNION ALL

						       SELECT child.orderid, child.materialid, parent.plntag, child.matltag, child.pmatltag
						          FROM ", MATLPLAN, @" child with (readuncommitted)
						          JOIN refbom parent on parent.matltag = child.pmatltag

						       UNION ALL

						       SELECT child.orderid, child.materialid, parent.plntag, child.matltag, child.pmatltag
						          FROM ", MATLPLAN, @" supply with (readuncommitted)
						          JOIN ", INVPLAN, @" ip with (readuncommitted) on ip.supmatltag = supply.matltag
						          JOIN ", MATLPLAN, @" child with (readuncommitted) on child.pmatltag = supply.matltag
						          JOIN refbom parent on parent.matltag = ip.matltag
						   )
						   INSERT INTO #Demands
						   SELECT DISTINCT
						      rb.plntag AS demandtag,
						      '' AS demandtype,
						      '' AS demandref,
						      'PLN ' + CONVERT(nvarchar, rb.plntag) AS demandid
						   FROM
						      refbom rb
						      JOIN ", SHORTSPLAN, @" sh ON rb.orderid = sh.orderid AND rb.matltag = sh.matltag AND rb.pmatltag <> -1
						      JOIN ", ORDER, @" o ON o.ORDERID = sh.ORDERID
						      JOIN ", ORDPLAN, @" op ON op.ORDERID = o.ORDERID
						      JOIN ", MATLPLAN, @" mp ON mp.matltag = rb.matltag
						      JOIN ", MATLPLAN, @" plnmp ON plnmp.matltag = rb.plntag
						      LEFT JOIN item plnitem (nolock) ON plnitem.item = plnmp.materialid
						   WHERE
						      1=1 ", (ProductCode == null ? "" : stringUtil.Concat(@"
						      AND ISNULL(plnitem.product_code, '') ", (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                        "%",
                        ProductCode), 0) == true ? "LIKE" : "="), " @PRC")), (PlannerCode == null ? "" : stringUtil.Concat(@"
						      AND ISNULL(plnitem.plan_code, '') ", (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                        "%",
                        PlannerCode), 0) == true ? "LIKE" : "="), " @PLC")), (Item == null ? "" : stringUtil.Concat(@"
						      AND plnmp.materialid ", (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                        "%",
                        Item), 0) == true ? "LIKE" : "="), " @IT")), (StartDate == null ? "" : @"
						      AND mp.STARTDATE >= @SD"), (DueDate == null ? "" : @"
						      AND op.DUEDATE <= @DD"));
                    ParmList = @"@DRN int, @PLC UserCodeType, @IT ItemType, @SD DateType, @DD DateType, @PRC ProductCodeType";

                    var execResult9 = sQLCollectionLoad.ExecuteDynamicQuery(SQLStr
                    , ParmList
                    , DemandRefNumber
                    , PlannerCode
                    , Item
                    , StartDate
                    , DueDate
                    , ProductCode);
                    Severity = execResult9.Severity;
                    /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */

                    //END

                }

                #region CRUD LoadToRecord
                var DemandsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"DemandType","dem.DemandType"},
                        {"DemandRef","dem.DemandRef"},
                        {"u0","dem.DemandId"},
                    },
                    tableName: "#Demands",
                    loadForChange: true,
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(" AS dem"),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var DemandsLoadResponse = this.appDB.Load(DemandsLoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var DemandsItem in DemandsLoadResponse.Items)
                {
                    DemandsItem.SetValue<string>("DemandType", (sQLUtil.SQLEqual(stringUtil.Left(DemandsItem.GetDeletedValue<string>("u0"), 3), "XFD") == true ? "XFD" :
                    sQLUtil.SQLEqual(stringUtil.Left(DemandsItem.GetDeletedValue<string>("u0"), 3), "WTD") == true ? "WTD" : stringUtil.Left(DemandsItem.GetDeletedValue<string>("u0"), convertToUtil.ToInt32(stringUtil.CharIndex(
                        " ",
                        DemandsItem.GetDeletedValue<string>("u0"))) - 1)));
                    DemandsItem.SetValue<string>("DemandRef", (sQLUtil.SQLEqual(stringUtil.Left(DemandsItem.GetDeletedValue<string>("u0"), 3), "XFD") == true ? stringUtil.Substring(
                        DemandsItem.GetDeletedValue<string>("u0"),
                        convertToUtil.ToInt32(stringUtil.CharIndex(
                                "-",
                                DemandsItem.GetDeletedValue<string>("u0"))) + 1,
                        stringUtil.Len(DemandsItem.GetDeletedValue<string>("u0")) - convertToUtil.ToInt32(stringUtil.CharIndex(
                                "-",
                                DemandsItem.GetDeletedValue<string>("u0")))) :
                    sQLUtil.SQLEqual(stringUtil.Left(DemandsItem.GetDeletedValue<string>("u0"), 3), "WTD") == true ? convertToUtil.ToString(DemandsItem.GetDeletedValue<string>("u0")) : stringUtil.LTrim(stringUtil.Substring(
                        DemandsItem.GetDeletedValue<string>("u0"),
                        convertToUtil.ToInt32(stringUtil.CharIndex(
                                " ",
                                DemandsItem.GetDeletedValue<string>("u0"))) + 1,
                        stringUtil.Len(DemandsItem.GetDeletedValue<string>("u0")) - convertToUtil.ToInt32(stringUtil.CharIndex(
                                " ",
                                DemandsItem.GetDeletedValue<string>("u0")))))));
                };

                var DemandsRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#Demands",
                    items: DemandsLoadResponse.Items);

                this.appDB.Update(DemandsRequestUpdate);
                #endregion UpdateByRecord
                #region CRUD InsertByMethodCall
                (int? Severity, ICollectionLoadResponse Data) MATLPLAN1ExecResult = iCLM_ApsGetShortagesCRUD.LoadShortageExtraData(DemandType, DemandRef, Item, PlannerCode, StartDate, DueDate, ProductCode, ORDER, MATLPLAN, MATL, ORDPLAN, DemandRefNumber);
                Severity = MATLPLAN1ExecResult.Severity;
                var MATLPLAN1LoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(MATLPLAN1ExecResult.Data,
                    new List<string>() { "DemandType",
                            "DemandRef",
                            "DemandId",
                            "Matltag",
                            "Item",
                            "ItemDescr",
                            "LowLevel",
                            "PlannerCode",
                            "ProductCode",
                            "Quantity",
                            "StartDate",
                            "DueDate",
                            "DaysLate",
                            "RowPointer" });
                var MATLPLAN1InsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#MATLPLAN",
                    items: MATLPLAN1LoadResponse.Items);

                this.appDB.Insert(MATLPLAN1InsertRequest);

                #endregion InsertByMethodCall

                SelectionClause = "";
                FromClause = "";
                AdditionalClause = "";
                KeyColumns = "";
                SelectionClause = "SELECT *";
                FromClause = "FROM #MATLPLAN";
                WhereClause = null;
                AdditionalClause = "ORDER BY DemandId";
                KeyColumns = "DemandId";
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#DynamicParameters") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters");

                }

                this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause VeryLongListType
					,@FromClause VeryLongListType
					,@WhereClause LongListType
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

                this.sQLExpressionExecutor.Execute("DROP TABLE #Demands");
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
        AltExtGen_CLM_ApsGetShortagesSp(
            string AltExtGenSp,
            string DemandType,
            string DemandRef,
            string Item,
            string PlannerCode,
            DateTime? StartDate,
            DateTime? DueDate,
            int? AltNo,
            string ProductCode = null,
            string FilterString = null)
        {
            RefType _DemandType = DemandType;
            ApsOrderType _DemandRef = DemandRef;
            ItemType _Item = Item;
            UserCodeType _PlannerCode = PlannerCode;
            DateType _StartDate = StartDate;
            DateType _DueDate = DueDate;
            ApsAltNoType _AltNo = AltNo;
            ProductCodeType _ProductCode = ProductCode;
            LongListType _FilterString = FilterString;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "DemandType", _DemandType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DemandRef", _DemandRef, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlannerCode", _PlannerCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
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