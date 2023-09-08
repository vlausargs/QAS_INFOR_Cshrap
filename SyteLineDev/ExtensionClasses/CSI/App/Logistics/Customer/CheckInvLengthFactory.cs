//PROJECT NAME: Logistics
//CLASS NAME: CheckInvLengthFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CheckInvLengthFactory
	{
		public ICheckInvLength Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckInvLength = new Logistics.Customer.CheckInvLength(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckInvLengthExt = timerfactory.Create<Logistics.Customer.ICheckInvLength>(_CheckInvLength);
			
			return iCheckInvLengthExt;
		}
	}
}
