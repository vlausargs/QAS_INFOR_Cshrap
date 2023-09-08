//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GetItemContent.cs

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
using CSI.MG.MGCore;
using CSI.Material;

namespace CSI.Reporting
{
    public class Rpt_GetItemContent : IRpt_GetItemContent
    {
        IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        ICollectionInsertRequestFactory collectionInsertRequestFactory;
        ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICloseSessionContext iCloseSessionContext;
        readonly IInitSessionContext iInitSessionContext;
        readonly IGetWinRegDecGroup iGetWinRegDecGroup;
        readonly IFixMaskForCrystal iFixMaskForCrystal;
        readonly IExpandKyByType iExpandKyByType;
        readonly IGetItemContent iGetItemContent;
        readonly IScalarFunction scalarFunction;
        IExistsChecker existsChecker;
        IVariableUtil variableUtil;
        IStringUtil stringUtil;
        ISQLValueComparerUtil sQLUtil;
        readonly ILowString lowString;
        public Rpt_GetItemContent(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICloseSessionContext iCloseSessionContext,
            IInitSessionContext iInitSessionContext,
            IGetWinRegDecGroup iGetWinRegDecGroup,
            IFixMaskForCrystal iFixMaskForCrystal,
            IExpandKyByType iExpandKyByType,
            IGetItemContent iGetItemContent,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ILowString lowString)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iCloseSessionContext = iCloseSessionContext;
            this.iInitSessionContext = iInitSessionContext;
            this.iGetWinRegDecGroup = iGetWinRegDecGroup;
            this.iFixMaskForCrystal = iFixMaskForCrystal;
            this.iExpandKyByType = iExpandKyByType;
            this.iGetItemContent = iGetItemContent;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.lowString = lowString;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_GetItemContentSp(string Item = null,
            string RefType = null,
            string RefNum = null,
            int? RefLine = null,
            int? RefRelease = null,
            string pSite = null,
            string InvNum = null,
            int? InvLine = null,
            int? InvSeq = null)
        {
            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            Guid? RptSessionID = null;
            DecimalPlacesType _DomPricePlaces = DBNull.Value;
            int? DomPricePlaces = null;
            InputMaskType _DomPriceFormat = DBNull.Value;
            string DomPriceFormat = null;
            DecimalPlacesType _DomAmountPlaces = DBNull.Value;
            int? DomAmountPlaces = null;
            InputMaskType _DomAmountFormat = DBNull.Value;
            string DomAmountFormat = null;
            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause($"ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_GetItemContentSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_GetItemContentSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_GetItemContentSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

                    var ALTGEN = AltExtGen_Rpt_GetItemContentSp(_ALTGEN_SpName,
                        Item,
                        RefType,
                        RefNum,
                        RefLine,
                        RefRelease,
                        pSite,
                        InvNum,
                        InvLine,
                        InvSeq);
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
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_GetItemContentSp") != null)
            {
                var EXTGEN = AltExtGen_Rpt_GetItemContentSp("dbo.EXTGEN_Rpt_GetItemContentSp",
                    Item,
                    RefType,
                    RefNum,
                    RefLine,
                    RefRelease,
                    pSite,
                    InvNum,
                    InvLine,
                    InvSeq);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: InitSessionContextSp
            var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(ContextName: "Rpt_GetItemContentSp"
                , SessionID: RptSessionID
                , Site: pSite);
            RptSessionID = InitSessionContext.SessionID;

            #endregion ExecuteMethodCall

            InvNum = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("InvNumType", InvNum), this.lowString.LowStringFn("InvNumType"));
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @ItemContentTable TABLE (
                    ItemContent       ItemContentType      ,
                    CurrencyCode      CurrCodeType         ,
                    BasePrice         CostPrcType          ,
                    DomPrice          CostPrcType          ,
                    UM                UMType               ,
                    ItemContentFactor ItemContentFactorType,
                    ExchangeName      ExchangeNameType     ,
                    Description       DescriptionType      ,
                    Surcharge         CostPrcType          );
                SELECT * into #tv_ItemContentTable from @ItemContentTable ");

            #region CRUD LoadToVariable
            var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_DomPriceFormat,"cst_prc_format"},
                    {_DomPricePlaces,"places_cp"},
                    {_DomAmountFormat,"amt_format"},
                    {_DomAmountPlaces,"places"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "currency",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("currency.curr_code = (SELECT curr_code FROM currparms)"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(currencyLoadRequest);
            DomPriceFormat = _DomPriceFormat;
            DomPricePlaces = _DomPricePlaces;
            DomAmountFormat = _DomAmountFormat;
            DomAmountPlaces = _DomAmountPlaces;
            #endregion  LoadToVariable

            DomPriceFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(DomPriceFormat, this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
            DomAmountFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(DomAmountFormat, this.iGetWinRegDecGroup.GetWinRegDecGroupFn());

            #region CRUD InsertByMethodCall
            //Please Generate the bounce for this stored procedure:GetItemContentSp
            var tv_ItemContentTableExecResult = this.iGetItemContent.GetItemContentSp(Item: Item
                , RefType: RefType
                , RefNum: RefNum
                , RefLine: RefLine
                , RefRelease: RefRelease
                , InvNum: InvNum
                , InvLine: InvLine
                , InvSeq: InvSeq);
            var tv_ItemContentTableLoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(tv_ItemContentTableExecResult.Data,
                new List<string>() { "ItemContent",
                    "CurrencyCode",
                    "BasePrice",
                    "DomPrice",
                    "UM",
                    "ItemContentFactor",
                    "ExchangeName",
                    "Description",
                    "Surcharge" });
            var tv_ItemContentTableInsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ItemContentTable",
            items: tv_ItemContentTableLoadResponse.Items);

            this.appDB.Insert(tv_ItemContentTableInsertRequest);

            #endregion InsertByMethodCall

            #region CRUD LoadToRecord
            var tv_ItemContentTable1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"col0ItemContent","ItemContent"},
                    {"col1CurrencyCode","CurrencyCode"},
                    {"col2BasePrice","BasePrice"},
                    {"col3DomPrice","DomPrice"},
                    {"col4UM","UM"},
                    {"col5ItemContentFactor","ItemContentFactor"},
                    {"col6ExchangeName","ExchangeName"},
                    {"col7Description","Description"},
                    {"col8Surcharge","Surcharge"},
                    {"Dom_Price_Places",$"{variableUtil.GetValue<int?>(DomPricePlaces)}"},
                    {"Dom_Price_Format",$"{variableUtil.GetValue<string>(DomPriceFormat)}"},
                    {"Dom_Amount_Places",$"{variableUtil.GetValue<int?>(DomAmountPlaces)}"},
                    {"Dom_Amount_Format",$"{variableUtil.GetValue<string>(DomAmountFormat)}"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_ItemContentTable",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_ItemContentTable1LoadResponse = this.appDB.Load(tv_ItemContentTable1LoadRequest);
            #endregion  LoadToRecord

            Data = tv_ItemContentTable1LoadResponse;

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: CloseSessionContextSp
            var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

            #endregion ExecuteMethodCall

            return (Data, Severity);
        }
        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_GetItemContentSp(string AltExtGenSp,
            string Item = null,
            string RefType = null,
            string RefNum = null,
            int? RefLine = null,
            int? RefRelease = null,
            string pSite = null,
            string InvNum = null,
            int? InvLine = null,
            int? InvSeq = null)
        {
            ItemType _Item = Item;
            RefTypeCEIOPRVType _RefType = RefType;
            EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
            CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLine = RefLine;
            CoReleaseOperNumPoReleaseType _RefRelease = RefRelease;
            SiteType _pSite = pSite;
            InvNumType _InvNum = InvNum;
            InvLineType _InvLine = InvLine;
            InvSeqType _InvSeq = InvSeq;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvLine", _InvLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);

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
