//PROJECT NAME: Material
//CLASS NAME: MrpNetFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MrpNetFactory
	{
		public IMrpNet Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MrpNet = new Material.MrpNet(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMrpNetExt = timerfactory.Create<Material.IMrpNet>(_MrpNet);
			
			return iMrpNetExt;
		}
	}
}
