//PROJECT NAME: Material
//CLASS NAME: InvparmsFbomBlankFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class InvparmsFbomBlankFactory
	{
		public IInvparmsFbomBlank Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvparmsFbomBlank = new Material.InvparmsFbomBlank(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvparmsFbomBlankExt = timerfactory.Create<Material.IInvparmsFbomBlank>(_InvparmsFbomBlank);
			
			return iInvparmsFbomBlankExt;
		}
	}
}
