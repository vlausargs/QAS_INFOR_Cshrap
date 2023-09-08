//PROJECT NAME: Codes
//CLASS NAME: CLM_PerTot.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Utilities;
using CSI.Data.SQL;

namespace CSI.Codes
{
    public class CLM_PerTot : ICLM_PerTot
    {
        readonly IApplicationDB appDB;

        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICLM_PerTotByProdcode iCLM_PerTotByProdcode;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public CLM_PerTot(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICLM_PerTotByProdcode iCLM_PerTotByProdcode,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IDateTimeUtil dateTimeUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iCLM_PerTotByProdcode = iCLM_PerTotByProdcode;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.dateTimeUtil = dateTimeUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_PerTotSp()
        {

            ICollectionLoadResponse Data = null;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            DateTime? CurrentDate = null;
            DateType _EndDate = DBNull.Value;
            DateTime? EndDate = null;
            int? Severity = null;
            ListYesNoType _AnalyticalLedger = DBNull.Value;
            int? AnalyticalLedger = null;
            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_PerTotSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_PerTotSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_PerTotSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_CLM_PerTotSp(ALTGEN_SpName);
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
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_PerTotSp") != null)
            {
                var EXTGEN = AltExtGen_CLM_PerTotSp("dbo.EXTGEN_CLM_PerTotSp");
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            #region CRUD LoadToVariable
            var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_AnalyticalLedger,"analytical_ledger"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "parms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
            if (parmsLoadResponse.Items.Count > 0)
            {
                AnalyticalLedger = _AnalyticalLedger;
            }
            #endregion  LoadToVariable

            CurrentDate = convertToUtil.ToDateTime(scalarFunction.Execute<DateTime>("GETDATE"));
            Severity = 0;

            #region CRUD LoadToVariable
            var PeriodsViewASPVLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_EndDate,"PV.endDate"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "PeriodsView AS PV",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL({0}, dbo.MidnightOfSp(GETDATE())) BETWEEN PV.startDate AND pv.endDate", EndDate),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var PeriodsViewASPVLoadResponse = this.appDB.Load(PeriodsViewASPVLoadRequest);
            if (PeriodsViewASPVLoadResponse.Items.Count > 0)
            {
                EndDate = _EndDate;
            }
            #endregion  LoadToVariable

            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @PeriodsTable TABLE (
				    StartDate DateType  ,
				    EndDate   DateType  ,
				    Seq       SMALLINT   IDENTITY (1, 1),
				    Amount    AmountType);
				SELECT * into #tv_PeriodsTable from @PeriodsTable
				ALTER TABLE #tv_PeriodsTable ADD PRIMARY KEY (Seq)");

            #region CRUD LoadToRecord
            var PeriodsTableLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"StartDate","startDate"},
                    {"EndDate","endDate"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 4,
                tableName: "PeriodsView",
                fromClause: collectionLoadRequestFactory.Clause(" AS PV"),
                whereClause: collectionLoadRequestFactory.Clause("EndDate <= {0}", EndDate),
                orderByClause: collectionLoadRequestFactory.Clause(" startDate DESC"));
            var PeriodsTableLoadResponse = this.appDB.Load(PeriodsTableLoadRequest);
            #endregion  LoadToRecord

            #region CRUD InsertByRecords
            var PeriodsTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_PeriodsTable",
                items: PeriodsTableLoadResponse.Items);

            this.appDB.Insert(PeriodsTableInsertRequest);
            #endregion InsertByRecords

            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @tmp_pertot TABLE (
				    Whse         NVARCHAR (4) ,
				    ProductCode  NVARCHAR (10),
				    InvAcct      NVARCHAR (12),
				    InvAcctUnit1 NVARCHAR (12),
				    InvAcctUnit2 NVARCHAR (12),
				    InvAcctUnit3 NVARCHAR (12),
				    InvAcctUnit4 NVARCHAR (12),
				    UBBalance1   AmountType   ,
				    UBBalance2   AmountType   ,
				    UBBalance3   AmountType   ,
				    UBBalance4   AmountType   ,
				    SiteRef      SiteType     );
				SELECT * into #tv_tmp_pertot from @tmp_pertot");

            #region CRUD InsertByMethodCall
            //Please Generate the bounce for this stored procedure:CLM_PerTotByProdcodeSp
            var tv_tmp_pertotExecResult = this.iCLM_PerTotByProdcode.CLM_PerTotByProdcodeSp(FilterString: null);
            var tv_tmp_pertotLoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(tv_tmp_pertotExecResult.Data,
                new List<string>() { "Whse",
                        "ProductCode",
                        "InvAcct",
                        "InvAcctUnit1",
                        "InvAcctUnit2",
                        "InvAcctUnit3",
                        "InvAcctUnit4",
                        "UBBalance1",
                        "UBBalance2",
                        "UBBalance3",
                        "UBBalance4",
                        "SiteRef" });
            var tv_tmp_pertotInsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_pertot",
                items: tv_tmp_pertotLoadResponse.Items);

            this.appDB.Insert(tv_tmp_pertotInsertRequest);

            #endregion InsertByMethodCall

            #region CRUD LoadToRecord
            var tv_PeriodsTable1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "Amount", "PT.Amount" },
                    { "u0", "(SELECT SUM(UBBalance1) FROM   #tv_tmp_pertot)" },
                },
                tableName: "#tv_PeriodsTable", 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(" AS PT"),
                whereClause: collectionLoadRequestFactory.Clause("PT.Seq = 4"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_PeriodsTable1LoadResponse = this.appDB.Load(tv_PeriodsTable1LoadRequest);
            #endregion  LoadToRecord

            #region CRUD UpdateByRecord
            foreach (var tv_PeriodsTable1Item in tv_PeriodsTable1LoadResponse.Items)
            {
                tv_PeriodsTable1Item.SetValue<decimal?>("Amount", tv_PeriodsTable1Item.GetValue<decimal?>("u0"));
            };

            var tv_PeriodsTable1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_PeriodsTable",
                items: tv_PeriodsTable1LoadResponse.Items);

            this.appDB.Update(tv_PeriodsTable1RequestUpdate);
            #endregion UpdateByRecord

            #region CRUD LoadToRecord
            var tv_PeriodsTable3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "Amount", "PT.Amount" },
                    { "u0", "(SELECT SUM(UBBalance2) FROM   #tv_tmp_pertot)" },
                },
                tableName: "#tv_PeriodsTable", 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(" AS PT"),
                whereClause: collectionLoadRequestFactory.Clause("PT.Seq = 3"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_PeriodsTable3LoadResponse = this.appDB.Load(tv_PeriodsTable3LoadRequest);
            #endregion  LoadToRecord

            #region CRUD UpdateByRecord
            foreach (var tv_PeriodsTable3Item in tv_PeriodsTable3LoadResponse.Items)
            {
                tv_PeriodsTable3Item.SetValue<decimal?>("Amount", tv_PeriodsTable3Item.GetValue<decimal?>("u0"));
            };

            var tv_PeriodsTable3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_PeriodsTable",
                items: tv_PeriodsTable3LoadResponse.Items);

            this.appDB.Update(tv_PeriodsTable3RequestUpdate);
            #endregion UpdateByRecord

            #region CRUD LoadToRecord
            var tv_PeriodsTable5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "Amount", "PT.Amount" },
                    { "u0", "(SELECT SUM(UBBalance3) FROM   #tv_tmp_pertot)" },
                },
                tableName: "#tv_PeriodsTable",
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(" AS PT"),
                whereClause: collectionLoadRequestFactory.Clause("PT.Seq = 2"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_PeriodsTable5LoadResponse = this.appDB.Load(tv_PeriodsTable5LoadRequest);
            #endregion  LoadToRecord

            #region CRUD UpdateByRecord
            foreach (var tv_PeriodsTable5Item in tv_PeriodsTable5LoadResponse.Items)
            {
                tv_PeriodsTable5Item.SetValue<decimal?>("Amount", tv_PeriodsTable5Item.GetValue<decimal?>("u0"));
            };

            var tv_PeriodsTable5RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_PeriodsTable",
                items: tv_PeriodsTable5LoadResponse.Items);

            this.appDB.Update(tv_PeriodsTable5RequestUpdate);
            #endregion UpdateByRecord

            #region CRUD LoadToRecord
            var tv_PeriodsTable7LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "Amount", "PT.Amount" },
                    { "u0", "(SELECT SUM(UBBalance4) FROM   #tv_tmp_pertot)" },
                },
                tableName: "#tv_PeriodsTable",
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(" AS PT"),
                whereClause: collectionLoadRequestFactory.Clause("PT.Seq = 1"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_PeriodsTable7LoadResponse = this.appDB.Load(tv_PeriodsTable7LoadRequest);
            #endregion  LoadToRecord

            #region CRUD UpdateByRecord
            foreach (var tv_PeriodsTable7Item in tv_PeriodsTable7LoadResponse.Items)
            {
                tv_PeriodsTable7Item.SetValue<decimal?>("Amount", tv_PeriodsTable7Item.GetValue<decimal?>("u0"));
            };

            var tv_PeriodsTable7RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_PeriodsTable",
                items: tv_PeriodsTable7LoadResponse.Items);

            this.appDB.Update(tv_PeriodsTable7RequestUpdate);
            #endregion UpdateByRecord

            UnionUtil unionTable = new UnionUtil(UnionType.Union, $"EndDateChar");

            #region CRUD LoadToRecord
            var tv_PeriodsTable8LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"Amount1","CAST (NULL AS INT)"},
                    {"Amount2","CAST (NULL AS INT)"},
                    {"Amount3","CAST (NULL AS INT)"},
                    {"Amount4","PT.Amount"},
                    {"EndDateChar","CAST (NULL AS NVARCHAR)"},
                    {"u0","PT.EndDate"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_PeriodsTable",
                fromClause: collectionLoadRequestFactory.Clause(" AS PT"),
                whereClause: collectionLoadRequestFactory.Clause("PT.Seq = 1"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_PeriodsTable8LoadResponse = this.appDB.Load(tv_PeriodsTable8LoadRequest);
            #endregion  LoadToRecord

            foreach (var tv_PeriodsTable8Item in tv_PeriodsTable8LoadResponse.Items)
            {
                tv_PeriodsTable8Item.SetValue<int?>("Amount1", 0);
                tv_PeriodsTable8Item.SetValue<int?>("Amount2", 0);
                tv_PeriodsTable8Item.SetValue<int?>("Amount3", 0);
                tv_PeriodsTable8Item.SetValue<decimal?>("Amount4", tv_PeriodsTable8Item.GetValue<decimal?>("Amount4"));
                tv_PeriodsTable8Item.SetValue<string>("EndDateChar", dateTimeUtil.ConvertToString(tv_PeriodsTable8Item.GetValue<DateTime?>("u0"), "MM/dd/yyyy"));
            };

            Data = tv_PeriodsTable8LoadResponse;

            unionTable.Add(tv_PeriodsTable8LoadResponse);

            #region CRUD LoadToRecord
            var tv_PeriodsTable9LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"Amount1","CAST (NULL AS INT)"},
                    {"Amount2","CAST (NULL AS INT)"},
                    {"Amount3","PT.Amount"},
                    {"Amount4","CAST (NULL AS INT)"},
                    {"EndDateChar","CAST (NULL AS NVARCHAR)"},
                    {"u0","PT.EndDate"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_PeriodsTable",
                fromClause: collectionLoadRequestFactory.Clause(" AS PT"),
                whereClause: collectionLoadRequestFactory.Clause("PT.Seq = 2"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_PeriodsTable9LoadResponse = this.appDB.Load(tv_PeriodsTable9LoadRequest);
            #endregion  LoadToRecord

            foreach (var tv_PeriodsTable9Item in tv_PeriodsTable9LoadResponse.Items)
            {
                tv_PeriodsTable9Item.SetValue<int?>("Amount1", 0);
                tv_PeriodsTable9Item.SetValue<int?>("Amount2", 0);
                tv_PeriodsTable9Item.SetValue<decimal?>("Amount3", tv_PeriodsTable9Item.GetValue<decimal?>("Amount3"));
                tv_PeriodsTable9Item.SetValue<int?>("Amount4", 0);
                tv_PeriodsTable9Item.SetValue<string>("EndDateChar", dateTimeUtil.ConvertToString(tv_PeriodsTable9Item.GetValue<DateTime?>("u0"), "MM/dd/yyyy"));
            };

            Data = tv_PeriodsTable9LoadResponse;

            unionTable.Add(tv_PeriodsTable9LoadResponse);

            #region CRUD LoadToRecord
            var tv_PeriodsTable10LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"Amount1","CAST (NULL AS INT)"},
                    {"Amount2","PT.Amount"},
                    {"Amount3","CAST (NULL AS INT)"},
                    {"Amount4","CAST (NULL AS INT)"},
                    {"EndDateChar","CAST (NULL AS NVARCHAR)"},
                    {"u0","PT.EndDate"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_PeriodsTable",
                fromClause: collectionLoadRequestFactory.Clause(" AS PT"),
                whereClause: collectionLoadRequestFactory.Clause("PT.Seq = 3"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_PeriodsTable10LoadResponse = this.appDB.Load(tv_PeriodsTable10LoadRequest);
            #endregion  LoadToRecord

            foreach (var tv_PeriodsTable10Item in tv_PeriodsTable10LoadResponse.Items)
            {
                tv_PeriodsTable10Item.SetValue<int?>("Amount1", 0);
                tv_PeriodsTable10Item.SetValue<decimal?>("Amount2", tv_PeriodsTable10Item.GetValue<decimal?>("Amount2"));
                tv_PeriodsTable10Item.SetValue<int?>("Amount3", 0);
                tv_PeriodsTable10Item.SetValue<int?>("Amount4", 0);
                tv_PeriodsTable10Item.SetValue<string>("EndDateChar", dateTimeUtil.ConvertToString(tv_PeriodsTable10Item.GetValue<DateTime?>("u0"), "MM/dd/yyyy"));
            };

            Data = tv_PeriodsTable10LoadResponse;

            unionTable.Add(tv_PeriodsTable10LoadResponse);

            #region CRUD LoadToRecord
            var tv_PeriodsTable11LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"Amount1","PT.Amount"},
                    {"Amount2","CAST (NULL AS INT)"},
                    {"Amount3","CAST (NULL AS INT)"},
                    {"Amount4","CAST (NULL AS INT)"},
                    {"EndDateChar","CAST (NULL AS NVARCHAR)"},
                    {"u0","PT.EndDate"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_PeriodsTable",
                fromClause: collectionLoadRequestFactory.Clause(" AS PT"),
                whereClause: collectionLoadRequestFactory.Clause("PT.Seq = 4"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_PeriodsTable11LoadResponse = this.appDB.Load(tv_PeriodsTable11LoadRequest);
            #endregion  LoadToRecord

            foreach (var tv_PeriodsTable11Item in tv_PeriodsTable11LoadResponse.Items)
            {
                tv_PeriodsTable11Item.SetValue<decimal?>("Amount1", tv_PeriodsTable11Item.GetValue<decimal?>("Amount1"));
                tv_PeriodsTable11Item.SetValue<int?>("Amount2", 0);
                tv_PeriodsTable11Item.SetValue<int?>("Amount3", 0);
                tv_PeriodsTable11Item.SetValue<int?>("Amount4", 0);
                tv_PeriodsTable11Item.SetValue<string>("EndDateChar", dateTimeUtil.ConvertToString(tv_PeriodsTable11Item.GetValue<DateTime?>("u0"), "MM/dd/yyyy"));
            };

            Data = tv_PeriodsTable11LoadResponse;

            unionTable.Add(tv_PeriodsTable11LoadResponse);
            var unionTableResult = unionTable.Process();
            Data = unionTableResult;
            return (Data, Severity);

        }
        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_CLM_PerTotSp(
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
