//PROJECT NAME: Production
//CLASS NAME: GetJobMatlItem.cs

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
using CSI.Material;
using CSI.Logistics.Customer;

namespace CSI.Production
{
    public class GetJobMatlItem : IGetJobMatlItem
    {
        readonly IApplicationDB appDB;

        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IShipLocDefault iShipLocDefault;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IItemUMValid iItemUMValid;
        readonly IGetCostCode iGetCostCode;
        readonly IGetVariable iGetVariable;
        readonly IUomConvAmt iUomConvAmt;
        readonly IUomConvQty iUomConvQty;
        readonly IStringUtil stringUtil;
        readonly IMathUtil mathUtil;
        readonly IObsSlow iObsSlow;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;
        readonly IReqQty iReqQty;
        readonly IFmtJob iFmtJob;

        public GetJobMatlItem(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IShipLocDefault iShipLocDefault,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IItemUMValid iItemUMValid,
            IGetCostCode iGetCostCode,
            IGetVariable iGetVariable,
            IUomConvAmt iUomConvAmt,
            IUomConvQty iUomConvQty,
            IStringUtil stringUtil,
            IMathUtil mathUtil,
            IObsSlow iObsSlow,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp,
            IReqQty iReqQty,
            IFmtJob iFmtJob)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iShipLocDefault = iShipLocDefault;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.iItemUMValid = iItemUMValid;
            this.iGetCostCode = iGetCostCode;
            this.iGetVariable = iGetVariable;
            this.iUomConvAmt = iUomConvAmt;
            this.iUomConvQty = iUomConvQty;
            this.stringUtil = stringUtil;
            this.mathUtil = mathUtil;
            this.iObsSlow = iObsSlow;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
            this.iReqQty = iReqQty;
            this.iFmtJob = iFmtJob;
        }

        public (
            int? ReturnCode,
            string item_UM,
            string item_Description,
            int? ItemExists,
            decimal? UMConvFactor,
            int? JobmatlExists,
            int? JobmatlByProduct,
            decimal? item_MatlCost,
            decimal? item_MatlCostConv,
            decimal? item_LaborCost,
            decimal? item_LaborCostConv,
            decimal? item_FovhdCost,
            decimal? item_FovhdCostConv,
            decimal? item_VovhdCost,
            decimal? item_VovhdCostConv,
            decimal? item_OutCost,
            decimal? item_OutCostConv,
            string item_IssueBy,
            int? item_SerialTracked,
            int? item_LotTracked,
            string OutLoc,
            string OutLot,
            decimal? ReqQty,
            decimal? ReqQtyConv,
            decimal? QtyIssued,
            decimal? QtyIssuedConv,
            decimal? PlanCost,
            decimal? PlanCostConv,
            decimal? OnHandQty,
            decimal? OnHandQtyConv,
            decimal? ACost,
            decimal? AMatlCost,
            decimal? ALbrCost,
            decimal? AFovhdCost,
            decimal? AVovhdCost,
            decimal? AOutCost,
            string CostCode,
            string PoitemNonInvAcct,
            string PoitemNonInvAcctUnit1,
            string PoitemNonInvAcctUnit2,
            string PoitemNonInvAcctUnit3,
            string PoitemNonInvAcctUnit4,
            string PoitemNonInvAcctAccessUnit1,
            string PoitemNonInvAcctAccessUnit2,
            string PoitemNonInvAcctAccessUnit3,
            string PoitemNonInvAcctAccessUnit4,
            string Infobar,
            string Prompt,
            string PromptButtons,
            string OutImportDocId,
            int? WCOutside,
            DateTime? JobmatlRecordDate,
            int? TrakcedPieces,
            string ItemDimensionGroup,
            Guid? JobmatlRowPointer,
            int? JobmatlBackFlush,
            string jobmatl_ManufacturerID,
            string manufacturer_ManufacturerName,
            string jobmatl_ManufacturerItem,
            string manufacturerItem_ManufacturerItemDesc)
        GetJobMatlItemSp(
            string Item = null,
            string UM = null,
            string Job = null,
            int? Suffix = null,
            int? OperNum = null,
            int? Sequence = null,
            string CurWhse = null,
            int? ExtByScrap = null,
            string PoNum = null,
            int? PoLine = null,
            int? PoRelease = null,
            string item_UM = null,
            string item_Description = null,
            int? ItemExists = null,
            decimal? UMConvFactor = null,
            int? JobmatlExists = null,
            int? JobmatlByProduct = null,
            decimal? item_MatlCost = null,
            decimal? item_MatlCostConv = null,
            decimal? item_LaborCost = null,
            decimal? item_LaborCostConv = null,
            decimal? item_FovhdCost = null,
            decimal? item_FovhdCostConv = null,
            decimal? item_VovhdCost = null,
            decimal? item_VovhdCostConv = null,
            decimal? item_OutCost = null,
            decimal? item_OutCostConv = null,
            string item_IssueBy = null,
            int? item_SerialTracked = null,
            int? item_LotTracked = null,
            string OutLoc = null,
            string OutLot = null,
            decimal? ReqQty = null,
            decimal? ReqQtyConv = null,
            decimal? QtyIssued = null,
            decimal? QtyIssuedConv = null,
            decimal? PlanCost = null,
            decimal? PlanCostConv = null,
            decimal? OnHandQty = null,
            decimal? OnHandQtyConv = null,
            decimal? ACost = null,
            decimal? AMatlCost = null,
            decimal? ALbrCost = null,
            decimal? AFovhdCost = null,
            decimal? AVovhdCost = null,
            decimal? AOutCost = null,
            string CostCode = null,
            string PoitemNonInvAcct = null,
            string PoitemNonInvAcctUnit1 = null,
            string PoitemNonInvAcctUnit2 = null,
            string PoitemNonInvAcctUnit3 = null,
            string PoitemNonInvAcctUnit4 = null,
            string PoitemNonInvAcctAccessUnit1 = null,
            string PoitemNonInvAcctAccessUnit2 = null,
            string PoitemNonInvAcctAccessUnit3 = null,
            string PoitemNonInvAcctAccessUnit4 = null,
            string Infobar = null,
            string Prompt = null,
            string PromptButtons = null,
            string Site = null,
            string OutImportDocId = null,
            int? JmtRETURN = 0,
            int? WCOutside = 0,
            DateTime? JobmatlRecordDate = null,
            int? TrakcedPieces = 0,
            string ItemDimensionGroup = null,
            Guid? JobmatlRowPointer = null,
            int? JobmatlBackFlush = 0,
            string jobmatl_ManufacturerID = null,
            string manufacturer_ManufacturerName = null,
            string jobmatl_ManufacturerItem = null,
            string manufacturerItem_ManufacturerItemDesc = null)
        {

            ItemType _Item = Item;
            UMType _UM = UM;
            JobType _Job = Job;
            UMType _item_UM = item_UM;
            DescriptionType _item_Description = item_Description;
            CostPrcType _item_LaborCost = item_LaborCost;
            CostPrcType _item_LaborCostConv = item_LaborCostConv;
            CostPrcType _item_FovhdCost = item_FovhdCost;
            CostPrcType _item_FovhdCostConv = item_FovhdCostConv;
            CostPrcType _item_VovhdCost = item_VovhdCost;
            CostPrcType _item_VovhdCostConv = item_VovhdCostConv;
            CostPrcType _item_OutCost = item_OutCost;
            CostPrcType _item_OutCostConv = item_OutCostConv;
            ListLocLotType _item_IssueBy = item_IssueBy;
            ListYesNoType _item_SerialTracked = item_SerialTracked;
            ListYesNoType _item_LotTracked = item_LotTracked;
            LotType _OutLot = OutLot;
            QtyPerType _QtyIssued = QtyIssued;
            QtyPerType _OnHandQty = OnHandQty;
            CostPrcType _ACost = ACost;
            CostPrcType _AMatlCost = AMatlCost;
            CostPrcType _ALbrCost = ALbrCost;
            CostPrcType _AFovhdCost = AFovhdCost;
            CostPrcType _AVovhdCost = AVovhdCost;
            CostPrcType _AOutCost = AOutCost;
            AcctType _PoitemNonInvAcct = PoitemNonInvAcct;
            UnitCode1Type _PoitemNonInvAcctUnit1 = PoitemNonInvAcctUnit1;
            UnitCode2Type _PoitemNonInvAcctUnit2 = PoitemNonInvAcctUnit2;
            UnitCode3Type _PoitemNonInvAcctUnit3 = PoitemNonInvAcctUnit3;
            UnitCode4Type _PoitemNonInvAcctUnit4 = PoitemNonInvAcctUnit4;
            UnitCodeAccessType _PoitemNonInvAcctAccessUnit1 = PoitemNonInvAcctAccessUnit1;
            UnitCodeAccessType _PoitemNonInvAcctAccessUnit2 = PoitemNonInvAcctAccessUnit2;
            UnitCodeAccessType _PoitemNonInvAcctAccessUnit3 = PoitemNonInvAcctAccessUnit3;
            UnitCodeAccessType _PoitemNonInvAcctAccessUnit4 = PoitemNonInvAcctAccessUnit4;
            SiteType _Site = Site;
            ListYesNoType _WCOutside = WCOutside;
            DateType _JobmatlRecordDate = JobmatlRecordDate;
            FlagNyType _TrakcedPieces = TrakcedPieces;
            AttributeGroupType _ItemDimensionGroup = ItemDimensionGroup;
            RowPointerType _JobmatlRowPointer = JobmatlRowPointer;
            ListYesNoType _JobmatlBackFlush = JobmatlBackFlush;
            ManufacturerIdType _jobmatl_ManufacturerID = jobmatl_ManufacturerID;
            NameType _manufacturer_ManufacturerName = manufacturer_ManufacturerName;
            ManufacturerItemType _jobmatl_ManufacturerItem = jobmatl_ManufacturerItem;
            DescriptionType _manufacturerItem_ManufacturerItemDesc = manufacturerItem_ManufacturerItemDesc;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            RowPointerType _item_RowPointer = DBNull.Value;
            Guid? item_RowPointer = null;
            ListYesNoType _item_TrackEcn = DBNull.Value;
            int? item_TrackEcn = null;
            EcnModeType _Ecn_Job = DBNull.Value;
            string Ecn_Job = null;
            DecimalPlacesType _InvparmsPlacesQtyPer = DBNull.Value;
            int? InvparmsPlacesQtyPer = null;
            ItemType _job_Item = DBNull.Value;
            string job_Item = null;
            RefTypeIKOTType _job_OrdType = DBNull.Value;
            string job_OrdType = null;
            WcType _WC = DBNull.Value;
            string WC = null;
            QtyUnitType _JobQtyReleased = DBNull.Value;
            decimal? JobQtyReleased = null;
            JobmatlUnitsType _JobmatlUnits = DBNull.Value;
            string JobmatlUnits = null;
            QtyPerType _JobmatlMatlQty = DBNull.Value;
            decimal? JobmatlMatlQty = null;
            ScrapFactorType _JobmatlScrapFact = DBNull.Value;
            decimal? JobmatlScrapFact = null;
            CostPrcType _JobmatlCost = DBNull.Value;
            decimal? JobmatlCost = null;
            CostPrcType _JobmatlCostConv = DBNull.Value;
            decimal? JobmatlCostConv = null;
            UMType _JobmatlUM = DBNull.Value;
            string JobmatlUM = null;
            CostPrcType _MatlCost = DBNull.Value;
            decimal? MatlCost = null;
            CostPrcType _MatlCostConv = DBNull.Value;
            CostPrcType _LaborCost = DBNull.Value;
            decimal? LaborCost = null;
            CostPrcType _LaborCostConv = DBNull.Value;
            CostPrcType _FovhdCost = DBNull.Value;
            decimal? FovhdCost = null;
            CostPrcType _FovhdCostConv = DBNull.Value;
            CostPrcType _VovhdCost = DBNull.Value;
            decimal? VovhdCost = null;
            CostPrcType _VovhdCostConv = DBNull.Value;
            CostPrcType _OutCost = DBNull.Value;
            decimal? OutCost = null;
            CostPrcType _OutCostConv = DBNull.Value;
            LocType _DefLoc = DBNull.Value;
            string DefLoc = null;
            LotType _DefLot = DBNull.Value;
            string DefLot = null;
            string DefImportDocId = null;
            CostPrcType _item_MatlCst = DBNull.Value;
            decimal? item_MatlCst = null;
            CostPrcType _item_MatlCstConv = DBNull.Value;
            decimal? item_MatlCstConv = null;
            int? CallFromPORecv = null;
            ListYesNoType _Rework = DBNull.Value;
            int? Rework = null;
            UMType _ItemBaseUM = DBNull.Value;
            string ItemBaseUM = null;
            ListYesNoType _ParmsAnalyticalLedger = DBNull.Value;
            int? ParmsAnalyticalLedger = null;
            string tmpFmtJob = null;
            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GetJobMatlItemSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
            )
            {
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GetJobMatlItemSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("GetJobMatlItemSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_GetJobMatlItemSp(ALTGEN_SpName,
                        Item,
                        UM,
                        Job,
                        Suffix,
                        OperNum,
                        Sequence,
                        CurWhse,
                        ExtByScrap,
                        PoNum,
                        PoLine,
                        PoRelease,
                        item_UM,
                        item_Description,
                        ItemExists,
                        UMConvFactor,
                        JobmatlExists,
                        JobmatlByProduct,
                        item_MatlCost,
                        item_MatlCostConv,
                        item_LaborCost,
                        item_LaborCostConv,
                        item_FovhdCost,
                        item_FovhdCostConv,
                        item_VovhdCost,
                        item_VovhdCostConv,
                        item_OutCost,
                        item_OutCostConv,
                        item_IssueBy,
                        item_SerialTracked,
                        item_LotTracked,
                        OutLoc,
                        OutLot,
                        ReqQty,
                        ReqQtyConv,
                        QtyIssued,
                        QtyIssuedConv,
                        PlanCost,
                        PlanCostConv,
                        OnHandQty,
                        OnHandQtyConv,
                        ACost,
                        AMatlCost,
                        ALbrCost,
                        AFovhdCost,
                        AVovhdCost,
                        AOutCost,
                        CostCode,
                        PoitemNonInvAcct,
                        PoitemNonInvAcctUnit1,
                        PoitemNonInvAcctUnit2,
                        PoitemNonInvAcctUnit3,
                        PoitemNonInvAcctUnit4,
                        PoitemNonInvAcctAccessUnit1,
                        PoitemNonInvAcctAccessUnit2,
                        PoitemNonInvAcctAccessUnit3,
                        PoitemNonInvAcctAccessUnit4,
                        Infobar,
                        Prompt,
                        PromptButtons,
                        Site,
                        OutImportDocId,
                        JmtRETURN,
                        WCOutside,
                        JobmatlRecordDate,
                        TrakcedPieces,
                        ItemDimensionGroup,
                        JobmatlRowPointer,
                        JobmatlBackFlush,
                        jobmatl_ManufacturerID,
                        manufacturer_ManufacturerName,
                        jobmatl_ManufacturerItem,
                        manufacturerItem_ManufacturerItemDesc);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, item_UM, item_Description, ItemExists, UMConvFactor, JobmatlExists, JobmatlByProduct, item_MatlCost, item_MatlCostConv, item_LaborCost, item_LaborCostConv, item_FovhdCost, item_FovhdCostConv, item_VovhdCost, item_VovhdCostConv, item_OutCost, item_OutCostConv, item_IssueBy, item_SerialTracked, item_LotTracked, OutLoc, OutLot, ReqQty, ReqQtyConv, QtyIssued, QtyIssuedConv, PlanCost, PlanCostConv, OnHandQty, OnHandQtyConv, ACost, AMatlCost, ALbrCost, AFovhdCost, AVovhdCost, AOutCost, CostCode, PoitemNonInvAcct, PoitemNonInvAcctUnit1, PoitemNonInvAcctUnit2, PoitemNonInvAcctUnit3, PoitemNonInvAcctUnit4, PoitemNonInvAcctAccessUnit1, PoitemNonInvAcctAccessUnit2, PoitemNonInvAcctAccessUnit3, PoitemNonInvAcctAccessUnit4, Infobar, Prompt, PromptButtons, OutImportDocId, WCOutside, JobmatlRecordDate, TrakcedPieces, ItemDimensionGroup, JobmatlRowPointer, JobmatlBackFlush, jobmatl_ManufacturerID, manufacturer_ManufacturerName, jobmatl_ManufacturerItem, manufacturerItem_ManufacturerItemDesc);

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

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_GetJobMatlItemSp") != null)
            {
                var EXTGEN = AltExtGen_GetJobMatlItemSp("dbo.EXTGEN_GetJobMatlItemSp",
                    Item,
                    UM,
                    Job,
                    Suffix,
                    OperNum,
                    Sequence,
                    CurWhse,
                    ExtByScrap,
                    PoNum,
                    PoLine,
                    PoRelease,
                    item_UM,
                    item_Description,
                    ItemExists,
                    UMConvFactor,
                    JobmatlExists,
                    JobmatlByProduct,
                    item_MatlCost,
                    item_MatlCostConv,
                    item_LaborCost,
                    item_LaborCostConv,
                    item_FovhdCost,
                    item_FovhdCostConv,
                    item_VovhdCost,
                    item_VovhdCostConv,
                    item_OutCost,
                    item_OutCostConv,
                    item_IssueBy,
                    item_SerialTracked,
                    item_LotTracked,
                    OutLoc,
                    OutLot,
                    ReqQty,
                    ReqQtyConv,
                    QtyIssued,
                    QtyIssuedConv,
                    PlanCost,
                    PlanCostConv,
                    OnHandQty,
                    OnHandQtyConv,
                    ACost,
                    AMatlCost,
                    ALbrCost,
                    AFovhdCost,
                    AVovhdCost,
                    AOutCost,
                    CostCode,
                    PoitemNonInvAcct,
                    PoitemNonInvAcctUnit1,
                    PoitemNonInvAcctUnit2,
                    PoitemNonInvAcctUnit3,
                    PoitemNonInvAcctUnit4,
                    PoitemNonInvAcctAccessUnit1,
                    PoitemNonInvAcctAccessUnit2,
                    PoitemNonInvAcctAccessUnit3,
                    PoitemNonInvAcctAccessUnit4,
                    Infobar,
                    Prompt,
                    PromptButtons,
                    Site,
                    OutImportDocId,
                    JmtRETURN,
                    WCOutside,
                    JobmatlRecordDate,
                    TrakcedPieces,
                    ItemDimensionGroup,
                    JobmatlRowPointer,
                    JobmatlBackFlush,
                    jobmatl_ManufacturerID,
                    manufacturer_ManufacturerName,
                    jobmatl_ManufacturerItem,
                    manufacturerItem_ManufacturerItemDesc);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.item_UM, EXTGEN.item_Description, EXTGEN.ItemExists, EXTGEN.UMConvFactor, EXTGEN.JobmatlExists, EXTGEN.JobmatlByProduct, EXTGEN.item_MatlCost, EXTGEN.item_MatlCostConv, EXTGEN.item_LaborCost, EXTGEN.item_LaborCostConv, EXTGEN.item_FovhdCost, EXTGEN.item_FovhdCostConv, EXTGEN.item_VovhdCost, EXTGEN.item_VovhdCostConv, EXTGEN.item_OutCost, EXTGEN.item_OutCostConv, EXTGEN.item_IssueBy, EXTGEN.item_SerialTracked, EXTGEN.item_LotTracked, EXTGEN.OutLoc, EXTGEN.OutLot, EXTGEN.ReqQty, EXTGEN.ReqQtyConv, EXTGEN.QtyIssued, EXTGEN.QtyIssuedConv, EXTGEN.PlanCost, EXTGEN.PlanCostConv, EXTGEN.OnHandQty, EXTGEN.OnHandQtyConv, EXTGEN.ACost, EXTGEN.AMatlCost, EXTGEN.ALbrCost, EXTGEN.AFovhdCost, EXTGEN.AVovhdCost, EXTGEN.AOutCost, EXTGEN.CostCode, EXTGEN.PoitemNonInvAcct, EXTGEN.PoitemNonInvAcctUnit1, EXTGEN.PoitemNonInvAcctUnit2, EXTGEN.PoitemNonInvAcctUnit3, EXTGEN.PoitemNonInvAcctUnit4, EXTGEN.PoitemNonInvAcctAccessUnit1, EXTGEN.PoitemNonInvAcctAccessUnit2, EXTGEN.PoitemNonInvAcctAccessUnit3, EXTGEN.PoitemNonInvAcctAccessUnit4, EXTGEN.Infobar, EXTGEN.Prompt, EXTGEN.PromptButtons, EXTGEN.OutImportDocId, EXTGEN.WCOutside, EXTGEN.JobmatlRecordDate, EXTGEN.TrakcedPieces, EXTGEN.ItemDimensionGroup, EXTGEN.JobmatlRowPointer, EXTGEN.JobmatlBackFlush, EXTGEN.jobmatl_ManufacturerID, EXTGEN.manufacturer_ManufacturerName, EXTGEN.jobmatl_ManufacturerItem, EXTGEN.manufacturerItem_ManufacturerItemDesc);
                }
            }

            Infobar = null;
            Prompt = null;
            PromptButtons = null;
            Severity = 0;

            #region CRUD LoadToVariable
            var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_Ecn_Job,"ecn_job"},
                    {_InvparmsPlacesQtyPer,"places_qty_per"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "invparms",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var invparmsLoadResponse = this.appDB.Load(invparmsLoadRequest);
            if (invparmsLoadResponse.Items.Count > 0)
            {
                Ecn_Job = _Ecn_Job;
                InvparmsPlacesQtyPer = _InvparmsPlacesQtyPer;
            }
            #endregion  LoadToVariable

            item_Description = (item_Description == null ? "" : item_Description);
            item_UM = "";
            item_MatlCst = (decimal?)(stringUtil.IsNull<decimal?>(
                item_MatlCost,
                0));
            item_MatlCstConv = (decimal?)(stringUtil.IsNull<decimal?>(
                item_MatlCostConv,
                0));
            if (Site == null)
            {

                #region CRUD LoadToVariable
                var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_Site,"site"},
                        {_ParmsAnalyticalLedger,"analytical_ledger"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "parms",
                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                    whereClause: collectionLoadRequestFactory.Clause("parm_key = 0"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
                if (parmsLoadResponse.Items.Count > 0)
                {
                    Site = _Site;
                    ParmsAnalyticalLedger = _ParmsAnalyticalLedger;
                }
                #endregion  LoadToVariable

            }

            #region CRUD LoadToVariable
            var jobmatlLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_JobmatlMatlQty,"jobmatl.matl_qty"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "jobmatl",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("jobmatl.job = {3} AND jobmatl.suffix = {1} AND jobmatl.oper_num = {0} AND jobmatl.item = {2} AND jobmatl.matl_qty < 0", OperNum, Suffix, Item, Job),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var jobmatlLoadResponse = this.appDB.Load(jobmatlLoadRequest);
            if (jobmatlLoadResponse.Items.Count > 0)
            {
                JobmatlMatlQty = _JobmatlMatlQty;
            }
            #endregion  LoadToVariable

            if (sQLUtil.SQLLessThan(JobmatlMatlQty, 0) == true)
            {
                JobmatlByProduct = 1;

            }
            else
            {
                JobmatlByProduct = 0;

            }

            #region CRUD LoadToVariable
            var jobmatl1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_JobmatlUnits,"jobmatl.units"},
                    {_JobmatlMatlQty,"jobmatl.matl_qty"},
                    {_JobmatlScrapFact,"jobmatl.scrap_fact"},
                    {_JobmatlCost,"jobmatl.cost"},
                    {_JobmatlCostConv,"jobmatl.cost_conv"},
                    {_QtyIssued,"jobmatl.qty_issued"},
                    {_ACost,"jobmatl.a_cost"},
                    {_AMatlCost,"jobmatl.a_matl_cost"},
                    {_ALbrCost,"jobmatl.a_lbr_cost"},
                    {_AFovhdCost,"jobmatl.a_fovhd_cost"},
                    {_AVovhdCost,"jobmatl.a_vovhd_cost"},
                    {_AOutCost,"jobmatl.a_out_cost"},
                    {_MatlCost,"jobmatl.matl_cost"},
                    {_LaborCost,"jobmatl.lbr_cost"},
                    {_FovhdCost,"jobmatl.fovhd_cost"},
                    {_VovhdCost,"jobmatl.vovhd_cost"},
                    {_OutCost,"jobmatl.out_cost"},
                    {_JobmatlRecordDate,"jobmatl.RecordDate"},
                    {_JobmatlUM,"jobmatl.u_m"},
                    {_JobmatlRowPointer,"jobmatl.RowPointer"},
                    {_JobmatlBackFlush,"jobmatl.backflush"},
                    {_jobmatl_ManufacturerID,"jobmatl.manufacturer_id"},
                    {_jobmatl_ManufacturerItem,"jobmatl.manufacturer_item"},
                    {_manufacturer_ManufacturerName,"man.name"},
                    {_manufacturerItem_ManufacturerItemDesc,"mai.description"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "jobmatl",
                fromClause: collectionLoadRequestFactory.Clause(@" WITH (READUNCOMMITTED) LEFT OUTER JOIN manufacturer AS man ON jobmatl.manufacturer_id = man.manufacturer_id LEFT OUTER JOIN manufacturer_item AS mai ON jobmatl.manufacturer_id = mai.manufacturer_id
					AND jobmatl.manufacturer_item = mai.manufacturer_item"),
                whereClause: collectionLoadRequestFactory.Clause("jobmatl.job = {3} AND jobmatl.suffix = {2} AND jobmatl.oper_num = {1} AND jobmatl.Sequence = {0}", Sequence, OperNum, Suffix, Job),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var jobmatl1LoadResponse = this.appDB.Load(jobmatl1LoadRequest);
            if (jobmatl1LoadResponse.Items.Count > 0)
            {
                JobmatlUnits = _JobmatlUnits;
                JobmatlMatlQty = _JobmatlMatlQty;
                JobmatlScrapFact = _JobmatlScrapFact;
                JobmatlCost = _JobmatlCost;
                JobmatlCostConv = _JobmatlCostConv;
                QtyIssued = _QtyIssued;
                ACost = _ACost;
                AMatlCost = _AMatlCost;
                ALbrCost = _ALbrCost;
                AFovhdCost = _AFovhdCost;
                AVovhdCost = _AVovhdCost;
                AOutCost = _AOutCost;
                MatlCost = _MatlCost;
                LaborCost = _LaborCost;
                FovhdCost = _FovhdCost;
                VovhdCost = _VovhdCost;
                OutCost = _OutCost;
                JobmatlRecordDate = _JobmatlRecordDate;
                JobmatlUM = _JobmatlUM;
                JobmatlRowPointer = _JobmatlRowPointer;
                JobmatlBackFlush = _JobmatlBackFlush;
                jobmatl_ManufacturerID = _jobmatl_ManufacturerID;
                jobmatl_ManufacturerItem = _jobmatl_ManufacturerItem;
                manufacturer_ManufacturerName = _manufacturer_ManufacturerName;
                manufacturerItem_ManufacturerItemDesc = _manufacturerItem_ManufacturerItemDesc;
            }
            #endregion  LoadToVariable

            if (sQLUtil.SQLGreaterThan(jobmatl1LoadResponse.Items.Count, 0) == true)
            {
                JobmatlExists = 1;

            }
            else
            {
                JobmatlExists = 0;

            }

            #region CRUD LoadToVariable
            var jobLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_job_Item,"job.item"},
                    {_job_OrdType,"job.ord_type"},
                    {_JobQtyReleased,"job.qty_released"},
                    {_Rework,"job.rework"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "job",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("job.job = {1} AND job.suffix = {0}", Suffix, Job),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var jobLoadResponse = this.appDB.Load(jobLoadRequest);
            if (jobLoadResponse.Items.Count > 0)
            {
                job_Item = _job_Item;
                job_OrdType = _job_OrdType;
                JobQtyReleased = _JobQtyReleased;
                Rework = _Rework;
            }
            #endregion  LoadToVariable

            #region CRUD LoadToVariable
            var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_item_TrackEcn,"track_ecn"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "item",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("item = {0}", job_Item),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var itemLoadResponse = this.appDB.Load(itemLoadRequest);
            if (itemLoadResponse.Items.Count > 0)
            {
                item_TrackEcn = _item_TrackEcn;
            }
            #endregion  LoadToVariable

            if (sQLUtil.SQLEqual(job_Item, Item) == true && sQLUtil.SQLEqual(Rework, 0) == true)
            {

                #region CRUD ExecuteMethodCall

                var MsgApp = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "E=NoRecursive",
                    Parm1: "@item",
                    Parm2: "@item.item",
                    Parm3: Item);
                Severity = MsgApp.ReturnCode;
                Infobar = MsgApp.Infobar;

                #endregion ExecuteMethodCall

                return (Severity, item_UM, item_Description, ItemExists, UMConvFactor, JobmatlExists, JobmatlByProduct, item_MatlCost, item_MatlCostConv, item_LaborCost, item_LaborCostConv, item_FovhdCost, item_FovhdCostConv, item_VovhdCost, item_VovhdCostConv, item_OutCost, item_OutCostConv, item_IssueBy, item_SerialTracked, item_LotTracked, OutLoc, OutLot, ReqQty, ReqQtyConv, QtyIssued, QtyIssuedConv, PlanCost, PlanCostConv, OnHandQty, OnHandQtyConv, ACost, AMatlCost, ALbrCost, AFovhdCost, AVovhdCost, AOutCost, CostCode, PoitemNonInvAcct, PoitemNonInvAcctUnit1, PoitemNonInvAcctUnit2, PoitemNonInvAcctUnit3, PoitemNonInvAcctUnit4, PoitemNonInvAcctAccessUnit1, PoitemNonInvAcctAccessUnit2, PoitemNonInvAcctAccessUnit3, PoitemNonInvAcctAccessUnit4, Infobar, Prompt, PromptButtons, OutImportDocId, WCOutside, JobmatlRecordDate, TrakcedPieces, ItemDimensionGroup, JobmatlRowPointer, JobmatlBackFlush, jobmatl_ManufacturerID, manufacturer_ManufacturerName, jobmatl_ManufacturerItem, manufacturerItem_ManufacturerItemDesc);
            }
            if (sQLUtil.SQLEqual(JobmatlExists, 0) == true)
            {

                #region CRUD LoadToVariable
                var jobmatl2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_JobmatlUM,"jobmatl.u_m"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    maximumRows: 1,
                    tableName: "jobmatl",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("job = {3} AND suffix = {1} AND oper_num = {0} AND item = {2}", OperNum, Suffix, Item, Job),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var jobmatl2LoadResponse = this.appDB.Load(jobmatl2LoadRequest);
                if (jobmatl2LoadResponse.Items.Count > 0)
                {
                    JobmatlUM = _JobmatlUM;
                }
                #endregion  LoadToVariable

            }

            #region CRUD LoadToVariable
            var item1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_item_RowPointer,"item.RowPointer"},
                    {_item_UM,$"isnull({variableUtil.GetQuotedValue<string>(JobmatlUM)}, item.u_m)"},
                    {_ItemBaseUM,"item.u_m"},
                    {_item_Description,"item.description"},
                    {_MatlCost,$"CASE WHEN {variableUtil.GetQuotedValue<int?>(JobmatlExists)} = 1 THEN {variableUtil.GetQuotedValue<decimal?>(MatlCost)} ELSE item.matl_cost END"},
                    {_LaborCost,$"CASE WHEN {variableUtil.GetQuotedValue<int?>(JobmatlExists)} = 1 THEN {variableUtil.GetQuotedValue<decimal?>(LaborCost)} ELSE item.lbr_cost END"},
                    {_FovhdCost,$"CASE WHEN {variableUtil.GetQuotedValue<int?>(JobmatlExists)} = 1 THEN {variableUtil.GetQuotedValue<decimal?>(FovhdCost)} ELSE item.fovhd_cost END"},
                    {_VovhdCost,$"CASE WHEN {variableUtil.GetQuotedValue<int?>(JobmatlExists)} = 1 THEN {variableUtil.GetQuotedValue<decimal?>(VovhdCost)} ELSE item.vovhd_cost END"},
                    {_OutCost,$"CASE WHEN {variableUtil.GetQuotedValue<int?>(JobmatlExists)} = 1 THEN {variableUtil.GetQuotedValue<decimal?>(OutCost)} ELSE item.out_cost END"},
                    {_item_IssueBy,"item.issue_by"},
                    {_item_SerialTracked,"item.serial_tracked"},
                    {_item_LotTracked,"item.lot_tracked"},
                    {_TrakcedPieces,"item.track_pieces"},
                    {_ItemDimensionGroup,"item.dimension_group"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "item",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("item.item = {0}", Item),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var item1LoadResponse = this.appDB.Load(item1LoadRequest);
            if (item1LoadResponse.Items.Count > 0)
            {
                item_RowPointer = _item_RowPointer;
                item_UM = _item_UM;
                ItemBaseUM = _ItemBaseUM;
                item_Description = _item_Description;
                MatlCost = _MatlCost;
                LaborCost = _LaborCost;
                FovhdCost = _FovhdCost;
                VovhdCost = _VovhdCost;
                OutCost = _OutCost;
                item_IssueBy = _item_IssueBy;
                item_SerialTracked = _item_SerialTracked;
                item_LotTracked = _item_LotTracked;
                TrakcedPieces = _TrakcedPieces;
                ItemDimensionGroup = _ItemDimensionGroup;
            }
            #endregion  LoadToVariable

            if (UM != null)
            {
                if (sQLUtil.SQLNotEqual(UM, ItemBaseUM) == true)
                {

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: ItemUMValidSp
                    var ItemUMValid = this.iItemUMValid.ItemUMValidSp(
                        PItem: Item,
                        PUM: UM,
                        UomConvFactor: UMConvFactor,
                        Infobar: Infobar);
                    Severity = ItemUMValid.ReturnCode;
                    UM = ItemUMValid.PUM;
                    UMConvFactor = ItemUMValid.UomConvFactor;
                    Infobar = ItemUMValid.Infobar;

                    #endregion ExecuteMethodCall

                    if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                    {
                        return (Severity, item_UM, item_Description, ItemExists, UMConvFactor, JobmatlExists, JobmatlByProduct, item_MatlCost, item_MatlCostConv, item_LaborCost, item_LaborCostConv, item_FovhdCost, item_FovhdCostConv, item_VovhdCost, item_VovhdCostConv, item_OutCost, item_OutCostConv, item_IssueBy, item_SerialTracked, item_LotTracked, OutLoc, OutLot, ReqQty, ReqQtyConv, QtyIssued, QtyIssuedConv, PlanCost, PlanCostConv, OnHandQty, OnHandQtyConv, ACost, AMatlCost, ALbrCost, AFovhdCost, AVovhdCost, AOutCost, CostCode, PoitemNonInvAcct, PoitemNonInvAcctUnit1, PoitemNonInvAcctUnit2, PoitemNonInvAcctUnit3, PoitemNonInvAcctUnit4, PoitemNonInvAcctAccessUnit1, PoitemNonInvAcctAccessUnit2, PoitemNonInvAcctAccessUnit3, PoitemNonInvAcctAccessUnit4, Infobar, Prompt, PromptButtons, OutImportDocId, WCOutside, JobmatlRecordDate, TrakcedPieces, ItemDimensionGroup, JobmatlRowPointer, JobmatlBackFlush, jobmatl_ManufacturerID, manufacturer_ManufacturerName, jobmatl_ManufacturerItem, manufacturerItem_ManufacturerItemDesc);
                    }
                    JobmatlCostConv = convertToUtil.ToDecimal(this.iUomConvAmt.UomConvAmtFn(
                        JobmatlCost,
                        UMConvFactor,
                        "From Base"));

                }
                else
                {
                    UMConvFactor = 1M;
                    JobmatlCostConv = JobmatlCost;

                }

            }
            else
            {
                UM = item_UM;
                if (sQLUtil.SQLNotEqual(UM, ItemBaseUM) == true)
                {

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: ItemUMValidSp
                    var ItemUMValid1 = this.iItemUMValid.ItemUMValidSp(
                        PItem: Item,
                        PUM: UM,
                        UomConvFactor: UMConvFactor,
                        Infobar: Infobar);
                    Severity = ItemUMValid1.ReturnCode;
                    UM = ItemUMValid1.PUM;
                    UMConvFactor = ItemUMValid1.UomConvFactor;
                    Infobar = ItemUMValid1.Infobar;

                    #endregion ExecuteMethodCall

                    if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                    {
                        return (Severity, item_UM, item_Description, ItemExists, UMConvFactor, JobmatlExists, JobmatlByProduct, item_MatlCost, item_MatlCostConv, item_LaborCost, item_LaborCostConv, item_FovhdCost, item_FovhdCostConv, item_VovhdCost, item_VovhdCostConv, item_OutCost, item_OutCostConv, item_IssueBy, item_SerialTracked, item_LotTracked, OutLoc, OutLot, ReqQty, ReqQtyConv, QtyIssued, QtyIssuedConv, PlanCost, PlanCostConv, OnHandQty, OnHandQtyConv, ACost, AMatlCost, ALbrCost, AFovhdCost, AVovhdCost, AOutCost, CostCode, PoitemNonInvAcct, PoitemNonInvAcctUnit1, PoitemNonInvAcctUnit2, PoitemNonInvAcctUnit3, PoitemNonInvAcctUnit4, PoitemNonInvAcctAccessUnit1, PoitemNonInvAcctAccessUnit2, PoitemNonInvAcctAccessUnit3, PoitemNonInvAcctAccessUnit4, Infobar, Prompt, PromptButtons, OutImportDocId, WCOutside, JobmatlRecordDate, TrakcedPieces, ItemDimensionGroup, JobmatlRowPointer, JobmatlBackFlush, jobmatl_ManufacturerID, manufacturer_ManufacturerName, jobmatl_ManufacturerItem, manufacturerItem_ManufacturerItemDesc);
                    }
                    JobmatlCostConv = convertToUtil.ToDecimal(this.iUomConvAmt.UomConvAmtFn(
                        JobmatlCost,
                        UMConvFactor,
                        "From Base"));

                }
                else
                {
                    UMConvFactor = 1M;
                    JobmatlCostConv = JobmatlCost;

                }

            }
            if (sQLUtil.SQLEqual(JobmatlExists, 1) == true)
            {
                ReqQty = convertToUtil.ToDecimal(mathUtil.Round<decimal?>(this.iReqQty.ReqQtyFn(
                        JobQtyReleased,
                        JobmatlUnits,
                        JobmatlMatlQty,
                        ExtByScrap,
                        JobmatlScrapFact), InvparmsPlacesQtyPer));
                ReqQtyConv = convertToUtil.ToDecimal(this.iUomConvQty.UomConvQtyFn(
                    ReqQty,
                    UMConvFactor,
                    "From Base"));
                QtyIssuedConv = convertToUtil.ToDecimal(this.iUomConvQty.UomConvQtyFn(
                    QtyIssued,
                    UMConvFactor,
                    "From Base"));
                PlanCost = (decimal?)((JobmatlCost * ReqQty));
                PlanCostConv = (decimal?)((JobmatlCostConv * ReqQtyConv));

            }
            else
            {
                PlanCost = 0.0M;
                PlanCostConv = 0.0M;
                ReqQty = 0.0M;
                ReqQtyConv = 0.0M;
                QtyIssued = 0.0M;
                QtyIssuedConv = 0.0M;
                ACost = 0.0M;
                AMatlCost = 0.0M;
                ALbrCost = 0.0M;
                AFovhdCost = 0.0M;
                AVovhdCost = 0.0M;
                AOutCost = 0.0M;

            }
            if (item_RowPointer != null)
            {
                ItemExists = 1;
                if (sQLUtil.SQLEqual(JobmatlExists, 0) == true && sQLUtil.SQLEqual(item_TrackEcn, 1) == true)
                {
                    if ((sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
                                Ecn_Job,
                                "AI"), 0) == true))
                    {
                        tmpFmtJob = this.iFmtJob.FmtJobSp(
                            Job,
                            Suffix);

                        #region CRUD ExecuteMethodCall

                        var MsgApp1 = this.iMsgApp.MsgAppSp(
                            Infobar: Infobar,
                            BaseMsg: "E=NoExistForIs2",
                            Parm1: "@jobmatl",
                            Parm2: "@jobmatl.item",
                            Parm3: Item,
                            Parm4: "@jobroute",
                            Parm5: "@jobroute.job",
                            Parm6: tmpFmtJob,
                            Parm7: "@jobroute.oper_num",
                            Parm8: convertToUtil.ToString(OperNum));
                        Severity = MsgApp1.ReturnCode;
                        Infobar = MsgApp1.Infobar;

                        #endregion ExecuteMethodCall

                        #region CRUD ExecuteMethodCall

                        var MsgApp2 = this.iMsgApp.MsgAppSp(
                            Infobar: Infobar,
                            BaseMsg: "E=IsCompare1",
                            Parm1: "@item.track_ecn",
                            Parm2: "@:ListYesNo:1",
                            Parm3: "@job.job",
                            Parm4: "@job.item",
                            Parm5: job_Item);
                        Severity = MsgApp2.ReturnCode;
                        Infobar = MsgApp2.Infobar;

                        #endregion ExecuteMethodCall

                        return (Severity, item_UM, item_Description, ItemExists, UMConvFactor, JobmatlExists, JobmatlByProduct, item_MatlCost, item_MatlCostConv, item_LaborCost, item_LaborCostConv, item_FovhdCost, item_FovhdCostConv, item_VovhdCost, item_VovhdCostConv, item_OutCost, item_OutCostConv, item_IssueBy, item_SerialTracked, item_LotTracked, OutLoc, OutLot, ReqQty, ReqQtyConv, QtyIssued, QtyIssuedConv, PlanCost, PlanCostConv, OnHandQty, OnHandQtyConv, ACost, AMatlCost, ALbrCost, AFovhdCost, AVovhdCost, AOutCost, CostCode, PoitemNonInvAcct, PoitemNonInvAcctUnit1, PoitemNonInvAcctUnit2, PoitemNonInvAcctUnit3, PoitemNonInvAcctUnit4, PoitemNonInvAcctAccessUnit1, PoitemNonInvAcctAccessUnit2, PoitemNonInvAcctAccessUnit3, PoitemNonInvAcctAccessUnit4, Infobar, Prompt, PromptButtons, OutImportDocId, WCOutside, JobmatlRecordDate, TrakcedPieces, ItemDimensionGroup, JobmatlRowPointer, JobmatlBackFlush, jobmatl_ManufacturerID, manufacturer_ManufacturerName, jobmatl_ManufacturerItem, manufacturerItem_ManufacturerItemDesc);
                    }

                }

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ObsSlowSp
                var ObsSlow = this.iObsSlow.ObsSlowSp(
                    Item: Item,
                    WarnIfSlowMoving: 1,
                    ErrorIfSlowMoving: 0,
                    WarnIfObsolete: 1,
                    ErrorIfObsolete: 0,
                    Infobar: Infobar,
                    Prompt: Prompt,
                    PromptButtons: PromptButtons,
                    Site: Site);
                Severity = ObsSlow.ReturnCode;
                Infobar = ObsSlow.Infobar;
                Prompt = ObsSlow.Prompt;
                PromptButtons = ObsSlow.PromptButtons;

                #endregion ExecuteMethodCall

                if (sQLUtil.SQLGreaterThanOrEqual(Severity, 16) == true)
                {
                    return (Severity, item_UM, item_Description, ItemExists, UMConvFactor, JobmatlExists, JobmatlByProduct, item_MatlCost, item_MatlCostConv, item_LaborCost, item_LaborCostConv, item_FovhdCost, item_FovhdCostConv, item_VovhdCost, item_VovhdCostConv, item_OutCost, item_OutCostConv, item_IssueBy, item_SerialTracked, item_LotTracked, OutLoc, OutLot, ReqQty, ReqQtyConv, QtyIssued, QtyIssuedConv, PlanCost, PlanCostConv, OnHandQty, OnHandQtyConv, ACost, AMatlCost, ALbrCost, AFovhdCost, AVovhdCost, AOutCost, CostCode, PoitemNonInvAcct, PoitemNonInvAcctUnit1, PoitemNonInvAcctUnit2, PoitemNonInvAcctUnit3, PoitemNonInvAcctUnit4, PoitemNonInvAcctAccessUnit1, PoitemNonInvAcctAccessUnit2, PoitemNonInvAcctAccessUnit3, PoitemNonInvAcctAccessUnit4, Infobar, Prompt, PromptButtons, OutImportDocId, WCOutside, JobmatlRecordDate, TrakcedPieces, ItemDimensionGroup, JobmatlRowPointer, JobmatlBackFlush, jobmatl_ManufacturerID, manufacturer_ManufacturerName, jobmatl_ManufacturerItem, manufacturerItem_ManufacturerItemDesc);
                }
                item_MatlCst = MatlCost;
                item_LaborCost = LaborCost;
                item_FovhdCost = FovhdCost;
                item_VovhdCost = VovhdCost;
                item_OutCost = OutCost;
                item_MatlCstConv = convertToUtil.ToDecimal(this.iUomConvAmt.UomConvAmtFn(
                    MatlCost,
                    UMConvFactor,
                    "From Base"));
                item_LaborCostConv = convertToUtil.ToDecimal(this.iUomConvAmt.UomConvAmtFn(
                    LaborCost,
                    UMConvFactor,
                    "From Base"));
                item_FovhdCostConv = convertToUtil.ToDecimal(this.iUomConvAmt.UomConvAmtFn(
                    FovhdCost,
                    UMConvFactor,
                    "From Base"));
                item_VovhdCostConv = convertToUtil.ToDecimal(this.iUomConvAmt.UomConvAmtFn(
                    VovhdCost,
                    UMConvFactor,
                    "From Base"));
                item_OutCostConv = convertToUtil.ToDecimal(this.iUomConvAmt.UomConvAmtFn(
                    OutCost,
                    UMConvFactor,
                    "From Base"));
                DefLoc = OutLoc;
                DefLot = OutLot;
                DefImportDocId = OutImportDocId;

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ShipLocDefaultSp
                var ShipLocDefault = this.iShipLocDefault.ShipLocDefaultSp(
                    Site: Site,
                    Whse: CurWhse,
                    Item: Item,
                    Loc: DefLoc,
                    Lot: DefLot,
                    Infobar: Infobar,
                    ImportDocId: DefImportDocId);
                Severity = ShipLocDefault.ReturnCode;
                DefLoc = ShipLocDefault.Loc;
                DefLot = ShipLocDefault.Lot;
                Infobar = ShipLocDefault.Infobar;
                DefImportDocId = ShipLocDefault.ImportDocId;

                #endregion ExecuteMethodCall

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    return (Severity, item_UM, item_Description, ItemExists, UMConvFactor, JobmatlExists, JobmatlByProduct, item_MatlCost, item_MatlCostConv, item_LaborCost, item_LaborCostConv, item_FovhdCost, item_FovhdCostConv, item_VovhdCost, item_VovhdCostConv, item_OutCost, item_OutCostConv, item_IssueBy, item_SerialTracked, item_LotTracked, OutLoc, OutLot, ReqQty, ReqQtyConv, QtyIssued, QtyIssuedConv, PlanCost, PlanCostConv, OnHandQty, OnHandQtyConv, ACost, AMatlCost, ALbrCost, AFovhdCost, AVovhdCost, AOutCost, CostCode, PoitemNonInvAcct, PoitemNonInvAcctUnit1, PoitemNonInvAcctUnit2, PoitemNonInvAcctUnit3, PoitemNonInvAcctUnit4, PoitemNonInvAcctAccessUnit1, PoitemNonInvAcctAccessUnit2, PoitemNonInvAcctAccessUnit3, PoitemNonInvAcctAccessUnit4, Infobar, Prompt, PromptButtons, OutImportDocId, WCOutside, JobmatlRecordDate, TrakcedPieces, ItemDimensionGroup, JobmatlRowPointer, JobmatlBackFlush, jobmatl_ManufacturerID, manufacturer_ManufacturerName, jobmatl_ManufacturerItem, manufacturerItem_ManufacturerItemDesc);
                }
                if (sQLUtil.SQLEqual(item_LotTracked, 1) == true)
                {
                    if (DefLoc == null)
                    {

                        #region CRUD LoadToVariable
                        var matltrackLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_DefLoc,"loc"},
                                {_DefLot,"lot"},
                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            maximumRows: 1,
                            tableName: "matltrack",
                            fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                            whereClause: collectionLoadRequestFactory.Clause("matltrack.ref_type = 'J' AND matltrack.ref_num = {3} AND matltrack.ref_line_suf = {1} AND matltrack.ref_release = {0} AND matltrack.item = {2}", OperNum, Suffix, Item, Job),
                            orderByClause: collectionLoadRequestFactory.Clause(" track_num DESC"));

                        var matltrackLoadResponse = this.appDB.Load(matltrackLoadRequest);
                        if (matltrackLoadResponse.Items.Count > 0)
                        {
                            DefLoc = _DefLoc;
                            DefLot = _DefLot;
                        }
                        #endregion  LoadToVariable

                    }

                }
                if (DefLoc == null)
                {

                    #region CRUD LoadToVariable
                    var itemlocLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_DefLoc,"loc"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        maximumRows: 1,
                        tableName: "itemloc",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause("whse = {0} AND item = {1}", CurWhse, Item),
                        orderByClause: collectionLoadRequestFactory.Clause(" rank"));

                    var itemlocLoadResponse = this.appDB.Load(itemlocLoadRequest);
                    if (itemlocLoadResponse.Items.Count > 0)
                    {
                        DefLoc = _DefLoc;
                    }
                    #endregion  LoadToVariable

                }
                OutLoc = stringUtil.IsNull(
                    OutLoc,
                    DefLoc);
                OutLot = stringUtil.IsNull(
                    OutLot,
                    DefLot);
                OutImportDocId = stringUtil.IsNull(
                    OutImportDocId,
                    DefImportDocId);
                if (sQLUtil.SQLEqual(JmtRETURN, 1) == true)
                {

                    #region CRUD LoadToVariable
                    var serial_allASserLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_OutLot,"ser.lot"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        maximumRows: 1,
                        tableName: "serial_all AS ser",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED) INNER JOIN ser_track AS st WITH (READUNCOMMITTED) ON st.ser_num = ser.ser_num INNER JOIN matltrack AS mt WITH (READUNCOMMITTED) ON mt.track_num = st.track_num"),
                        whereClause: collectionLoadRequestFactory.Clause("mt.ref_type = 'J' AND mt.ref_num = {4} AND mt.ref_line_suf = {1} AND ser.item = {2} AND ser.whse = {0} AND ser.site_ref = {3} AND ser.stat = 'O'", CurWhse, Suffix, Item, Site, Job),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var serial_allASserLoadResponse = this.appDB.Load(serial_allASserLoadRequest);
                    if (serial_allASserLoadResponse.Items.Count > 0)
                    {
                        OutLot = _OutLot;
                    }
                    #endregion  LoadToVariable

                }
                OutLot = stringUtil.IsNull(
                    OutLot,
                    DefLot);
                if (sQLUtil.SQLEqual(item_LotTracked, 1) == true)
                {

                    #region CRUD LoadToVariable
                    var lot_locLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_OnHandQty,"abs(lot_loc.qty_on_hand - lot_loc.qty_rsvd - lot_loc.qty_contained)"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "lot_loc",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("lot_loc.whse = {0} AND lot_loc.item = {3} AND lot_loc.loc = {1} AND lot_loc.lot = {2}", CurWhse, OutLoc, OutLot, Item),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var lot_locLoadResponse = this.appDB.Load(lot_locLoadRequest);
                    if (lot_locLoadResponse.Items.Count > 0)
                    {
                        OnHandQty = _OnHandQty;
                    }
                    #endregion  LoadToVariable

                }
                else
                {

                    #region CRUD LoadToVariable
                    var itemloc1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_OnHandQty,"SUM(itemloc.qty_on_hand - itemloc.qty_rsvd - itemloc.qty_contained)"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "itemloc",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("itemloc.whse = {0} AND itemloc.item = {1} AND itemloc.mrb_flag = 0 AND itemloc.loc_type = 'S'", CurWhse, Item),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var itemloc1LoadResponse = this.appDB.Load(itemloc1LoadRequest);
                    if (itemloc1LoadResponse.Items.Count > 0)
                    {
                        OnHandQty = _OnHandQty;
                    }
                    #endregion  LoadToVariable

                }
                OnHandQtyConv = convertToUtil.ToDecimal(this.iUomConvQty.UomConvQtyFn(
                    OnHandQty,
                    UMConvFactor,
                    "From Base"));

            }
            else
            {
                ItemExists = 0;
                OutImportDocId = null;
                OnHandQty = 0;
                OnHandQtyConv = 0;
                item_IssueBy = null;
                item_SerialTracked = 0;
                item_LotTracked = 0;
                OutLoc = null;
                OutLot = null;
                CostCode = null;

                #region CRUD LoadToVariable
                var jobmatl3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_item_RowPointer,"jobmatl.RowPointer"},
                        {_item_UM,"jobmatl.u_m"},
                        {_item_Description,"jobmatl.description"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "jobmatl",
                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                    whereClause: collectionLoadRequestFactory.Clause("jobmatl.job = {3} AND jobmatl.suffix = {2} AND jobmatl.oper_num = {1} AND jobmatl.Sequence = {0}", Sequence, OperNum, Suffix, Job),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var jobmatl3LoadResponse = this.appDB.Load(jobmatl3LoadRequest);
                if (jobmatl3LoadResponse.Items.Count > 0)
                {
                    item_RowPointer = _item_RowPointer;
                    item_UM = _item_UM;
                    item_Description = _item_Description;
                }
                #endregion  LoadToVariable

                if (PoitemNonInvAcct == null)
                {
                    if (ParmsAnalyticalLedger == null)
                    {

                        #region CRUD LoadToVariable
                        var parms1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_ParmsAnalyticalLedger,"analytical_ledger"},
                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "parms",
                            fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                            whereClause: collectionLoadRequestFactory.Clause(""),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var parms1LoadResponse = this.appDB.Load(parms1LoadRequest);
                        if (parms1LoadResponse.Items.Count > 0)
                        {
                            ParmsAnalyticalLedger = _ParmsAnalyticalLedger;
                        }
                        #endregion  LoadToVariable

                    }
                    if (sQLUtil.SQLEqual(ParmsAnalyticalLedger, 1) == true)
                    {

                        #region CRUD LoadToVariable
                        var poparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_PoitemNonInvAcct,"poparms.ana_inv_acct"},
                                {_PoitemNonInvAcctUnit1,"poparms.ana_inv_acct_unit1"},
                                {_PoitemNonInvAcctUnit2,"poparms.ana_inv_acct_unit2"},
                                {_PoitemNonInvAcctUnit3,"poparms.ana_inv_acct_unit3"},
                                {_PoitemNonInvAcctUnit4,"poparms.ana_inv_acct_unit4"},
                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "poparms",
                            fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                            whereClause: collectionLoadRequestFactory.Clause(""),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var poparmsLoadResponse = this.appDB.Load(poparmsLoadRequest);
                        if (poparmsLoadResponse.Items.Count > 0)
                        {
                            PoitemNonInvAcct = _PoitemNonInvAcct;
                            PoitemNonInvAcctUnit1 = _PoitemNonInvAcctUnit1;
                            PoitemNonInvAcctUnit2 = _PoitemNonInvAcctUnit2;
                            PoitemNonInvAcctUnit3 = _PoitemNonInvAcctUnit3;
                            PoitemNonInvAcctUnit4 = _PoitemNonInvAcctUnit4;
                        }
                        #endregion  LoadToVariable

                    }

                }

                #region CRUD LoadToVariable
                var jobmatl4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_PoitemNonInvAcct,$"CASE WHEN {variableUtil.GetQuotedValue<string>(PoitemNonInvAcct)} IS NULL THEN poitem.non_inv_acct ELSE {variableUtil.GetQuotedValue<string>(PoitemNonInvAcct)} END"},
                        {_PoitemNonInvAcctUnit1,$"CASE WHEN {variableUtil.GetQuotedValue<string>(PoitemNonInvAcctUnit1)} IS NULL THEN poitem.non_inv_acct_unit1 ELSE {variableUtil.GetQuotedValue<string>(PoitemNonInvAcctUnit1)} END"},
                        {_PoitemNonInvAcctUnit2,$"CASE WHEN {variableUtil.GetQuotedValue<string>(PoitemNonInvAcctUnit2)} IS NULL THEN poitem.non_inv_acct_unit2 ELSE {variableUtil.GetQuotedValue<string>(PoitemNonInvAcctUnit2)} END"},
                        {_PoitemNonInvAcctUnit3,$"CASE WHEN {variableUtil.GetQuotedValue<string>(PoitemNonInvAcctUnit3)} IS NULL THEN poitem.non_inv_acct_unit3 ELSE {variableUtil.GetQuotedValue<string>(PoitemNonInvAcctUnit3)} END"},
                        {_PoitemNonInvAcctUnit4,$"CASE WHEN {variableUtil.GetQuotedValue<string>(PoitemNonInvAcctUnit4)} IS NULL THEN poitem.non_inv_acct_unit4 ELSE {variableUtil.GetQuotedValue<string>(PoitemNonInvAcctUnit4)} END"},
                        {_item_MatlCst,"jobmatl.matl_cost"},
                        {_item_LaborCost,"jobmatl.lbr_cost"},
                        {_item_FovhdCost,"jobmatl.fovhd_cost"},
                        {_item_VovhdCost,"jobmatl.vovhd_cost"},
                        {_item_OutCost,"jobmatl.out_cost"},
                        {_item_MatlCstConv,"jobmatl.matl_cost * jobmatl.matl_qty"},
                        {_item_LaborCostConv,"jobmatl.lbr_cost * jobmatl.matl_qty"},
                        {_item_FovhdCostConv,"jobmatl.fovhd_cost * jobmatl.matl_qty"},
                        {_item_VovhdCostConv,"jobmatl.vovhd_cost * jobmatl.matl_qty"},
                        {_item_OutCostConv,"jobmatl.out_cost * jobmatl.matl_qty"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "jobmatl",
                    fromClause: collectionLoadRequestFactory.Clause(@" WITH (READUNCOMMITTED) INNER JOIN poitem WITH (READUNCOMMITTED) ON poitem.po_num = jobmatl.ref_num
						AND poitem.po_line = jobmatl.ref_line_suf
						AND poitem.po_release = jobmatl.ref_release"),
                    whereClause: collectionLoadRequestFactory.Clause("jobmatl.job = {3} AND jobmatl.suffix = {2} AND jobmatl.oper_num = {1} AND jobmatl.sequence = {0} AND jobmatl.ref_type = 'P'", Sequence, OperNum, Suffix, Job),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var jobmatl4LoadResponse = this.appDB.Load(jobmatl4LoadRequest);
                if (jobmatl4LoadResponse.Items.Count > 0)
                {
                    PoitemNonInvAcct = _PoitemNonInvAcct;
                    PoitemNonInvAcctUnit1 = _PoitemNonInvAcctUnit1;
                    PoitemNonInvAcctUnit2 = _PoitemNonInvAcctUnit2;
                    PoitemNonInvAcctUnit3 = _PoitemNonInvAcctUnit3;
                    PoitemNonInvAcctUnit4 = _PoitemNonInvAcctUnit4;
                    item_MatlCst = _item_MatlCst;
                    item_LaborCost = _item_LaborCost;
                    item_FovhdCost = _item_FovhdCost;
                    item_VovhdCost = _item_VovhdCost;
                    item_OutCost = _item_OutCost;
                    item_MatlCstConv = _item_MatlCstConv;
                    item_LaborCostConv = _item_LaborCostConv;
                    item_FovhdCostConv = _item_FovhdCostConv;
                    item_VovhdCostConv = _item_VovhdCostConv;
                    item_OutCostConv = _item_OutCostConv;
                }
                #endregion  LoadToVariable

                if (sQLUtil.SQLEqual(jobmatl4LoadResponse.Items.Count, 0) == true)
                {

                    #region CRUD LoadToVariable
                    var poitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_PoitemNonInvAcct,"poitem.non_inv_acct"},
                            {_PoitemNonInvAcctUnit1,"poitem.non_inv_acct_unit1"},
                            {_PoitemNonInvAcctUnit2,"poitem.non_inv_acct_unit2"},
                            {_PoitemNonInvAcctUnit3,"poitem.non_inv_acct_unit3"},
                            {_PoitemNonInvAcctUnit4,"poitem.non_inv_acct_unit4"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "poitem",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause("poitem.po_num = {2} AND poitem.po_line = {1} AND poitem.po_release = isnull({0}, 0)", PoRelease, PoLine, PoNum),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var poitemLoadResponse = this.appDB.Load(poitemLoadRequest);
                    if (poitemLoadResponse.Items.Count > 0)
                    {
                        PoitemNonInvAcct = _PoitemNonInvAcct;
                        PoitemNonInvAcctUnit1 = _PoitemNonInvAcctUnit1;
                        PoitemNonInvAcctUnit2 = _PoitemNonInvAcctUnit2;
                        PoitemNonInvAcctUnit3 = _PoitemNonInvAcctUnit3;
                        PoitemNonInvAcctUnit4 = _PoitemNonInvAcctUnit4;
                    }
                    #endregion  LoadToVariable

                    if (sQLUtil.SQLEqual(JobmatlExists, 1) == true)
                    {

                        #region CRUD LoadToVariable
                        var jobmatl5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_item_MatlCst,"jobmatl.matl_cost"},
                                {_item_LaborCost,"jobmatl.lbr_cost"},
                                {_item_FovhdCost,"jobmatl.fovhd_cost"},
                                {_item_VovhdCost,"jobmatl.vovhd_cost"},
                                {_item_OutCost,"jobmatl.out_cost"},
                                {_item_MatlCstConv,"jobmatl.matl_cost"},
                                {_item_LaborCostConv,"jobmatl.lbr_cost"},
                                {_item_FovhdCostConv,"jobmatl.fovhd_cost"},
                                {_item_VovhdCostConv,"jobmatl.vovhd_cost"},
                                {_item_OutCostConv,"jobmatl.out_cost"},
                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "jobmatl",
                            fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                            whereClause: collectionLoadRequestFactory.Clause("jobmatl.job = {3} AND jobmatl.suffix = {2} AND jobmatl.oper_num = {1} AND jobmatl.sequence = {0}", Sequence, OperNum, Suffix, Job),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var jobmatl5LoadResponse = this.appDB.Load(jobmatl5LoadRequest);
                        if (jobmatl5LoadResponse.Items.Count > 0)
                        {
                            item_MatlCst = _item_MatlCst;
                            item_LaborCost = _item_LaborCost;
                            item_FovhdCost = _item_FovhdCost;
                            item_VovhdCost = _item_VovhdCost;
                            item_OutCost = _item_OutCost;
                            item_MatlCstConv = _item_MatlCstConv;
                            item_LaborCostConv = _item_LaborCostConv;
                            item_FovhdCostConv = _item_FovhdCostConv;
                            item_VovhdCostConv = _item_VovhdCostConv;
                            item_OutCostConv = _item_OutCostConv;
                        }
                        #endregion  LoadToVariable

                    }

                }

            }
            if (PoitemNonInvAcct != null)
            {

                #region CRUD LoadToVariable
                var chart_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_PoitemNonInvAcctAccessUnit1,"chart_all.access_unit1"},
                        {_PoitemNonInvAcctAccessUnit2,"chart_all.access_unit2"},
                        {_PoitemNonInvAcctAccessUnit3,"chart_all.access_unit3"},
                        {_PoitemNonInvAcctAccessUnit4,"chart_all.access_unit4"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "chart_all",
                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                    whereClause: collectionLoadRequestFactory.Clause("chart_all.acct = {0} AND chart_all.site_ref = {1}", PoitemNonInvAcct, Site),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var chart_allLoadResponse = this.appDB.Load(chart_allLoadRequest);
                if (chart_allLoadResponse.Items.Count > 0)
                {
                    PoitemNonInvAcctAccessUnit1 = _PoitemNonInvAcctAccessUnit1;
                    PoitemNonInvAcctAccessUnit2 = _PoitemNonInvAcctAccessUnit2;
                    PoitemNonInvAcctAccessUnit3 = _PoitemNonInvAcctAccessUnit3;
                    PoitemNonInvAcctAccessUnit4 = _PoitemNonInvAcctAccessUnit4;
                }
                #endregion  LoadToVariable

            }
            if (OperNum != null)
            {

                #region CRUD LoadToVariable
                var jobrouteLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_WC,"jobroute.wc"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "jobroute",
                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                    whereClause: collectionLoadRequestFactory.Clause("jobroute.job = {2} AND jobroute.suffix = {1} AND jobroute.oper_num = {0}", OperNum, Suffix, Job),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var jobrouteLoadResponse = this.appDB.Load(jobrouteLoadRequest);
                if (jobrouteLoadResponse.Items.Count > 0)
                {
                    WC = _WC;
                }
                #endregion  LoadToVariable

                WCOutside = 0;

                #region CRUD LoadToVariable
                var wcLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_WCOutside,"outside"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "wc",
                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                    whereClause: collectionLoadRequestFactory.Clause("wc.wc = {0}", WC),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var wcLoadResponse = this.appDB.Load(wcLoadRequest);
                if (wcLoadResponse.Items.Count > 0)
                {
                    WCOutside = _WCOutside;
                }
                #endregion  LoadToVariable

            }
            if (sQLUtil.SQLEqual(job_OrdType, "K") == true)
            {
                CostCode = this.iGetCostCode.GetCostCodeFn(Item);

            }

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: GetVariableSp
            var GetVariable = this.iGetVariable.GetVariableSp(
                VariableName: "CallFromPORecv",
                DefaultValue: convertToUtil.ToString(0),
                DeleteVariable: 0,
                VariableValue: convertToUtil.ToString(CallFromPORecv),
                Infobar: Infobar);
            CallFromPORecv = convertToUtil.ToInt32(GetVariable.VariableValue);
            Infobar = GetVariable.Infobar;

            #endregion ExecuteMethodCall

            if (sQLUtil.SQLEqual(CallFromPORecv, 0) == true || sQLUtil.SQLEqual(WCOutside, 0) == true)
            {
                item_MatlCost = item_MatlCst;
                item_MatlCostConv = item_MatlCstConv;

            }
            return (Severity, item_UM, item_Description, ItemExists, UMConvFactor, JobmatlExists, JobmatlByProduct, item_MatlCost, item_MatlCostConv, item_LaborCost, item_LaborCostConv, item_FovhdCost, item_FovhdCostConv, item_VovhdCost, item_VovhdCostConv, item_OutCost, item_OutCostConv, item_IssueBy, item_SerialTracked, item_LotTracked, OutLoc, OutLot, ReqQty, ReqQtyConv, QtyIssued, QtyIssuedConv, PlanCost, PlanCostConv, OnHandQty, OnHandQtyConv, ACost, AMatlCost, ALbrCost, AFovhdCost, AVovhdCost, AOutCost, CostCode, PoitemNonInvAcct, PoitemNonInvAcctUnit1, PoitemNonInvAcctUnit2, PoitemNonInvAcctUnit3, PoitemNonInvAcctUnit4, PoitemNonInvAcctAccessUnit1, PoitemNonInvAcctAccessUnit2, PoitemNonInvAcctAccessUnit3, PoitemNonInvAcctAccessUnit4, Infobar, Prompt, PromptButtons, OutImportDocId, WCOutside, JobmatlRecordDate, TrakcedPieces, ItemDimensionGroup, JobmatlRowPointer, JobmatlBackFlush, jobmatl_ManufacturerID, manufacturer_ManufacturerName, jobmatl_ManufacturerItem, manufacturerItem_ManufacturerItemDesc);

        }
        public (int? ReturnCode,
            string item_UM,
            string item_Description,
            int? ItemExists,
            decimal? UMConvFactor,
            int? JobmatlExists,
            int? JobmatlByProduct,
            decimal? item_MatlCost,
            decimal? item_MatlCostConv,
            decimal? item_LaborCost,
            decimal? item_LaborCostConv,
            decimal? item_FovhdCost,
            decimal? item_FovhdCostConv,
            decimal? item_VovhdCost,
            decimal? item_VovhdCostConv,
            decimal? item_OutCost,
            decimal? item_OutCostConv,
            string item_IssueBy,
            int? item_SerialTracked,
            int? item_LotTracked,
            string OutLoc,
            string OutLot,
            decimal? ReqQty,
            decimal? ReqQtyConv,
            decimal? QtyIssued,
            decimal? QtyIssuedConv,
            decimal? PlanCost,
            decimal? PlanCostConv,
            decimal? OnHandQty,
            decimal? OnHandQtyConv,
            decimal? ACost,
            decimal? AMatlCost,
            decimal? ALbrCost,
            decimal? AFovhdCost,
            decimal? AVovhdCost,
            decimal? AOutCost,
            string CostCode,
            string PoitemNonInvAcct,
            string PoitemNonInvAcctUnit1,
            string PoitemNonInvAcctUnit2,
            string PoitemNonInvAcctUnit3,
            string PoitemNonInvAcctUnit4,
            string PoitemNonInvAcctAccessUnit1,
            string PoitemNonInvAcctAccessUnit2,
            string PoitemNonInvAcctAccessUnit3,
            string PoitemNonInvAcctAccessUnit4,
            string Infobar,
            string Prompt,
            string PromptButtons,
            string OutImportDocId,
            int? WCOutside,
            DateTime? JobmatlRecordDate,
            int? TrakcedPieces,
            string ItemDimensionGroup,
            Guid? JobmatlRowPointer,
            int? JobmatlBackFlush,
            string jobmatl_ManufacturerID,
            string manufacturer_ManufacturerName,
            string jobmatl_ManufacturerItem,
            string manufacturerItem_ManufacturerItemDesc)
        AltExtGen_GetJobMatlItemSp(
            string AltExtGenSp,
            string Item = null,
            string UM = null,
            string Job = null,
            int? Suffix = null,
            int? OperNum = null,
            int? Sequence = null,
            string CurWhse = null,
            int? ExtByScrap = null,
            string PoNum = null,
            int? PoLine = null,
            int? PoRelease = null,
            string item_UM = null,
            string item_Description = null,
            int? ItemExists = null,
            decimal? UMConvFactor = null,
            int? JobmatlExists = null,
            int? JobmatlByProduct = null,
            decimal? item_MatlCost = null,
            decimal? item_MatlCostConv = null,
            decimal? item_LaborCost = null,
            decimal? item_LaborCostConv = null,
            decimal? item_FovhdCost = null,
            decimal? item_FovhdCostConv = null,
            decimal? item_VovhdCost = null,
            decimal? item_VovhdCostConv = null,
            decimal? item_OutCost = null,
            decimal? item_OutCostConv = null,
            string item_IssueBy = null,
            int? item_SerialTracked = null,
            int? item_LotTracked = null,
            string OutLoc = null,
            string OutLot = null,
            decimal? ReqQty = null,
            decimal? ReqQtyConv = null,
            decimal? QtyIssued = null,
            decimal? QtyIssuedConv = null,
            decimal? PlanCost = null,
            decimal? PlanCostConv = null,
            decimal? OnHandQty = null,
            decimal? OnHandQtyConv = null,
            decimal? ACost = null,
            decimal? AMatlCost = null,
            decimal? ALbrCost = null,
            decimal? AFovhdCost = null,
            decimal? AVovhdCost = null,
            decimal? AOutCost = null,
            string CostCode = null,
            string PoitemNonInvAcct = null,
            string PoitemNonInvAcctUnit1 = null,
            string PoitemNonInvAcctUnit2 = null,
            string PoitemNonInvAcctUnit3 = null,
            string PoitemNonInvAcctUnit4 = null,
            string PoitemNonInvAcctAccessUnit1 = null,
            string PoitemNonInvAcctAccessUnit2 = null,
            string PoitemNonInvAcctAccessUnit3 = null,
            string PoitemNonInvAcctAccessUnit4 = null,
            string Infobar = null,
            string Prompt = null,
            string PromptButtons = null,
            string Site = null,
            string OutImportDocId = null,
            int? JmtRETURN = 0,
            int? WCOutside = 0,
            DateTime? JobmatlRecordDate = null,
            int? TrakcedPieces = 0,
            string ItemDimensionGroup = null,
            Guid? JobmatlRowPointer = null,
            int? JobmatlBackFlush = 0,
            string jobmatl_ManufacturerID = null,
            string manufacturer_ManufacturerName = null,
            string jobmatl_ManufacturerItem = null,
            string manufacturerItem_ManufacturerItemDesc = null)
        {
            ItemType _Item = Item;
            UMType _UM = UM;
            JobType _Job = Job;
            SuffixType _Suffix = Suffix;
            OperNumType _OperNum = OperNum;
            JobmatlSequenceType _Sequence = Sequence;
            WhseType _CurWhse = CurWhse;
            ListYesNoType _ExtByScrap = ExtByScrap;
            PoNumType _PoNum = PoNum;
            PoLineType _PoLine = PoLine;
            PoReleaseType _PoRelease = PoRelease;
            UMType _item_UM = item_UM;
            DescriptionType _item_Description = item_Description;
            ListYesNoType _ItemExists = ItemExists;
            UMConvFactorType _UMConvFactor = UMConvFactor;
            ListYesNoType _JobmatlExists = JobmatlExists;
            ListYesNoType _JobmatlByProduct = JobmatlByProduct;
            CostPrcType _item_MatlCost = item_MatlCost;
            CostPrcType _item_MatlCostConv = item_MatlCostConv;
            CostPrcType _item_LaborCost = item_LaborCost;
            CostPrcType _item_LaborCostConv = item_LaborCostConv;
            CostPrcType _item_FovhdCost = item_FovhdCost;
            CostPrcType _item_FovhdCostConv = item_FovhdCostConv;
            CostPrcType _item_VovhdCost = item_VovhdCost;
            CostPrcType _item_VovhdCostConv = item_VovhdCostConv;
            CostPrcType _item_OutCost = item_OutCost;
            CostPrcType _item_OutCostConv = item_OutCostConv;
            ListLocLotType _item_IssueBy = item_IssueBy;
            ListYesNoType _item_SerialTracked = item_SerialTracked;
            ListYesNoType _item_LotTracked = item_LotTracked;
            LocType _OutLoc = OutLoc;
            LotType _OutLot = OutLot;
            QtyTotlType _ReqQty = ReqQty;
            QtyTotlType _ReqQtyConv = ReqQtyConv;
            QtyPerType _QtyIssued = QtyIssued;
            QtyPerType _QtyIssuedConv = QtyIssuedConv;
            CostPrcType _PlanCost = PlanCost;
            CostPrcType _PlanCostConv = PlanCostConv;
            QtyPerType _OnHandQty = OnHandQty;
            QtyPerType _OnHandQtyConv = OnHandQtyConv;
            CostPrcType _ACost = ACost;
            CostPrcType _AMatlCost = AMatlCost;
            CostPrcType _ALbrCost = ALbrCost;
            CostPrcType _AFovhdCost = AFovhdCost;
            CostPrcType _AVovhdCost = AVovhdCost;
            CostPrcType _AOutCost = AOutCost;
            CostCodeType _CostCode = CostCode;
            AcctType _PoitemNonInvAcct = PoitemNonInvAcct;
            UnitCode1Type _PoitemNonInvAcctUnit1 = PoitemNonInvAcctUnit1;
            UnitCode2Type _PoitemNonInvAcctUnit2 = PoitemNonInvAcctUnit2;
            UnitCode3Type _PoitemNonInvAcctUnit3 = PoitemNonInvAcctUnit3;
            UnitCode4Type _PoitemNonInvAcctUnit4 = PoitemNonInvAcctUnit4;
            UnitCodeAccessType _PoitemNonInvAcctAccessUnit1 = PoitemNonInvAcctAccessUnit1;
            UnitCodeAccessType _PoitemNonInvAcctAccessUnit2 = PoitemNonInvAcctAccessUnit2;
            UnitCodeAccessType _PoitemNonInvAcctAccessUnit3 = PoitemNonInvAcctAccessUnit3;
            UnitCodeAccessType _PoitemNonInvAcctAccessUnit4 = PoitemNonInvAcctAccessUnit4;
            InfobarType _Infobar = Infobar;
            InfobarType _Prompt = Prompt;
            InfobarType _PromptButtons = PromptButtons;
            SiteType _Site = Site;
            ImportDocIdType _OutImportDocId = OutImportDocId;
            ListYesNoType _JmtRETURN = JmtRETURN;
            ListYesNoType _WCOutside = WCOutside;
            DateType _JobmatlRecordDate = JobmatlRecordDate;
            FlagNyType _TrakcedPieces = TrakcedPieces;
            AttributeGroupType _ItemDimensionGroup = ItemDimensionGroup;
            RowPointerType _JobmatlRowPointer = JobmatlRowPointer;
            ListYesNoType _JobmatlBackFlush = JobmatlBackFlush;
            ManufacturerIdType _jobmatl_ManufacturerID = jobmatl_ManufacturerID;
            NameType _manufacturer_ManufacturerName = manufacturer_ManufacturerName;
            ManufacturerItemType _jobmatl_ManufacturerItem = jobmatl_ManufacturerItem;
            DescriptionType _manufacturerItem_ManufacturerItemDesc = manufacturerItem_ManufacturerItemDesc;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExtByScrap", _ExtByScrap, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "item_UM", _item_UM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_Description", _item_Description, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UMConvFactor", _UMConvFactor, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobmatlExists", _JobmatlExists, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobmatlByProduct", _JobmatlByProduct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_MatlCost", _item_MatlCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_MatlCostConv", _item_MatlCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_LaborCost", _item_LaborCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_LaborCostConv", _item_LaborCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_FovhdCost", _item_FovhdCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_FovhdCostConv", _item_FovhdCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_VovhdCost", _item_VovhdCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_VovhdCostConv", _item_VovhdCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_OutCost", _item_OutCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_OutCostConv", _item_OutCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_IssueBy", _item_IssueBy, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_SerialTracked", _item_SerialTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "item_LotTracked", _item_LotTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutLoc", _OutLoc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutLot", _OutLot, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ReqQty", _ReqQty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ReqQtyConv", _ReqQtyConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyIssued", _QtyIssued, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyIssuedConv", _QtyIssuedConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PlanCost", _PlanCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PlanCostConv", _PlanCostConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OnHandQty", _OnHandQty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OnHandQtyConv", _OnHandQtyConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ACost", _ACost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AMatlCost", _AMatlCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ALbrCost", _ALbrCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AFovhdCost", _AFovhdCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AVovhdCost", _AVovhdCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AOutCost", _AOutCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CostCode", _CostCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PoitemNonInvAcct", _PoitemNonInvAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PoitemNonInvAcctUnit1", _PoitemNonInvAcctUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PoitemNonInvAcctUnit2", _PoitemNonInvAcctUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PoitemNonInvAcctUnit3", _PoitemNonInvAcctUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PoitemNonInvAcctUnit4", _PoitemNonInvAcctUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PoitemNonInvAcctAccessUnit1", _PoitemNonInvAcctAccessUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PoitemNonInvAcctAccessUnit2", _PoitemNonInvAcctAccessUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PoitemNonInvAcctAccessUnit3", _PoitemNonInvAcctAccessUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PoitemNonInvAcctAccessUnit4", _PoitemNonInvAcctAccessUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutImportDocId", _OutImportDocId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JmtRETURN", _JmtRETURN, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WCOutside", _WCOutside, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobmatlRecordDate", _JobmatlRecordDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TrakcedPieces", _TrakcedPieces, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemDimensionGroup", _ItemDimensionGroup, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobmatlRowPointer", _JobmatlRowPointer, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobmatlBackFlush", _JobmatlBackFlush, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "jobmatl_ManufacturerID", _jobmatl_ManufacturerID, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "manufacturer_ManufacturerName", _manufacturer_ManufacturerName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "jobmatl_ManufacturerItem", _jobmatl_ManufacturerItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "manufacturerItem_ManufacturerItemDesc", _manufacturerItem_ManufacturerItemDesc, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                item_UM = _item_UM;
                item_Description = _item_Description;
                ItemExists = _ItemExists;
                UMConvFactor = _UMConvFactor;
                JobmatlExists = _JobmatlExists;
                JobmatlByProduct = _JobmatlByProduct;
                item_MatlCost = _item_MatlCost;
                item_MatlCostConv = _item_MatlCostConv;
                item_LaborCost = _item_LaborCost;
                item_LaborCostConv = _item_LaborCostConv;
                item_FovhdCost = _item_FovhdCost;
                item_FovhdCostConv = _item_FovhdCostConv;
                item_VovhdCost = _item_VovhdCost;
                item_VovhdCostConv = _item_VovhdCostConv;
                item_OutCost = _item_OutCost;
                item_OutCostConv = _item_OutCostConv;
                item_IssueBy = _item_IssueBy;
                item_SerialTracked = _item_SerialTracked;
                item_LotTracked = _item_LotTracked;
                OutLoc = _OutLoc;
                OutLot = _OutLot;
                ReqQty = _ReqQty;
                ReqQtyConv = _ReqQtyConv;
                QtyIssued = _QtyIssued;
                QtyIssuedConv = _QtyIssuedConv;
                PlanCost = _PlanCost;
                PlanCostConv = _PlanCostConv;
                OnHandQty = _OnHandQty;
                OnHandQtyConv = _OnHandQtyConv;
                ACost = _ACost;
                AMatlCost = _AMatlCost;
                ALbrCost = _ALbrCost;
                AFovhdCost = _AFovhdCost;
                AVovhdCost = _AVovhdCost;
                AOutCost = _AOutCost;
                CostCode = _CostCode;
                PoitemNonInvAcct = _PoitemNonInvAcct;
                PoitemNonInvAcctUnit1 = _PoitemNonInvAcctUnit1;
                PoitemNonInvAcctUnit2 = _PoitemNonInvAcctUnit2;
                PoitemNonInvAcctUnit3 = _PoitemNonInvAcctUnit3;
                PoitemNonInvAcctUnit4 = _PoitemNonInvAcctUnit4;
                PoitemNonInvAcctAccessUnit1 = _PoitemNonInvAcctAccessUnit1;
                PoitemNonInvAcctAccessUnit2 = _PoitemNonInvAcctAccessUnit2;
                PoitemNonInvAcctAccessUnit3 = _PoitemNonInvAcctAccessUnit3;
                PoitemNonInvAcctAccessUnit4 = _PoitemNonInvAcctAccessUnit4;
                Infobar = _Infobar;
                Prompt = _Prompt;
                PromptButtons = _PromptButtons;
                OutImportDocId = _OutImportDocId;
                WCOutside = _WCOutside;
                JobmatlRecordDate = _JobmatlRecordDate;
                TrakcedPieces = _TrakcedPieces;
                ItemDimensionGroup = _ItemDimensionGroup;
                JobmatlRowPointer = _JobmatlRowPointer;
                JobmatlBackFlush = _JobmatlBackFlush;
                jobmatl_ManufacturerID = _jobmatl_ManufacturerID;
                manufacturer_ManufacturerName = _manufacturer_ManufacturerName;
                jobmatl_ManufacturerItem = _jobmatl_ManufacturerItem;
                manufacturerItem_ManufacturerItemDesc = _manufacturerItem_ManufacturerItemDesc;

                return (Severity, item_UM, item_Description, ItemExists, UMConvFactor, JobmatlExists, JobmatlByProduct, item_MatlCost, item_MatlCostConv, item_LaborCost, item_LaborCostConv, item_FovhdCost, item_FovhdCostConv, item_VovhdCost, item_VovhdCostConv, item_OutCost, item_OutCostConv, item_IssueBy, item_SerialTracked, item_LotTracked, OutLoc, OutLot, ReqQty, ReqQtyConv, QtyIssued, QtyIssuedConv, PlanCost, PlanCostConv, OnHandQty, OnHandQtyConv, ACost, AMatlCost, ALbrCost, AFovhdCost, AVovhdCost, AOutCost, CostCode, PoitemNonInvAcct, PoitemNonInvAcctUnit1, PoitemNonInvAcctUnit2, PoitemNonInvAcctUnit3, PoitemNonInvAcctUnit4, PoitemNonInvAcctAccessUnit1, PoitemNonInvAcctAccessUnit2, PoitemNonInvAcctAccessUnit3, PoitemNonInvAcctAccessUnit4, Infobar, Prompt, PromptButtons, OutImportDocId, WCOutside, JobmatlRecordDate, TrakcedPieces, ItemDimensionGroup, JobmatlRowPointer, JobmatlBackFlush, jobmatl_ManufacturerID, manufacturer_ManufacturerName, jobmatl_ManufacturerItem, manufacturerItem_ManufacturerItemDesc);
            }
        }

    }
}
