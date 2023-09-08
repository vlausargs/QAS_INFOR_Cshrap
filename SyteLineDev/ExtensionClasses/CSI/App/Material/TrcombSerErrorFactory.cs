//PROJECT NAME: Material
//CLASS NAME: TrcombSerErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class TrcombSerErrorFactory
	{
		public ITrcombSerError Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TrcombSerError = new Material.TrcombSerError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrcombSerErrorExt = timerfactory.Create<Material.ITrcombSerError>(_TrcombSerError);
			
			return iTrcombSerErrorExt;
		}
	}
}
