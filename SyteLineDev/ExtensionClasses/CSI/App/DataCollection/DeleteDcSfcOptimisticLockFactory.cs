//PROJECT NAME: DataCollection
//CLASS NAME: DeleteDcSfcOptimisticLockFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.DataCollection
{
	public class DeleteDcSfcOptimisticLockFactory
	{
		public IDeleteDcSfcOptimisticLock Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DeleteDcSfcOptimisticLock = new DataCollection.DeleteDcSfcOptimisticLock(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteDcSfcOptimisticLockExt = timerfactory.Create<DataCollection.IDeleteDcSfcOptimisticLock>(_DeleteDcSfcOptimisticLock);
			
			return iDeleteDcSfcOptimisticLockExt;
		}
	}
}
