//PROJECT NAME: Codes
//CLASS NAME: ClearTrackRowsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.Functions;

namespace CSI.Codes
{
	public class ClearTrackRowsFactory
	{
		public const string IDO = "SLPortalParms";
		public const string Method = "ClearTrackRows";
		
		public IClearTrackRows Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			
			IClearTrackRows _ClearTrackRows = new ClearTrackRows(appDB,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				sQLExpressionExecutor,
				scalarFunction,
				sQLUtil);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_ClearTrackRows = IDOMethodIntercept<IClearTrackRows>.Create(_ClearTrackRows, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iClearTrackRowsExt = timerfactory.Create<IClearTrackRows>(_ClearTrackRows);
			
			return iClearTrackRowsExt;
		}
	}
}
