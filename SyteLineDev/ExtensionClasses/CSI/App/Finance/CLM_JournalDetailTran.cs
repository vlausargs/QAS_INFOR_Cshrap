//PROJECT NAME: Finance
//CLASS NAME: CLM_JournalDetailTran.cs

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

namespace CSI.Finance
{
    public class CLM_JournalDetailTran : ICLM_JournalDetailTran
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public CLM_JournalDetailTran(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_JournalDetailTranSp(
            string Type = "E",
            string JournalId = null,
            string ControlPrefix = null,
            string ControlSite = null,
            int? ControlYear = null,
            int? ControlPeriod = null,
            decimal? ControlNumber = null)
        {
            ICollectionLoadResponse Data = null;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            AmountType _SumDomAmount = DBNull.Value;
            decimal? SumDomAmount = null;
            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_JournalDetailTranSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_JournalDetailTranSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_JournalDetailTranSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_CLM_JournalDetailTranSp(_ALTGEN_SpName,
                        Type,
                        JournalId,
                        ControlPrefix,
                        ControlSite,
                        ControlYear,
                        ControlPeriod,
                        ControlNumber);
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_JournalDetailTranSp") != null)
            {
                var EXTGEN = AltExtGen_CLM_JournalDetailTranSp("dbo.EXTGEN_CLM_JournalDetailTranSp",
                    Type,
                    JournalId,
                    ControlPrefix,
                    ControlSite,
                    ControlYear,
                    ControlPeriod,
                    ControlNumber);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            Severity = 0;
            SumDomAmount = 0;
            if (sQLUtil.SQLEqual(Type, "E") == true)
            {
                #region CRUD LoadToVariable
                var ledgerLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_SumDomAmount,"SUM(CASE WHEN dom_amount > 0 THEN dom_amount ELSE 0 END)"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "ledger",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("(Control_Prefix = {0} OR {0} IS NULL) AND (Control_Site = {3} OR {3} IS NULL) AND (Control_Year = {4} OR {4} IS NULL) AND (Control_Period = {1} OR {1} IS NULL) AND (Control_Number = {2} OR {2} IS NULL) AND (from_id = {5} OR {5} IS NULL)", ControlPrefix, ControlPeriod, ControlNumber, ControlSite, ControlYear, JournalId),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var ledgerLoadResponse = this.appDB.Load(ledgerLoadRequest);
                if (ledgerLoadResponse.Items.Count > 0)
                {
                    SumDomAmount = _SumDomAmount;
                }
                #endregion  LoadToVariable

                #region CRUD LoadToRecord
                var ledger1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"Acct","led.acct"},
                        {"AcctUnit1","led.acct_unit1"},
                        {"AcctUnit2","led.acct_unit2"},
                        {"AcctUnit3","led.acct_unit3"},
                        {"AcctUnit4","led.acct_unit4"},
                        {"ChaDescription","cha.description"},
                        {"DerDomAmountDebit","CAST (NULL AS DECIMAL)"},
                        {"DerDomAmountCredit","CAST (NULL AS DECIMAL)"},
                        {"ExchRate","led.exch_rate"},
                        {"DerForAmountDebit","CAST (NULL AS DECIMAL)"},
                        {"DerForAmountCredit","CAST (NULL AS DECIMAL)"},
                        {"Cancellation","led.cancellation"},
                        {"SumDomAmount","CAST (NULL AS DECIMAL)"},
                        {"u0","led.dom_amount"},
                        {"u1","led.for_amount"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "ledger",
                    fromClause: collectionLoadRequestFactory.Clause(" AS led LEFT OUTER JOIN chart AS cha ON cha.acct = led.acct"),
                    whereClause: collectionLoadRequestFactory.Clause("(led.Control_Prefix = {0} OR {0} IS NULL) AND (led.Control_Site = {3} OR {3} IS NULL) AND (led.Control_Year = {4} OR {4} IS NULL) AND (led.Control_Period = {1} OR {1} IS NULL) AND (led.Control_Number = {2} OR {2} IS NULL) AND (led.from_id = {5} OR {5} IS NULL)", ControlPrefix, ControlPeriod, ControlNumber, ControlSite, ControlYear, JournalId),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var ledger1LoadResponse = this.appDB.Load(ledger1LoadRequest);
                #endregion  LoadToRecord

                foreach (var ledger1Item in ledger1LoadResponse.Items)
                {
                    ledger1Item.SetValue<string>("Acct", ledger1Item.GetValue<string>("Acct"));
                    ledger1Item.SetValue<string>("AcctUnit1", ledger1Item.GetValue<string>("AcctUnit1"));
                    ledger1Item.SetValue<string>("AcctUnit2", ledger1Item.GetValue<string>("AcctUnit2"));
                    ledger1Item.SetValue<string>("AcctUnit3", ledger1Item.GetValue<string>("AcctUnit3"));
                    ledger1Item.SetValue<string>("AcctUnit4", ledger1Item.GetValue<string>("AcctUnit4"));
                    ledger1Item.SetValue<string>("ChaDescription", ledger1Item.GetValue<string>("ChaDescription"));
                    ledger1Item.SetValue<decimal?>("DerDomAmountDebit", ((sQLUtil.SQLGreaterThan(ledger1Item.GetValue<decimal?>("u0"), 0) == true ? ledger1Item.GetValue<decimal?>("u0") : 0)));
                    ledger1Item.SetValue<decimal?>("DerDomAmountCredit", ((sQLUtil.SQLLessThan(ledger1Item.GetValue<decimal?>("u0"), 0) == true ? -ledger1Item.GetValue<decimal?>("u0") : 0)));
                    ledger1Item.SetValue<decimal?>("ExchRate", ledger1Item.GetValue<decimal?>("ExchRate"));
                    ledger1Item.SetValue<decimal?>("DerForAmountDebit", ((sQLUtil.SQLGreaterThan(ledger1Item.GetValue<decimal?>("u1"), 0) == true ? ledger1Item.GetValue<decimal?>("u1") : 0)));
                    ledger1Item.SetValue<decimal?>("DerForAmountCredit", ((sQLUtil.SQLLessThan(ledger1Item.GetValue<decimal?>("u1"), 0) == true ? -ledger1Item.GetValue<decimal?>("u1") : 0)));
                    ledger1Item.SetValue<int?>("Cancellation", ledger1Item.GetValue<int?>("Cancellation"));
                    ledger1Item.SetValue<decimal?>("SumDomAmount", SumDomAmount);
                };

                Data = ledger1LoadResponse;
            }
            else
            {
                #region CRUD LoadToVariable
                var journalLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_SumDomAmount,"SUM(CASE WHEN dom_amount > 0 THEN dom_amount ELSE 0 END)"},
                    },
                    loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "journal",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("(Control_Prefix = {0} OR {0} IS NULL) AND (Control_Site = {3} OR {3} IS NULL) AND (Control_Year = {4} OR {4} IS NULL) AND (Control_Period = {1} OR {1} IS NULL) AND (Control_Number = {2} OR {2} IS NULL) AND (id = {5} OR {5} IS NULL)", ControlPrefix, ControlPeriod, ControlNumber, ControlSite, ControlYear, JournalId),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var journalLoadResponse = this.appDB.Load(journalLoadRequest);
                if (journalLoadResponse.Items.Count > 0)
                {
                    SumDomAmount = _SumDomAmount;
                }
                #endregion  LoadToVariable

                #region CRUD LoadToRecord
                var journal1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"Acct","jnl.acct"},
                        {"AcctUnit1","jnl.acct_unit1"},
                        {"AcctUnit2","jnl.acct_unit2"},
                        {"AcctUnit3","jnl.acct_unit3"},
                        {"AcctUnit4","jnl.acct_unit4"},
                        {"ChaDescription","cha.description"},
                        {"DerDomAmountDebit","CAST (NULL AS DECIMAL)"},
                        {"DerDomAmountCredit","CAST (NULL AS DECIMAL)"},
                        {"ExchRate","jnl.exch_rate"},
                        {"DerForAmountDebit","CAST (NULL AS DECIMAL)"},
                        {"DerForAmountCredit","CAST (NULL AS DECIMAL)"},
                        {"Cancellation","jnl.cancellation"},
                        {"SumDomAmount","CAST (NULL AS DECIMAL)"},
                        {"u0","jnl.dom_amount"},
                        {"u1","jnl.for_amount"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "journal",
                    fromClause: collectionLoadRequestFactory.Clause(" AS jnl LEFT OUTER JOIN chart AS cha ON cha.acct = jnl.acct"),
                    whereClause: collectionLoadRequestFactory.Clause("(jnl.Control_Prefix = {0} OR {0} IS NULL) AND (jnl.Control_Site = {3} OR {3} IS NULL) AND (jnl.Control_Year = {4} OR {4} IS NULL) AND (jnl.Control_Period = {1} OR {1} IS NULL) AND (jnl.Control_Number = {2} OR {2} IS NULL) AND (jnl.id = {5} OR {5} IS NULL)", ControlPrefix, ControlPeriod, ControlNumber, ControlSite, ControlYear, JournalId),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var journal1LoadResponse = this.appDB.Load(journal1LoadRequest);
                #endregion  LoadToRecord

                foreach (var journal1Item in journal1LoadResponse.Items)
                {
                    journal1Item.SetValue<string>("Acct", journal1Item.GetValue<string>("Acct"));
                    journal1Item.SetValue<string>("AcctUnit1", journal1Item.GetValue<string>("AcctUnit1"));
                    journal1Item.SetValue<string>("AcctUnit2", journal1Item.GetValue<string>("AcctUnit2"));
                    journal1Item.SetValue<string>("AcctUnit3", journal1Item.GetValue<string>("AcctUnit3"));
                    journal1Item.SetValue<string>("AcctUnit4", journal1Item.GetValue<string>("AcctUnit4"));
                    journal1Item.SetValue<string>("ChaDescription", journal1Item.GetValue<string>("ChaDescription"));
                    journal1Item.SetValue<decimal?>("DerDomAmountDebit", ((sQLUtil.SQLGreaterThan(journal1Item.GetValue<decimal?>("u0"), 0) == true ? journal1Item.GetValue<decimal?>("u0") : 0)));
                    journal1Item.SetValue<decimal?>("DerDomAmountCredit", ((sQLUtil.SQLLessThan(journal1Item.GetValue<decimal?>("u0"), 0) == true ? -journal1Item.GetValue<decimal?>("u0") : 0)));
                    journal1Item.SetValue<decimal?>("ExchRate", journal1Item.GetValue<decimal?>("ExchRate"));
                    journal1Item.SetValue<decimal?>("DerForAmountDebit", ((sQLUtil.SQLGreaterThan(journal1Item.GetValue<decimal?>("u1"), 0) == true ? journal1Item.GetValue<decimal?>("u1") : 0)));
                    journal1Item.SetValue<decimal?>("DerForAmountCredit", ((sQLUtil.SQLLessThan(journal1Item.GetValue<decimal?>("u1"), 0) == true ? -journal1Item.GetValue<decimal?>("u1") : 0)));
                    journal1Item.SetValue<int?>("Cancellation", journal1Item.GetValue<int?>("Cancellation"));
                    journal1Item.SetValue<decimal?>("SumDomAmount", SumDomAmount);
                };

                Data = journal1LoadResponse;
            }
            return (Data, Severity);

        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_CLM_JournalDetailTranSp(
            string AltExtGenSp,
            string Type = "E",
            string JournalId = null,
            string ControlPrefix = null,
            string ControlSite = null,
            int? ControlYear = null,
            int? ControlPeriod = null,
            decimal? ControlNumber = null)
        {
            StringType _Type = Type;
            JournalIdType _JournalId = JournalId;
            JourControlPrefixType _ControlPrefix = ControlPrefix;
            SiteType _ControlSite = ControlSite;
            FiscalYearType _ControlYear = ControlYear;
            FinPeriodType _ControlPeriod = ControlPeriod;
            LastTranType _ControlNumber = ControlNumber;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);

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
