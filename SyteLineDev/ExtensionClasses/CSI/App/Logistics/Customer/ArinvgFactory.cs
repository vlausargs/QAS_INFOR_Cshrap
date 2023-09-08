//PROJECT NAME: Logistics
//CLASS NAME: ArinvgFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArinvgFactory
	{
		public IArinvg Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _Arinvg = new Logistics.Customer.Arinvg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArinvgExt = timerfactory.Create<Logistics.Customer.IArinvg>(_Arinvg);
			
			return iArinvgExt;
		}
	}
}
