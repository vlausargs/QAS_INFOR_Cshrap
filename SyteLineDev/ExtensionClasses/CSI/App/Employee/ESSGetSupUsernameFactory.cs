//PROJECT NAME: CSIEmployee
//CLASS NAME: ESSGetSupUsernameFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class ESSGetSupUsernameFactory
	{
		public IESSGetSupUsername Create(IApplicationDB appDB)
		{
			var _ESSGetSupUsername = new Employee.ESSGetSupUsername(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iESSGetSupUsernameExt = timerfactory.Create<Employee.IESSGetSupUsername>(_ESSGetSupUsername);
			
			return iESSGetSupUsernameExt;
		}
	}
}
