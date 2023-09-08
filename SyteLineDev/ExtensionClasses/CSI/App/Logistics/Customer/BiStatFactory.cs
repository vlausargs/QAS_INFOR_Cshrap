//PROJECT NAME: Logistics
//CLASS NAME: BiStatFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class BiStatFactory
	{
		public IBiStat Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BiStat = new Logistics.Customer.BiStat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBiStatExt = timerfactory.Create<Logistics.Customer.IBiStat>(_BiStat);
			
			return iBiStatExt;
		}
	}
}
