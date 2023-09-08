//PROJECT NAME: Logistics
//CLASS NAME: CoDuePerFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoDuePerFactory
	{
		public ICoDuePer Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoDuePer = new Logistics.Customer.CoDuePer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoDuePerExt = timerfactory.Create<Logistics.Customer.ICoDuePer>(_CoDuePer);
			
			return iCoDuePerExt;
		}
	}
}
