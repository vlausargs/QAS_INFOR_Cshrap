//PROJECT NAME: Material
//CLASS NAME: TransferOrderShipFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class TransferOrderShipFactory
	{
		public ITransferOrderShip Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TransferOrderShip = new Material.TransferOrderShip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransferOrderShipExt = timerfactory.Create<Material.ITransferOrderShip>(_TransferOrderShip);
			
			return iTransferOrderShipExt;
		}
	}
}
