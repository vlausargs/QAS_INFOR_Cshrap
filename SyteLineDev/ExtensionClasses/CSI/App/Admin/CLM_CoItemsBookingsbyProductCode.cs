//PROJECT NAME: Admin
//CLASS NAME: CLM_CoItemsBookingsbyProductCode.cs

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
using System.Linq;

namespace CSI.Admin
{
    public class CLM_CoItemsBookingsbyProductCode : ICLM_CoItemsBookingsbyProductCode
    {
        readonly IApplicationDB appDB;

        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IDefaultToLocalSite iDefaultToLocalSite;
        readonly IScalarFunction scalarFunction;
        readonly IInterpretText iInterpretText;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IVariableUtil variableUtil;
        readonly IMidnightOf iMidnightOf;
        readonly IStringUtil stringUtil;
        readonly ILowDate iLowDate;
        readonly ISQLValueComparerUtil sQLUtil;

        public CLM_CoItemsBookingsbyProductCode(IApplicationDB appDB,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IDefaultToLocalSite iDefaultToLocalSite,
            IScalarFunction scalarFunction,
            IInterpretText iInterpretText,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IDateTimeUtil dateTimeUtil,
            IVariableUtil variableUtil,
            IMidnightOf iMidnightOf,
            IStringUtil stringUtil,
            ILowDate iLowDate,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iDefaultToLocalSite = iDefaultToLocalSite;
            this.scalarFunction = scalarFunction;
            this.iInterpretText = iInterpretText;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.dateTimeUtil = dateTimeUtil;
            this.variableUtil = variableUtil;
            this.iMidnightOf = iMidnightOf;
            this.stringUtil = stringUtil;
            this.iLowDate = iLowDate;
            this.sQLUtil = sQLUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_CoItemsBookingsbyProductCodeSp(
            string ProductCode = null,
            int? StartYear = null,
            int? EndYear = null,
            int? StartPeriod = null,
            int? EndPeriod = null,
            int? PageNum = null,
            int? EntriesPerPage = null,
            string SiteRef = null)
        {

            IntType _StartPeriod = StartPeriod;
            IntType _EndPeriod = EndPeriod;

            ICollectionLoadResponse Data = null;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            DateTimeType _StartDate = DBNull.Value;
            DateTime? StartDate = null;
            DateTimeType _EndDate = DBNull.Value;
            DateTime? EndDate = null;
            int? TotalPages = null;
            string TranslatedText = null;
            string Infobar = null;
            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_CoItemsBookingsbyProductCodeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_CoItemsBookingsbyProductCodeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord


                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_CoItemsBookingsbyProductCodeSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_CLM_CoItemsBookingsbyProductCodeSp(ALTGEN_SpName,
                        ProductCode,
                        StartYear,
                        EndYear,
                        StartPeriod,
                        EndPeriod,
                        PageNum,
                        EntriesPerPage,
                        SiteRef);
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
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_CoItemsBookingsbyProductCodeSp") != null)
            {
                var EXTGEN = AltExtGen_CLM_CoItemsBookingsbyProductCodeSp("dbo.EXTGEN_CLM_CoItemsBookingsbyProductCodeSp",
                    ProductCode,
                    StartYear,
                    EndYear,
                    StartPeriod,
                    EndPeriod,
                    PageNum,
                    EntriesPerPage,
                    SiteRef);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            SiteRef = stringUtil.Coalesce<string>(SiteRef, this.iDefaultToLocalSite.DefaultToLocalSiteFn(SiteRef));
            if (StartYear == null)
            {
                StartYear = (int?)(dateTimeUtil.Year<int?>(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE"))));

            }
            if (EndYear == null)
            {
                EndYear = (int?)(dateTimeUtil.Year<int?>(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE") + TimeSpan.FromDays(1))));

            }
            if (StartPeriod == null)
            {

                #region CRUD LoadToVariable
                var PeriodsAllViewASpvLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_StartPeriod,"PV.period"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "PeriodsAllView AS pv",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("GETDATE() BETWEEN startDate AND endDate AND site = {0}", SiteRef),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var PeriodsAllViewASpvLoadResponse = this.appDB.Load(PeriodsAllViewASpvLoadRequest);
                if (PeriodsAllViewASpvLoadResponse.Items.Count > 0)
                {
                    StartPeriod = _StartPeriod;
                }
                #endregion  LoadToVariable


            }
            if (EndPeriod == null)
            {

                #region CRUD LoadToVariable
                var PeriodsAllViewASpv1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_EndPeriod,"PV.period"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "PeriodsAllView AS pv",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("GETDATE() BETWEEN startDate AND endDate AND site = {0}", SiteRef),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var PeriodsAllViewASpv1LoadResponse = this.appDB.Load(PeriodsAllViewASpv1LoadRequest);
                if (PeriodsAllViewASpv1LoadResponse.Items.Count > 0)
                {
                    EndPeriod = _EndPeriod;
                }
                #endregion  LoadToVariable


            }
            if (ProductCode == null)
            {
                ProductCode = "%";

            }

            #region CRUD LoadToVariable
            var PeriodsAllViewASpv2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
            {
                {_StartDate,"PV.startDate"},
            },
            loadForChange: false, 
            lockingType: LockingType.None,
            tableName: "PeriodsAllView AS pv",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("pv.FiscalYear = {1} AND pv.period = {0} AND site = {2}", StartPeriod, StartYear, SiteRef),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var PeriodsAllViewASpv2LoadResponse = this.appDB.Load(PeriodsAllViewASpv2LoadRequest);
            if (PeriodsAllViewASpv2LoadResponse.Items.Count > 0)
            {
                StartDate = _StartDate;
            }
            #endregion  LoadToVariable


            #region CRUD LoadToVariable
            var PeriodsAllViewASpv3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
            {
                {_EndDate,"PV.EndDate"},
            },
            loadForChange: false, 
            lockingType: LockingType.None,
            tableName: "PeriodsAllView AS pv",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("pv.FiscalYear = {1} AND pv.period = {0} AND site = {2}", EndPeriod, EndYear, SiteRef),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var PeriodsAllViewASpv3LoadResponse = this.appDB.Load(PeriodsAllViewASpv3LoadRequest);
            if (PeriodsAllViewASpv3LoadResponse.Items.Count > 0)
            {
                EndDate = _EndDate;
            }
            #endregion  LoadToVariable

            if (StartDate == null)
            {
                StartDate = convertToUtil.ToDateTime(this.iLowDate.LowDateFn());

            }
            if (EndDate == null)
            {
                EndDate = convertToUtil.ToDateTime(scalarFunction.Execute<DateTime>("GETDATE"));

            }
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @Bookings TABLE (
			ProdCode     ProductCodeType,
			ProdCodeDesc DescriptionType,
			DomAmount     DECIMAL (28, 8),
			TotalPages   INT            );
			SELECT * into #tv_Bookings from @Bookings");
            PageNum = (int?)(stringUtil.IsNull(
                PageNum,
                1));
            EntriesPerPage = (int?)(stringUtil.IsNull(
                EntriesPerPage,
                5));
            TotalPages = 1;
            Severity = 0;

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InterpretTextSp
            var InterpretText = this.iInterpretText.InterpretTextSp(
                Text: "FORMAT(sNone)",
                InterpretedText: TranslatedText,
                Infobar: Infobar);
            Severity = InterpretText.ReturnCode;
            TranslatedText = InterpretText.InterpretedText;
            Infobar = InterpretText.Infobar;

            #endregion ExecuteMethodCall


            #region CRUD LoadArbitrary
            var tv_BookingsLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                { "ProdCode", $"COALESCE (p.product_code, {variableUtil.GetQuotedValue<string>(TranslatedText)})" },
                { "ProdCodeDesc", $"ISNULL(p.description, {variableUtil.GetQuotedValue<string>(TranslatedText)})" },
                { "DomAmount", "SUM(qty_ordered * DomAmount)" },
            },
            selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
			FROM (SELECT COALESCE (product_code, {0} ) AS Product_code,
			qty_ordered_conv AS qty_ordered,
			dbo.CurrCnvtSingleAmt2([co].[curr_code], 0, 0, 1, DEFAULT, DEFAULT, DEFAULT, DEFAULT, [co].[exch_rate], DEFAULT, DEFAULT, DEFAULT, ISNULL([coi].[price_conv], 0)) AS DomAmount,
			coi.site_ref
			FROM   coitem_all AS coi
			LEFT OUTER JOIN
			[co_all] AS [co]
			ON co.co_num = coi.co_num
			AND co.site_ref = coi.site_ref
			LEFT OUTER JOIN
			[custaddr] AS [adr]
			ON adr.cust_num = co.cust_num
			AND adr.cust_seq = co.cust_seq
			LEFT OUTER JOIN
			[currency_all] AS [currency]
			ON currency.curr_code = co.curr_code
			AND currency.site_ref = {3}
			LEFT OUTER JOIN
			item_all AS item
			ON item.item = coi.item
			AND item.site_ref = coi.site_ref
			WHERE  coi.createdate BETWEEN {2}  AND {4}
			AND coi.site_ref = {3} ) AS SS
			LEFT OUTER JOIN
			prodcode_all AS p
			ON p.product_code = ss.product_code
			AND p.site_ref = ss.site_ref
			WHERE SS.Product_code LIKE {1}
			AND SS.site_ref = {3}
			GROUP BY p.product_code, p.description
			ORDER BY DomAmount DESC", TranslatedText, ProductCode, StartDate, SiteRef, EndDate));

            var tv_BookingsLoadResponse = this.appDB.Load(tv_BookingsLoadRequest);
            Data = tv_BookingsLoadResponse;
            #endregion  LoadArbitrary


            #region CRUD InsertByRecords
            var tv_BookingsInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Bookings",
                items: tv_BookingsLoadResponse.Items);

            this.appDB.Insert(tv_BookingsInsertRequest);
            #endregion InsertByRecords


            #region CRUD LoadToRecord
            var tv_Bookings1LoadRequestForScalarSubQuery = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"col0",$"CEILING(CONVERT (DECIMAL, COUNT(*)) / CONVERT (DECIMAL, {variableUtil.GetQuotedValue<int?>(EntriesPerPage)}))"},
            },
            loadForChange: false, 
            lockingType: LockingType.None,
            tableName: "#tv_Bookings",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause(""),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_Bookings1LoadResponseForScalarSubQuery = this.appDB.Load(tv_Bookings1LoadRequestForScalarSubQuery);
            #endregion  LoadToRecord

            Data = tv_Bookings1LoadResponseForScalarSubQuery;

            TotalPages = (int?)(stringUtil.IsNull<int?>(
                ((tv_Bookings1LoadResponseForScalarSubQuery.Items != null &&
                        tv_Bookings1LoadResponseForScalarSubQuery.Items.Count != 0) ?
                    (tv_Bookings1LoadResponseForScalarSubQuery.Items.FirstOrDefault().GetValue<int?>("col0")) : null),
                1));
            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Bookings ADD tempTableId INT IDENTITY");

            #region CRUD LoadToRecord
            var tv_Bookings2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"TotalPages","PL.TotalPages"},
            },
            tableName: "#tv_Bookings", 
            loadForChange: true, 
            lockingType: LockingType.UPDLock,
            fromClause: collectionLoadRequestFactory.Clause(" AS PL"),
            whereClause: collectionLoadRequestFactory.Clause(""),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_Bookings2LoadResponse = this.appDB.Load(tv_Bookings2LoadRequest);
            #endregion  LoadToRecord


            #region CRUD UpdateByRecord
            foreach (var tv_Bookings2Item in tv_Bookings2LoadResponse.Items)
            {
                tv_Bookings2Item.SetValue<int?>("TotalPages", TotalPages);
            };

            var tv_Bookings2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Bookings",
                items: tv_Bookings2LoadResponse.Items);

            this.appDB.Update(tv_Bookings2RequestUpdate);
            #endregion UpdateByRecord

            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Bookings DROP COLUMN tempTableId");
            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Bookings ADD tempTableId INT IDENTITY");
            /*Needs to load at least one column from the table: #tv_Bookings for delete, Loads the record based on its where and from clause, then deletes it by record.*/
            #region CRUD LoadToRecord
            var tv_Bookings3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"ProdCode","ProdCode"},
                {"DomAmount","DomAmount"},
            },
            maximumRows: PageNum,
            tableName: "#tv_Bookings",
            loadForChange: true, 
            lockingType: LockingType.None,
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("ProdCode IN (SELECT TOP ({0} * ({1} - 1)) ProdCode FROM #tv_Bookings ORDER BY DomAmount DESC)", EntriesPerPage, PageNum),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_Bookings3LoadResponse = this.appDB.Load(tv_Bookings3LoadRequest);
            #endregion  LoadToRecord


            #region CRUD DeleteByRecord
            var tv_Bookings3DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_Bookings",
                items: tv_Bookings3LoadResponse.Items);
            this.appDB.Delete(tv_Bookings3DeleteRequest);
            #endregion DeleteByRecord

            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Bookings DROP COLUMN tempTableId");

            #region CRUD LoadToRecord
            var tv_Bookings4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"ProdCodeDesc","ProdCodeDesc"},
                {"EstValue","DomAmount"},
                {"TotalPages","TotalPages"},
            },
            loadForChange: false, 
            lockingType: LockingType.None,
            maximumRows: EntriesPerPage,
            tableName: "#tv_Bookings",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause(""),
            orderByClause: collectionLoadRequestFactory.Clause(" EstValue DESC"));
            var tv_Bookings4LoadResponse = this.appDB.Load(tv_Bookings4LoadRequest);
            #endregion  LoadToRecord

            Data = tv_Bookings4LoadResponse;

            return (Data, Severity);

        }
        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_CLM_CoItemsBookingsbyProductCodeSp(
            string AltExtGenSp,
            string ProductCode = null,
            int? StartYear = null,
            int? EndYear = null,
            int? StartPeriod = null,
            int? EndPeriod = null,
            int? PageNum = null,
            int? EntriesPerPage = null,
            string SiteRef = null)
        {
            ProductCodeType _ProductCode = ProductCode;
            IntType _StartYear = StartYear;
            IntType _EndYear = EndYear;
            IntType _StartPeriod = StartPeriod;
            IntType _EndPeriod = EndPeriod;
            IntType _PageNum = PageNum;
            IntType _EntriesPerPage = EntriesPerPage;
            SiteType _SiteRef = SiteRef;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartYear", _StartYear, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndYear", _EndYear, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartPeriod", _StartPeriod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndPeriod", _EndPeriod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PageNum", _PageNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EntriesPerPage", _EntriesPerPage, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);

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
