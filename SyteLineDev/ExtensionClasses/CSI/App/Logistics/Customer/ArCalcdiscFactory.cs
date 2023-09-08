//PROJECT NAME: Logistics
//CLASS NAME: ArCalcdiscFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArCalcdiscFactory
	{
		public IArCalcdisc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArCalcdisc = new Logistics.Customer.ArCalcdisc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArCalcdiscExt = timerfactory.Create<Logistics.Customer.IArCalcdisc>(_ArCalcdisc);
			
			return iArCalcdiscExt;
		}
	}
}
