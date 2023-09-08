//PROJECT NAME: Employee
//CLASS NAME: PrtrxdepIFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class PrtrxdepIFactory
	{
		public IPrtrxdepI Create(IApplicationDB appDB)
		{
			var _PrtrxdepI = new Employee.PrtrxdepI(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrtrxdepIExt = timerfactory.Create<Employee.IPrtrxdepI>(_PrtrxdepI);
			
			return iPrtrxdepIExt;
		}
	}
}
