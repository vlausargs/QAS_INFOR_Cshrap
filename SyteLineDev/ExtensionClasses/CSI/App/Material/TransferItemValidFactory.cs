//PROJECT NAME: Material
//CLASS NAME: TransferItemValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TransferItemValidFactory
	{
		public ITransferItemValid Create(IApplicationDB appDB)
		{
			var _TransferItemValid = new Material.TransferItemValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransferItemValidExt = timerfactory.Create<Material.ITransferItemValid>(_TransferItemValid);
			
			return iTransferItemValidExt;
		}
	}
}
