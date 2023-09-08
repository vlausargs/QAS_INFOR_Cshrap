//PROJECT NAME: Logistics
//CLASS NAME: ValidateItemCust.cs

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
using System.Linq;

namespace CSI.Logistics.Customer
{
    public class ValidateItemCust : IValidateItemCust
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
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;
        readonly ICanAny iCanAny;
        readonly IMsgAsk iMsgAsk;

        public ValidateItemCust(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp,
            ICanAny iCanAny,
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
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
            this.iCanAny = iCanAny;
            this.iMsgAsk = iMsgAsk;
        }

        public (
            int? ReturnCode,
            string NewItem,
            int? ItemCustExists,
            int? ItemCustUpdate,
            int? ItemCustAdd,
            string WarningMsg,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        ValidateItemCustSp(
            string CustNum,
            string CustItem,
            string Item,
            string NewItem,
            int? ItemCustExists,
            int? ItemCustUpdate,
            int? ItemCustAdd,
            string WarningMsg,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        {

            CustItemType _CustItem = CustItem;
            ItemType _Item = Item;
            ItemType _NewItem = NewItem;
            ListYesNoType _ItemCustExists = ItemCustExists;
            ListYesNoType _ItemCustUpdate = ItemCustUpdate;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            RowPointerType _icRowPointer = DBNull.Value;
            Guid? icRowPointer = null;
            int? CanInsert = null;
            int? CanUpdate = null;
            ListYesNoType _BlankCIExist = DBNull.Value;
            int? BlankCIExist = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateItemCustSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ValidateItemCustSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ValidateItemCustSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_ValidateItemCustSp(_ALTGEN_SpName,
                        CustNum,
                        CustItem,
                        Item,
                        NewItem,
                        ItemCustExists,
                        ItemCustUpdate,
                        ItemCustAdd,
                        WarningMsg,
                        PromptMsg,
                        PromptButtons,
                        Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;


                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        NewItem = _NewItem;
                        ItemCustExists = _ItemCustExists;
                        ItemCustUpdate = _ItemCustUpdate;
                        return (ALTGEN_Severity, NewItem, ItemCustExists, ItemCustUpdate, ItemCustAdd, WarningMsg, PromptMsg, PromptButtons, Infobar);

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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ValidateItemCustSp") != null)
            {
                var EXTGEN = AltExtGen_ValidateItemCustSp("dbo.EXTGEN_ValidateItemCustSp",
                    CustNum,
                    CustItem,
                    Item,
                    NewItem,
                    ItemCustExists,
                    ItemCustUpdate,
                    ItemCustAdd,
                    WarningMsg,
                    PromptMsg,
                    PromptButtons,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.NewItem, EXTGEN.ItemCustExists, EXTGEN.ItemCustUpdate, EXTGEN.ItemCustAdd, EXTGEN.WarningMsg, EXTGEN.PromptMsg, EXTGEN.PromptButtons, EXTGEN.Infobar);
                }
            }

            _BlankCIExist = 0;
            BlankCIExist = 0;
            Severity = 0;
            Infobar = null;
            WarningMsg = null;
            PromptMsg = null;
            PromptButtons = null;
            NewItem = null;
            icRowPointer = null;
            ItemCustExists = 0;
            ItemCustUpdate = 0;
            ItemCustAdd = 0;
            while (sQLUtil.SQLBool(sQLUtil.SQLEqual(Severity, 0)))
            {
                if (sQLUtil.SQLBool(sQLUtil.SQLAnd(Item != null, sQLUtil.SQLNot(existsChecker.Exists(
                    tableName: "item",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("item.item = {0}", Item))))))
                {
                    break;
                }

                #region CRUD LoadToVariable
                var itemcustLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_BlankCIExist,"1"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "itemcust",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("cust_num = {0} AND cust_item IS NULL AND item = {1}", CustNum, Item),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var itemcustLoadResponse = this.appDB.Load(itemcustLoadRequest);
                if (itemcustLoadResponse.Items.Count > 0)
                {
                    BlankCIExist = _BlankCIExist;
                }
                #endregion  LoadToVariable

                #region CRUD LoadToRecord
                var itemcust1LoadRequestForScalarSubQuery = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"col0","COUNT(*)"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "itemcust",
                    fromClause: collectionLoadRequestFactory.Clause(" AS ic"),
                    whereClause: collectionLoadRequestFactory.Clause("ic.cust_num = {1} AND ISNULL(ic.cust_item, NCHAR(1)) = ISNULL({0}, NCHAR(1))", CustItem, CustNum),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var itemcust1LoadResponseForScalarSubQuery = this.appDB.Load(itemcust1LoadRequestForScalarSubQuery);
                #endregion  LoadToRecord

                if (sQLUtil.SQLEqual(1, ((itemcust1LoadResponseForScalarSubQuery.Items != null &&
                itemcust1LoadResponseForScalarSubQuery.Items.Count != 0) ?
                (itemcust1LoadResponseForScalarSubQuery.Items.FirstOrDefault().GetValue<int?>("col0")) : null)) == true)
                {
                    #region CRUD LoadToVariable
                    var itemcustASicLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_NewItem,"ic.item"},
                            {_CustItem,"ic.cust_item"},
                            {_ItemCustExists,"1"},
                            {_ItemCustUpdate,"0"},
                            {_icRowPointer,"ic.RowPointer"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        maximumRows: 1,
                        tableName: "itemcust AS ic",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("ic.cust_num = {1} AND ISNULL(ic.cust_item, NCHAR(1)) = ISNULL({0}, NCHAR(1))", CustItem, CustNum),
                        orderByClause: collectionLoadRequestFactory.Clause(" ic.cust_num, ic.item"));
                    ;
                    var itemcustASicLoadResponse = this.appDB.Load(itemcustASicLoadRequest);
                    if (itemcustASicLoadResponse.Items.Count > 0)
                    {
                        NewItem = _NewItem;
                        CustItem = _CustItem;
                        ItemCustExists = _ItemCustExists;
                        ItemCustUpdate = _ItemCustUpdate;
                        icRowPointer = _icRowPointer;
                    }
                    #endregion  LoadToVariable
                }
                else
                {
                    #region CRUD LoadToVariable
                    var itemcustASic1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_CustItem,"ic.cust_item"},
                            {_ItemCustExists,"1"},
                            {_ItemCustUpdate,"0"},
                            {_icRowPointer,"ic.RowPointer"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        maximumRows: 1,
                        tableName: "itemcust AS ic",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("ic.cust_num = {1} AND ISNULL(ic.cust_item, NCHAR(1)) = ISNULL({0}, NCHAR(1))", CustItem, CustNum),
                        orderByClause: collectionLoadRequestFactory.Clause(" ic.cust_num, ic.item"));
                    
                    var itemcustASic1LoadResponse = this.appDB.Load(itemcustASic1LoadRequest);
                    if (itemcustASic1LoadResponse.Items.Count > 0)
                    {
                        CustItem = _CustItem;
                        ItemCustExists = _ItemCustExists;
                        ItemCustUpdate = _ItemCustUpdate;
                        icRowPointer = _icRowPointer;
                    }
                    #endregion  LoadToVariable
                }
                if (icRowPointer == null)
                {
                    #region CRUD ExecuteMethodCall

                    var MsgApp = this.iMsgApp.MsgAppSp(Infobar: WarningMsg
                        , BaseMsg: "I=NoExist2"
                        , Parm1: "@itemcust"
                        , Parm2: "@itemcust.cust_item"
                        , Parm3: CustItem
                        , Parm4: "@itemcust.cust_num"
                        , Parm5: CustNum);
                    WarningMsg = MsgApp.Infobar;

                    #endregion ExecuteMethodCall

                    if (Item == null)
                    {
                        Severity = 16;
                        Infobar = WarningMsg;
                        WarningMsg = null;

                        break;
                    }

                    CanInsert = convertToUtil.ToInt32(this.iCanAny.CanAnyFn("Insert", "CustomerContracts"));
                    CanUpdate = convertToUtil.ToInt32(this.iCanAny.CanAnyFn("Update", "CustomerContracts"));
                    if (sQLUtil.SQLEqual(CanInsert, 0) == true && (sQLUtil.SQLEqual(BlankCIExist, 0) == true || sQLUtil.SQLEqual(CanUpdate, 0) == true))
                    {
                        ItemCustUpdate = 1;
                        goto EOF;
                    }
                }
                icRowPointer = null;
                if (sQLUtil.SQLBool(Item != null))
                {
                    if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(
                        tableName: "itemcust",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("cust_num = {1} AND ISNULL(cust_item, NCHAR(1)) = ISNULL({0}, NCHAR(1)) AND item = {2}", CustItem, CustNum, Item)))))
                    {
                        NewItem = Item;
                        CanInsert = convertToUtil.ToInt32(this.iCanAny.CanAnyFn("Insert", "CustomerContracts"));
                        if (sQLUtil.SQLEqual(CanInsert, 1) == true)
                        {
                            ItemCustAdd = 1;
                        }
                        else
                        {
                            ItemCustAdd = 0;
                        }
                        WarningMsg = null;
                        if (sQLUtil.SQLEqual(ItemCustAdd, 1) == true)
                        {
                            #region CRUD ExecuteMethodCall

                            var MsgApp1 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
                                , BaseMsg: "I=NoExist3"
                                , Parm1: "@itemcust"
                                , Parm2: "@itemcust.item"
                                , Parm3: Item
                                , Parm4: "@itemcust.cust_num"
                                , Parm5: CustNum
                                , Parm6: "@itemcust.cust_item"
                                , Parm7: CustItem);
                            PromptMsg = MsgApp1.Infobar;

                            #endregion ExecuteMethodCall
                        }
                        if (sQLUtil.SQLEqual(BlankCIExist, 1) == true)
                        {
                            CanUpdate = convertToUtil.ToInt32(this.iCanAny.CanAnyFn("Update", "CustomerContracts"));
                            if (sQLUtil.SQLEqual(CanUpdate, 1) == true)
                            {
                                ItemCustUpdate = 1;
                            }
                            else
                            {
                                ItemCustUpdate = 0;
                            }

                            #region CRUD ExecuteMethodCall

                            var MsgApp2 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
                                , BaseMsg: "I=Exist3"
                                , Parm1: "@itemcust"
                                , Parm2: "@itemcust.item"
                                , Parm3: Item
                                , Parm4: "@itemcust.cust_num"
                                , Parm5: CustNum
                                , Parm6: "@itemcust.cust_item"
                                , Parm7: null);
                            PromptMsg = MsgApp2.Infobar;

                            #endregion ExecuteMethodCall
                        }
                        if (sQLUtil.SQLEqual(ItemCustUpdate, 1) == true && sQLUtil.SQLEqual(ItemCustAdd, 1) == true)
                        {
                            #region CRUD ExecuteMethodCall

                            var MsgApp3 = this.iMsgApp.MsgAppSp(Infobar: PromptMsg
                                , BaseMsg: "I=CmdPerform0"
                                , Parm1: "@!Yes"
                                , Parm2: "@%add"
                                , Parm3: "@itemcust");
                            PromptMsg = MsgApp3.Infobar;

                            #endregion ExecuteMethodCall

                            #region CRUD ExecuteMethodCall

                            //Please Generate the bounce for this stored procedure: MsgAskSp
                            var MsgAsk = this.iMsgAsk.MsgAskSp(Infobar: PromptMsg
                                , Buttons: PromptButtons
                                , BaseMsg: "Q=CmdPerform1AddUpdateCancel"
                                , Parm1: "@!No"
                                , Parm2: "@%Update"
                                , Parm3: "@itemcust"
                                , Parm4: "@itemcust.cust_item"
                                , Parm5: null);
                            PromptMsg = MsgAsk.Infobar;
                            PromptButtons = MsgAsk.Buttons;

                            #endregion ExecuteMethodCall
                        }
                        else
                        {
                            if (sQLUtil.SQLEqual(ItemCustUpdate, 1) == true)
                            {
                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: MsgAskSp
                                var MsgAsk1 = this.iMsgAsk.MsgAskSp(Infobar: PromptMsg
                                    , Buttons: PromptButtons
                                    , BaseMsg: "Q=CmdPerform0NoYes"
                                    , Parm1: "@%Update"
                                    , Parm2: "@itemcust");
                                PromptMsg = MsgAsk1.Infobar;
                                PromptButtons = MsgAsk1.Buttons;

                                #endregion ExecuteMethodCall
                            }
                            else
                            {
                                if (sQLUtil.SQLEqual(ItemCustAdd, 1) == true)
                                {
                                    #region CRUD ExecuteMethodCall

                                    //Please Generate the bounce for this stored procedure: MsgAskSp
                                    var MsgAsk2 = this.iMsgAsk.MsgAskSp(Infobar: PromptMsg
                                        , Buttons: PromptButtons
                                        , BaseMsg: "Q=CmdPerform0NoYes"
                                        , Parm1: "@%add"
                                        , Parm2: "@itemcust");
                                    PromptMsg = MsgAsk2.Infobar;
                                    PromptButtons = MsgAsk2.Buttons;

                                    #endregion ExecuteMethodCall
                                }
                                else
                                {
                                    Severity = 16;
                                    Infobar = PromptMsg;
                                    PromptMsg = null;

                                    break;
                                }
                            }
                        }
                    }
                }

                break;
            }

        EOF:;

            return (Severity, NewItem, ItemCustExists, ItemCustUpdate, ItemCustAdd, WarningMsg, PromptMsg, PromptButtons, Infobar);
        }

        public (int? ReturnCode,
            string NewItem,
            int? ItemCustExists,
            int? ItemCustUpdate,
            int? ItemCustAdd,
            string WarningMsg,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        AltExtGen_ValidateItemCustSp(
            string AltExtGenSp,
            string CustNum,
            string CustItem,
            string Item,
            string NewItem,
            int? ItemCustExists,
            int? ItemCustUpdate,
            int? ItemCustAdd,
            string WarningMsg,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        {
            CustNumType _CustNum = CustNum;
            CustItemType _CustItem = CustItem;
            ItemType _Item = Item;
            ItemType _NewItem = NewItem;
            ListYesNoType _ItemCustExists = ItemCustExists;
            ListYesNoType _ItemCustUpdate = ItemCustUpdate;
            ListYesNoType _ItemCustAdd = ItemCustAdd;
            InfobarType _WarningMsg = WarningMsg;
            InfobarType _PromptMsg = PromptMsg;
            InfobarType _PromptButtons = PromptButtons;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewItem", _NewItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemCustExists", _ItemCustExists, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemCustUpdate", _ItemCustUpdate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemCustAdd", _ItemCustAdd, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "WarningMsg", _WarningMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                NewItem = _NewItem;
                ItemCustExists = _ItemCustExists;
                ItemCustUpdate = _ItemCustUpdate;
                ItemCustAdd = _ItemCustAdd;
                WarningMsg = _WarningMsg;
                PromptMsg = _PromptMsg;
                PromptButtons = _PromptButtons;
                Infobar = _Infobar;

                return (Severity, NewItem, ItemCustExists, ItemCustUpdate, ItemCustAdd, WarningMsg, PromptMsg, PromptButtons, Infobar);
            }
        }
    }
}
