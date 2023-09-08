//PROJECT NAME: Admin
//CLASS NAME: UserFormInGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class UserFormInGroupFactory
	{
		public IUserFormInGroup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UserFormInGroup = new Admin.UserFormInGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUserFormInGroupExt = timerfactory.Create<Admin.IUserFormInGroup>(_UserFormInGroup);
			
			return iUserFormInGroupExt;
		}
	}
}
