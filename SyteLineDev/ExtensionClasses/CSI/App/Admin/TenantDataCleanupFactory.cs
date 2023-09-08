//PROJECT NAME: Admin
//CLASS NAME: TenantDataCleanupFactory.cs

using CSI.MG;
using CSI.Data.Metric;

namespace CSI.Admin
{
	public class TenantDataCleanupFactory
	{
		public ITenantDataCleanup Create(IApplicationDB appDB)
		{
			ITenantDataCleanup _TenantDataCleanup = new Admin.TenantDataCleanup(appDB);
			TimerFactory _timerfactory = new TimerFactory();

			return _timerfactory.Create<ITenantDataCleanup>(_TenantDataCleanup);
		}
	}
}
