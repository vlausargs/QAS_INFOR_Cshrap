//PROJECT NAME: Production
//CLASS NAME: ValidatePurchasedItemsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.Functions;

namespace CSI.Production.APS
{
	public class ValidatePurchasedItemsFactory
	{
		public const string IDO = "SLExpectedReceipts";
		public const string Method = "ValidatePurchasedItems";
		
		public IValidatePurchasedItems Create(IApplicationDB appDB,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);
			
			IValidatePurchasedItems _ValidatePurchasedItems = new ValidatePurchasedItems(appDB,
				collectionLoadRequestFactory,
				scalarFunction,
				existsChecker,
				sQLUtil,
				iMsgApp);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_ValidatePurchasedItems = IDOMethodIntercept<IValidatePurchasedItems>.Create(_ValidatePurchasedItems, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatePurchasedItemsExt = timerfactory.Create<IValidatePurchasedItems>(_ValidatePurchasedItems);
			
			return iValidatePurchasedItemsExt;
		}
	}
}
