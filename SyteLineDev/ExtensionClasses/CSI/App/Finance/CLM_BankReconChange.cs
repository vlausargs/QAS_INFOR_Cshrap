//PROJECT NAME: Finance
//CLASS NAME: CLM_BankReconChange.cs

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
    public class CLM_BankReconChange : ICLM_BankReconChange
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
        readonly ITransactionFactory transactionFactory;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly ISQLCollectionLoad sQLCollectionLoad;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly IDayEndOf iDayEndOf;
        readonly IHighDate iHighDate;
        readonly ILowDate iLowDate;
        readonly IHighInt iHighInt;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ILowInt iLowInt;
        readonly ICstr iCstr;

        public CLM_BankReconChange(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ITransactionFactory transactionFactory,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            ISQLCollectionLoad sQLCollectionLoad,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            IDayEndOf iDayEndOf,
            IHighDate iHighDate,
            ILowDate iLowDate,
            IHighInt iHighInt,
            ISQLValueComparerUtil sQLUtil,
            ILowInt iLowInt,
            ICstr iCstr)
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
            this.transactionFactory = transactionFactory;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.sQLCollectionLoad = sQLCollectionLoad;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.iDayEndOf = iDayEndOf;
            this.iHighDate = iHighDate;
            this.iLowDate = iLowDate;
            this.iHighInt = iHighInt;
            this.sQLUtil = sQLUtil;
            this.iLowInt = iLowInt;
            this.iCstr = iCstr;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode,
            string Infobar)
        CLM_BankReconChangeSp(
            string pBankCode,
            DateTime? pStartTransDate,
            DateTime? pEndTransDate,
            int? pStartTransNum,
            int? pEndTransNum,
            string pTypes,
            int? pCommit,
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
                int? Severity = null;
                string WhereStr = null;
                string SelectionClause = null;
                string FromClause = null;
                string WhereClause = null;
                string AdditionalClause = null;
                string KeyColumns = null;
                string FilterString = null;

                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_BankReconChangeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_BankReconChangeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_BankReconChangeSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                        var ALTGEN = AltExtGen_CLM_BankReconChangeSp(ALTGEN_SpName,
                            pBankCode,
                            pStartTransDate,
                            pEndTransDate,
                            pStartTransNum,
                            pEndTransNum,
                            pTypes,
                            pCommit,
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
                    }
                }

                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_BankReconChangeSp") != null)
                {
                    var EXTGEN = AltExtGen_CLM_BankReconChangeSp("dbo.EXTGEN_CLM_BankReconChangeSp",
                        pBankCode,
                        pStartTransDate,
                        pEndTransDate,
                        pStartTransNum,
                        pEndTransNum,
                        pTypes,
                        pCommit,
                        Infobar);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity, EXTGEN.Infobar);
                    }
                }

                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                Severity = 0;
                pStartTransDate = convertToUtil.ToDateTime(stringUtil.IsNull(
                    pStartTransDate,
                    this.iLowDate.LowDateFn()));
                pEndTransDate = convertToUtil.ToDateTime(stringUtil.IsNull(
                    this.iDayEndOf.DayEndOfFn(pEndTransDate),
                    this.iHighDate.HighDateFn()));
                pStartTransNum = (int?)(stringUtil.IsNull(
                    pStartTransNum,
                    this.iLowInt.LowIntFn()));
                pEndTransNum = (int?)(stringUtil.IsNull(
                    pEndTransNum,
                    this.iHighInt.HighIntFn()));
                if (sQLUtil.SQLNotEqual(pCommit, 0) == true)
                {

                    #region CRUD LoadToRecord
                    var glbankLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"bank_amt","glbank.bank_amt"},
                            {"bank_recon","glbank.bank_recon"},
                            {"u0","glbank.voided"},
                            {"u1","glbank.check_amt"},
                        },
                        tableName: "glbank", 
                        loadForChange: true, 
                        lockingType: LockingType.UPDLock,
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("charindex(type, {5}) > 0 AND bank_code = {4} AND check_date BETWEEN {0} AND {2} AND check_num BETWEEN {1} AND {3}", pStartTransDate, pStartTransNum, pEndTransDate, pEndTransNum, pBankCode, pTypes),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var glbankLoadResponse = this.appDB.Load(glbankLoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD UpdateByRecord
                    foreach (var glbankItem in glbankLoadResponse.Items)
                    {
                        glbankItem.SetValue<decimal?>("bank_amt", (sQLUtil.SQLNotEqual(glbankItem.GetDeletedValue<int?>("u0"), 0) == true ? 0 : glbankItem.GetDeletedValue<decimal?>("u1")));
                        glbankItem.SetValue<int?>("bank_recon", 1);
                    };

                    var glbankRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "glbank",
                        items: glbankLoadResponse.Items);

                    this.appDB.Update(glbankRequestUpdate);
                    #endregion UpdateByRecord

                }
                WhereStr = stringUtil.Concat("WHERE charindex(type, '", stringUtil.Replace(
                    pTypes,
                    "'",
                    "''"), "') > 0 and bank_code = '", stringUtil.Replace(
                    pBankCode,
                    "'",
                    "''"), "'", "and check_date between '", stringUtil.Replace(
                    this.iCstr.CstrFn(pStartTransDate),
                    "'",
                    "''"), "' and '", stringUtil.Replace(
                    this.iCstr.CstrFn(pEndTransDate),
                    "'",
                    "''"), "'", "and check_num between ", stringUtil.Replace(
                    this.iCstr.CstrFn(pStartTransNum),
                    "'",
                    "''"), " and ", stringUtil.Replace(
                    this.iCstr.CstrFn(pEndTransNum),
                    "'",
                    "''"));
                SelectionClause = "";
                FromClause = "";
                WhereClause = "";
                AdditionalClause = "";
                KeyColumns = "";
                FilterString = "";
                SelectionClause = "SELECT type, check_num, check_date, check_amt, bank_amt, bank_recon";
                FromClause = "FROM glbank";
                WhereClause = WhereStr;
                AdditionalClause = "ORDER BY type, check_num, check_date";
                KeyColumns = "type, check_num, check_date";
                FilterString = null;
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#DynamicParameters") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters ");

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
        AltExtGen_CLM_BankReconChangeSp(
            string AltExtGenSp,
            string pBankCode,
            DateTime? pStartTransDate,
            DateTime? pEndTransDate,
            int? pStartTransNum,
            int? pEndTransNum,
            string pTypes,
            int? pCommit,
            string Infobar)
        {
            BankCodeType _pBankCode = pBankCode;
            DateTimeType _pStartTransDate = pStartTransDate;
            DateTimeType _pEndTransDate = pEndTransDate;
            GlCheckNumType _pStartTransNum = pStartTransNum;
            GlCheckNumType _pEndTransNum = pEndTransNum;
            InfobarType _pTypes = pTypes;
            Flag _pCommit = pCommit;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartTransDate", _pStartTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndTransDate", _pEndTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartTransNum", _pStartTransNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndTransNum", _pEndTransNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pTypes", _pTypes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCommit", _pCommit, ParameterDirection.Input);
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
