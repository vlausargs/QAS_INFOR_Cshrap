//PROJECT NAME: Logistics
//CLASS NAME: POReceivePrePojob3PFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class POReceivePrePojob3PFactory
	{
		public IPOReceivePrePojob3P Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _POReceivePrePojob3P = new Logistics.Vendor.POReceivePrePojob3P(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOReceivePrePojob3PExt = timerfactory.Create<Logistics.Vendor.IPOReceivePrePojob3P>(_POReceivePrePojob3P);
			
			return iPOReceivePrePojob3PExt;
		}
	}
}
