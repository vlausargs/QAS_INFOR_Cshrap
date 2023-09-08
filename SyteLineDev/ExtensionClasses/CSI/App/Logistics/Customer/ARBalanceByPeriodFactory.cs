//PROJECT NAME: Logistics
//CLASS NAME: ARBalanceByPeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ARBalanceByPeriodFactory
	{
		public IARBalanceByPeriod Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ARBalanceByPeriod = new Logistics.Customer.ARBalanceByPeriod(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARBalanceByPeriodExt = timerfactory.Create<Logistics.Customer.IARBalanceByPeriod>(_ARBalanceByPeriod);

			return iARBalanceByPeriodExt;
		}
	}
}
