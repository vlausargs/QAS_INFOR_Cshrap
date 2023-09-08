//PROJECT NAME: Logistics
//CLASS NAME: Home_VchPayFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Cache;
using CSI.Material;
using CSI.Logistics.Vendor;
using CSI.DataCollection;
using CSI.Reporting;
using System.Collections.Generic;
using System;
using CSI.MG.MGCore;

namespace CSI.Logistics.Customer
{
    [Obsolete("Please use CompositionRoot to create instance. Obsolete since 9/15/2021. Remove at 12/15/2021.")]
    public class Home_VchPayFactory
    {
        public const string IDO = "SLControllerAlls";
        public const string Method = "Home_VchPay";

        public IHome_VchPay Create(
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
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var recordCollectionToDataTable = new RecordCollectionToDataTable();
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, true);
            var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, true);
            var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, true);
            var iUomConvQty = new UomConvQtyFactory().Create(cSIExtensionClassBase, true);

            var iCurrCnvt = new CurrCnvtFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iGetumcf = new GetumcfFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var mathUtil = new MathUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);
            string orderBy = "PoBuilderPoOrigSite, PoBuilderPoNum, PoNum, PoLine, PoRelease, RType, LCTypeOrder";
            var subUnionUtil = new UnionUtil(UnionType.UnionAll, orderBy);
            var mainUnionUtil = new UnionUtil(UnionType.UnionAll, "SiteRef, VendNum, PoNum");
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var bookmarkFactory = new BookmarkFactory();

            var sortDic = new Dictionary<string, SortOrderDirection>();
            sortDic.Add("po_all.site_ref", SortOrderDirection.Ascending);
            sortDic.Add("po_all.vend_num", SortOrderDirection.Ascending);
            sortDic.Add("po_all.po_num", SortOrderDirection.Ascending);
            var poSortOrder = new SortOrder(sortDic);

            ISortOrderFactory sortOrderFactory = new SortOrderFactory();

            Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
            dicSortOrder.Add("po_all.builder_po_orig_site", SortOrderDirection.Ascending);
            dicSortOrder.Add("po_all.builder_po_num", SortOrderDirection.Ascending);
            dicSortOrder.Add("poitem_all.po_num", SortOrderDirection.Ascending);
            dicSortOrder.Add("poitem_all.po_line", SortOrderDirection.Ascending);
            dicSortOrder.Add("poitem_all.po_release", SortOrderDirection.Ascending);
            dicSortOrder.Add("po_vch_all.rcvd_date", SortOrderDirection.Ascending);
            dicSortOrder.Add("po_vch_all.date_seq", SortOrderDirection.Ascending);
            var poVchSortOrder = new SortOrder(dicSortOrder);
            var recordStreamFactory = new RecordStreamFactory();

            var collectionNonTriggerInsertRequestFactory = new CollectionNonTriggerInsertRequestFactory(queryLanguage);
            var collectionNonTriggerDeleteRequestFactory = new CollectionNonTriggerDeleteRequestFactory(queryLanguage);
            var sessionBasedCache = new MGSessionVariableBasedCache(new BookmarkSerializer(),
                new UndefineVariable(appDB),
                new DefineVariable(appDB),
                new GetVariable(appDB));

            var rpt_VouchersPayableSub = new Rpt_VouchersPayableSub(appDB,
                bunchedLoadCollection,
                collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                sQLExpressionExecutor,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                stringUtil,
                sQLUtil,
                iExpandKyByType,
                mathUtil,
                iCurrCnvt,
                iGetumcf,
                iUomConvQty,
                iGetWinRegDecGroup,
                iFixMaskForCrystal,
                iMsgApp,
                subUnionUtil,
                recordStreamFactory,
                //poVchSortOrder,
                sortOrderFactory,
                queryLanguage,
                mgSessionVariableBasedCache,
                cSIExtensionClassBase.MongooseDependencies.LowCharacter,
                cSIExtensionClassBase.MongooseDependencies.HighCharacter,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString,
                collectionNonTriggerDeleteRequestFactory,
                collectionNonTriggerInsertRequestFactory,
                null,
                sessionBasedCache);

            IHome_VchPay _Home_VchPay = new Home_VchPay(appDB,
                bunchedLoadCollection,
                collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                recordCollectionToDataTable,
                sQLExpressionExecutor,
                transactionFactory,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                stringUtil,
                iDayEndOf,
                sQLUtil,
                //subUnionUtil,
                mainUnionUtil,
                defineProcessVariable,
                rpt_VouchersPayableSub,
                mgSessionVariableBasedCache,
                bookmarkFactory,
                queryLanguage,
                getVariable,
                sortOrderFactory,
                null);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Home_VchPay = IDOMethodIntercept<IHome_VchPay>.Create(_Home_VchPay, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHome_VchPayExt = timerfactory.Create<IHome_VchPay>(_Home_VchPay);

            return iHome_VchPayExt;
        }
    }
}