//PROJECT NAME: Logistics
//CLASS NAME: Homepage_LeadsCount.cs

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
using CSI.Material;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
    public class Homepage_LeadsCount : IHomepage_LeadsCount
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IVariableUtil variableUtil;
        readonly IMidnightOf iMidnightOf;
        readonly IStringUtil stringUtil;
        readonly IGetLabel iGetLabel;
        readonly ISQLValueComparerUtil sQLUtil;

        public Homepage_LeadsCount(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IDateTimeUtil dateTimeUtil,
            IVariableUtil variableUtil,
            IMidnightOf iMidnightOf,
            IStringUtil stringUtil,
            IGetLabel iGetLabel,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.dateTimeUtil = dateTimeUtil;
            this.variableUtil = variableUtil;
            this.iMidnightOf = iMidnightOf;
            this.stringUtil = stringUtil;
            this.iGetLabel = iGetLabel;
            this.sQLUtil = sQLUtil;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_LeadsCountSp(int? DaysBefore = 30,
            string CustNumProspectId = null,
            string Type = "Customer")
        {
            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            StringType _ALTGEN_SpName = DBNull.Value;
            int? ALTGEN_Severity = null;
            string CountLabel = null;
            IntType _LeadsCount = DBNull.Value;
            DateTime? CutoffDate = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause($"ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_LeadsCountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_LeadsCountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Homepage_LeadsCountSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
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

                    var ALTGEN = AltExtGen_Homepage_LeadsCountSp(_ALTGEN_SpName,
                        DaysBefore,
                        CustNumProspectId,
                        Type);
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
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_LeadsCountSp") != null)
            {
                var EXTGEN = AltExtGen_Homepage_LeadsCountSp("dbo.EXTGEN_Homepage_LeadsCountSp",
                    DaysBefore,
                    CustNumProspectId,
                    Type);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            CountLabel = this.iGetLabel.GetLabelFn("@!Count");
            CutoffDate = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", -1 * DaysBefore, this.iMidnightOf.MidnightOfFn(scalarFunction.Execute<DateTime>("GETDATE"))));
            if (sQLUtil.SQLNotEqual(stringUtil.IsNull(Type, ""), "Customer") == true && sQLUtil.SQLNotEqual(stringUtil.IsNull(Type, ""), "Prospect") == true)
            {
                //BEGIN
                Type = "Customer";
                //END
            }
            if (CustNumProspectId != null)
            {
                //BEGIN
                CustNumProspectId = this.iExpandKyByType.ExpandKyByTypeFn("CustNumType", CustNumProspectId);
                //END
            }

            #region CRUD LoadToVariable
            var leadLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_LeadsCount,"COUNT(1)"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "lead",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("CreateDate >= {1} AND (cust_num = {0} AND {2} = 'Customer' OR prospect_id = {0} AND {2} = 'Prospect' OR {0} IS NULL)", CustNumProspectId, CutoffDate, Type),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(leadLoadRequest);
            #endregion  LoadToVariable

            #region CRUD LoadResponseWithoutTable
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                {
                    { "Caption", variableUtil.GetValue<string>(CountLabel,true)},
                    { "Count", variableUtil.GetValue<IntType>(_LeadsCount,true)},
                });

            var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
            Data = nonTableLoadResponse;
            #endregion CRUD LoadResponseWithoutTable

            return (Data, Severity);
        }
        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_LeadsCountSp(string AltExtGenSp,
            int? DaysBefore = 30,
            string CustNumProspectId = null,
            string Type = "Customer")
        {
            IntType _DaysBefore = DaysBefore;
            CustNumType _CustNumProspectId = CustNumProspectId;
            StringType _Type = Type;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "DaysBefore", _DaysBefore, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNumProspectId", _CustNumProspectId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);

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
