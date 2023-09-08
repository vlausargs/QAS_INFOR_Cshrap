//PROJECT NAME: Finance
//CLASS NAME: CCIGetLastTransInfo.cs

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
using CSI.Material;

namespace CSI.Finance.CreditCard
{
    public class CCIGetLastTransInfo : ICCIGetLastTransInfo
    {
        readonly IApplicationDB appDB;

        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;

        public CCIGetLastTransInfo(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
        }

        public (
            int? ReturnCode,
            decimal? GatewayTransNum,
            int? Success,
            string Infobar)
        CCIGetLastTransInfoSp(
            string CardSystemId,
            string CardSystem,
            string RefType,
            string TransType,
            string OrdInvNum,
            decimal? GatewayTransNum,
            int? Success,
            string Infobar)
        {

            CCIGatewayTransNumType _GatewayTransNum = GatewayTransNum;
            ListYesNoType _Success = Success;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CCIGetLastTransInfoSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CCIGetLastTransInfoSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CCIGetLastTransInfoSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_CCIGetLastTransInfoSp(_ALTGEN_SpName,
                        CardSystemId,
                        CardSystem,
                        RefType,
                        TransType,
                        OrdInvNum,
                        GatewayTransNum,
                        Success,
                        Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        GatewayTransNum = _GatewayTransNum;
                        Success = _Success;
                        return (ALTGEN_Severity, GatewayTransNum, Success, Infobar);
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CCIGetLastTransInfoSp") != null)
            {
                var EXTGEN = AltExtGen_CCIGetLastTransInfoSp("dbo.EXTGEN_CCIGetLastTransInfoSp",
                    CardSystemId,
                    CardSystem,
                    RefType,
                    TransType,
                    OrdInvNum,
                    GatewayTransNum,
                    Success,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.GatewayTransNum, EXTGEN.Success, EXTGEN.Infobar);
                }
            }

            Severity = 0;
            Infobar = null;
            if (sQLUtil.SQLEqual(RefType, "I") == true)
            {
                OrdInvNum = this.iExpandKyByType.ExpandKyByTypeFn(
                    "InvNumType",
                    OrdInvNum);
            }
            if (sQLUtil.SQLEqual(RefType, "N") == true)
            {
                OrdInvNum = stringUtil.LTrim(OrdInvNum);
            }

            #region CRUD LoadToVariable
            var cci_transLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_GatewayTransNum,"gateway_trans_num"},
                    {_Success,"success"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "cci_trans",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("card_system_id = {0} AND card_system = {1} AND ref_type = {4} AND ref_num = {2} AND trans_type = {3}", CardSystemId, CardSystem, OrdInvNum, TransType, RefType),
                orderByClause: collectionLoadRequestFactory.Clause(" trans_date DESC"));

            var cci_transLoadResponse = this.appDB.Load(cci_transLoadRequest);
            if (cci_transLoadResponse.Items.Count > 0)
            {
                GatewayTransNum = _GatewayTransNum;
                Success = _Success;
            }
            #endregion  LoadToVariable

            if (GatewayTransNum == null)
            {
                #region CRUD ExecuteMethodCall

                var MsgApp = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "E=SSSCCITransNotFound");
                Severity = MsgApp.ReturnCode;
                Infobar = MsgApp.Infobar;

                #endregion ExecuteMethodCall

                return (Severity, GatewayTransNum, Success, Infobar);//END
            }

            return (Severity, GatewayTransNum, Success, Infobar);
        }

        public (int? ReturnCode,
            decimal? GatewayTransNum,
            int? Success,
            string Infobar)
        AltExtGen_CCIGetLastTransInfoSp(
            string AltExtGenSp,
            string CardSystemId,
            string CardSystem,
            string RefType,
            string TransType,
            string OrdInvNum,
            decimal? GatewayTransNum,
            int? Success,
            string Infobar)
        {
            CCICardSystemIDType _CardSystemId = CardSystemId;
            CCICardSystemType _CardSystem = CardSystem;
            CCITransRefTypeType _RefType = RefType;
            CCITransTypeType _TransType = TransType;
            InvNumType _OrdInvNum = OrdInvNum;
            CCIGatewayTransNumType _GatewayTransNum = GatewayTransNum;
            ListYesNoType _Success = Success;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CardSystem", _CardSystem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrdInvNum", _OrdInvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "GatewayTransNum", _GatewayTransNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Success", _Success, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                GatewayTransNum = _GatewayTransNum;
                Success = _Success;
                Infobar = _Infobar;

                return (Severity, GatewayTransNum, Success, Infobar);
            }
        }
    }
}
