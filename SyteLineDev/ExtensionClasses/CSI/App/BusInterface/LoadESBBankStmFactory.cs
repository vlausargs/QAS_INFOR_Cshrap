//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmFactory
	{
		public ILoadESBBankStm Create(IApplicationDB appDB)
		{
			var _LoadESBBankStm = new BusInterface.LoadESBBankStm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmExt = timerfactory.Create<BusInterface.ILoadESBBankStm>(_LoadESBBankStm);
			
			return iLoadESBBankStmExt;
		}
	}
}
