//PROJECT NAME: Material
//CLASS NAME: CLM_TransactionDetailMatTranFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Material
{
	public class CLM_TransactionDetailMatTranFactory
	{
		public const string IDO = "SLMatltranAlls";
		public const string Method = "CLM_TransactionDetailMatTran";

		public ICLM_TransactionDetailMatTran Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMtCode = new MtCodeFactory().Create(cSIExtensionClassBase, calledFromIDO);

			ICLM_TransactionDetailMatTran _CLM_TransactionDetailMatTran = new CLM_TransactionDetailMatTran(appDB,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				existsChecker,
				convertToUtil,
				variableUtil,
				stringUtil,
				sQLUtil,
				iMtCode);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_TransactionDetailMatTran = IDOMethodIntercept<ICLM_TransactionDetailMatTran>.Create(_CLM_TransactionDetailMatTran, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_TransactionDetailMatTranExt = timerfactory.Create<ICLM_TransactionDetailMatTran>(_CLM_TransactionDetailMatTran);

			return iCLM_TransactionDetailMatTranExt;
		}
	}
}
