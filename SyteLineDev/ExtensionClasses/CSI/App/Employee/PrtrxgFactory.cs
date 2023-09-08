//PROJECT NAME: Employee
//CLASS NAME: PrtrxgFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class PrtrxgFactory
	{
		public IPrtrxg Create(IApplicationDB appDB)
		{
			var _Prtrxg = new Employee.Prtrxg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrtrxgExt = timerfactory.Create<Employee.IPrtrxg>(_Prtrxg);
			
			return iPrtrxgExt;
		}
	}
}
