//PROJECT NAME: Codes
//CLASS NAME: PortalAccountCreateOrCopy_1_CanCreateUsersFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class PortalAccountCreateOrCopy_1_CanCreateUsersFactory
	{
		public IPortalAccountCreateOrCopy_1_CanCreateUsers Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PortalAccountCreateOrCopy_1_CanCreateUsers = new Codes.PortalAccountCreateOrCopy_1_CanCreateUsers(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalAccountCreateOrCopy_1_CanCreateUsersExt = timerfactory.Create<Codes.IPortalAccountCreateOrCopy_1_CanCreateUsers>(_PortalAccountCreateOrCopy_1_CanCreateUsers);
			
			return iPortalAccountCreateOrCopy_1_CanCreateUsersExt;
		}
	}
}
