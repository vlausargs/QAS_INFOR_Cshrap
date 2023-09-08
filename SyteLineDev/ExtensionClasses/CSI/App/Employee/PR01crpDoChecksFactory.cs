//PROJECT NAME: CSIEmployee
//CLASS NAME: PR01crpDoChecksFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class PR01crpDoChecksFactory
	{
		public IPR01crpDoChecks Create(IApplicationDB appDB)
		{
			var _PR01crpDoChecks = new Employee.PR01crpDoChecks(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPR01crpDoChecksExt = timerfactory.Create<Employee.IPR01crpDoChecks>(_PR01crpDoChecks);
			
			return iPR01crpDoChecksExt;
		}
	}
}
