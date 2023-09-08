//PROJECT NAME: Admin
//CLASS NAME: ValidateDeptFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class ValidateDeptFactory
	{
		public IValidateDept Create(IApplicationDB appDB)
		{
			var _ValidateDept = new Admin.ValidateDept(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateDeptExt = timerfactory.Create<Admin.IValidateDept>(_ValidateDept);
			
			return iValidateDeptExt;
		}
	}
}
