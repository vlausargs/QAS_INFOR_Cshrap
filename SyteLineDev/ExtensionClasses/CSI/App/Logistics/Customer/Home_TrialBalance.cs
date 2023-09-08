//PROJECT NAME: Logistics
//CLASS NAME: Home_TrialBalance.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;
using CSI.MG.MGCore;
using CSI.Finance;

namespace CSI.Logistics.Customer
{
    public class Home_TrialBalance : IHome_TrialBalance
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
        readonly IBuildXMLFilterString iBuildXMLFilterString;
        readonly ITransactionFactory transactionFactory;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IPeriodsGetDates iPeriodsGetDates;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IStringUtil stringUtil;
        readonly ICalcBal iCalcBal;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IPerGet iPerGet;

        public Home_TrialBalance(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IBuildXMLFilterString iBuildXMLFilterString,
            ITransactionFactory transactionFactory,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            IPeriodsGetDates iPeriodsGetDates,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IDateTimeUtil dateTimeUtil,
            IStringUtil stringUtil,
            ICalcBal iCalcBal,
            ISQLValueComparerUtil sQLUtil,
            IPerGet iPerGet)
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
            this.iBuildXMLFilterString = iBuildXMLFilterString;
            this.transactionFactory = transactionFactory;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.iPeriodsGetDates = iPeriodsGetDates;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.dateTimeUtil = dateTimeUtil;
            this.stringUtil = stringUtil;
            this.iCalcBal = iCalcBal;
            this.sQLUtil = sQLUtil;
            this.iPerGet = iPerGet;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Home_TrialBalanceSp(string FilterString = null,
            DateTime? AsOfDate = null,
            string SiteGroup = null)
        {

            SiteGroupType _SiteGroup = SiteGroup;
            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {
                ICollectionLoadResponse Data = null;

                StringType _ALTGEN_SpName = DBNull.Value;
                int? ALTGEN_Severity = null;
                int? Severity = null;
                string Infobar = null;
                DateTime? PreviousPeriodEndDate = null;
                DateTime? PeriodStartDate = null;
                int? CurrentPeriod = null;
                int? PeriodsFiscalYear = null;
                string Acct = null;
                string ChartType = null;
                CurrCodeType _CurrCode = DBNull.Value;
                string CurrCode = null;
                decimal? BeginningBalance = null;
                decimal? PeriodDebit = null;
                decimal? PeriodCredit = null;
                string SiteRef = null;
                string LastSiteRef = null;
                string SelectionClause = null;
                string FromClause = null;
                string WhereClause = null;
                string AdditionalClause = null;
                string KeyColumns = null;
                ICollectionLoadResponse accounts1LoadResponse = null;
                int accounts1_CursorFetch_Status = -1;
                int accounts1_CursorCounter = -1;

                if (existsChecker.Exists(
                    tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_TrialBalanceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
                {
                    //BEGIN
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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_TrialBalanceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Home_TrialBalanceSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
                    };

                    var optional_module1RequiredColumns = new List<string>() { "SpName" };

                    optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                    var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                        items: optional_module1LoadResponse.Items);

                    this.appDB.Insert(optional_module1InsertRequest);
                    #endregion InsertByRecords

                    while (existsChecker.Exists(
                        tableName: "#tv_ALTGEN",
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
                        this.appDB.Load(tv_ALTGEN1LoadRequest);
                        #endregion  LoadToVariable

                        var ALTGEN = AltExtGen_Home_TrialBalanceSp(_ALTGEN_SpName,
                            FilterString,
                            AsOfDate,
                            SiteGroup);
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
                                {"col0","1"},
                            },
                            loadForChange: true, 
                            lockingType: LockingType.None,
                            tableName: "#tv_ALTGEN",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", _ALTGEN_SpName),
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

                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_TrialBalanceSp") != null)
                {
                    var EXTGEN = AltExtGen_Home_TrialBalanceSp("dbo.EXTGEN_Home_TrialBalanceSp",
                        FilterString,
                        AsOfDate,
                        SiteGroup);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                SelectionClause = "";
                FromClause = "";
                WhereClause = "";
                AdditionalClause = "";
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#accounts") == null)
                {
                    this.sQLExpressionExecutor.Execute(@"Declare
                         @ChartType ChartTypeType
                         ,@Acct AcctType
                         ,@BeginningBalance AmtTotType
                         ,@PeriodDebit AmtTotType
                         ,@PeriodCredit AmtTotType
                         ,@EndingBalance AmtTotType
                         ,@ChartAcctDescription DescriptionType
                         ,@SiteRef SiteType
                         SELECT @ChartType AS ChartType,
                                @Acct AS ChartAcct,
                                @BeginningBalance AS BeginningBalance,
                                @PeriodDebit AS PeriodDebit,
                                @PeriodCredit AS PeriodCredit,
                                @EndingBalance AS EndingBalance,
                                @ChartAcctDescription AS ChartAcctDescription,
                                @SiteRef AS SiteRef
                         INTO   #accounts
                         WHERE  1 = 2");

                }
                this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX accountsAcct
                        ON #accounts(ChartAcct, SiteRef)");
                Severity = 0;
                if (_SiteGroup.IsNull)
                {
                    #region CRUD LoadToVariable
                    var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_SiteGroup,"site_group"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "parms",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    this.appDB.Load(parmsLoadRequest);
                    #endregion  LoadToVariable
                }

                #region CRUD LoadToRecord
                var accounts1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"ChartType","chart.type"},
                        {"ChartAcct","chart.acct"},
                        {"BeginningBalance","0"},
                        {"PeriodDebit","0"},
                        {"PeriodCredit","0"},
                        {"EndingBalance","0"},
                        {"ChartAcctDescription","chart.description"},
                        {"SiteRef","chart.site_ref"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "chart_all",
                    fromClause: collectionLoadRequestFactory.Clause(" AS chart INNER JOIN site_group AS site ON site.site = chart.site_ref"),
                    whereClause: collectionLoadRequestFactory.Clause("site.site_group = {0}", _SiteGroup),
                    orderByClause: collectionLoadRequestFactory.Clause(" chart.site_ref, chart.acct"));
                accounts1LoadResponse = this.appDB.Load(accounts1LoadRequest);
                #endregion  LoadToRecord
                
                accounts1_CursorFetch_Status = accounts1LoadResponse.Items.Count > 0 ? 0 : -1;
                accounts1_CursorCounter = -1;

                while (true)
                {
                    //BEGIN
                    accounts1_CursorCounter++;
                    if (accounts1LoadResponse.Items.Count > accounts1_CursorCounter)
                    {
                        SiteRef = accounts1LoadResponse.Items[accounts1_CursorCounter].GetValue<string>("SiteRef");
                        Acct = accounts1LoadResponse.Items[accounts1_CursorCounter].GetValue<string>("ChartAcct");
                        ChartType = accounts1LoadResponse.Items[accounts1_CursorCounter].GetValue<string>("ChartType");
                    }
                    accounts1_CursorFetch_Status = (accounts1_CursorCounter == accounts1LoadResponse.Items.Count ? -1 : 0);

                    if (sQLUtil.SQLNotEqual(accounts1_CursorFetch_Status, 0) == true)
                    {
                        break;
                    }

                    if (LastSiteRef != SiteRef)
                    {
                        #region CRUD LoadToVariable
                        var currparms_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_CurrCode,"curr_code"},
                            },
                            loadForChange: false,
                            lockingType: LockingType.None,
                            tableName: "currparms_all",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("site_ref = {0}", SiteRef),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        this.appDB.Load(currparms_allLoadRequest);
                        #endregion  LoadToVariable
                    }
                    LastSiteRef = SiteRef;

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: PerGetSp
                    var PerGet = this.iPerGet.PerGetSp(Date: AsOfDate
                        , CurrentPeriod: CurrentPeriod
                        , Infobar: Infobar
                        , Site: SiteRef
                        , PeriodsFiscalYear: PeriodsFiscalYear);
                    CurrentPeriod = PerGet.CurrentPeriod;
                    Infobar = PerGet.Infobar;
                    PeriodsFiscalYear = PerGet.PeriodsFiscalYear;

                    #endregion ExecuteMethodCall

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: PeriodsGetDatesSp
                    var PeriodsGetDates = this.iPeriodsGetDates.PeriodsGetDatesSp(FiscalYear: PeriodsFiscalYear
                        , Period: CurrentPeriod
                        , Site: SiteRef
                        , PerStart: PeriodStartDate
                        , PerEnd: null
                        , Infobar: Infobar);
                    PeriodStartDate = PeriodsGetDates.PerStart;
                    Infobar = PeriodsGetDates.Infobar;

                    #endregion ExecuteMethodCall

                    PreviousPeriodEndDate = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", -1, PeriodStartDate));

                    #region CRUD ExecuteMethodCall
                    CurrCode = _CurrCode;
                    //Please Generate the bounce for this stored procedure: CalcBalSp
                    var CalcBal = this.iCalcBal.CalcBalSp(TMethod: "N"
                        , TUse: 1
                        , SDate: null
                        , EDate: PreviousPeriodEndDate
                        , PHierarchy: null
                        , PAcct: Acct
                        , PAcctUnit1: null
                        , PAcctUnit2: null
                        , PAcctUnit3: null
                        , PAcctUnit4: null
                        , PSort: "A"
                        , PType: ChartType
                        , PIncome: 1
                        , PBalType: "B"
                        , PCurrCode: CurrCode
                        , PSortMethod: 1
                        , Balance: BeginningBalance
                        , Infobar: Infobar
                        , pSite: SiteRef);
                    BeginningBalance = CalcBal.Balance;
                    Infobar = CalcBal.Infobar;

                    #endregion ExecuteMethodCall

                    #region CRUD ExecuteMethodCall
                    CurrCode = _CurrCode;
                    //Please Generate the bounce for this stored procedure: CalcBalSp
                    var CalcBal1 = this.iCalcBal.CalcBalSp(TMethod: "N"
                        , TUse: 1
                        , SDate: PeriodStartDate
                        , EDate: AsOfDate
                        , PHierarchy: null
                        , PAcct: Acct
                        , PAcctUnit1: null
                        , PAcctUnit2: null
                        , PAcctUnit3: null
                        , PAcctUnit4: null
                        , PSort: "A"
                        , PType: ChartType
                        , PIncome: 1
                        , PBalType: "D"
                        , PCurrCode: CurrCode
                        , PSortMethod: 1
                        , Balance: PeriodDebit
                        , Infobar: Infobar
                        , pSite: SiteRef);
                    PeriodDebit = CalcBal1.Balance;
                    Infobar = CalcBal1.Infobar;

                    #endregion ExecuteMethodCall

                    #region CRUD ExecuteMethodCall
                    CurrCode = _CurrCode;
                    //Please Generate the bounce for this stored procedure: CalcBalSp
                    var CalcBal2 = this.iCalcBal.CalcBalSp(TMethod: "N"
                        , TUse: 1
                        , SDate: PeriodStartDate
                        , EDate: AsOfDate
                        , PHierarchy: null
                        , PAcct: Acct
                        , PAcctUnit1: null
                        , PAcctUnit2: null
                        , PAcctUnit3: null
                        , PAcctUnit4: null
                        , PSort: "A"
                        , PType: ChartType
                        , PIncome: 1
                        , PBalType: "C"
                        , PCurrCode: CurrCode
                        , PSortMethod: 1
                        , Balance: PeriodCredit
                        , Infobar: Infobar
                        , pSite: SiteRef);
                    PeriodCredit = CalcBal2.Balance;
                    Infobar = CalcBal2.Infobar;

                    #endregion ExecuteMethodCall

                    accounts1LoadResponse.Items[accounts1_CursorCounter].SetValue<decimal?>("BeginningBalance", BeginningBalance);
                    accounts1LoadResponse.Items[accounts1_CursorCounter].SetValue<decimal?>("PeriodDebit", PeriodDebit);
                    accounts1LoadResponse.Items[accounts1_CursorCounter].SetValue<decimal?>("PeriodCredit", -PeriodCredit);
                    accounts1LoadResponse.Items[accounts1_CursorCounter].SetValue<decimal?>("EndingBalance", BeginningBalance + PeriodDebit + PeriodCredit);
                }

                #region CRUD InsertByRecords
                var accounts1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#accounts",
                    items: accounts1LoadResponse.Items);

                this.appDB.Insert(accounts1InsertRequest);
                #endregion InsertByRecords

                WhereClause = " WHERE SiteRef IN (select site from site_group where site_group.site_group = @SiteGroup)";
                SelectionClause = "SELECT ChartType, ChartAcct, BeginningBalance, PeriodDebit, PeriodCredit, EndingBalance, ChartAcctDescription, SiteRef";
                FromClause = "FROM #accounts";
                AdditionalClause = "ORDER BY SiteRef, ChartAcct";
                KeyColumns = "SiteRef, ChartAcct";

                #region CRUD ExecuteMethodCall
                SiteGroup = _SiteGroup;
                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "SiteGroup"
                    , Value: SiteGroup
                    , DataType: "SiteGroupType"
                    , NameInParmList: "@SiteGroup"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: FilterString);
                Severity = BuildXMLFilterString.ReturnCode;
                FilterString = BuildXMLFilterString.XmlFilterString;

                #endregion ExecuteMethodCall

                this.sQLExpressionExecutor.Execute(@"Declare
                     @SelectionClause VeryLongListType
                     ,@FromClause VeryLongListType
                     ,@WhereClause VeryLongListType
                     ,@AdditionalClause VeryLongListType
                     ,@KeyColumns LongListType
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
                        {"SelectionClause",$"{variableUtil.GetValue<string>(SelectionClause)}"},
                        {"FromClause",$"{variableUtil.GetValue<string>(FromClause)}"},
                        {"WhereClause",$"{variableUtil.GetValue<string>(WhereClause)}"},
                        {"AdditionalClause",$"{variableUtil.GetValue<string>(AdditionalClause)}"},
                        {"KeyColumns",$"{variableUtil.GetValue<string>(KeyColumns)}"},
                        {"FilterString",$"{variableUtil.GetValue<string>(FilterString)}"},
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
                var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(NeedGetMoreRows: 1
                    , Infobar: Infobar);
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
        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Home_TrialBalanceSp(string AltExtGenSp,
            string FilterString = null,
            DateTime? AsOfDate = null,
            string SiteGroup = null)
        {
            LongListType _FilterString = FilterString;
            DateType _AsOfDate = AsOfDate;
            SiteGroupType _SiteGroup = SiteGroup;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);

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
