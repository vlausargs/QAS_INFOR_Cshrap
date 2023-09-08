//PROJECT NAME: CSIEmployee
//CLASS NAME: ESSGetSupNameFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class ESSGetSupNameFactory
	{
		public IESSGetSupName Create(IApplicationDB appDB)
		{
			var _ESSGetSupName = new Employee.ESSGetSupName(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iESSGetSupNameExt = timerfactory.Create<Employee.IESSGetSupName>(_ESSGetSupName);
			
			return iESSGetSupNameExt;
		}
	}
}
