//PROJECT NAME: Logistics
//CLASS NAME: COShippingPopulateTmpShpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class COShippingPopulateTmpShpFactory
	{
		public ICOShippingPopulateTmpShp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _COShippingPopulateTmpShp = new Logistics.Customer.COShippingPopulateTmpShp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCOShippingPopulateTmpShpExt = timerfactory.Create<Logistics.Customer.ICOShippingPopulateTmpShp>(_COShippingPopulateTmpShp);
			
			return iCOShippingPopulateTmpShpExt;
		}
	}
}
