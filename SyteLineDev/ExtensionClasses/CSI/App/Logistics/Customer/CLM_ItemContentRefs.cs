//PROJECT NAME: Logistics
//CLASS NAME: CLM_ItemContentRefs.cs

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

namespace CSI.Logistics.Customer
{
    public class CLM_ItemContentRefs : ICLM_ItemContentRefs
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IBuildXMLFilterString iBuildXMLFilterString;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IGetSiteDate iGetSiteDate;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly IRaiseError raiseError;
        readonly ISQLValueComparerUtil sQLUtil;

        public CLM_ItemContentRefs(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IBuildXMLFilterString iBuildXMLFilterString,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IGetSiteDate iGetSiteDate,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            IRaiseError raiseError,
            ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iBuildXMLFilterString = iBuildXMLFilterString;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.iGetSiteDate = iGetSiteDate;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.raiseError = raiseError;
            this.sQLUtil = sQLUtil;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ItemContentRefsSp(string Item = null,
            string RefType = null,
            string RefNum = null,
            int? RefLine = 0,
            int? RefRelease = 0,
            DateTime? EffectDate = null,
            string FilterString = null)
        {
            DateTimeType _EffectDate = EffectDate;
            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {
                ICollectionLoadResponse Data = null;

                StringType _ALTGEN_SpName = DBNull.Value;
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                int? Severity = null;
                DateTime? CurrDate = null;
                CustNumType _CustNum = DBNull.Value;
                string CustNum = null;
                CustSeqType _CustSeq = DBNull.Value;
                int? CustSeq = null;
                VendNumType _VendNum = DBNull.Value;
                string VendNum = null;
                DateTime? EffectDateOutput = null;
                string RefTypeOutput = null;
                string RefNumOutput = null;
                int? RefLineOutput = null;
                int? RefReleaseOutput = null;
                int? Exist = null;
                string Infobar = null;
                string SelectionClause = null;
                string FromClause = null;
                string WhereClause = null;
                string AdditionalClause = null;
                string KeyColumns = null;
                string VeryLongFilterString = null;
                if (existsChecker.Exists(
                    tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause($"ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ItemContentRefsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ItemContentRefsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_ItemContentRefsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
                        this.appDB.Load(tv_ALTGEN1LoadRequest);
                        ALTGEN_SpName = _ALTGEN_SpName;
                        #endregion  LoadToVariable

                        var ALTGEN = AltExtGen_CLM_ItemContentRefsSp(_ALTGEN_SpName,
                            Item,
                            RefType,
                            RefNum,
                            RefLine,
                            RefRelease,
                            EffectDate,
                            FilterString);
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
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ItemContentRefsSp") != null)
                {
                    var EXTGEN = AltExtGen_CLM_ItemContentRefsSp("dbo.EXTGEN_CLM_ItemContentRefsSp",
                        Item,
                        RefType,
                        RefNum,
                        RefLine,
                        RefRelease,
                        EffectDate,
                        FilterString);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                Severity = 0;
                RefLine = (int?)(stringUtil.IsNull(RefLine, 0));
                RefRelease = (int?)(stringUtil.IsNull(RefRelease, 0));
                CustNum = null;
                VendNum = null;
                CurrDate = convertToUtil.ToDateTime(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE")));
                FilterString = stringUtil.IsNull(FilterString, "");
                RefTypeOutput = RefType;
                RefNumOutput = RefNum;
                RefLineOutput = RefLine;
                RefReleaseOutput = RefRelease;
                EffectDateOutput = convertToUtil.ToDateTime(EffectDate);
                if (sQLUtil.SQLEqual(RefType, "C") == true)
                {
                    RefNum = this.iExpandKyByType.ExpandKyByTypeFn("CustNumType", RefNum);
                    RefNumOutput = RefNum;
                }
                if (sQLUtil.SQLEqual(RefType, "V") == true)
                {
                    RefNum = this.iExpandKyByType.ExpandKyByTypeFn("VendNumType", RefNum);
                    RefNumOutput = RefNum;
                }
                if (sQLUtil.SQLEqual(RefType, "E") == true || sQLUtil.SQLEqual(RefType, "O") == true)
                {
                    RefNum = this.iExpandKyByType.ExpandKyByTypeFn("CoNumType", RefNum);
                    RefNumOutput = RefNum;

                    #region CRUD LoadToVariable
                    var coitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_CustNum,"co.cust_num"},
                            {_CustSeq,"co.cust_seq"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "coitem",
                        fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN co ON co.co_num = coitem.co_num"),
                        whereClause: collectionLoadRequestFactory.Clause("coitem.co_num = {2} AND coitem.co_line = {1} AND coitem.co_release = {0}", RefRelease, RefLine, RefNum),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    this.appDB.Load(coitemLoadRequest);
                    CustNum = _CustNum;
                    CustSeq = _CustSeq;
                    #endregion  LoadToVariable
                }
                else
                {
                    if (sQLUtil.SQLEqual(RefType, "R") == true || sQLUtil.SQLEqual(RefType, "P") == true)
                    {
                        RefNum = this.iExpandKyByType.ExpandKyByTypeFn("PoNumType", RefNum);
                        RefNumOutput = RefNum;

                        #region CRUD LoadToVariable
                        var poitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_VendNum,"vend_num"},
                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "poitem",
                            fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN po ON po.po_num = poitem.po_num"),
                            whereClause: collectionLoadRequestFactory.Clause("poitem.po_num = {3} AND poitem.po_line = {1} AND poitem.po_release = {0} AND {2} = N'P'", RefRelease, RefLine, RefType, RefNum),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        this.appDB.Load(poitemLoadRequest);
                        VendNum = _VendNum;
                        #endregion  LoadToVariable

                        if (VendNum == null)
                        {
                            #region CRUD LoadToVariable
                            var preqitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_VendNum,"preqitem.vend_num"},
                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "preqitem",
                            fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN preq ON preq.req_num = preqitem.req_num"),
                            whereClause: collectionLoadRequestFactory.Clause("preqitem.req_num = {2} AND preqitem.req_line = {0} AND {1} = N'R'", RefLine, RefType, RefNum),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                            this.appDB.Load(preqitemLoadRequest);
                            VendNum = _VendNum;
                            #endregion  LoadToVariable
                        }
                    }
                }

                if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(
                    tableName: "item_content_ref",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("item = {5} AND ref_type = {2} AND ref_num = {4} AND ref_line_suf = {3} AND ref_release = {0} AND effect_date = {1}", RefRelease, EffectDate, RefType, RefLine, RefNum, Item)))))
                {
                    if (CustNum != null)
                    {
                        #region CRUD LoadToVariable
                        var itemcustpriceLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_EffectDate,"effect_date"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        maximumRows: 1,
                        tableName: "itemcustprice",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("cust_num = {1} AND item = {2} AND effect_date <= {0}", CurrDate, CustNum, Item),
                        orderByClause: collectionLoadRequestFactory.Clause(" effect_date DESC"));
                        
                        this.appDB.Load(itemcustpriceLoadRequest);
                        EffectDate = _EffectDate;
                        #endregion  LoadToVariable
                    }
                    if (VendNum != null)
                    {
                        #region CRUD LoadToVariable
                        var itemvendpriceLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_EffectDate,"effect_date"},
                            },
                            loadForChange: false,
                            lockingType: LockingType.None,
                            maximumRows: 1,
                            tableName: "itemvendprice",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("vend_num = {1} AND item = {2} AND effect_date <= {0}", CurrDate, VendNum, Item),
                            orderByClause: collectionLoadRequestFactory.Clause(" effect_date DESC"));
                        
                        this.appDB.Load(itemvendpriceLoadRequest);
                        EffectDate = _EffectDate;
                        #endregion  LoadToVariable
                    }
                    if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(
                        tableName: "item_content_ref",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("item = {4} AND ref_type = CASE WHEN {1} IS NOT NULL THEN N'C' WHEN {2} IS NOT NULL THEN N'V' ELSE N'' END AND ref_num = CASE WHEN {1} IS NOT NULL THEN {1} WHEN {2} IS NOT NULL THEN {2} ELSE N'' END AND ref_line_suf = CASE WHEN {1} IS NOT NULL THEN {3} WHEN {2} IS NOT NULL THEN 0 ELSE N'' END AND effect_date = {0}", EffectDate, CustNum, VendNum, CustSeq, Item)))))
                    {
                        if (sQLUtil.SQLNotEqual(RefType, "I") == true)
                        {
                            #region CRUD LoadToVariable
                            var item_content_ref2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                {
                                    {_EffectDate,"effect_date"},
                                },
                                loadForChange: false,
                                lockingType: LockingType.None,
                                maximumRows: 1,
                                tableName: "item_content_ref",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("item = {1} AND ref_type = N'I' AND ISNULL(ref_num, N'') = N'' AND ref_line_suf = 0 AND ref_release = 0 AND effect_date <= {0}", CurrDate, Item),
                                orderByClause: collectionLoadRequestFactory.Clause(" effect_date DESC"));
                            
                            this.appDB.Load(item_content_ref2LoadRequest);
                            EffectDate = _EffectDate;
                            #endregion  LoadToVariable

                            if (EffectDate == null)
                            {
                                goto END_OF_PROG;
                            }
                            else
                            {
                                RefType = "I";
                                RefNum = null;
                                RefLine = 0;
                                RefRelease = 0;
                            }
                        }
                        else
                        {
                            EffectDate = null;
                        }
                    }
                    else
                    {
                        RefType = (CustNum != null ? "C" :
                        VendNum != null ? "V" : "");
                        RefNum = stringUtil.IsNull(CustNum, stringUtil.IsNull(VendNum, ""));
                        RefLine = 0;
                        RefRelease = 0;
                        if (sQLUtil.SQLEqual(RefTypeOutput, "I") == true)
                        {
                            EffectDate = null;
                        }
                    }
                }

                if (existsChecker.Exists(
                    tableName: "item_content_ref",
                    fromClause: collectionLoadRequestFactory.Clause(" AS icr"),
                    whereClause: collectionLoadRequestFactory.Clause("icr.item = {5} AND ISNULL(icr.ref_type, N'') = ISNULL({1}, N'') AND ISNULL(icr.ref_num, N'') = ISNULL({3}, N'') AND icr.ref_line_suf = ISNULL({2}, ref_line_suf) AND icr.ref_release = ISNULL({0}, ref_release) AND icr.effect_date = ISNULL({4}, icr.effect_date)", RefReleaseOutput, RefTypeOutput, RefLineOutput, RefNumOutput, EffectDate, Item)))
                {
                    Exist = 1;
                }
                else
                {
                    Exist = 0;
                }
                SelectionClause = "";
                FromClause = "";
                WhereClause = "";
                AdditionalClause = "";
                KeyColumns = "";
                VeryLongFilterString = "";
                VeryLongFilterString = FilterString;

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "Item"
                    , Value: Item
                    , DataType: "ItemType"
                    , NameInParmList: "@Item"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString.XmlFilterString;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString1 = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "RefType"
                    , Value: RefType
                    , DataType: "RefTypeCEIOPRVType"
                    , NameInParmList: "@RefType"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString1.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString1.XmlFilterString;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString2 = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "RefNum"
                    , Value: RefNum
                    , DataType: "EmpJobCoPoRmaProjPsTrnNumType"
                    , NameInParmList: "@RefNum"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString2.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString2.XmlFilterString;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString3 = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "RefLine"
                    , Value: convertToUtil.ToString(RefLine)
                    , DataType: "CoLineSuffixPoLineProjTaskRmaTrnLineType"
                    , NameInParmList: "@RefLine"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString3.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString3.XmlFilterString;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString4 = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "RefRelease"
                    , Value: convertToUtil.ToString(RefRelease)
                    , DataType: "CoReleaseOperNumPoReleaseType"
                    , NameInParmList: "@RefRelease"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString4.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString4.XmlFilterString;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString5 = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "EffectDate"
                    , Value: convertToUtil.ToString(EffectDate)
                    , DataType: "DateTimeType"
                    , NameInParmList: "@EffectDate"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString5.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString5.XmlFilterString;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString6 = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "RefTypeOutput"
                    , Value: RefTypeOutput
                    , DataType: "RefTypeCEIOPRVType"
                    , NameInParmList: "@RefTypeOutput"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString6.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString6.XmlFilterString;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString7 = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "EffectDateOutput"
                    , Value: convertToUtil.ToString(EffectDateOutput)
                    , DataType: "DateTimeType"
                    , NameInParmList: "@EffectDateOutput"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString7.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString7.XmlFilterString;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString8 = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "RefNumOutput"
                    , Value: RefNumOutput
                    , DataType: "EmpJobCoPoRmaProjPsTrnNumType"
                    , NameInParmList: "@RefNumOutput"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString8.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString8.XmlFilterString;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString9 = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "RefLineOutput"
                    , Value: convertToUtil.ToString(RefLineOutput)
                    , DataType: "CoLineSuffixPoLineProjTaskRmaTrnLineType"
                    , NameInParmList: "@RefLineOutput"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString9.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString9.XmlFilterString;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString10 = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "RefReleaseOutput"
                    , Value: convertToUtil.ToString(RefReleaseOutput)
                    , DataType: "CoReleaseOperNumPoReleaseType"
                    , NameInParmList: "@RefReleaseOutput"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString10.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString10.XmlFilterString;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                var BuildXMLFilterString11 = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "Exist"
                    , Value: convertToUtil.ToString(Exist)
                    , DataType: "ListYesNoType"
                    , NameInParmList: "@Exist"
                    , IsPropertyInWhereClause: 0
                    , XmlFilterString: VeryLongFilterString);
                Severity = BuildXMLFilterString11.ReturnCode;
                VeryLongFilterString = BuildXMLFilterString11.XmlFilterString;

                #endregion ExecuteMethodCall

                SelectionClause = "SELECT *";
                WhereClause = "WHERE 1=1";
                FromClause = @"FROM (SELECT icr.item_content AS ItemContent
                                         , ic.description AS ItemContentDescription
                                         , ISNULL(@EffectDateOutput, icr.effect_date) AS EffectDate
                                         , icr.item AS Item
                                         , it.description AS ItemDescription
                                         , ic.u_m AS Um
                                         , um.description AS UmDescription
                                         , icr.item_content_factor AS ItemContentFactor
                                         , icr.base_price AS BasePrice
                                         , @RefTypeOutput AS RefType
                                         , @RefNumOutput AS RefNum
                                         , @RefLineOutput AS RefLine
                                         , @RefReleaseOutput AS RefRelease
                                         , @Exist AS UbExist
                                         , icr.RowPointer AS RowPointer
                                         , icr.RecordDate FROM item_content_ref icr
                                          INNER JOIN item_content ic ON ic.item_content = icr.item_content
                                          INNER JOIN u_m um ON um.u_m = ic.u_m
                                          INNER JOIN item it ON it.item = icr.item
                                          WHERE icr.item                 = @Item
                                          AND ISNULL(icr.ref_type, N'') = ISNULL(@RefType, N'')
                                          AND ISNULL(icr.ref_num, N'')  = ISNULL(@RefNum, N'')
                                          AND icr.ref_line_suf           = ISNULL(@RefLine, icr.ref_line_suf)
                                          AND icr.ref_release            = ISNULL(@RefRelease, icr.ref_line_suf)
                                          AND icr.effect_date            = ISNULL(@EffectDate, icr.effect_date)) T";
                AdditionalClause = "ORDER BY ItemContent, Item, RefNum, RefLine, RefRelease";
                KeyColumns = "ItemContent, Item, RefNum, RefLine, RefRelease";
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#DynamicParameters") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters ");
                }

                this.sQLExpressionExecutor.Execute(@"Declare
                     @SelectionClause VeryLongListType
                     ,@FromClause VeryLongListType
                     ,@WhereClause VeryLongListType
                     ,@AdditionalClause VeryLongListType
                     ,@KeyColumns VeryLongListType
                     ,@VeryLongFilterString VeryLongListType
                     SELECT @SelectionClause AS SelectionClause,
                            @FromClause AS FromClause,
                            @WhereClause AS WhereClause,
                            @AdditionalClause AS AdditionalClause,
                            @KeyColumns AS KeyColumns,
                            @VeryLongFilterString AS FilterString
                     INTO   #DynamicParameters
                     WHERE 1 = 2");

                #region CRUD LoadArbitrary
                var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"SelectionClause",$"{variableUtil.GetValue<string>(SelectionClause)}"},
                        {"FromClause",$"{variableUtil.GetValue<string>(FromClause)}"},
                        {"WhereClause",$"{variableUtil.GetValue<string>(WhereClause)}"},
                        {"AdditionalClause",$"{variableUtil.GetValue<string>(AdditionalClause)}"},
                        {"KeyColumns",$"{variableUtil.GetValue<string>(KeyColumns)}"},
                        {"FilterString",$"{variableUtil.GetValue<string>(VeryLongFilterString)}"},
                    },
                    selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));

                var DynamicParametersLoadResponse = this.appDB.Load(DynamicParametersLoadRequest);
                Data = DynamicParametersLoadResponse;
                #endregion  LoadArbitrary

                #region CRUD InsertByRecords
                var DynamicParametersInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
                    items: DynamicParametersLoadResponse.Items);

                this.appDB.Insert(DynamicParametersInsertRequest);
                #endregion InsertByRecords

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
                var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(NeedGetMoreRows: 1
                    , Infobar: Infobar);
                Severity = ExecuteDynamicSQL.ReturnCode;
                Data = ExecuteDynamicSQL.Data;
                Infobar = ExecuteDynamicSQL.Infobar;

                #endregion ExecuteMethodCall

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    goto RAISE_ERROR;
                }

            END_OF_PROG:;
            RAISE_ERROR:;
                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    raiseError.RaiseErrorSp(Infobar, Severity, 1);
                }
                return (Data, Severity);
            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_ItemContentRefsSp(string AltExtGenSp,
            string Item = null,
            string RefType = null,
            string RefNum = null,
            int? RefLine = 0,
            int? RefRelease = 0,
            DateTime? EffectDate = null,
            string FilterString = null)
        {
            ItemType _Item = Item;
            RefTypeCEIOPRVType _RefType = RefType;
            EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
            CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLine = RefLine;
            CoReleaseOperNumPoReleaseType _RefRelease = RefRelease;
            DateTimeType _EffectDate = EffectDate;
            LongListType _FilterString = FilterString;

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
                appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);

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
