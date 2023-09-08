//PROJECT NAME: Material
//CLASS NAME: CLM_ExpiringLotsSerials.cs

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
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Material
{
    public class CLM_ExpiringLotsSerials : ICLM_ExpiringLotsSerials
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IGetSiteDate iGetSiteDate;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly IRaiseError raiseError;
        readonly IDayEndOf iDayEndOf;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IUnionUtil unionUtil;

        public CLM_ExpiringLotsSerials(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IGetSiteDate iGetSiteDate,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            IRaiseError raiseError,
            IDayEndOf iDayEndOf,
            ISQLValueComparerUtil sQLUtil,
            IUnionUtil unionUtil)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.iGetSiteDate = iGetSiteDate;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.raiseError = raiseError;
            this.iDayEndOf = iDayEndOf;
            this.sQLUtil = sQLUtil;
            this.unionUtil = unionUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_ExpiringLotsSerialsSp(
            DateTime? CutoffDate,
            string PMTCodes,
            string FilterString = null,
            string PSiteGroup = null)
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
                string Infobar = null;
                string SelectionClause = null;
                string FromClause = null;
                string WhereClause = null;
                string AdditionalClause = null;
                string KeyColumns = null;
                SiteType _Site = DBNull.Value;
                string Site = null;

                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ExpiringLotsSerialsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ExpiringLotsSerialsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_ExpiringLotsSerialsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
                            maximumRows: 1,
                            tableName: "#tv_ALTGEN", 
                            lockingType: LockingType.None,
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause(""),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
                        if (tv_ALTGEN1LoadResponse.Items.Count > 0)
                        {
                            ALTGEN_SpName = _ALTGEN_SpName;
                        }
                        #endregion  LoadToVariable

                        var ALTGEN = AltExtGen_CLM_ExpiringLotsSerialsSp(ALTGEN_SpName,
                            CutoffDate,
                            PMTCodes,
                            FilterString,
                            PSiteGroup);
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
                    }
                }

                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ExpiringLotsSerialsSp") != null)
                {
                    var EXTGEN = AltExtGen_CLM_ExpiringLotsSerialsSp("dbo.EXTGEN_CLM_ExpiringLotsSerialsSp",
                        CutoffDate,
                        PMTCodes,
                        FilterString,
                        PSiteGroup);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                SelectionClause = "";
                FromClause = "";
                WhereClause = "";
                AdditionalClause = "";
                this.sQLExpressionExecutor.Execute(@"CREATE TABLE #tempOutput (
                        ExpDate         DATETIME     ,
                        Item            NVARCHAR (30) COLLATE DATABASE_DEFAULT,
                        Type            NVARCHAR (1)  COLLATE DATABASE_DEFAULT,
                        ItemDescription NVARCHAR (40) COLLATE DATABASE_DEFAULT,
                        Lot             NVARCHAR (15) COLLATE DATABASE_DEFAULT,
                        SerNum          NVARCHAR (30) COLLATE DATABASE_DEFAULT,
                        SiteRef         NVARCHAR (8)  COLLATE DATABASE_DEFAULT
                    ) ");
                Severity = 0;
                CutoffDate = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(stringUtil.IsNull(
                        CutoffDate,
                        this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE")))));
                        PMTCodes = stringUtil.IsNull(
                        PMTCodes,
                        "");

                #region CRUD LoadArbitrary
                var tempOutput1LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        { "ExpDate", "serial.exp_date" },
                        { "Item", "serial.item" },
                        { "Type", "'S'" },
                        { "ItemDescription", "item.description" },
                        { "Lot", "serial.lot" },
                        { "SerNum", "serial.ser_num" },
                        { "SiteRef", "serial.site_ref" },
                    },
                    selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList  
                        FROM serial_all AS serial 
                             INNER JOIN 
                             item_all AS item 
                             ON item.item = serial.item 
                                AND item.site_ref = serial.site_ref 
                        WHERE ISNULL(serial.exp_date, {0} ) < {0}  
                              AND CHARINDEX(item.p_m_t_code, {1} ) > 0", CutoffDate, PMTCodes));

                var tempOutput1LoadResponse = this.appDB.Load(tempOutput1LoadRequest);
                Data = tempOutput1LoadResponse;
                #endregion  LoadArbitrary

                unionUtil.Add(tempOutput1LoadResponse);

                #region CRUD LoadArbitrary
                var tempOutput2LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        { "ExpDate", "lot.exp_date" },
                        { "Item", "lot.item" },
                        { "Type", "'L'" },
                        { "ItemDescription", "item.description" },
                        { "Lot", "lot.lot" },
                        { "SerNum", "null" },
                        { "SiteRef", "lot.site_ref" },
                    },
                    selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList  
                        FROM lot_all AS lot 
                             INNER JOIN 
                             item_all AS item 
                             ON item.item = lot.item 
                                AND item.site_ref = lot.site_ref 
                        WHERE ISNULL(lot.exp_date, {0} ) < {0}  
                              AND CHARINDEX(item.p_m_t_code, {1} ) > 0", CutoffDate, PMTCodes));

                var tempOutput2LoadResponse = this.appDB.Load(tempOutput2LoadRequest);
                Data = tempOutput2LoadResponse;
                #endregion  LoadArbitrary

                unionUtil.Add(tempOutput2LoadResponse);
                var unionTableResult = unionUtil.Process();
                Data = unionTableResult;

                #region CRUD InsertByRecords
                var unionTableResultInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tempOutput",
                    items: unionTableResult.Items);

                this.appDB.Insert(unionTableResultInsertRequest);
                #endregion InsertByRecords

                WhereClause = "WHERE 1 = 1";
                if (PSiteGroup == null)
                {
                    #region CRUD LoadToVariable
                    var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_Site,"site"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        maximumRows: 1,
                        tableName: "parms",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
                    if (parmsLoadResponse.Items.Count > 0)
                    {
                        Site = _Site;
                    }
                    #endregion  LoadToVariable

                    WhereClause = stringUtil.Concat(WhereClause, " AND SiteRef = '", stringUtil.Replace(
                        Site,
                        "'",
                        "''"), "' ");
                }
                else
                {
                    WhereClause = stringUtil.Concat(WhereClause, " AND SiteRef IN (select site from site_group where site_group.site_group = '", stringUtil.Replace(
                        PSiteGroup,
                        "'",
                        "''"), "' )");
                }
                SelectionClause = "SELECT *";
                FromClause = "FROM #tempOutput";
                AdditionalClause = "ORDER BY SiteRef";
                KeyColumns = "SiteRef";

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
                return (Data, Severity); RAISE_ERROR:;
                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    raiseError.RaiseErrorSp(
                        Infobar,
                        Severity,
                        1);
                }

                return (Data, Severity);
            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_CLM_ExpiringLotsSerialsSp(
            string AltExtGenSp,
            DateTime? CutoffDate,
            string PMTCodes,
            string FilterString = null,
            string PSiteGroup = null)
        {
            DateTimeType _CutoffDate = CutoffDate;
            StringType _PMTCodes = PMTCodes;
            LongListType _FilterString = FilterString;
            SiteGroupType _PSiteGroup = PSiteGroup;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PMTCodes", _PMTCodes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSiteGroup", _PSiteGroup, ParameterDirection.Input);

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
