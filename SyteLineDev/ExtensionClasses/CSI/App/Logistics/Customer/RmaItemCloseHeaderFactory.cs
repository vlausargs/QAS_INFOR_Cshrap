//PROJECT NAME: Logistics
//CLASS NAME: RmaItemCloseHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class RmaItemCloseHeaderFactory
	{
		public IRmaItemCloseHeader Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RmaItemCloseHeader = new Logistics.Customer.RmaItemCloseHeader(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaItemCloseHeaderExt = timerfactory.Create<Logistics.Customer.IRmaItemCloseHeader>(_RmaItemCloseHeader);
			
			return iRmaItemCloseHeaderExt;
		}
	}
}
