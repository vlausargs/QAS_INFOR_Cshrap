//PROJECT NAME: Logistics
//CLASS NAME: Home_CustomerAnalysisCRUD.cs

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
using System.Linq;

namespace CSI.CRUD.Logistics.Customer
{
    public class Home_CustomerAnalysisCRUD : IHome_CustomerAnalysisCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly IDefaultToLocalSite iDefaultToLocalSite;
        readonly IQuotedLiteral iQuotedLiteral;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;

        readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
        readonly ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory;
        readonly ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory;

        public Home_CustomerAnalysisCRUD(IApplicationDB appDB,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            IDefaultToLocalSite iDefaultToLocalSite,
            IQuotedLiteral iQuotedLiteral,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,

            ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
            ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory,
            ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory)
        {
            this.appDB = appDB;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.iDefaultToLocalSite = iDefaultToLocalSite;
            this.iQuotedLiteral = iQuotedLiteral;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;

            this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
            this.collectionNonTriggerUpdateRequestFactory = collectionNonTriggerUpdateRequestFactory;
            this.collectionNonTriggerDeleteRequestFactory = collectionNonTriggerDeleteRequestFactory;
        }

        public bool Optional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_CustomerAnalysisSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
        }

        public ICollectionLoadResponse SelectOptional_Module()
        {
            var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SpName","CAST (NULL AS NVARCHAR)"},
                    {"u0","[om].[ModuleName]"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_CustomerAnalysisSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_CustomerAnalysisSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
            };

            return optional_module1LoadResponse;
        }

        public void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse)
        {
            var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                items: optional_module1LoadResponse.Items);

            this.appDB.Insert(optional_module1InsertRequest);
        }

        public bool Tv_ALTGENForExists()
        {
            return existsChecker.Exists(tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""));
        }

        public (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName)
        {
            StringType _ALTGEN_SpName = DBNull.Value;

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

            int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
            return (ALTGEN_SpName, rowCount);
        }

        public ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName)
        {
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
            return this.appDB.Load(tv_ALTGEN2LoadRequest);
        }

        public void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
        {
            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                items: tv_ALTGEN2LoadResponse.Items);
            this.appDB.Delete(tv_ALTGEN2DeleteRequest);
        }

        public ICollectionLoadResponse SelectSiteRef(string SiteGroup)
        {
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "site_ref", this.iDefaultToLocalSite.DefaultToLocalSiteFn(SiteGroup)},
            });

            return this.appDB.Load(nonTableLoadRequest);
        }

        public ICollectionLoadResponse SelectSites(string SiteGroup)
        {
            var Sites1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"site_ref","SITE"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "site_group",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("site_group = {0}", SiteGroup),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(Sites1LoadRequest);
        }

        public ICollectionLoadResponse SelectProperties(string FilterString)
        {
            var PropertiesCrsLoadStatementRequestForCursor = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"Property","Property"},
                    {"Operator","Operator"},
                    {"Value","Value"},
                    {"DataType","DataType"},
                    {"DataLength","DataLength"},
                },
                selectStatement: collectionLoadRequestFactory.Clause(@";WITH xmlcontent
					AS (SELECT CAST (CONVERT (VARBINARY (MAX), {0} ) AS XML) AS filterstring),
					properties
					AS (SELECT DISTINCT c1.value('(./Property)[1]', 'nvarchar(500)') AS Property,
						c1.value('(./Operator)[1]', 'nvarchar(20)') AS Operator,
						c1.value('(./Value)[1]', 'nvarchar(MAX)') AS Value,
						c1.value('(./DataType)[1]', 'nvarchar(MAX)') AS DataType,
						c1.value('(./DataLength)[1]', 'nvarchar(MAX)') AS DataLength
						FROM   xmlcontent AS t2 CROSS APPLY t2.filterstring.nodes('//*:Item') AS t1(c1))
					SELECT @selectList
					FROM properties", FilterString));

            var PropertiesCrsLoadResponseForCursor = this.appDB.Load(PropertiesCrsLoadStatementRequestForCursor);
            return PropertiesCrsLoadResponseForCursor;
        }
        public ICollectionLoadResponse SelectDynamicparameters(string SelectionClause, string FromClause, string WhereClause, string AdditionalClause, string KeyColumns, string FilterCust)
        {
            var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SelectionClause",$"{variableUtil.GetQuotedValue<string>(SelectionClause)}"},
                    {"FromClause",$"{variableUtil.GetQuotedValue<string>(FromClause)}"},
                    {"WhereClause",$"{variableUtil.GetQuotedValue<string>(WhereClause)}"},
                    {"AdditionalClause",$"{variableUtil.GetQuotedValue<string>(AdditionalClause)}"},
                    {"KeyColumns",$"{variableUtil.GetQuotedValue<string>(KeyColumns)}"},
                    {"FilterString",$"{variableUtil.GetQuotedValue<string>(FilterCust)}"},
                },
                selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));

            return this.appDB.Load(DynamicParametersLoadRequest);
        }

        public void InsertDynamicparameters(ICollectionLoadResponse DynamicParametersLoadResponse)
        {
            var DynamicParametersInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
                items: DynamicParametersLoadResponse.Items);

            this.appDB.Insert(DynamicParametersInsertRequest);
        }

        public void InsertCustagingWithNonTrigger(IList<string> SiteGroupVar, string filterStringForWhere, IList<object> parmList)
        {
            string SiteGroup = string.Join(", ", SiteGroupVar.Select(t => "'" + t + "'"));
            string whereClause = string.Format(" customer_all.cust_seq = 0 AND customer_all.show_in_drop_down_list = 1 AND customer_all.site_ref IN ({0})", SiteGroup);

            if (!string.IsNullOrEmpty(filterStringForWhere))
                whereClause += " AND " + filterStringForWhere;

            var CustAgingNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                    targetTableName: "#CustAging",
                    targetColumns: new List<string>()
                                 {
                                   "CustNum",
                                   "CustName",
                                   "CustCreditHold",
                                   "CustCreditLimit",
                                   "CustOrderCreditLimit",
                                   "CustAgeBal1",
                                   "CustAgeBal2",
                                   "CustAgeBal3",
                                   "CustAgeBal4",
                                   "CustAgeBal5",
                                   "CustAgeBalNet",
                                   "CustAvgBalOs",
                                   "CustCurrCode",
                                   "ToCurrCode",
                                   "SiteRef",
                                   "Infobar",
                                   "IsProcessed"
                                 },
                    valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                    {
                      { "CustNum", collectionNonTriggerInsertRequestFactory.Clause("customer_all.cust_num") },
                      { "CustName", collectionNonTriggerInsertRequestFactory.Clause("custaddr.name") },
                      { "CustCreditHold", collectionNonTriggerInsertRequestFactory.Clause("custaddr.credit_hold") },
                      { "CustCreditLimit", collectionNonTriggerInsertRequestFactory.Clause("custaddr.credit_limit") },
                      { "CustOrderCreditLimit", collectionNonTriggerInsertRequestFactory.Clause("custaddr.order_credit_limit") },
                      { "CustAgeBal1", collectionNonTriggerInsertRequestFactory.Clause("{0}",0) },
                      { "CustAgeBal2", collectionNonTriggerInsertRequestFactory.Clause("{0}",0) },
                      { "CustAgeBal3", collectionNonTriggerInsertRequestFactory.Clause("{0}",0) },
                      { "CustAgeBal4", collectionNonTriggerInsertRequestFactory.Clause("{0}",0) },
                      { "CustAgeBal5", collectionNonTriggerInsertRequestFactory.Clause("{0}",0) },
                      { "CustAgeBalNet", collectionNonTriggerInsertRequestFactory.Clause("{0}",0) },
                      { "CustAvgBalOs", collectionNonTriggerInsertRequestFactory.Clause("customer_all.avg_bal_os") },
                      { "CustCurrCode", collectionNonTriggerInsertRequestFactory.Clause("custaddr.curr_code") },
                      { "ToCurrCode", collectionNonTriggerInsertRequestFactory.Clause("custaddr.curr_code") },
                      { "SiteRef", collectionNonTriggerInsertRequestFactory.Clause("customer_all.site_ref") },
                      { "Infobar", collectionNonTriggerInsertRequestFactory.Clause("{0}","Null") },
                      { "IsProcessed", collectionNonTriggerInsertRequestFactory.Clause("{0}",0) }
                    },

                    fromClause: collectionNonTriggerInsertRequestFactory.Clause("customer_all WITH (READUNCOMMITTED)" +
                    " INNER JOIN custaddr WITH(READUNCOMMITTED) ON custaddr.cust_num = customer_all.cust_num" +
                    " AND custaddr.cust_seq = customer_all.cust_seq "),
                    whereClause: collectionNonTriggerInsertRequestFactory.Clause(whereClause, parmList.ToArray()),
                    orderByClause: collectionNonTriggerInsertRequestFactory.Clause(" customer_all.site_ref, customer_all.cust_num"));

            this.appDB.InsertWithoutTrigger(CustAgingNonTriggerInsertRequest);
        }

        public (int? InitialCount, int? rowCount) LoadCustaging(int? InitialCount)
        {
            IntType _InitialCount = DBNull.Value;

            var CustAging21LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_InitialCount,"count(*)"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#CustAging",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var CustAging21LoadResponse = this.appDB.Load(CustAging21LoadRequest);
            if (CustAging21LoadResponse.Items.Count > 0)
            {
                InitialCount = _InitialCount;
            }

            int rowCount = CustAging21LoadResponse.Items.Count;
            return (InitialCount, rowCount);
        }

        public (string LastSite, string LastCustNum, int? rowCount) LoadCustaging2(string LastSite, string LastCustNum)
        {
            SiteType _LastSite = DBNull.Value;
            CustNumType _LastCustNum = DBNull.Value;

            var CustAging21LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_LastSite,"SiteRef"},
                    {_LastCustNum,"CustNum"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "#CustAging",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(" SiteRef DESC, CustNum DESC"));

            var CustAging21LoadResponse = this.appDB.Load(CustAging21LoadRequest);
            if (CustAging21LoadResponse.Items.Count > 0)
            {
                LastSite = _LastSite;
                LastCustNum = _LastCustNum;
            }

            int rowCount = CustAging21LoadResponse.Items.Count;
            return (LastSite, LastCustNum, rowCount);
        }

        public (int? NumCustomerBlocks, int? rowCount) LoadCustomer_All(int? NumCustomerBlocks, IList<string> SiteGroupVar)
        {
            IntType _NumCustomerBlocks = DBNull.Value;

            string SiteGroup = String.Join(", ", SiteGroupVar.Select(t => "'" + t + "'"));
            string whereClause = string.Format(" customer_all.site_ref IN ({0})", SiteGroup);

            var customer_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_NumCustomerBlocks,"COUNT(*)"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "customer_all",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(whereClause),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var customer_allLoadResponse = this.appDB.Load(customer_allLoadRequest);
            if (customer_allLoadResponse.Items.Count > 0)
            {
                NumCustomerBlocks = _NumCustomerBlocks;
            }

            int rowCount = customer_allLoadResponse.Items.Count;
            return (NumCustomerBlocks, rowCount);
        }

        public void UpdateDynamicparametersWithNonTrigger(string FilterAging)
        {
            var DynamicParametersNonTriggerUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
                        tableName: "#DynamicParameters",
                        expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
                        {
                        { "SelectionClause", collectionNonTriggerUpdateRequestFactory.Clause("'SELECT CustNum, CustName, CustCreditHold, CustCreditLimit, CustOrderCreditLimit, CustAgeBal1, CustAgeBal2, CustAgeBal3, CustAgeBal4, CustAgeBal5, CustAgeBalNet, CustAvgBalOs, CustCurrCode, SiteRef, Infobar'") },
                        { "FromClause", collectionNonTriggerUpdateRequestFactory.Clause("'FROM #CustAging'") },
                        { "WhereClause", collectionNonTriggerUpdateRequestFactory.Clause("'WHERE ISNULL(IsProcessed, 0) = 0'") },
                        { "AdditionalClause", collectionNonTriggerUpdateRequestFactory.Clause("'ORDER BY SiteRef, CustNum'") },
                        { "KeyColumns", collectionNonTriggerUpdateRequestFactory.Clause("'SiteRef, CustNum'") },
                        { "FilterString", collectionNonTriggerUpdateRequestFactory.Clause("{0}",FilterAging) },
                        },
                        fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
                        whereClause: collectionNonTriggerUpdateRequestFactory.Clause("")
                        );

            this.appDB.UpdateWithoutTrigger(DynamicParametersNonTriggerUpdateRequest);
        }

        public void InsertCustaging2(ICollectionLoadResponse CustAging21ExecResultLoadResponse)
        {
            var CustAging21LoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(CustAging21ExecResultLoadResponse,
                new List<string>() { "CustNum",
                        "CustName",
                        "CustCreditHold",
                        "CustCreditLimit",
                        "CustOrderCreditLimit",
                        "CustAgeBal1",
                        "CustAgeBal2",
                        "CustAgeBal3",
                        "CustAgeBal4",
                        "CustAgeBal5",
                        "CustAgeBalNet",
                        "CustAvgBalOs",
                        "CustCurrCode",
                        "SiteRef",
                        "Infobar" });
            var CustAging21InsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#CustAging2",
                items: CustAging21LoadResponse.Items);

            this.appDB.Insert(CustAging21InsertRequest);
        }

        public void DeleteCaWithNonTrigger()
        {
            var CustAgingNonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                 tableName: "#CustAging",
                 fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
                 whereClause: collectionNonTriggerDeleteRequestFactory.Clause("NOT EXISTS (SELECT 1 FROM #CustAging2 AS ca2 WHERE ca2.SiteRef = [#CustAging].SiteRef AND ca2.CustNum = [#CustAging].CustNum) AND IsProcessed = 0")
                 );
            this.appDB.DeleteWithoutTrigger(CustAgingNonTriggerDeleteRequest);
        }

        public (int? PostAgeCount, int? rowCount) LoadCustaging3(int? PostAgeCount)
        {
            IntType _PostAgeCount = DBNull.Value;

            var CustAging22LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_PostAgeCount,"COUNT(*)"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#CustAging",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("IsProcessed = 0"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var CustAging22LoadResponse = this.appDB.Load(CustAging22LoadRequest);
            if (CustAging22LoadResponse.Items.Count > 0)
            {
                PostAgeCount = _PostAgeCount;
            }

            int rowCount = CustAging22LoadResponse.Items.Count;
            return (PostAgeCount, rowCount);
        }

        public void UpdateCustagingWithNonTrigger()
        {
            var CustAgingNonTriggerUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(tableName: "#CustAging",
                         expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
                         {
                           { "IsProcessed", collectionNonTriggerUpdateRequestFactory.Clause("{0}",1) }
                         },
                         fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
                         whereClause: collectionNonTriggerUpdateRequestFactory.Clause(" IsProcessed = 0")
                         );

            this.appDB.UpdateWithoutTrigger(CustAgingNonTriggerUpdateRequest);
        }

        public void Dynamicparameters2UpdateWithNonTrigger(string LastSite, string LastCustNum, string FilterCust, IList<string> SiteGroupVar)
        {
            string SiteGroup = String.Join(", ", SiteGroupVar.Select(t => "'" + t + "'"));

            var DynamicParametersWhereNonTriggerUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "#DynamicParameters",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
                {
                    {"SelectionClause", collectionNonTriggerUpdateRequestFactory.Clause(@"' SELECT customer_all.cust_num, custaddr.name, custaddr.credit_hold, custaddr.credit_limit, custaddr.order_credit_limit, 0 AS CustAgeBal1, 0 AS CustAgeBal2, 0 AS CustAgeBal3, 0 AS CustAgeBal4, 0 AS CustAgeBal5, 0 AS CustAgeBalNet, customer_all.avg_bal_os, custaddr.curr_code as FromCurrCode, custaddr.curr_code as ToCurrCode, customer_all.site_ref, NULL AS Infobar, 0 AS IsProcessed'") },
                    {"FromClause", collectionNonTriggerUpdateRequestFactory.Clause(@"' FROM customer_all WITH (READUNCOMMITTED) INNER JOIN custaddr WITH (READUNCOMMITTED) ON custaddr.cust_num = customer_all.cust_num AND custaddr.cust_seq = customer_all.cust_seq'" )},
                    {"WhereClause",collectionNonTriggerUpdateRequestFactory.Clause(this.iQuotedLiteral.QuotedLiteralFn(stringUtil.Concat("WHERE customer_all.cust_seq = 0 AND customer_all.show_in_drop_down_list = 1", " AND (customer_all.site_ref = ", this.iQuotedLiteral.QuotedLiteralFn(LastSite), " AND customer_all.cust_num > ", this.iQuotedLiteral.QuotedLiteralFn(LastCustNum), " OR customer_all.site_ref > ", this.iQuotedLiteral.QuotedLiteralFn(LastSite), ")", $" AND customer_all.site_ref IN ({SiteGroup})"))) },
                    {"AdditionalClause",collectionNonTriggerUpdateRequestFactory.Clause(@"'ORDER BY customer_all.site_ref, customer_all.cust_num'") },
                    {"KeyColumns",collectionNonTriggerUpdateRequestFactory.Clause(@"'customer_all.site_ref, customer_all.cust_num'") },
                    {"FilterString", collectionNonTriggerUpdateRequestFactory.Clause(@"{0}",FilterCust) }
                },
                fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
                whereClause: collectionNonTriggerUpdateRequestFactory.Clause("")
                );

            this.appDB.UpdateWithoutTrigger(DynamicParametersWhereNonTriggerUpdateRequest);
        }

        public void InsertCustaging3(ICollectionLoadResponse CustAging4ExecResultLoadResponse)
        {
            var CustAging4LoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(CustAging4ExecResultLoadResponse,
                new List<string>() { "CustNum",
                        "CustName",
                        "CustCreditHold",
                        "CustCreditLimit",
                        "CustOrderCreditLimit",
                        "CustAgeBal1",
                        "CustAgeBal2",
                        "CustAgeBal3",
                        "CustAgeBal4",
                        "CustAgeBal5",
                        "CustAgeBalNet",
                        "CustAvgBalOs",
                        "CustCurrCode",
                        "ToCurrCode",
                        "SiteRef",
                        "Infobar",
                        "IsProcessed" });
            var CustAging4InsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#CustAging",
                items: CustAging4LoadResponse.Items);

            this.appDB.Insert(CustAging4InsertRequest);
        }

        public (string LastSite, string LastCustNum, int? rowCount) LoadCustaging4(string LastCustNum, string LastSite)
        {
            SiteType _LastSite = DBNull.Value;
            CustNumType _LastCustNum = DBNull.Value;

            var CustAging5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_LastSite,"SiteRef"},
                    {_LastCustNum,"CustNum"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "#CustAging",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("SiteRef = {1} AND CustNum > {0} OR SiteRef > {1}", LastCustNum, LastSite),
                orderByClause: collectionLoadRequestFactory.Clause(" SiteRef DESC, CustNum DESC"));

            var CustAging5LoadResponse = this.appDB.Load(CustAging5LoadRequest);
            if (CustAging5LoadResponse.Items.Count > 0)
            {
                LastSite = _LastSite;
                LastCustNum = _LastCustNum;
            }

            int rowCount = CustAging5LoadResponse.Items.Count;
            return (LastSite, LastCustNum, rowCount);
        }

        public ICollectionLoadResponse SelectCustaging2(int? InitialCount)
        {
            var CustAging6LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"CustNum","CustNum"},
                    {"CustName","CustName"},
                    {"CustCreditHold","CustCreditHold"},
                    {"CustCreditLimit","CustCreditLimit"},
                    {"CustOrderCreditLimit","CustOrderCreditLimit"},
                    {"CustAgeBal1","CustAgeBal1"},
                    {"CustAgeBal2","CustAgeBal2"},
                    {"CustAgeBal3","CustAgeBal3"},
                    {"CustAgeBal4","CustAgeBal4"},
                    {"CustAgeBal5","CustAgeBal5"},
                    {"CustAgeBalNet","CustAgeBalNet"},
                    {"CustAvgBalOs","CustAvgBalOs"},
                    {"CustCurrCode","CustCurrCode"},
                    {"SiteRef","SiteRef"},
                    {"Infobar","Infobar"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: InitialCount,
                tableName: "#CustAging",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(" SiteRef, CustNum"));
            return this.appDB.Load(CustAging6LoadRequest);
        }

        public (string LastSite, string LastCustNum) SelectSubq(int? InitialCount)
        {
            string LastSite = null;
            SiteType _LastSite = DBNull.Value;
            string LastCustNum = null;
            CustNumType _LastCustNum = DBNull.Value;

            var subqLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_LastSite,"SiteRef"},
                    {_LastCustNum,"CustNum"},
                },
                selectStatement: collectionLoadRequestFactory.Clause(@"SELECT TOP 1 @selectList
					FROM (SELECT   TOP ({0} - 1) CustNum,
						SiteRef
						FROM     #CustAging
						ORDER BY SiteRef ASC, CustNum ASC) AS subq
					ORDER BY SiteRef DESC, CustNum DESC", InitialCount));

            var subqLoadResponse = this.appDB.Load(subqLoadRequest);
            if (subqLoadResponse.Items.Count > 0)
            {
                LastSite = _LastSite;
                LastCustNum = _LastCustNum;
            }

            return (LastSite, LastCustNum);
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode,
            string Infobar)
        AltExtGen_Home_CustomerAnalysisSp(
            string AltExtGenSp,
            string FilterString = null,
            string SiteGroup = null,
            string Infobar = null)
        {
            LongListType _FilterString = FilterString;
            SiteGroupType _SiteGroup = SiteGroup;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
                var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;

                Infobar = _Infobar;

                return (resultSet, returnCode, Infobar);
            }
        }

    }
}