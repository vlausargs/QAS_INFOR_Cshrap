//PROJECT NAME: CSIEmployee
//CLASS NAME: GenericNotifyEventGlobalCsFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class GenericNotifyEventGlobalCsFactory
	{
		public IGenericNotifyEventGlobalCs Create(IApplicationDB appDB)
		{
			var _GenericNotifyEventGlobalCs = new Employee.GenericNotifyEventGlobalCs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenericNotifyEventGlobalCsExt = timerfactory.Create<Employee.IGenericNotifyEventGlobalCs>(_GenericNotifyEventGlobalCs);
			
			return iGenericNotifyEventGlobalCsExt;
		}
	}
}
