//PROJECT NAME: Logistics
//CLASS NAME: VerifyCoCustNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class VerifyCoCustNumFactory
	{
		public IVerifyCoCustNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VerifyCoCustNum = new Logistics.Customer.VerifyCoCustNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVerifyCoCustNumExt = timerfactory.Create<Logistics.Customer.IVerifyCoCustNum>(_VerifyCoCustNum);
			
			return iVerifyCoCustNumExt;
		}
	}
}
