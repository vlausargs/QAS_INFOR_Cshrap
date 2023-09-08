//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBankStmProcessedFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBankStmProcessedFactory
	{
		public ILoadESBBankStmProcessed Create(IApplicationDB appDB)
		{
			var _LoadESBBankStmProcessed = new BusInterface.LoadESBBankStmProcessed(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBankStmProcessedExt = timerfactory.Create<BusInterface.ILoadESBBankStmProcessed>(_LoadESBBankStmProcessed);
			
			return iLoadESBBankStmProcessedExt;
		}
	}
}
