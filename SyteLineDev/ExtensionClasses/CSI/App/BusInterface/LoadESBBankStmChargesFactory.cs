//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmChargesFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmChargesFactory
	{
		public ILoadESBBankStmCharges Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmCharges = new BusInterface.LoadESBBankStmCharges(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmChargesExt = timerfactory.Create<BusInterface.ILoadESBBankStmCharges>(_LoadESBBankStmCharges);
			
			return iLoadESBBankStmChargesExt;
		}
	}
}
