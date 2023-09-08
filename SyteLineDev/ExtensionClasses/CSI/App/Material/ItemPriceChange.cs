//PROJECT NAME: Material
//CLASS NAME: ItemPriceChange.cs

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
    public class ItemPriceChange : IItemPriceChange
    {
        readonly IApplicationDB appDB;

        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IGetSiteDate iGetSiteDate;
        readonly IVariableUtil variableUtil;
        readonly IMidnightOf iMidnightOf;
        readonly IStringUtil stringUtil;
        readonly IHighDate iHighDate;
        readonly ILowDate iLowDate;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;
        readonly IHighString highString;
        readonly ILowString lowString;

        public ItemPriceChange(IApplicationDB appDB,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IApplyDateOffset iApplyDateOffset,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IGetSiteDate iGetSiteDate,
            IVariableUtil variableUtil,
            IMidnightOf iMidnightOf,
            IStringUtil stringUtil,
            IHighDate iHighDate,
            ILowDate iLowDate,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp,
            ILowString lowString,
            IHighString highString)
        {
            this.appDB = appDB;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iApplyDateOffset = iApplyDateOffset;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.iGetSiteDate = iGetSiteDate;
            this.variableUtil = variableUtil;
            this.iMidnightOf = iMidnightOf;
            this.stringUtil = stringUtil;
            this.highString = highString;
            this.lowString = lowString;
            this.iHighDate = iHighDate;
            this.iLowDate = iLowDate;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
        }

        public (
            int? ReturnCode,
            string Infobar)
        ItemPriceChangeSp(
            string SessionIDChar,
            string FromProductCode,
            string ToProductCode,
            string FromItem,
            string ToItem,
            DateTime? FromEffectDate,
            DateTime? ToEffectDate,
            string FromPriceCode,
            string ToPriceCode,
            string FromCurrCode,
            string ToCurrCode,
            string FromCustNum,
            string ToCustNum,
            string FromCustType,
            string ToCustType,
            string FromEndUserType,
            string ToEndUserType,
            DateTime? FromDueDate,
            DateTime? ToDueDate,
            DateTime? NewEffectDate,
            int? UpdateCreate = 0,
            int? ItmPrc1 = 0,
            int? ItmPrc2 = 0,
            int? ItmPrc3 = 0,
            int? ItmPrc4 = 0,
            int? ItmPrc5 = 0,
            int? ItmPrc6 = 0,
            string PriceType = "I",
            string PriWhole = "PB",
            string AmtType = "A",
            decimal? PriAmt = 0.0M,
            string Infobar = null,
            int? StartingEffectDateOffset = null,
            int? EndingEffectDateOffset = null)
        {

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            int? Counter = null;
            ListYesNoType _Wholesale1 = DBNull.Value;
            int? Wholesale1 = null;
            ListYesNoType _Wholesale2 = DBNull.Value;
            int? Wholesale2 = null;
            string CurrCode = null;
            string CustNum = null;
            string item = null;
            Guid? vRowPointer = null;
            int? CustItemSeq = null;
            IntType _NextSeq = DBNull.Value;
            int? NextSeq = null;
            int? ProductNull = null;
            int? PriceCodeNull = null;
            int? CurrCodeNull = null;
            int? CustTypeNULL = null;
            int? EndUserTypeNULL = null;
            IntType _itmRePrc = DBNull.Value;
            int? itmRePrc = null;
            Guid? SessionID = null;
            string WholesaleChange = null;
            ICollectionLoadRequest itempricecurLoadRequestForCursor = null;
            ICollectionLoadResponse itempricecurLoadResponseForCursor = null;
            int itempricecur_CursorFetch_Status = -1;
            int itempricecur_CursorCounter = -1;
            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ItemPriceChangeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
            )
            {
                //BEGIN
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");

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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ItemPriceChangeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ItemPriceChangeSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                    items: optional_module1LoadResponse.Items);

                this.appDB.Insert(optional_module1InsertRequest);
                #endregion InsertByRecords

                while (existsChecker.Exists(tableName: "#tv_ALTGEN",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""))
                )
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
                    var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
                    if (tv_ALTGEN1LoadResponse.Items.Count > 0)
                    {
                        ALTGEN_SpName = _ALTGEN_SpName;
                    }
                    #endregion  LoadToVariable

                    var ALTGEN = AltExtGen_ItemPriceChangeSp(ALTGEN_SpName,
                        SessionIDChar,
                        FromProductCode,
                        ToProductCode,
                        FromItem,
                        ToItem,
                        FromEffectDate,
                        ToEffectDate,
                        FromPriceCode,
                        ToPriceCode,
                        FromCurrCode,
                        ToCurrCode,
                        FromCustNum,
                        ToCustNum,
                        FromCustType,
                        ToCustType,
                        FromEndUserType,
                        ToEndUserType,
                        FromDueDate,
                        ToDueDate,
                        NewEffectDate,
                        UpdateCreate,
                        ItmPrc1,
                        ItmPrc2,
                        ItmPrc3,
                        ItmPrc4,
                        ItmPrc5,
                        ItmPrc6,
                        PriceType,
                        PriWhole,
                        AmtType,
                        PriAmt,
                        Infobar,
                        StartingEffectDateOffset,
                        EndingEffectDateOffset);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, Infobar);

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
                    //END

                }
                //END

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ItemPriceChangeSp") != null)
            {
                var EXTGEN = AltExtGen_ItemPriceChangeSp("dbo.EXTGEN_ItemPriceChangeSp",
                    SessionIDChar,
                    FromProductCode,
                    ToProductCode,
                    FromItem,
                    ToItem,
                    FromEffectDate,
                    ToEffectDate,
                    FromPriceCode,
                    ToPriceCode,
                    FromCurrCode,
                    ToCurrCode,
                    FromCustNum,
                    ToCustNum,
                    FromCustType,
                    ToCustType,
                    FromEndUserType,
                    ToEndUserType,
                    FromDueDate,
                    ToDueDate,
                    NewEffectDate,
                    UpdateCreate,
                    ItmPrc1,
                    ItmPrc2,
                    ItmPrc3,
                    ItmPrc4,
                    ItmPrc5,
                    ItmPrc6,
                    PriceType,
                    PriWhole,
                    AmtType,
                    PriAmt,
                    Infobar,
                    StartingEffectDateOffset,
                    EndingEffectDateOffset);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.Infobar);
                }
            }

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
                Date: FromEffectDate,
                Offset: StartingEffectDateOffset,
                IsEndDate: 0);
            FromEffectDate = ApplyDateOffset.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
                Date: ToEffectDate,
                Offset: EndingEffectDateOffset,
                IsEndDate: 1);
            ToEffectDate = ApplyDateOffset1.Date;

            #endregion ExecuteMethodCall

            Severity = 0;
            Counter = 0;
            itmRePrc = 0;
            SessionID = string.IsNullOrEmpty(SessionIDChar) ? default(Guid?) : new Guid(SessionIDChar);
            ProductNull = convertToUtil.ToInt32(((FromProductCode == null ? 1 : 0)));
            PriceCodeNull = convertToUtil.ToInt32(((FromPriceCode == null ? 1 : 0)));
            CurrCodeNull = convertToUtil.ToInt32(((FromCurrCode == null ? 1 : 0)));
            CustTypeNULL = convertToUtil.ToInt32(((FromCustType == null ? 1 : 0)));
            EndUserTypeNULL = convertToUtil.ToInt32(((FromEndUserType == null ? 1 : 0)));
            FromProductCode = stringUtil.IsNull(
                FromProductCode,
                this.lowString.LowStringFn("ProductCodeType"));
            ToProductCode = stringUtil.IsNull(
                ToProductCode,
                this.highString.HighStringFn("ProductCodeType"));
            FromItem = stringUtil.IsNull(
                FromItem,
                this.lowString.LowStringFn("ItemType"));
            ToItem = stringUtil.IsNull(
                ToItem,
                this.highString.HighStringFn("ItemType"));
            FromEffectDate = convertToUtil.ToDateTime(stringUtil.IsNull(
                FromEffectDate,
                this.iLowDate.LowDateFn()));
            ToEffectDate = convertToUtil.ToDateTime(stringUtil.IsNull(
                ToEffectDate,
                this.iHighDate.HighDateFn()));
            FromPriceCode = stringUtil.IsNull(
                FromPriceCode,
                this.lowString.LowStringFn("PriceCodeType"));
            ToPriceCode = stringUtil.IsNull(
                ToPriceCode,
                this.highString.HighStringFn("PriceCodeType"));
            FromCurrCode = stringUtil.IsNull(
                FromCurrCode,
                this.lowString.LowStringFn("CurrCodeType"));
            ToCurrCode = stringUtil.IsNull(
                ToCurrCode,
                this.highString.HighStringFn("CurrCodeType"));
            FromCustNum = stringUtil.IsNull(
                FromCustNum,
                this.lowString.LowStringFn("CustNumType"));
            ToCustNum = stringUtil.IsNull(
                ToCustNum,
                this.highString.HighStringFn("CustNumType"));
            FromCustType = stringUtil.IsNull(
                FromCustType,
                this.lowString.LowStringFn("CustTypeType"));
            ToCustType = stringUtil.IsNull(
                ToCustType,
                this.highString.HighStringFn("CustTypeType"));
            FromEndUserType = stringUtil.IsNull(
                FromEndUserType,
                this.lowString.LowStringFn("EndUserTypeType"));
            ToEndUserType = stringUtil.IsNull(
                ToEndUserType,
                this.highString.HighStringFn("EndUserTypeType"));
            FromDueDate = convertToUtil.ToDateTime(stringUtil.IsNull(
                FromDueDate,
                this.iLowDate.LowDateFn()));
            ToDueDate = convertToUtil.ToDateTime(stringUtil.IsNull(
                ToDueDate,
                this.iHighDate.HighDateFn()));
            NewEffectDate = convertToUtil.ToDateTime(stringUtil.IsNull(
                NewEffectDate,
                this.iMidnightOf.MidnightOfFn(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE")))));

            #region CRUD LoadToVariable
            var tax_systemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_Wholesale1,"tax_system.wholesale_price"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "tax_system",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("tax_system = 1"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tax_systemLoadResponse = this.appDB.Load(tax_systemLoadRequest);
            if (tax_systemLoadResponse.Items.Count > 0)
            {
                Wholesale1 = _Wholesale1;
            }
            #endregion  LoadToVariable

            #region CRUD LoadToVariable
            var tax_system1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_Wholesale2,"tax_system.wholesale_price"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "tax_system",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("tax_system = 2"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tax_system1LoadResponse = this.appDB.Load(tax_system1LoadRequest);
            if (tax_system1LoadResponse.Items.Count > 0)
            {
                Wholesale2 = _Wholesale2;
            }
            #endregion  LoadToVariable

            if ((sQLUtil.SQLEqual(Wholesale1, 1) == true || sQLUtil.SQLEqual(Wholesale2, 1) == true) && PriWhole != null)
            {
                WholesaleChange = PriWhole;

            }
            else
            {
                WholesaleChange = "P";

            }
            if (PriAmt == null)
            {
                PriAmt = 0;

            }
            if (sQLUtil.SQLEqual(PriceType, "I") == true)
            {
                //BEGIN
                if (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                        WholesaleChange,
                        "WB"), 0) == true && sQLUtil.SQLEqual(UpdateCreate, 1) == true)
                {
                    //BEGIN

                    #region CRUD LoadToRecord
                    var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"u_ws_price","item.u_ws_price"},
                        }, 
                        loadForChange: true, 
                        lockingType: LockingType.UPDLock,
                        tableName: "item",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("item.item BETWEEN {3} AND {4} AND ((item.product_code BETWEEN {0} AND {1}) OR ({2} = 1 AND item.product_code IS NULL))", FromProductCode, ToProductCode, ProductNull, FromItem, ToItem),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var itemLoadResponse = this.appDB.Load(itemLoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD UpdateByRecord
                    foreach (var itemItem in itemLoadResponse.Items)
                    {
                        itemItem.SetValue<decimal?>("u_ws_price", ((sQLUtil.SQLEqual(AmtType, "A") == true ? stringUtil.IsNull<decimal?>(
                            itemItem.GetDeletedValue<decimal?>("u_ws_price"),
                            0) + PriAmt : stringUtil.IsNull<decimal?>(
                            itemItem.GetDeletedValue<decimal?>("u_ws_price"),
                            0) + (stringUtil.IsNull<decimal?>(
                            itemItem.GetDeletedValue<decimal?>("u_ws_price"),
                            0) * PriAmt / 100M))));
                    };

                    var itemRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "item",
                        items: itemLoadResponse.Items);

                    this.appDB.Update(itemRequestUpdate);
                    #endregion UpdateByRecord

                    Counter = (int?)(Counter + itemLoadResponse.Items.Count);
                    //END

                }
                if (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                        WholesaleChange,
                        "PB"), 0) == true && (sQLUtil.SQLEqual(ItmPrc1, 1) == true || sQLUtil.SQLEqual(ItmPrc2, 1) == true || sQLUtil.SQLEqual(ItmPrc3, 1) == true || sQLUtil.SQLEqual(ItmPrc4, 1) == true || sQLUtil.SQLEqual(ItmPrc5, 1) == true || sQLUtil.SQLEqual(ItmPrc6, 1) == true))
                {
                    //BEGIN
                    #region Cursor Statement

                    #region CRUD LoadToRecord
                    itempricecurLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"itp.item","itp.item"},
                            {"itp.curr_code","itp.curr_code"},
                            {"itp.RowPointer","itp.RowPointer"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "itemprice",
                        fromClause: collectionLoadRequestFactory.Clause(" AS itp INNER JOIN item AS itm WITH (READUNCOMMITTED) ON itm.item = itp.item"),
                        whereClause: collectionLoadRequestFactory.Clause("itp.item BETWEEN {11} AND {13} AND ((itm.product_code BETWEEN {0} AND {2}) OR ({8} = 1 AND itm.product_code IS NULL)) AND itp.effect_date BETWEEN {1} AND {5} AND ((itp.pricecode BETWEEN {3} AND {9}) OR ({4} = 1 AND itp.pricecode IS NULL)) AND 1 = (CASE WHEN {12} = 'P' THEN (CASE WHEN itp.curr_code BETWEEN {6} AND {10} THEN 1 ELSE 0 END) ELSE 1 END) AND 1 = (CASE WHEN {12} = 'A' THEN (CASE WHEN isnull(itp.curr_code, char(1)) = (CASE WHEN {6} = '' THEN isnull(itp.curr_code, char(1)) ELSE {6} END) THEN 1 ELSE 0 END) ELSE 1 END) AND itp.RowPointer = (CASE WHEN {7} = 1 THEN itp.RowPointer ELSE (SELECT TOP 1 RowPointer FROM itemprice WHERE item = itp.item AND curr_code = itp.curr_code ORDER BY effect_date DESC) END)", FromProductCode, FromEffectDate, ToProductCode, FromPriceCode, PriceCodeNull, ToEffectDate, FromCurrCode, UpdateCreate, ProductNull, ToPriceCode, ToCurrCode, FromItem, AmtType, ToItem),
                        orderByClause: collectionLoadRequestFactory.Clause(" itp.item ASC"));
                    #endregion  LoadToRecord

                    #endregion Cursor Statement
                    itempricecurLoadResponseForCursor = this.appDB.Load(itempricecurLoadRequestForCursor);
                    itempricecur_CursorFetch_Status = itempricecurLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                    itempricecur_CursorCounter = -1;

                    while (sQLUtil.SQLEqual(Severity, 0) == true)
                    {
                        //BEGIN
                        itempricecur_CursorCounter++;
                        if (itempricecurLoadResponseForCursor.Items.Count > itempricecur_CursorCounter)
                        {
                            item = itempricecurLoadResponseForCursor.Items[itempricecur_CursorCounter].GetValue<string>(0);
                            CurrCode = itempricecurLoadResponseForCursor.Items[itempricecur_CursorCounter].GetValue<string>(1);
                            vRowPointer = itempricecurLoadResponseForCursor.Items[itempricecur_CursorCounter].GetValue<Guid?>(2);
                        }
                        itempricecur_CursorFetch_Status = (itempricecur_CursorCounter == itempricecurLoadResponseForCursor.Items.Count ? -1 : 0);

                        if (sQLUtil.SQLEqual(itempricecur_CursorFetch_Status, -1) == true)
                        {

                            break;

                        }
                        if (sQLUtil.SQLEqual(UpdateCreate, 0) == true)
                        {
                            if (existsChecker.Exists(tableName: "itemprice",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("item = {2} AND curr_code = {1} AND effect_date = {0}", NewEffectDate, CurrCode, item))
                            )
                            {
                                //BEGIN

                                #region CRUD LoadToVariable
                                var tmp_MessageBufferLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_NextSeq,"max(sequence) + 1"},
                                    },
                                    loadForChange: false, 
                                    lockingType: LockingType.None,
                                    tableName: "tmp_MessageBuffer",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("SessionID = {0}", SessionID),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var tmp_MessageBufferLoadResponse = this.appDB.Load(tmp_MessageBufferLoadRequest);
                                if (tmp_MessageBufferLoadResponse.Items.Count > 0)
                                {
                                    NextSeq = _NextSeq;
                                }
                                #endregion  LoadToVariable

                                NextSeq = (int?)(stringUtil.IsNull(
                                    NextSeq,
                                    0));
                                Infobar = null;

                                #region CRUD ExecuteMethodCall

                                var MsgApp = this.iMsgApp.MsgAppSp(
                                    Infobar: Infobar,
                                    BaseMsg: "E=AlreadyExists3",
                                    Parm1: "@itemprice.item",
                                    Parm2: item,
                                    Parm3: "@currency",
                                    Parm4: CurrCode,
                                    Parm5: "@itemcustprice.effect_date",
                                    Parm6: convertToUtil.ToString(NewEffectDate));
                                Infobar = MsgApp.Infobar;

                                #endregion ExecuteMethodCall

                                #region CRUD LoadResponseWithoutTable
                                var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                {
                                        { "SessionID", SessionID},
                                        { "sequence", NextSeq},
                                        { "MessageText", Infobar},
                                });

                                var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                                #endregion CRUD LoadResponseWithoutTable

                                #region CRUD InsertByRecords
                                var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "tmp_MessageBuffer",
                                    items: nonTableLoadResponse.Items);

                                this.appDB.Insert(nonTableInsertRequest);
                                #endregion InsertByRecords

                                continue;
                                //END

                            }
                            else
                            {
                                //BEGIN

                                #region CRUD LoadToRecord
                                var itemprice2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                    {
                                        {"item","itemprice.item"},
                                        {"effect_date","CAST (NULL AS DATETIME)"},
                                        {"curr_code","itemprice.curr_code"},
                                        {"unit_price1","CAST (NULL AS DECIMAL)"},
                                        {"unit_price2","CAST (NULL AS DECIMAL)"},
                                        {"unit_price3","CAST (NULL AS DECIMAL)"},
                                        {"unit_price4","CAST (NULL AS DECIMAL)"},
                                        {"unit_price5","CAST (NULL AS DECIMAL)"},
                                        {"unit_price6","CAST (NULL AS DECIMAL)"},
                                        {"reprice","itemprice.reprice"},
                                        {"brk_qty##1","itemprice.brk_qty##1"},
                                        {"brk_qty##2","itemprice.brk_qty##2"},
                                        {"brk_qty##3","itemprice.brk_qty##3"},
                                        {"brk_qty##4","itemprice.brk_qty##4"},
                                        {"brk_qty##5","itemprice.brk_qty##5"},
                                        {"brk_price##1","itemprice.brk_price##1"},
                                        {"brk_price##2","itemprice.brk_price##2"},
                                        {"brk_price##3","itemprice.brk_price##3"},
                                        {"brk_price##4","itemprice.brk_price##4"},
                                        {"brk_price##5","itemprice.brk_price##5"},
                                        {"base_code##1","itemprice.base_code##1"},
                                        {"base_code##2","itemprice.base_code##2"},
                                        {"base_code##3","itemprice.base_code##3"},
                                        {"base_code##4","itemprice.base_code##4"},
                                        {"base_code##5","itemprice.base_code##5"},
                                        {"dol_percent##1","itemprice.dol_percent##1"},
                                        {"dol_percent##2","itemprice.dol_percent##2"},
                                        {"dol_percent##3","itemprice.dol_percent##3"},
                                        {"dol_percent##4","itemprice.dol_percent##4"},
                                        {"dol_percent##5","itemprice.dol_percent##5"},
                                        {"pricecode","itemprice.pricecode"},
                                        {"u0","itemprice.unit_price1"},
                                        {"u1","itemprice.unit_price2"},
                                        {"u2","itemprice.unit_price3"},
                                        {"u3","itemprice.unit_price4"},
                                        {"u4","itemprice.unit_price5"},
                                        {"u5","itemprice.unit_price6"},
                                    },
                                    loadForChange: false, 
                                    lockingType: LockingType.None,
                                    tableName: "itemprice",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("itemprice.rowpointer = {0}", vRowPointer),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var itemprice2LoadResponse = this.appDB.Load(itemprice2LoadRequest);
                                #endregion  LoadToRecord

                                #region CRUD InsertByRecords
                                foreach (var itemprice2Item in itemprice2LoadResponse.Items)
                                {
                                    itemprice2Item.SetValue<string>("item", itemprice2Item.GetValue<string>("item"));
                                    itemprice2Item.SetValue<DateTime?>("effect_date", NewEffectDate);
                                    itemprice2Item.SetValue<string>("curr_code", itemprice2Item.GetValue<string>("curr_code"));
                                    itemprice2Item.SetValue<decimal?>("unit_price1", ((sQLUtil.SQLEqual(ItmPrc1, 1) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice2Item.GetValue<decimal?>("u0") + PriAmt : itemprice2Item.GetValue<decimal?>("u0") + (itemprice2Item.GetValue<decimal?>("u0") * PriAmt / 100M))) : itemprice2Item.GetValue<decimal?>("u0"))));
                                    itemprice2Item.SetValue<decimal?>("unit_price2", ((sQLUtil.SQLEqual(ItmPrc2, 1) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice2Item.GetValue<decimal?>("u1") + PriAmt : itemprice2Item.GetValue<decimal?>("u1") + (itemprice2Item.GetValue<decimal?>("u1") * PriAmt / 100M))) : itemprice2Item.GetValue<decimal?>("u1"))));
                                    itemprice2Item.SetValue<decimal?>("unit_price3", ((sQLUtil.SQLEqual(ItmPrc3, 1) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice2Item.GetValue<decimal?>("u2") + PriAmt : itemprice2Item.GetValue<decimal?>("u2") + (itemprice2Item.GetValue<decimal?>("u2") * PriAmt / 100M))) : itemprice2Item.GetValue<decimal?>("u2"))));
                                    itemprice2Item.SetValue<decimal?>("unit_price4", ((sQLUtil.SQLEqual(ItmPrc4, 1) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice2Item.GetValue<decimal?>("u3") + PriAmt : itemprice2Item.GetValue<decimal?>("u3") + (itemprice2Item.GetValue<decimal?>("u3") * PriAmt / 100M))) : itemprice2Item.GetValue<decimal?>("u3"))));
                                    itemprice2Item.SetValue<decimal?>("unit_price5", ((sQLUtil.SQLEqual(ItmPrc5, 1) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice2Item.GetValue<decimal?>("u4") + PriAmt : itemprice2Item.GetValue<decimal?>("u4") + (itemprice2Item.GetValue<decimal?>("u4") * PriAmt / 100M))) : itemprice2Item.GetValue<decimal?>("u4"))));
                                    itemprice2Item.SetValue<decimal?>("unit_price6", ((sQLUtil.SQLEqual(ItmPrc6, 1) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice2Item.GetValue<decimal?>("u5") + PriAmt : itemprice2Item.GetValue<decimal?>("u5") + (itemprice2Item.GetValue<decimal?>("u5") * PriAmt / 100M))) : itemprice2Item.GetValue<decimal?>("u5"))));
                                    itemprice2Item.SetValue<int?>("reprice", itemprice2Item.GetValue<int?>("reprice"));
                                    itemprice2Item.SetValue<decimal?>("brk_qty##1", itemprice2Item.GetValue<decimal?>("brk_qty##1"));
                                    itemprice2Item.SetValue<decimal?>("brk_qty##2", itemprice2Item.GetValue<decimal?>("brk_qty##2"));
                                    itemprice2Item.SetValue<decimal?>("brk_qty##3", itemprice2Item.GetValue<decimal?>("brk_qty##3"));
                                    itemprice2Item.SetValue<decimal?>("brk_qty##4", itemprice2Item.GetValue<decimal?>("brk_qty##4"));
                                    itemprice2Item.SetValue<decimal?>("brk_qty##5", itemprice2Item.GetValue<decimal?>("brk_qty##5"));
                                    itemprice2Item.SetValue<decimal?>("brk_price##1", itemprice2Item.GetValue<decimal?>("brk_price##1"));
                                    itemprice2Item.SetValue<decimal?>("brk_price##2", itemprice2Item.GetValue<decimal?>("brk_price##2"));
                                    itemprice2Item.SetValue<decimal?>("brk_price##3", itemprice2Item.GetValue<decimal?>("brk_price##3"));
                                    itemprice2Item.SetValue<decimal?>("brk_price##4", itemprice2Item.GetValue<decimal?>("brk_price##4"));
                                    itemprice2Item.SetValue<decimal?>("brk_price##5", itemprice2Item.GetValue<decimal?>("brk_price##5"));
                                    itemprice2Item.SetValue<string>("base_code##1", itemprice2Item.GetValue<string>("base_code##1"));
                                    itemprice2Item.SetValue<string>("base_code##2", itemprice2Item.GetValue<string>("base_code##2"));
                                    itemprice2Item.SetValue<string>("base_code##3", itemprice2Item.GetValue<string>("base_code##3"));
                                    itemprice2Item.SetValue<string>("base_code##4", itemprice2Item.GetValue<string>("base_code##4"));
                                    itemprice2Item.SetValue<string>("base_code##5", itemprice2Item.GetValue<string>("base_code##5"));
                                    itemprice2Item.SetValue<string>("dol_percent##1", itemprice2Item.GetValue<string>("dol_percent##1"));
                                    itemprice2Item.SetValue<string>("dol_percent##2", itemprice2Item.GetValue<string>("dol_percent##2"));
                                    itemprice2Item.SetValue<string>("dol_percent##3", itemprice2Item.GetValue<string>("dol_percent##3"));
                                    itemprice2Item.SetValue<string>("dol_percent##4", itemprice2Item.GetValue<string>("dol_percent##4"));
                                    itemprice2Item.SetValue<string>("dol_percent##5", itemprice2Item.GetValue<string>("dol_percent##5"));
                                    itemprice2Item.SetValue<string>("pricecode", itemprice2Item.GetValue<string>("pricecode"));
                                };

                                var itemprice2RequiredColumns = new List<string>() { "item", "effect_date", "curr_code", "unit_price1", "unit_price2", "unit_price3", "unit_price4", "unit_price5", "unit_price6", "reprice", "brk_qty##1", "brk_qty##2", "brk_qty##3", "brk_qty##4", "brk_qty##5", "brk_price##1", "brk_price##2", "brk_price##3", "brk_price##4", "brk_price##5", "base_code##1", "base_code##2", "base_code##3", "base_code##4", "base_code##5", "dol_percent##1", "dol_percent##2", "dol_percent##3", "dol_percent##4", "dol_percent##5", "pricecode" };

                                itemprice2LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(itemprice2LoadResponse, itemprice2RequiredColumns);

                                var itemprice2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "itemprice",
                                    items: itemprice2LoadResponse.Items);

                                this.appDB.Insert(itemprice2InsertRequest);
                                #endregion InsertByRecords

                                Counter = (int?)(Counter + 1);
                                //END

                            }

                        }
                        else
                        {
                            //BEGIN

                            #region CRUD LoadToVariable
                            var itemprice3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                {
                                    {_itmRePrc,"reprice"},
                                },
                                loadForChange: false, 
                                lockingType: LockingType.None,
                                tableName: "itemprice",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("rowpointer = {0}", vRowPointer),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var itemprice3LoadResponse = this.appDB.Load(itemprice3LoadRequest);
                            if (itemprice3LoadResponse.Items.Count > 0)
                            {
                                itmRePrc = _itmRePrc;
                            }
                            #endregion  LoadToVariable

                            if ((sQLUtil.SQLEqual(ItmPrc1, 1) == true && sQLUtil.SQLEqual(itmRePrc, 0) == true) || (sQLUtil.SQLEqual(ItmPrc2, 1) == true || sQLUtil.SQLEqual(ItmPrc3, 1) == true || sQLUtil.SQLEqual(ItmPrc4, 1) == true || sQLUtil.SQLEqual(ItmPrc5, 1) == true || sQLUtil.SQLEqual(ItmPrc6, 1) == true))
                            {
                                //BEGIN

                                #region CRUD LoadToRecord
                                var itemprice4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                    {
                                        {"unit_price1","itemprice.unit_price1"},
                                        {"unit_price2","itemprice.unit_price2"},
                                        {"unit_price3","itemprice.unit_price3"},
                                        {"unit_price4","itemprice.unit_price4"},
                                        {"unit_price5","itemprice.unit_price5"},
                                        {"unit_price6","itemprice.unit_price6"},
                                    }, 
                                    loadForChange: true, 
                                    lockingType: LockingType.UPDLock,
                                    tableName: "itemprice",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("itemprice.rowpointer = {0}", vRowPointer),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var itemprice4LoadResponse = this.appDB.Load(itemprice4LoadRequest);
                                #endregion  LoadToRecord

                                #region CRUD UpdateByRecord
                                foreach (var itemprice4Item in itemprice4LoadResponse.Items)
                                {
                                    itemprice4Item.SetValue<decimal?>("unit_price1", ((sQLUtil.SQLEqual(ItmPrc1, 1) == true && sQLUtil.SQLEqual(itmRePrc, 0) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice4Item.GetDeletedValue<decimal?>("unit_price1") + PriAmt : itemprice4Item.GetDeletedValue<decimal?>("unit_price1") + (itemprice4Item.GetDeletedValue<decimal?>("unit_price1") * PriAmt / 100M))) : itemprice4Item.GetDeletedValue<decimal?>("unit_price1"))));
                                    itemprice4Item.SetValue<decimal?>("unit_price2", ((sQLUtil.SQLEqual(ItmPrc2, 1) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice4Item.GetDeletedValue<decimal?>("unit_price2") + PriAmt : itemprice4Item.GetDeletedValue<decimal?>("unit_price2") + (itemprice4Item.GetDeletedValue<decimal?>("unit_price2") * PriAmt / 100M))) : itemprice4Item.GetDeletedValue<decimal?>("unit_price2"))));
                                    itemprice4Item.SetValue<decimal?>("unit_price3", ((sQLUtil.SQLEqual(ItmPrc3, 1) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice4Item.GetDeletedValue<decimal?>("unit_price3") + PriAmt : itemprice4Item.GetDeletedValue<decimal?>("unit_price3") + (itemprice4Item.GetDeletedValue<decimal?>("unit_price3") * PriAmt / 100M))) : itemprice4Item.GetDeletedValue<decimal?>("unit_price3"))));
                                    itemprice4Item.SetValue<decimal?>("unit_price4", ((sQLUtil.SQLEqual(ItmPrc4, 1) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice4Item.GetDeletedValue<decimal?>("unit_price4") + PriAmt : itemprice4Item.GetDeletedValue<decimal?>("unit_price4") + (itemprice4Item.GetDeletedValue<decimal?>("unit_price4") * PriAmt / 100M))) : itemprice4Item.GetDeletedValue<decimal?>("unit_price4"))));
                                    itemprice4Item.SetValue<decimal?>("unit_price5", ((sQLUtil.SQLEqual(ItmPrc5, 1) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice4Item.GetDeletedValue<decimal?>("unit_price5") + PriAmt : itemprice4Item.GetDeletedValue<decimal?>("unit_price5") + (itemprice4Item.GetDeletedValue<decimal?>("unit_price5") * PriAmt / 100M))) : itemprice4Item.GetDeletedValue<decimal?>("unit_price5"))));
                                    itemprice4Item.SetValue<decimal?>("unit_price6", ((sQLUtil.SQLEqual(ItmPrc6, 1) == true ? ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemprice4Item.GetDeletedValue<decimal?>("unit_price6") + PriAmt : itemprice4Item.GetDeletedValue<decimal?>("unit_price6") + (itemprice4Item.GetDeletedValue<decimal?>("unit_price6") * PriAmt / 100M))) : itemprice4Item.GetDeletedValue<decimal?>("unit_price6"))));
                                };

                                var itemprice4RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "itemprice",
                                    items: itemprice4LoadResponse.Items);

                                this.appDB.Update(itemprice4RequestUpdate);
                                #endregion UpdateByRecord

                                if (sQLUtil.SQLGreaterThan(itemprice4LoadResponse.Items.Count, 0) == true)
                                {
                                    Counter = (int?)(Counter + 1);

                                }
                                //END

                            }
                            //END

                        }
                        //END

                    }
                    //Deallocate Cursor itempricecur
                    //END

                }
                //END

            }
            else
            {
                if (sQLUtil.SQLEqual(PriceType, "C") == true)
                {
                    //BEGIN
                    #region Cursor Statement

                    #region CRUD LoadToRecord
                    itempricecurLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"itc.item","itc.item"},
                            {"itc.cust_num","itc.cust_num"},
                            {"itc.cust_item_seq","itc.cust_item_seq"},
                            {"itc.RowPointer","itc.RowPointer"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "itemcustprice",
                        fromClause: collectionLoadRequestFactory.Clause(@" AS itc INNER JOIN item AS it ON it.item = itc.item INNER JOIN customer AS cust WITH (READUNCOMMITTED) ON cust.cust_num = itc.cust_num
							AND cust.cust_seq = 0 INNER JOIN custaddr AS custadr WITH (READUNCOMMITTED) ON custadr.cust_num = itc.cust_num
							AND custadr.cust_seq = 0"),
                        whereClause: collectionLoadRequestFactory.Clause("itc.item BETWEEN {16} AND {18} AND ((it.product_code BETWEEN {0} AND {4}) OR ({11} = 1 AND it.product_code IS NULL)) AND itc.effect_date BETWEEN {3} AND {6} AND itc.cust_num BETWEEN {12} AND {15} AND ((cust.cust_type BETWEEN {7} AND {13}) OR ({8} = 1 AND cust.cust_type IS NULL)) AND ((cust.end_user_type BETWEEN {1} AND {5}) OR ({2} = 1 AND cust.end_user_type IS NULL)) AND 1 = (CASE WHEN {17} = 'P' THEN (CASE WHEN custadr.curr_code BETWEEN {9} AND {14} THEN 1 ELSE 0 END) ELSE 1 END) AND 1 = (CASE WHEN {17} = 'A' THEN (CASE WHEN isnull(custadr.curr_code, char(1)) = (CASE WHEN {9} = '' THEN isnull(custadr.curr_code, char(1)) ELSE {9} END) THEN 1 ELSE 0 END) ELSE 1 END) AND itc.RowPointer = (CASE WHEN {10} = 1 THEN itc.RowPointer ELSE (SELECT TOP 1 itmcustprice.RowPointer FROM itemcustprice AS itmcustprice INNER JOIN custaddr AS cstadr WITH (READUNCOMMITTED) ON cstadr.cust_num = itmcustprice.cust_num AND cstadr.cust_seq = 0 WHERE itmcustprice.item = itc.item AND itmcustprice.cust_num = itc.cust_num AND cstadr.curr_code = custadr.curr_code AND cstadr.cust_seq = 0 ORDER BY effect_date DESC) END)", FromProductCode, FromEndUserType, EndUserTypeNULL, FromEffectDate, ToProductCode, ToEndUserType, ToEffectDate, FromCustType, CustTypeNULL, FromCurrCode, UpdateCreate, ProductNull, FromCustNum, ToCustType, ToCurrCode, ToCustNum, FromItem, AmtType, ToItem),
                        orderByClause: collectionLoadRequestFactory.Clause(" itc.cust_num, itc.item"));
                    #endregion  LoadToRecord

                    #endregion Cursor Statement
                    itempricecurLoadResponseForCursor = this.appDB.Load(itempricecurLoadRequestForCursor);
                    itempricecur_CursorFetch_Status = itempricecurLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                    itempricecur_CursorCounter = -1;

                    while (sQLUtil.SQLEqual(Severity, 0) == true)
                    {
                        //BEGIN
                        itempricecur_CursorCounter++;
                        if (itempricecurLoadResponseForCursor.Items.Count > itempricecur_CursorCounter)
                        {
                            item = itempricecurLoadResponseForCursor.Items[itempricecur_CursorCounter].GetValue<string>(0);
                            CustNum = itempricecurLoadResponseForCursor.Items[itempricecur_CursorCounter].GetValue<string>(1);
                            CustItemSeq = itempricecurLoadResponseForCursor.Items[itempricecur_CursorCounter].GetValue<int?>(2);
                            vRowPointer = itempricecurLoadResponseForCursor.Items[itempricecur_CursorCounter].GetValue<Guid?>(3);
                        }
                        itempricecur_CursorFetch_Status = (itempricecur_CursorCounter == itempricecurLoadResponseForCursor.Items.Count ? -1 : 0);

                        if (sQLUtil.SQLEqual(itempricecur_CursorFetch_Status, -1) == true)
                        {

                            break;

                        }
                        if (sQLUtil.SQLEqual(UpdateCreate, 0) == true)
                        {
                            if (existsChecker.Exists(tableName: "itemcustprice",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("item = {2} AND cust_num = {1} AND effect_Date = {0}", NewEffectDate, CustNum, item))
                            || existsChecker.Exists(tableName: "itemcustprice",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("item = {3} AND cust_num = {2} AND cust_item_seq = {1} AND effect_date = {0}", NewEffectDate, CustItemSeq, CustNum, item))
                            )
                            {
                                //BEGIN

                                #region CRUD LoadToVariable
                                var tmp_MessageBuffer1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_NextSeq,"max(sequence) + 1"},
                                    },
                                    loadForChange: false, 
                                    lockingType: LockingType.None,
                                    tableName: "tmp_MessageBuffer",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("SessionID = {0}", SessionID),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var tmp_MessageBuffer1LoadResponse = this.appDB.Load(tmp_MessageBuffer1LoadRequest);
                                if (tmp_MessageBuffer1LoadResponse.Items.Count > 0)
                                {
                                    NextSeq = _NextSeq;
                                }
                                #endregion  LoadToVariable

                                NextSeq = (int?)(stringUtil.IsNull(
                                    NextSeq,
                                    0));
                                Infobar = null;

                                #region CRUD ExecuteMethodCall

                                var MsgApp1 = this.iMsgApp.MsgAppSp(
                                    Infobar: Infobar,
                                    BaseMsg: "E=AlreadyExists4",
                                    Parm1: "@itemcustprice.cust_num",
                                    Parm2: CustNum,
                                    Parm3: "@itemcustprice.cust_item_seq",
                                    Parm4: convertToUtil.ToString(CustItemSeq),
                                    Parm5: "@itemcustprice.item",
                                    Parm6: item,
                                    Parm7: "@itemcustprice.effect_date",
                                    Parm8: convertToUtil.ToString(NewEffectDate));
                                Infobar = MsgApp1.Infobar;

                                #endregion ExecuteMethodCall

                                #region CRUD LoadResponseWithoutTable
                                var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                {
                                        { "SessionID", SessionID},
                                        { "sequence", NextSeq},
                                        { "MessageText", Infobar},
                                });

                                var nonTable1LoadResponse = this.appDB.Load(nonTable1LoadRequest);
                                #endregion CRUD LoadResponseWithoutTable

                                #region CRUD InsertByRecords
                                var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "tmp_MessageBuffer",
                                    items: nonTable1LoadResponse.Items);

                                this.appDB.Insert(nonTable1InsertRequest);
                                #endregion InsertByRecords

                                continue;
                                //END

                            }
                            else
                            {

                                #region CRUD LoadToRecord
                                var itemcustprice3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                    {
                                        {"item","itemcustprice.item"},
                                        {"cust_num","itemcustprice.cust_num"},
                                        {"cont_price","CAST (NULL AS DECIMAL)"},
                                        {"effect_date","CAST (NULL AS DATETIME)"},
                                        {"brk_qty##1","itemcustprice.brk_qty##1"},
                                        {"brk_qty##2","itemcustprice.brk_qty##2"},
                                        {"brk_qty##3","itemcustprice.brk_qty##3"},
                                        {"brk_qty##4","itemcustprice.brk_qty##4"},
                                        {"brk_qty##5","itemcustprice.brk_qty##5"},
                                        {"brk_price##1","itemcustprice.brk_price##1"},
                                        {"brk_price##2","itemcustprice.brk_price##2"},
                                        {"brk_price##3","itemcustprice.brk_price##3"},
                                        {"brk_price##4","itemcustprice.brk_price##4"},
                                        {"brk_price##5","itemcustprice.brk_price##5"},
                                        {"base_code##1","itemcustprice.base_code##1"},
                                        {"base_code##2","itemcustprice.base_code##2"},
                                        {"base_code##3","itemcustprice.base_code##3"},
                                        {"base_code##4","itemcustprice.base_code##4"},
                                        {"base_code##5","itemcustprice.base_code##5"},
                                        {"dol_percent##1","itemcustprice.dol_percent##1"},
                                        {"dol_percent##2","itemcustprice.dol_percent##2"},
                                        {"dol_percent##3","itemcustprice.dol_percent##3"},
                                        {"dol_percent##4","itemcustprice.dol_percent##4"},
                                        {"dol_percent##5","itemcustprice.dol_percent##5"},
                                        {"cust_item_seq","CAST (NULL AS INT)"},
                                        {"u0","itemcustprice.cont_price"},
                                    },
                                    loadForChange: false,
                                    lockingType: LockingType.None,
                                    tableName: "itemcustprice",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("itemcustprice.rowpointer = {0}", vRowPointer),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var itemcustprice3LoadResponse = this.appDB.Load(itemcustprice3LoadRequest);
                                #endregion  LoadToRecord

                                #region CRUD InsertByRecords
                                foreach (var itemcustprice3Item in itemcustprice3LoadResponse.Items)
                                {
                                    itemcustprice3Item.SetValue<string>("item", itemcustprice3Item.GetValue<string>("item"));
                                    itemcustprice3Item.SetValue<string>("cust_num", itemcustprice3Item.GetValue<string>("cust_num"));
                                    itemcustprice3Item.SetValue<decimal?>("cont_price", ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemcustprice3Item.GetValue<decimal?>("u0") + PriAmt : itemcustprice3Item.GetValue<decimal?>("u0") + (itemcustprice3Item.GetValue<decimal?>("u0") * PriAmt / 100M))));
                                    itemcustprice3Item.SetValue<DateTime?>("effect_date", NewEffectDate);
                                    itemcustprice3Item.SetValue<decimal?>("brk_qty##1", itemcustprice3Item.GetValue<decimal?>("brk_qty##1"));
                                    itemcustprice3Item.SetValue<decimal?>("brk_qty##2", itemcustprice3Item.GetValue<decimal?>("brk_qty##2"));
                                    itemcustprice3Item.SetValue<decimal?>("brk_qty##3", itemcustprice3Item.GetValue<decimal?>("brk_qty##3"));
                                    itemcustprice3Item.SetValue<decimal?>("brk_qty##4", itemcustprice3Item.GetValue<decimal?>("brk_qty##4"));
                                    itemcustprice3Item.SetValue<decimal?>("brk_qty##5", itemcustprice3Item.GetValue<decimal?>("brk_qty##5"));
                                    itemcustprice3Item.SetValue<decimal?>("brk_price##1", itemcustprice3Item.GetValue<decimal?>("brk_price##1"));
                                    itemcustprice3Item.SetValue<decimal?>("brk_price##2", itemcustprice3Item.GetValue<decimal?>("brk_price##2"));
                                    itemcustprice3Item.SetValue<decimal?>("brk_price##3", itemcustprice3Item.GetValue<decimal?>("brk_price##3"));
                                    itemcustprice3Item.SetValue<decimal?>("brk_price##4", itemcustprice3Item.GetValue<decimal?>("brk_price##4"));
                                    itemcustprice3Item.SetValue<decimal?>("brk_price##5", itemcustprice3Item.GetValue<decimal?>("brk_price##5"));
                                    itemcustprice3Item.SetValue<string>("base_code##1", itemcustprice3Item.GetValue<string>("base_code##1"));
                                    itemcustprice3Item.SetValue<string>("base_code##2", itemcustprice3Item.GetValue<string>("base_code##2"));
                                    itemcustprice3Item.SetValue<string>("base_code##3", itemcustprice3Item.GetValue<string>("base_code##3"));
                                    itemcustprice3Item.SetValue<string>("base_code##4", itemcustprice3Item.GetValue<string>("base_code##4"));
                                    itemcustprice3Item.SetValue<string>("base_code##5", itemcustprice3Item.GetValue<string>("base_code##5"));
                                    itemcustprice3Item.SetValue<string>("dol_percent##1", itemcustprice3Item.GetValue<string>("dol_percent##1"));
                                    itemcustprice3Item.SetValue<string>("dol_percent##2", itemcustprice3Item.GetValue<string>("dol_percent##2"));
                                    itemcustprice3Item.SetValue<string>("dol_percent##3", itemcustprice3Item.GetValue<string>("dol_percent##3"));
                                    itemcustprice3Item.SetValue<string>("dol_percent##4", itemcustprice3Item.GetValue<string>("dol_percent##4"));
                                    itemcustprice3Item.SetValue<string>("dol_percent##5", itemcustprice3Item.GetValue<string>("dol_percent##5"));
                                    itemcustprice3Item.SetValue<int?>("cust_item_seq", CustItemSeq);
                                };

                                var itemcustprice3RequiredColumns = new List<string>() { "item", "cust_num", "cont_price", "effect_date", "brk_qty##1", "brk_qty##2", "brk_qty##3", "brk_qty##4", "brk_qty##5", "brk_price##1", "brk_price##2", "brk_price##3", "brk_price##4", "brk_price##5", "base_code##1", "base_code##2", "base_code##3", "base_code##4", "base_code##5", "dol_percent##1", "dol_percent##2", "dol_percent##3", "dol_percent##4", "dol_percent##5", "cust_item_seq" };

                                itemcustprice3LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(itemcustprice3LoadResponse, itemcustprice3RequiredColumns);

                                var itemcustprice3InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "itemcustprice",
                                    items: itemcustprice3LoadResponse.Items);

                                this.appDB.Insert(itemcustprice3InsertRequest);
                                #endregion InsertByRecords

                            }

                        }
                        else
                        {

                            #region CRUD LoadToRecord
                            var itemcustprice4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                {
                                    {"cont_price","itemcustprice.cont_price"},
                                }, 
                                loadForChange: true, 
                                lockingType: LockingType.UPDLock,
                                tableName: "itemcustprice",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("itemcustprice.rowpointer = {0}", vRowPointer),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var itemcustprice4LoadResponse = this.appDB.Load(itemcustprice4LoadRequest);
                            #endregion  LoadToRecord

                            #region CRUD UpdateByRecord
                            foreach (var itemcustprice4Item in itemcustprice4LoadResponse.Items)
                            {
                                itemcustprice4Item.SetValue<decimal?>("cont_price", ((sQLUtil.SQLEqual(AmtType, "A") == true ? itemcustprice4Item.GetDeletedValue<decimal?>("cont_price") + PriAmt : itemcustprice4Item.GetDeletedValue<decimal?>("cont_price") + (itemcustprice4Item.GetDeletedValue<decimal?>("cont_price") * PriAmt / 100M))));
                            };

                            var itemcustprice4RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "itemcustprice",
                                items: itemcustprice4LoadResponse.Items);

                            this.appDB.Update(itemcustprice4RequestUpdate);
                            #endregion UpdateByRecord

                        }
                        Counter = (int?)(Counter + 1);
                        //END

                    }
                    //Deallocate Cursor itempricecur
                    //END

                }
                else
                {
                    if (sQLUtil.SQLEqual(PriceType, "O") == true)
                    {
                        //BEGIN

                        #region CRUD LoadToRecord
                        var coitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                            {
                                {"price","coi.price"},
                                {"price_conv","coi.price_conv"},
                                {"u0","coi.qty_ordered"},
                                {"u1","coi.qty_ordered_conv"},
                            },
                            loadForChange: true, 
                            lockingType: LockingType.UPDLock,
                            tableName: "coitem",
                            fromClause: collectionLoadRequestFactory.Clause(@" AS coi INNER JOIN item AS itm WITH (READUNCOMMITTED) ON itm.item = coi.item INNER JOIN co ON co.co_num = coi.co_num INNER JOIN customer AS cust ON cust.cust_num = co.cust_num
								AND cust.cust_seq = 0 INNER JOIN custaddr ON custaddr.cust_num = cust.cust_num
								AND custaddr.cust_seq = 0"),
                            whereClause: collectionLoadRequestFactory.Clause("coi.item BETWEEN {16} AND {18} AND coi.stat IN ('O', 'P') AND ((itm.product_code BETWEEN {0} AND {3}) OR ({9} = 1 AND itm.product_code IS NULL)) AND 1 = (CASE WHEN {17} = 'P' THEN (CASE WHEN ((co.curr_code BETWEEN {5} AND {12}) OR ({6} = 1 AND co.curr_code IS NULL)) THEN 1 ELSE 0 END) ELSE 1 END) AND 1 = (CASE WHEN {17} = 'A' THEN (CASE WHEN isnull(co.curr_code, char(1)) = (CASE WHEN {5} = '' THEN isnull(co.curr_code, char(1)) ELSE {5} END) THEN 1 ELSE 0 END) ELSE 1 END) AND co.cust_num BETWEEN {10} AND {14} AND ((cust.cust_type BETWEEN {7} AND {13}) OR ({8} = 1 AND cust.cust_type IS NULL)) AND ((cust.end_user_type BETWEEN {1} AND {4}) OR ({2} = 1 AND cust.end_user_type IS NULL)) AND coi.due_date BETWEEN {11} AND {15} AND (coi.qty_ordered - coi.qty_shipped) > 0", FromProductCode, FromEndUserType, EndUserTypeNULL, ToProductCode, ToEndUserType, FromCurrCode, CurrCodeNull, FromCustType, CustTypeNULL, ProductNull, FromCustNum, FromDueDate, ToCurrCode, ToCustType, ToCustNum, ToDueDate, FromItem, AmtType, ToItem),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var coitemLoadResponse = this.appDB.Load(coitemLoadRequest);
                        #endregion  LoadToRecord

                        #region CRUD UpdateByRecord
                        foreach (var coitemItem in coitemLoadResponse.Items)
                        {
                            coitemItem.SetValue<decimal?>("price", ((sQLUtil.SQLEqual(AmtType, "A") == true ? (coitemItem.GetDeletedValue<decimal?>("price") + PriAmt) : (coitemItem.GetDeletedValue<decimal?>("price") + (coitemItem.GetDeletedValue<decimal?>("price") * PriAmt / 100M)))));
                            coitemItem.SetValue<decimal?>("price_conv", (((sQLUtil.SQLEqual(AmtType, "A") == true ? (coitemItem.GetDeletedValue<decimal?>("price") + PriAmt) : (coitemItem.GetDeletedValue<decimal?>("price") + (coitemItem.GetDeletedValue<decimal?>("price") * PriAmt / 100M)))) * coitemItem.GetDeletedValue<decimal?>("u0")) / coitemItem.GetDeletedValue<decimal?>("u1"));
                        };

                        var coitemRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "coitem",
                            items: coitemLoadResponse.Items);

                        this.appDB.Update(coitemRequestUpdate);
                        #endregion UpdateByRecord

                        Counter = (int?)(Counter + coitemLoadResponse.Items.Count);

                        #region CRUD LoadToRecord
                        var co_blnLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                            {
                                {"cont_price","co_bln.cont_price"},
                                {"cont_price_conv","co_bln.cont_price_conv"},
                                {"u0","co_bln.blanket_qty"},
                                {"u1","co_bln.blanket_qty_conv"},
                            },
                            loadForChange: true, 
                            lockingType: LockingType.UPDLock,
                            tableName: "co_bln",
                            fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN item AS itm WITH (READUNCOMMITTED) ON itm.item = co_bln.item INNER JOIN co ON co.co_num = co_bln.co_num INNER JOIN customer AS cust ON cust.cust_num = co.cust_num
								AND cust.cust_seq = 0 INNER JOIN custaddr ON custaddr.cust_num = cust.cust_num
								AND custaddr.cust_seq = 0"),
                            whereClause: collectionLoadRequestFactory.Clause("co_bln.item BETWEEN {16} AND {18} AND co_bln.stat IN ('O', 'P') AND ((itm.product_code BETWEEN {0} AND {3}) OR ({9} = 1 AND itm.product_code IS NULL)) AND 1 = (CASE WHEN {17} = 'P' THEN (CASE WHEN ((co.curr_code BETWEEN {5} AND {12}) OR ({6} = 1 AND co.curr_code IS NULL)) THEN 1 ELSE 0 END) ELSE 1 END) AND 1 = (CASE WHEN {17} = 'A' THEN (CASE WHEN isnull(co.curr_code, char(1)) = (CASE WHEN {5} = '' THEN isnull(co.curr_code, char(1)) ELSE {5} END) THEN 1 ELSE 0 END) ELSE 1 END) AND co.cust_num BETWEEN {10} AND {14} AND ((cust.cust_type BETWEEN {7} AND {13}) OR ({8} = 1 AND cust.cust_type IS NULL)) AND ((cust.end_user_type BETWEEN {1} AND {4}) OR ({2} = 1 AND cust.end_user_type IS NULL)) AND (co_bln.eff_date IS NULL OR co_bln.eff_date BETWEEN {11} AND {15}) AND (co_bln.exp_date IS NULL OR co_bln.exp_date BETWEEN {11} AND {15}) AND EXISTS (SELECT 1 FROM coitem AS coi WHERE coi.co_num = co_bln.co_num AND coi.co_line = co_bln.co_line AND (coi.qty_ordered - coi.qty_shipped) > 0)", FromProductCode, FromEndUserType, EndUserTypeNULL, ToProductCode, ToEndUserType, FromCurrCode, CurrCodeNull, FromCustType, CustTypeNULL, ProductNull, FromCustNum, FromDueDate, ToCurrCode, ToCustType, ToCustNum, ToDueDate, FromItem, AmtType, ToItem),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var co_blnLoadResponse = this.appDB.Load(co_blnLoadRequest);
                        #endregion  LoadToRecord

                        #region CRUD UpdateByRecord
                        foreach (var co_blnItem in co_blnLoadResponse.Items)
                        {
                            co_blnItem.SetValue<decimal?>("cont_price", ((sQLUtil.SQLEqual(AmtType, "A") == true ? (co_blnItem.GetDeletedValue<decimal?>("cont_price") + PriAmt) : (co_blnItem.GetDeletedValue<decimal?>("cont_price") + (co_blnItem.GetDeletedValue<decimal?>("cont_price") * PriAmt / 100M)))));
                            co_blnItem.SetValue<decimal?>("cont_price_conv", (((sQLUtil.SQLEqual(AmtType, "A") == true ? (co_blnItem.GetDeletedValue<decimal?>("cont_price") + PriAmt) : (co_blnItem.GetDeletedValue<decimal?>("cont_price") + (co_blnItem.GetDeletedValue<decimal?>("cont_price") * PriAmt / 100M)))) * co_blnItem.GetDeletedValue<decimal?>("u0")) / co_blnItem.GetDeletedValue<decimal?>("u1"));
                        };

                        var co_blnRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "co_bln",
                            items: co_blnLoadResponse.Items);

                        this.appDB.Update(co_blnRequestUpdate);
                        #endregion UpdateByRecord

                        Counter = (int?)(Counter + co_blnLoadResponse.Items.Count);
                        //END

                    }

                }

            }
            Infobar = null;

            #region CRUD ExecuteMethodCall

            var MsgApp2 = this.iMsgApp.MsgAppSp(
                Infobar: Infobar,
                BaseMsg: "I=#Processed",
                Parm1: convertToUtil.ToString(Counter),
                Parm2: "@item");
            Infobar = MsgApp2.Infobar;

            #endregion ExecuteMethodCall

            return (Severity, Infobar);

        }
        public (int? ReturnCode,
            string Infobar)
        AltExtGen_ItemPriceChangeSp(
            string AltExtGenSp,
            string SessionIDChar,
            string FromProductCode,
            string ToProductCode,
            string FromItem,
            string ToItem,
            DateTime? FromEffectDate,
            DateTime? ToEffectDate,
            string FromPriceCode,
            string ToPriceCode,
            string FromCurrCode,
            string ToCurrCode,
            string FromCustNum,
            string ToCustNum,
            string FromCustType,
            string ToCustType,
            string FromEndUserType,
            string ToEndUserType,
            DateTime? FromDueDate,
            DateTime? ToDueDate,
            DateTime? NewEffectDate,
            int? UpdateCreate = 0,
            int? ItmPrc1 = 0,
            int? ItmPrc2 = 0,
            int? ItmPrc3 = 0,
            int? ItmPrc4 = 0,
            int? ItmPrc5 = 0,
            int? ItmPrc6 = 0,
            string PriceType = "I",
            string PriWhole = "PB",
            string AmtType = "A",
            decimal? PriAmt = 0.0M,
            string Infobar = null,
            int? StartingEffectDateOffset = null,
            int? EndingEffectDateOffset = null)
        {
            StringType _SessionIDChar = SessionIDChar;
            ProductCodeType _FromProductCode = FromProductCode;
            ProductCodeType _ToProductCode = ToProductCode;
            ItemType _FromItem = FromItem;
            ItemType _ToItem = ToItem;
            DateType _FromEffectDate = FromEffectDate;
            DateType _ToEffectDate = ToEffectDate;
            PriceCodeType _FromPriceCode = FromPriceCode;
            PriceCodeType _ToPriceCode = ToPriceCode;
            CurrCodeType _FromCurrCode = FromCurrCode;
            CurrCodeType _ToCurrCode = ToCurrCode;
            CustNumType _FromCustNum = FromCustNum;
            CustNumType _ToCustNum = ToCustNum;
            CustTypeType _FromCustType = FromCustType;
            CustTypeType _ToCustType = ToCustType;
            EndUserTypeType _FromEndUserType = FromEndUserType;
            EndUserTypeType _ToEndUserType = ToEndUserType;
            DateType _FromDueDate = FromDueDate;
            DateType _ToDueDate = ToDueDate;
            DateType _NewEffectDate = NewEffectDate;
            ListYesNoType _UpdateCreate = UpdateCreate;
            ListYesNoType _ItmPrc1 = ItmPrc1;
            ListYesNoType _ItmPrc2 = ItmPrc2;
            ListYesNoType _ItmPrc3 = ItmPrc3;
            ListYesNoType _ItmPrc4 = ItmPrc4;
            ListYesNoType _ItmPrc5 = ItmPrc5;
            ListYesNoType _ItmPrc6 = ItmPrc6;
            PriceBaseCodeType _PriceType = PriceType;
            StringType _PriWhole = PriWhole;
            ListAmountPercentType _AmtType = AmtType;
            CostPrcType _PriAmt = PriAmt;
            InfobarType _Infobar = Infobar;
            DateOffsetType _StartingEffectDateOffset = StartingEffectDateOffset;
            DateOffsetType _EndingEffectDateOffset = EndingEffectDateOffset;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "SessionIDChar", _SessionIDChar, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromProductCode", _FromProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToProductCode", _ToProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromEffectDate", _FromEffectDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToEffectDate", _ToEffectDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromPriceCode", _FromPriceCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToPriceCode", _ToPriceCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromCustNum", _FromCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToCustNum", _ToCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromCustType", _FromCustType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToCustType", _ToCustType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromEndUserType", _FromEndUserType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToEndUserType", _ToEndUserType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromDueDate", _FromDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToDueDate", _ToDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewEffectDate", _NewEffectDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdateCreate", _UpdateCreate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItmPrc1", _ItmPrc1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItmPrc2", _ItmPrc2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItmPrc3", _ItmPrc3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItmPrc4", _ItmPrc4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItmPrc5", _ItmPrc5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItmPrc6", _ItmPrc6, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PriceType", _PriceType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PriWhole", _PriWhole, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AmtType", _AmtType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PriAmt", _PriAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "StartingEffectDateOffset", _StartingEffectDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingEffectDateOffset", _EndingEffectDateOffset, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }

    }
}
