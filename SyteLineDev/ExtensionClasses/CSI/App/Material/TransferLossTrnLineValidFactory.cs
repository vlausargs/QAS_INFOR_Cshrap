//PROJECT NAME: Material
//CLASS NAME: TransferLossTrnLineValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TransferLossTrnLineValidFactory
	{
		public ITransferLossTrnLineValid Create(IApplicationDB appDB)
		{
			var _TransferLossTrnLineValid = new Material.TransferLossTrnLineValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransferLossTrnLineValidExt = timerfactory.Create<Material.ITransferLossTrnLineValid>(_TransferLossTrnLineValid);
			
			return iTransferLossTrnLineValidExt;
		}
	}
}
