//PROJECT NAME: Production
//CLASS NAME: GetSharedForCoJob.cs

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

namespace CSI.Production
{
    public class GetSharedForCoJob : IGetSharedForCoJob
    {
        readonly IApplicationDB appDB;

        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public GetSharedForCoJob(IApplicationDB appDB,
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
            int? ReturnCode,
            int? Shared,
            string WC,
            int? IsCojob)
        GetSharedForCoJobSp(
            string Job,
            int? OperNum,
            int? Suffix,
            int? Shared,
            string WC,
            int? IsCojob)
        {

            JobType _Job = Job;
            ListYesNoType _Shared = Shared;
            WcType _WC = WC;
            ListYesNoType _IsCojob = IsCojob;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GetSharedForCoJobSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GetSharedForCoJobSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("GetSharedForCoJobSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_GetSharedForCoJobSp(_ALTGEN_SpName,
                        Job,
                        OperNum,
                        Suffix,
                        Shared,
                        WC,
                        IsCojob);
                    ALTGEN_Severity = ALTGEN.ReturnCode;


                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        WC = _WC;
                        Shared = _Shared;
                        IsCojob = _IsCojob;
                        return (ALTGEN_Severity, Shared, WC, IsCojob);
                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    #region CRUD LoadToRecord
                    var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"[SpName]","[SpName]"},
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
                }
            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_GetSharedForCoJobSp") != null)
            {
                var EXTGEN = AltExtGen_GetSharedForCoJobSp("dbo.EXTGEN_GetSharedForCoJobSp",
                    Job,
                    OperNum,
                    Suffix,
                    Shared,
                    WC,
                    IsCojob);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.Shared, EXTGEN.WC, EXTGEN.IsCojob);
                }
            }

            Severity = 0;
            Shared = 0;
            if (existsChecker.Exists(
                tableName: "jobroute",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("job = {1} AND suffix = 0 AND oper_num = ISNULL({0}, 0)", OperNum, Job)))
            {
                #region CRUD LoadToVariable
                var jobroute1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_WC,"wc"},
                        {_Shared,"MO_shared"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "jobroute",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("job = {1} AND suffix = 0 AND oper_num = ISNULL({0}, 0)", OperNum, Job),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var jobroute1LoadResponse = this.appDB.Load(jobroute1LoadRequest);
                if (jobroute1LoadResponse.Items.Count > 0)
                {
                    WC = _WC;
                    Shared = _Shared;
                }
                #endregion  LoadToVariable
            }

            #region CRUD LoadToVariable
            var jobLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_IsCojob,"MO_co_job"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "job",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("job = {1} AND suffix = {0}", Suffix, Job),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var jobLoadResponse = this.appDB.Load(jobLoadRequest);
            if (jobLoadResponse.Items.Count > 0)
            {
                IsCojob = _IsCojob;
            }
            #endregion  LoadToVariable

            return (Severity, Shared, WC, IsCojob);
        }

        public (int? ReturnCode,
            int? Shared,
            string WC,
            int? IsCojob)
        AltExtGen_GetSharedForCoJobSp(
            string AltExtGenSp,
            string Job,
            int? OperNum,
            int? Suffix,
            int? Shared,
            string WC,
            int? IsCojob)
        {
            JobType _Job = Job;
            OperNumType _OperNum = OperNum;
            SuffixType _Suffix = Suffix;
            ListYesNoType _Shared = Shared;
            WcType _WC = WC;
            ListYesNoType _IsCojob = IsCojob;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Shared", _Shared, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "WC", _WC, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "IsCojob", _IsCojob, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Shared = _Shared;
                WC = _WC;
                IsCojob = _IsCojob;

                return (Severity, Shared, WC, IsCojob);
            }
        }
    }
}
