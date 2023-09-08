//PROJECT NAME: Production
//CLASS NAME: CLM_InvMsNomFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Production.Projects
{
	public class CLM_InvMsNomFactory
	{
		public const string IDO = "SLInvMs";
		public const string Method = "CLM_InvMsNom";

		public ICLM_InvMsNom Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
			var iProjInvMsLoadTot = new ProjInvMsLoadTotFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iProjGetMsPeriod = new ProjGetMsPeriodFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var stringUtil = new StringUtil();
			var raiseError = new RaiseErrorFactory().Create(appDB);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iCLM_InvMsNomCRUD = new CLM_InvMsNomCRUD(appDB, collectionLoadStatementRequestFactory, collectionLoadBuilderRequestFactory, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionUpdateRequestFactory, collectionLoadRequestFactory, collectionLoadResponseUtil, existsChecker, variableUtil, stringUtil);
			ICLM_InvMsNom _CLM_InvMsNom = new CLM_InvMsNom(bunchedLoadCollection,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iExecuteDynamicSQL,
				iProjInvMsLoadTot,
				iProjGetMsPeriod,
				scalarFunction,
				convertToUtil,
				dateTimeUtil,
				stringUtil,
				raiseError,
				sQLUtil,
				iCLM_InvMsNomCRUD);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_InvMsNom = IDOMethodIntercept<ICLM_InvMsNom>.Create(_CLM_InvMsNom, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_InvMsNomExt = timerfactory.Create<ICLM_InvMsNom>(_CLM_InvMsNom);

			return iCLM_InvMsNomExt;
		}
	}
}
