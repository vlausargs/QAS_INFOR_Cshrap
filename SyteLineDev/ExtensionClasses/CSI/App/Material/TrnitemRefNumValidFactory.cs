//PROJECT NAME: Material
//CLASS NAME: TrnitemRefNumValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class TrnitemRefNumValidFactory
	{
		public ITrnitemRefNumValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TrnitemRefNumValid = new Material.TrnitemRefNumValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrnitemRefNumValidExt = timerfactory.Create<Material.ITrnitemRefNumValid>(_TrnitemRefNumValid);
			
			return iTrnitemRefNumValidExt;
		}
	}
}
