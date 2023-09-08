//PROJECT NAME: Finance
//CLASS NAME: CHSRepAcctsNextSeq.cs

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

namespace CSI.Finance.Chinese
{
    public class CHSRepAcctsNextSeq : ICHSRepAcctsNextSeq
    {
        readonly IApplicationDB appDB;

        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public CHSRepAcctsNextSeq(IApplicationDB appDB,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
        }

        public (
            int? ReturnCode,
            decimal? SeqCount,
            string InfoBar)
        CHSRepAcctsNextSeqSp(
            decimal? BookKey,
            decimal? SeqCount,
            string InfoBar)
        {
            OperationCounterType _SeqCount = SeqCount;
            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;

            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CHSRepAcctsNextSeqSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CHSRepAcctsNextSeqSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CHSRepAcctsNextSeqSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_CHSRepAcctsNextSeqSp(_ALTGEN_SpName,
                        BookKey,
                        SeqCount,
                        InfoBar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        SeqCount = _SeqCount;
                        return (ALTGEN_Severity, SeqCount, InfoBar);
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CHSRepAcctsNextSeqSp") != null)
            {
                var EXTGEN = AltExtGen_CHSRepAcctsNextSeqSp("dbo.EXTGEN_CHSRepAcctsNextSeqSp",
                    BookKey,
                    SeqCount,
                    InfoBar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.SeqCount, EXTGEN.InfoBar);
                }
            }

            Severity = 0;

            #region CRUD LoadToVariable
            var CN_RepAcctsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_SeqCount,"COUNT(Acct)"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "CN_RepAccts",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("BookKey = {0}", BookKey),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var CN_RepAcctsLoadResponse = this.appDB.Load(CN_RepAcctsLoadRequest);
            if (CN_RepAcctsLoadResponse.Items.Count > 0)
            {
                SeqCount = _SeqCount;
            }
            #endregion  LoadToVariable

            SeqCount = (decimal?)(SeqCount + 1M);

            #region CRUD LoadResponseWithoutTable
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                { "col0", variableUtil.GetValue<decimal?>(SeqCount,true)},
            });

            var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
            #endregion CRUD LoadResponseWithoutTable

            return (Severity, SeqCount, InfoBar);
        }

        public (int? ReturnCode,
            decimal? SeqCount,
            string InfoBar)
        AltExtGen_CHSRepAcctsNextSeqSp(
            string AltExtGenSp,
            decimal? BookKey,
            decimal? SeqCount,
            string InfoBar)
        {
            SequenceType _BookKey = BookKey;
            OperationCounterType _SeqCount = SeqCount;
            InfobarType _InfoBar = InfoBar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "BookKey", _BookKey, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SeqCount", _SeqCount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                SeqCount = _SeqCount;
                InfoBar = _InfoBar;

                return (Severity, SeqCount, InfoBar);
            }
        }
    }
}
