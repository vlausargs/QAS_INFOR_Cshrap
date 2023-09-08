//PROJECT NAME: Material
//CLASS NAME: GetNextTrnShipLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetNextTrnShipLineFactory
	{
		public IGetNextTrnShipLine Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNextTrnShipLine = new Material.GetNextTrnShipLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextTrnShipLineExt = timerfactory.Create<Material.IGetNextTrnShipLine>(_GetNextTrnShipLine);
			
			return iGetNextTrnShipLineExt;
		}
	}
}
