//PROJECT NAME: Admin
//CLASS NAME: PortalEventMessagesUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class PortalEventMessagesUpdFactory
	{
		public IPortalEventMessagesUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PortalEventMessagesUpd = new Admin.PortalEventMessagesUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalEventMessagesUpdExt = timerfactory.Create<Admin.IPortalEventMessagesUpd>(_PortalEventMessagesUpd);
			
			return iPortalEventMessagesUpdExt;
		}
	}
}
