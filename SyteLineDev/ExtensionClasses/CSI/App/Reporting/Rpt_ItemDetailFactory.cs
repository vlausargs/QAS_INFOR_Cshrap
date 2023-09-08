//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemDetailFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using System.Linq;
using CSI.MG.MGCore;
using CSI.Adapters;

namespace CSI.Reporting
{
	public class Rpt_ItemDetailFactory
	{
		public const string IDO = "SLItemDetailReport";
		public const string Method = "Rpt_ItemDetail";


		readonly ICloseSessionContextFactory iCloseSessionContextFactory;
		readonly IInitSessionContextFactory iInitSessionContextFactory;
		readonly IGetIsolationLevelFactory iGetIsolationLevelFactory;
		readonly IGetSiteDateFactory iGetSiteDateFactory;
		readonly IGetCodeFactory iGetCodeFactory;
		public Rpt_ItemDetailFactory(ICloseSessionContextFactory iCloseSessionContextFactory,
			IInitSessionContextFactory iInitSessionContextFactory,
			IGetIsolationLevelFactory iGetIsolationLevelFactory,
			IGetSiteDateFactory iGetSiteDateFactory,
			IGetCodeFactory iGetCodeFactory)
		{
			this.iCloseSessionContextFactory = iCloseSessionContextFactory;
			this.iInitSessionContextFactory = iInitSessionContextFactory;
			this.iGetIsolationLevelFactory = iGetIsolationLevelFactory;
			this.iGetSiteDateFactory = iGetSiteDateFactory;
			this.iGetCodeFactory = iGetCodeFactory;
		}

		public IRpt_ItemDetail Create(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO, ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iCloseSessionContext = this.iCloseSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iInitSessionContext = this.iInitSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = this.iGetIsolationLevelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsChecker(appDB, collectionLoadRequestFactory, collectionLoadStatementRequestFactory);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var iGetSiteDate = this.iGetSiteDateFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var iGetCode = this.iGetCodeFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iUnionUtil = new UnionUtil(UnionType.UnionAll);

			IRpt_ItemDetail _Rpt_ItemDetail = new Rpt_ItemDetail(appDB,
				bunchedLoadCollection,
				collectionLoadStatementRequestFactory,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCloseSessionContext,
				iInitSessionContext,
				transactionFactory,
				iGetIsolationLevel,
				iGetWinRegDecGroup,
				iFixMaskForCrystal,
				scalarFunction,
				existsChecker,
				convertToUtil,
				iGetSiteDate,
				variableUtil,
				stringUtil,
				iGetCode,
				sQLUtil,
				iUnionUtil,
                cSIExtensionClassBase.MongooseDependencies.LowCharacter,
                cSIExtensionClassBase.MongooseDependencies.HighCharacter);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_ItemDetail = IDOMethodIntercept<IRpt_ItemDetail>.Create(_Rpt_ItemDetail, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemDetailExt = timerfactory.Create<IRpt_ItemDetail>(_Rpt_ItemDetail);

			return iRpt_ItemDetailExt;
		}
	}
}
