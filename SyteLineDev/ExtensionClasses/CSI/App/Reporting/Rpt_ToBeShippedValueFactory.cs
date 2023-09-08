//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ToBeShippedValueFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.Logistics.Vendor;
using CSI.DataCollection;
using CSI.Data.Cache;
using System.Collections.Generic;
using CSI.Logger;

namespace CSI.Reporting
{
    public class Rpt_ToBeShippedValueFactory
    {
        public const string IDO = "SLToBeShippedValueReport";
        public const string Method = "Rpt_ToBeShippedValue";

        public IRpt_ToBeShippedValue Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iAddProcessErrorLog = cSIExtensionClassBase.MongooseDependencies.AddProcessErrorLog;
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
            var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var highCharacter = cSIExtensionClassBase.MongooseDependencies.HighCharacter;
            var lowCharacter = cSIExtensionClassBase.MongooseDependencies.LowCharacter;
            var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
            var iUomConvAmt = new UomConvAmtFactory().Create(cSIExtensionClassBase);
            var iUomConvQty = new UomConvQtyFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var stringUtil = new StringUtil();
            var iGetLabelCache = cSIExtensionClassBase.MongooseDependencies.GetLabelCache;
            var iCurrCnvtCache = new CurrCnvtCacheFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iChkcredCache = new ChkcredCacheFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iGetumcf = new GetumcfCacheFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var mathUtil = new MathUtilFactory().Create();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionNonTriggerInsertRequestFactory = new CollectionNonTriggerInsertRequestFactory(queryLanguage);
            var collectionNonTriggerDeleteRequestFactory = new CollectionNonTriggerDeleteRequestFactory(queryLanguage);

            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var defineVariable = cSIExtensionClassBase.MongooseDependencies.DefineVariable;
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);

            var recordStreamFactory = new RecordStreamFactory();
            var bookmarkFactory = new BookmarkFactory();
            var sortOrderFactory = new SortOrderFactory();

            var iRpt_ToBeShippedValueCRUD = new Rpt_ToBeShippedValueCRUD(appDB, collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionNonTriggerInsertRequestFactory,
                collectionNonTriggerDeleteRequestFactory,
                sQLExpressionExecutor,
                transactionFactory,
                iGetIsolationLevel,
                existsChecker,
                sQLUtil,
                recordStreamFactory,
                sortOrderFactory,
                bookmarkFactory,
                queryLanguage,
                mgSessionVariableBasedCache);

            IRpt_ToBeShippedValue _Rpt_ToBeShippedValue = new Rpt_ToBeShippedValue(
                bunchedLoadCollection,
                iAddProcessErrorLog,
                iGetWinRegDecGroup,
                iFixMaskForCrystal,
                iApplyDateOffset,
                iExpandKyByType,
                scalarFunction,
                convertToUtil,
                highCharacter,
                lowCharacter,
                iGetSiteDate,
                iUomConvAmt,
                iUomConvQty,
                stringUtil,
                iGetLabelCache,
                iCurrCnvtCache,
                iChkcredCache,
                iGetumcf,
                mathUtil,
                sQLUtil,
                iMsgApp,
                defineProcessVariable,
                defineVariable,
                getVariable,
                CachePageSize.XLarge,
                iRpt_ToBeShippedValueCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_ToBeShippedValue = IDOMethodIntercept<IRpt_ToBeShippedValue>.Create(_Rpt_ToBeShippedValue, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_ToBeShippedValueExt = timerfactory.Create<IRpt_ToBeShippedValue>(_Rpt_ToBeShippedValue);

            return iRpt_ToBeShippedValueExt;
        }
    }
}
