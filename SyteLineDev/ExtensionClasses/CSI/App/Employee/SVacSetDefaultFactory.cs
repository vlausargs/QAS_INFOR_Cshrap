//PROJECT NAME: Employee
//CLASS NAME: SVacSetDefaultFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class SVacSetDefaultFactory
	{
		public ISVacSetDefault Create(IApplicationDB appDB)
		{
			var _SVacSetDefault = new Employee.SVacSetDefault(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSVacSetDefaultExt = timerfactory.Create<Employee.ISVacSetDefault>(_SVacSetDefault);
			
			return iSVacSetDefaultExt;
		}
	}
}
