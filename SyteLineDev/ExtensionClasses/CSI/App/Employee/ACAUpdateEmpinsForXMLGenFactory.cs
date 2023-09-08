//PROJECT NAME: CSIEmployee
//CLASS NAME: ACAUpdateEmpinsForXMLGenFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class ACAUpdateEmpinsForXMLGenFactory
	{
		public IACAUpdateEmpinsForXMLGen Create(IApplicationDB appDB)
		{
			var _ACAUpdateEmpinsForXMLGen = new Employee.ACAUpdateEmpinsForXMLGen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iACAUpdateEmpinsForXMLGenExt = timerfactory.Create<Employee.IACAUpdateEmpinsForXMLGen>(_ACAUpdateEmpinsForXMLGen);
			
			return iACAUpdateEmpinsForXMLGenExt;
		}
	}
}
