//PROJECT NAME: Logistics
//CLASS NAME: Home_CustomerAnalysis.cs

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
using CSI.Finance.AR;
using CSI.CRUD.Logistics.Customer;
using CSI.Material;

namespace CSI.Logistics.Customer
{
    public class Home_CustomerAnalysis : IHome_CustomerAnalysis
    {
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly IUndefineProcessVariable iUndefineProcessVariable;
        readonly IDefineProcessVariable iDefineProcessVariable;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IBuildXMLFilterString iBuildXMLFilterString;
        readonly IDefaultToLocalSite iDefaultToLocalSite;
        readonly IGetProcessVariable iGetProcessVariable;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IARAgingBuckets iARAgingBuckets;
        readonly IGetStringValue iGetStringValue;
        readonly IScalarFunction scalarFunction;
        readonly IConvertToUtil convertToUtil;
        readonly IStringUtil stringUtil;
        readonly IMathUtil mathUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMaxQty iMaxQty;
        readonly IHome_CustomerAnalysisCRUD iHome_CustomerAnalysisCRUD;
        readonly IInsertSiteGroupLoader iInsertSiteGroupLoader;
        readonly IExpandKyByType _expandKyByType;
        readonly IBuildCustomerFilter _buildCustomerFilter;

        public Home_CustomerAnalysis(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            IUndefineProcessVariable iUndefineProcessVariable,
            IDefineProcessVariable iDefineProcessVariable,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IBuildXMLFilterString iBuildXMLFilterString,
            IDefaultToLocalSite iDefaultToLocalSite,
            IGetProcessVariable iGetProcessVariable,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            IARAgingBuckets iARAgingBuckets,
            IGetStringValue iGetStringValue,
            IScalarFunction scalarFunction,
            IConvertToUtil convertToUtil,
            IStringUtil stringUtil,
            IMathUtil mathUtil,
            ISQLValueComparerUtil sQLUtil,
            IMaxQty iMaxQty,
            IHome_CustomerAnalysisCRUD iHome_CustomerAnalysisCRUD,
            IInsertSiteGroupLoader iInsertSiteGroupLoader,
            IExpandKyByType expandKyByType,
            IBuildCustomerFilter buildCustomerFilter)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.iUndefineProcessVariable = iUndefineProcessVariable;
            this.iDefineProcessVariable = iDefineProcessVariable;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iBuildXMLFilterString = iBuildXMLFilterString;
            this.iDefaultToLocalSite = iDefaultToLocalSite;
            this.iGetProcessVariable = iGetProcessVariable;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.iARAgingBuckets = iARAgingBuckets;
            this.iGetStringValue = iGetStringValue;
            this.scalarFunction = scalarFunction;
            this.convertToUtil = convertToUtil;
            this.stringUtil = stringUtil;
            this.mathUtil = mathUtil;
            this.sQLUtil = sQLUtil;
            this.iMaxQty = iMaxQty;
            this.iHome_CustomerAnalysisCRUD = iHome_CustomerAnalysisCRUD;
            this.iInsertSiteGroupLoader = iInsertSiteGroupLoader;
            _expandKyByType = expandKyByType;
            _buildCustomerFilter = buildCustomerFilter;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode,
            string Infobar)
        Home_CustomerAnalysisSp(
            string FilterString = null,
            string SiteGroup = null,
            string Infobar = null)
        {
            #region variable declare
            ICollectionLoadResponse Data = null;

            string ALTGEN_SpName = null;
            int? rowCount = null;
            int? InitialCount = null;
            int? PostAgeCount = null;
            string LastSite = null;
            string LastCustNum = null;
            int? RecordCap = null;
            int? NumCustomerBlocks = null;
            string KeyColumns = null;
            string Property = null;
            string Operator = null;
            string Value = null;
            string DataType = null;
            string DataLength = null;
            #endregion

            #region ETP Block
            if (this.iHome_CustomerAnalysisCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iHome_CustomerAnalysisCRUD.SelectOptional_Module();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iHome_CustomerAnalysisCRUD.InsertOptional_Module(optional_module1LoadResponse);
                while (this.iHome_CustomerAnalysisCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iHome_CustomerAnalysisCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
                    var ALTGEN = this.iHome_CustomerAnalysisCRUD.AltExtGen_Home_CustomerAnalysisSp(ALTGEN_SpName,
                        FilterString,
                        SiteGroup,
                        Infobar);
                    int? ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity, Infobar);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iHome_CustomerAnalysisCRUD.SelectTv_ALTGEN(ALTGEN_SpName);
                    this.iHome_CustomerAnalysisCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_CustomerAnalysisSp") != null)
            {
                var EXTGEN = this.iHome_CustomerAnalysisCRUD.AltExtGen_Home_CustomerAnalysisSp("dbo.EXTGEN_Home_CustomerAnalysisSp",
                    FilterString,
                    SiteGroup,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity, EXTGEN.Infobar);
                }
            }
            #endregion

            int? Severity = 0;
            int? RecordCapChanged = 0;
            int? BlockSize = 10000;
            string SelectionClause = "";
            string FromClause = "";
            string WhereClause = "";
            string AdditionalClause = "";
            IList<string> siteGroupVar = new List<string>();

            if (SiteGroup == null)
            {
                #region CRUD InsertByRecords
                var nonTableLoadResponse = this.iHome_CustomerAnalysisCRUD.SelectSiteRef(SiteGroup);
                //Data = nonTableLoadResponse;
                //this.iHome_CustomerAnalysisCRUD.InsertSiteRef(nonTableLoadResponse);
                siteGroupVar = this.iInsertSiteGroupLoader.InsertSiteGroup(nonTableLoadResponse);
                #endregion CRUD InsertByRecords
            }
            else
            {
                #region CRUD InsertByRecords
                var Sites1LoadResponse = this.iHome_CustomerAnalysisCRUD.SelectSites(SiteGroup);
                //this.iHome_CustomerAnalysisCRUD.InsertSites(Sites1LoadResponse);
                siteGroupVar = this.iInsertSiteGroupLoader.InsertSiteGroup(Sites1LoadResponse);
                #endregion InsertByRecords
            }

            SiteGroup = stringUtil.IsNull(SiteGroup, this.iDefaultToLocalSite.DefaultToLocalSiteFn(SiteGroup));
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#CustAging") == null)
            {
                this.sQLExpressionExecutor.Execute(@"SELECT customer_all.cust_num AS CustNum,
                    	        custaddr.name AS CustName,
                    	        custaddr.credit_hold AS CustCreditHold,
                    	        custaddr.credit_limit AS CustCreditLimit,
                    	        custaddr.order_credit_limit AS CustOrderCreditLimit,
                    	        customer_all.order_bal AS CustAgeBal1,
                    	        customer_all.order_bal AS CustAgeBal2,
                    	        customer_all.order_bal AS CustAgeBal3,
                    	        customer_all.order_bal AS CustAgeBal4,
                    	        customer_all.order_bal AS CustAgeBal5,
                    	        customer_all.order_bal AS CustAgeBalNet,
                    	        customer_all.avg_bal_os AS CustAvgBalOs,
                    	        custaddr.curr_code AS CustCurrCode,
                    	        custaddr.curr_code AS ToCurrCode,
                    	        customer_all.site_ref AS SiteRef,
                    	        CAST(NULL AS NVARCHAR(2800)) AS Infobar,
                    	        CAST(0 AS INT) AS IsProcessed
                    	 INTO   #CustAging
                    	 FROM   customer_all WITH (READUNCOMMITTED), custaddr WITH (READUNCOMMITTED)
                    	 WHERE  1 = 2 ");

                this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX AgingCustNum
					    ON #CustAging(CustNum, SiteRef)");

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#CustAging2") == null)
            {
                this.sQLExpressionExecutor.Execute(@"SELECT customer_all.cust_num AS CustNum,
						        custaddr.name AS CustName,
						        custaddr.credit_hold AS CustCreditHold,
						        custaddr.credit_limit AS CustCreditLimit,
						        custaddr.order_credit_limit AS CustOrderCreditLimit,
						        customer_all.order_bal AS CustAgeBal1,
						        customer_all.order_bal AS CustAgeBal2,
						        customer_all.order_bal AS CustAgeBal3,
						        customer_all.order_bal AS CustAgeBal4,
						        customer_all.order_bal AS CustAgeBal5,
						        customer_all.order_bal AS CustAgeBalNet,
						        customer_all.avg_bal_os AS CustAvgBalOs,
						        custaddr.curr_code AS CustCurrCode,
						        customer_all.site_ref AS SiteRef,
						        CAST(NULL AS NVARCHAR(2800)) AS Infobar
						 INTO   #CustAging2
						 FROM   customer_all WITH (READUNCOMMITTED), custaddr WITH (READUNCOMMITTED)
						 WHERE  1 = 2 ");

                this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX Aging2CustNum
					    ON #CustAging2(CustNum, SiteRef)");

            }
            string FilterCust = "";
            string FilterAging = "";

            #region Cursor Statement
            ICollectionLoadResponse PropertiesCrsLoadResponseForCursor = iHome_CustomerAnalysisCRUD.SelectProperties(FilterString);
            int PropertiesCrs_CursorFetch_Status = PropertiesCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
            int PropertiesCrs_CursorCounter = -1;

            string filterStringForWhere = "";
            IList<object> parms = new List<object>();
            #endregion Cursor Statement
            while (sQLUtil.SQLEqual(1, 1) == true)
            {
                PropertiesCrs_CursorCounter++;
                if (PropertiesCrsLoadResponseForCursor.Items.Count > PropertiesCrs_CursorCounter)
                {
                    Property = PropertiesCrsLoadResponseForCursor.Items[PropertiesCrs_CursorCounter].GetValue<string>(0);
                    Operator = PropertiesCrsLoadResponseForCursor.Items[PropertiesCrs_CursorCounter].GetValue<string>(1);
                    Value = PropertiesCrsLoadResponseForCursor.Items[PropertiesCrs_CursorCounter].GetValue<string>(2);
                    DataType = PropertiesCrsLoadResponseForCursor.Items[PropertiesCrs_CursorCounter].GetValue<string>(3);
                    DataLength = Convert.ToString(PropertiesCrsLoadResponseForCursor.Items[PropertiesCrs_CursorCounter].GetValue<int?>(4));
                }
                PropertiesCrs_CursorFetch_Status = (PropertiesCrs_CursorCounter == PropertiesCrsLoadResponseForCursor.Items.Count ? -1 : 0);

                if (sQLUtil.SQLEqual(PropertiesCrs_CursorFetch_Status, -1) == true)
                {
                    break;
                }
                if (stringUtil.Like(Property, "CustAgeBal%", false))
                {
                    #region CRUD ExecuteMethodCall
                    //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                    var (ReturnCode, XmlFilterString) = this.iBuildXMLFilterString.BuildXMLFilterStringSp(
                        PropertyName: Property,
                        Operator: Operator,
                        Value: Value,
                        DataType: DataType,
                        DataLength: string.IsNullOrEmpty(DataLength) ? 0 : convertToUtil.ToInt32(DataLength),
                        UseSpecifiedDataType: 0,
                        XmlFilterString: FilterAging);
                    Severity = ReturnCode;
                    FilterAging = XmlFilterString;

                    #endregion ExecuteMethodCall
                }
                else
                {
                    Property = (sQLUtil.SQLEqual(Property, "CustNum") == true ? "customer_all.cust_num" : sQLUtil.SQLEqual(Property, "CustName") == true ? "custaddr.name" : sQLUtil.SQLEqual(Property, "CustCreditHold") == true ? "custaddr.credit_hold" : sQLUtil.SQLEqual(Property, "CustCreditLimit") == true ? "custaddr.credit_limit" : sQLUtil.SQLEqual(Property, "CustOrderCreditLimit") == true ? "custaddr.order_credit_limit" : sQLUtil.SQLEqual(Property, "CustAvgBalOs") == true ? "customer_all.avg_bal_os" : sQLUtil.SQLEqual(Property, "CustCurrCode") == true ? "custaddr.curr_code" : sQLUtil.SQLEqual(Property, "SiteRef") == true ? "customer_all.site_ref" : Property);

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
                    var (ReturnCode, XmlFilterString) = this.iBuildXMLFilterString.BuildXMLFilterStringSp(
                        PropertyName: Property,
                        Operator: Operator,
                        Value: Value,
                        DataType: DataType,
                        DataLength: string.IsNullOrEmpty(DataLength) ? 0 : convertToUtil.ToInt32(DataLength),
                        UseSpecifiedDataType: 0,
                        XmlFilterString: FilterCust);
                    Severity = ReturnCode;
                    FilterCust = XmlFilterString;

                    #endregion ExecuteMethodCall

                    if (Operator != "like" && Property == "customer_all.cust_num")
                        Value = _expandKyByType.ExpandKyByTypeFn("CustNumType", Value);

                    filterStringForWhere = _buildCustomerFilter.BuildCustomerFilterString(filterStringForWhere, parms, Property, Operator, Value);
                }
            }
            //Deallocate Cursor PropertiesCrs

            this.sQLExpressionExecutor.Execute(@"Declare
				@SelectionClause VeryLongListType
				,@FromClause VeryLongListType
				,@WhereClause VeryLongListType
				,@AdditionalClause VeryLongListType
				,@KeyColumns LongListType
				,@FilterCust LongListType
				SELECT @SelectionClause AS SelectionClause,
				       @FromClause AS FromClause,
				       @WhereClause AS WhereClause,
				       @AdditionalClause AS AdditionalClause,
				       @KeyColumns AS KeyColumns,
				       @FilterCust AS FilterString
				INTO   #DynamicParameters
				WHERE 1 = 2");
            #region CRUD InsertByRecords
            var DynamicParametersLoadResponse = this.iHome_CustomerAnalysisCRUD.SelectDynamicparameters(SelectionClause, FromClause, WhereClause, AdditionalClause, KeyColumns, FilterCust);

            this.iHome_CustomerAnalysisCRUD.InsertDynamicparameters(DynamicParametersLoadResponse);
            #endregion InsertByRecords

            #region CustAging NonTriggerInsert

            this.iHome_CustomerAnalysisCRUD.InsertCustagingWithNonTrigger(siteGroupVar, filterStringForWhere, parms);

            #endregion  CustAging NonTriggerInsert


            (InitialCount, rowCount) = this.iHome_CustomerAnalysisCRUD.LoadCustaging(InitialCount);


            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: GetProcessVariableSp
            var GetProcessVariable = this.iGetProcessVariable.GetProcessVariableSp(VariableName: "RecordCap",
                DefaultValue: convertToUtil.ToString(5000),
                DeleteVariable: 0,
                VariableValue: convertToUtil.ToString(RecordCap),
                Infobar: Infobar);
            Severity = GetProcessVariable.ReturnCode;
            RecordCap = convertToUtil.ToInt32(GetProcessVariable.VariableValue);
            Infobar = GetProcessVariable.Infobar;

            #endregion ExecuteMethodCall

            (LastSite, LastCustNum, rowCount) = this.iHome_CustomerAnalysisCRUD.LoadCustaging2(LastSite, LastCustNum);
            int? PostCount = 0;
            int? i = 0;

            (NumCustomerBlocks, rowCount) = this.iHome_CustomerAnalysisCRUD.LoadCustomer_All(NumCustomerBlocks, siteGroupVar);

            if (NumCustomerBlocks == null)
            {
                NumCustomerBlocks = 0;

            }
            else
            {
                NumCustomerBlocks = (int?)(mathUtil.Ceiling<int?>(NumCustomerBlocks / BlockSize));

            }

            while (sQLUtil.SQLBool(sQLUtil.SQLLessThanOrEqual(i, NumCustomerBlocks)))
            {
                i = (int?)(i + 1);

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ARAgingBucketsSp
                this.iARAgingBuckets.ARAgingBucketsSp();

                #endregion ExecuteMethodCall

                #region Dynamicparameters NonTriggerUpdate

                this.iHome_CustomerAnalysisCRUD.UpdateDynamicparametersWithNonTrigger(FilterAging);

                #endregion Dynamicparameters NonTriggerUpdate


                if (sQLUtil.SQLLessThan(InitialCount, RecordCap) == true)
                {

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
                    var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
                        NeedGetMoreRows: 1,
                        Infobar: Infobar);
                    Severity = ExecuteDynamicSQL.ReturnCode;
                    Data = ExecuteDynamicSQL.Data;
                    Infobar = ExecuteDynamicSQL.Infobar;

                    #endregion ExecuteMethodCall

                    break;

                }
                else
                {
                    //Please Generate the bounce for this stored procedure:ExecuteDynamicSQLSp
                    var CustAging21ExecResult = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
                        NeedGetMoreRows: 0,
                        Infobar: Infobar);
                    this.iHome_CustomerAnalysisCRUD.InsertCustaging2(CustAging21ExecResult.Data);
                    Infobar = CustAging21ExecResult.Infobar;

                }

                #region Ca NonTriggerDelete

                this.iHome_CustomerAnalysisCRUD.DeleteCaWithNonTrigger();

                #endregion  Ca NonTriggerDelete

                (PostAgeCount, rowCount) = this.iHome_CustomerAnalysisCRUD.LoadCustaging3(PostAgeCount);

                #region Custaging NonTriggerUpdate

                this.iHome_CustomerAnalysisCRUD.UpdateCustagingWithNonTrigger();

                #endregion  Custaging NonTriggerUpdate

                PostCount += PostAgeCount;
                int? RowCount = (int?)(InitialCount - PostCount);
                if (sQLUtil.SQLLessThanOrEqual(RowCount, 0) == true)
                {

                    break;

                }
                RowCount = (int?)(this.iMaxQty.MaxQtyFn(convertToUtil.ToDecimal(BlockSize), convertToUtil.ToDecimal(RowCount)));

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: DefineProcessVariableSp
                var DefineProcessVariable = this.iDefineProcessVariable.DefineProcessVariableSp(
                    VariableName: "RecordCap",
                    VariableValue: convertToUtil.ToString(RowCount),
                    Infobar: Infobar);
                Infobar = DefineProcessVariable.Infobar;

                #endregion ExecuteMethodCall

                RecordCapChanged = 1;
                this.sQLExpressionExecutor.Execute("ALTER TABLE #DynamicParameters ADD tempTableId INT IDENTITY");

                #region Dynamicparameters NonTriggerUpdate

                this.iHome_CustomerAnalysisCRUD.Dynamicparameters2UpdateWithNonTrigger(LastSite, LastCustNum, FilterCust, siteGroupVar);

                #endregion Dynamicparameters NonTriggerUpdate

                this.sQLExpressionExecutor.Execute("ALTER TABLE #DynamicParameters DROP COLUMN tempTableId");

                //Please Generate the bounce for this stored procedure:ExecuteDynamicSQLSp
                var CustAging4ExecResult = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
                    NeedGetMoreRows: 1,
                    Infobar: Infobar);

                this.iHome_CustomerAnalysisCRUD.InsertCustaging3(CustAging4ExecResult.Data);
                Infobar = CustAging4ExecResult.Infobar;

                (LastSite, LastCustNum, rowCount) = this.iHome_CustomerAnalysisCRUD.LoadCustaging4(LastCustNum, LastSite);

            }
            if (sQLUtil.SQLEqual(RecordCapChanged, 1) == true)
            {
                if (sQLUtil.SQLGreaterThan(RecordCap, 0) == true)
                {

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: DefineProcessVariableSp
                    var DefineProcessVariable1 = this.iDefineProcessVariable.DefineProcessVariableSp(
                        VariableName: "RecordCap",
                        VariableValue: convertToUtil.ToString(RecordCap),
                        Infobar: Infobar);
                    Infobar = DefineProcessVariable1.Infobar;

                    #endregion ExecuteMethodCall

                }
                else
                {

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: UndefineProcessVariableSp
                    var UndefineProcessVariable = this.iUndefineProcessVariable.UndefineProcessVariableSp(
                        VariableName: "RecordCap",
                        Infobar: Infobar);
                    Infobar = UndefineProcessVariable.Infobar;

                    #endregion ExecuteMethodCall

                }

            }
            if (sQLUtil.SQLGreaterThanOrEqual(InitialCount, RecordCap) == true)
            {
                var CustAging6LoadResponse = this.iHome_CustomerAnalysisCRUD.SelectCustaging2(InitialCount);
                Data = CustAging6LoadResponse;

                var subqLoadResponse = this.iHome_CustomerAnalysisCRUD.SelectSubq(InitialCount);

                LastSite = subqLoadResponse.LastSite;
                LastCustNum = subqLoadResponse.LastCustNum;

                string BookmarkString = stringUtil.Concat("'", this.iGetStringValue.GetStringValueFn(LastSite), "'", stringUtil.NChar(1), "'", this.iGetStringValue.GetStringValueFn(LastCustNum), "'");

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: DefineProcessVariableSp
               this.iDefineProcessVariable.DefineProcessVariableSp(
                    VariableName: "Bookmark",
                    VariableValue: BookmarkString,
                    Infobar: null);

                #endregion ExecuteMethodCall

            }
            this.sQLExpressionExecutor.Execute("DROP TABLE #CustAging");
            this.sQLExpressionExecutor.Execute("DROP TABLE #CustAging2");
            //this.sQLExpressionExecutor.Execute("DROP TABLE #Sites");
            return (Data, Severity, Infobar);
        }
    }
}