//PROJECT NAME: Admin
//CLASS NAME: UpdateUserStartFormSubFormFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class UpdateUserStartFormSubFormFactory
	{
		public IUpdateUserStartFormSubForm Create(IApplicationDB appDB)
		{
			var _UpdateUserStartFormSubForm = new Admin.UpdateUserStartFormSubForm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateUserStartFormSubFormExt = timerfactory.Create<Admin.IUpdateUserStartFormSubForm>(_UpdateUserStartFormSubForm);
			
			return iUpdateUserStartFormSubFormExt;
		}
	}
}
