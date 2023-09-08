//PROJECT NAME: Logistics
//CLASS NAME: Home_GetPastDueValuesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class Home_GetPastDueValuesFactory
	{
		public IHome_GetPastDueValues Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_GetPastDueValues = new Logistics.Vendor.Home_GetPastDueValues(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_GetPastDueValuesExt = timerfactory.Create<Logistics.Vendor.IHome_GetPastDueValues>(_Home_GetPastDueValues);
			
			return iHome_GetPastDueValuesExt;
		}
	}
}
