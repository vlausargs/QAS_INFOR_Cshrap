//PROJECT NAME: Logistics
//CLASS NAME: Homepage_AverageOrderAmount.cs

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
using CSI.Finance;

namespace CSI.Logistics.Customer
{
    [RuntimeIntercept(ERuntimeIntercept.HomepageAverageOrderAmount)]
    public class Homepage_AverageOrderAmount : IHomepage_AverageOrderAmount
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ITransactionFactory transactionFactory;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IMidnightOf iMidnightOf;
        readonly IStringUtil stringUtil;
        readonly IGetLabel iGetLabel;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMathUtil mathUtil;
        readonly ICurrCnvtSingleAmt2 currCnvtSingleAmt2;

        public Homepage_AverageOrderAmount(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ITransactionFactory transactionFactory,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IMidnightOf iMidnightOf,
            IStringUtil stringUtil,
            IGetLabel iGetLabel,
            ISQLValueComparerUtil sQLUtil,
            IMathUtil mathUtil,
            ICurrCnvtSingleAmt2 currCnvtSingleAmt2)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.transactionFactory = transactionFactory;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.iMidnightOf = iMidnightOf;
            this.stringUtil = stringUtil;
            this.iGetLabel = iGetLabel;
            this.sQLUtil = sQLUtil;
            this.mathUtil = mathUtil;
            this.currCnvtSingleAmt2 = currCnvtSingleAmt2;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_AverageOrderAmountSp(string Range = "T", string CustNum = null)
        {
            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            DateTime? StartDate = null;
            DateTime? EndDate = null;
            CurrCodeType _DomCurrCode = DBNull.Value;
            string DomCurrCode = null;
            string Label = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_AverageOrderAmountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_AverageOrderAmountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Homepage_AverageOrderAmountSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_Homepage_AverageOrderAmountSp(_ALTGEN_SpName,
                        Range,
                        CustNum);
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_AverageOrderAmountSp") != null)
            {
                var EXTGEN = AltExtGen_Homepage_AverageOrderAmountSp("dbo.EXTGEN_Homepage_AverageOrderAmountSp",
                    Range,
                    CustNum);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            StartDate = convertToUtil.ToDateTime((sQLUtil.SQLEqual(Range, "T") == true ? this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) :
            sQLUtil.SQLEqual(Range, "3") == true ? this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(29) :
            sQLUtil.SQLEqual(Range, "6") == true ? this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(59) :
            sQLUtil.SQLEqual(Range, "9") == true ? this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(89) :
            sQLUtil.SQLEqual(Range, "M") == true ? this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(179) :
            sQLUtil.SQLEqual(Range, "Y") == true ? this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(364) : null));
            EndDate = convertToUtil.ToDateTime(scalarFunction.Execute<DateTime>("GETDATE"));
            Label = (sQLUtil.SQLEqual(Range, "T") == true ? this.iGetLabel.GetLabelFn("@!Today") :
            sQLUtil.SQLEqual(Range, "3") == true ? stringUtil.Concat("30 ", this.iGetLabel.GetLabelFn("@!Days")) :
            sQLUtil.SQLEqual(Range, "6") == true ? stringUtil.Concat("60 ", this.iGetLabel.GetLabelFn("@!Days")) :
            sQLUtil.SQLEqual(Range, "9") == true ? stringUtil.Concat("90 ", this.iGetLabel.GetLabelFn("@!Days")) :
            sQLUtil.SQLEqual(Range, "M") == true ? stringUtil.Concat("180 ", this.iGetLabel.GetLabelFn("@!Days")) :
            sQLUtil.SQLEqual(Range, "Y") == true ? stringUtil.Concat("365 ", this.iGetLabel.GetLabelFn("@!Days")) : null);

            #region CRUD LoadToVariable
            var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_DomCurrCode,"curr_code"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "currparms",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
            if (currparmsLoadResponse.Items.Count > 0)
            {
                DomCurrCode = _DomCurrCode;
            }
            #endregion  LoadToVariable

            #region CRUD LoadToRecord
            var coLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"curr_code","co.curr_code"},
                    {"exch_rate","co.exch_rate"},
                    {"price","co.price"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "co",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("(co.type = 'R' OR co.type = 'B') AND (co.stat = 'O' OR co.stat = 'P' OR co.stat = 'C') AND co.order_date BETWEEN {0} AND {1} AND co.price > 0 AND ({2} IS NULL OR co.cust_num = {2})", StartDate, EndDate, CustNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coLoadResponse = this.appDB.Load(coLoadRequest);
            #endregion  LoadToRecord

            decimal? Average = null;
            if (coLoadResponse.Items.Count > 0)
            {
                Average = 0;
                foreach (var coItem in coLoadResponse.Items)
                {
                    Average = Average + stringUtil.Coalesce<decimal?>(this.currCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(coItem.GetValue<string>("curr_code"), 0, 0, 1, null, 2, 0, 1, coItem.GetValue<decimal?>("exch_rate"), null, DomCurrCode, 0, coItem.GetValue<decimal?>("price")), 0.0);
                }
                Average = mathUtil.Round<decimal?>(Average / coLoadResponse.Items.Count, 2);
            }

            #region CRUD LoadResponseWithoutTable
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                {
                    { "col0", variableUtil.GetValue<string>(Label,true)},
                    { "col1", variableUtil.GetValue<decimal?>(Average,true)},
                });

            var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
            Data = nonTableLoadResponse;
            #endregion CRUD LoadResponseWithoutTable

            return (Data, Severity);
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_AverageOrderAmountSp(string AltExtGenSp,
            string Range = "T",
            string CustNum = null)
        {
            StringType _Range = Range;
            CustNumType _CustNum = CustNum;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "Range", _Range, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);

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
