//PROJECT NAME: Logistics
//CLASS NAME: CustomerDefaultShipSiteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CustomerDefaultShipSiteFactory
	{
		public ICustomerDefaultShipSite Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CustomerDefaultShipSite = new Logistics.Customer.CustomerDefaultShipSite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerDefaultShipSiteExt = timerfactory.Create<Logistics.Customer.ICustomerDefaultShipSite>(_CustomerDefaultShipSite);
			
			return iCustomerDefaultShipSiteExt;
		}
	}
}
