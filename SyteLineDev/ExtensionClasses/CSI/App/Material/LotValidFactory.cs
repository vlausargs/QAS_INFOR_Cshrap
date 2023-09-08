//PROJECT NAME: Material
//CLASS NAME: LotValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class LotValidFactory
	{
		public ILotValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LotValid = new Material.LotValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLotValidExt = timerfactory.Create<Material.ILotValid>(_LotValid);
			
			return iLotValidExt;
		}
	}
}
