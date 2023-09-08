//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceGroupSummary.cs

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

namespace CSI.Reporting
{
    public class Rpt_ResourceGroupSummary : IRpt_ResourceGroupSummary
    {
        IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        ICollectionInsertRequestFactory collectionInsertRequestFactory;
        ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICloseSessionContext iCloseSessionContext;
        readonly IInitSessionContext iInitSessionContext;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        ISQLCollectionLoad sQLCollectionLoad;
        readonly IScalarFunction scalarFunction;
        IExistsChecker existsChecker;
        IStringUtil stringUtil;
        ISQLValueComparerUtil sQLUtil;

        public Rpt_ResourceGroupSummary(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICloseSessionContext iCloseSessionContext,
            IInitSessionContext iInitSessionContext,
            ITransactionFactory transactionFactory,
            IGetIsolationLevel iGetIsolationLevel,
            ISQLCollectionLoad sQLCollectionLoad,
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
            this.iCloseSessionContext = iCloseSessionContext;
            this.iInitSessionContext = iInitSessionContext;
            this.transactionFactory = transactionFactory;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.sQLCollectionLoad = sQLCollectionLoad;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceGroupSummarySp(string ResourceStarting = null,
            string ResourceEnding = null,
            string ResourceGroupStarting = null,
            string ResourceGroupEnding = null,
            string ResourceTypeStarting = null,
            string ResourceTypeEnding = null,
            decimal? PercentLoadStarting = null,
            decimal? PercentLoadEnding = null,
            int? DisplayHeader = null,
            int? ALTNO = null,
            string pSite = null)
        {
            ICollectionLoadResponse Data = null;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            Guid? RptSessionID = null;
            int? Severity = null;
            string RGRPSUM = null;
            string RESSCHD = null;
            string RESRC = null;
            string RGRP = null;
            string SQLStr = null;
            string ParmList = null;
            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ResourceGroupSummarySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ResourceGroupSummarySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_ResourceGroupSummarySp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
                    ALTGEN_SpName = _ALTGEN_SpName;
                    #endregion  LoadToVariable

                    var ALTGEN = AltExtGen_Rpt_ResourceGroupSummarySp(_ALTGEN_SpName,
                        ResourceStarting,
                        ResourceEnding,
                        ResourceGroupStarting,
                        ResourceGroupEnding,
                        ResourceTypeStarting,
                        ResourceTypeEnding,
                        PercentLoadStarting,
                        PercentLoadEnding,
                        DisplayHeader,
                        ALTNO,
                        pSite);
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
                    //END
                }
                //END
            }

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_ResourceGroupSummarySp") != null)
            {
                var EXTGEN = AltExtGen_Rpt_ResourceGroupSummarySp("dbo.EXTGEN_Rpt_ResourceGroupSummarySp",
                    ResourceStarting,
                    ResourceEnding,
                    ResourceGroupStarting,
                    ResourceGroupEnding,
                    ResourceTypeStarting,
                    ResourceTypeEnding,
                    PercentLoadStarting,
                    PercentLoadEnding,
                    DisplayHeader,
                    ALTNO,
                    pSite);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            this.transactionFactory.BeginTransaction("");
            this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("ResourceGroupSummaryReport"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            }

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InitSessionContextSp
            var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(ContextName: "Rpt_ResourceGroupSummarySp"
                , SessionID: RptSessionID
                , Site: pSite);
            RptSessionID = InitSessionContext.SessionID;

            #endregion ExecuteMethodCall

            ALTNO = (int?)(stringUtil.IsNull(ALTNO, 0));
            RGRPSUM = stringUtil.Concat("RGRPSUM", stringUtil.Substring("000", 1, 3 - stringUtil.Len(ALTNO)), Convert.ToString(ALTNO));
            RESSCHD = stringUtil.Concat("RESSCHD", stringUtil.Substring("000", 1, 3 - stringUtil.Len(ALTNO)), Convert.ToString(ALTNO));
            RESRC = stringUtil.Concat("RESRC", stringUtil.Substring("000", 1, 3 - stringUtil.Len(ALTNO)), Convert.ToString(ALTNO));
            RGRP = stringUtil.Concat("RGRP", stringUtil.Substring("000", 1, 3 - stringUtil.Len(ALTNO)), Convert.ToString(ALTNO));
            SQLStr = stringUtil.Concat("SELECT DISTINCT ALTSCHED.\"STARTDATE\", ALTSCHED.\"ENDDATE\","
                + "\r\n"
                + "      R.RGID, R.TIMEONSHFT AS ONSHIFTCAP,"
                + "\r\n"
                + "      (R.BUSY+R.SETUP+R.BLOCK) AS TOTALLOAD,"
                + "\r\n"
                + "      CASE WHEN R.TIMEONSHFT = 0  THEN 0"
                + "\r\n"
                + "      ELSE CONVERT( DECIMAL(11,8),  ((R.BUSY+R.SETUP+R.BLOCK)/(R.TIMEONSHFT)*100.0) ) END AS PERCENTLOAD,"
                + "\r\n"
                + "      R.BUSY AS [PROC], R.SETUP, R.IDLE, R.BLOCK,"
                + "\r\n"
                + "      R.QUEAVG AS MQLEN, R.WAITAVG AS MQTIME,"
                + "\r\n"
                + "      R.WAITOBS AS NLOADSWAIT,"
                + "\r\n"
                + "      RGRP.DESCR"
                + "\r\n"
                + "   FROM"
                + "\r\n"
                + "      ", stringUtil.QuoteName(RGRPSUM), " R"
                + "\r\n"
                + "      INNER JOIN ", stringUtil.QuoteName(RESSCHD), " RESSCHDXXX  ON  RESSCHDXXX.GROUPID = R.RGID"
                + "\r\n"
                + "      INNER JOIN ", stringUtil.QuoteName(RESRC), " RESRCXXX  ON  RESRCXXX.RESID = RESSCHDXXX.RESID"
                + "\r\n"
                + "      , ", stringUtil.QuoteName(RGRP), " RGRP , ALTERN ALTERN, ALTSCHED ALTSCHED"
                + "\r\n"
                + "   WHERE"
                + "\r\n"
                + "      R.RGID = RGRP.RGID AND"
                + "\r\n"
                + "      ALTERN.ALTNO = 0 AND"
                + "\r\n"
                + "      ALTERN.ALTNO = ALTSCHED.ALTNO AND"
                + "\r\n"
                + "      (CASE WHEN R.\"TIMEONSHFT\" <> 0 THEN"
                + "\r\n"
                + "      (R.BUSY+R.SETUP+R.BLOCK)/(R.TIMEONSHFT)*100.0 ELSE 0 END)"
                + "\r\n"
                + "      BETWEEN ISNULL(@PercentLoadStarting,dbo.LowDecimal('SalaryChangePercentType'))"
                + "\r\n"
                + "          AND ISNULL(@PercentLoadEnding,dbo.HighDecimal('SalaryChangePercentType'))"
                + "\r\n"
                + "      AND RESRCXXX.RESID BETWEEN ISNULL(@ResourceStarting, dbo.LowString('ApsResourceType'))"
                + "\r\n"
                + "                             AND  ISNULL(@ResourceEnding, dbo.HighString('ApsResourceType'))"
                + "\r\n"
                + "      AND RESSCHDXXX.RESID BETWEEN ISNULL(@ResourceStarting, dbo.LowString('ApsResourceType'))"
                + "\r\n"
                + "                               AND ISNULL(@ResourceEnding, dbo.HighString('ApsResourceType'))"
                + "\r\n"
                + "      AND RESRCXXX.RESTYPE BETWEEN ISNULL(@ResourceTypeStarting, dbo.LowString('ApsRestypeType'))"
                + "\r\n"
                + "                               AND ISNULL(@ResourceTypeEnding, dbo.HighString('ApsRestypeType'))"
                + "\r\n"
                + "      AND R.RGID BETWEEN ISNULL(@ResourceGroupStarting, dbo.LowString('ApsResgroupType'))"
                + "\r\n"
                + "                     AND ISNULL(@ResourceGroupEnding, dbo.HighString('ApsResgroupType'))"
                + "\r\n"
                + "      ORDER BY"
                + "\r\n"
                + "      R.RGID ASC");
            ParmList = @"@ResourceStarting APSResourceType, @ResourceEnding APSResourceType
                  , @ResourceTypeStarting APSResourceType,@ResourceTypeEnding APSResourceType
                  , @PercentLoadStarting SalaryChangePercentType, @PercentLoadEnding SalaryChangePercentType
                  , @ResourceGroupStarting APSResourceType,@ResourceGroupEnding APSResourceType";

            var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQLStr
            , ParmList
            , ResourceStarting
            , ResourceEnding
            , ResourceTypeStarting
            , ResourceTypeEnding
            , PercentLoadStarting
            , PercentLoadEnding
            , ResourceGroupStarting
            , ResourceGroupEnding);
            Severity = execResult.Severity;
            /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the return. */

            this.transactionFactory.CommitTransaction("");

            #region CRUD ExecuteMethodCall
            //Please Generate the bounce for this stored procedure: CloseSessionContextSp
            var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

            #endregion ExecuteMethodCall

            Data = execResult.Data;

            return (Data, Severity);
        }
        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_ResourceGroupSummarySp(string AltExtGenSp,
            string ResourceStarting = null,
            string ResourceEnding = null,
            string ResourceGroupStarting = null,
            string ResourceGroupEnding = null,
            string ResourceTypeStarting = null,
            string ResourceTypeEnding = null,
            decimal? PercentLoadStarting = null,
            decimal? PercentLoadEnding = null,
            int? DisplayHeader = null,
            int? ALTNO = null,
            string pSite = null)
        {
            ApsResourceType _ResourceStarting = ResourceStarting;
            ApsResourceType _ResourceEnding = ResourceEnding;
            ApsResourceType _ResourceGroupStarting = ResourceGroupStarting;
            ApsResourceType _ResourceGroupEnding = ResourceGroupEnding;
            ApsResourceType _ResourceTypeStarting = ResourceTypeStarting;
            ApsResourceType _ResourceTypeEnding = ResourceTypeEnding;
            SalaryChangePercentType _PercentLoadStarting = PercentLoadStarting;
            SalaryChangePercentType _PercentLoadEnding = PercentLoadEnding;
            ListYesNoType _DisplayHeader = DisplayHeader;
            ApsAltNoType _ALTNO = ALTNO;
            SiteType _pSite = pSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "ResourceStarting", _ResourceStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ResourceEnding", _ResourceEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ResourceGroupStarting", _ResourceGroupStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ResourceGroupEnding", _ResourceGroupEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ResourceTypeStarting", _ResourceTypeStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ResourceTypeEnding", _ResourceTypeEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PercentLoadStarting", _PercentLoadStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PercentLoadEnding", _PercentLoadEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ALTNO", _ALTNO, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);

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
