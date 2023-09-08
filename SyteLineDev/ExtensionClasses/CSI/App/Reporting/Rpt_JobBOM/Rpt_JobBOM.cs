//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobBOM.cs

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
using CSI.Adapters;
using CSI.DataCollection;
using CSI.App.Reporting.Rpt_JobBOM;
using CSI.CRUD.Reporting;

namespace CSI.Reporting
{
	public class Rpt_JobBOM : IRpt_JobBOM
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly ITransactionFactory transactionFactory;
		readonly IGetIsolationLevel iGetIsolationLevel;
		readonly IGetWinRegDecGroup iGetWinRegDecGroup;
		readonly IFixMaskForCrystal iFixMaskForCrystal;
		readonly IIsAddonAvailable iIsAddonAvailable;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IHighAnyInt iHighAnyInt;
		readonly IUomConvAmt iUomConvAmt;
		readonly IUomConvQty iUomConvQty;
		readonly IStringUtil stringUtil;
		readonly ILowAnyInt iLowAnyInt;
		readonly IGetCode iGetCode;
		readonly IGetumcf iGetumcf;
		readonly ISQLValueComparerUtil sQLUtil;
        readonly ILowString lowString;
        readonly IHighString highString;
        readonly IRpt_JobBOMCRUD iRpt_JobBOMCRUD;
        readonly IRpt_JobBOMChangeValueForUbVisibleAndUbFlag rpt_JobBOMChangeValueForUbVisibleAndUbFlag;
        public Rpt_JobBOM(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			ITransactionFactory transactionFactory,
			IGetIsolationLevel iGetIsolationLevel,
			IGetWinRegDecGroup iGetWinRegDecGroup,
			IFixMaskForCrystal iFixMaskForCrystal,
			IIsAddonAvailable iIsAddonAvailable,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IHighAnyInt iHighAnyInt,
			IUomConvAmt iUomConvAmt,
			IUomConvQty iUomConvQty,
			IStringUtil stringUtil,
			ILowAnyInt iLowAnyInt,
			IGetCode iGetCode,
			IGetumcf iGetumcf,
			ISQLValueComparerUtil sQLUtil,
            ILowString lowString,
            IHighString highString,
            IRpt_JobBOMCRUD iRpt_JobBOMCRUD,
            IRpt_JobBOMChangeValueForUbVisibleAndUbFlag rpt_JobBOMChangeValueForUbVisibleAndUbFlag
            )
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.transactionFactory = transactionFactory;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.iGetWinRegDecGroup = iGetWinRegDecGroup;
			this.iFixMaskForCrystal = iFixMaskForCrystal;
			this.iIsAddonAvailable = iIsAddonAvailable;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.iHighAnyInt = iHighAnyInt;
			this.iUomConvAmt = iUomConvAmt;
			this.iUomConvQty = iUomConvQty;
			this.stringUtil = stringUtil;
			this.iLowAnyInt = iLowAnyInt;
			this.iGetCode = iGetCode;
			this.iGetumcf = iGetumcf;
			this.sQLUtil = sQLUtil;
            this.lowString = lowString;
            this.highString = highString;
            this.iRpt_JobBOMCRUD = iRpt_JobBOMCRUD;
            this.rpt_JobBOMChangeValueForUbVisibleAndUbFlag = rpt_JobBOMChangeValueForUbVisibleAndUbFlag;
        }

        public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_JobBOMSp(
			string JobStarting = null,
			string JobEnding = null,
			int? SuffixStarting = null,
			int? SuffixEnding = null,
			string PageJob3 = null,
			int? RefFields = null,
			string SortBy = null,
			string DisplayLevel = null,
			int? PrintCost = null,
			int? DisplayHeader = null,
			string pSite = null)
        {
            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            Guid? RptSessionID = null;
            string FromType = null;
            string job = null;
            int? suffix = null;
            ItemType _item = DBNull.Value;
            string item = null;
            decimal? qtyreleased = null;
            RevisionType _revision = DBNull.Value;
            string revision = null;
            string indenture = null;
            string tJob = null;
            QtyTotlType _tcqtureleased = DBNull.Value;
            decimal? tcqtureleased = null;
            decimal? tcqtpqtyconv = null;
            UMType _ItemUM = DBNull.Value;
            string ItemUM = null;
            UMType _CoitemUM = DBNull.Value;
            string CoitemUM = null;
            string tUnit = null;
            string tRef = null;
            int? BOMseq = null;
            int? backflush = null;
            RevisionType _tRevision = DBNull.Value;
            string tRevision = null;
            string matltype = null;
            string t_matltype = null;
            int? lev = null;
            decimal? tcqtpqty = null;
            QtyTotlType _saveqty = DBNull.Value;
            decimal? saveqty = null;
            int? Alternate = null;
            string tDesc = null;
            decimal? tUnitCost = null;
            string ordNum = null;
            int? ordLine = null;
            int? ordRelease = null;
            string JobmatlUM = null;
            CostPrcType _cost = DBNull.Value;
            decimal? cost = null;
            int? check = null;
            int? currSuffix = null;
            string job2 = null;
            int? suffix2 = null;
            int? opernum = null;
            int? sequence = null;
            string reftype = null;
            string refnum = null;
            int? reflinesuf = null;
            decimal? uomconvfactor = null;
            int? check2 = null;
            string stdmsg = null;
            string units = null;
            string cuomconvfrombase = null;
            decimal? scrapfact = null;
            int? SortByItem = null;
            string refdes = null;
            string bubble = null;
            string assyseq = null;
            int? itemLevel2 = null;
            SiteType _ParmsSite = DBNull.Value;
            string ParmsSite = null;
            string SortString = null;
            InputMaskType _QtyUnitFormat = DBNull.Value;
            string QtyUnitFormat = null;
            DecimalPlacesType _PlacesQtyUnit = DBNull.Value;
            int? PlacesQtyUnit = null;
            InputMaskType _QtyPerFormat = DBNull.Value;
            string QtyPerFormat = null;
            DecimalPlacesType _PlacesQtyPer = DBNull.Value;
            int? PlacesQtyPer = null;
            InputMaskType _CstPrcFormat = DBNull.Value;
            string CstPrcFormat = null;
            DecimalPlacesType _PlacesCp = DBNull.Value;
            int? PlacesCp = null;
            int? CoJob = null;
            int? CoProductMix = null;
            int? MOAddonAvailable = null;
            string UnitsLot = null;
            string UnitsUnit = null;
            ListYesNoType _CostItemAtWhse = DBNull.Value;
            int? CostItemAtWhse = null;
            WhseType _DefaultWhse = DBNull.Value;
            string DefaultWhse = null;
            string MatlTypeMaterial = null;
            string MatlTypeTool = null;
            string MatlTypeFixture = null;
            string MatlTypeOther = null;
            ICollectionLoadRequest jobCursorLoadRequestForCursor = null;
            ICollectionLoadResponse jobCursorLoadResponseForCursor = null;
            int jobCursor_CursorFetch_Status = -1;
            int jobCursor_CursorCounter = -1;
            ICollectionLoadRequest loopCursorLoadRequestForCursor = null;
            ICollectionLoadResponse loopCursorLoadResponseForCursor = null;
            int loopCursor_CursorFetch_Status = -1;
            int loopCursor_CursorCounter = -1;
            ICollectionLoadRequest jobmatlCursorLoadRequestForCursor = null;
            ICollectionLoadResponse jobmatlCursorLoadResponseForCursor = null;
            int jobmatlCursor_CursorFetch_Status = -1;
            int jobmatlCursor_CursorCounter = -1;

            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_JobBOMSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_JobBOMSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_JobBOMSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_Rpt_JobBOMSp(_ALTGEN_SpName,
                        JobStarting,
                        JobEnding,
                        SuffixStarting,
                        SuffixEnding,
                        PageJob3,
                        RefFields,
                        SortBy,
                        DisplayLevel,
                        PrintCost,
                        DisplayHeader,
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_JobBOMSp") != null)
            {
                var EXTGEN = AltExtGen_Rpt_JobBOMSp("dbo.EXTGEN_Rpt_JobBOMSp",
                    JobStarting,
                    JobEnding,
                    SuffixStarting,
                    SuffixEnding,
                    PageJob3,
                    RefFields,
                    SortBy,
                    DisplayLevel,
                    PrintCost,
                    DisplayHeader,
                    pSite);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            this.transactionFactory.BeginTransaction("");
            this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
            if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("JobBOMReport"), "COMMITTED") == true)
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
            }
            else
            {
                this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            }

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InitSessionContextSp
            var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(
                ContextName: "Rpt_JobBOMSp",
                SessionID: RptSessionID,
                Site: pSite);
            RptSessionID = InitSessionContext.SessionID;

            #endregion ExecuteMethodCall

            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @tempOutput TABLE (
				    lev                  NVARCHAR (20)    ,
				    item                 ItemType         ,
				    job                  JobType          ,
				    jobtype              NVARCHAR (10)    ,
				    qty_rel              QtyTotlType      ,
				    qty_per              QtyTotlType      ,
				    u_m                  UMType           ,
				    type                 NVARCHAR (10)    ,
				    ref                  RefTypeIJKPRTType,
				    oper                 OperNumType      ,
				    sequence             INT              ,
				    BOM_seq              EcnBomSeqType    ,
				    backflush            ListYesNoType    ,
				    revision             RevisionType     ,
				    description          DescriptionType  ,
				    unit_cost            CostPrcType      ,
				    ref_des              NVARCHAR (10)    ,
				    bubble               NVARCHAR (4)     ,
				    assy_seq             NVARCHAR (4)     ,
				    alternate            TINYINT          ,
				    qty_unit_format      InputMaskType    ,
				    places_qty_unit      DecimalPlacesType,
				    qty_per_format       InputMaskType    ,
				    places_qty_per       DecimalPlacesType,
				    cst_prc_format       InputMaskType    ,
				    places_cp            DecimalPlacesType,
				    co_job               ListYesNoType    ,
				    co_prod              ItemType         ,
				    co_prod_qty_released QtyUnitType      ,
				    co_job_item          ItemType         ,
				    co_job_qty_received  QtyUnitType      ,
				    co_job_qty_complete  QtyUnitType      ,
				    co_job_qty_scrapped  QtyUnitType      ,
				    suffix               SuffixType       ,
				    job_id               JobType          ,
				    oper_num_for_link    OperNumType      );
				SELECT * into #tv_tempOutput from @tempOutput ");

            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @loop TABLE (
				    job               NVARCHAR (20)   ,
				    suffix            INT             ,
				    oper_num          INT             ,
				    sequence          INT             ,
				    ref_num           NVARCHAR (20)   ,
				    ref_line_suf      INT             ,
				    item              NVARCHAR (30)   ,
				    itemLevel         INT             ,
				    sort_string       NVARCHAR (1000) ,
				    matl_qty          DECIMAL (25, 10),
				    matl_qty_conv     DECIMAL (25, 10),
				    ref_type          NVARCHAR (1)    ,
				    bom_seq           INT             ,
				    backflush         BIT             ,
				    u_m               NVARCHAR (5)    ,
				    units             NVARCHAR (1)    ,
				    scrap_fact        DECIMAL (25, 10),
				    matl_type         NVARCHAR (1)    ,
				    description       NVARCHAR (50)   ,
				    cost_conv         DECIMAL (25, 10),
				    revision          NVARCHAR (50)   ,
				    planned_alternate BIT             );
				SELECT * into #tv_loop from @loop ");

            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @loop2 TABLE (
				    job               NVARCHAR (20)   ,
				    suffix            INT             ,
				    oper_num          INT             ,
				    sequence          INT             ,
				    ref_num           NVARCHAR (20)   ,
				    ref_line_suf      INT             ,
				    item              NVARCHAR (30)   ,
				    itemLevel         INT             ,
				    sort_string       NVARCHAR (1000) ,
				    matl_qty          DECIMAL (25, 10),
				    matl_qty_conv     DECIMAL (25, 10),
				    ref_type          NVARCHAR (1)    ,
				    bom_seq           INT             ,
				    backflush         BIT             ,
				    u_m               NVARCHAR (5)    ,
				    units             NVARCHAR (1)    ,
				    scrap_fact        DECIMAL (25, 10),
				    matl_type         NVARCHAR (1)    ,
				    description       NVARCHAR (50)   ,
				    cost_conv         DECIMAL (25, 10),
				    revision          NVARCHAR (50)   ,
				    planned_alternate BIT             ,
				    sort_seq          INT              IDENTITY (1, 1));
				SELECT * into #tv_loop2 from @loop2 
				ALTER TABLE #tv_loop2 ADD PRIMARY KEY (sort_seq) ");

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: GetCodeSp
            var GetCode = this.iGetCode.GetCodeSp(
                PClass: "jobmatl.units",
                PCode: "L",
                PDesc: UnitsLot);
            UnitsLot = GetCode.PDesc;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: GetCodeSp
            var GetCode1 = this.iGetCode.GetCodeSp(
                PClass: "jobmatl.units",
                PCode: "U",
                PDesc: UnitsUnit);
            UnitsUnit = GetCode1.PDesc;

            #endregion ExecuteMethodCall

            #region CRUD LoadToVariable
            var dbo_invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CostItemAtWhse,"ISNULL(invparms.cost_item_at_whse, 0)"},
                    {_DefaultWhse,"def_whse"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "dbo.invparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var dbo_invparmsLoadResponse = this.appDB.Load(dbo_invparmsLoadRequest);
            if (dbo_invparmsLoadResponse.Items.Count > 0)
            {
                CostItemAtWhse = _CostItemAtWhse;
                DefaultWhse = _DefaultWhse;
            }
            #endregion  LoadToVariable

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: GetCodeSp
            var GetCode2 = this.iGetCode.GetCodeSp(
                PClass: "item.matl_type",
                PCode: "M",
                PDesc: MatlTypeMaterial);
            MatlTypeMaterial = GetCode2.PDesc;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: GetCodeSp
            var GetCode3 = this.iGetCode.GetCodeSp(
                PClass: "item.matl_type",
                PCode: "T",
                PDesc: MatlTypeTool);
            MatlTypeTool = GetCode3.PDesc;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: GetCodeSp
            var GetCode4 = this.iGetCode.GetCodeSp(
                PClass: "item.matl_type",
                PCode: "F",
                PDesc: MatlTypeFixture);
            MatlTypeFixture = GetCode4.PDesc;

            #endregion ExecuteMethodCall

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: GetCodeSp
            var GetCode5 = this.iGetCode.GetCodeSp(
                PClass: "item.matl_type",
                PCode: "O",
                PDesc: MatlTypeOther);
            MatlTypeOther = GetCode5.PDesc;

            #endregion ExecuteMethodCall

            #region CRUD LoadToVariable
            var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ParmsSite,"site"},
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
                ParmsSite = _ParmsSite;
            }
            #endregion  LoadToVariable


            #region CRUD LoadToVariable
            var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_QtyUnitFormat,"qty_unit_format"},
                    {_PlacesQtyUnit,"places_qty_unit"},
                    {_QtyPerFormat,"qty_per_format"},
                    {_PlacesQtyPer,"places_qty_per"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "invparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var invparmsLoadResponse = this.appDB.Load(invparmsLoadRequest);
            if (invparmsLoadResponse.Items.Count > 0)
            {
                QtyUnitFormat = _QtyUnitFormat;
                PlacesQtyUnit = _PlacesQtyUnit;
                QtyPerFormat = _QtyPerFormat;
                PlacesQtyPer = _PlacesQtyPer;
            }
            #endregion  LoadToVariable

            QtyUnitFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                QtyUnitFormat,
                this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
            QtyPerFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                QtyPerFormat,
                this.iGetWinRegDecGroup.GetWinRegDecGroupFn());

            #region CRUD LoadToVariable
            var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CstPrcFormat,"cst_prc_format"},
                    {_PlacesCp,"places_cp"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "currency",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("curr_code = (SELECT curr_code FROM currparms)"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var currencyLoadResponse = this.appDB.Load(currencyLoadRequest);
            if (currencyLoadResponse.Items.Count > 0)
            {
                CstPrcFormat = _CstPrcFormat;
                PlacesCp = _PlacesCp;
            }
            #endregion  LoadToVariable

            CstPrcFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                CstPrcFormat,
                this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
            JobStarting = stringUtil.IsNull(
                this.iExpandKyByType.ExpandKyByTypeFn(
                    "JobType",
                    JobStarting),
                this.lowString.LowStringFn("JobType"));
            JobEnding = stringUtil.IsNull(
                this.iExpandKyByType.ExpandKyByTypeFn(
                    "JobType",
                    JobEnding),
                this.highString.HighStringFn("JobType"));
            SuffixStarting = convertToUtil.ToInt32(stringUtil.IsNull(
                SuffixStarting,
                this.iLowAnyInt.LowAnyIntFn("SuffixType")));
            SuffixEnding = convertToUtil.ToInt32(stringUtil.IsNull(
                SuffixEnding,
                this.iHighAnyInt.HighAnyIntFn("SuffixType")));
            FromType = "J";
            cuomconvfrombase = "FROM Base";
            DisplayLevel = stringUtil.IsNull(
                DisplayLevel,
                "A");
            SortBy = stringUtil.IsNull(
                SortBy,
                "J");
            MOAddonAvailable = convertToUtil.ToInt32(this.iIsAddonAvailable.IsAddonAvailableFn("MoldingPack"));
            if (sQLUtil.SQLEqual(SortBy, "J") == true)
            {
                SortByItem = 0;
            }
            else
            {
                SortByItem = 1;
            }
            if (sQLUtil.SQLEqual(SortByItem, 1) == true)
            {
                if (sQLUtil.SQLEqual(DisplayLevel, "A") == true)
                {
                    #region Cursor Statement

                    #region CRUD LoadToRecord
                    jobCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"job","job.job"},
                            {"suffix","job.suffix"},
                            {"item","job.item"},
                            {"qty_released","job.qty_released"},
                            {"revision","job.revision"},
                            {"ord_num","job.ord_num"},
                            {"ord_line","job.ord_line"},
                            {"ord_release","job.ord_release"},
                            {"description","item.description"},
                            {"unit_cost","CAST (NULL AS DECIMAL)"},
                            {"u_m","item.u_m"},
                            {"co_product_mix","job.co_product_mix"},
                            {"MO_co_job","job.MO_co_job"},
                            {"u0","itemwhse.unit_cost"},
                            {"u1","item.unit_cost"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "job",
                        fromClause: collectionLoadRequestFactory.Clause(@" inner join item on item.item = job.item inner join itemwhse on item.item = itemwhse.item 
							and itemwhse.whse = {0}", DefaultWhse),
                        whereClause: collectionLoadRequestFactory.Clause("job.job BETWEEN {2} AND {3} AND (job.suffix >= CASE WHEN job.job = {2} THEN {0} ELSE 0 END) AND (job.suffix <= CASE WHEN job.job = {3} THEN {1} ELSE dbo.HighAnyInt('SuffixType') END) AND job.type = {4} AND job.job = job.root_job AND job.suffix = job.root_suf", SuffixStarting, SuffixEnding, JobStarting, JobEnding, FromType),
                        orderByClause: collectionLoadRequestFactory.Clause(" job.item"));
                    #endregion  LoadToRecord

                    #endregion Cursor Statement
                }
                else
                {
                    #region Cursor Statement

                    #region CRUD LoadToRecord
                    jobCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"job","job.job"},
                            {"suffix","job.suffix"},
                            {"item","job.item"},
                            {"qty_released","job.qty_released"},
                            {"revision","job.revision"},
                            {"ord_num","job.ord_num"},
                            {"ord_line","job.ord_line"},
                            {"ord_release","job.ord_release"},
                            {"description","item.description"},
                            {"unit_cost","CAST (NULL AS DECIMAL)"},
                            {"u_m","item.u_m"},
                            {"co_product_mix","job.co_product_mix"},
                            {"MO_co_job","job.MO_co_job"},
                            {"u0","itemwhse.unit_cost"},
                            {"u1","item.unit_cost"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "job",
                        fromClause: collectionLoadRequestFactory.Clause(@" inner join item on item.item = job.item inner join itemwhse on item.item = itemwhse.item 
							and itemwhse.whse = {0}", DefaultWhse),
                        whereClause: collectionLoadRequestFactory.Clause("job.job BETWEEN {2} AND {3} AND (job.suffix >= CASE WHEN job.job = {2} THEN {0} ELSE 0 END) AND (job.suffix <= CASE WHEN job.job = {3} THEN {1} ELSE dbo.HighAnyInt('SuffixType') END) AND job.type = {4}", SuffixStarting, SuffixEnding, JobStarting, JobEnding, FromType),
                        orderByClause: collectionLoadRequestFactory.Clause(" job.item"));
                    #endregion  LoadToRecord

                    #endregion Cursor Statement
                }
            }
            else
            {
                if (sQLUtil.SQLEqual(DisplayLevel, "A") == true)
                {
                    #region Cursor Statement

                    #region CRUD LoadToRecord
                    jobCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"job","job.job"},
                            {"suffix","job.suffix"},
                            {"item","job.item"},
                            {"qty_released","job.qty_released"},
                            {"revision","job.revision"},
                            {"ord_num","job.ord_num"},
                            {"ord_line","job.ord_line"},
                            {"ord_release","job.ord_release"},
                            {"description","item.description"},
                            {"unit_cost","CAST (NULL AS DECIMAL)"},
                            {"u_m","item.u_m"},
                            {"co_product_mix","job.co_product_mix"},
                            {"MO_co_job","job.MO_co_job"},
                            {"u0","itemwhse.unit_cost"},
                            {"u1","item.unit_cost"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "job",
                        fromClause: collectionLoadRequestFactory.Clause(@" inner join item on item.item = job.item inner join itemwhse on item.item = itemwhse.item 
							and itemwhse.whse = {0}", DefaultWhse),
                        whereClause: collectionLoadRequestFactory.Clause("job.job BETWEEN {2} AND {3} AND (job.suffix >= CASE WHEN job.job = {2} THEN {0} ELSE 0 END) AND (job.suffix <= CASE WHEN job.job = {3} THEN {1} ELSE dbo.HighAnyInt('SuffixType') END) AND job.type = {4} AND job.job = job.root_job AND job.suffix = job.root_suf", SuffixStarting, SuffixEnding, JobStarting, JobEnding, FromType),
                        orderByClause: collectionLoadRequestFactory.Clause(" job.job"));
                    #endregion  LoadToRecord

                    #endregion Cursor Statement
                }
                else
                {
                    #region Cursor Statement

                    #region CRUD LoadToRecord
                    jobCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"job","job.job"},
                            {"suffix","job.suffix"},
                            {"item","job.item"},
                            {"qty_released","job.qty_released"},
                            {"revision","job.revision"},
                            {"ord_num","job.ord_num"},
                            {"ord_line","job.ord_line"},
                            {"ord_release","job.ord_release"},
                            {"description","item.description"},
                            {"unit_cost","CAST (NULL AS DECIMAL)"},
                            {"u_m","item.u_m"},
                            {"co_product_mix","job.co_product_mix"},
                            {"MO_co_job","job.MO_co_job"},
                            {"u0","itemwhse.unit_cost"},
                            {"u1","item.unit_cost"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "job",
                        fromClause: collectionLoadRequestFactory.Clause(@" inner join item on item.item = job.item inner join itemwhse on item.item = itemwhse.item 
							and itemwhse.whse = {0}", DefaultWhse),
                        whereClause: collectionLoadRequestFactory.Clause("job.job BETWEEN {2} AND {3} AND (job.suffix >= CASE WHEN job.job = {2} THEN {0} ELSE 0 END) AND (job.suffix <= CASE WHEN job.job = {3} THEN {1} ELSE dbo.HighAnyInt('SuffixType') END) AND job.type = {4}", SuffixStarting, SuffixEnding, JobStarting, JobEnding, FromType),
                        orderByClause: collectionLoadRequestFactory.Clause(" job.job"));
                    #endregion  LoadToRecord

                    #endregion Cursor Statement
                }
            }
            jobCursorLoadResponseForCursor = this.appDB.Load(jobCursorLoadRequestForCursor);
            jobCursor_CursorFetch_Status = jobCursorLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
            jobCursor_CursorCounter = -1;

            while (sQLUtil.SQLEqual(1, 1) == true)
            {
                jobCursor_CursorCounter++;
                if (jobCursorLoadResponseForCursor.Items.Count > jobCursor_CursorCounter)
                {
                    job = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<string>(0);
                    suffix = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<int?>(1);
                    item = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<string>(2);
                    qtyreleased = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<decimal?>(3);
                    revision = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<string>(4);
                    ordNum = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<string>(5);
                    ordLine = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<int?>(6);
                    ordRelease = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<int?>(7);
                    tDesc = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<string>(8);
                    tUnitCost = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<decimal?>(9);
                    ItemUM = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<string>(10);
                    CoProductMix = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<int?>(11);
                    CoJob = jobCursorLoadResponseForCursor.Items[jobCursor_CursorCounter].GetValue<int?>(12);
                }
                jobCursor_CursorFetch_Status = (jobCursor_CursorCounter == jobCursorLoadResponseForCursor.Items.Count ? -1 : 0);

                if (sQLUtil.SQLNotEqual(jobCursor_CursorFetch_Status, 0) == true)
                {
                    break;
                }
                currSuffix = suffix;
                lev = 0;
                indenture = stringUtil.Concat(stringUtil.Char(1), "   ", Convert.ToString(lev));
                tJob = job;
                tcqtpqty = 1M;
                tRef = "";
                tcqtpqtyconv = 1M;
                tUnit = "";
                tRevision = "";
                SortString = "";
                tcqtureleased = qtyreleased;
                saveqty = qtyreleased;
                tRevision = revision;
                BOMseq = null;
                backflush = null;
                if (ordNum != null)
                {
                    #region CRUD LoadToVariable
                    var coitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_cost,"coitem.cost"},
                            {_CoitemUM,"coitem.u_m"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "coitem",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("co_num = {2} AND co_line = {1} AND co_release = {0} AND ref_num = {4} AND ref_line_suf = {3}", ordRelease, ordLine, ordNum, suffix, job),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var coitemLoadResponse = this.appDB.Load(coitemLoadRequest);
                    if (coitemLoadResponse.Items.Count > 0)
                    {
                        cost = _cost;
                        CoitemUM = _CoitemUM;
                    }
                    #endregion  LoadToVariable

                    if (sQLUtil.SQLGreaterThan(coitemLoadResponse.Items.Count, 0) == true)
                    {
                        if (sQLUtil.SQLNotEqual(CoitemUM, ItemUM) == true)
                        {
                            #region CRUD ExecuteMethodCall

                            //Please Generate the bounce for this stored procedure: GetumcfSp
                            var Getumcf = this.iGetumcf.GetumcfSp(
                                OtherUM: CoitemUM,
                                Item: item,
                                VendNum: null,
                                Area: null,
                                ConvFactor: uomconvfactor,
                                Infobar: stdmsg,
                                Site: ParmsSite);
                            uomconvfactor = Getumcf.ConvFactor;
                            stdmsg = Getumcf.Infobar;

                            #endregion ExecuteMethodCall

                            tUnitCost = convertToUtil.ToDecimal(this.iUomConvAmt.UomConvAmtFn(
                                cost,
                                uomconvfactor,
                                cuomconvfrombase));
                        }
                        else
                        {
                            tUnitCost = cost;
                        }
                    }
                }
                tUnitCost = (decimal?)(stringUtil.IsNull<decimal?>(
                    tUnitCost,
                    0));
                if (sQLUtil.SQLEqual(PrintCost, 0) == true)
                {
                    tUnitCost = 0;
                }

                #region CRUD LoadResponseWithoutTable
                var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                {
                    { "lev", variableUtil.GetValue<string>(indenture,true)},
                    { "item", variableUtil.GetValue<string>(item,true)},
                    { "job", variableUtil.GetValue<string>(tJob,true)},
                    { "qty_rel", variableUtil.GetValue<decimal?>(tcqtureleased,true)},
                    { "qty_per", variableUtil.GetValue<decimal?>(tcqtpqtyconv,true)},
                    { "u_m", variableUtil.GetValue<string>(ItemUM,true)},
                    { "type", variableUtil.GetValue<string>(tUnit,true)},
                    { "ref", variableUtil.GetValue<string>(tRef,true)},
                    { "oper", variableUtil.GetValue<int?>(opernum,true)},
                    { "sequence", variableUtil.GetValue<int?>(0,true)},
                    { "BOM_seq", variableUtil.GetValue<int?>(BOMseq,true)},
                    { "backflush", variableUtil.GetValue<int?>(backflush,true)},
                    { "revision", variableUtil.GetValue<string>(tRevision,true)},
                    { "description", variableUtil.GetValue<string>(tDesc,true)},
                    { "unit_cost", variableUtil.GetValue<decimal?>(tUnitCost,true)},
                    { "qty_unit_format", variableUtil.GetValue<string>(QtyUnitFormat,true)},
                    { "places_qty_unit", variableUtil.GetValue<int?>(PlacesQtyUnit,true)},
                    { "qty_per_format", variableUtil.GetValue<string>(QtyPerFormat,true)},
                    { "places_qty_per", variableUtil.GetValue<int?>(PlacesQtyPer,true)},
                    { "cst_prc_format", variableUtil.GetValue<string>(CstPrcFormat,true)},
                    { "places_cp", variableUtil.GetValue<int?>(PlacesCp,true)},
                    { "co_job", variableUtil.GetValue<int?>(CoJob,true)},
                    { "co_prod", variableUtil.GetValue<string>(null,true)},
                    { "co_prod_qty_released", variableUtil.GetValue<decimal?>(null,true)},
                    { "co_job_item", variableUtil.GetValue<string>(null,true)},
                    { "co_job_qty_received", variableUtil.GetValue<decimal?>(null,true)},
                    { "co_job_qty_complete", variableUtil.GetValue<decimal?>(null,true)},
                    { "co_job_qty_scrapped", variableUtil.GetValue<decimal?>(null,true)},
                    { "suffix", variableUtil.GetValue<int?>(currSuffix,true)},
                    { "job_id", variableUtil.GetValue<string>(job,true)},
                    { "oper_num_for_link", variableUtil.GetValue<int?>(stringUtil.IsNull(
                            opernum,
                        -1),true)},
                });

                var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                Data = nonTableLoadResponse;
                #endregion CRUD LoadResponseWithoutTable

                #region CRUD InsertByRecords
                var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tempOutput",
                    items: nonTableLoadResponse.Items);

                this.appDB.Insert(nonTableInsertRequest);
                #endregion InsertByRecords

                lev = (int?)(lev + 1);
                check = 0;
                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_loop ADD tempTableId INT IDENTITY");
                /*Needs to load at least one column from the table: #tv_loop for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                #region CRUD LoadToRecord
                var tv_loopLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"job","job"},
                    },
                    tableName: "#tv_loop",
                    loadForChange: true,
                    lockingType: LockingType.None,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_loopLoadResponse = this.appDB.Load(tv_loopLoadRequest);
                #endregion  LoadToRecord

                #region CRUD DeleteByRecord
                var tv_loopDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_loop",
                    items: tv_loopLoadResponse.Items);
                this.appDB.Delete(tv_loopDeleteRequest);
                #endregion DeleteByRecord

                this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_loop DROP COLUMN tempTableId");
                /*Needs to load at least one column from the table: #tv_loop2 for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                #region CRUD LoadToRecord
                var tv_loop2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"job","job"},
                    },
                    tableName: "#tv_loop2",
                    loadForChange: true,
                    lockingType: LockingType.None,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_loop2LoadResponse = this.appDB.Load(tv_loop2LoadRequest);
                #endregion  LoadToRecord


                #region CRUD DeleteByRecord
                var tv_loop2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_loop2",
                items: tv_loop2LoadResponse.Items);
                this.appDB.Delete(tv_loop2DeleteRequest);
                #endregion DeleteByRecord

                if (sQLUtil.SQLEqual(SortByItem, 1) == true)
                {
                    #region CRUD LoadToRecord
                    var jobmatlLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"job","jobmatl.job"},
                            {"suffix","jobmatl.suffix"},
                            {"oper_num","jobmatl.oper_num"},
                            {"sequence","jobmatl.sequence"},
                            {"ref_num","jobmatl.ref_num"},
                            {"ref_line_suf","jobmatl.ref_line_suf"},
                            {"item","jobmatl.item"},
                            {"itemLevel","CAST (NULL AS INT)"},
                            {"sort_string","CAST (NULL AS NVARCHAR)"},
                            {"matl_qty","jobmatl.matl_qty"},
                            {"matl_qty_conv","jobmatl.matl_qty_conv"},
                            {"ref_type","jobmatl.ref_type"},
                            {"bom_seq","jobmatl.bom_seq"},
                            {"backflush","jobmatl.backflush"},
                            {"u_m","jobmatl.u_m"},
                            {"units","jobmatl.units"},
                            {"scrap_fact","jobmatl.scrap_fact"},
                            {"matl_type","jobmatl.matl_type"},
                            {"description","CAST (NULL AS NVARCHAR)"},
                            {"cost_conv","jobmatl.cost_conv"},
                            {"revision","item.revision"},
                            {"planned_alternate","jobmatl.planned_alternate"},
                            {"u0","item.description"},
                            {"u1","jobmatl.description"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "jobmatl",
                        fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN item ON item.item = jobmatl.item"),
                        whereClause: collectionLoadRequestFactory.Clause("jobmatl.job = {1} AND jobmatl.suffix = {0}", currSuffix, job),
                        orderByClause: collectionLoadRequestFactory.Clause(" jobmatl.item"));
                    var jobmatlLoadResponse = this.appDB.Load(jobmatlLoadRequest);
                    #endregion  LoadToRecord


                    #region CRUD InsertByRecords
                    foreach (var jobmatlItem in jobmatlLoadResponse.Items)
                    {
                        jobmatlItem.SetValue<string>("job", jobmatlItem.GetValue<string>("job"));
                        jobmatlItem.SetValue<int?>("suffix", jobmatlItem.GetValue<int?>("suffix"));
                        jobmatlItem.SetValue<int?>("oper_num", jobmatlItem.GetValue<int?>("oper_num"));
                        jobmatlItem.SetValue<int?>("sequence", jobmatlItem.GetValue<int?>("sequence"));
                        jobmatlItem.SetValue<string>("ref_num", jobmatlItem.GetValue<string>("ref_num"));
                        jobmatlItem.SetValue<int?>("ref_line_suf", jobmatlItem.GetValue<int?>("ref_line_suf"));
                        jobmatlItem.SetValue<string>("item", jobmatlItem.GetValue<string>("item"));
                        jobmatlItem.SetValue<int?>("itemLevel", lev);
                        jobmatlItem.SetValue<string>("sort_string", SortString);
                        jobmatlItem.SetValue<decimal?>("matl_qty", jobmatlItem.GetValue<decimal?>("matl_qty"));
                        jobmatlItem.SetValue<decimal?>("matl_qty_conv", jobmatlItem.GetValue<decimal?>("matl_qty_conv"));
                        jobmatlItem.SetValue<string>("ref_type", jobmatlItem.GetValue<string>("ref_type"));
                        jobmatlItem.SetValue<int?>("bom_seq", jobmatlItem.GetValue<int?>("bom_seq"));
                        jobmatlItem.SetValue<int?>("backflush", jobmatlItem.GetValue<int?>("backflush"));
                        jobmatlItem.SetValue<string>("u_m", jobmatlItem.GetValue<string>("u_m"));
                        jobmatlItem.SetValue<string>("units", jobmatlItem.GetValue<string>("units"));
                        jobmatlItem.SetValue<decimal?>("scrap_fact", jobmatlItem.GetValue<decimal?>("scrap_fact"));
                        jobmatlItem.SetValue<string>("matl_type", jobmatlItem.GetValue<string>("matl_type"));
                        jobmatlItem.SetValue<string>("description", stringUtil.IsNull(
                            jobmatlItem.GetValue<string>("u0"),
                            jobmatlItem.GetValue<string>("u1")));
                        jobmatlItem.SetValue<decimal?>("cost_conv", jobmatlItem.GetValue<decimal?>("cost_conv"));
                        jobmatlItem.SetValue<string>("revision", jobmatlItem.GetValue<string>("revision"));
                        jobmatlItem.SetValue<int?>("planned_alternate", jobmatlItem.GetValue<int?>("planned_alternate"));
                    };

                    var jobmatlRequiredColumns = new List<string>() { "job", "suffix", "oper_num", "sequence", "ref_num", "ref_line_suf", "item", "itemLevel", "sort_string", "matl_qty", "matl_qty_conv", "ref_type", "bom_seq", "backflush", "u_m", "units", "scrap_fact", "matl_type", "description", "cost_conv", "revision", "planned_alternate" };

                    jobmatlLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(jobmatlLoadResponse, jobmatlRequiredColumns);

                    var jobmatlInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_loop2",
                    items: jobmatlLoadResponse.Items);

                    this.appDB.Insert(jobmatlInsertRequest);
                    #endregion InsertByRecords
                }
                else
                {
                    #region CRUD LoadToRecord
                    var jobmatl1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"job","jobmatl.job"},
                            {"suffix","jobmatl.suffix"},
                            {"oper_num","jobmatl.oper_num"},
                            {"sequence","jobmatl.sequence"},
                            {"ref_num","jobmatl.ref_num"},
                            {"ref_line_suf","jobmatl.ref_line_suf"},
                            {"item","jobmatl.item"},
                            {"itemLevel","CAST (NULL AS INT)"},
                            {"sort_string","CAST (NULL AS NVARCHAR)"},
                            {"matl_qty","jobmatl.matl_qty"},
                            {"matl_qty_conv","jobmatl.matl_qty_conv"},
                            {"ref_type","jobmatl.ref_type"},
                            {"bom_seq","jobmatl.bom_seq"},
                            {"backflush","jobmatl.backflush"},
                            {"u_m","jobmatl.u_m"},
                            {"units","jobmatl.units"},
                            {"scrap_fact","jobmatl.scrap_fact"},
                            {"matl_type","jobmatl.matl_type"},
                            {"description","CAST (NULL AS NVARCHAR)"},
                            {"cost_conv","jobmatl.cost_conv"},
                            {"revision","item.revision"},
                            {"planned_alternate","jobmatl.planned_alternate"},
                            {"u0","item.description"},
                            {"u1","jobmatl.description"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "jobmatl",
                        fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN item ON item.item = jobmatl.item"),
                        whereClause: collectionLoadRequestFactory.Clause("jobmatl.job = {1} AND jobmatl.suffix = {0}", currSuffix, job),
                        orderByClause: collectionLoadRequestFactory.Clause(" jobmatl.job, jobmatl.suffix, jobmatl.oper_num, jobmatl.sequence"));
                    var jobmatl1LoadResponse = this.appDB.Load(jobmatl1LoadRequest);
                    #endregion  LoadToRecord


                    #region CRUD InsertByRecords
                    foreach (var jobmatl1Item in jobmatl1LoadResponse.Items)
                    {
                        jobmatl1Item.SetValue<string>("job", jobmatl1Item.GetValue<string>("job"));
                        jobmatl1Item.SetValue<int?>("suffix", jobmatl1Item.GetValue<int?>("suffix"));
                        jobmatl1Item.SetValue<int?>("oper_num", jobmatl1Item.GetValue<int?>("oper_num"));
                        jobmatl1Item.SetValue<int?>("sequence", jobmatl1Item.GetValue<int?>("sequence"));
                        jobmatl1Item.SetValue<string>("ref_num", jobmatl1Item.GetValue<string>("ref_num"));
                        jobmatl1Item.SetValue<int?>("ref_line_suf", jobmatl1Item.GetValue<int?>("ref_line_suf"));
                        jobmatl1Item.SetValue<string>("item", jobmatl1Item.GetValue<string>("item"));
                        jobmatl1Item.SetValue<int?>("itemLevel", lev);
                        jobmatl1Item.SetValue<string>("sort_string", SortString);
                        jobmatl1Item.SetValue<decimal?>("matl_qty", jobmatl1Item.GetValue<decimal?>("matl_qty"));
                        jobmatl1Item.SetValue<decimal?>("matl_qty_conv", jobmatl1Item.GetValue<decimal?>("matl_qty_conv"));
                        jobmatl1Item.SetValue<string>("ref_type", jobmatl1Item.GetValue<string>("ref_type"));
                        jobmatl1Item.SetValue<int?>("bom_seq", jobmatl1Item.GetValue<int?>("bom_seq"));
                        jobmatl1Item.SetValue<int?>("backflush", jobmatl1Item.GetValue<int?>("backflush"));
                        jobmatl1Item.SetValue<string>("u_m", jobmatl1Item.GetValue<string>("u_m"));
                        jobmatl1Item.SetValue<string>("units", jobmatl1Item.GetValue<string>("units"));
                        jobmatl1Item.SetValue<decimal?>("scrap_fact", jobmatl1Item.GetValue<decimal?>("scrap_fact"));
                        jobmatl1Item.SetValue<string>("matl_type", jobmatl1Item.GetValue<string>("matl_type"));
                        jobmatl1Item.SetValue<string>("description", stringUtil.IsNull(
                            jobmatl1Item.GetValue<string>("u0"),
                            jobmatl1Item.GetValue<string>("u1")));
                        jobmatl1Item.SetValue<decimal?>("cost_conv", jobmatl1Item.GetValue<decimal?>("cost_conv"));
                        jobmatl1Item.SetValue<string>("revision", jobmatl1Item.GetValue<string>("revision"));
                        jobmatl1Item.SetValue<int?>("planned_alternate", jobmatl1Item.GetValue<int?>("planned_alternate"));
                    };

                    var jobmatl1RequiredColumns = new List<string>() { "job", "suffix", "oper_num", "sequence", "ref_num", "ref_line_suf", "item", "itemLevel", "sort_string", "matl_qty", "matl_qty_conv", "ref_type", "bom_seq", "backflush", "u_m", "units", "scrap_fact", "matl_type", "description", "cost_conv", "revision", "planned_alternate" };

                    jobmatl1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(jobmatl1LoadResponse, jobmatl1RequiredColumns);

                    var jobmatl1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_loop2",
                    items: jobmatl1LoadResponse.Items);

                    this.appDB.Insert(jobmatl1InsertRequest);
                    #endregion InsertByRecords
                }

                #region CRUD LoadToRecord
                var tv_loop21LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"sort_string","#tv_loop2.sort_string"},
                        {"u0","sort_seq"},
                    },
                    tableName: "#tv_loop2",
                    loadForChange: true,
                    lockingType: LockingType.UPDLock,
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var tv_loop21LoadResponse = this.appDB.Load(tv_loop21LoadRequest);
                #endregion  LoadToRecord

                #region CRUD UpdateByRecord
                foreach (var tv_loop21Item in tv_loop21LoadResponse.Items)
                {
                    tv_loop21Item.SetValue<string>("sort_string", stringUtil.Concat(stringUtil.Str(
                        tv_loop21Item.GetValue<int?>("u0"),
                        6), "."));
                };

                var tv_loop21RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_loop2",
                items: tv_loop21LoadResponse.Items);

                this.appDB.Update(tv_loop21RequestUpdate);
                #endregion UpdateByRecord


                #region CRUD LoadToRecord
                var loopLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"job","job"},
                        {"suffix","suffix"},
                        {"oper_num","oper_num"},
                        {"sequence","sequence"},
                        {"ref_num","ref_num"},
                        {"ref_line_suf","ref_line_suf"},
                        {"item","item"},
                        {"itemLevel","itemLevel"},
                        {"sort_string","sort_string"},
                        {"matl_qty","matl_qty"},
                        {"matl_qty_conv","matl_qty_conv"},
                        {"ref_type","ref_type"},
                        {"bom_seq","bom_seq"},
                        {"backflush","backflush"},
                        {"u_m","u_m"},
                        {"units","units"},
                        {"scrap_fact","scrap_fact"},
                        {"matl_type","matl_type"},
                        {"description","description"},
                        {"cost_conv","cost_conv"},
                        {"revision","revision"},
                        {"planned_alternate","planned_alternate"},
                    },
                    loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "#tv_loop2",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var loopLoadResponse = this.appDB.Load(loopLoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                var loopInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_loop",
                    items: loopLoadResponse.Items);

                this.appDB.Insert(loopInsertRequest);
                #endregion InsertByRecords

                while (sQLUtil.SQLEqual(check, 0) == true)
                {
                    check = 1;
                    /*Needs to load at least one column from the table: #tv_loop2 for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    #region CRUD LoadToRecord
                    var tv_loop22LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"ref_num","ref_num"},
                        },
                        tableName: "#tv_loop2",
                        loadForChange: true,
                        lockingType: LockingType.None,
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("ref_num IS NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var tv_loop22LoadResponse = this.appDB.Load(tv_loop22LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD DeleteByRecord
                    var tv_loop22DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_loop2",
                        items: tv_loop22LoadResponse.Items);
                    this.appDB.Delete(tv_loop22DeleteRequest);
                    #endregion DeleteByRecord

                    #region Cursor Statement

                    #region CRUD LoadToRecord
                    loopCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"ref_type","ref_type"},
                            {"ref_num","ref_num"},
                            {"ref_line_suf","ref_line_suf"},
                            {"itemLevel","itemLevel"},
                            {"sort_string","sort_string"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "#tv_loop2",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    #endregion  LoadToRecord

                    #endregion Cursor Statement
                    loopCursorLoadResponseForCursor = this.appDB.Load(loopCursorLoadRequestForCursor);
                    loopCursor_CursorFetch_Status = loopCursorLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                    loopCursor_CursorCounter = -1;

                    /*Needs to load at least one column from the table: #tv_loop2 for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    #region CRUD LoadToRecord
                    var tv_loop24LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"job","job"},
                        },
                        tableName: "#tv_loop2",
                        loadForChange: true,
                        lockingType: LockingType.None,
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var tv_loop24LoadResponse = this.appDB.Load(tv_loop24LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD DeleteByRecord
                    var tv_loop24DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_loop2",
                        items: tv_loop24LoadResponse.Items);
                    this.appDB.Delete(tv_loop24DeleteRequest);
                    #endregion DeleteByRecord

                    if (sQLUtil.SQLEqual(DisplayLevel, "A") == true)
                    {
                        while (sQLUtil.SQLEqual(1, 1) == true)
                        {
                            loopCursor_CursorCounter++;
                            if (loopCursorLoadResponseForCursor.Items.Count > loopCursor_CursorCounter)
                            {
                                reftype = loopCursorLoadResponseForCursor.Items[loopCursor_CursorCounter].GetValue<string>(0);
                                refnum = loopCursorLoadResponseForCursor.Items[loopCursor_CursorCounter].GetValue<string>(1);
                                reflinesuf = loopCursorLoadResponseForCursor.Items[loopCursor_CursorCounter].GetValue<int?>(2);
                                itemLevel2 = loopCursorLoadResponseForCursor.Items[loopCursor_CursorCounter].GetValue<int?>(3);
                                SortString = loopCursorLoadResponseForCursor.Items[loopCursor_CursorCounter].GetValue<string>(4);
                            }
                            loopCursor_CursorFetch_Status = (loopCursor_CursorCounter == loopCursorLoadResponseForCursor.Items.Count ? -1 : 0);

                            if (sQLUtil.SQLNotEqual(loopCursor_CursorFetch_Status, 0) == true)
                            {
                                break;
                            }
                            check = 0;
                            if (sQLUtil.SQLEqual(SortByItem, 1) == true)
                            {

                                #region CRUD LoadToRecord
                                var jobmatl2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                    {
                                        {"job","jobmatl.job"},
                                        {"suffix","jobmatl.suffix"},
                                        {"oper_num","jobmatl.oper_num"},
                                        {"sequence","jobmatl.sequence"},
                                        {"ref_num","jobmatl.ref_num"},
                                        {"ref_line_suf","jobmatl.ref_line_suf"},
                                        {"item","jobmatl.item"},
                                        {"itemLevel","CAST (NULL AS INT)"},
                                        {"sort_string","CAST (NULL AS NVARCHAR)"},
                                        {"matl_qty","jobmatl.matl_qty"},
                                        {"matl_qty_conv","jobmatl.matl_qty_conv"},
                                        {"ref_type","jobmatl.ref_type"},
                                        {"bom_seq","jobmatl.bom_seq"},
                                        {"backflush","jobmatl.backflush"},
                                        {"u_m","jobmatl.u_m"},
                                        {"units","jobmatl.units"},
                                        {"scrap_fact","jobmatl.scrap_fact"},
                                        {"matl_type","jobmatl.matl_type"},
                                        {"description","CAST (NULL AS NVARCHAR)"},
                                        {"cost_conv","jobmatl.cost_conv"},
                                        {"revision","item.revision"},
                                        {"planned_alternate","jobmatl.planned_alternate"},
                                        {"u0","item.description"},
                                        {"u1","jobmatl.description"},
                                    },
                                    loadForChange: false,
                                    lockingType: LockingType.None,
                                    tableName: "jobmatl",
                                    fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN item ON item.item = jobmatl.item"),
                                    whereClause: collectionLoadRequestFactory.Clause("jobmatl.job = {2} AND jobmatl.suffix = {0} AND {1} = 'J'", reflinesuf, reftype, refnum),
                                    orderByClause: collectionLoadRequestFactory.Clause(" jobmatl.item"));
                                var jobmatl2LoadResponse = this.appDB.Load(jobmatl2LoadRequest);
                                #endregion  LoadToRecord


                                #region CRUD InsertByRecords
                                foreach (var jobmatl2Item in jobmatl2LoadResponse.Items)
                                {
                                    jobmatl2Item.SetValue<string>("job", jobmatl2Item.GetValue<string>("job"));
                                    jobmatl2Item.SetValue<int?>("suffix", jobmatl2Item.GetValue<int?>("suffix"));
                                    jobmatl2Item.SetValue<int?>("oper_num", jobmatl2Item.GetValue<int?>("oper_num"));
                                    jobmatl2Item.SetValue<int?>("sequence", jobmatl2Item.GetValue<int?>("sequence"));
                                    jobmatl2Item.SetValue<string>("ref_num", jobmatl2Item.GetValue<string>("ref_num"));
                                    jobmatl2Item.SetValue<int?>("ref_line_suf", jobmatl2Item.GetValue<int?>("ref_line_suf"));
                                    jobmatl2Item.SetValue<string>("item", jobmatl2Item.GetValue<string>("item"));
                                    jobmatl2Item.SetValue<int?>("itemLevel", itemLevel2 + 1);
                                    jobmatl2Item.SetValue<string>("sort_string", SortString);
                                    jobmatl2Item.SetValue<decimal?>("matl_qty", jobmatl2Item.GetValue<decimal?>("matl_qty"));
                                    jobmatl2Item.SetValue<decimal?>("matl_qty_conv", jobmatl2Item.GetValue<decimal?>("matl_qty_conv"));
                                    jobmatl2Item.SetValue<string>("ref_type", jobmatl2Item.GetValue<string>("ref_type"));
                                    jobmatl2Item.SetValue<int?>("bom_seq", jobmatl2Item.GetValue<int?>("bom_seq"));
                                    jobmatl2Item.SetValue<int?>("backflush", jobmatl2Item.GetValue<int?>("backflush"));
                                    jobmatl2Item.SetValue<string>("u_m", jobmatl2Item.GetValue<string>("u_m"));
                                    jobmatl2Item.SetValue<string>("units", jobmatl2Item.GetValue<string>("units"));
                                    jobmatl2Item.SetValue<decimal?>("scrap_fact", jobmatl2Item.GetValue<decimal?>("scrap_fact"));
                                    jobmatl2Item.SetValue<string>("matl_type", jobmatl2Item.GetValue<string>("matl_type"));
                                    jobmatl2Item.SetValue<string>("description", stringUtil.IsNull(
                                        jobmatl2Item.GetValue<string>("u0"),
                                        jobmatl2Item.GetValue<string>("u1")));
                                    jobmatl2Item.SetValue<decimal?>("cost_conv", jobmatl2Item.GetValue<decimal?>("cost_conv"));
                                    jobmatl2Item.SetValue<string>("revision", jobmatl2Item.GetValue<string>("revision"));
                                    jobmatl2Item.SetValue<int?>("planned_alternate", jobmatl2Item.GetValue<int?>("planned_alternate"));
                                };

                                var jobmatl2RequiredColumns = new List<string>() { "job", "suffix", "oper_num", "sequence", "ref_num", "ref_line_suf", "item", "itemLevel", "sort_string", "matl_qty", "matl_qty_conv", "ref_type", "bom_seq", "backflush", "u_m", "units", "scrap_fact", "matl_type", "description", "cost_conv", "revision", "planned_alternate" };

                                jobmatl2LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(jobmatl2LoadResponse, jobmatl2RequiredColumns);

                                var jobmatl2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_loop2",
                                items: jobmatl2LoadResponse.Items);

                                this.appDB.Insert(jobmatl2InsertRequest);
                                #endregion InsertByRecords
                            }
                            else
                            {
                                #region CRUD LoadToRecord
                                var jobmatl3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                    {
                                        {"job","jobmatl.job"},
                                        {"suffix","jobmatl.suffix"},
                                        {"oper_num","jobmatl.oper_num"},
                                        {"sequence","jobmatl.sequence"},
                                        {"ref_num","jobmatl.ref_num"},
                                        {"ref_line_suf","jobmatl.ref_line_suf"},
                                        {"item","jobmatl.item"},
                                        {"itemLevel","CAST (NULL AS INT)"},
                                        {"sort_string","CAST (NULL AS NVARCHAR)"},
                                        {"matl_qty","jobmatl.matl_qty"},
                                        {"matl_qty_conv","jobmatl.matl_qty_conv"},
                                        {"ref_type","jobmatl.ref_type"},
                                        {"bom_seq","jobmatl.bom_seq"},
                                        {"backflush","jobmatl.backflush"},
                                        {"u_m","jobmatl.u_m"},
                                        {"units","jobmatl.units"},
                                        {"scrap_fact","jobmatl.scrap_fact"},
                                        {"matl_type","jobmatl.matl_type"},
                                        {"description","CAST (NULL AS NVARCHAR)"},
                                        {"cost_conv","jobmatl.cost_conv"},
                                        {"revision","item.revision"},
                                        {"planned_alternate","jobmatl.planned_alternate"},
                                        {"u0","item.description"},
                                        {"u1","jobmatl.description"},
                                    },
                                    loadForChange: false,
                                    lockingType: LockingType.None,
                                    tableName: "jobmatl",
                                    fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN item ON item.item = jobmatl.item"),
                                    whereClause: collectionLoadRequestFactory.Clause("jobmatl.job = {2} AND jobmatl.suffix = {0} AND {1} = 'J'", reflinesuf, reftype, refnum),
                                    orderByClause: collectionLoadRequestFactory.Clause(" jobmatl.job, jobmatl.suffix, jobmatl.oper_num, jobmatl.sequence"));
                                var jobmatl3LoadResponse = this.appDB.Load(jobmatl3LoadRequest);
                                #endregion  LoadToRecord


                                #region CRUD InsertByRecords
                                foreach (var jobmatl3Item in jobmatl3LoadResponse.Items)
                                {
                                    jobmatl3Item.SetValue<string>("job", jobmatl3Item.GetValue<string>("job"));
                                    jobmatl3Item.SetValue<int?>("suffix", jobmatl3Item.GetValue<int?>("suffix"));
                                    jobmatl3Item.SetValue<int?>("oper_num", jobmatl3Item.GetValue<int?>("oper_num"));
                                    jobmatl3Item.SetValue<int?>("sequence", jobmatl3Item.GetValue<int?>("sequence"));
                                    jobmatl3Item.SetValue<string>("ref_num", jobmatl3Item.GetValue<string>("ref_num"));
                                    jobmatl3Item.SetValue<int?>("ref_line_suf", jobmatl3Item.GetValue<int?>("ref_line_suf"));
                                    jobmatl3Item.SetValue<string>("item", jobmatl3Item.GetValue<string>("item"));
                                    jobmatl3Item.SetValue<int?>("itemLevel", itemLevel2 + 1);
                                    jobmatl3Item.SetValue<string>("sort_string", SortString);
                                    jobmatl3Item.SetValue<decimal?>("matl_qty", jobmatl3Item.GetValue<decimal?>("matl_qty"));
                                    jobmatl3Item.SetValue<decimal?>("matl_qty_conv", jobmatl3Item.GetValue<decimal?>("matl_qty_conv"));
                                    jobmatl3Item.SetValue<string>("ref_type", jobmatl3Item.GetValue<string>("ref_type"));
                                    jobmatl3Item.SetValue<int?>("bom_seq", jobmatl3Item.GetValue<int?>("bom_seq"));
                                    jobmatl3Item.SetValue<int?>("backflush", jobmatl3Item.GetValue<int?>("backflush"));
                                    jobmatl3Item.SetValue<string>("u_m", jobmatl3Item.GetValue<string>("u_m"));
                                    jobmatl3Item.SetValue<string>("units", jobmatl3Item.GetValue<string>("units"));
                                    jobmatl3Item.SetValue<decimal?>("scrap_fact", jobmatl3Item.GetValue<decimal?>("scrap_fact"));
                                    jobmatl3Item.SetValue<string>("matl_type", jobmatl3Item.GetValue<string>("matl_type"));
                                    jobmatl3Item.SetValue<string>("description", stringUtil.IsNull(
                                        jobmatl3Item.GetValue<string>("u0"),
                                        jobmatl3Item.GetValue<string>("u1")));
                                    jobmatl3Item.SetValue<decimal?>("cost_conv", jobmatl3Item.GetValue<decimal?>("cost_conv"));
                                    jobmatl3Item.SetValue<string>("revision", jobmatl3Item.GetValue<string>("revision"));
                                    jobmatl3Item.SetValue<int?>("planned_alternate", jobmatl3Item.GetValue<int?>("planned_alternate"));
                                };

                                var jobmatl3RequiredColumns = new List<string>() { "job", "suffix", "oper_num", "sequence", "ref_num", "ref_line_suf", "item", "itemLevel", "sort_string", "matl_qty", "matl_qty_conv", "ref_type", "bom_seq", "backflush", "u_m", "units", "scrap_fact", "matl_type", "description", "cost_conv", "revision", "planned_alternate" };

                                jobmatl3LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(jobmatl3LoadResponse, jobmatl3RequiredColumns);

                                var jobmatl3InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_loop2",
                                items: jobmatl3LoadResponse.Items);

                                this.appDB.Insert(jobmatl3InsertRequest);
                                #endregion InsertByRecords
                            }
                        }
                    }
                    //Deallocate Cursor loopCursor
                    lev = (int?)(lev + 1);

                    #region CRUD LoadToRecord
                    var tv_loop25LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"sort_string","#tv_loop2.sort_string"},
                            {"u0","sort_seq"},
                        },
                        tableName: "#tv_loop2",
                        loadForChange: true,
                        lockingType: LockingType.UPDLock,
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var tv_loop25LoadResponse = this.appDB.Load(tv_loop25LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD UpdateByRecord
                    foreach (var tv_loop25Item in tv_loop25LoadResponse.Items)
                    {
                        tv_loop25Item.SetValue<string>("sort_string", stringUtil.Concat(tv_loop25Item.GetDeletedValue<string>("sort_string"), stringUtil.Str(
                            tv_loop25Item.GetValue<int?>("u0"),
                            6), "."));
                    };

                    var tv_loop25RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_loop2",
                    items: tv_loop25LoadResponse.Items);

                    this.appDB.Update(tv_loop25RequestUpdate);
                    #endregion UpdateByRecord

                    #region CRUD LoadToRecord
                    var loop1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"job","job"},
                            {"suffix","suffix"},
                            {"oper_num","oper_num"},
                            {"sequence","sequence"},
                            {"ref_num","ref_num"},
                            {"ref_line_suf","ref_line_suf"},
                            {"item","item"},
                            {"itemLevel","itemLevel"},
                            {"sort_string","sort_string"},
                            {"matl_qty","matl_qty"},
                            {"matl_qty_conv","matl_qty_conv"},
                            {"ref_type","ref_type"},
                            {"bom_seq","bom_seq"},
                            {"backflush","backflush"},
                            {"u_m","u_m"},
                            {"units","units"},
                            {"scrap_fact","scrap_fact"},
                            {"matl_type","matl_type"},
                            {"description","description"},
                            {"cost_conv","cost_conv"},
                            {"revision","revision"},
                            {"planned_alternate","planned_alternate"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "#tv_loop2",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var loop1LoadResponse = this.appDB.Load(loop1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    var loop1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_loop",
                    items: loop1LoadResponse.Items);

                    this.appDB.Insert(loop1InsertRequest);
                    #endregion InsertByRecords
                }
                #region Cursor Statement

                #region CRUD LoadToRecord
                jobmatlCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"job","jm.job"},
                        {"suffix","jm.suffix"},
                        {"oper_num","jm.oper_num"},
                        {"sequence","jm.sequence"},
                        {"ref_num","jm.ref_num"},
                        {"ref_line_suf","jm.ref_line_suf"},
                        {"item","jm.item"},
                        {"itemLevel","jm.itemLevel"},
                        {"matl_qty","jm.matl_qty"},
                        {"matl_qty_conv","jm.matl_qty_conv"},
                        {"ref_type","jm.ref_type"},
                        {"bom_seq","jm.bom_seq"},
                        {"backflush","jm.backflush"},
                        {"u_m","jm.u_m"},
                        {"units","jm.units"},
                        {"scrap_fact","jm.scrap_fact"},
                        {"matl_type","jm.matl_type"},
                        {"description","jm.description"},
                        {"cost_conv","jm.cost_conv"},
                        {"col0","CAST (NULL AS NVARCHAR)"},
                        {"qty_released","job.qty_released"},
                        {"planned_alternate","jm.planned_alternate"},
                        {"u0","job2.revision"},
                        {"u1","jm.revision"},
                    },
                    loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "#tv_loop",
                    fromClause: collectionLoadRequestFactory.Clause(@" AS jm LEFT OUTER JOIN job ON job.job = jm.job 
						AND job.suffix = jm.suffix LEFT OUTER JOIN job AS job2 ON job2.job = jm.ref_num 
						AND job2.suffix = jm.ref_line_suf"),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(" sort_string"));
                #endregion  LoadToRecord

                #endregion Cursor Statement
                jobmatlCursorLoadResponseForCursor = this.appDB.Load(jobmatlCursorLoadRequestForCursor);
                foreach (var tv_loopASjmItem in jobmatlCursorLoadResponseForCursor.Items)
                {
                    tv_loopASjmItem.SetValue<string>("job", tv_loopASjmItem.GetValue<string>("job"));
                    tv_loopASjmItem.SetValue<int?>("suffix", tv_loopASjmItem.GetValue<int?>("suffix"));
                    tv_loopASjmItem.SetValue<int?>("oper_num", tv_loopASjmItem.GetValue<int?>("oper_num"));
                    tv_loopASjmItem.SetValue<int?>("sequence", tv_loopASjmItem.GetValue<int?>("sequence"));
                    tv_loopASjmItem.SetValue<string>("ref_num", tv_loopASjmItem.GetValue<string>("ref_num"));
                    tv_loopASjmItem.SetValue<int?>("ref_line_suf", tv_loopASjmItem.GetValue<int?>("ref_line_suf"));
                    tv_loopASjmItem.SetValue<string>("item", tv_loopASjmItem.GetValue<string>("item"));
                    tv_loopASjmItem.SetValue<int?>("itemLevel", tv_loopASjmItem.GetValue<int?>("itemLevel"));
                    tv_loopASjmItem.SetValue<decimal?>("matl_qty", tv_loopASjmItem.GetValue<decimal?>("matl_qty"));
                    tv_loopASjmItem.SetValue<decimal?>("matl_qty_conv", tv_loopASjmItem.GetValue<decimal?>("matl_qty_conv"));
                    tv_loopASjmItem.SetValue<string>("ref_type", tv_loopASjmItem.GetValue<string>("ref_type"));
                    tv_loopASjmItem.SetValue<int?>("bom_seq", tv_loopASjmItem.GetValue<int?>("bom_seq"));
                    tv_loopASjmItem.SetValue<int?>("backflush", tv_loopASjmItem.GetValue<int?>("backflush"));
                    tv_loopASjmItem.SetValue<string>("u_m", tv_loopASjmItem.GetValue<string>("u_m"));
                    tv_loopASjmItem.SetValue<string>("units", tv_loopASjmItem.GetValue<string>("units"));
                    tv_loopASjmItem.SetValue<decimal?>("scrap_fact", tv_loopASjmItem.GetValue<decimal?>("scrap_fact"));
                    tv_loopASjmItem.SetValue<string>("matl_type", tv_loopASjmItem.GetValue<string>("matl_type"));
                    tv_loopASjmItem.SetValue<string>("description", tv_loopASjmItem.GetValue<string>("description"));
                    tv_loopASjmItem.SetValue<decimal?>("cost_conv", tv_loopASjmItem.GetValue<decimal?>("cost_conv"));
                    tv_loopASjmItem.SetValue<string>("col0", (tv_loopASjmItem.GetValue<string>("ref_num") != null ? convertToUtil.ToString(tv_loopASjmItem.GetValue<string>("u0")) : convertToUtil.ToString(tv_loopASjmItem.GetValue<string>("u1"))));
                    tv_loopASjmItem.SetValue<decimal?>("qty_released", tv_loopASjmItem.GetValue<decimal?>("qty_released"));
                    tv_loopASjmItem.SetValue<int?>("planned_alternate", tv_loopASjmItem.GetValue<int?>("planned_alternate"));
                };

                jobmatlCursor_CursorFetch_Status = jobmatlCursorLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                jobmatlCursor_CursorCounter = -1;

                while (sQLUtil.SQLEqual(1, 1) == true)
                {
                    jobmatlCursor_CursorCounter++;
                    if (jobmatlCursorLoadResponseForCursor.Items.Count > jobmatlCursor_CursorCounter)
                    {
                        job2 = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(0);
                        suffix2 = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<int?>(1);
                        opernum = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<int?>(2);
                        sequence = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<int?>(3);
                        refnum = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(4);
                        reflinesuf = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<int?>(5);
                        item = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(6);
                        lev = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<int?>(7);
                        tcqtpqty = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<decimal?>(8);
                        tcqtpqtyconv = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<decimal?>(9);
                        tRef = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(10);
                        BOMseq = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<int?>(11);
                        backflush = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<int?>(12);
                        JobmatlUM = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(13);
                        units = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(14);
                        scrapfact = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<decimal?>(15);
                        matltype = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(16);
                        tDesc = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(17);
                        tUnitCost = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<decimal?>(18);
                        tRevision = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<string>(19);
                        tcqtureleased = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<decimal?>(20);
                        Alternate = jobmatlCursorLoadResponseForCursor.Items[jobmatlCursor_CursorCounter].GetValue<int?>(21);
                    }
                    jobmatlCursor_CursorFetch_Status = (jobmatlCursor_CursorCounter == jobmatlCursorLoadResponseForCursor.Items.Count ? -1 : 0);

                    if (sQLUtil.SQLNotEqual(jobmatlCursor_CursorFetch_Status, 0) == true)
                    {
                        break;
                    }
                    if (sQLUtil.SQLEqual(DisplayLevel, "A") == true)
                    {
                        indenture = stringUtil.Concat(stringUtil.Char(1), "    ", stringUtil.Space(lev), Convert.ToString(lev));
                    }
                    else
                    {
                        indenture = stringUtil.Concat(stringUtil.Char(1), "   ", Convert.ToString(lev));
                    }
                    if (refnum != null && (sQLUtil.SQLNotEqual(refnum, job2) == true || sQLUtil.SQLNotEqual(reflinesuf, suffix2) == true))
                    {
                        tJob = refnum;
                        suffix2 = reflinesuf;
                    }
                    else
                    {
                        tJob = job2;
                        refnum = "";
                    }
                    tUnit = (sQLUtil.SQLEqual(units, "L") == true ? UnitsLot :
                    sQLUtil.SQLEqual(units, "U") == true ? UnitsUnit : "");
                    t_matltype = (sQLUtil.SQLEqual(matltype, "M") == true ? MatlTypeMaterial :
                    sQLUtil.SQLEqual(matltype, "T") == true ? MatlTypeTool :
                    sQLUtil.SQLEqual(matltype, "F") == true ? MatlTypeFixture :
                    sQLUtil.SQLEqual(matltype, "O") == true ? MatlTypeOther : "");
                    check2 = 0;
                    if (refnum != null)
                    {
                        if (tcqtureleased == null)
                        {
                            check2 = 1;

                        }
                    }
                    if (sQLUtil.SQLEqual(check2, 0) == true)
                    {
                        if (tcqtureleased == null)
                        {

                            #region CRUD LoadToVariable
                            var job4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                {
                                    {_tcqtureleased,"qty_released"},
                                    {_saveqty,"qty_released"},
                                    {_tRevision,$"ISNULL({variableUtil.GetValue<string>(tRevision)}, revision)"},
                                },
                                loadForChange: false,
                                lockingType: LockingType.None,
                                tableName: "job",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("job = {1} AND suffix = {0}", suffix2, job2),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var job4LoadResponse = this.appDB.Load(job4LoadRequest);
                            if (job4LoadResponse.Items.Count > 0)
                            {
                                tcqtureleased = _tcqtureleased;
                                saveqty = _saveqty;
                                tRevision = _tRevision;
                            }
                            #endregion  LoadToVariable
                        }

                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: GetumcfSp
                        var Getumcf1 = this.iGetumcf.GetumcfSp(
                            OtherUM: JobmatlUM,
                            Item: item,
                            VendNum: null,
                            Area: null,
                            ConvFactor: uomconvfactor,
                            Infobar: stdmsg,
                            Site: ParmsSite);
                        uomconvfactor = Getumcf1.ConvFactor;
                        stdmsg = Getumcf1.Infobar;

                        #endregion ExecuteMethodCall

                        tcqtureleased = (decimal?)((sQLUtil.SQLEqual(units, "U") == true ? tcqtureleased * tcqtpqty / (1M - scrapfact) : tcqtpqty / (1M - scrapfact)));
                        tcqtureleased = convertToUtil.ToDecimal(this.iUomConvQty.UomConvQtyFn(
                            tcqtureleased,
                            uomconvfactor,
                            cuomconvfrombase));
                    }
                    refdes = null;
                    bubble = null;
                    assyseq = null;
                    if (sQLUtil.SQLEqual(PrintCost, 0) == true)
                    {
                        tUnitCost = 0;
                    }
                    if (sQLUtil.SQLEqual(RefFields, 0) == true)
                    {
                        sequence = -1;
                    }

                    #region CRUD LoadResponseWithoutTable
                    var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                    {
                        { "lev", variableUtil.GetValue<string>(indenture,true)},
                        { "item", variableUtil.GetValue<string>(item,true)},
                        { "job", variableUtil.GetValue<string>(tJob,true)},
                        { "jobtype", variableUtil.GetValue<string>(t_matltype,true)},
                        { "qty_rel", variableUtil.GetValue<decimal?>(tcqtureleased,true)},
                        { "qty_per", variableUtil.GetValue<decimal?>(tcqtpqtyconv,true)},
                        { "u_m", variableUtil.GetValue<string>(JobmatlUM,true)},
                        { "type", variableUtil.GetValue<string>(tUnit,true)},
                        { "ref", variableUtil.GetValue<string>(tRef,true)},
                        { "oper", variableUtil.GetValue<int?>(opernum,true)},
                            { "sequence", variableUtil.GetValue<int?>(stringUtil.IsNull(
                                sequence,
                            0),true)},
                        { "BOM_seq", variableUtil.GetValue<int?>(BOMseq,true)},
                        { "backflush", variableUtil.GetValue<int?>(backflush,true)},
                        { "revision", variableUtil.GetValue<string>(tRevision,true)},
                        { "description", variableUtil.GetValue<string>(tDesc,true)},
                        { "unit_cost", variableUtil.GetValue<decimal?>(tUnitCost,true)},
                            { "alternate", variableUtil.GetValue<int?>(stringUtil.IsNull(
                                Alternate,
                            0),true)},
                        { "qty_unit_format", variableUtil.GetValue<string>(QtyUnitFormat,true)},
                        { "places_qty_unit", variableUtil.GetValue<int?>(PlacesQtyUnit,true)},
                        { "qty_per_format", variableUtil.GetValue<string>(QtyPerFormat,true)},
                        { "places_qty_per", variableUtil.GetValue<int?>(PlacesQtyPer,true)},
                        { "cst_prc_format", variableUtil.GetValue<string>(CstPrcFormat,true)},
                        { "places_cp", variableUtil.GetValue<int?>(PlacesCp,true)},
                        { "co_job", variableUtil.GetValue<int?>(CoJob,true)},
                        { "co_prod", variableUtil.GetValue<string>(null,true)},
                        { "co_prod_qty_released", variableUtil.GetValue<decimal?>(null,true)},
                        { "co_job_item", variableUtil.GetValue<string>(null,true)},
                        { "co_job_qty_received", variableUtil.GetValue<decimal?>(null,true)},
                        { "co_job_qty_complete", variableUtil.GetValue<decimal?>(null,true)},
                        { "co_job_qty_scrapped", variableUtil.GetValue<decimal?>(null,true)},
                        { "suffix", variableUtil.GetValue<int?>(suffix2,true)},
                        { "job_id", variableUtil.GetValue<string>(refnum,true)},
                            { "oper_num_for_link", variableUtil.GetValue<int?>(stringUtil.IsNull(
                                opernum,
                            -1),true)},
                    });

                    var nonTable1LoadResponse = this.appDB.Load(nonTable1LoadRequest);
                    Data = nonTable1LoadResponse;
                    #endregion CRUD LoadResponseWithoutTable

                    #region CRUD InsertByRecords
                    var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tempOutput",
                    items: nonTable1LoadResponse.Items);

                    this.appDB.Insert(nonTable1InsertRequest);
                    #endregion InsertByRecords

                    if (sQLUtil.SQLEqual(nonTable1LoadResponse.Items.Count, 0) == true)
                    {

                        #region CRUD LoadResponseWithoutTable
                        var nonTable2LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                        {
                            { "lev", variableUtil.GetValue<string>(indenture,true)},
                            { "item", variableUtil.GetValue<string>(item,true)},
                            { "job", variableUtil.GetValue<string>(tJob,true)},
                            { "jobtype", variableUtil.GetValue<string>(t_matltype,true)},
                            { "qty_rel", variableUtil.GetValue<decimal?>(tcqtureleased,true)},
                            { "qty_per", variableUtil.GetValue<decimal?>(tcqtpqtyconv,true)},
                            { "u_m", variableUtil.GetValue<string>(JobmatlUM,true)},
                            { "type", variableUtil.GetValue<string>(tUnit,true)},
                            { "ref", variableUtil.GetValue<string>(tRef,true)},
                            { "oper", variableUtil.GetValue<int?>(opernum,true)},
                                { "sequence", variableUtil.GetValue<int?>(stringUtil.IsNull(
                                    sequence,
                                0),true)},
                            { "BOM_seq", variableUtil.GetValue<int?>(BOMseq,true)},
                            { "backflush", variableUtil.GetValue<int?>(backflush,true)},
                            { "revision", variableUtil.GetValue<string>(tRevision,true)},
                            { "description", variableUtil.GetValue<string>(tDesc,true)},
                            { "unit_cost", variableUtil.GetValue<decimal?>(tUnitCost,true)},
                            { "ref_des", variableUtil.GetValue<string>(refdes,true)},
                            { "bubble", variableUtil.GetValue<string>(bubble,true)},
                            { "assy_seq", variableUtil.GetValue<string>(assyseq,true)},
                                { "alternate", variableUtil.GetValue<int?>(stringUtil.IsNull(
                                    Alternate,
                                0),true)},
                            { "qty_unit_format", variableUtil.GetValue<string>(QtyUnitFormat,true)},
                            { "places_qty_unit", variableUtil.GetValue<int?>(PlacesQtyUnit,true)},
                            { "qty_per_format", variableUtil.GetValue<string>(QtyPerFormat,true)},
                            { "places_qty_per", variableUtil.GetValue<int?>(PlacesQtyPer,true)},
                            { "cst_prc_format", variableUtil.GetValue<string>(CstPrcFormat,true)},
                            { "places_cp", variableUtil.GetValue<int?>(PlacesCp,true)},
                            { "co_job", variableUtil.GetValue<int?>(CoJob,true)},
                            { "co_prod", variableUtil.GetValue<string>(null,true)},
                            { "co_prod_qty_released", variableUtil.GetValue<decimal?>(null,true)},
                            { "co_job_item", variableUtil.GetValue<string>(null,true)},
                            { "co_job_qty_received", variableUtil.GetValue<decimal?>(null,true)},
                            { "co_job_qty_complete", variableUtil.GetValue<decimal?>(null,true)},
                            { "co_job_qty_scrapped", variableUtil.GetValue<decimal?>(null,true)},
                            { "suffix", variableUtil.GetValue<int?>(suffix2,true)},
                            { "job_id", variableUtil.GetValue<string>(refnum,true)},
                                { "oper_num_for_link", variableUtil.GetValue<int?>(stringUtil.IsNull(
                                    opernum,
                                -1),true)},
                        });

                        var nonTable2LoadResponse = this.appDB.Load(nonTable2LoadRequest);
                        Data = nonTable2LoadResponse;
                        #endregion CRUD LoadResponseWithoutTable

                        #region CRUD InsertByRecords
                        var nonTable2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tempOutput",
                        items: nonTable2LoadResponse.Items);

                        this.appDB.Insert(nonTable2InsertRequest);
                        #endregion InsertByRecords
                    }
                }
                //Deallocate Cursor jobmatlCursor
            }
            //Deallocate Cursor jobCursor

            #region CRUD LoadToRecord
            ICollectionLoadResponse tv_tempOutputLoadResponse = this.iRpt_JobBOMCRUD.LoadCollection(MOAddonAvailable);
            #endregion  LoadToRecord

            Data = rpt_JobBOMChangeValueForUbVisibleAndUbFlag.ChangeValueForUbVisibleAndUbFlag(tv_tempOutputLoadResponse, SortBy, PageJob3);

            this.transactionFactory.CommitTransaction("");

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: CloseSessionContextSp
            var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

            #endregion ExecuteMethodCall

            return (Data, Severity);
        }

        public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Rpt_JobBOMSp(
			string AltExtGenSp,
			string JobStarting = null,
			string JobEnding = null,
			int? SuffixStarting = null,
			int? SuffixEnding = null,
			string PageJob3 = null,
			int? RefFields = null,
			string SortBy = null,
			string DisplayLevel = null,
			int? PrintCost = null,
			int? DisplayHeader = null,
			string pSite = null)
		{
			JobType _JobStarting = JobStarting;
			JobType _JobEnding = JobEnding;
			SuffixType _SuffixStarting = SuffixStarting;
			SuffixType _SuffixEnding = SuffixEnding;
			StringType _PageJob3 = PageJob3;
			ListYesNoType _RefFields = RefFields;
			StringType _SortBy = SortBy;
			StringType _DisplayLevel = DisplayLevel;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "JobStarting", _JobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEnding", _JobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixStarting", _SuffixStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixEnding", _SuffixEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageJob3", _PageJob3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefFields", _RefFields, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayLevel", _DisplayLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
