//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransferOrderStatus.cs

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
using CSI.Logistics.Customer;
using CSI.Material;
using CSI.DataCollection;

namespace CSI.Reporting
{
    public class Rpt_TransferOrderStatus : IRpt_TransferOrderStatus
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly IProcessShipmentProcess iProcessShipmentProcess;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICloseSessionContext iCloseSessionContext;
        readonly IInitSessionContext iInitSessionContext;
        readonly IAddProcessErrorLog iAddProcessErrorLog;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IUomConvQty iUomConvQty;
        readonly IStringUtil stringUtil;
        readonly IRaiseError raiseError;
        readonly ILowDate iLowDate;
        readonly IGetumcf iGetumcf;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ILowCharacter lowCharacter;
        readonly IHighCharacter highCharacter;
        public Rpt_TransferOrderStatus(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            IProcessShipmentProcess iProcessShipmentProcess,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICloseSessionContext iCloseSessionContext,
            IInitSessionContext iInitSessionContext,
            IAddProcessErrorLog iAddProcessErrorLog,
            ITransactionFactory transactionFactory,
            IGetIsolationLevel iGetIsolationLevel,
            IApplyDateOffset iApplyDateOffset,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IUomConvQty iUomConvQty,
            IStringUtil stringUtil,
            IRaiseError raiseError,
            ILowDate iLowDate,
            IGetumcf iGetumcf,
            ISQLValueComparerUtil sQLUtil,
            ILowCharacter lowCharacter,
            IHighCharacter highCharacter)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.iProcessShipmentProcess = iProcessShipmentProcess;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iCloseSessionContext = iCloseSessionContext;
            this.iInitSessionContext = iInitSessionContext;
            this.iAddProcessErrorLog = iAddProcessErrorLog;
            this.transactionFactory = transactionFactory;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.iApplyDateOffset = iApplyDateOffset;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.iUomConvQty = iUomConvQty;
            this.stringUtil = stringUtil;
            this.raiseError = raiseError;
            this.iLowDate = iLowDate;
            this.iGetumcf = iGetumcf;
            this.sQLUtil = sQLUtil;
            this.lowCharacter = lowCharacter;
            this.highCharacter = highCharacter;
        }

        public (ICollectionLoadResponse Data,
            int? ReturnCode) 
        Rpt_TransferOrderStatusSp(
            string TransOrderStarting = null,
            string TransOrderEnding = null,
            string ExOptszTransferStat = null,
            string ExOptszTrnitemStat = null,
            int? ExOptprQtyLoss = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string FromSiteStarting = null,
            string FromSiteEnding = null,
            string ToSiteStarting = null,
            string ToSiteEnding = null,
            string FromWhseStarting = null,
            string FromWhseEnding = null,
            string TransitLocStarting = null,
            string TransitLocEnding = null,
            string ToWhseStarting = null,
            string ToWhseEnding = null,
            DateTime? SchRcptDateStarting = null,
            DateTime? SchRcptDateEnding = null,
            DateTime? SchShipDateStarting = null,
            DateTime? SchShipDateEnding = null,
            DateTime? LastRcptStarting = null,
            DateTime? LastRcptEnding = null,
            string OrderBy = null,
            int? QuantityInTransitOnly = null,
            int? SchRcptDateStartingOffset = null,
            int? SchRcptDateEndingOffset = null,
            int? SchShipDateStartingOffset = null,
            int? SchShipDateEndingOffset = null,
            int? LastRcptStartingOffset = null,
            int? LastRcptEndingOffset = null,
            DateTime? OrderDateStarting = null,
            DateTime? OrderDateEnding = null,
            int? OrderDateStartingOffset = null,
            int? OrderDateEndingOffset = null,
            int? DisplayHeader = null,
            int? TaskId = null,
            string pSite = null)
        {
            ICollectionLoadResponse Data = null;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            Guid? RptSessionID = null;
            string LowCharValue = null;
            string HighCharValue = null;
            DateTime? LowDate = null;
            int? Severity = null;
            decimal? TcQtuToRecLost = null;
            string TFromTrnLoc = null;
            string TToTrnLoc = null;
            string TransferStat = null;
            string TransferToSite = null;
            string TransferFobSite = null;
            string TransferFromSite = null;
            string TransferTrnNum = null;
            string TransferFromWhse = null;
            string TransferToWhse = null;
            string ItemDescription = null;
            decimal? ItemUnitCost = null;
            DateTime? TransferOrderDate = null;
            string TrnitemItem = null;
            string TrnitemUM = null;
            decimal? TrnitemQtyShipped = null;
            decimal? TrnitemQtyReceived = null;
            string TrnitemTrnLoc = null;
            int? TrnitemTrnLine = null;
            DateTime? TrnitemSchRcvDate = null;
            DateTime? TrnitemShipDate = null;
            DateTime? TrnitemRcvdDate = null;
            string TrnitemStat = null;
            decimal? TrnitemQtyLoss = null;
            string Infobar = null;
            decimal? UomConvFactor = null;
            string CUomConvFromBase = null;
            decimal? ValueInTransit = null;
            decimal? QuantityInTransit = null;
            QtyUnitType _ItemLocQtyOnHand = DBNull.Value;
            decimal? ItemLocQtyOnHand = null;
            CostPrcType _ItemLocUnitCost = DBNull.Value;
            decimal? ItemLocUnitCost = null;
            ICollectionLoadRequest curTransferLoadRequestForCursor = null;
            ICollectionLoadResponse curTransferLoadResponseForCursor = null;
            int curTransfer_CursorFetch_Status = -1;
            int curTransfer_CursorCounter = -1;
            string ProcessShipmentTransferTrnNum = null;
            RowPointerType _TrnRowPointer = DBNull.Value;
            Guid? TrnRowPointer = null;
            ICollectionLoadResponse ProcessShipCrsLoadResponseForCursor = null;
            ICollectionLoadStatementRequest ProcessShipCrsLoadStatementRequestForCursor = null;
            int ProcessShipCrs_CursorFetch_Status = -1;
            int ProcessShipCrs_CursorCounter = -1;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_TransferOrderStatusSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_TransferOrderStatusSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_TransferOrderStatusSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_Rpt_TransferOrderStatusSp(_ALTGEN_SpName,
                        TransOrderStarting,
                        TransOrderEnding,
                        ExOptszTransferStat,
                        ExOptszTrnitemStat,
                        ExOptprQtyLoss,
                        ItemStarting,
                        ItemEnding,
                        FromSiteStarting,
                        FromSiteEnding,
                        ToSiteStarting,
                        ToSiteEnding,
                        FromWhseStarting,
                        FromWhseEnding,
                        TransitLocStarting,
                        TransitLocEnding,
                        ToWhseStarting,
                        ToWhseEnding,
                        SchRcptDateStarting,
                        SchRcptDateEnding,
                        SchShipDateStarting,
                        SchShipDateEnding,
                        LastRcptStarting,
                        LastRcptEnding,
                        OrderBy,
                        QuantityInTransitOnly,
                        SchRcptDateStartingOffset,
                        SchRcptDateEndingOffset,
                        SchShipDateStartingOffset,
                        SchShipDateEndingOffset,
                        LastRcptStartingOffset,
                        LastRcptEndingOffset,
                        OrderDateStarting,
                        OrderDateEnding,
                        OrderDateStartingOffset,
                        OrderDateEndingOffset,
                        DisplayHeader,
                        TaskId,
                        pSite);
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
                }
            }

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_TransferOrderStatusSp") != null)
            {
                var EXTGEN = AltExtGen_Rpt_TransferOrderStatusSp("dbo.EXTGEN_Rpt_TransferOrderStatusSp",
                    TransOrderStarting,
                    TransOrderEnding,
                    ExOptszTransferStat,
                    ExOptszTrnitemStat,
                    ExOptprQtyLoss,
                    ItemStarting,
                    ItemEnding,
                    FromSiteStarting,
                    FromSiteEnding,
                    ToSiteStarting,
                    ToSiteEnding,
                    FromWhseStarting,
                    FromWhseEnding,
                    TransitLocStarting,
                    TransitLocEnding,
                    ToWhseStarting,
                    ToWhseEnding,
                    SchRcptDateStarting,
                    SchRcptDateEnding,
                    SchShipDateStarting,
                    SchShipDateEnding,
                    LastRcptStarting,
                    LastRcptEnding,
                    OrderBy,
                    QuantityInTransitOnly,
                    SchRcptDateStartingOffset,
                    SchRcptDateEndingOffset,
                    SchShipDateStartingOffset,
                    SchShipDateEndingOffset,
                    LastRcptStartingOffset,
                    LastRcptEndingOffset,
                    OrderDateStarting,
                    OrderDateEnding,
                    OrderDateStartingOffset,
                    OrderDateEndingOffset,
                    DisplayHeader,
                    TaskId,
                    pSite);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            this.transactionFactory.BeginTransaction("");
            this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("TransferOrderStatusReport"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            }

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InitSessionContextSp
            var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(ContextName: "Rpt_TransferOrderStatusSp"
                , SessionID: RptSessionID
                , Site: pSite);
            RptSessionID = InitSessionContext.SessionID;

            #endregion ExecuteMethodCall

            LowCharValue = convertToUtil.ToString(this.lowCharacter.LowCharacterFn());
            HighCharValue = convertToUtil.ToString(this.highCharacter.HighCharacterFn());
            LowDate = convertToUtil.ToDateTime(this.iLowDate.LowDateFn());
            TransOrderStarting = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("TrnNumType", TransOrderStarting), LowCharValue);
            TransOrderEnding = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("TrnNumType", TransOrderEnding), HighCharValue);
            ItemStarting = stringUtil.IsNull(ItemStarting, LowCharValue);
            ItemEnding = stringUtil.IsNull(ItemEnding, HighCharValue);
            FromSiteStarting = stringUtil.IsNull(FromSiteStarting, LowCharValue);
            FromSiteEnding = stringUtil.IsNull(FromSiteEnding, HighCharValue);
            ToSiteStarting = stringUtil.IsNull(ToSiteStarting, LowCharValue);
            ToSiteEnding = stringUtil.IsNull(ToSiteEnding, HighCharValue);
            FromWhseStarting = stringUtil.IsNull(FromWhseStarting, LowCharValue);
            FromWhseEnding = stringUtil.IsNull(FromWhseEnding, HighCharValue);
            ToWhseStarting = stringUtil.IsNull(ToWhseStarting, LowCharValue);
            ToWhseEnding = stringUtil.IsNull(ToWhseEnding, HighCharValue);
            TransitLocStarting = stringUtil.IsNull(TransitLocStarting, LowCharValue);
            TransitLocEnding = stringUtil.IsNull(TransitLocEnding, HighCharValue);

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(Date: SchRcptDateStarting
                , Offset: SchRcptDateStartingOffset
                , IsEndDate: 0);
            SchRcptDateStarting = ApplyDateOffset.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: SchRcptDateEnding
                , Offset: SchRcptDateEndingOffset
                , IsEndDate: 1);
            SchRcptDateEnding = ApplyDateOffset1.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset2 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: SchShipDateStarting
                , Offset: SchShipDateStartingOffset
                , IsEndDate: 0);
            SchShipDateStarting = ApplyDateOffset2.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset3 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: SchShipDateEnding
                , Offset: SchShipDateEndingOffset
                , IsEndDate: 1);
            SchShipDateEnding = ApplyDateOffset3.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset4 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: LastRcptStarting
                , Offset: LastRcptStartingOffset
                , IsEndDate: 0);
            LastRcptStarting = ApplyDateOffset4.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset5 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: LastRcptEnding
                , Offset: LastRcptEndingOffset
                , IsEndDate: 1);
            LastRcptEnding = ApplyDateOffset5.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset6 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: OrderDateStarting
                , Offset: OrderDateStartingOffset
                , IsEndDate: 0);
            OrderDateStarting = ApplyDateOffset6.Date;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset7 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: OrderDateEnding
                , Offset: OrderDateEndingOffset
                , IsEndDate: 1);
            OrderDateEnding = ApplyDateOffset7.Date;

            #endregion ExecuteMethodCall

            Severity = 0;
            TcQtuToRecLost = 0;
            UomConvFactor = 0;
            CUomConvFromBase = "From Base";
            OrderBy = stringUtil.IsNull(OrderBy, "T");
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @TransferOrderStatus TABLE (
                    TransferTrnNum     TrnNumType        ,
                    TrnitemTrnLine     TrnLineType       ,
                    TrnitemItem        ItemType          ,
                    TransferFromSite   SiteType          ,
                    TransferFromWhse   WhseType          ,
                    TFromTrnLoc        LocType           ,
                    TrnitemSchRcvDate  DateType          ,
                    TrnitemQtyShipped  QtyUnitType       ,
                    TrnitemUM          UMType            ,
                    TransferStat       TransferStatusType,
                    TrnitemStat        TransferStatusType,
                    ItemDescription    DescriptionType   ,
                    TransferToSite     SiteType          ,
                    TransferToWhse     WhseType          ,
                    TToTrnLoc          LocType           ,
                    TrnitemShipDate    DateType          ,
                    TrnitemQtyReceived QtyUnitType       ,
                    TrnitemRcvdDate    DateType          ,
                    TcQtuToRecLost     QtyUnitType       ,
                    ValueInTransit     AmountType        ,
                    QuantityInTransit  AmountType        ,
                    OrderDate          DateType          );
                SELECT * into #tv_TransferOrderStatus from @TransferOrderStatus ");

            if (sQLUtil.SQLNotEqual(OrderBy, "W") == true)
            {

                #region CRUD LoadToRecord
                curTransferLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"stat","transfer.stat"},
                        {"to_site","transfer.to_site"},
                        {"fob_site","transfer.fob_site"},
                        {"from_site","transfer.from_site"},
                        {"trn_num","transfer.trn_num"},
                        {"from_whse","transfer.from_whse"},
                        {"to_whse","transfer.to_whse"},
                        {"order_date","transfer.order_date"},
                        {"item","trnitem.item"},
                        {"u_m","trnitem.u_m"},
                        {"qty_shipped","trnitem.qty_shipped"},
                        {"qty_received","trnitem.qty_received"},
                        {"trn_loc","trnitem.trn_loc"},
                        {"trn_line","trnitem.trn_line"},
                        {"sch_rcv_date","trnitem.sch_rcv_date"},
                        {"ship_date","trnitem.ship_date"},
                        {"rcvd_date","trnitem.rcvd_date"},
                        {"stat_","trnitem.stat"},
                        {"qty_loss","trnitem.qty_loss"},
                        {"description","item.description"},
                        {"col0","CAST (NULL AS DECIMAL)"},
                        {"u0","item.unit_cost"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "transfer",
                    fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN trnitem ON trnitem.trn_num = transfer.trn_num LEFT OUTER JOIN item ON item.item = trnitem.item"),
                    whereClause: collectionLoadRequestFactory.Clause("transfer.trn_num BETWEEN {3} AND {9} AND ISNULL(transfer.from_site, {21}) BETWEEN {10} AND {15} AND ISNULL(transfer.to_site, {21}) BETWEEN {16} AND {22} AND ISNULL(transfer.from_whse, {21}) BETWEEN {11} AND {17} AND ISNULL(transfer.to_whse, {21}) BETWEEN {18} AND {23} AND CHARINDEX(transfer.stat, {0}) <> 0 AND ISNULL(trnitem.item, {21}) BETWEEN {24} AND {25} AND ISNULL(trnitem.trn_loc, {21}) BETWEEN {4} AND {12} AND CHARINDEX(trnitem.stat, {5}) <> 0 AND ISNULL(trnitem.sch_rcv_date, {26}) BETWEEN {1} AND {6} AND ISNULL(trnitem.sch_ship_date, {26}) BETWEEN {2} AND {7} AND ISNULL(transfer.order_date, {26}) BETWEEN {8} AND {14} AND ISNULL(trnitem.rcvd_date, {26}) BETWEEN {13} AND {19} AND ({20} = 0 OR ({20} = 1 AND (trnitem.qty_shipped - trnitem.qty_received) > 0))", ExOptszTransferStat, SchRcptDateStarting, SchShipDateStarting, TransOrderStarting, TransitLocStarting, ExOptszTrnitemStat, SchRcptDateEnding, SchShipDateEnding, OrderDateStarting, TransOrderEnding, FromSiteStarting, FromWhseStarting, TransitLocEnding, LastRcptStarting, OrderDateEnding, FromSiteEnding, ToSiteStarting, FromWhseEnding, ToWhseStarting, LastRcptEnding, ExOptprQtyLoss, LowCharValue, ToSiteEnding, ToWhseEnding, ItemStarting, ItemEnding, LowDate),
                    orderByClause: collectionLoadRequestFactory.Clause(" transfer.trn_num"));
                #endregion  LoadToRecord

                curTransferLoadResponseForCursor = this.appDB.Load(curTransferLoadRequestForCursor);
                foreach (var transferItem in curTransferLoadResponseForCursor.Items)
                {
                    transferItem.SetValue<string>("stat", transferItem.GetValue<string>("stat"));
                    transferItem.SetValue<string>("to_site", transferItem.GetValue<string>("to_site"));
                    transferItem.SetValue<string>("fob_site", transferItem.GetValue<string>("fob_site"));
                    transferItem.SetValue<string>("from_site", transferItem.GetValue<string>("from_site"));
                    transferItem.SetValue<string>("trn_num", transferItem.GetValue<string>("trn_num"));
                    transferItem.SetValue<string>("from_whse", transferItem.GetValue<string>("from_whse"));
                    transferItem.SetValue<string>("to_whse", transferItem.GetValue<string>("to_whse"));
                    transferItem.SetValue<DateTime?>("order_date", transferItem.GetValue<DateTime?>("order_date"));
                    transferItem.SetValue<string>("item", transferItem.GetValue<string>("item"));
                    transferItem.SetValue<string>("u_m", transferItem.GetValue<string>("u_m"));
                    transferItem.SetValue<decimal?>("qty_shipped", transferItem.GetValue<decimal?>("qty_shipped"));
                    transferItem.SetValue<decimal?>("qty_received", transferItem.GetValue<decimal?>("qty_received"));
                    transferItem.SetValue<string>("trn_loc", transferItem.GetValue<string>("trn_loc"));
                    transferItem.SetValue<int?>("trn_line", transferItem.GetValue<int?>("trn_line"));
                    transferItem.SetValue<DateTime?>("sch_rcv_date", transferItem.GetValue<DateTime?>("sch_rcv_date"));
                    transferItem.SetValue<DateTime?>("ship_date", transferItem.GetValue<DateTime?>("ship_date"));
                    transferItem.SetValue<DateTime?>("rcvd_date", transferItem.GetValue<DateTime?>("rcvd_date"));
                    transferItem.SetValue<string>("stat_", transferItem.GetValue<string>("stat_"));
                    transferItem.SetValue<decimal?>("qty_loss", transferItem.GetValue<decimal?>("qty_loss"));
                    transferItem.SetValue<string>("description", transferItem.GetValue<string>("description"));
                    transferItem.SetValue<decimal?>("col0", stringUtil.IsNull<decimal?>(transferItem.GetValue<decimal?>("u0"), 0));
                };

                curTransfer_CursorFetch_Status = curTransferLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                curTransfer_CursorCounter = -1;
            }
            else
            {

                #region CRUD LoadToRecord
                curTransferLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"stat","transfer.stat"},
                        {"to_site","transfer.to_site"},
                        {"fob_site","transfer.fob_site"},
                        {"from_site","transfer.from_site"},
                        {"trn_num","transfer.trn_num"},
                        {"from_whse","transfer.from_whse"},
                        {"to_whse","transfer.to_whse"},
                        {"order_date","transfer.order_date"},
                        {"item","trnitem.item"},
                        {"u_m","trnitem.u_m"},
                        {"qty_shipped","trnitem.qty_shipped"},
                        {"qty_received","trnitem.qty_received"},
                        {"trn_loc","trnitem.trn_loc"},
                        {"trn_line","trnitem.trn_line"},
                        {"sch_rcv_date","trnitem.sch_rcv_date"},
                        {"ship_date","trnitem.ship_date"},
                        {"rcvd_date","trnitem.rcvd_date"},
                        {"stat_","trnitem.stat"},
                        {"qty_loss","trnitem.qty_loss"},
                        {"description","item.description"},
                        {"col0","CAST (NULL AS DECIMAL)"},
                        {"u0","item.unit_cost"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "transfer",
                    fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN trnitem ON trnitem.trn_num = transfer.trn_num LEFT OUTER JOIN item ON item.item = trnitem.item"),
                    whereClause: collectionLoadRequestFactory.Clause("transfer.trn_num BETWEEN {3} AND {9} AND ISNULL(transfer.from_site, {21}) BETWEEN {10} AND {15} AND ISNULL(transfer.to_site, {21}) BETWEEN {16} AND {22} AND ISNULL(transfer.from_whse, {21}) BETWEEN {11} AND {17} AND ISNULL(transfer.to_whse, {21}) BETWEEN {18} AND {23} AND CHARINDEX(transfer.stat, {0}) <> 0 AND ISNULL(trnitem.item, {21}) BETWEEN {24} AND {25} AND ISNULL(trnitem.trn_loc, {21}) BETWEEN {4} AND {12} AND CHARINDEX(trnitem.stat, {5}) <> 0 AND ISNULL(trnitem.sch_rcv_date, {26}) BETWEEN {1} AND {6} AND ISNULL(trnitem.sch_ship_date, {26}) BETWEEN {2} AND {7} AND ISNULL(trnitem.rcvd_date, {26}) BETWEEN {13} AND {19} AND ISNULL(transfer.order_date, {26}) BETWEEN {8} AND {14} AND ({20} = 0 OR ({20} = 1 AND (trnitem.qty_shipped - trnitem.qty_received) > 0))", ExOptszTransferStat, SchRcptDateStarting, SchShipDateStarting, TransOrderStarting, TransitLocStarting, ExOptszTrnitemStat, SchRcptDateEnding, SchShipDateEnding, OrderDateStarting, TransOrderEnding, FromSiteStarting, FromWhseStarting, TransitLocEnding, LastRcptStarting, OrderDateEnding, FromSiteEnding, ToSiteStarting, FromWhseEnding, ToWhseStarting, LastRcptEnding, ExOptprQtyLoss, LowCharValue, ToSiteEnding, ToWhseEnding, ItemStarting, ItemEnding, LowDate),
                    orderByClause: collectionLoadRequestFactory.Clause(" transfer.from_whse, transfer.to_whse"));
                #endregion  LoadToRecord

                curTransferLoadResponseForCursor = this.appDB.Load(curTransferLoadRequestForCursor);
                foreach (var transfer1Item in curTransferLoadResponseForCursor.Items)
                {
                    transfer1Item.SetValue<string>("stat", transfer1Item.GetValue<string>("stat"));
                    transfer1Item.SetValue<string>("to_site", transfer1Item.GetValue<string>("to_site"));
                    transfer1Item.SetValue<string>("fob_site", transfer1Item.GetValue<string>("fob_site"));
                    transfer1Item.SetValue<string>("from_site", transfer1Item.GetValue<string>("from_site"));
                    transfer1Item.SetValue<string>("trn_num", transfer1Item.GetValue<string>("trn_num"));
                    transfer1Item.SetValue<string>("from_whse", transfer1Item.GetValue<string>("from_whse"));
                    transfer1Item.SetValue<string>("to_whse", transfer1Item.GetValue<string>("to_whse"));
                    transfer1Item.SetValue<DateTime?>("order_date", transfer1Item.GetValue<DateTime?>("order_date"));
                    transfer1Item.SetValue<string>("item", transfer1Item.GetValue<string>("item"));
                    transfer1Item.SetValue<string>("u_m", transfer1Item.GetValue<string>("u_m"));
                    transfer1Item.SetValue<decimal?>("qty_shipped", transfer1Item.GetValue<decimal?>("qty_shipped"));
                    transfer1Item.SetValue<decimal?>("qty_received", transfer1Item.GetValue<decimal?>("qty_received"));
                    transfer1Item.SetValue<string>("trn_loc", transfer1Item.GetValue<string>("trn_loc"));
                    transfer1Item.SetValue<int?>("trn_line", transfer1Item.GetValue<int?>("trn_line"));
                    transfer1Item.SetValue<DateTime?>("sch_rcv_date", transfer1Item.GetValue<DateTime?>("sch_rcv_date"));
                    transfer1Item.SetValue<DateTime?>("ship_date", transfer1Item.GetValue<DateTime?>("ship_date"));
                    transfer1Item.SetValue<DateTime?>("rcvd_date", transfer1Item.GetValue<DateTime?>("rcvd_date"));
                    transfer1Item.SetValue<string>("stat_", transfer1Item.GetValue<string>("stat_"));
                    transfer1Item.SetValue<decimal?>("qty_loss", transfer1Item.GetValue<decimal?>("qty_loss"));
                    transfer1Item.SetValue<string>("description", transfer1Item.GetValue<string>("description"));
                    transfer1Item.SetValue<decimal?>("col0", stringUtil.IsNull<decimal?>(transfer1Item.GetValue<decimal?>("u0"), 0));
                };

                curTransfer_CursorFetch_Status = curTransferLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                curTransfer_CursorCounter = -1;
            }
            while (sQLUtil.SQLEqual(0, 0) == true)
            {
                curTransfer_CursorCounter++;
                if (curTransferLoadResponseForCursor.Items.Count > curTransfer_CursorCounter)
                {
                    TransferStat = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(0);
                    TransferToSite = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(1);
                    TransferFobSite = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(2);
                    TransferFromSite = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(3);
                    TransferTrnNum = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(4);
                    TransferFromWhse = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(5);
                    TransferToWhse = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(6);
                    TransferOrderDate = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<DateTime?>(7);
                    TrnitemItem = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(8);
                    TrnitemUM = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(9);
                    TrnitemQtyShipped = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<decimal?>(10);
                    TrnitemQtyReceived = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<decimal?>(11);
                    TrnitemTrnLoc = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(12);
                    TrnitemTrnLine = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<int?>(13);
                    TrnitemSchRcvDate = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<DateTime?>(14);
                    TrnitemShipDate = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<DateTime?>(15);
                    TrnitemRcvdDate = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<DateTime?>(16);
                    TrnitemStat = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(17);
                    TrnitemQtyLoss = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<decimal?>(18);
                    ItemDescription = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<string>(19);
                    ItemUnitCost = curTransferLoadResponseForCursor.Items[curTransfer_CursorCounter].GetValue<decimal?>(20);
                }
                curTransfer_CursorFetch_Status = (curTransfer_CursorCounter == curTransferLoadResponseForCursor.Items.Count ? -1 : 0);

                if (sQLUtil.SQLEqual(curTransfer_CursorFetch_Status, -1) == true)
                {
                    break;
                }
                ItemLocQtyOnHand = 0;
                ItemLocUnitCost = 0;
                if (sQLUtil.SQLEqual(TrnitemStat, "T") == true)
                {
                    #region CRUD LoadToVariable
                    var itemlocLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_ItemLocQtyOnHand,"itemloc.qty_on_hand"},
                            {_ItemLocUnitCost,"itemloc.unit_cost"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "itemloc",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("itemloc.item = {1} AND itemloc.loc = {0} AND itemloc.loc_type = 'T' AND itemloc.qty_on_hand <> 0", TrnitemTrnLoc, TrnitemItem),
                        orderByClause: collectionLoadRequestFactory.Clause(" itemloc.whse, itemloc.loc"));
                    
                    var itemlocLoadResponse = this.appDB.Load(itemlocLoadRequest);
                    if (itemlocLoadResponse.Items.Count > 0)
                    {
                        ItemLocQtyOnHand = _ItemLocQtyOnHand;
                        ItemLocUnitCost = _ItemLocUnitCost;
                    }
                    #endregion  LoadToVariable
                }
                QuantityInTransit = (decimal?)(TrnitemQtyShipped - TrnitemQtyReceived - TrnitemQtyLoss);
                ValueInTransit = (decimal?)(QuantityInTransit * ItemLocUnitCost);
                if (sQLUtil.SQLEqual(ValueInTransit, 0) == true)
                {
                    ValueInTransit = (decimal?)(QuantityInTransit * ItemUnitCost);
                }

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: GetumcfSp
                var Getumcf = this.iGetumcf.GetumcfSp(OtherUM: TrnitemUM
                    , Item: TrnitemItem
                    , VendNum: ""
                    , Area: ""
                    , ConvFactor: UomConvFactor
                    , Infobar: Infobar);
                Severity = Getumcf.ReturnCode;
                UomConvFactor = Getumcf.ConvFactor;
                Infobar = Getumcf.Infobar;

                #endregion ExecuteMethodCall

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    goto END_OF_PROG;
                }

                TcQtuToRecLost = convertToUtil.ToDecimal(this.iUomConvQty.UomConvQtyFn(TrnitemQtyShipped - TrnitemQtyReceived, UomConvFactor, CUomConvFromBase));
                TFromTrnLoc = (sQLUtil.SQLEqual(TransferToSite, TransferFobSite) == true && sQLUtil.SQLNotEqual(TransferFromSite, TransferToSite) == true ? TrnitemTrnLoc : "");
                TToTrnLoc = (sQLUtil.SQLEqual(stringUtil.IsNull(TransferFromSite, ""), stringUtil.IsNull(TransferFobSite, "")) == true ? TrnitemTrnLoc : "");

                #region CRUD LoadResponseWithoutTable
                var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                    {
                        { "TransferTrnNum", variableUtil.GetValue<string>(TransferTrnNum,true)},
                        { "TrnitemTrnLine", variableUtil.GetValue<int?>(TrnitemTrnLine,true)},
                        { "TrnitemItem", variableUtil.GetValue<string>(TrnitemItem,true)},
                        { "TransferFromSite", variableUtil.GetValue<string>(TransferFromSite,true)},
                        { "TransferFromWhse", variableUtil.GetValue<string>(TransferFromWhse,true)},
                        { "TFromTrnLoc", variableUtil.GetValue<string>(TFromTrnLoc,true)},
                        { "TrnitemSchRcvDate", variableUtil.GetValue<DateTime?>(TrnitemSchRcvDate,true)},
                        { "TrnitemQtyShipped", variableUtil.GetValue<decimal?>(this.iUomConvQty.UomConvQtyFn(TrnitemQtyShipped,UomConvFactor,CUomConvFromBase),true)},
                        { "TrnitemUM", variableUtil.GetValue<string>(TrnitemUM,true)},
                        { "TransferStat", variableUtil.GetValue<string>(TransferStat,true)},
                        { "TrnitemStat", variableUtil.GetValue<string>(TrnitemStat,true)},
                        { "ItemDescription", variableUtil.GetValue<string>(ItemDescription,true)},
                        { "TransferToSite", variableUtil.GetValue<string>(TransferToSite,true)},
                        { "TransferToWhse", variableUtil.GetValue<string>(TransferToWhse,true)},
                        { "TToTrnLoc", variableUtil.GetValue<string>(TToTrnLoc,true)},
                        { "TrnitemShipDate", variableUtil.GetValue<DateTime?>(TrnitemShipDate,true)},
                        { "TrnitemQtyReceived", variableUtil.GetValue<decimal?>(this.iUomConvQty.UomConvQtyFn(TrnitemQtyReceived,UomConvFactor,CUomConvFromBase),true)},
                        { "TrnitemRcvdDate", variableUtil.GetValue<DateTime?>(TrnitemRcvdDate,true)},
                        { "TcQtuToRecLost", variableUtil.GetValue<decimal?>(TcQtuToRecLost,true)},
                        { "ValueInTransit", variableUtil.GetValue<decimal?>(ValueInTransit,true)},
                        { "QuantityInTransit", variableUtil.GetValue<decimal?>(this.iUomConvQty.UomConvQtyFn(QuantityInTransit,UomConvFactor,CUomConvFromBase),true)},
                        { "OrderDate", variableUtil.GetValue<DateTime?>(TransferOrderDate,true)},
                    });

                var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                Data = nonTableLoadResponse;
                #endregion CRUD LoadResponseWithoutTable

                #region CRUD InsertByRecords
                var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_TransferOrderStatus",
                    items: nonTableLoadResponse.Items);

                this.appDB.Insert(nonTableInsertRequest);
                #endregion InsertByRecords
            }
            curTransferLoadResponseForCursor = null;
        //Deallocate Cursor @curTransfer
        END_OF_PROG:;
            if (sQLUtil.SQLNotEqual(Severity, 0) == true)
            {
                if (TaskId != null)
                {
                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: AddProcessErrorLogSp
                    var AddProcessErrorLog = this.iAddProcessErrorLog.AddProcessErrorLogSp(ProcessID: TaskId
                        , InfobarText: Infobar
                        , MessageSeverity: Severity);

                    #endregion ExecuteMethodCall
                }
            }
            if (sQLUtil.SQLEqual(QuantityInTransitOnly, 1) == true)
            {
                #region CRUD LoadColumn
                var tv_TransferOrderStatusLoadRequest = collectionLoadRequestFactory.SQLLoad(columns: new List<string>()
                    {
                        "TransferTrnNum",
                        "TrnitemTrnLine",
                        "TrnitemItem",
                        "TransferFromSite",
                        "TransferFromWhse",
                        "TFromTrnLoc",
                        "TrnitemSchRcvDate",
                        "TrnitemQtyShipped",
                        "TrnitemUM",
                        "TransferStat",
                        "TrnitemStat",
                        "ItemDescription",
                        "TransferToSite",
                        "TransferToWhse",
                        "TToTrnLoc",
                        "TrnitemShipDate",
                        "TrnitemQtyReceived",
                        "TrnitemRcvdDate",
                        "TcQtuToRecLost",
                        "ValueInTransit",
                        "QuantityInTransit",
                        "OrderDate",
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#tv_TransferOrderStatus",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("QuantityInTransit <> 0 AND {0} = 0", Severity),
                    orderByClause: collectionLoadRequestFactory.Clause(""));

                var tv_TransferOrderStatusLoadResponse = this.appDB.Load(tv_TransferOrderStatusLoadRequest);
                Data = tv_TransferOrderStatusLoadResponse;
                #endregion  LoadColumn
            }
            else
            {
                #region CRUD LoadColumn
                var tv_TransferOrderStatus1LoadRequest = collectionLoadRequestFactory.SQLLoad(columns: new List<string>()
                    {
                        "TransferTrnNum",
                        "TrnitemTrnLine",
                        "TrnitemItem",
                        "TransferFromSite",
                        "TransferFromWhse",
                        "TFromTrnLoc",
                        "TrnitemSchRcvDate",
                        "TrnitemQtyShipped",
                        "TrnitemUM",
                        "TransferStat",
                        "TrnitemStat",
                        "ItemDescription",
                        "TransferToSite",
                        "TransferToWhse",
                        "TToTrnLoc",
                        "TrnitemShipDate",
                        "TrnitemQtyReceived",
                        "TrnitemRcvdDate",
                        "TcQtuToRecLost",
                        "ValueInTransit",
                        "QuantityInTransit",
                        "OrderDate",
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#tv_TransferOrderStatus",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("{0} = 0", Severity),
                    orderByClause: collectionLoadRequestFactory.Clause(""));

                var tv_TransferOrderStatus1LoadResponse = this.appDB.Load(tv_TransferOrderStatus1LoadRequest);
                Data = tv_TransferOrderStatus1LoadResponse;
                #endregion  LoadColumn
            }
            #region Cursor Statement

            #region CRUD LoadArbitrary
            ProcessShipCrsLoadStatementRequestForCursor = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"Rep.TransferTrnNum","Rep.TransferTrnNum"},
                },
                selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList  
                    FROM #tv_TransferOrderStatus AS Rep 
                         INNER JOIN 
                         whse_all AS whs 
                         ON whs.whse = Rep.TransferFromWhse 
                            AND whs.site_ref = Rep.TransferFromSite 
                            AND whs.controlled_by_external_wms = 1 
                    WHERE {0} = 0", Severity));

            #endregion  LoadArbitrary

            #endregion Cursor Statement
            ProcessShipCrsLoadResponseForCursor = this.appDB.Load(ProcessShipCrsLoadStatementRequestForCursor);
            ProcessShipCrs_CursorFetch_Status = ProcessShipCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
            ProcessShipCrs_CursorCounter = -1;

            Severity = 0;
            while (sQLUtil.SQLEqual(Severity, 0) == true)
            {
                ProcessShipCrs_CursorCounter++;
                if (ProcessShipCrsLoadResponseForCursor.Items.Count > ProcessShipCrs_CursorCounter)
                {
                    ProcessShipmentTransferTrnNum = ProcessShipCrsLoadResponseForCursor.Items[ProcessShipCrs_CursorCounter].GetValue<string>(0);
                }
                ProcessShipCrs_CursorFetch_Status = (ProcessShipCrs_CursorCounter == ProcessShipCrsLoadResponseForCursor.Items.Count ? -1 : 0);

                if (sQLUtil.SQLEqual(ProcessShipCrs_CursorFetch_Status, -1) == true)
                {
                    break;
                }

                #region CRUD LoadToVariable
                var transferLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_TrnRowPointer,"rowpointer"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "[transfer]",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("trn_num = {0}", ProcessShipmentTransferTrnNum),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var transferLoadResponse = this.appDB.Load(transferLoadRequest);
                if (transferLoadResponse.Items.Count > 0)
                {
                    TrnRowPointer = _TrnRowPointer;
                }
                #endregion  LoadToVariable

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ProcessShipmentProcessSp
                var ProcessShipmentProcess = this.iProcessShipmentProcess.ProcessShipmentProcessSp(TCoNumRowPointer: null
                    , TCustAddrRowPointer: null
                    , CreditHoldChanged: 0
                    , TrnRowPointer: TrnRowPointer
                    , Infobar: Infobar);
                Severity = ProcessShipmentProcess.ReturnCode;
                Infobar = ProcessShipmentProcess.Infobar;

                #endregion ExecuteMethodCall

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    raiseError.RaiseErrorSp(Infobar, Severity, 1);
                }
            }

            //Deallocate Cursor ProcessShipCrs
            this.transactionFactory.CommitTransaction("");

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: CloseSessionContextSp
            var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

            #endregion ExecuteMethodCall

            return (Data, Severity);
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_TransferOrderStatusSp(string AltExtGenSp,
            string TransOrderStarting = null,
            string TransOrderEnding = null,
            string ExOptszTransferStat = null,
            string ExOptszTrnitemStat = null,
            int? ExOptprQtyLoss = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string FromSiteStarting = null,
            string FromSiteEnding = null,
            string ToSiteStarting = null,
            string ToSiteEnding = null,
            string FromWhseStarting = null,
            string FromWhseEnding = null,
            string TransitLocStarting = null,
            string TransitLocEnding = null,
            string ToWhseStarting = null,
            string ToWhseEnding = null,
            DateTime? SchRcptDateStarting = null,
            DateTime? SchRcptDateEnding = null,
            DateTime? SchShipDateStarting = null,
            DateTime? SchShipDateEnding = null,
            DateTime? LastRcptStarting = null,
            DateTime? LastRcptEnding = null,
            string OrderBy = null,
            int? QuantityInTransitOnly = null,
            int? SchRcptDateStartingOffset = null,
            int? SchRcptDateEndingOffset = null,
            int? SchShipDateStartingOffset = null,
            int? SchShipDateEndingOffset = null,
            int? LastRcptStartingOffset = null,
            int? LastRcptEndingOffset = null,
            DateTime? OrderDateStarting = null,
            DateTime? OrderDateEnding = null,
            int? OrderDateStartingOffset = null,
            int? OrderDateEndingOffset = null,
            int? DisplayHeader = null,
            int? TaskId = null,
            string pSite = null)
        {
            TrnNumType _TransOrderStarting = TransOrderStarting;
            TrnNumType _TransOrderEnding = TransOrderEnding;
            InfobarType _ExOptszTransferStat = ExOptszTransferStat;
            InfobarType _ExOptszTrnitemStat = ExOptszTrnitemStat;
            ListYesNoType _ExOptprQtyLoss = ExOptprQtyLoss;
            ItemType _ItemStarting = ItemStarting;
            ItemType _ItemEnding = ItemEnding;
            SiteType _FromSiteStarting = FromSiteStarting;
            SiteType _FromSiteEnding = FromSiteEnding;
            SiteType _ToSiteStarting = ToSiteStarting;
            SiteType _ToSiteEnding = ToSiteEnding;
            WhseType _FromWhseStarting = FromWhseStarting;
            WhseType _FromWhseEnding = FromWhseEnding;
            LocType _TransitLocStarting = TransitLocStarting;
            LocType _TransitLocEnding = TransitLocEnding;
            WhseType _ToWhseStarting = ToWhseStarting;
            WhseType _ToWhseEnding = ToWhseEnding;
            DateType _SchRcptDateStarting = SchRcptDateStarting;
            DateType _SchRcptDateEnding = SchRcptDateEnding;
            DateType _SchShipDateStarting = SchShipDateStarting;
            DateType _SchShipDateEnding = SchShipDateEnding;
            DateType _LastRcptStarting = LastRcptStarting;
            DateType _LastRcptEnding = LastRcptEnding;
            StringType _OrderBy = OrderBy;
            ListYesNoType _QuantityInTransitOnly = QuantityInTransitOnly;
            DateOffsetType _SchRcptDateStartingOffset = SchRcptDateStartingOffset;
            DateOffsetType _SchRcptDateEndingOffset = SchRcptDateEndingOffset;
            DateOffsetType _SchShipDateStartingOffset = SchShipDateStartingOffset;
            DateOffsetType _SchShipDateEndingOffset = SchShipDateEndingOffset;
            DateOffsetType _LastRcptStartingOffset = LastRcptStartingOffset;
            DateOffsetType _LastRcptEndingOffset = LastRcptEndingOffset;
            DateType _OrderDateStarting = OrderDateStarting;
            DateType _OrderDateEnding = OrderDateEnding;
            DateOffsetType _OrderDateStartingOffset = OrderDateStartingOffset;
            DateOffsetType _OrderDateEndingOffset = OrderDateEndingOffset;
            ListYesNoType _DisplayHeader = DisplayHeader;
            TaskNumType _TaskId = TaskId;
            SiteType _pSite = pSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "TransOrderStarting", _TransOrderStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransOrderEnding", _TransOrderEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptszTransferStat", _ExOptszTransferStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptszTrnitemStat", _ExOptszTrnitemStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptprQtyLoss", _ExOptprQtyLoss, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromSiteStarting", _FromSiteStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromSiteEnding", _FromSiteEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToSiteStarting", _ToSiteStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToSiteEnding", _ToSiteEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromWhseStarting", _FromWhseStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromWhseEnding", _FromWhseEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransitLocStarting", _TransitLocStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransitLocEnding", _TransitLocEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToWhseStarting", _ToWhseStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToWhseEnding", _ToWhseEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchRcptDateStarting", _SchRcptDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchRcptDateEnding", _SchRcptDateEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchShipDateStarting", _SchShipDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchShipDateEnding", _SchShipDateEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LastRcptStarting", _LastRcptStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LastRcptEnding", _LastRcptEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderBy", _OrderBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QuantityInTransitOnly", _QuantityInTransitOnly, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchRcptDateStartingOffset", _SchRcptDateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchRcptDateEndingOffset", _SchRcptDateEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchShipDateStartingOffset", _SchShipDateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SchShipDateEndingOffset", _SchShipDateEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LastRcptStartingOffset", _LastRcptStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LastRcptEndingOffset", _LastRcptEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderDateStarting", _OrderDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderDateEnding", _OrderDateEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderDateStartingOffset", _OrderDateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderDateEndingOffset", _OrderDateEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);

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
