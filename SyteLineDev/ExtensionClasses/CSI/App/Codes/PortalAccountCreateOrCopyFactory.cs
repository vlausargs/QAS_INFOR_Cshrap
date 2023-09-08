//PROJECT NAME: Codes
//CLASS NAME: PortalAccountCreateOrCopyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class PortalAccountCreateOrCopyFactory
	{
		public IPortalAccountCreateOrCopy Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PortalAccountCreateOrCopy = new Codes.PortalAccountCreateOrCopy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalAccountCreateOrCopyExt = timerfactory.Create<Codes.IPortalAccountCreateOrCopy>(_PortalAccountCreateOrCopy);
			
			return iPortalAccountCreateOrCopyExt;
		}
	}
}
