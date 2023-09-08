//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetARBalance.cs

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
using CSI.Finance.AR;

namespace CSI.Logistics.Customer
{
    public class CLM_GetARBalance : ICLM_GetARBalance
    {
        readonly IApplicationDB appDB;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IARAgingBuckets iARAgingBuckets;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public CLM_GetARBalance(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IARAgingBuckets iARAgingBuckets,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iARAgingBuckets = iARAgingBuckets;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_GetARBalanceSp()
        {
            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            SiteType _Site = DBNull.Value;
            string Site = null;
            CurrCodeType _DomCurrCode = DBNull.Value;
            string DomCurrCode = null;

            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_GetARBalanceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_GetARBalanceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_GetARBalanceSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_CLM_GetARBalanceSp(_ALTGEN_SpName);
                    int? ALTGEN_Severity = ALTGEN.ReturnCode;

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
                }
            }

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_GetARBalanceSp") != null)
            {
                var EXTGEN = AltExtGen_CLM_GetARBalanceSp("dbo.EXTGEN_CLM_GetARBalanceSp");
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            int? Severity = 0;
            if (this.scalarFunction.Execute<int?>(
                "OBJECT_ID",
                "tempdb..#CustAging") == null)
            {
                this.sQLExpressionExecutor.Execute(@"SELECT customer_all.cust_num AS CustNum,
                            customer_all.order_bal AS CustAgeBal1,
                            customer_all.order_bal AS CustAgeBal2,
                            customer_all.order_bal AS CustAgeBal3,
                            customer_all.order_bal AS CustAgeBal4,
                            customer_all.order_bal AS CustAgeBal5,
                            customer_all.order_bal AS CustAgeBalNet,
                            custaddr.curr_code AS ToCurrCode,
                            customer_all.site_ref AS SiteRef,
                            CAST(NULL as nvarchar(2800)) AS Infobar,
                            CAST(0 as int) AS IsProcessed
                     INTO   #CustAging
                     FROM   customer_all WITH (READUNCOMMITTED), custaddr WITH (READUNCOMMITTED)
                     WHERE  1 = 2 ");

                this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX AgingCustNum
                        ON #CustAging(CustNum, SiteRef)");
            }

            #region CRUD LoadToVariable
            var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_Site,"site"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "parms",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
            if (parmsLoadResponse.Items.Count > 0)
            {
                Site = _Site;
            }
            #endregion  LoadToVariable

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
            var CustAging1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"CustNum","customer_all.cust_num"},
                    {"CustAgeBal1","0"},
                    {"CustAgeBal2","0"},
                    {"CustAgeBal3","0"},
                    {"CustAgeBal4","0"},
                    {"CustAgeBal5","0"},
                    {"CustAgeBalNet","0"},
                    {"ToCurrCode",$"{variableUtil.GetValue<string>(DomCurrCode)}"},
                    {"SiteRef","customer_all.site_ref"},
                    {"Infobar","NULL"},
                    {"IsProcessed","0"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "customer_all",
                fromClause: collectionLoadRequestFactory.Clause(@" WITH (READUNCOMMITTED) INNER JOIN custaddr WITH (READUNCOMMITTED) ON custaddr.cust_num = customer_all.cust_num 
                    AND custaddr.cust_seq = customer_all.cust_seq"),
                whereClause: collectionLoadRequestFactory.Clause("customer_all.cust_seq = 0 AND customer_all.show_in_drop_down_list = 1 AND customer_all.site_ref = {0}", Site),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var CustAging1LoadResponse = this.appDB.Load(CustAging1LoadRequest);
            #endregion  LoadToRecord

            #region CRUD InsertByRecords
            var CustAging1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#CustAging",
                items: CustAging1LoadResponse.Items);

            this.appDB.Insert(CustAging1InsertRequest);
            #endregion InsertByRecords

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ARAgingBucketsSp
            iARAgingBuckets.ARAgingBucketsSp();

            #endregion ExecuteMethodCall

            #region CRUD LoadToRecord
            var CustAging2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"DomAgeBalNet","CONVERT (DECIMAL (22, 2), SUM(CustAgeBalNet))"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#CustAging",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var CustAging2LoadResponse = this.appDB.Load(CustAging2LoadRequest);
            #endregion  LoadToRecord

            ICollectionLoadResponse Data = CustAging2LoadResponse;
            return (Data, Severity);
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_CLM_GetARBalanceSp(
            string AltExtGenSp)
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

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
