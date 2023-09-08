//PROJECT NAME: Employee
//CLASS NAME: PayoutWinMessagesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PayoutWinMessagesFactory
	{
		public IPayoutWinMessages Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PayoutWinMessages = new Employee.PayoutWinMessages(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPayoutWinMessagesExt = timerfactory.Create<Employee.IPayoutWinMessages>(_PayoutWinMessages);
			
			return iPayoutWinMessagesExt;
		}
	}
}
