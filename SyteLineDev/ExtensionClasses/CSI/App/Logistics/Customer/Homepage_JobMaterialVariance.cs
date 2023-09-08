//PROJECT NAME: Logistics
//CLASS NAME: Homepage_JobMaterialVariance.cs

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
    public class Homepage_JobMaterialVariance : IHomepage_JobMaterialVariance
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;
        readonly IMathUtil mathUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public Homepage_JobMaterialVariance(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IStringUtil stringUtil,
            IMathUtil mathUtil,
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
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
            this.mathUtil = mathUtil;
            this.sQLUtil = sQLUtil;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_JobMaterialVarianceSp(DateTime? StartDate,
            DateTime? EndDate,
            string SiteGroup = null)
        {
            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            StringType _ALTGEN_SpName = DBNull.Value;
            int? ALTGEN_Severity = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_JobMaterialVarianceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_JobMaterialVarianceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Homepage_JobMaterialVarianceSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
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
                    #endregion  LoadToVariable

                    var ALTGEN = AltExtGen_Homepage_JobMaterialVarianceSp(_ALTGEN_SpName,
                        StartDate,
                        EndDate,
                        SiteGroup);
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
                        whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", _ALTGEN_SpName),
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
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_JobMaterialVarianceSp") != null)
            {
                var EXTGEN = AltExtGen_Homepage_JobMaterialVarianceSp("dbo.EXTGEN_Homepage_JobMaterialVarianceSp",
                    StartDate,
                    EndDate,
                    SiteGroup);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            #region CRUD LoadArbitrary
            var matltranLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"Job","jm.job"},
                    {"Suffix","jm.suffix"},
                    {"OperNum","jm.oper_num"},
                    {"Item","jm.item"},
                    {"QtyIssued","jm.qty_issued"},
                    {"CostConv","jm.cost_conv"},
                    {"PlannedCost","jm.qty_issued * jm.cost_conv"},
                    {"jm.a_cost","jm.a_cost"},
                    {"VarPercent","CASE WHEN jm.a_cost = 0 AND (jm.qty_issued * jm.cost_conv) = 0 THEN 0 WHEN jm.qty_issued * jm.cost_conv = 0 THEN 100 ELSE Round(((jm.a_cost - (jm.qty_issued * jm.cost_conv)) / (jm.qty_issued * jm.cost_conv)) * 100, 2) END"},
                },
                selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct TOP 10 @selectList  
                    FROM matltran AS mat 
                         INNER JOIN 
                         jobmatl AS jm 
                         ON jm.job = mat.ref_num 
                            AND jm.oper_num = mat.ref_release 
                            AND jm.item = mat.item 
                    WHERE mat.trans_type = 'I' 
                          AND mat.ref_type = 'J' 
                          AND CONVERT (DATE, mat.trans_date) BETWEEN {0}  AND {1}  
                    ORDER BY VarPercent DESC", StartDate, EndDate));

            var matltranLoadResponse = this.appDB.Load(matltranLoadRequest);
            Data = matltranLoadResponse;
            #endregion  LoadArbitrary

            return (Data, Severity);
        }
        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_JobMaterialVarianceSp(string AltExtGenSp,
            DateTime? StartDate,
            DateTime? EndDate,
            string SiteGroup = null)
        {
            DateType _StartDate = StartDate;
            DateType _EndDate = EndDate;
            SiteGroupType _SiteGroup = SiteGroup;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);

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
