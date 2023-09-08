//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadBankStmFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadBankStmFactory
	{
		public ILoadBankStm Create(IApplicationDB appDB)
		{
			var _LoadBankStm = new BusInterface.LoadBankStm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadBankStmExt = timerfactory.Create<BusInterface.ILoadBankStm>(_LoadBankStm);
			
			return iLoadBankStmExt;
		}
	}
}
