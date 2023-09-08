//PROJECT NAME: Material
//CLASS NAME: TransferOrderShipSetVarsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TransferOrderShipSetVarsFactory
	{
		public ITransferOrderShipSetVars Create(IApplicationDB appDB)
		{
			var _TransferOrderShipSetVars = new Material.TransferOrderShipSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransferOrderShipSetVarsExt = timerfactory.Create<Material.ITransferOrderShipSetVars>(_TransferOrderShipSetVars);
			
			return iTransferOrderShipSetVarsExt;
		}
	}
}
