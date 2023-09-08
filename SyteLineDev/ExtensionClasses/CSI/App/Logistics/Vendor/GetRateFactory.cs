//PROJECT NAME: CSIVendor
//CLASS NAME: GetRateFactory.cs

using CSI.Data.Functions;
using CSI.Data.RecordSets;
using CSI.Data.Utilities;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetRateFactory
	{
		public IGetRate Create(ICSIExtensionClassBase csiExtensionClassBase)
		{
			var appDB = csiExtensionClassBase.AppDB;
			var parameterProvider = csiExtensionClassBase.ParameterProvider;

			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);
			var _GetRate = new Logistics.Vendor.GetRate(appDB, dataTableToCollectionLoadResponse, dataTableUtil);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetRateExt = timerfactory.Create<Logistics.Vendor.IGetRate>(_GetRate);
			
			return iGetRateExt;
		}
	}
}
