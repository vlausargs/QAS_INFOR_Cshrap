//PROJECT NAME: Material
//CLASS NAME: CombineXferShipReceiveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CombineXferShipReceiveFactory
	{
		public ICombineXferShipReceive Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CombineXferShipReceive = new Material.CombineXferShipReceive(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCombineXferShipReceiveExt = timerfactory.Create<Material.ICombineXferShipReceive>(_CombineXferShipReceive);
			
			return iCombineXferShipReceiveExt;
		}
	}
}
