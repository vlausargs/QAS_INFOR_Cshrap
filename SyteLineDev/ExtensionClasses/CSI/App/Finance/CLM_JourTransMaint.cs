//PROJECT NAME: Finance
//CLASS NAME: CLM_JourTransMaint.cs

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

namespace CSI.Finance
{
    public class CLM_JourTransMaint : ICLM_JourTransMaint
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IBuildXMLFilterString iBuildXMLFilterString;
        readonly ITransactionFactory transactionFactory;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly IRaiseError raiseError;
        readonly ISQLValueComparerUtil sQLUtil;

        public CLM_JourTransMaint(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IBuildXMLFilterString iBuildXMLFilterString,
            ITransactionFactory transactionFactory,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            IRaiseError raiseError,
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
            this.iBuildXMLFilterString = iBuildXMLFilterString;
            this.transactionFactory = transactionFactory;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.raiseError = raiseError;
            this.sQLUtil = sQLUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode,
            string Infobar)
        CLM_JourTransMaintSp(
            string pJournalId,
            string Infobar)
        {

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {

                ICollectionLoadResponse Data = null;

                StringType _ALTGEN_SpName = DBNull.Value;
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                decimal? BalDr = null;
                decimal? BalCr = null;
                AmountType _TotDr = DBNull.Value;
                decimal? TotDr = null;
                AmountType _TotCr = DBNull.Value;
                decimal? TotCr = null;
                decimal? RevBalDr = null;
                decimal? RevBalCr = null;
                AmountType _RevTotDr = DBNull.Value;
                decimal? RevTotDr = null;
                AmountType _RevTotCr = DBNull.Value;
                decimal? RevTotCr = null;
                int? Severity = null;
                string SelectionStr = null;
                string pJournalIdStr = null;
                string BalDrStr = null;
                string BalCrStr = null;
                string TotDrStr = null;
                string TotCrStr = null;
                string RevBalDrStr = null;
                string RevBalCrStr = null;
                string RevTotDrStr = null;
                string RevTotCrStr = null;
                string SelectionClause = null;
                string FromClause = null;
                string WhereClause = null;
                string AdditionalClause = null;
                string KeyColumns = null;
                string FilterString = null;
                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_JourTransMaintSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_JourTransMaintSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_JourTransMaintSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                        var ALTGEN = AltExtGen_CLM_JourTransMaintSp(ALTGEN_SpName,
                            pJournalId,
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
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_JourTransMaintSp") != null)
                {
                    var EXTGEN = AltExtGen_CLM_JourTransMaintSp("dbo.EXTGEN_CLM_JourTransMaintSp",
                        pJournalId,
                        Infobar);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity, EXTGEN.Infobar);
                    }
                }

                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");

                #region CRUD LoadToVariable
                var journalLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_TotDr,"SUM(CASE WHEN dom_amount > 0 THEN dom_amount ELSE 0 END)"},
                        {_TotCr,"-SUM(CASE WHEN dom_amount < 0 THEN dom_amount ELSE 0 END)"},
                        {_RevTotDr,"SUM(CASE WHEN dom_amount > 0              AND reverse <> 0 THEN dom_amount ELSE 0 END)"},
                        {_RevTotCr,"-SUM(CASE WHEN dom_amount < 0               AND reverse <> 0 THEN dom_amount ELSE 0 END)"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "journal",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("journal.id = {0} AND (journal.acct IS NULL OR journal.acct = '' OR journal.trans_date IS NULL OR journal.dom_amount IS NULL)", pJournalId),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var journalLoadResponse = this.appDB.Load(journalLoadRequest);
                if (journalLoadResponse.Items.Count > 0)
                {
                    TotDr = _TotDr;
                    TotCr = _TotCr;
                    RevTotDr = _RevTotDr;
                    RevTotCr = _RevTotCr;
                }
                #endregion  LoadToVariable

                BalDr = (decimal?)((sQLUtil.SQLGreaterThan(TotDr - TotCr, 0) == true ? TotDr - TotCr : null));
                BalCr = (decimal?)((sQLUtil.SQLLessThan(TotDr - TotCr, 0) == true ? -(TotDr - TotCr) : null));
                RevBalDr = (decimal?)((sQLUtil.SQLGreaterThan(RevTotDr - RevTotCr, 0) == true ? RevTotDr - RevTotCr : null));
                RevBalCr = (decimal?)((sQLUtil.SQLLessThan(RevTotDr - RevTotCr, 0) == true ? -(RevTotDr - RevTotCr) : null));
                if (pJournalId == null)
                {
                    pJournalIdStr = "NULL";

                }
                else
                {
                    pJournalIdStr = Convert.ToString(pJournalId);

                }
                if (BalDr == null)
                {
                    BalDrStr = "NULL";

                }
                else
                {
                    BalDrStr = Convert.ToString((decimal?)BalDr);

                }
                if (BalCr == null)
                {
                    BalCrStr = "NULL";

                }
                else
                {
                    BalCrStr = Convert.ToString((decimal?)BalCr);

                }
                if (TotDr == null)
                {
                    TotDrStr = "NULL";

                }
                else
                {
                    TotDrStr = Convert.ToString((decimal?)TotDr);

                }
                if (TotCr == null)
                {
                    TotCrStr = "NULL";

                }
                else
                {
                    TotCrStr = Convert.ToString((decimal?)TotCr);

                }
                if (RevBalDr == null)
                {
                    RevBalDrStr = "NULL";

                }
                else
                {
                    RevBalDrStr = Convert.ToString((decimal?)RevBalDr);

                }
                if (RevBalCr == null)
                {
                    RevBalCrStr = "NULL";

                }
                else
                {
                    RevBalCrStr = Convert.ToString((decimal?)RevBalCr);

                }
                if (RevTotDr == null)
                {
                    RevTotDrStr = "NULL";

                }
                else
                {
                    RevTotDrStr = Convert.ToString((decimal?)RevTotDr);

                }
                if (RevTotCr == null)
                {
                    RevTotCrStr = "NULL";

                }
                else
                {
                    RevTotCrStr = Convert.ToString((decimal?)RevTotCr);

                }
                SelectionStr = stringUtil.Concat(@"SELECT  id
					                              , seq
					                              , trans_date
					                              , acct
					                              , acct_unit1
					                              , acct_unit2
					                              , acct_unit3
					                              , acct_unit4
					                              ,  CASE WHEN dom_amount > 0 THEN dom_amount ELSE NULL END AS Dr
					                              , -CASE WHEN dom_amount < 0 THEN dom_amount ELSE NULL END AS Cr
					                              , dom_amount
					                              , reverse
					                              , ref
					                              , ", stringUtil.Replace(
                    BalDrStr,
                    "'",
                    "''"), @" AS BalDr
					                              , ", stringUtil.Replace(
                    BalCrStr,
                    "'",
                    "''"), @" AS BalCr
					                              , ", stringUtil.Replace(
                    TotDrStr,
                    "'",
                    "''"), @" AS TotDr
					                              , ", stringUtil.Replace(
                    TotCrStr,
                    "'",
                    "''"), @" AS TotCr
					                              , ", stringUtil.Replace(
                    RevBalDrStr,
                    "'",
                    "''"), @" AS RevBalDr
					                              , ", stringUtil.Replace(
                    RevBalCrStr,
                    "'",
                    "''"), @" AS RevBalCr
					                              , ", stringUtil.Replace(
                    RevTotDrStr,
                    "'",
                    "''"), @" AS RevTotDr
					                              , ", stringUtil.Replace(
                    RevTotDrStr,
                    "'",
                    "''"), " AS RevTotCr");
                SelectionClause = "";
                FromClause = "";
                WhereClause = "";
                AdditionalClause = "";
                KeyColumns = "";
                FilterString = "";

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString = this.iBuildXMLFilterString.BuildXMLFilterStringSp(
                    PropertyName: "pJournalIdStr",
                    Value: pJournalIdStr,
                    DataType: "Nvarchar(100)",
                    NameInParmList: "@pJournalIdStr",
                    IsPropertyInWhereClause: 0,
                    XmlFilterString: FilterString);
                Severity = BuildXMLFilterString.ReturnCode;
                FilterString = BuildXMLFilterString.XmlFilterString;

                #endregion ExecuteMethodCall

                SelectionClause = SelectionStr;
                FromClause = "FROM journal";
                WhereClause = @"WHERE journal.id = @pJournalIdStr
					                     AND ( journal.acct IS NULL
					                     OR journal.acct = ''
					                     OR journal.trans_date IS NULL
					                     OR journal.dom_amount IS NULL )";
                AdditionalClause = "ORDER BY id";
                KeyColumns = "id";
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#DynamicParameters") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters");

                }

                this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause VeryLongListType
					,@FromClause VeryLongListType
					,@WhereClause VeryLongListType
					,@AdditionalClause VeryLongListType
					,@KeyColumns VeryLongListType
					,@FilterString VeryLongListType
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

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    goto RAISE_ERROR;

                }
            RAISE_ERROR:;
                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    raiseError.RaiseErrorSp(
                        Infobar,
                        Severity,
                        1);

                }
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
        AltExtGen_CLM_JourTransMaintSp(
            string AltExtGenSp,
            string pJournalId,
            string Infobar)
        {
            JournalIdType _pJournalId = pJournalId;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "pJournalId", _pJournalId, ParameterDirection.Input);
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
