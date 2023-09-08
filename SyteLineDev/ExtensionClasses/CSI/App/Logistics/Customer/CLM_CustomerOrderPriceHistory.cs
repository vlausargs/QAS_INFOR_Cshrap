//PROJECT NAME: Logistics
//CLASS NAME: CLM_CustomerOrderPriceHistory.cs

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

namespace CSI.Logistics.Customer
{
    public class CLM_CustomerOrderPriceHistory : ICLM_CustomerOrderPriceHistory
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public CLM_CustomerOrderPriceHistory(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
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
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_CustomerOrderPriceHistorySp(
            string CustNum,
            string Item,
            string FilterString,
            string PSiteGroup = null)
        {
            FilterString = String.IsNullOrEmpty(FilterString) ? "<FilterString />" : FilterString;
            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {

                ICollectionLoadResponse Data = null;

                StringType _ALTGEN_SpName = DBNull.Value;
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                int? Severity = null;
                SiteType _Site = DBNull.Value;
                string Site = null;
                string Infobar = null;
                string SelectionClause = null;
                string FromClause = null;
                string WhereClause = null;
                string AdditionalClause = null;
                string KeyColumns = null;
                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_CustomerOrderPriceHistorySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
                )
                {
                    //BEGIN
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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_CustomerOrderPriceHistorySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_CustomerOrderPriceHistorySp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
                        var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
                        if (tv_ALTGEN1LoadResponse.Items.Count > 0)
                        {
                            ALTGEN_SpName = _ALTGEN_SpName;
                        }
                        #endregion  LoadToVariable

                        var ALTGEN = AltExtGen_CLM_CustomerOrderPriceHistorySp(ALTGEN_SpName,
                            CustNum,
                            Item,
                            FilterString,
                            PSiteGroup);
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
                        //END

                    }
                    //END

                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_CustomerOrderPriceHistorySp") != null)
                {
                    var EXTGEN = AltExtGen_CLM_CustomerOrderPriceHistorySp("dbo.EXTGEN_CLM_CustomerOrderPriceHistorySp",
                        CustNum,
                        Item,
                        FilterString,
                        PSiteGroup);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#tempOutput") == null)
                {

                    this.sQLExpressionExecutor.Execute(@"Declare
						@CoNum CoNumType
						,@CoLine CoLineType
						,@CoRelease CoReleaseType
						,@CoOrderDate DateType
						,@QtyOrderedConv QtyUnitNoNegType
						,@UM UMType
						,@PriceConv CostPrcType
						,@DerNetPrice AmountType
						,@AdrCurrCode CurrCodeType
						,@CustNum CustNumType
						,@Item ItemType
						,@AmtFormat InputMaskType
						,@CstPrcFormat InputMaskType
						,@SiteRef SiteType
						SELECT @CoNum AS CoNum,
						       @CoLine AS CoLine,
						       @CoRelease AS CoRelease,
						       @CoOrderDate AS CoOrderDate,
						       @QtyOrderedConv AS QtyOrderedConv,
						       @UM AS UM,
						       @PriceConv AS PriceConv,
						       @DerNetPrice AS DerNetPrice,
						       @AdrCurrCode AS AdrCurrCode,
						       @CustNum AS CustNum,
						       @Item AS Item,
						       @AmtFormat AS AmtFormat,
						       @CstPrcFormat AS CstPrcFormat,
						       @SiteRef AS SiteRef
						INTO   #tempOutput
						WHERE  1 = 2");

                }

                #region CRUD LoadToVariable
                var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_Site,"site"},
                    },
                    loadForChange: false,
                    lockingType: LockingType.None,
                    maximumRows: 1,
                    tableName: "parms",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
                if (parmsLoadResponse.Items.Count > 0)
                {
                    Site = _Site;
                }
                #endregion  LoadToVariable

                #region CRUD LoadToRecord
                var tempOutput1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"CoNum","coph.CoNum"},
                        {"CoLine","coph.CoLine"},
                        {"CoRelease","coph.CoRelease"},
                        {"CoOrderDate","coph.CoOrderDate"},
                        {"QtyOrderedConv","coph.QtyOrderedConv"},
                        {"UM","coph.UM"},
                        {"PriceConv","coph.PriceConv"},
                        {"DerNetPrice","coph.DerNetPrice"},
                        {"AdrCurrCode","coph.AdrCurrCode"},
                        {"CustNum","coph.CustNum"},
                        {"Item","coph.Item"},
                        {"AmtFormat","coph.AmtFormat"},
                        {"CstPrcFormat","coph.CstPrcFormat"},
                        {"SiteRef","coph.SiteRef"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "CustomerOrderPriceHistoryView",
                    fromClause: collectionLoadRequestFactory.Clause(" AS coph"),
                    whereClause: collectionLoadRequestFactory.Clause("coph.CustNum = ISNULL({1}, coph.CustNum) AND coph.Item = {2} AND (SiteRef IN (SELECT site FROM site_group WHERE site_group.site_group = {0}) OR SiteRef = {3})", PSiteGroup, CustNum, Item, Site),
                    orderByClause: collectionLoadRequestFactory.Clause(" CoOrderDate DESC"));
                var tempOutput1LoadResponse = this.appDB.Load(tempOutput1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                var tempOutput1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tempOutput",
                    items: tempOutput1LoadResponse.Items);

                this.appDB.Insert(tempOutput1InsertRequest);
                #endregion InsertByRecords

                SelectionClause = "";
                FromClause = "";
                WhereClause = "";
                AdditionalClause = "";
                KeyColumns = "";
                SelectionClause = @"SELECT
					       CoNum
					     , CoLine
					     , CoRelease
					     , CoOrderDate
					     , QtyOrderedConv
					     , UM
					     , PriceConv
					     , DerNetPrice
					     , AdrCurrCode
					     , CustNum
					     , Item
					     , AmtFormat
					     , CstPrcFormat
					     , SiteRef";
                FromClause = "FROM #tempOutput";
                WhereClause = "WHERE 1=1";
                AdditionalClause = "ORDER BY SiteRef, CoNum, CoLine, CoRelease";
                KeyColumns = "SiteRef, CoNum, CoLine, CoRelease";
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#DynamicParameters") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters");

                }

                this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause VeryLongListType
					,@FromClause VeryLongListType
					,@WhereClause VeryLongListType
					,@AdditionalClause VeryLongListType
					,@KeyColumns VeryLongListType
					,@FilterString LongListType
					SELECT @SelectionClause AS SelectionClause,
					       @FromClause AS FromClause,
					       @WhereClause AS WhereClause,
					       @AdditionalClause AS AdditionalClause,
					       @KeyColumns AS KeyColumns,
					       @FilterString AS FilterString
					INTO   #DynamicParameters
					WHERE 1 = 2");

                #region CRUD LoadArbitrary
                var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"SelectionClause",$"{variableUtil.GetQuotedValue<string>(SelectionClause)}"},
                        {"FromClause",$"{variableUtil.GetQuotedValue<string>(FromClause)}"},
                        {"WhereClause",$"{variableUtil.GetQuotedValue<string>(WhereClause)}"},
                        {"AdditionalClause",$"{variableUtil.GetQuotedValue<string>(AdditionalClause)}"},
                        {"KeyColumns",$"{variableUtil.GetQuotedValue<string>(KeyColumns)}"},
                        {"FilterString",$"{variableUtil.GetQuotedValue<string>(FilterString)}"},
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
                var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
                    NeedGetMoreRows: 1,
                    Infobar: Infobar);
                Severity = ExecuteDynamicSQL.ReturnCode;
                Data = ExecuteDynamicSQL.Data;
                Infobar = ExecuteDynamicSQL.Infobar;

                #endregion ExecuteMethodCall

                return (Data, Severity = 0);

            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }
        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_CLM_CustomerOrderPriceHistorySp(
            string AltExtGenSp,
            string CustNum,
            string Item,
            string FilterString,
            string PSiteGroup = null)
        {
            CustNumType _CustNum = CustNum;
            ItemType _Item = Item;
            LongListType _FilterString = FilterString;
            SiteGroupType _PSiteGroup = PSiteGroup;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSiteGroup", _PSiteGroup, ParameterDirection.Input);

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
