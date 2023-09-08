//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VouchersPayable.cs

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

namespace CSI.Reporting
{
    public class Rpt_VouchersPayable : IRpt_VouchersPayable
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly IRpt_VouchersPayableSub rpt_VouchersPayableSub;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICloseSessionContext iCloseSessionContext;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly ILowString lowString;
        readonly IHighString highString;
        readonly IMathUtil mathUtil;
        readonly IRpt_VouchersPayableCRUD rpt_VouchersPayableCRUD;
        DateTime startTime;

        public Rpt_VouchersPayable(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICloseSessionContext iCloseSessionContext,
            ITransactionFactory transactionFactory,
            IGetIsolationLevel iGetIsolationLevel,
            IApplyDateOffset iApplyDateOffset,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IDefineProcessVariable defineProcessVariable,
            IGetVariable getVariable,
            IRpt_VouchersPayableSub rpt_VouchersPayableSub,
            ILowString lowString,
            IHighString highString,
            IMathUtil mathUtil,
            IRpt_VouchersPayableCRUD rpt_VouchersPayableCRUD)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iCloseSessionContext = iCloseSessionContext;
            this.transactionFactory = transactionFactory;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.iApplyDateOffset = iApplyDateOffset;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.defineProcessVariable = defineProcessVariable;
            this.getVariable = getVariable;
            this.sQLUtil = sQLUtil;
            this.rpt_VouchersPayableSub = rpt_VouchersPayableSub;
            this.lowString = lowString;
            this.highString = highString;
            this.mathUtil = mathUtil;
            this.rpt_VouchersPayableCRUD = rpt_VouchersPayableCRUD;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_VouchersPayableSp(string POType = null,
            int? TransDomCurr = null,
            int? ShowDetail = null,
            DateTime? CutoffDate = null,
            string PoStarting = null,
            string PoEnding = null,
            string VendorStarting = null,
            string VendorEnding = null,
            int? CutoffDateOffset = null,
            int? DisplayHeader = null,
            string SiteGroup = null,
            string BuilderPoStarting = null,
            string BuilderPoEnding = null,
            int? TaskId = null,
            int? PrintItemOverview = null,
            string BGSessionId = null,
            string pSite = null)
        {
            SiteGroupType _SiteGroup = SiteGroup;
            ICollectionLoadResponse Data = null;
            bunchedLoadCollection.StartBunching();

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            Guid? RptSessionID = null;
            int? Severity = null;
            string Infobar = null;

            startTime = DateTime.Now;

            #region ETP Block
            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_VouchersPayableSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_VouchersPayableSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_VouchersPayableSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = rpt_VouchersPayableCRUD.AltExtGen_Rpt_VouchersPayableSp(_ALTGEN_SpName,
                        POType,
                        TransDomCurr,
                        ShowDetail,
                        CutoffDate,
                        PoStarting,
                        PoEnding,
                        VendorStarting,
                        VendorEnding,
                        CutoffDateOffset,
                        DisplayHeader,
                        SiteGroup,
                        BuilderPoStarting,
                        BuilderPoEnding,
                        TaskId,
                        PrintItemOverview,
                        BGSessionId,
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_VouchersPayableSp") != null)
            {
                var EXTGEN = rpt_VouchersPayableCRUD.AltExtGen_Rpt_VouchersPayableSp("dbo.EXTGEN_Rpt_VouchersPayableSp",
                    POType,
                    TransDomCurr,
                    ShowDetail,
                    CutoffDate,
                    PoStarting,
                    PoEnding,
                    VendorStarting,
                    VendorEnding,
                    CutoffDateOffset,
                    DisplayHeader,
                    SiteGroup,
                    BuilderPoStarting,
                    BuilderPoEnding,
                    TaskId,
                    PrintItemOverview,
                    BGSessionId,
                    pSite);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }
            #endregion 

            this.transactionFactory.BeginTransaction("");
            this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("VouchersPayableReport"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            }
            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
            var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(Date: CutoffDate
                , Offset: CutoffDateOffset
                , IsEndDate: 1);
            CutoffDate = ApplyDateOffset.Date;

            #endregion ExecuteMethodCall

            POType = stringUtil.IsNull(POType, "RB");
            TransDomCurr = (int?)(stringUtil.IsNull(TransDomCurr, 1));
            ShowDetail = (int?)(stringUtil.IsNull(ShowDetail, 1));
            DisplayHeader = (int?)(stringUtil.IsNull(DisplayHeader, 1));
            PrintItemOverview = (int?)(stringUtil.IsNull(PrintItemOverview, 0));
            PoStarting = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("PoNumType", PoStarting), this.lowString.LowStringFn("PoNumType"));
            PoEnding = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("PoNumType", PoEnding), this.highString.HighStringFn("PoNumType"));
            VendorStarting = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("VendNumType", VendorStarting), this.lowString.LowStringFn("VendNumType"));
            VendorEnding = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("VendNumType", VendorEnding), this.highString.HighStringFn("VendNumType"));
            if (SiteGroup == null)
            {
                #region CRUD LoadToVariable
                var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_SiteGroup,"parms.site_group"},
                    },
                    loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "parms",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
                if (parmsLoadResponse.Items.Count > 0)
                {
                    SiteGroup = _SiteGroup;
                }
                #endregion  LoadToVariable
            }
            Severity = 0;
            

            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @VchPayTable TABLE (
				    VendNum              VendNumType        ,
				    VendName             NameType           ,
				    ItemNum              ItemType           ,
				    ItemDesc             NVARCHAR (60)      ,
				    PoCurrCode           CurrCodeType       ,
				    CurrDesc             DescriptionType    ,
				    PoNum                PoNumType          ,
				    PoLine               PoLineType         ,
				    PoRelease            PoReleaseType      ,
				    PoitemDesc           DescriptionType    ,
				    RType                INT                ,
				    QtyNotVchd           QtyUnitType        ,
				    PUM                  UMType             ,
				    MatlRcvdAmt          AmountType         ,
				    MatlVchdAmt          AmountType         ,
				    VPMatlAmt            AmountType         ,
				    MatlAdj              AmountType         ,
				    LCType               NCHAR (10)         ,
				    LCAmt                AmountType         ,
				    LCVchd               AmountType         ,
				    LCToVch              AmountType         ,
				    PVRcvdDate           DateType           ,
				    PVType               NCHAR (10)         ,
				    PVQty                DECIMAL (18, 8)    ,
				    PVItemCost           DECIMAL (18, 8)    ,
				    PVGrnNum             NVARCHAR (40)      ,
				    PVPackNum            NVARCHAR (40)      ,
				    LCTypeOrder          TINYINT            ,
				    PoBuilderPoOrigSite  SiteType           ,
				    PoBuilderPoNum       BuilderPoNumType   ,
				    PoSiteRef            SiteType           ,
				    QtyUnitFormat        InputMaskType      ,
				    QtyUnitPlaces        DecimalPlacesType  ,
				    AmountFormat         InputMaskType      ,
				    AmountPlaces         DecimalPlacesType  ,
				    CostPriceFormat      InputMaskType      ,
				    CostPricePlaces      DecimalPlacesType  ,
				    ItemOverview         ProductOverviewType,
				    DisplayDetailHeading FlagNyType         );
				SELECT * into #tv_VchPayTable from @VchPayTable");

            #region CRUD InsertByMethodCall
            //Please Generate the bounce for this stored procedure:Rpt_VouchersPayableSubSp
            var tv_VchPayTableMainExecResult = rpt_VouchersPayableSub.Rpt_VouchersPayableSubSp(POType: POType
                , TransDomCurr: TransDomCurr
                , ShowDetail: ShowDetail
                , CutoffDate: CutoffDate
                , PoStarting: PoStarting
                , PoEnding: PoEnding
                , VendorStarting: VendorStarting
                , VendorEnding: VendorEnding
                , CutoffDateOffset: CutoffDateOffset
                , DisplayHeader: DisplayHeader
                , SiteGroup: SiteGroup
                , BuilderPoStarting: BuilderPoStarting
                , BuilderPoEnding: BuilderPoEnding
                , BGSessionId: BGSessionId
                , TaskId: TaskId
                , Infobar: Infobar
                , PrintItemOverview: PrintItemOverview);


            var tv_VchPayTableInsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#tv_VchPayTable",
                items: tv_VchPayTableMainExecResult.Data.Items);

            this.appDB.Insert(tv_VchPayTableInsertRequest);

            ICollectionLoadResponse tv_VchPayTable2LoadResponse = rpt_VouchersPayableCRUD.AddSummaryFields(Severity);

            Data = tv_VchPayTable2LoadResponse;
            #endregion InsertByMethodCall
            this.transactionFactory.CommitTransaction("");
            
            

            #region CRUD ExecuteMethodCall
            //Please Generate the bounce for this stored procedure: CloseSessionContextSp
            var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);
            #endregion ExecuteMethodCall
            

            defineProcessVariable.DefineProcessVariableSp("RecordCap", (Data.Items.Count - 1).ToString(), null);
            (int? returnCode, string variableValue, string infobar) = getVariable.GetVariableSp("MyReport_Rpt", "", 0, "", "");
            defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
            bunchedLoadCollection.EndBunching();

            return (Data, Severity);
        }


    }
}
