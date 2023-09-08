//PROJECT NAME: Logistics
//CLASS NAME: ValidateShipCoCoNum.cs

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
    public class ValidateShipCoCoNum : IValidateShipCoCoNum
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
        readonly IStringUtil stringUtil;
        readonly IShipLcr iShipLcr;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;

        public ValidateShipCoCoNum(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IStringUtil stringUtil,
            IShipLcr iShipLcr,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp)
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
            this.stringUtil = stringUtil;
            this.iShipLcr = iShipLcr;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
        }

        public (int? ReturnCode,
            string PromptMsg,
            string PromptButtons,
            string Infobar) 
        ValidateShipCoCoNumSp(string PCoNum,
            DateTime? PGenDate,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        {
            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            RowPointerType _ShipCoRowPointer = DBNull.Value;
            Guid? ShipCoRowPointer = null;
            BatchIdType _ShipCoBatchId = DBNull.Value;
            int? ShipCoBatchId = null;
            ListYesNoType _AllowCoOnMultipleBatches = DBNull.Value;
            int? AllowCoOnMultipleBatches = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateShipCoCoNumSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateShipCoCoNumSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ValidateShipCoCoNumSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_ValidateShipCoCoNumSp(_ALTGEN_SpName,
                        PCoNum,
                        PGenDate,
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ValidateShipCoCoNumSp") != null)
            {
                var EXTGEN = AltExtGen_ValidateShipCoCoNumSp("dbo.EXTGEN_ValidateShipCoCoNumSp",
                    PCoNum,
                    PGenDate,
                    PromptMsg,
                    PromptButtons,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.PromptMsg, EXTGEN.PromptButtons, EXTGEN.Infobar);
                }
            }

            Severity = 0;
            Infobar = null;
            ShipCoRowPointer = null;
            while (sQLUtil.SQLEqual(Severity, 0) == true)
            {
                #region CRUD LoadToVariable
                var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_AllowCoOnMultipleBatches,"allow_co_on_multiple_batches"},
                    },
                    loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "coparms",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var coparmsLoadResponse = this.appDB.Load(coparmsLoadRequest);
                if (coparmsLoadResponse.Items.Count > 0)
                {
                    AllowCoOnMultipleBatches = _AllowCoOnMultipleBatches;
                }
                #endregion  LoadToVariable

                if (sQLUtil.SQLEqual(AllowCoOnMultipleBatches, 0) == true || AllowCoOnMultipleBatches == null)
                {
                    #region CRUD LoadToVariable
                    var shipcoLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_ShipCoRowPointer,"shipco.RowPointer"},
                            {_ShipCoBatchId,"shipco.batch_id"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "shipco",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("shipco.co_num = {0}", PCoNum),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var shipcoLoadResponse = this.appDB.Load(shipcoLoadRequest);
                    if (shipcoLoadResponse.Items.Count > 0)
                    {
                        ShipCoRowPointer = _ShipCoRowPointer;
                        ShipCoBatchId = _ShipCoBatchId;
                    }
                    #endregion  LoadToVariable

                    if (ShipCoRowPointer != null)
                    {
                        #region CRUD ExecuteMethodCall

                        var MsgApp = this.iMsgApp.MsgAppSp(Infobar: Infobar
                            , BaseMsg: "E=Exist1"
                            , Parm1: "@shipco"
                            , Parm2: "@shipco.co_num"
                            , Parm3: PCoNum);
                        Severity = MsgApp.ReturnCode;
                        Infobar = MsgApp.Infobar;

                        #endregion ExecuteMethodCall

                        #region CRUD ExecuteMethodCall

                        var MsgApp1 = this.iMsgApp.MsgAppSp(Infobar: Infobar
                            , BaseMsg: "E=IsCompare"
                            , Parm1: "@shipco.batch_id"
                            , Parm2: convertToUtil.ToString(ShipCoBatchId));
                        Severity = MsgApp1.ReturnCode;
                        Infobar = MsgApp1.Infobar;

                        #endregion ExecuteMethodCall
                    }
                    if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                    {
                        break;
                    }
                }

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ShipLcrSp
                var ShipLcr = this.iShipLcr.ShipLcrSp(PCoNum: PCoNum
                    , PTransDate: PGenDate
                    , PMText: "@%add"
                    , PromptMsg: PromptMsg
                    , PromptButtons: PromptButtons
                    , Infobar: Infobar);
                Severity = ShipLcr.ReturnCode;
                PromptMsg = ShipLcr.PromptMsg;
                PromptButtons = ShipLcr.PromptButtons;
                Infobar = ShipLcr.Infobar;

                #endregion ExecuteMethodCall

                break;
            }

            return (Severity, PromptMsg, PromptButtons, Infobar);
        }

        public (int? ReturnCode, string PromptMsg,
            string PromptButtons,
            string Infobar) 
        AltExtGen_ValidateShipCoCoNumSp(string AltExtGenSp,
            string PCoNum,
            DateTime? PGenDate,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        {
            CoNumType _PCoNum = PCoNum;
            DateType _PGenDate = PGenDate;
            InfobarType _PromptMsg = PromptMsg;
            InfobarType _PromptButtons = PromptButtons;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PGenDate", _PGenDate, ParameterDirection.Input);
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
