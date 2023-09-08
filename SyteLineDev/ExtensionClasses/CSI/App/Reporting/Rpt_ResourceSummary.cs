//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceSummary.cs

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
    public class Rpt_ResourceSummary : IRpt_ResourceSummary
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ISQLCollectionLoad sQLCollectionLoad;
        readonly ICloseSessionContext iCloseSessionContext;
        readonly IInitSessionContext iInitSessionContext;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public Rpt_ResourceSummary(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ISQLCollectionLoad sQLCollectionLoad,
            ICloseSessionContext iCloseSessionContext,
            IInitSessionContext iInitSessionContext,
            ITransactionFactory transactionFactory,
            IGetIsolationLevel iGetIsolationLevel,
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
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.sQLCollectionLoad = sQLCollectionLoad;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceSummarySp(string ResourceStarting = null,
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
            string ParmList = null;
            string SQLStr = null;
            string RESSUM = null;
            string RESRC = null;
            string RESSCHD = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ResourceSummarySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ResourceSummarySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_ResourceSummarySp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_Rpt_ResourceSummarySp(_ALTGEN_SpName,
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_ResourceSummarySp") != null)
            {
                var EXTGEN = AltExtGen_Rpt_ResourceSummarySp("dbo.EXTGEN_Rpt_ResourceSummarySp",
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
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("ResourceSummary"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            }

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InitSessionContextSp
            var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(ContextName: "Rpt_ResourceSummarySp"
                , SessionID: RptSessionID
                , Site: pSite);
            RptSessionID = InitSessionContext.SessionID;

            #endregion ExecuteMethodCall

            ALTNO = (int?)(stringUtil.IsNull(ALTNO, 0));
            RESSUM = stringUtil.Concat("RESSUM", stringUtil.Substring("000", 1, 3 - stringUtil.Len(ALTNO)), Convert.ToString(ALTNO));
            RESRC = stringUtil.Concat("RESRC", stringUtil.Substring("000", 1, 3 - stringUtil.Len(ALTNO)), Convert.ToString(ALTNO));
            RESSCHD = stringUtil.Concat("RESSCHD", stringUtil.Substring("000", 1, 3 - stringUtil.Len(ALTNO)), Convert.ToString(ALTNO));
            SQLStr = stringUtil.Concat(@"
              SELECT DISTINCT
                  ALTSCHED.STARTDATE, ALTSCHED.ENDDATE,
                  RESSUMXXX.RESID, RESRCXXX.DESCR,
                  RESSUMXXX.TIMEONSHFT,  RESSUMXXX.TIMEPROC + RESSUMXXX.TIMESETUP + RESSUMXXX.TIMEBLK AS TotalLoad,
                  (CASE WHEN RESSUMXXX.TIMEONSHFT <> 0 THEN
                     (RESSUMXXX.TIMEPROC + RESSUMXXX.TIMESETUP + RESSUMXXX.TIMEBLK)/ (RESSUMXXX.TIMEONSHFT) * 100 ELSE 0 END)
                  AS PercentLoad,
                  RESSUMXXX.TIMEPROC,RESSUMXXX.TIMESETUP,RESSUMXXX.TIMEIDLE, RESSUMXXX.TIMEBLK,
                  RESSUMXXX.MEANQLEN, RESSUMXXX.MEANQTIM, RESSUMXXX.NJOBSPR, RESSUMXXX.NLOADSWT
               FROM ALTSCHED ALTSCHED
                 , ", stringUtil.QuoteName(RESSUM), @" RESSUMXXX
                 INNER JOIN ", stringUtil.QuoteName(RESRC), @" RESRCXXX
                 ON RESSUMXXX.RESID = RESRCXXX.RESID
                 INNER JOIN ", stringUtil.QuoteName(RESSCHD), @" AS RESSCHDXXX
                 ON RESSCHDXXX.RESID = RESRCXXX.RESID
               WHERE
                  ALTSCHED.ALTNO = ", stringUtil.Replace(stringUtil.Str(ALTNO), "'", "''"), @"AND RESRCXXX.RESID BETWEEN ISNULL( @ResourceStarting, dbo.LowString('APSResourceType'))
                  AND ISNULL( @ResourceEnding, dbo.HighString('APSResourceType'))
                  AND RESRCXXX.RESTYPE BETWEEN ISNULL( @ResourceTypeStarting, dbo.LowString('APSResourceType'))
                  AND ISNULL( @ResourceTypeEnding, dbo.HighString('APSResourceType'))
                  AND (CASE WHEN RESSUMXXX.TIMEONSHFT <> 0 THEN
                  (RESSUMXXX.TIMEPROC + RESSUMXXX.TIMESETUP + RESSUMXXX.TIMEBLK)/ (RESSUMXXX.TIMEONSHFT) * 100 ELSE 0 END)
                  BETWEEN ISNULL(@PercentLoadStarting,dbo.LowDecimal('SalaryChangePercentType'))
                   AND ISNULL(@PercentLoadEnding,dbo.HighDecimal('SalaryChangePercentType'))
                  AND
                  RESSCHDXXX.GROUPID BETWEEN ISNULL( @ResourceGroupStarting, dbo.LowString('APSResourceType'))
                  AND ISNULL( @ResourceGroupEnding, dbo.HighString('APSResourceType'))
                  ORDER BY RESSUMXXX.RESID ASC ");
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
            /* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */

            this.transactionFactory.CommitTransaction("");
            Data = execResult.Data;
            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: CloseSessionContextSp
            var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

            #endregion ExecuteMethodCall

            return (Data, Severity);
        }
        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_ResourceSummarySp(string AltExtGenSp,
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
