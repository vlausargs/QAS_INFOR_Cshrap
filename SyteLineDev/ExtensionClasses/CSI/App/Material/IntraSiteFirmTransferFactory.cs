//PROJECT NAME: CSIMaterial
//CLASS NAME: IntraSiteFirmTransferFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class IntraSiteFirmTransferFactory
	{
		public IIntraSiteFirmTransfer Create(IApplicationDB appDB)
		{
			var _IntraSiteFirmTransfer = new Material.IntraSiteFirmTransfer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIntraSiteFirmTransferExt = timerfactory.Create<Material.IIntraSiteFirmTransfer>(_IntraSiteFirmTransfer);
			
			return iIntraSiteFirmTransferExt;
		}
	}
}
