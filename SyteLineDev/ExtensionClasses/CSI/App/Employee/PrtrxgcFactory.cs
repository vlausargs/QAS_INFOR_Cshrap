//PROJECT NAME: Employee
//CLASS NAME: PrtrxgcFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class PrtrxgcFactory
	{
		public IPrtrxgc Create(IApplicationDB appDB)
		{
			var _Prtrxgc = new Employee.Prtrxgc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrtrxgcExt = timerfactory.Create<Employee.IPrtrxgc>(_Prtrxgc);
			
			return iPrtrxgcExt;
		}
	}
}
