//PROJECT NAME: Logistics
//CLASS NAME: CheckEndingInvFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CheckEndingInvFactory
	{
		public ICheckEndingInv Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckEndingInv = new Logistics.Customer.CheckEndingInv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckEndingInvExt = timerfactory.Create<Logistics.Customer.ICheckEndingInv>(_CheckEndingInv);
			
			return iCheckEndingInvExt;
		}
	}
}
