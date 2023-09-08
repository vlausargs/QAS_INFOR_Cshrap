//PROJECT NAME: Material
//CLASS NAME: TrrcvSerErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class TrrcvSerErrorFactory
	{
		public ITrrcvSerError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TrrcvSerError = new Material.TrrcvSerError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrrcvSerErrorExt = timerfactory.Create<Material.ITrrcvSerError>(_TrrcvSerError);
			
			return iTrrcvSerErrorExt;
		}
	}
}
