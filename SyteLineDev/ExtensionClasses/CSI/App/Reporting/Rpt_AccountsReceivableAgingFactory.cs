//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AccountsReceivableAgingFactory.cs

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
using System.Collections.Generic;
using CSI.Data.Cache;
using CSI.Logger;
using System;

namespace CSI.Reporting
{
	public class Rpt_AccountsReceivableAgingFactory
	{
		public const string IDO = "SLAccountsReceivableAgingReport";
		public const string Method = "Rpt_AccountsReceivableAging";
		
		public IRpt_AccountsReceivableAging Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
			var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, true);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iAndSqlWhere = cSIExtensionClassBase.MongooseDependencies.AndSqlWhere;
			var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
			var stringUtil = new StringUtil();
			var iIsInteger = cSIExtensionClassBase.MongooseDependencies.IsInteger;
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iAging = new AgingFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var bookmarkFactory = new BookmarkFactory();
            var recordCollectionToDataTable = new RecordCollectionToDataTable();
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

            var collectionNonTriggerUpdateRequestFactory = new CollectionNonTriggerUpdateRequestFactory(queryLanguage);
            var collectionNonTriggerInsertRequestFactory = new CollectionNonTriggerInsertRequestFactory(queryLanguage);
            var logger = new Logger.LoggerFactory().Create(LoggerType.Mongoose);

			IRpt_AccountsReceivableAging _Rpt_AccountsReceivableAging = new Rpt_AccountsReceivableAging(appDB,
				bunchedLoadCollection,
				collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				sQLCollectionLoad,
				iApplyDateOffset,
				iExpandKyByType,
				scalarFunction,
				existsChecker,
				convertToUtil,
				dateTimeUtil,
				variableUtil,
				iAndSqlWhere,
				iMidnightOf,
				stringUtil,
				iIsInteger,
				sQLUtil,
				iAging,
				defineProcessVariable,
				getVariable,
				mgSessionVariableBasedCache,
				queryLanguage,
				bookmarkFactory,
				//resultSortOrder,
				//arTranSortOrder,
				//tmpArAgingSortOrder,
				recordCollectionToDataTable,
				dataTableToCollectionLoadResponse,
				cSIExtensionClassBase.MongooseDependencies.LowCharacter,
				cSIExtensionClassBase.MongooseDependencies.HighCharacter,
				collectionNonTriggerUpdateRequestFactory,
				collectionNonTriggerInsertRequestFactory,
				logger);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_AccountsReceivableAging = IDOMethodIntercept<IRpt_AccountsReceivableAging>.Create(_Rpt_AccountsReceivableAging, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_AccountsReceivableAgingExt = timerfactory.Create<IRpt_AccountsReceivableAging>(_Rpt_AccountsReceivableAging);
			
			return iRpt_AccountsReceivableAgingExt;
		}
	}
}
