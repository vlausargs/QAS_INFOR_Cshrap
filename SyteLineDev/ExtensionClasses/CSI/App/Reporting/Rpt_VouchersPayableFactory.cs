//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VouchersPayableFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Cache;
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.Logistics.Vendor;
using CSI.DataCollection;
using System.Collections.Generic;
using CSI.Logger;
using CSI.CRUD.Reporting;
using System;
using CSI.MG.MGCore;

namespace CSI.Reporting
{
    [Obsolete("Please use CompositionRoot to create instance. Obsolete since 9/15/2021. Remove at 12/15/2021.")]
    public class Rpt_VouchersPayableFactory
	{
		public const string IDO = "SLVouchersPayableReport";
		public const string Method = "Rpt_VouchersPayable";
		
		public IRpt_VouchersPayable Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iCloseSessionContext = cSIExtensionClassBase.MongooseDependencies.CloseSessionContext;
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
			var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, true);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, true);
            var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, true);
            var iUomConvQty = new UomConvQtyFactory().Create(cSIExtensionClassBase, true);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var iCurrCnvt = new CurrCnvtFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iGetumcf = new GetumcfFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var mathUtil = new MathUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);
            string orderBy = "PoBuilderPoOrigSite, PoBuilderPoNum, PoNum, PoLine, PoRelease, RType, LCTypeOrder";
            var unionUtil = new UnionUtil(UnionType.UnionAll, orderBy);
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);

            var collectionNonTriggerInsertRequestFactory = new CollectionNonTriggerInsertRequestFactory(queryLanguage);
            var collectionNonTriggerDeleteRequestFactory = new CollectionNonTriggerDeleteRequestFactory(queryLanguage);
            ISortOrderFactory sortOrderFactory = new SortOrderFactory();
            var rpt_VouchersPayableCRUD = new Rpt_VouchersPayableCRUD(appDB, collectionLoadRequestFactory);

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

            int recordCap = bunchedLoadCollection.RecordCap;
            if (recordCap == -1)
            {
                recordCap = 5000;
            }
            else if (recordCap == 0)
            {
                recordCap = int.MaxValue;
            }

            var Rpt_VouchersPayableSubCRUD = new Rpt_VouchersPayableSubCRUD(collectionLoadRequestFactory);
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
                unionUtil,
                recordStreamFactory,
                sortOrderFactory,
                queryLanguage,
                mgSessionVariableBasedCache,
                cSIExtensionClassBase.MongooseDependencies.LowCharacter,
                cSIExtensionClassBase.MongooseDependencies.HighCharacter,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString,
                collectionNonTriggerDeleteRequestFactory,
                collectionNonTriggerInsertRequestFactory,
                Rpt_VouchersPayableSubCRUD,
                sessionBasedCache
                );

            IRpt_VouchersPayable _Rpt_VouchersPayable = new Rpt_VouchersPayable(appDB,
                bunchedLoadCollection,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iCloseSessionContext,
                transactionFactory,
                iGetIsolationLevel,
                iApplyDateOffset,
                iExpandKyByType,
                scalarFunction,
                existsChecker,
                stringUtil,
                sQLUtil,
                defineProcessVariable,
                getVariable,
                rpt_VouchersPayableSub,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString,
                mathUtil,
                rpt_VouchersPayableCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_VouchersPayable = IDOMethodIntercept<IRpt_VouchersPayable>.Create(_Rpt_VouchersPayable, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VouchersPayableExt = timerfactory.Create<IRpt_VouchersPayable>(_Rpt_VouchersPayable);
			
			return iRpt_VouchersPayableExt;
		}
	}
}