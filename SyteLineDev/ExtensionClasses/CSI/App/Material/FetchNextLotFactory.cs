//PROJECT NAME: Material
//CLASS NAME: FetchNextLotFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class FetchNextLotFactory
	{
		public IFetchNextLot Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FetchNextLot = new Material.FetchNextLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFetchNextLotExt = timerfactory.Create<Material.IFetchNextLot>(_FetchNextLot);
			
			return iFetchNextLotExt;
		}
	}
}
