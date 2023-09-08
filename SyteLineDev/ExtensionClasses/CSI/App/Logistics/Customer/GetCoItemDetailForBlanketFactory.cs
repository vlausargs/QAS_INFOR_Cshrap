//PROJECT NAME: Logistics
//CLASS NAME: GetCoItemDetailForBlanketFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetCoItemDetailForBlanketFactory
	{
		public IGetCoItemDetailForBlanket Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCoItemDetailForBlanket = new Logistics.Customer.GetCoItemDetailForBlanket(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCoItemDetailForBlanketExt = timerfactory.Create<Logistics.Customer.IGetCoItemDetailForBlanket>(_GetCoItemDetailForBlanket);
			
			return iGetCoItemDetailForBlanketExt;
		}
	}
}
