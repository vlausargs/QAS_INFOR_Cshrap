//PROJECT NAME: Production
//CLASS NAME: ApsPBOMMATLSDel.cs

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

namespace CSI.Production.APS
{
    public class ApsPBOMMATLSDel : IApsPBOMMATLSDel
    {
        readonly IApplicationDB appDB;

        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ISQLCollectionLoad sQLCollectionLoad;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public ApsPBOMMATLSDel(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ISQLCollectionLoad sQLCollectionLoad,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.sQLCollectionLoad = sQLCollectionLoad;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
        }

        public int? ApsPBOMMATLSDelSp(
            int? AltNo,
            Guid? RowPointer)
        {
            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            string Table = null;
            string ParmList = null;
            string SQLStr = null;

            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ApsPBOMMATLSDelSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ApsPBOMMATLSDelSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ApsPBOMMATLSDelSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_ApsPBOMMATLSDelSp(_ALTGEN_SpName,
                        AltNo,
                        RowPointer);
                    ALTGEN_Severity = ALTGEN;


                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity);
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ApsPBOMMATLSDelSp") != null)
            {
                var EXTGEN = AltExtGen_ApsPBOMMATLSDelSp("dbo.EXTGEN_ApsPBOMMATLSDelSp",
                    AltNo,
                    RowPointer);
                int? EXTGEN_Severity = EXTGEN;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity);
                }
            }

            Severity = 0;
            Table = stringUtil.Concat("PBOMMATLS", stringUtil.Replace(
                stringUtil.Str(
                    AltNo,
                    3),
                " ",
                "0"));
            ParmList = "@P_RowPointer RowPointerType";
            SQLStr = stringUtil.Concat("DELETE FROM ", Table, " WHERE RowPointer = @P_RowPointer");

            var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQLStr
                , ParmList
                , RowPointer);
            Severity = execResult.Severity;

            return (Severity);
        }

        public int?
        AltExtGen_ApsPBOMMATLSDelSp(
            string AltExtGenSp,
            int? AltNo,
            Guid? RowPointer)
        {
            ApsAltNoType _AltNo = AltNo;
            RowPointerType _RowPointer = RowPointer;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
