//PROJECT NAME: Material
//CLASS NAME: GetTransitItemLocFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetTransitItemLocFactory
	{
		public IGetTransitItemLoc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetTransitItemLoc = new Material.GetTransitItemLoc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetTransitItemLocExt = timerfactory.Create<Material.IGetTransitItemLoc>(_GetTransitItemLoc);
			
			return iGetTransitItemLocExt;
		}
	}
}
