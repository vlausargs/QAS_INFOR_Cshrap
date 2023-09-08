//PROJECT NAME: Logistics
//CLASS NAME: CLM_APBalance.cs

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

namespace CSI.Logistics.Vendor
{
    public class CLM_APBalance : ICLM_APBalance
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IAPBalanceByPeriod iAPBalanceByPeriod;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISqlFilter iSqlFilter;
        readonly ISQLValueComparerUtil sQLUtil;

        public CLM_APBalance(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IAPBalanceByPeriod iAPBalanceByPeriod,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISqlFilter iSqlFilter,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iAPBalanceByPeriod = iAPBalanceByPeriod;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.iSqlFilter = iSqlFilter;
            this.sQLUtil = sQLUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode,
            string Infobar)
        CLM_APBalanceSp(
            int? FiscalYear,
            int? Period,
            string SiteGroup,
            string FilterString = null,
            string Infobar = null)
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
                string SelectionClause = null;
                string WhereClause = null;
                string PropertyList = null;
                string ColumnList = null;
                string FromClause = null;
                string AdditionalClause = null;
                string KeyColumns = null;
                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_APBalanceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_APBalanceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_APBalanceSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                        var ALTGEN = AltExtGen_CLM_APBalanceSp(ALTGEN_SpName,
                            FiscalYear,
                            Period,
                            SiteGroup,
                            FilterString,
                            Infobar);
                        ALTGEN_Severity = ALTGEN.ReturnCode;

                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN.Data, ALTGEN_Severity, Infobar);

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
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_APBalanceSp") != null)
                {
                    var EXTGEN = AltExtGen_CLM_APBalanceSp("dbo.EXTGEN_CLM_APBalanceSp",
                        FiscalYear,
                        Period,
                        SiteGroup,
                        FilterString,
                        Infobar);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity, EXTGEN.Infobar);
                    }
                }

                Severity = 0;

                this.sQLExpressionExecutor.Execute(@"Declare
					@VendNum VendNumType
					,@VendName NameType
					,@Opening AmountType
					,@Voucher AmountType
					,@Payment AmountType
					,@Closing AmountType
					,@currcode CurrCodeType
					,@CurrencyAmtFormat InputMaskType
					,@CurrencyPlaces DecimalPlacesType
					SELECT @VendNum AS UbVendNum,
					       @VendName AS UbVendName,
					       @Opening AS UbOpening,
					       @Voucher AS UbVoucher,
					       @Payment AS UbPayment,
					       @Closing AS UbClosing,
					       @currcode AS UbCurrCode,
					       @CurrencyAmtFormat AS CurrencyAmtFormat,
					       @CurrencyPlaces AS CurrencyPlaces
					INTO   #tempOutput
					WHERE  1 = 2");

                #region CRUD InsertByMethodCall
                //Please Generate the bounce for this stored procedure:APBalanceByPeriodSp
                var tempOutput1ExecResult = this.iAPBalanceByPeriod.APBalanceByPeriodSp(
                    FiscalYear: FiscalYear,
                    Period: Period,
                    SiteGroup: SiteGroup,
                    Infobar: Infobar);
                var tempOutput1LoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(tempOutput1ExecResult.Data,
                    new List<string>() { "UbVendNum",
                            "UbVendName",
                            "UbOpening",
                            "UbVoucher",
                            "UbPayment",
                            "UbClosing",
                            "UbCurrCode",
                            "CurrencyAmtFormat",
                            "CurrencyPlaces" });
                var tempOutput1InsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#tempOutput",
                    items: tempOutput1LoadResponse.Items);

                this.appDB.Insert(tempOutput1InsertRequest);

                Infobar = tempOutput1ExecResult.Infobar;
                #endregion InsertByMethodCall

                PropertyList = "UbDispOpening;UbDispVoucher;UbDispPayment;UbDispClosing";
                ColumnList = "UbOpening;UbVoucher;UbPayment;UbClosing";
                FilterString = stringUtil.IsNull(
                    this.iSqlFilter.SqlFilterFn(
                        FilterString,
                        PropertyList,
                        ColumnList,
                        ";"),
                    "");
                FromClause = "";
                AdditionalClause = "";
                KeyColumns = "";
                SelectionClause = @"SELECT
					                           UbVendNum
					                         , UbVendName
					                         , UbOpening
					                         , UbVoucher
					                         , UbPayment
					                         , UbClosing
					                         , UbCurrCode
					                         , CurrencyAmtFormat
					                         , CurrencyPlaces
					                         ";
                FromClause = "FROM #tempOutput";
                WhereClause = null;
                AdditionalClause = "ORDER BY UbVendNum";
                KeyColumns = "UbVendNum";
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#DynamicParameters") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters");

                }

                this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause LongListType
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

                return (Data, Severity, Infobar);

            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }
        public (
            ICollectionLoadResponse Data,
            int? ReturnCode,
            string Infobar)
        AltExtGen_CLM_APBalanceSp(
            string AltExtGenSp,
            int? FiscalYear,
            int? Period,
            string SiteGroup,
            string FilterString = null,
            string Infobar = null)
        {
            FiscalYearType _FiscalYear = FiscalYear;
            FinPeriodType _Period = Period;
            SiteGroupType _SiteGroup = SiteGroup;
            LongListType _FilterString = FilterString;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
                var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;

                Infobar = _Infobar;

                return (resultSet, returnCode, Infobar);
            }
        }

    }
}