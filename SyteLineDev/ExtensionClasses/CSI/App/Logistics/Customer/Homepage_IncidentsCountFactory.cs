//PROJECT NAME: Logistics
//CLASS NAME: Homepage_IncidentsCountFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;

namespace CSI.Logistics.Customer
{
	public class Homepage_IncidentsCountFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_IncidentsCount";

		readonly IExpandKyByTypeFactory iExpandKyByTypeFactory;
		readonly IInterpretTextFactory iInterpretTextFactory;
		readonly IMidnightOfFactory iMidnightOfFactory;
		readonly IGetLabelFactory iGetLabelFactory;
		public Homepage_IncidentsCountFactory(IExpandKyByTypeFactory iExpandKyByTypeFactory, IInterpretTextFactory iInterpretTextFactory, IMidnightOfFactory iMidnightOfFactory, IGetLabelFactory iGetLabelFactory)
		{
			this.iExpandKyByTypeFactory = iExpandKyByTypeFactory;
			this.iInterpretTextFactory = iInterpretTextFactory;
			this.iMidnightOfFactory = iMidnightOfFactory;
			this.iGetLabelFactory = iGetLabelFactory;
		}
		public IHomepage_IncidentsCount Create(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iExpandKyByType = this.iExpandKyByTypeFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var iInterpretText = this.iInterpretTextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iMidnightOf = this.iMidnightOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var stringUtil = new StringUtil();
			var iGetLabel = this.iGetLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			
			IHomepage_IncidentsCount _Homepage_IncidentsCount = new Homepage_IncidentsCount(appDB,
				bunchedLoadCollection,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iExpandKyByType,
				scalarFunction,
				iInterpretText,
				existsChecker,
				convertToUtil,
				dateTimeUtil,
				variableUtil,
				iMidnightOf,
				stringUtil,
				iGetLabel,
				sQLUtil);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Homepage_IncidentsCount = IDOMethodIntercept<IHomepage_IncidentsCount>.Create(_Homepage_IncidentsCount, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_IncidentsCountExt = timerfactory.Create<IHomepage_IncidentsCount>(_Homepage_IncidentsCount);
			
			return iHomepage_IncidentsCountExt;
		}
	}
}
