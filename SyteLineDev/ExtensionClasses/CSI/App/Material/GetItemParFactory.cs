//PROJECT NAME: Material
//CLASS NAME: GetItemParFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetItemParFactory
	{
		public IGetItemPar Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetItemPar = new Material.GetItemPar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemParExt = timerfactory.Create<Material.IGetItemPar>(_GetItemPar);
			
			return iGetItemParExt;
		}
	}
}
