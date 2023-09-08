//PROJECT NAME: Material
//CLASS NAME: ValidateCoRsvdQty.cs

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
using CSI.Data.SQL;

namespace CSI.Material
{
    public class ValidateCoRsvdQty : IValidateCoRsvdQty
    {
        readonly IApplicationDB appDB;

        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgAsk iMsgAsk;

        public ValidateCoRsvdQty(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IMsgAsk iMsgAsk)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iMsgAsk = iMsgAsk;
        }

        public (int? ReturnCode,
            string PromptMsg,
            string PromptButtons,
            string Infobar) 
        ValidateCoRsvdQtySp(string PCoNum,
            int? PCoLine,
            int? PCoRelease,
            decimal? PQtyRsvd,
            decimal? PQtyRsvdOld,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        {

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = 0;
            decimal? QtyReserved = null;
            QtyUnitType _QtyOrdered = DBNull.Value;
            decimal? QtyOrdered = null;
            QtyUnitType _QtyShipped = DBNull.Value;
            decimal? QtyShipped = null;
            decimal? QtyOpen = null;
            QtyUnitType _QtyShippedConv = DBNull.Value;
            decimal? QtyShippedConv = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateCoRsvdQtySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateCoRsvdQtySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ValidateCoRsvdQtySp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_ValidateCoRsvdQtySp(_ALTGEN_SpName,
                        PCoNum,
                        PCoLine,
                        PCoRelease,
                        PQtyRsvd,
                        PQtyRsvdOld,
                        PromptMsg,
                        PromptButtons,
                        Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, PromptMsg, PromptButtons, Infobar);
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ValidateCoRsvdQtySp") != null)
            {
                var EXTGEN = AltExtGen_ValidateCoRsvdQtySp("dbo.EXTGEN_ValidateCoRsvdQtySp",
                    PCoNum,
                    PCoLine,
                    PCoRelease,
                    PQtyRsvd,
                    PQtyRsvdOld,
                    PromptMsg,
                    PromptButtons,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.PromptMsg, EXTGEN.PromptButtons, EXTGEN.Infobar);
                }
            }

            PromptMsg = null;
            PromptButtons = null;
            Infobar = null;
            QtyReserved = 0;
            QtyOrdered = 0;
            Severity = 0;
            QtyReserved = (decimal?)((stringUtil.IsNull<decimal?>(PQtyRsvd, 0) - stringUtil.IsNull<decimal?>(PQtyRsvdOld, 0)));

            #region CRUD LoadToVariable
            var coitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_QtyOrdered,"qty_ordered_conv"},
                    {_QtyShipped,"qty_shipped"},
                    {_QtyShippedConv,"dbo.UomConvQty(qty_shipped, dbo.Getumcf(coitem.u_m, coitem.item, co.cust_num, 'C'), 'from base')"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "coitem",
                fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN co WITH (READUNCOMMITTED) ON co.co_num = coitem.co_num"),
                whereClause: collectionLoadRequestFactory.Clause("coitem.co_num = {2} AND coitem.co_line = {1} AND coitem.co_release = {0}", PCoRelease, PCoLine, PCoNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coitemLoadResponse = this.appDB.Load(coitemLoadRequest);
            if (coitemLoadResponse.Items.Count > 0)
            {
                QtyOrdered = _QtyOrdered;
                QtyShipped = _QtyShipped;
                QtyShippedConv = _QtyShippedConv;
            }
            #endregion  LoadToVariable

            QtyOpen = (decimal?)(QtyOrdered - QtyShippedConv);
            QtyOpen = (decimal?)(stringUtil.IsNull<decimal?>(QtyOpen, 0));
            if (sQLUtil.SQLGreaterThan(QtyReserved, QtyOpen) == true)
            {
                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: MsgAskSp
                var MsgAsk = this.iMsgAsk.MsgAskSp(Infobar: PromptMsg
                    , Buttons: PromptButtons
                    , BaseMsg: "Q=WillCompare>3NoYes"
                    , Parm1: "@coitem.qty_rsvd"
                    , Parm2: "@coitem.qty_ordered"
                    , Parm3: "@coitem"
                    , Parm4: "@coitem.co_num"
                    , Parm5: PCoNum
                    , Parm6: "@coitem.co_line"
                    , Parm7: convertToUtil.ToString(PCoLine)
                    , Parm8: "@coitem.co_release"
                    , Parm9: convertToUtil.ToString(PCoRelease));
                PromptMsg = MsgAsk.Infobar;
                PromptButtons = MsgAsk.Buttons;

                #endregion ExecuteMethodCall

                goto SkipLineCheck;
            }

            #region CRUD LoadToVariable
            var rsvd_invLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"qty_rsvd_conv","qty_rsvd_conv"}
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "rsvd_inv",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("ref_num = {2} AND ref_line = {1} AND ref_release = {0}", PCoRelease, PCoLine, PCoNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var rsvd_invLoadResponse = this.appDB.Load(rsvd_invLoadRequest);
            if (rsvd_invLoadResponse.Items.Count > 0)
            {
                foreach (var rsvdInvItem in rsvd_invLoadResponse.Items)
                {
                    QtyReserved = QtyReserved + rsvdInvItem.GetValue<decimal?>("qty_rsvd_conv");
                }
            }
            #endregion  LoadToVariable

            if (sQLUtil.SQLGreaterThan(stringUtil.IsNull<decimal?>(QtyReserved, 0), QtyOpen) == true)
            {
                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: MsgAskSp
                var MsgAsk1 = this.iMsgAsk.MsgAskSp(Infobar: PromptMsg
                    , Buttons: PromptButtons
                    , BaseMsg: "Q=WillCompare>3NoYes"
                    , Parm1: "@coitem.qty_rsvd"
                    , Parm2: "@coitem.qty_ordered"
                    , Parm3: "@coitem"
                    , Parm4: "@coitem.co_num"
                    , Parm5: PCoNum
                    , Parm6: "@coitem.co_line"
                    , Parm7: convertToUtil.ToString(PCoLine)
                    , Parm8: "@coitem.co_release"
                    , Parm9: convertToUtil.ToString(PCoRelease));
                PromptMsg = MsgAsk1.Infobar;
                PromptButtons = MsgAsk1.Buttons;

                #endregion ExecuteMethodCall
            }
        SkipLineCheck:;
            return (Severity, PromptMsg, PromptButtons, Infobar);
        }

        public (int? ReturnCode, 
            string PromptMsg,
            string PromptButtons,
            string Infobar) 
        AltExtGen_ValidateCoRsvdQtySp(
            string AltExtGenSp,
            string PCoNum,
            int? PCoLine,
            int? PCoRelease,
            decimal? PQtyRsvd,
            decimal? PQtyRsvdOld,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        {
            CoNumType _PCoNum = PCoNum;
            CoLineType _PCoLine = PCoLine;
            CoReleaseType _PCoRelease = PCoRelease;
            QtyUnitType _PQtyRsvd = PQtyRsvd;
            QtyUnitType _PQtyRsvdOld = PQtyRsvdOld;
            Infobar _PromptMsg = PromptMsg;
            Infobar _PromptButtons = PromptButtons;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PQtyRsvd", _PQtyRsvd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PQtyRsvdOld", _PQtyRsvdOld, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PromptMsg = _PromptMsg;
                PromptButtons = _PromptButtons;
                Infobar = _Infobar;

                return (Severity, PromptMsg, PromptButtons, Infobar);
            }
        }
    }
}
