//PROJECT NAME: Material
//CLASS NAME: LockJobItemsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class LockJobItemsFactory
	{
		public ILockJobItems Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LockJobItems = new Material.LockJobItems(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLockJobItemsExt = timerfactory.Create<Material.ILockJobItems>(_LockJobItems);
			
			return iLockJobItemsExt;
		}
	}
}
