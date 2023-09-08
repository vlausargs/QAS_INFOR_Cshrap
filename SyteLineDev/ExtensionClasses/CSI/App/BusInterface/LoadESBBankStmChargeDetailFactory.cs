//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmChargeDetailFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmChargeDetailFactory
	{
		public ILoadESBBankStmChargeDetail Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmChargeDetail = new BusInterface.LoadESBBankStmChargeDetail(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmChargeDetailExt = timerfactory.Create<BusInterface.ILoadESBBankStmChargeDetail>(_LoadESBBankStmChargeDetail);
			
			return iLoadESBBankStmChargeDetailExt;
		}
	}
}
