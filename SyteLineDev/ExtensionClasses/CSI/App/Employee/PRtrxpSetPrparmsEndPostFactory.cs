//PROJECT NAME: Employee
//CLASS NAME: PRtrxpSetPrparmsEndPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PRtrxpSetPrparmsEndPostFactory
	{
		public IPRtrxpSetPrparmsEndPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PRtrxpSetPrparmsEndPost = new Employee.PRtrxpSetPrparmsEndPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPRtrxpSetPrparmsEndPostExt = timerfactory.Create<Employee.IPRtrxpSetPrparmsEndPost>(_PRtrxpSetPrparmsEndPost);
			
			return iPRtrxpSetPrparmsEndPostExt;
		}
	}
}
