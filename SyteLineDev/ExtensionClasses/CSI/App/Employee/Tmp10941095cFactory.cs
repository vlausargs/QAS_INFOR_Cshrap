//PROJECT NAME: Employee
//CLASS NAME: Tmp10941095cFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class Tmp10941095cFactory
	{
		public ITmp10941095c Create(IApplicationDB appDB)
		{
			var _Tmp10941095c = new Employee.Tmp10941095c(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTmp10941095cExt = timerfactory.Create<Employee.ITmp10941095c>(_Tmp10941095c);
			
			return iTmp10941095cExt;
		}
	}
}
