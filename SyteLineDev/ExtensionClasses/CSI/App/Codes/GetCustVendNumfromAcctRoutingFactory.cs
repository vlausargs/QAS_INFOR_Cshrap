//PROJECT NAME: Codes
//CLASS NAME: GetCustVendNumfromAcctRoutingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Utilities;

namespace CSI.Codes
{
	public class GetCustVendNumfromAcctRoutingFactory
	{
		public IGetCustVendNumfromAcctRouting Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);
			var _GetCustVendNumfromAcctRouting = new Codes.GetCustVendNumfromAcctRouting(appDB, dataTableToCollectionLoadResponse, dataTableUtil);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCustVendNumfromAcctRoutingExt = timerfactory.Create<Codes.IGetCustVendNumfromAcctRouting>(_GetCustVendNumfromAcctRouting);
			
			return iGetCustVendNumfromAcctRoutingExt;
		}
	}
}
