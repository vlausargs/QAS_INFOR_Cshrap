//PROJECT NAME: Employee
//CLASS NAME: PayoutGetAdpParmFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PayoutGetAdpParmFactory
	{
		public IPayoutGetAdpParm Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PayoutGetAdpParm = new Employee.PayoutGetAdpParm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPayoutGetAdpParmExt = timerfactory.Create<Employee.IPayoutGetAdpParm>(_PayoutGetAdpParm);
			
			return iPayoutGetAdpParmExt;
		}
	}
}
