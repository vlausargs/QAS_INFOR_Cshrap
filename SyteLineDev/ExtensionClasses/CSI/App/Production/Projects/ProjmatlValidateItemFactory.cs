//PROJECT NAME: Production
//CLASS NAME: ProjmatlValidateItemFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using System.Linq;
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.DataCollection;

namespace CSI.Production.Projects
{
	public class ProjmatlValidateItemFactory
	{
		public const string IDO = "SLProjMatls";
		public const string Method = "ProjmatlValidateItem";
		
		public IProjmatlValidateItem Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iPmatlSumMaterial = new PmatlSumMaterialFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iShipLocDefault = new ShipLocDefaultFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iUomConvAmt = new UomConvAmtFactory().Create(cSIExtensionClassBase);
			var iUomConvQty = new UomConvQtyFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var stringUtil = new StringUtil();
			var iObsSlow = new ObsSlowFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iGetumcf = new GetumcfFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);
			var iMsgAsk = cSIExtensionClassBase.MongooseDependencies.MsgAsk;
			var iMinQty = new MinQtyFactory().Create(cSIExtensionClassBase);
			var iMaxQty = new MaxQtyFactory().Create(cSIExtensionClassBase);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iProjmatlValidateItemCRUD = new ProjmatlValidateItemCRUD(appDB, collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);
			
			IProjmatlValidateItem _ProjmatlValidateItem = new ProjmatlValidateItem(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iPmatlSumMaterial,
				iShipLocDefault,
				scalarFunction,
				convertToUtil,
				variableUtil,
				iUomConvAmt,
				iUomConvQty,
				stringUtil,
				iObsSlow,
				iGetumcf,
				sQLUtil,
				iMsgApp,
				iMsgAsk,
				iMinQty,
				iMaxQty,
				iProjmatlValidateItemCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_ProjmatlValidateItem = IDOMethodIntercept<IProjmatlValidateItem>.Create(_ProjmatlValidateItem, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjmatlValidateItemExt = timerfactory.Create<IProjmatlValidateItem>(_ProjmatlValidateItem);
			
			return iProjmatlValidateItemExt;
		}
	}
}
