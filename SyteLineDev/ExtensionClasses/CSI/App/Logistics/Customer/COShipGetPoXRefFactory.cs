//PROJECT NAME: Logistics
//CLASS NAME: COShipGetPoXRefFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class COShipGetPoXRefFactory
	{
		public ICOShipGetPoXRef Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _COShipGetPoXRef = new Logistics.Customer.COShipGetPoXRef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCOShipGetPoXRefExt = timerfactory.Create<Logistics.Customer.ICOShipGetPoXRef>(_COShipGetPoXRef);
			
			return iCOShipGetPoXRefExt;
		}
	}
}
