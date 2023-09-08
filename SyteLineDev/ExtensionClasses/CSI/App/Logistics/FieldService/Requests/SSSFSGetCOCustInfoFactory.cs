//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetCOCustInfoFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Material;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSGetCOCustInfoFactory
	{
		public const string IDO = "FSSROs";
		public const string Method = "SSSFSGetCOCustInfo";
		
		public ISSSFSGetCOCustInfo Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iSSSFSGetCOCustInfoCRUD = new SSSFSGetCOCustInfoCRUD(appDB, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionLoadRequestFactory, existsChecker, variableUtil);
			ISSSFSGetCOCustInfo _SSSFSGetCOCustInfo = new SSSFSGetCOCustInfo(collectionLoadResponseUtil,
				sQLExpressionExecutor,
                iExpandKyByType,
                scalarFunction,
				stringUtil,
				sQLUtil,
				iSSSFSGetCOCustInfoCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_SSSFSGetCOCustInfo = IDOMethodIntercept<ISSSFSGetCOCustInfo>.Create(_SSSFSGetCOCustInfo, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetCOCustInfoExt = timerfactory.Create<ISSSFSGetCOCustInfo>(_SSSFSGetCOCustInfo);
			
			return iSSSFSGetCOCustInfoExt;
		}
	}
}
