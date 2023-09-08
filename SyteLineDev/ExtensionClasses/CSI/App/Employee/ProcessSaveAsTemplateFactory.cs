//PROJECT NAME: CSIEmployee
//CLASS NAME: ProcessSaveAsTemplateFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class ProcessSaveAsTemplateFactory
	{
		public IProcessSaveAsTemplate Create(IApplicationDB appDB)
		{
			var _ProcessSaveAsTemplate = new Employee.ProcessSaveAsTemplate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcessSaveAsTemplateExt = timerfactory.Create<Employee.IProcessSaveAsTemplate>(_ProcessSaveAsTemplate);
			
			return iProcessSaveAsTemplateExt;
		}
	}
}
