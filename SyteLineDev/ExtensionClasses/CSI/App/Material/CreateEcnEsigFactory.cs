//PROJECT NAME: Material
//CLASS NAME: CreateEcnEsigFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Material
{
	public class CreateEcnEsigFactory
	{
		public const string IDO = "SLEcns";
		public const string Method = "CreateEcnEsig";

		public ICreateEcnEsig Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var iInterpretText = cSIExtensionClassBase.MongooseDependencies.InterpretText;
			var stringUtil = new StringUtil();
			var iGetLabel = cSIExtensionClassBase.MongooseDependencies.GetLabel;
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iCreateEcnEsigCRUD = new CreateEcnEsigCRUD(appDB, collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				variableUtil,
				stringUtil);

			ICreateEcnEsig _CreateEcnEsig = new CreateEcnEsig(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				iInterpretText,
				stringUtil,
				iGetLabel,
				sQLUtil,
				iCreateEcnEsigCRUD);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CreateEcnEsig = IDOMethodIntercept<ICreateEcnEsig>.Create(_CreateEcnEsig, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateEcnEsigExt = timerfactory.Create<ICreateEcnEsig>(_CreateEcnEsig);

			return iCreateEcnEsigExt;
		}
	}
}
