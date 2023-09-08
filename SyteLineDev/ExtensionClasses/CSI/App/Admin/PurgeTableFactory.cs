//PROJECT NAME: Admin
//CLASS NAME: PurgeTableFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.Functions;
using System.Diagnostics;
using CSI.Logger;

namespace CSI.Admin
{
	public class PurgeTableFactory
	{
		public const string IDO = "SLSiteMgmtTableData";
		public const string Method = "PurgeTable";
		
		public IPurgeTable Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var logger = new LoggerFactory().Create();
			
			IPurgeTable _PurgeTable = new PurgeTable(appDB,
			collectionLoadStatementRequestFactory,
			collectionUpdateRequestFactory,
			collectionDeleteRequestFactory,
			collectionLoadRequestFactory,
			sQLExpressionExecutor,
			transactionFactory,
			existsChecker,
			stringUtil,
			sQLUtil,
			logger);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_PurgeTable = IDOMethodIntercept<IPurgeTable>.Create(_PurgeTable, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeTableExt = timerfactory.Create<IPurgeTable>(_PurgeTable);
			
			return iPurgeTableExt;
		}
	}
}
