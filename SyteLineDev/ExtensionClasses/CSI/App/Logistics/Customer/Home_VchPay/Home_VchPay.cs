//PROJECT NAME: Logistics
//CLASS NAME: Home_VchPay.cs

using System;
using System.Data;
using System.Xml;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;
using CSI.Reporting;
using CSI.Data.Utilities;
using CSI.Data.Cache;

namespace CSI.Logistics.Customer
{
	public class Home_VchPay : IHome_VchPay
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly IRecordCollectionToDataTable recordCollectionToDataTable;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly IDayEndOf iDayEndOf;
		readonly ISQLValueComparerUtil sQLUtil;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly IUnionUtil mainUnionUtil;
        readonly IRpt_VouchersPayableSub rpt_VouchersPayableSub;
        readonly ISessionBasedCache mgSessionVariableBasedCache;
        readonly IQueryLanguage queryLanguage;
        readonly IBookmarkFactory bookmarkFactory;
        readonly LoadType loadType;
		readonly ISortOrderFactory sortOrderFactory;
        readonly IHome_VchPayBuildPoFilterCondition _home_VchPayBuildPoFilterCondition;

        public Home_VchPay(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
            IRecordCollectionToDataTable recordCollectionToDataTable,
            ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			IDayEndOf iDayEndOf,
			ISQLValueComparerUtil sQLUtil,
            IUnionUtil mainUnionUtil,
            IDefineProcessVariable defineProcessVariable,
            IRpt_VouchersPayableSub rpt_VouchersPayableSub,
			ISessionBasedCache mgCache,
            IBookmarkFactory bookmarkFactory,
            IQueryLanguage queryLanguage,
            IGetVariable getVariable,
            ISortOrderFactory sortOrderFactory,
            IHome_VchPayBuildPoFilterCondition home_VchPayBuildPoFilterCondition)
		{
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;            
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.recordCollectionToDataTable = recordCollectionToDataTable;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.transactionFactory = transactionFactory;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.iDayEndOf = iDayEndOf;
            this.sQLUtil = sQLUtil;
            this.mainUnionUtil = mainUnionUtil;
            this.defineProcessVariable = defineProcessVariable;
            this.getVariable = getVariable;
            this.rpt_VouchersPayableSub = rpt_VouchersPayableSub;
            this.mgSessionVariableBasedCache = mgCache;
            this.queryLanguage = queryLanguage;
			this.loadType = bunchedLoadCollection.LoadType;
			this.bookmarkFactory = bookmarkFactory;
			this.sortOrderFactory = sortOrderFactory;
            _home_VchPayBuildPoFilterCondition = home_VchPayBuildPoFilterCondition;
		}

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Home_VchPaySp(
            string FilterString = null,
            DateTime? CutoffDate = null,
            string SiteGroup = null)
        {
            Dictionary<string, SortOrderDirection> sortDic = new Dictionary<string, SortOrderDirection>();
            sortDic.Add("po_all.site_ref", SortOrderDirection.Ascending);
            sortDic.Add("po_all.vend_num", SortOrderDirection.Ascending);
            sortDic.Add("po_all.po_num", SortOrderDirection.Ascending);
            ISortOrder poSortOrder = sortOrderFactory.Create(sortDic);

            int recordCap = bunchedLoadCollection.RecordCap;
            if (recordCap == -1) recordCap = 200;
            else if (recordCap == 0) recordCap = int.MaxValue;

            int outputRowCount = 0;
            SiteGroupType _SiteGroup = SiteGroup;
            ICollectionLoadResponse Data = null;
            bunchedLoadCollection.StartBunching();
            int? returnCode = 0;
            string variableValue = null;
            string infobar = null;
            string filterInPlaceWhereClause = " 1 = 1 ";
            IBookmark currentRowBookmark = null;
            IBookmark previousRowBookmark = null;
            if (!string.IsNullOrEmpty(FilterString))
            {
                filterInPlaceWhereClause = ParseFIPIntoWhereClause(FilterString);
            }

            if (loadType == LoadType.Next)
            {
                currentRowBookmark = mgSessionVariableBasedCache.Get<Bookmark>("Bookmark");
            }

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            string Infobar = null;
            CurrCodeType _DomCurrCode = DBNull.Value;
            string DomCurrCode = null;
            string VendNum = null;
            string PoNum = null;
            AmtTotType _VPMatlAmt = DBNull.Value;
            decimal? VPMatlAmt = null;
            AmtTotType _VPLCAmt = DBNull.Value;
            decimal? VPLCAmt = null;
            string VendName = null;
            string SiteRef = null;
            ICollectionLoadResponse PoVendCrsLoadResponseForCursor = null;
            ICollectionLoadRequest PoVendCrsLoadStatementRequestForCursor = null;
            int PoVendCrs_CursorFetch_Status = -1;
            int PoVendCrs_CursorCounter = -1;
            if (existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_VchPaySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_VchPaySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord				

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_VchPaySp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_Home_VchPaySp(_ALTGEN_SpName,
                        FilterString,
                        CutoffDate,
                        SiteGroup);
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

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_VchPaySp") != null)
            {
                var EXTGEN = AltExtGen_Home_VchPaySp("dbo.EXTGEN_Home_VchPaySp",
                    FilterString,
                    CutoffDate,
                    SiteGroup);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @VchPayTable TABLE (
				    VendNum              VendNumType        ,
				    VendName             NameType           ,
				    ItemNum              ItemType           ,
				    ItemDesc             DescriptionType    ,
				    PoCurrCode            CurrCodeType      ,
				    CurrDesc             DescriptionType    ,
				    PoNum                PoNumType          ,
				    PoLine               PoLineType         ,
				    PoRelease            PoReleaseType      ,
				    PoitemDesc           DescriptionType    ,
				    RType                INT                ,
				    QtyNotVchd           QtyTotlType        ,
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
				    PVQty                QtyTotlType        ,
				    PVItemCost           AmountType         ,
				    PVGrnNum             GrnNumType         ,
				    PVPackNum            PackNumType        ,
				    LCTypeOrder          TINYINT            ,
				    PoBuilderPoOrigSite  SiteType           ,
				    PoBuilderPoNum       PoNumType          ,
				    PoSiteRef            SiteType           ,
				    QtyUnitFormat        NVARCHAR (30)      ,
				    QtyUnitPlaces        TINYINT            ,
				    AmountFormat         NVARCHAR (30)      ,
				    AmountPlaces         TINYINT            ,
				    CostPriceFormat      NVARCHAR (30)      ,
				    CostPricePlaces      TINYINT            ,
				    ItemOverview         ProductOverviewType,
				    DisplayDetailHeading FlagNyType          PRIMARY KEY (LCTypeOrder, PoNum, PoLine, PoRelease, PoSiteRef));
				SELECT * into #tv_VchPayTableMain from @VchPayTable 
				ALTER TABLE #tv_VchPayTableMain ADD PRIMARY KEY (LCTypeOrder, PoNum, PoLine, PoRelease, PoSiteRef) ");

            if (this.scalarFunction.Execute<int?>(
                "OBJECT_ID",
                "tempdb..#VchPay") == null)
            {
                this.sQLExpressionExecutor.Execute(@"Declare
					 @VendNum VendNumType
					 ,@PoNum PoNumType
					 ,@VendCurrCode CurrCodeType
					 ,@VPMatlAmt AmtTotType
					 ,@VPLCAmt AmtTotType
					 ,@VendName NameType
					 ,@SiteRef SiteType
					 SELECT @VendNum AS VendNum,
					        @PoNum AS PoNum,
					        @VendCurrCode AS VendCurrCode,
					        @VPMatlAmt AS VPMatlAmt,
					        @VPLCAmt AS VPLCAmt,
					        @VendName AS VendName,
					        @SiteRef AS SiteRef
					 INTO   #VchPay
					 WHERE  1 = 2");
            }

            if (this.scalarFunction.Execute<int?>(
                "OBJECT_ID",
                "tempdb..#VchPayTable") == null)
            {
                this.sQLExpressionExecutor.Execute(@"SELECT *
					 INTO   #VchPayTable
					 FROM   #tv_VchPayTableMain ");
            }
            Severity = 0;
            CutoffDate = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(CutoffDate));

            #region CRUD LoadToVariable
            var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_DomCurrCode,"curr_code"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "currparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
            if (currparmsLoadResponse.Items.Count > 0)
            {
                DomCurrCode = _DomCurrCode;
            }
            #endregion  LoadToVariable

            if (SiteGroup == null)
            {
                #region CRUD LoadToVariable
                var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_SiteGroup,"site_group"},
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
            #region Cursor Statement

            #region CRUD LoadArbitrary
            IParameterizedCommand whereStatement = _home_VchPayBuildPoFilterCondition.GetPoFilterWhereClause(CutoffDate, SiteGroup, filterInPlaceWhereClause);
            if (currentRowBookmark != null)
            {
                whereStatement = queryLanguage.AppendBookmark(whereStatement, currentRowBookmark);
            }

            PoVendCrsLoadStatementRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"po_all.vend_num","po_all.vend_num"},
                    {"po_all.po_num","po_all.po_num"},
                    {"vendaddr.name","vendaddr.name"},
                    {"po_all.site_ref","po_all.site_ref"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "po_all",
                fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN vendaddr ON vendaddr.vend_num = po_all.vend_num"),
                whereClause: whereStatement,
                orderByClause: collectionLoadRequestFactory.Clause("po_all.site_ref, po_all.vend_num, po_all.po_num"));
            #endregion  LoadArbitrary

            #endregion Cursor Statement
            PoVendCrsLoadResponseForCursor = this.appDB.Load(PoVendCrsLoadStatementRequestForCursor);
            PoVendCrs_CursorFetch_Status = PoVendCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
            PoVendCrs_CursorCounter = -1;

            while (true)
            {
                PoVendCrs_CursorCounter++;
                IRecordReadOnly currentRow = null;
                if (PoVendCrsLoadResponseForCursor.Items.Count > PoVendCrs_CursorCounter)
                {
                    currentRow = PoVendCrsLoadResponseForCursor.Items[PoVendCrs_CursorCounter];
                    previousRowBookmark = currentRowBookmark;
                    currentRowBookmark = bookmarkFactory.Create(currentRow, poSortOrder);

                    VendNum = PoVendCrsLoadResponseForCursor.Items[PoVendCrs_CursorCounter].GetValue<string>(0);
                    PoNum = PoVendCrsLoadResponseForCursor.Items[PoVendCrs_CursorCounter].GetValue<string>(1);
                    VendName = PoVendCrsLoadResponseForCursor.Items[PoVendCrs_CursorCounter].GetValue<string>(2);
                    SiteRef = PoVendCrsLoadResponseForCursor.Items[PoVendCrs_CursorCounter].GetValue<string>(3);
                }

                PoVendCrs_CursorFetch_Status = (PoVendCrs_CursorCounter == PoVendCrsLoadResponseForCursor.Items.Count ? -1 : 0);

                if (sQLUtil.SQLEqual(PoVendCrs_CursorFetch_Status, -1) == true)
                {
                    break;
                }

                #region CRUD InsertByMethodCall
                //Please Generate the bounce for this stored procedure:Rpt_VouchersPayableSubSp
                var VchPayTable1ExecResult = rpt_VouchersPayableSub.Rpt_VouchersPayableSubSp(
                    POType: "RB",
                    TransDomCurr: 1,
                    ShowDetail: 0,
                    CutoffDate: CutoffDate,
                    PoStarting: PoNum,
                    PoEnding: PoNum,
                    VendorStarting: null,
                    VendorEnding: null,
                    CutoffDateOffset: null,
                    DisplayHeader: null,
                    SiteGroup: SiteRef,
                    BuilderPoStarting: null,
                    BuilderPoEnding: null,
                    BGSessionId: null,
                    TaskId: null,
                    Infobar: Infobar,
                    UseSite: 0,
                    recordCapOverwrite: int.MaxValue);
                var VchPayTable1LoadResponse = VchPayTable1ExecResult.Data;

                DataTable poVchData = recordCollectionToDataTable.ToDataTable(VchPayTable1LoadResponse.Items);
                SumAmount(poVchData, out VPMatlAmt, out VPLCAmt);

                Infobar = VchPayTable1ExecResult.Infobar;
                #endregion InsertByMethodCall

                if ((VPMatlAmt != null || VPLCAmt != null) && ParseFIPForAmount(FilterString, VPMatlAmt, VPLCAmt))
                {
                    #region CRUD LoadResponseWithoutTable
                    var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                    {
                        { "VendNum", variableUtil.GetValue<string>(VendNum,true)},
                        { "PoNum", variableUtil.GetValue<string>(PoNum,true)},
                        { "VendCurrCode", variableUtil.GetValue<string>(DomCurrCode,true)},
                        { "VPMatlAmt", variableUtil.GetValue<decimal?>(VPMatlAmt,true)},
                        { "VPLCAmt", variableUtil.GetValue<decimal?>(VPLCAmt,true)},
                        { "VendName", variableUtil.GetValue<string>(VendName,true)},
                        { "SiteRef", variableUtil.GetValue<string>(SiteRef,true)},
                    });

                    var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                    Data = nonTableLoadResponse;
                    mainUnionUtil.Add(nonTableLoadResponse);

                    outputRowCount++;
                    #endregion CRUD LoadResponseWithoutTable

                    if (outputRowCount > recordCap)
                    {
                        mgSessionVariableBasedCache.Insert("Bookmark", (ICachable)previousRowBookmark);
                        break;
                    }
                }
            }
            //Deallocate Cursor PoVendCrs

            (returnCode, variableValue, infobar) = getVariable.GetVariableSp("Bookmark", "", 0, "", "");

            if (!string.IsNullOrEmpty(variableValue))
            {
                defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
            }

            bunchedLoadCollection.EndBunching();
            Data = mainUnionUtil.Process(UnionType.UnionAll, "SiteRef, VendNum, PoNum");

            return (Data, Severity);
        }

        #region Calculate Amount
        private void SumAmount(DataTable tableData, out decimal? vpMatlAmt, out decimal? vpLcAmt)
        {
            vpMatlAmt = 0;
            vpLcAmt = 0;
            bool hasMatchedMatlRows = false;
            bool hasMatchedLCToVchRows = false;
            foreach (DataRow row in tableData.Rows)
            {
                if (Convert.ToInt32(row["LCTypeOrder"]) == 0)
                {
                    hasMatchedMatlRows = true;
                    // Once the vpMatlAmt is null the sum result should be null.
                    if (vpMatlAmt == null || Convert.IsDBNull(row["VPMatlAmt"]))
                    {
                        vpMatlAmt = null;
                    }
                    else
                    {
                        vpMatlAmt += Convert.ToDecimal(row["VPMatlAmt"]);
                    }
                }

                if(Convert.ToInt32(row["LCTypeOrder"]) > 0)
                {
                    hasMatchedLCToVchRows = true;
                    // Once the vpLcAmt is null the sum result should be null.
                    if (vpLcAmt == null || Convert.IsDBNull(row["LCToVch"]))
                    {
                        vpLcAmt = null;
                    }
                    else
                    {
                        vpLcAmt += Convert.ToDecimal(row["LCToVch"]);
                    }
                }
            }

            if(hasMatchedMatlRows == false)
            {
                vpMatlAmt = null;
            }
            if(hasMatchedLCToVchRows == false)
            {
                vpLcAmt = null;
            }
        }
        #endregion

        #region Filter In Place Methods
        private string ParseFIPIntoWhereClause(string filterStringXml)
        {
            string filterClause = " 1 = 1 ";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(filterStringXml);
            if (xmlDoc.ChildNodes.Count == 0 && xmlDoc.ChildNodes[0].ChildNodes.Count == 0)
            {
                return filterClause;
            }

            foreach (XmlNode itemNode in xmlDoc.ChildNodes[0].ChildNodes)
            {
                string propertyNodeValue = itemNode.ChildNodes[0].InnerText;
                string operNodeValue = itemNode.ChildNodes[1].InnerText;
                string valueNodeValue = itemNode.ChildNodes[2].InnerText;

                if (propertyNodeValue == "SiteRef")
                {
                    filterClause += string.Format(" AND po_all.site_ref {0} '{1}' ", operNodeValue, valueNodeValue);
                }

                if (propertyNodeValue == "VendNum")
                {
                    filterClause += string.Format(" AND po_all.vend_num {0} '{1}' ", operNodeValue, valueNodeValue);
                }

                if (propertyNodeValue == "PoNum")
                {
                    filterClause += string.Format(" AND po_all.po_num {0} '{1}' ", operNodeValue, valueNodeValue);
                }

                if (propertyNodeValue == "VendName")
                {
                    filterClause += string.Format(" AND vendaddr.name {0} '{1}' ", operNodeValue, valueNodeValue);
                }
            }

            return filterClause;
        }

        private bool ParseFIPForAmount(string filterStringXml, decimal? vpMatlAmt, decimal? vpLcAmt)
        {
            bool compareResult = true;
            if(string.IsNullOrEmpty(filterStringXml))
            {
                return true;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(filterStringXml);
            if (xmlDoc.ChildNodes.Count == 0 && xmlDoc.ChildNodes[0].ChildNodes.Count == 0)
            {
                return true;
            }

            foreach (XmlNode itemNode in xmlDoc.ChildNodes[0].ChildNodes)
            {
                string propertyNodeValue = itemNode.ChildNodes[0].InnerText;
                string operNodeValue = itemNode.ChildNodes[1].InnerText;
                string valueNodeValue = itemNode.ChildNodes[2].InnerText;
                
                if (propertyNodeValue == "VPMatlAmt")
                {
                    compareResult = compareResult && ValueCompare(vpMatlAmt, operNodeValue, Convert.ToDecimal(valueNodeValue));
                }

                if (propertyNodeValue == "VPLCAmt")
                {
                    compareResult = compareResult && ValueCompare(vpLcAmt, operNodeValue, Convert.ToDecimal(valueNodeValue));
                }
            }

            return compareResult;
        }

        private bool ValueCompare(decimal? firstValue, string compareOperator, decimal? secondValue)
        {
            bool compareResult = false;
            switch (compareOperator)
            {
                case "=":
                    compareResult = firstValue == secondValue;
                    break;
                case ">":
                    compareResult = firstValue > secondValue;
                    break;
                case "<":
                    compareResult = firstValue < secondValue;
                    break;
                case ">=":
                    compareResult = firstValue >= secondValue;
                    break;
                case "<=":
                    compareResult = firstValue <= secondValue;
                    break;
                case "<>":
                    compareResult = firstValue != secondValue;
                    break;
            }

            return compareResult;
        }
        #endregion

        public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Home_VchPaySp(
			string AltExtGenSp,
			string FilterString = null,
			DateTime? CutoffDate = null,
			string SiteGroup = null)
		{
			LongListType _FilterString = FilterString;
			DateType _CutoffDate = CutoffDate;
			SiteGroupType _SiteGroup = SiteGroup;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				
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
