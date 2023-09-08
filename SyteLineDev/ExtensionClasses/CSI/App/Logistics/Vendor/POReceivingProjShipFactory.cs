//PROJECT NAME: Logistics
//CLASS NAME: POReceivingProjShipFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class POReceivingProjShipFactory
	{
		public IPOReceivingProjShip Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _POReceivingProjShip = new Logistics.Vendor.POReceivingProjShip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOReceivingProjShipExt = timerfactory.Create<Logistics.Vendor.IPOReceivingProjShip>(_POReceivingProjShip);
			
			return iPOReceivingProjShipExt;
		}
	}
}
