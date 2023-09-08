//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateStatus.cs

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
using CSI.DataCollection;
using CSI.MG.MGCore;
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.Logistics.Vendor;

namespace CSI.Reporting
{
    public class Rpt_EstimateStatus : IRpt_EstimateStatus
    {
        IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        ICollectionInsertRequestFactory collectionInsertRequestFactory;
        ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IInitSessionContextWithUser iInitSessionContextWithUser;
        ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICopySessionVariables iCopySessionVariables;
        readonly ICloseSessionContext iCloseSessionContext;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        IExistsChecker existsChecker;
        IConvertToUtil convertToUtil;
        IVariableUtil variableUtil;
        readonly IUomConvAmt iUomConvAmt;
        IStringUtil stringUtil;
        readonly IGetLabel iGetLabel;
        readonly ICurrCnvt iCurrCnvt;
        IMathUtil mathUtil;
        readonly IGetumcf iGetumcf;
        ISQLValueComparerUtil sQLUtil;
        readonly IRefFmt iRefFmt;
        readonly ILowString lowString;
        readonly IHighString highString;
        public Rpt_EstimateStatus(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IInitSessionContextWithUser iInitSessionContextWithUser,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICopySessionVariables iCopySessionVariables,
            ICloseSessionContext iCloseSessionContext,
            ITransactionFactory transactionFactory,
            IGetIsolationLevel iGetIsolationLevel,
            IApplyDateOffset iApplyDateOffset,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IUomConvAmt iUomConvAmt,
            IStringUtil stringUtil,
            IGetLabel iGetLabel,
            ICurrCnvt iCurrCnvt,
            IMathUtil mathUtil,
            IGetumcf iGetumcf,
            ISQLValueComparerUtil sQLUtil,
            IRefFmt iRefFmt,
            ILowString lowString,
            IHighString highString)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.iInitSessionContextWithUser = iInitSessionContextWithUser;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iCopySessionVariables = iCopySessionVariables;
            this.iCloseSessionContext = iCloseSessionContext;
            this.transactionFactory = transactionFactory;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.iApplyDateOffset = iApplyDateOffset;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.iUomConvAmt = iUomConvAmt;
            this.stringUtil = stringUtil;
            this.iGetLabel = iGetLabel;
            this.iCurrCnvt = iCurrCnvt;
            this.mathUtil = mathUtil;
            this.iGetumcf = iGetumcf;
            this.sQLUtil = sQLUtil;
            this.iRefFmt = iRefFmt;
            this.lowString = lowString;
            this.highString = highString;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimateStatusSp(string OrderStarting = null,
            string OrderEnding = null,
            string EstStatus = null,
            string CustomerStarting = null,
            string CustomerEnding = null,
            DateTime? QuoteDateStarting = null,
            DateTime? QuoteDateEnding = null,
            int? QuoteDateStartingOffset = null,
            int? QuoteDateEndingOffset = null,
            DateTime? ExpDateStarting = null,
            DateTime? ExpDateEnding = null,
            int? ExpDateStartingOffset = null,
            int? ExpDateEndingOffset = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string CustItemStarting = null,
            string CustItemEnding = null,
            DateTime? DueDateStarting = null,
            DateTime? DueDateEnding = null,
            int? DueDateStartingOffset = null,
            int? DueDateEndingOffset = null,
            int? PrintDetail = null,
            string SortBy = null,
            int? ShowCONotes = null,
            int? ShowLineRelNotes = null,
            int? ShowInternal = null,
            int? ShowExternal = null,
            int? PrintCost = 0,
            int? DisplayHeader = null,
            string StartProspect = null,
            string EndProspect = null,
            string BGSessionId = null,
            string pSite = null,
            string BGUser = null)
        {
            ICollectionLoadResponse Data = null;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            Guid? RptSessionID = null;
            int? AllOrder = null;
            int? AllCustomer = null;
            int? AllQuoteDate = null;
            int? AllExpDate = null;
            int? AllItem = null;
            int? AllCustItem = null;
            int? AllDueDate = null;
            int? AllProspect = null;
            int? Severity = null;
            ICollectionLoadRequest curLoadRequestForCursor = null;
            ICollectionLoadResponse curLoadResponseForCursor = null;
            int cur_CursorFetch_Status = -1;
            int cur_CursorCounter = -1;
            string t_group_value = null;
            string t_co_num = null;
            string t_co_cust_num = null;
            int? t_co_cust_seq = null;
            string t_co_prospect_id = null;
            string t_co_stat = null;
            DateTime? t_co_order_date = null;
            DateTime? t_co_close_date = null;
            decimal? t_co_disc = null;
            decimal? t_co_exch_rate = null;
            int? t_coitem_co_line = null;
            int? t_coitem_co_release = null;
            string t_coitem_description = null;
            string t_coitem_ref_type = null;
            string t_coitem_ref_num = null;
            int? t_coitem_ref_line_suf = null;
            int? t_coitem_ref_release = null;
            string t_coitem_cust_item = null;
            decimal? t_coitem_qty_ordered = null;
            decimal? t_coitem_price = null;
            decimal? t_coitem_disc = null;
            decimal? t_coitem_cost = null;
            DateTime? t_coitem_due_date = null;
            decimal? t_coitem_qty_ordered_conv = null;
            string t_coitem_item = null;
            Guid? t_coitem_RowPointer = null;
            string t_coitem_u_m = null;
            string t_terms = null;
            string t_co_tax_code1 = null;
            string t_co_tax_code2 = null;
            decimal? t_co_price = null;
            decimal? t_co_misc_charges = null;
            decimal? t_co_sales_tax = null;
            decimal? t_co_sales_tax_2 = null;
            decimal? t_co_cost = null;
            Guid? t_co_RowPointer = null;
            NameType _t_name = DBNull.Value;
            string t_name = null;
            string t_ref = null;
            DecimalPlacesType _t_places = DBNull.Value;
            int? t_places = null;
            decimal? tc_amt_d_price = null;
            string t_ci = null;
            CurrCodeType _t_curr_code = DBNull.Value;
            string t_curr_code = null;
            decimal? t_rate = null;
            string t_error = null;
            decimal? dom_tc_amt_ext_cost = null;
            decimal? dom_tc_tot_cost = null;
            decimal? dom_tc_tot_price = null;
            decimal? uom_conv_factor = null;
            string std_msg = null;
            string c_uom_conv_from_base = null;
            decimal? tc_cpr_cost = null;
            decimal? tc_cpr_d_price = null;
            TaxCodeLabelType _t_tax_amt_label1 = DBNull.Value;
            string t_tax_amt_label1 = null;
            TaxCodeLabelType _t_tax_amt_label2 = DBNull.Value;
            string t_tax_amt_label2 = null;
            ListYesNoType _t_prompt_for_system1 = DBNull.Value;
            int? t_prompt_for_system1 = null;
            ListYesNoType _t_prompt_for_system2 = DBNull.Value;
            int? t_prompt_for_system2 = null;
            decimal? dom_tc_amt_misc_charges = null;
            decimal? dom_tc_amt_sales_tax = null;
            decimal? dom_tc_amt_sales_tax_2 = null;
            decimal? dom_tc_amt_price = null;
            ListYesNoType _CoNoteExistsFlag = DBNull.Value;
            int? CoNoteExistsFlag = null;
            ListYesNoType _CoitemNoteExistsFlag = DBNull.Value;
            int? CoitemNoteExistsFlag = null;
            int? PrCoNotes = null;
            int? PrCoitemNotes = null;
            string CILabel = null;
            ListYesNoType _CoParmsUseAltPriceCalc = DBNull.Value;
            int? CoParmsUseAltPriceCalc = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_EstimateStatusSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_EstimateStatusSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_EstimateStatusSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_Rpt_EstimateStatusSp(_ALTGEN_SpName,
                        OrderStarting,
                        OrderEnding,
                        EstStatus,
                        CustomerStarting,
                        CustomerEnding,
                        QuoteDateStarting,
                        QuoteDateEnding,
                        QuoteDateStartingOffset,
                        QuoteDateEndingOffset,
                        ExpDateStarting,
                        ExpDateEnding,
                        ExpDateStartingOffset,
                        ExpDateEndingOffset,
                        ItemStarting,
                        ItemEnding,
                        CustItemStarting,
                        CustItemEnding,
                        DueDateStarting,
                        DueDateEnding,
                        DueDateStartingOffset,
                        DueDateEndingOffset,
                        PrintDetail,
                        SortBy,
                        ShowCONotes,
                        ShowLineRelNotes,
                        ShowInternal,
                        ShowExternal,
                        PrintCost,
                        DisplayHeader,
                        StartProspect,
                        EndProspect,
                        BGSessionId,
                        pSite,
                        BGUser);
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_EstimateStatusSp") != null)
            {
                var EXTGEN = AltExtGen_Rpt_EstimateStatusSp("dbo.EXTGEN_Rpt_EstimateStatusSp",
                    OrderStarting,
                    OrderEnding,
                    EstStatus,
                    CustomerStarting,
                    CustomerEnding,
                    QuoteDateStarting,
                    QuoteDateEnding,
                    QuoteDateStartingOffset,
                    QuoteDateEndingOffset,
                    ExpDateStarting,
                    ExpDateEnding,
                    ExpDateStartingOffset,
                    ExpDateEndingOffset,
                    ItemStarting,
                    ItemEnding,
                    CustItemStarting,
                    CustItemEnding,
                    DueDateStarting,
                    DueDateEnding,
                    DueDateStartingOffset,
                    DueDateEndingOffset,
                    PrintDetail,
                    SortBy,
                    ShowCONotes,
                    ShowLineRelNotes,
                    ShowInternal,
                    ShowExternal,
                    PrintCost,
                    DisplayHeader,
                    StartProspect,
                    EndProspect,
                    BGSessionId,
                    pSite,
                    BGUser);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            if (DisplayHeader == null)
            {
                DisplayHeader = 1;
            }
            this.transactionFactory.BeginTransaction("");
            this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("EstimateStatusReport"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            }

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InitSessionContextWithUserSp
            var InitSessionContextWithUser = this.iInitSessionContextWithUser.InitSessionContextWithUserSp(ContextName: "Rpt_EstimateStatusSp"
                , SessionID: RptSessionID
                , Site: pSite
                , UserName: BGUser);
            RptSessionID = InitSessionContextWithUser.SessionID;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: CopySessionVariablesSp
            var CopySessionVariables = this.iCopySessionVariables.CopySessionVariablesSp(SessionId: BGSessionId);

            #endregion ExecuteMethodCall

            AllOrder = convertToUtil.ToInt32(OrderStarting == null && OrderEnding == null ? 1 : 0);
            AllCustomer = convertToUtil.ToInt32(CustomerStarting == null && CustomerEnding == null ? 1 : 0);
            AllQuoteDate = (int?)(QuoteDateStarting == null && QuoteDateEnding == null ? 1 : 0);
            AllExpDate = (int?)(ExpDateStarting == null && ExpDateEnding == null ? 1 : 0);
            AllItem = convertToUtil.ToInt32(ItemStarting == null && ItemEnding == null ? 1 : 0);
            AllCustItem = convertToUtil.ToInt32(CustItemStarting == null && CustItemEnding == null ? 1 : 0);
            AllDueDate = (int?)(DueDateStarting == null && DueDateEnding == null ? 1 : 0);
            AllProspect = convertToUtil.ToInt32(StartProspect == null && EndProspect == null ? 1 : 0);
            Severity = 0;
            OrderStarting = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("CoNumType", OrderStarting), this.lowString.LowStringFn("CoNumType"));
            OrderEnding = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("CoNumType", OrderEnding), this.highString.HighStringFn("CoNumType"));
            ItemStarting = stringUtil.IsNull(ItemStarting, this.lowString.LowStringFn("ItemType"));
            ItemEnding = stringUtil.IsNull(ItemEnding, this.highString.HighStringFn("ItemType"));
            CustItemStarting = stringUtil.IsNull(CustItemStarting, this.lowString.LowStringFn("CustItemType"));
            CustItemEnding = stringUtil.IsNull(CustItemEnding, this.highString.HighStringFn("CustItemType"));
            CustomerStarting = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("CustNumType", CustomerStarting), this.lowString.LowStringFn("CustNumType"));
            CustomerEnding = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("CustNumType", CustomerEnding), this.highString.HighStringFn("CustNumType"));
            StartProspect = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("ProspectIdType", StartProspect), this.lowString.LowStringFn("ProspectIdType"));
            EndProspect = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("ProspectIdType", EndProspect), this.highString.HighStringFn("ProspectIdType"));
            EstStatus = stringUtil.IsNull(EstStatus, "WQPH");
            ShowCONotes = (int?)(stringUtil.IsNull(ShowCONotes, 0));
            ShowLineRelNotes = (int?)(stringUtil.IsNull(ShowLineRelNotes, 0));
            ShowInternal = (int?)(stringUtil.IsNull(ShowInternal, 0));
            ShowExternal = (int?)(stringUtil.IsNull(ShowExternal, 1));
            SortBy = stringUtil.IsNull(SortBy, "E");
            PrintDetail = (int?)(stringUtil.IsNull(PrintDetail, 1));
            if (sQLUtil.SQLNotEqual(PrintDetail, 1) == true && sQLUtil.SQLEqual(SortBy, "I") == true)
            {
                SortBy = "E";
            }

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(Date: QuoteDateStarting
                , Offset: QuoteDateStartingOffset
                , IsEndDate: 0);
            QuoteDateStarting = ApplyDateOffset.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: QuoteDateEnding
                , Offset: QuoteDateEndingOffset
                , IsEndDate: 1);
            QuoteDateEnding = ApplyDateOffset1.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset2 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: ExpDateStarting
                , Offset: ExpDateStartingOffset
                , IsEndDate: 0);
            ExpDateStarting = ApplyDateOffset2.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset3 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: ExpDateEnding
                , Offset: ExpDateEndingOffset
                , IsEndDate: 1);
            ExpDateEnding = ApplyDateOffset3.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset4 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: DueDateStarting
                , Offset: DueDateStartingOffset
                , IsEndDate: 0);
            DueDateStarting = ApplyDateOffset4.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset5 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: DueDateEnding
                , Offset: DueDateEndingOffset
                , IsEndDate: 1);
            DueDateEnding = ApplyDateOffset5.Date;

            #endregion ExecuteMethodCall

            CILabel = stringUtil.Concat(this.iGetLabel.GetLabelFn("@coitem.cust_item"), ":");
            if ((sQLUtil.SQLEqual(ShowInternal, 1) == true || sQLUtil.SQLEqual(ShowExternal, 1) == true) && sQLUtil.SQLEqual(ShowCONotes, 1) == true)
            {
                PrCoNotes = 1;
            }
            else
            {
                PrCoNotes = 0;
            }
            if ((sQLUtil.SQLEqual(ShowInternal, 1) == true || sQLUtil.SQLEqual(ShowExternal, 1) == true) && sQLUtil.SQLEqual(ShowLineRelNotes, 1) == true)
            {
                PrCoitemNotes = 1;
            }
            else
            {
                PrCoitemNotes = 0;
            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#rpt_set") == null)
            {
                this.sQLExpressionExecutor.Execute(@"Declare
                     @t_seq int
                     ,@t_group_value nchar (30)
                     ,@t_co_num CoNumType
                     ,@t_co_cust_num CustNumType
                     ,@t_co_prospect_id ProspectIdType
                     ,@t_co_order_date DateType
                     ,@t_co_close_date DateType
                     ,@t_co_stat CoStatusType
                     ,@t_coitem_co_line CoLineType
                     ,@t_coitem_due_date DateType
                     ,@t_ref InfobarType
                     ,@t_coitem_qty_ordered QtyUnitNoNegType
                     ,@t_coitem_disc LineDiscType
                     ,@net_cost AmountType
                     ,@net_price AmountType
                     ,@t_name NameType
                     ,@t_coitem_item ItemType
                     ,@t_co_disc OrderDiscType
                     ,@t_coitem_description DescriptionType
                     ,@t_ci NVARCHAR (66)
                     ,@cost_each AmountType
                     ,@price_each AmountType
                     ,@t_coitem_u_m UMType
                     ,@t_curr_code CurrCodeType
                     ,@t_terms DescriptionType
                     ,@t_co_misc_charges AmountType
                     ,@t_co_sales_tax AmountType
                     ,@t_co_tax_code1 TaxCodeType
                     ,@t_co_tax_code2 TaxCodeType
                     ,@dom_tc_tot_cost AmountType
                     ,@dom_tc_tot_price AmountType
                     ,@t_coitem_RowPointer RowPointerType
                     ,@t_co_RowPointer RowPointerType
                     ,@t_note_type int
                     ,@t_note_text LongDescType
                     ,@CoNoteExistsFlag ListYesNoType
                     ,@CoitemNoteExistsFlag ListYesNoType
                     SELECT @t_seq AS seq,
                            @t_group_value AS group_value,
                            @t_co_num AS co_num,
                            @t_co_cust_num AS cust_num,
                            @t_co_prospect_id AS prospect_id,
                            @t_co_order_date AS quoted_date,
                            @t_co_close_date AS expired_date,
                            @t_co_stat AS status,
                            @t_coitem_co_line AS co_line,
                            @t_coitem_due_date AS due_date,
                            @t_ref AS ref,
                            @t_coitem_qty_ordered AS qty_ordered,
                            @t_coitem_disc AS ln_disc,
                            @net_cost AS net_cost,
                            @net_price AS net_price,
                            @t_name AS cust_name,
                            @t_coitem_item AS item,
                            @t_co_disc AS ord_disc,
                            @t_coitem_description AS description,
                            @t_ci AS cust_item,
                            @cost_each AS cost_each,
                            @price_each AS price_each,
                            @t_coitem_u_m AS u_m,
                            @t_curr_code AS curr_code,
                            @t_terms AS terms,
                            @t_co_misc_charges AS misc_charges,
                            @t_co_sales_tax AS sales_tax,
                            @t_co_sales_tax AS sales_tax_2,
                            @t_co_tax_code1 AS tax_code1,
                            @t_co_tax_code2 AS tax_code2,
                            @dom_tc_tot_cost AS total_cost,
                            @dom_tc_tot_price AS total_price,
                            @t_coitem_RowPointer AS coitem_RowPointer,
                            @t_co_RowPointer AS co_RowPointer,
                            @t_note_type AS note_type,
                            @t_note_text AS note_text,
                            @CoNoteExistsFlag AS co_note_exists_flag,
                            @CoitemNoteExistsFlag AS coitem_note_exists_flag
                     INTO   #rpt_set
                     WHERE  1 = 2");
            }
            this.sQLExpressionExecutor.Execute("ALTER TABLE #rpt_set ADD tempTableId INT IDENTITY");
            /*Needs to load at least one column from the table: #rpt_set for delete, Loads the record based on its where and from clause, then deletes it by record.*/
            #region CRUD LoadToRecord
            var rpt_set1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                {"col0","1"},
                },
                loadForChange: true, 
                lockingType: LockingType.None,
                tableName: "#rpt_set",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var rpt_set1LoadResponse = this.appDB.Load(rpt_set1LoadRequest);
            #endregion  LoadToRecord

            #region CRUD DeleteByRecord
            var rpt_set1DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#rpt_set",
                items: rpt_set1LoadResponse.Items);
            this.appDB.Delete(rpt_set1DeleteRequest);
            #endregion DeleteByRecord

            this.sQLExpressionExecutor.Execute("ALTER TABLE #rpt_set DROP COLUMN tempTableId");
            c_uom_conv_from_base = "From Base";

            #region CRUD LoadToVariable
            var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_t_places,"currency.places"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "currparms",
                fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN currency ON currency.curr_code = currparms.curr_code"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(currparmsLoadRequest);
            t_places = _t_places;
            #endregion  LoadToVariable

            t_places = (int?)(stringUtil.IsNull(t_places, 2));
            t_tax_amt_label1 = null;

            #region CRUD LoadToVariable
            var tax_systemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_t_tax_amt_label1,"tax_amt_label"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "tax_system",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("tax_system = 1"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(tax_systemLoadRequest);
            t_tax_amt_label1 = _t_tax_amt_label1;
            #endregion  LoadToVariable

            t_tax_amt_label2 = null;

            #region CRUD LoadToVariable
            var tax_system1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_t_tax_amt_label2,"tax_amt_label"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "tax_system",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("tax_system = 2"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(tax_system1LoadRequest);
            t_tax_amt_label2 = _t_tax_amt_label2;
            #endregion  LoadToVariable

            #region CRUD LoadToVariable
            var taxparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_t_prompt_for_system1,"prompt_for_system1"},
                    {_t_prompt_for_system2,"prompt_for_system2"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "taxparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(taxparmsLoadRequest);
            t_prompt_for_system1 = _t_prompt_for_system1;
            t_prompt_for_system2 = _t_prompt_for_system2;
            #endregion  LoadToVariable

            #region CRUD LoadToVariable
            var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CoParmsUseAltPriceCalc,"coparms.use_alt_price_calc"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "coparms",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(coparmsLoadRequest);
            CoParmsUseAltPriceCalc = _CoParmsUseAltPriceCalc;
            #endregion  LoadToVariable

            #region CRUD LoadToRecord
            curLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"co_num","co.co_num"},
                    {"cust_num","co.cust_num"},
                    {"cust_seq","co.cust_seq"},
                    {"prospect_id","co.prospect_id"},
                    {"stat","co.stat"},
                    {"order_date","co.order_date"},
                    {"close_date","co.close_date"},
                    {"disc","co.disc"},
                    {"exch_rate","co.exch_rate"},
                    {"co_line","coitem.co_line"},
                    {"co_release","coitem.co_release"},
                    {"description","coitem.description"},
                    {"ref_type","coitem.ref_type"},
                    {"ref_num","coitem.ref_num"},
                    {"ref_line_suf","coitem.ref_line_suf"},
                    {"ref_release","coitem.ref_release"},
                    {"cust_item","coitem.cust_item"},
                    {"qty_ordered","coitem.qty_ordered"},
                    {"price","coitem.price"},
                    {"disc_","coitem.disc"},
                    {"cost","coitem.cost"},
                    {"due_date","coitem.due_date"},
                    {"qty_ordered_conv","coitem.qty_ordered_conv"},
                    {"item","coitem.item"},
                    {"RowPointer","coitem.RowPointer"},
                    {"u_m","coitem.u_m"},
                    {"description_","terms.description"},
                    {"misc_charges","co.misc_charges"},
                    {"sales_tax","co.sales_tax"},
                    {"sales_tax_2","co.sales_tax_2"},
                    {"price_","co.price"},
                    {"tax_code1","co.tax_code1"},
                    {"tax_code2","co.tax_code2"},
                    {"cost_","co.cost"},
                    {"col0","CAST (NULL AS NVARCHAR)"},
                    {"RowPointer_","co.RowPointer"},
                    {"u0","co.curr_code"},
                    {"u1","custaddr.curr_code"},
                    {"u2","prospect.curr_code"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "CoView",
                fromClause: collectionLoadRequestFactory.Clause(@" AS co LEFT OUTER JOIN CoItemView AS coitem ON coitem.co_num = co.co_num LEFT OUTER JOIN terms ON terms.terms_code = co.terms_code LEFT OUTER JOIN custaddr ON co.cust_num = custaddr.cust_num 
                    AND co.cust_seq = custaddr.cust_seq LEFT OUTER JOIN prospect ON co.prospect_id = prospect.prospect_id"),
                whereClause: collectionLoadRequestFactory.Clause("co.type = 'E' AND (co.co_num BETWEEN {8} AND {14} OR {23} = 1) AND (co.cust_num BETWEEN {1} AND {6} OR {15} = 1) AND (co.prospect_id BETWEEN {9} AND {16} OR {17} = 1) AND (co.order_date BETWEEN {0} AND {3} OR {12} = 1) AND (co.close_date BETWEEN {4} AND {10} OR {19} = 1) AND (coitem.cust_item BETWEEN {2} AND {7} OR {18} = 1) AND (coitem.item BETWEEN {13} AND {20} OR {24} = 1) AND (coitem.due_date BETWEEN {5} AND {11} OR {21} = 1) AND CHARINDEX(co.stat, {22}) > 0"
                    , QuoteDateStarting, CustomerStarting, CustItemStarting, QuoteDateEnding, ExpDateStarting, DueDateStarting, CustomerEnding, CustItemEnding, OrderStarting, StartProspect, ExpDateEnding, DueDateEnding, AllQuoteDate, ItemStarting, OrderEnding, AllCustomer, EndProspect, AllProspect, AllCustItem, AllExpDate, ItemEnding, AllDueDate, EstStatus, AllOrder, AllItem),
                orderByClause: collectionLoadRequestFactory.Clause(" coitem.co_num, coitem.co_line"));
            #endregion  LoadToRecord

            curLoadResponseForCursor = this.appDB.Load(curLoadRequestForCursor);
            foreach (var CoViewItem in curLoadResponseForCursor.Items)
            {
                CoViewItem.SetValue<string>("co_num", CoViewItem.GetValue<string>("co_num"));
                CoViewItem.SetValue<string>("cust_num", CoViewItem.GetValue<string>("cust_num"));
                CoViewItem.SetValue<int?>("cust_seq", CoViewItem.GetValue<int?>("cust_seq"));
                CoViewItem.SetValue<string>("prospect_id", CoViewItem.GetValue<string>("prospect_id"));
                CoViewItem.SetValue<string>("stat", CoViewItem.GetValue<string>("stat"));
                CoViewItem.SetValue<DateTime?>("order_date", CoViewItem.GetValue<DateTime?>("order_date"));
                CoViewItem.SetValue<DateTime?>("close_date", CoViewItem.GetValue<DateTime?>("close_date"));
                CoViewItem.SetValue<decimal?>("disc", CoViewItem.GetValue<decimal?>("disc"));
                CoViewItem.SetValue<decimal?>("exch_rate", CoViewItem.GetValue<decimal?>("exch_rate"));
                CoViewItem.SetValue<int?>("co_line", CoViewItem.GetValue<int?>("co_line"));
                CoViewItem.SetValue<int?>("co_release", CoViewItem.GetValue<int?>("co_release"));
                CoViewItem.SetValue<string>("description", CoViewItem.GetValue<string>("description"));
                CoViewItem.SetValue<string>("ref_type", CoViewItem.GetValue<string>("ref_type"));
                CoViewItem.SetValue<string>("ref_num", CoViewItem.GetValue<string>("ref_num"));
                CoViewItem.SetValue<int?>("ref_line_suf", CoViewItem.GetValue<int?>("ref_line_suf"));
                CoViewItem.SetValue<int?>("ref_release", CoViewItem.GetValue<int?>("ref_release"));
                CoViewItem.SetValue<string>("cust_item", CoViewItem.GetValue<string>("cust_item"));
                CoViewItem.SetValue<decimal?>("qty_ordered", CoViewItem.GetValue<decimal?>("qty_ordered"));
                CoViewItem.SetValue<decimal?>("price", CoViewItem.GetValue<decimal?>("price"));
                CoViewItem.SetValue<decimal?>("disc_", CoViewItem.GetValue<decimal?>("disc_"));
                CoViewItem.SetValue<decimal?>("cost", CoViewItem.GetValue<decimal?>("cost"));
                CoViewItem.SetValue<DateTime?>("due_date", CoViewItem.GetValue<DateTime?>("due_date"));
                CoViewItem.SetValue<decimal?>("qty_ordered_conv", CoViewItem.GetValue<decimal?>("qty_ordered_conv"));
                CoViewItem.SetValue<string>("item", CoViewItem.GetValue<string>("item"));
                CoViewItem.SetValue<Guid?>("RowPointer", CoViewItem.GetValue<Guid?>("RowPointer"));
                CoViewItem.SetValue<string>("u_m", CoViewItem.GetValue<string>("u_m"));
                CoViewItem.SetValue<string>("description_", CoViewItem.GetValue<string>("description_"));
                CoViewItem.SetValue<decimal?>("misc_charges", CoViewItem.GetValue<decimal?>("misc_charges"));
                CoViewItem.SetValue<decimal?>("sales_tax", CoViewItem.GetValue<decimal?>("sales_tax"));
                CoViewItem.SetValue<decimal?>("sales_tax_2", CoViewItem.GetValue<decimal?>("sales_tax_2"));
                CoViewItem.SetValue<decimal?>("price_", CoViewItem.GetValue<decimal?>("price_"));
                CoViewItem.SetValue<string>("tax_code1", CoViewItem.GetValue<string>("tax_code1"));
                CoViewItem.SetValue<string>("tax_code2", CoViewItem.GetValue<string>("tax_code2"));
                CoViewItem.SetValue<decimal?>("cost_", CoViewItem.GetValue<decimal?>("cost_"));
                CoViewItem.SetValue<string>("col0", stringUtil.Coalesce<string>(CoViewItem.GetValue<string>("u0"), CoViewItem.GetValue<string>("u1"), CoViewItem.GetValue<string>("u2")));
                CoViewItem.SetValue<Guid?>("RowPointer_", CoViewItem.GetValue<Guid?>("RowPointer_"));
            };

            cur_CursorFetch_Status = curLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
            cur_CursorCounter = -1;

            while (sQLUtil.SQLBool(sQLUtil.SQLEqual(1, 1)))
            {
                //BEGIN
                cur_CursorCounter++;
                if (curLoadResponseForCursor.Items.Count > cur_CursorCounter)
                {
                    t_co_num = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(0);
                    t_co_cust_num = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(1);
                    t_co_cust_seq = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<int?>(2);
                    t_co_prospect_id = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(3);
                    t_co_stat = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(4);
                    t_co_order_date = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<DateTime?>(5);
                    t_co_close_date = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<DateTime?>(6);
                    t_co_disc = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(7);
                    t_co_exch_rate = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(8);
                    t_coitem_co_line = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<int?>(9);
                    t_coitem_co_release = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<int?>(10);
                    t_coitem_description = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(11);
                    t_coitem_ref_type = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(12);
                    t_coitem_ref_num = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(13);
                    t_coitem_ref_line_suf = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<int?>(14);
                    t_coitem_ref_release = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<int?>(15);
                    t_coitem_cust_item = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(16);
                    t_coitem_qty_ordered = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(17);
                    t_coitem_price = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(18);
                    t_coitem_disc = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(19);
                    t_coitem_cost = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(20);
                    t_coitem_due_date = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<DateTime?>(21);
                    t_coitem_qty_ordered_conv = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(22);
                    t_coitem_item = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(23);
                    t_coitem_RowPointer = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<Guid?>(24);
                    t_coitem_u_m = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(25);
                    t_terms = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(26);
                    t_co_misc_charges = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(27);
                    t_co_sales_tax = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(28);
                    t_co_sales_tax_2 = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(29);
                    t_co_price = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(30);
                    t_co_tax_code1 = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(31);
                    t_co_tax_code2 = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(32);
                    t_co_cost = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<decimal?>(33);
                    t_curr_code = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<string>(34);
                    t_co_RowPointer = curLoadResponseForCursor.Items[cur_CursorCounter].GetValue<Guid?>(35);
                }
                cur_CursorFetch_Status = (cur_CursorCounter == curLoadResponseForCursor.Items.Count ? -1 : 0);

                if (sQLUtil.SQLNotEqual(cur_CursorFetch_Status, 0) == true)
                {
                    break;
                }
                if (t_co_cust_num != null && sQLUtil.SQLNotEqual(t_co_cust_num, "") == true)
                {
                    #region CRUD LoadToVariable
                    var custaddrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_t_name,"custaddr.name"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "custaddr",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("cust_num = {0} AND cust_seq = ISNULL({1}, 0)", t_co_cust_num, t_co_cust_seq),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    this.appDB.Load(custaddrLoadRequest);
                    t_name = _t_name;
                    #endregion  LoadToVariable
                }
                else
                {
                    if (t_co_prospect_id != null && sQLUtil.SQLNotEqual(t_co_prospect_id, "") == true)
                    {
                        #region CRUD LoadToVariable
                        var prospectLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_t_name,"company"},
                                {_t_curr_code,"curr_code"},
                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "prospect",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("prospect_id = {0}", t_co_prospect_id),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        this.appDB.Load(prospectLoadRequest);
                        t_name = _t_name;
                        t_curr_code = _t_curr_code;
                        #endregion  LoadToVariable
                    }
                    else
                    {
                        //BEGIN
                        t_name = "";

                        #region CRUD LoadToVariable
                        var currparms1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_t_curr_code,"curr_code"},
                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "currparms",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause(""),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        this.appDB.Load(currparms1LoadRequest);
                        t_curr_code = _t_curr_code;
                        #endregion  LoadToVariable

                        //END
                    }
                }
                t_ref = this.iRefFmt.RefFmtSp(t_coitem_ref_type, t_coitem_ref_num, t_coitem_ref_line_suf, t_coitem_ref_release);
                t_ci = sQLUtil.SQLEqual(t_coitem_cust_item, "") == true ? "" : stringUtil.Concat(CILabel, " ", t_coitem_cust_item);
                tc_amt_d_price = (decimal?)(sQLUtil.SQLEqual(CoParmsUseAltPriceCalc, 1) == true ? mathUtil.Round<decimal?>(t_coitem_price * (1.0M - t_coitem_disc / 100.0M) * (1M - t_co_disc / 100M), t_places) * t_coitem_qty_ordered : mathUtil.Round<decimal?>(t_coitem_qty_ordered * t_coitem_price * (1.0M - t_coitem_disc / 100.0M) * (1M - t_co_disc / 100M), t_places));
                t_rate = t_co_exch_rate;

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: CurrCnvtSp
                var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(CurrCode: t_curr_code
                    , FromDomestic: 0
                    , UseBuyRate: 0
                    , RoundResult: 1
                    , TRate: t_rate
                    , Infobar: t_error
                    , Amount1: tc_amt_d_price
                    , Result1: tc_amt_d_price);
                Severity = CurrCnvt.ReturnCode;
                t_rate = CurrCnvt.TRate;
                t_error = CurrCnvt.Infobar;
                tc_amt_d_price = CurrCnvt.Result1;

                #endregion ExecuteMethodCall

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    break;
                }

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: CurrCnvtSp
                var CurrCnvt1 = this.iCurrCnvt.CurrCnvtSp(CurrCode: t_curr_code
                    , FromDomestic: 0
                    , UseBuyRate: 0
                    , RoundResult: 0
                    , TRate: t_rate
                    , Infobar: t_error
                    , Amount1: t_coitem_price
                    , Result1: tc_cpr_d_price);
                Severity = CurrCnvt1.ReturnCode;
                t_rate = CurrCnvt1.TRate;
                t_error = CurrCnvt1.Infobar;
                tc_cpr_d_price = CurrCnvt1.Result1;

                #endregion ExecuteMethodCall

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    break;
                }
                dom_tc_amt_ext_cost = (decimal?)(t_coitem_cost * t_coitem_qty_ordered);
                dom_tc_tot_price = (decimal?)(dom_tc_tot_price + tc_amt_d_price);
                dom_tc_tot_cost = (decimal?)(dom_tc_tot_cost + dom_tc_amt_ext_cost);

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: GetumcfSp
                var Getumcf = this.iGetumcf.GetumcfSp(OtherUM: t_coitem_u_m
                    , Item: t_coitem_item
                    , VendNum: t_co_cust_num
                    , Area: "C"
                    , ConvFactor: uom_conv_factor
                    , Infobar: std_msg);
                uom_conv_factor = Getumcf.ConvFactor;
                std_msg = Getumcf.Infobar;

                #endregion ExecuteMethodCall

                tc_cpr_cost = convertToUtil.ToDecimal(this.iUomConvAmt.UomConvAmtFn(t_coitem_cost, uom_conv_factor, c_uom_conv_from_base));
                if (sQLUtil.SQLBool(sQLUtil.SQLEqual(PrintDetail, 0)))
                {
                    //BEGIN
                    t_co_tax_code1 = sQLUtil.SQLEqual(t_prompt_for_system1, 1) == true ? t_co_tax_code1 : null;
                    t_co_tax_code2 = sQLUtil.SQLEqual(t_prompt_for_system2, 1) == true ? t_co_tax_code2 : null;
                    if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(
                        tableName: "#rpt_set",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("co_num = {0}", t_co_num)))))
                    {
                        //BEGIN
                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: CurrCnvtSp
                        var CurrCnvt2 = this.iCurrCnvt.CurrCnvtSp(CurrCode: t_curr_code
                            , FromDomestic: 0
                            , UseBuyRate: 0
                            , RoundResult: 1
                            , TRate: t_rate
                            , Infobar: t_error
                            , Amount1: t_co_misc_charges
                            , Result1: dom_tc_amt_misc_charges);
                        Severity = CurrCnvt2.ReturnCode;
                        t_rate = CurrCnvt2.TRate;
                        t_error = CurrCnvt2.Infobar;
                        dom_tc_amt_misc_charges = CurrCnvt2.Result1;

                        #endregion ExecuteMethodCall

                        if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                        {
                            break;
                        }

                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: CurrCnvtSp
                        var CurrCnvt3 = this.iCurrCnvt.CurrCnvtSp(CurrCode: t_curr_code
                            , FromDomestic: 0
                            , UseBuyRate: 0
                            , RoundResult: 1
                            , TRate: t_rate
                            , Infobar: t_error
                            , Amount1: t_co_sales_tax
                            , Result1: dom_tc_amt_sales_tax);
                        Severity = CurrCnvt3.ReturnCode;
                        t_rate = CurrCnvt3.TRate;
                        t_error = CurrCnvt3.Infobar;
                        dom_tc_amt_sales_tax = CurrCnvt3.Result1;

                        #endregion ExecuteMethodCall

                        if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                        {
                            break;
                        }

                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: CurrCnvtSp
                        var CurrCnvt4 = this.iCurrCnvt.CurrCnvtSp(CurrCode: t_curr_code
                            , FromDomestic: 0
                            , UseBuyRate: 0
                            , RoundResult: 1
                            , TRate: t_rate
                            , Infobar: t_error
                            , Amount1: t_co_sales_tax_2
                            , Result1: dom_tc_amt_sales_tax_2);
                        Severity = CurrCnvt4.ReturnCode;
                        t_rate = CurrCnvt4.TRate;
                        t_error = CurrCnvt4.Infobar;
                        dom_tc_amt_sales_tax_2 = CurrCnvt4.Result1;

                        #endregion ExecuteMethodCall

                        if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                        {
                            break;
                        }

                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: CurrCnvtSp
                        var CurrCnvt5 = this.iCurrCnvt.CurrCnvtSp(CurrCode: t_curr_code
                            , FromDomestic: 0
                            , UseBuyRate: 0
                            , RoundResult: 1
                            , TRate: t_rate
                            , Infobar: t_error
                            , Amount1: t_co_price
                            , Result1: dom_tc_amt_price);
                        Severity = CurrCnvt5.ReturnCode;
                        t_rate = CurrCnvt5.TRate;
                        t_error = CurrCnvt5.Infobar;
                        dom_tc_amt_price = CurrCnvt5.Result1;

                        #endregion ExecuteMethodCall

                        if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                        {
                            break;
                        }
                        //END
                    }
                    //END
                }
                t_group_value = sQLUtil.SQLEqual(SortBy, "E") == true ? Convert.ToString(t_co_num) : sQLUtil.SQLEqual(SortBy, "C") == true ? Convert.ToString(t_co_cust_num) : Convert.ToString(t_coitem_item);
                if (sQLUtil.SQLEqual(PrintCost, 0) == true)
                {
                    //BEGIN
                    t_co_cost = 0;
                    dom_tc_amt_ext_cost = 0;
                    //END
                }
                CoNoteExistsFlag = 0;
                CoitemNoteExistsFlag = 0;

                #region CRUD LoadToVariable
                var coLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_CoNoteExistsFlag,$"CASE {variableUtil.GetValue<int?>(PrCoNotes)} WHEN 1 THEN dbo.ReportNotesExist('co', co.RowPointer, {variableUtil.GetValue<int?>(ShowInternal)}, {variableUtil.GetValue<int?>(ShowExternal)}, co.NoteExistsFlag) ELSE 0 END"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "co",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("co.co_num = {0}", t_co_num),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                this.appDB.Load(coLoadRequest);
                CoNoteExistsFlag = _CoNoteExistsFlag;
                #endregion  LoadToVariable

                #region CRUD LoadToVariable
                var coitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_CoitemNoteExistsFlag,$"CASE {variableUtil.GetValue<int?>(PrCoitemNotes)} WHEN 1 THEN dbo.ReportNotesExist('coitem', coitem.RowPointer, {variableUtil.GetValue<int?>(ShowInternal)}, {variableUtil.GetValue<int?>(ShowExternal)}, coitem.NoteExistsFlag) ELSE 0 END"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "coitem",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("coitem.co_num = {2} AND coitem.co_line = {1} AND coitem.co_release = {0}", t_coitem_co_release, t_coitem_co_line, t_co_num),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                this.appDB.Load(coitemLoadRequest);
                CoitemNoteExistsFlag = _CoitemNoteExistsFlag;
                #endregion  LoadToVariable

                #region CRUD LoadResponseWithoutTable
                var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                    {
                        { "group_value", variableUtil.GetValue<string>(t_group_value,true)},
                        { "co_num", variableUtil.GetValue<string>(t_co_num,true)},
                        { "cust_num", variableUtil.GetValue<string>(t_co_cust_num,true)},
                        { "prospect_id", variableUtil.GetValue<string>(t_co_prospect_id,true)},
                        { "quoted_date", variableUtil.GetValue<DateTime?>(t_co_order_date,true)},
                        { "expired_date", variableUtil.GetValue<DateTime?>(t_co_close_date,true)},
                        { "status", variableUtil.GetValue<string>(t_co_stat,true)},
                        { "co_line", variableUtil.GetValue<int?>(t_coitem_co_line,true)},
                        { "due_date", variableUtil.GetValue<DateTime?>(t_coitem_due_date,true)},
                        { "ref", variableUtil.GetValue<string>(t_ref,true)},
                        { "qty_ordered", variableUtil.GetValue<decimal?>(t_coitem_qty_ordered_conv,true)},
                        { "ln_disc", variableUtil.GetValue<decimal?>(t_coitem_disc,true)},
                        { "net_cost", variableUtil.GetValue<decimal?>(dom_tc_amt_ext_cost,true)},
                        { "net_price", variableUtil.GetValue<decimal?>(tc_amt_d_price,true)},
                        { "cust_name", variableUtil.GetValue<string>(t_name,true)},
                        { "item", variableUtil.GetValue<string>(t_coitem_item,true)},
                        { "ord_disc", variableUtil.GetValue<decimal?>(t_co_disc,true)},
                        { "description", variableUtil.GetValue<string>(t_coitem_description,true)},
                        { "cust_item", variableUtil.GetValue<string>(t_ci,true)},
                        { "cost_each", variableUtil.GetValue<decimal?>(tc_cpr_cost,true)},
                        { "price_each", variableUtil.GetValue<decimal?>(tc_cpr_d_price,true)},
                        { "u_m", variableUtil.GetValue<string>(t_coitem_u_m,true)},
                        { "curr_code", variableUtil.GetValue<string>(t_curr_code,true)},
                        { "terms", variableUtil.GetValue<string>(t_terms,true)},
                        { "misc_charges", variableUtil.GetValue<decimal?>(dom_tc_amt_misc_charges,true)},
                        { "sales_tax", variableUtil.GetValue<decimal?>(dom_tc_amt_sales_tax + dom_tc_amt_sales_tax_2,true)},
                        { "tax_code1", variableUtil.GetValue<string>(t_co_tax_code1,true)},
                        { "tax_code2", variableUtil.GetValue<string>(t_co_tax_code2,true)},
                        { "total_cost", variableUtil.GetValue<decimal?>(t_co_cost,true)},
                        { "total_price", variableUtil.GetValue<decimal?>(dom_tc_amt_price,true)},
                        { "coitem_RowPointer", variableUtil.GetValue<Guid?>(sQLUtil.SQLEqual(CoitemNoteExistsFlag, 1) == true ? t_coitem_RowPointer : null, true)},
                        { "co_RowPointer", variableUtil.GetValue<Guid?>(sQLUtil.SQLEqual(CoNoteExistsFlag, 1) == true ? t_co_RowPointer : null, true)},
                        { "sales_tax_2", variableUtil.GetValue<decimal?>(dom_tc_amt_sales_tax_2,true)},
                        { "co_note_exists_flag", variableUtil.GetValue<int?>(CoNoteExistsFlag,true)},
                        { "coitem_note_exists_flag", variableUtil.GetValue<int?>(CoitemNoteExistsFlag,true)},
                    });

                var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                Data = nonTableLoadResponse;
                #endregion CRUD LoadResponseWithoutTable

                #region CRUD InsertByRecords
                var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#rpt_set",
                    items: nonTableLoadResponse.Items);

                this.appDB.Insert(nonTableInsertRequest);
                #endregion InsertByRecords

                //END
            }
            curLoadResponseForCursor = null;
            //Deallocate Cursor @cur
            if (sQLUtil.SQLEqual(PrintDetail, 1) == true)
            {
                //BEGIN
                #region CRUD LoadToRecord
                var rpt_set4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"seq","seq"},
                        {"group_value","group_value"},
                        {"co_num","co_num"},
                        {"cust_num","cust_num"},
                        {"prospect_id","prospect_id"},
                        {"quoted_date","quoted_date"},
                        {"expired_date","expired_date"},
                        {"status","status"},
                        {"co_line","co_line"},
                        {"due_date","due_date"},
                        {"ref","ref"},
                        {"qty_ordered","qty_ordered"},
                        {"ln_disc","ln_disc"},
                        {"net_cost","net_cost"},
                        {"net_price","net_price"},
                        {"cust_name","cust_name"},
                        {"item","item"},
                        {"ord_disc","ord_disc"},
                        {"description","description"},
                        {"cust_item","cust_item"},
                        {"cost_each","cost_each"},
                        {"price_each","price_each"},
                        {"u_m","u_m"},
                        {"curr_code","curr_code"},
                        {"terms","terms"},
                        {"misc_charges","misc_charges"},
                        {"sales_tax","sales_tax"},
                        {"tax_code1","tax_code1"},
                        {"tax_code2","tax_code2"},
                        {"total_cost","total_cost"},
                        {"total_price","total_price"},
                        {"coitem_RowPointer","coitem_RowPointer"},
                        {"co_RowPointer","co_RowPointer"},
                        {"sales_tax_2","sales_tax_2"},
                        {"note_type","note_type"},
                        {"note_text","note_text"},
                        {"tax_amt_label1",$"{variableUtil.GetValue<string>(t_tax_amt_label1)}"},
                        {"tax_amt_label2",$"{variableUtil.GetValue<string>(t_tax_amt_label2)}"},
                        {"co_note_exists_flag","co_note_exists_flag"},
                        {"coitem_note_exists_flag","coitem_note_exists_flag"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#rpt_set",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(" group_value, co_num, seq"));
                var rpt_set4LoadResponse = this.appDB.Load(rpt_set4LoadRequest);
                #endregion  LoadToRecord

                Data = rpt_set4LoadResponse;

                //END
            }
            else
            {
                //BEGIN
                #region CRUD LoadArbitrary
                var rpt_set6LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"seq","seq"},
                        {"group_value","group_value"},
                        {"co_num","co_num"},
                        {"cust_num","cust_num"},
                        {"prospect_id","prospect_id"},
                        {"quoted_date","quoted_date"},
                        {"expired_date","expired_date"},
                        {"status","status"},
                        {"co_line","NULL"},
                        {"due_date","NULL"},
                        {"ref","NULL"},
                        {"qty_ordered","NULL"},
                        {"ln_disc","NULL"},
                        {"net_cost","NULL"},
                        {"net_price","NULL"},
                        {"cust_name","cust_name"},
                        {"item","NULL"},
                        {"ord_disc","ord_disc"},
                        {"description","NULL"},
                        {"cust_item","NULL"},
                        {"cost_each","NULL"},
                        {"price_each","NULL"},
                        {"u_m","NULL"},
                        {"curr_code","curr_code"},
                        {"terms","terms"},
                        {"misc_charges","misc_charges"},
                        {"sales_tax","sales_tax"},
                        {"tax_code1","tax_code1"},
                        {"tax_code2","tax_code2"},
                        {"total_cost","total_cost"},
                        {"total_price","total_price"},
                        {"coitem_RowPointer","NULL"},
                        {"co_RowPointer","co_RowPointer"},
                        {"sales_tax_2","sales_tax_2"},
                        {"note_type","note_type"},
                        {"note_text","note_text"},
                        {"tax_amt_label1",$"{variableUtil.GetValue<string>(t_tax_amt_label1)}"},
                        {"tax_amt_label2",$"{variableUtil.GetValue<string>(t_tax_amt_label2)}"},
                        {"co_note_exists_flag","co_note_exists_flag"},
                        {"coitem_note_exists_flag","NULL"},
                    },
                    selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList  
                        FROM #rpt_set 
                        ORDER BY group_value, co_num, seq"));

                var rpt_set6LoadResponse = this.appDB.Load(rpt_set6LoadRequest);
                Data = rpt_set6LoadResponse;
                #endregion  LoadArbitrary

                //END
            }
            this.transactionFactory.CommitTransaction("");

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: CloseSessionContextSp
            var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

            #endregion ExecuteMethodCall

            return (Data, Severity);
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_EstimateStatusSp(string AltExtGenSp,
            string OrderStarting = null,
            string OrderEnding = null,
            string EstStatus = null,
            string CustomerStarting = null,
            string CustomerEnding = null,
            DateTime? QuoteDateStarting = null,
            DateTime? QuoteDateEnding = null,
            int? QuoteDateStartingOffset = null,
            int? QuoteDateEndingOffset = null,
            DateTime? ExpDateStarting = null,
            DateTime? ExpDateEnding = null,
            int? ExpDateStartingOffset = null,
            int? ExpDateEndingOffset = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string CustItemStarting = null,
            string CustItemEnding = null,
            DateTime? DueDateStarting = null,
            DateTime? DueDateEnding = null,
            int? DueDateStartingOffset = null,
            int? DueDateEndingOffset = null,
            int? PrintDetail = null,
            string SortBy = null,
            int? ShowCONotes = null,
            int? ShowLineRelNotes = null,
            int? ShowInternal = null,
            int? ShowExternal = null,
            int? PrintCost = 0,
            int? DisplayHeader = null,
            string StartProspect = null,
            string EndProspect = null,
            string BGSessionId = null,
            string pSite = null,
            string BGUser = null)
        {
            CoNumType _OrderStarting = OrderStarting;
            CoNumType _OrderEnding = OrderEnding;
            InfobarType _EstStatus = EstStatus;
            CustNumType _CustomerStarting = CustomerStarting;
            CustNumType _CustomerEnding = CustomerEnding;
            DateType _QuoteDateStarting = QuoteDateStarting;
            DateType _QuoteDateEnding = QuoteDateEnding;
            DateOffsetType _QuoteDateStartingOffset = QuoteDateStartingOffset;
            DateOffsetType _QuoteDateEndingOffset = QuoteDateEndingOffset;
            DateType _ExpDateStarting = ExpDateStarting;
            DateType _ExpDateEnding = ExpDateEnding;
            DateOffsetType _ExpDateStartingOffset = ExpDateStartingOffset;
            DateOffsetType _ExpDateEndingOffset = ExpDateEndingOffset;
            ItemType _ItemStarting = ItemStarting;
            ItemType _ItemEnding = ItemEnding;
            CustItemType _CustItemStarting = CustItemStarting;
            CustItemType _CustItemEnding = CustItemEnding;
            DateType _DueDateStarting = DueDateStarting;
            DateType _DueDateEnding = DueDateEnding;
            DateOffsetType _DueDateStartingOffset = DueDateStartingOffset;
            DateOffsetType _DueDateEndingOffset = DueDateEndingOffset;
            FlagNyType _PrintDetail = PrintDetail;
            InfobarType _SortBy = SortBy;
            FlagNyType _ShowCONotes = ShowCONotes;
            FlagNyType _ShowLineRelNotes = ShowLineRelNotes;
            FlagNyType _ShowInternal = ShowInternal;
            FlagNyType _ShowExternal = ShowExternal;
            ListYesNoType _PrintCost = PrintCost;
            FlagNyType _DisplayHeader = DisplayHeader;
            ProspectIDType _StartProspect = StartProspect;
            ProspectIDType _EndProspect = EndProspect;
            StringType _BGSessionId = BGSessionId;
            SiteType _pSite = pSite;
            UsernameType _BGUser = BGUser;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EstStatus", _EstStatus, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QuoteDateStarting", _QuoteDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QuoteDateEnding", _QuoteDateEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QuoteDateStartingOffset", _QuoteDateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QuoteDateEndingOffset", _QuoteDateEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExpDateStarting", _ExpDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExpDateEnding", _ExpDateEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExpDateStartingOffset", _ExpDateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExpDateEndingOffset", _ExpDateEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustItemStarting", _CustItemStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustItemEnding", _CustItemEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DueDateStarting", _DueDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DueDateEnding", _DueDateEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DueDateStartingOffset", _DueDateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DueDateEndingOffset", _DueDateEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintDetail", _PrintDetail, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowCONotes", _ShowCONotes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowLineRelNotes", _ShowLineRelNotes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartProspect", _StartProspect, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndProspect", _EndProspect, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);

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
