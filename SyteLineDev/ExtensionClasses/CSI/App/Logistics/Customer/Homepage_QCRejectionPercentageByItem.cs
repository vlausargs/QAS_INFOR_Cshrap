//PROJECT NAME: Logistics
//CLASS NAME: Homepage_QCRejectionPercentageByItem.cs

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

namespace CSI.Logistics.Customer
{
    public class Homepage_QCRejectionPercentageByItem : IHomepage_QCRejectionPercentageByItem
    {
        readonly IApplicationDB appDB;

        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ITransactionFactory transactionFactory;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IDataTypeUtil dataTypeUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public Homepage_QCRejectionPercentageByItem(IApplicationDB appDB,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ITransactionFactory transactionFactory,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IDataTypeUtil dataTypeUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.transactionFactory = transactionFactory;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.dataTypeUtil = dataTypeUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Homepage_QCRejectionPercentageByItemSp(
            DateTime? DateEnd,
            DateTime? DateStart,
            string RefType)
        {



            ICollectionLoadResponse Data = null;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_QCRejectionPercentageByItemSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_QCRejectionPercentageByItemSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord


                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Homepage_QCRejectionPercentageByItemSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_Homepage_QCRejectionPercentageByItemSp(ALTGEN_SpName,
                        DateEnd,
                        DateStart,
                        RefType);
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
                    //END

                }
                //END

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_QCRejectionPercentageByItemSp") != null)
            {
                var EXTGEN = AltExtGen_Homepage_QCRejectionPercentageByItemSp("dbo.EXTGEN_Homepage_QCRejectionPercentageByItemSp",
                    DateEnd,
                    DateStart,
                    RefType);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            Severity = 0;

            this.sQLExpressionExecutor.Execute(@"SELECT   rcvr.item,
                i.description,
                rcvr.ref_type,
                CAST (0 AS DECIMAL(12, 2)) AS Received,
                CAST (0 AS DECIMAL(12, 2)) AS Accepted,
                CAST (0 AS DECIMAL(12, 2)) AS Rejected,
                CAST (0 AS DECIMAL(12, 2)) AS OnHold,
                rcvr.trans_date,
                i.u_m
            INTO     #ResultTable
            FROM     rs_qcrcvr AS rcvr
            LEFT OUTER JOIN
                item AS i
                ON i.item = rcvr.item
               WHERE 1 = 0");


            this.sQLExpressionExecutor.Execute(@"INSERT INTO #ResultTable
                     SELECT   rcvr.item,
                i.description,
                rcvr.ref_type,
                CAST (ROUND(sum(rcvr.qty_received), 2) AS DECIMAL (12, 2)) AS Received,
                CAST (ROUND(sum(rcvr.qty_accepted), 2) AS DECIMAL (12, 2)) AS Accepted,
                CAST (ROUND(sum(rcvr.qty_rejected), 2) AS DECIMAL (12, 2)) AS Rejected,
                CAST (ROUND(sum(rcvr.qty_hold), 2) AS DECIMAL (12, 2)) AS OnHold,
                rcvr.trans_date,
                i.u_m
            FROM     rs_qcrcvr AS rcvr
            LEFT OUTER JOIN
                item AS i
                ON i.item = rcvr.item
            GROUP BY rcvr.item, rcvr.ref_type, rcvr.trans_date, rcvr.first_article, i.description, i.u_m
               HAVING   rcvr.trans_date BETWEEN dbo.MidnightOf(CAST({0} as datetime)) AND dbo.DayEndOf(CAST({1} as datetime))
                   AND rcvr.ref_type = CAST({2} as nvarchar(1))
                AND rcvr.first_article = 0
            ORDER BY rcvr.trans_date DESC",
            DateStart,
            DateEnd,
            RefType);

            #region CRUD LoadColumn
            var ResultTable1LoadRequest = collectionLoadRequestFactory.SQLLoad(columns: new List<string>()
            {
                "item",
                "description",
                "ref_type",
                "Received",
                "Accepted",
                "Rejected",
                "OnHold",
                "trans_date",
                "u_m",
            },
            loadForChange: false,
            lockingType: LockingType.None,
            tableName: "#ResultTable",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("Received > 0"),
            orderByClause: collectionLoadRequestFactory.Clause(" Received DESC"));

            var ResultTable1LoadResponse = this.appDB.Load(ResultTable1LoadRequest);
            Data = ResultTable1LoadResponse;
            #endregion  LoadColumn

            this.sQLExpressionExecutor.Execute("DROP TABLE #ResultTable");
            return (Data, Severity);

        }
        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_Homepage_QCRejectionPercentageByItemSp(
            string AltExtGenSp,
            DateTime? DateEnd,
            DateTime? DateStart,
            string RefType)
        {
            GenericDateType _DateEnd = DateEnd;
            GenericDateType _DateStart = DateStart;
            QCRefType _RefType = RefType;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "DateEnd", _DateEnd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DateStart", _DateStart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);

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
