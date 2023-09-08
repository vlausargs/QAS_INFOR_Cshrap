//PROJECT NAME: Logistics
//CLASS NAME: DefaultDiscFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class DefaultDiscFactory
	{
		public IDefaultDisc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DefaultDisc = new Logistics.Customer.DefaultDisc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDefaultDiscExt = timerfactory.Create<Logistics.Customer.IDefaultDisc>(_DefaultDisc);
			
			return iDefaultDiscExt;
		}
	}
}
