//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobOperationListingFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Config;
using CSI.Material;
using CSI.Production;
using CSI.Adapters;
using CSI.Data.Cache;
using System.Collections.Generic;

namespace CSI.Reporting
{
    public class Rpt_JobOperationListingFactory
    {
        public const string IDO = "SLJobOperationListingReport";
        public const string Method = "Rpt_JobOperationListing";

        public IRpt_JobOperationListing Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iCfgGetConfigValues = new CfgGetConfigValuesFactory().Create(cSIExtensionClassBase);
            var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iReportNotesExist = new ReportNotesExistFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);
            var variableUtil = new VariableUtilFactory().Create();
            var iHighAnyInt = new HighAnyIntFactory().Create(cSIExtensionClassBase);
            var iRefSetDesc = new RefSetDescFactory().Create(cSIExtensionClassBase);
            var stringUtil = new StringUtil();
            var iLowAnyInt = new LowAnyIntFactory().Create(cSIExtensionClassBase);
            var iStringOf = cSIExtensionClassBase.MongooseDependencies.StringOf;
            var iGetCode = new GetCodeFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);
            var iRefFmt = new RefFmtFactory().Create(cSIExtensionClassBase);
            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;

            string orderBy = "job_prefix, job_suffix, is_routing, oper_num, sequence, cfg_comp_comp_name";
            var unionUtil = new UnionUtil(UnionType.UnionAll, orderBy);
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);

            var recordStreamFactory = new RecordStreamFactory();
            Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
            dicSortOrder.Add("job.job", SortOrderDirection.Ascending);
            dicSortOrder.Add("job.suffix", SortOrderDirection.Ascending);
            dicSortOrder.Add("jobroute.oper_num", SortOrderDirection.Ascending);
            dicSortOrder.Add("wc.wc", SortOrderDirection.Ascending);
            dicSortOrder.Add("jobmatl.item", SortOrderDirection.Ascending);
            dicSortOrder.Add("jobmatl.sequence", SortOrderDirection.Ascending);
            var jobOperSortOrder = new SortOrder(dicSortOrder);

            IRpt_JobOperationListing _Rpt_JobOperationListing = new Rpt_JobOperationListing(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionLoadBuilderRequestFactory,
                dataTableToCollectionLoadResponse,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iCfgGetConfigValues,
                iGetIsolationLevel,
                transactionFactory,
                iGetWinRegDecGroup,
                iFixMaskForCrystal,
                iReportNotesExist,
                iApplyDateOffset,
                iExpandKyByType,
                scalarFunction,
                existsChecker,
                convertToUtil,
                dataTableUtil,
                variableUtil,
                iHighAnyInt,
                iRefSetDesc,
                stringUtil,
                iLowAnyInt,
                iStringOf,
                iGetCode,
                sQLUtil,
                iMsgApp,
                iRefFmt,
                defineProcessVariable,
                getVariable,
                unionUtil,
                recordStreamFactory,
                jobOperSortOrder,
                queryLanguage,
                mgSessionVariableBasedCache,
                CachePageSize.Large,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_JobOperationListing = IDOMethodIntercept<IRpt_JobOperationListing>.Create(_Rpt_JobOperationListing, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_JobOperationListingExt = timerfactory.Create<IRpt_JobOperationListing>(_Rpt_JobOperationListing);

            return iRpt_JobOperationListingExt;
        }
    }
}
