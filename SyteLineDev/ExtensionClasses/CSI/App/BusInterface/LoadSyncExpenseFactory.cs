//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadSyncExpenseFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadSyncExpenseFactory
	{
		public ILoadSyncExpense Create(IApplicationDB appDB)
		{
			var _LoadSyncExpense = new BusInterface.LoadSyncExpense(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadSyncExpenseExt = timerfactory.Create<BusInterface.ILoadSyncExpense>(_LoadSyncExpense);
			
			return iLoadSyncExpenseExt;
		}
	}
}
