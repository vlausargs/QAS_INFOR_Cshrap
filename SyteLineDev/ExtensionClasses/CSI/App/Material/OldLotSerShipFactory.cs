//PROJECT NAME: Material
//CLASS NAME: OldLotSerShipFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class OldLotSerShipFactory
	{
		public IOldLotSerShip Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _OldLotSerShip = new Material.OldLotSerShip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iOldLotSerShipExt = timerfactory.Create<Material.IOldLotSerShip>(_OldLotSerShip);
			
			return iOldLotSerShipExt;
		}
	}
}
