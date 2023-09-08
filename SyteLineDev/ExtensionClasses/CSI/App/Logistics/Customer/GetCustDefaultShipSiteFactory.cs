//PROJECT NAME: Logistics
//CLASS NAME: GetCustDefaultShipSiteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetCustDefaultShipSiteFactory
	{
		public IGetCustDefaultShipSite Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCustDefaultShipSite = new Logistics.Customer.GetCustDefaultShipSite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCustDefaultShipSiteExt = timerfactory.Create<Logistics.Customer.IGetCustDefaultShipSite>(_GetCustDefaultShipSite);
			
			return iGetCustDefaultShipSiteExt;
		}
	}
}
