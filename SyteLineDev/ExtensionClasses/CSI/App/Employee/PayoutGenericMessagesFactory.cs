//PROJECT NAME: Employee
//CLASS NAME: PayoutGenericMessagesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PayoutGenericMessagesFactory
	{
		public IPayoutGenericMessages Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PayoutGenericMessages = new Employee.PayoutGenericMessages(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPayoutGenericMessagesExt = timerfactory.Create<Employee.IPayoutGenericMessages>(_PayoutGenericMessages);
			
			return iPayoutGenericMessagesExt;
		}
	}
}
