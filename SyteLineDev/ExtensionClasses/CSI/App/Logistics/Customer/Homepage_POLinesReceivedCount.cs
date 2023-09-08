//PROJECT NAME: Logistics
//CLASS NAME: Homepage_POLinesReceivedCount.cs

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
using CSI.Material;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
    public class Homepage_POLinesReceivedCount : IHomepage_POLinesReceivedCount
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IInterpretText iInterpretText;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IVariableUtil variableUtil;
        readonly IMidnightOf iMidnightOf;
        readonly IStringUtil stringUtil;
        readonly IGetLabel iGetLabel;
        readonly ISQLValueComparerUtil sQLUtil;

        public Homepage_POLinesReceivedCount(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IInterpretText iInterpretText,
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
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.iInterpretText = iInterpretText;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.dateTimeUtil = dateTimeUtil;
            this.variableUtil = variableUtil;
            this.iMidnightOf = iMidnightOf;
            this.stringUtil = stringUtil;
            this.iGetLabel = iGetLabel;
            this.sQLUtil = sQLUtil;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_POLinesReceivedCountSp(int? DaysBefore = 0,
            string VendNum = null)
        {
            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            StringType _ALTGEN_SpName = DBNull.Value;
            int? ALTGEN_Severity = null;
            string ReceivedLabel = null;
            string UnReceivedLabel = null;
            DateTime? CutoffDate = null;
            string Infobar = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_POLinesReceivedCountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_POLinesReceivedCountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Homepage_POLinesReceivedCountSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
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

                    var ALTGEN = AltExtGen_Homepage_POLinesReceivedCountSp(_ALTGEN_SpName,
                        DaysBefore,
                        VendNum);
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
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_POLinesReceivedCountSp") != null)
            {
                var EXTGEN = AltExtGen_Homepage_POLinesReceivedCountSp("dbo.EXTGEN_Homepage_POLinesReceivedCountSp",
                    DaysBefore,
                    VendNum);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            UnReceivedLabel = stringUtil.Concat("FORMAT(" + "sNotReceived", ")");
            ReceivedLabel = this.iGetLabel.GetLabelFn("@po.received");

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InterpretTextSp
            var InterpretText = this.iInterpretText.InterpretTextSp(Text: UnReceivedLabel
                , InterpretedText: UnReceivedLabel
                , Infobar: Infobar);

            UnReceivedLabel = InterpretText.InterpretedText;
            Infobar = InterpretText.Infobar;
            #endregion ExecuteMethodCall

            CutoffDate = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", -1 * DaysBefore, this.iMidnightOf.MidnightOfFn(scalarFunction.Execute<DateTime>("GETDATE"))));
            if (VendNum != null)
            {
                //BEGIN
                VendNum = this.iExpandKyByType.ExpandKyByTypeFn("VendNumType", VendNum);
                //END
            }
            UnionUtil unionTable = new UnionUtil(UnionType.Union);

            #region CRUD LoadToRecord
            var poLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"Caption",$"{variableUtil.GetValue<string>(UnReceivedLabel)}"},
                    {"Count","COUNT(1)"},
                    {"Type","'U'"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "po",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("po_num IN (SELECT po_num FROM poitem WHERE qty_received < qty_ordered) AND (stat = 'O' OR stat = 'C') AND order_date >= {0} AND (vend_num = {1} OR {1} IS NULL)", CutoffDate, VendNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var poLoadResponse = this.appDB.Load(poLoadRequest);
            #endregion  LoadToRecord

            Data = poLoadResponse;

            unionTable.Add(poLoadResponse);

            #region CRUD LoadToRecord
            var po1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"Caption",$"{variableUtil.GetValue<string>(ReceivedLabel)}"},
                    {"Count","COUNT(1)"},
                    {"Type","'R'"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "po",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("po_num NOT IN (SELECT po_num FROM poitem WHERE qty_received < qty_ordered) AND (stat = 'O' OR stat = 'C') AND order_date >= {0} AND (vend_num = {1} OR {1} IS NULL)", CutoffDate, VendNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var po1LoadResponse = this.appDB.Load(po1LoadRequest);
            #endregion  LoadToRecord

            Data = po1LoadResponse;

            unionTable.Add(po1LoadResponse);
            var unionTableResult = unionTable.Process();
            Data = unionTableResult;

            return (Data, Severity);
        }
        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_POLinesReceivedCountSp(string AltExtGenSp,
            int? DaysBefore = 0,
            string VendNum = null)
        {
            IntType _DaysBefore = DaysBefore;
            VendNumType _VendNum = VendNum;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "DaysBefore", _DaysBefore, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);

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
