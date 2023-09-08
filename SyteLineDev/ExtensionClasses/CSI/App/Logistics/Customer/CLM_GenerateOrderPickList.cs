//PROJECT NAME: Logistics
//CLASS NAME: CLM_GenerateOrderPickList.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Material;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
    public class CLM_GenerateOrderPickList : ICLM_GenerateOrderPickList
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExpandKyByType iExpandKyByType;
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
        readonly IMsgApp iMsgApp;
        readonly ILowString lowString;
        readonly IHighString highString;
        public CLM_GenerateOrderPickList(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExpandKyByType iExpandKyByType,
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
            IMsgApp iMsgApp,
            ILowString lowString,
            IHighString highString)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExpandKyByType = iExpandKyByType;
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
            this.iMsgApp = iMsgApp;
            this.lowString = lowString;
            this.highString = highString;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) CLM_GenerateOrderPickListSp(string PStartCoNum,
            string PEndCoNum,
            DateTime? PStartDueDate,
            DateTime? PEndDueDate,
            string PStartWhse,
            string PEndWhse,
            string PStartCustNum,
            string PEndCustNum,
            int? PStartCustSeq,
            int? PEndCustSeq,
            string PParmsSite)
        {
            ICollectionLoadResponse Data = null;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            string Infobar = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_GenerateOrderPickListSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_GenerateOrderPickListSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_GenerateOrderPickListSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_CLM_GenerateOrderPickListSp(_ALTGEN_SpName,
                        PStartCoNum,
                        PEndCoNum,
                        PStartDueDate,
                        PEndDueDate,
                        PStartWhse,
                        PEndWhse,
                        PStartCustNum,
                        PEndCustNum,
                        PStartCustSeq,
                        PEndCustSeq,
                        PParmsSite);
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_GenerateOrderPickListSp") != null)
            {
                var EXTGEN = AltExtGen_CLM_GenerateOrderPickListSp("dbo.EXTGEN_CLM_GenerateOrderPickListSp",
                    PStartCoNum,
                    PEndCoNum,
                    PStartDueDate,
                    PEndDueDate,
                    PStartWhse,
                    PEndWhse,
                    PStartCustNum,
                    PEndCustNum,
                    PStartCustSeq,
                    PEndCustSeq,
                    PParmsSite);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            Severity = 0;
            PStartCoNum = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("CoNumType", PStartCoNum), this.lowString.LowStringFn("CoNumType"));
            PEndCoNum = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("CoNumType", PEndCoNum), this.highString.HighStringFn("CoNumType"));
            PStartDueDate = convertToUtil.ToDateTime(stringUtil.IsNull(PStartDueDate, this.iLowDate.LowDateFn()));
            PEndDueDate = convertToUtil.ToDateTime(stringUtil.IsNull(this.iDayEndOf.DayEndOfFn(PEndDueDate), this.iHighDate.HighDateFn()));
            PStartWhse = stringUtil.IsNull(PStartWhse, this.lowString.LowStringFn("WhseType"));
            PEndWhse = stringUtil.IsNull(PEndWhse, this.highString.HighStringFn("WhseType"));
            PStartCustNum = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("CustNumType", PStartCustNum), this.lowString.LowStringFn("CustNumType"));
            PEndCustNum = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("CustNumType", PEndCustNum), this.highString.HighStringFn("CustNumType"));
            PStartCustSeq = (int?)(stringUtil.IsNull(PStartCustSeq, this.iLowInt.LowIntFn()));
            PEndCustSeq = (int?)(stringUtil.IsNull(PEndCustSeq, this.iHighInt.HighIntFn()));

            #region CRUD ExecuteMethodCall

            var MsgApp = this.iMsgApp.MsgAppSp(Infobar: Infobar
                , BaseMsg: "I=IsCompare="
                , Parm1: "@co.credit_hold"
                , Parm2: "@:logical:yes");
            Infobar = MsgApp.Infobar;

            #endregion ExecuteMethodCall

            #region CRUD LoadArbitrary
            var co1LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"co.co_num","co.co_num"},
                    {"coitem.whse","coitem.whse"},
                    {"co.cust_num","co.cust_num"},
                    {"co.cust_seq","co.cust_seq"},
                    {"col4",$"CASE WHEN credit_hold = 1 THEN {variableUtil.GetValue<string>(Infobar)} ELSE NULL END"},
                },
                selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList  
                    FROM co 
                         INNER JOIN 
                         coitem 
                         ON (coitem.co_num = co.co_num) 
                         INNER JOIN 
                         whse 
                         ON (coitem.whse = whse.whse) 
                    WHERE co.stat = 'O' 
                          AND (co.type = 'R' 
                               OR co.type = 'B') 
                          AND (co.co_num BETWEEN {3}  AND {9} ) 
                          AND (co.cust_num BETWEEN {0}  AND {4} ) 
                          AND (co.cust_seq BETWEEN {1}  AND {5} ) 
                          AND coitem.stat = 'O' 
                          AND (coitem.whse BETWEEN {7}  AND {10} ) 
                          AND (coitem.due_date BETWEEN {2}  AND {6} ) 
                          AND coitem.ship_site = {8}  
                          AND whse.controlled_by_external_wms = 0 
                    ORDER BY co.cust_num, co.cust_seq, co.co_num, coitem.whse", PStartCustNum, PStartCustSeq, PStartDueDate, PStartCoNum, PEndCustNum, PEndCustSeq, PEndDueDate, PStartWhse, PParmsSite, PEndCoNum, PEndWhse));

            var co1LoadResponse = this.appDB.Load(co1LoadRequest);
            Data = co1LoadResponse;
            #endregion  LoadArbitrary

            return (Data, Severity);
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_GenerateOrderPickListSp(string AltExtGenSp,
            string PStartCoNum,
            string PEndCoNum,
            DateTime? PStartDueDate,
            DateTime? PEndDueDate,
            string PStartWhse,
            string PEndWhse,
            string PStartCustNum,
            string PEndCustNum,
            int? PStartCustSeq,
            int? PEndCustSeq,
            string PParmsSite)
        {
            CoNumType _PStartCoNum = PStartCoNum;
            CoNumType _PEndCoNum = PEndCoNum;
            DateType _PStartDueDate = PStartDueDate;
            DateType _PEndDueDate = PEndDueDate;
            WhseType _PStartWhse = PStartWhse;
            WhseType _PEndWhse = PEndWhse;
            CustNumType _PStartCustNum = PStartCustNum;
            CustNumType _PEndCustNum = PEndCustNum;
            CustSeqType _PStartCustSeq = PStartCustSeq;
            CustSeqType _PEndCustSeq = PEndCustSeq;
            SiteType _PParmsSite = PParmsSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "PStartCoNum", _PStartCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEndCoNum", _PEndCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PStartDueDate", _PStartDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEndDueDate", _PEndDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PStartWhse", _PStartWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEndWhse", _PEndWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PStartCustNum", _PStartCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEndCustNum", _PEndCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PStartCustSeq", _PStartCustSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEndCustSeq", _PEndCustSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PParmsSite", _PParmsSite, ParameterDirection.Input);

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
