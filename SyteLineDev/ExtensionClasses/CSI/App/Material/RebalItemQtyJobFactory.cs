//PROJECT NAME: Material
//CLASS NAME: RebalItemQtyJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class RebalItemQtyJobFactory
	{
		public IRebalItemQtyJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RebalItemQtyJob = new Material.RebalItemQtyJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRebalItemQtyJobExt = timerfactory.Create<Material.IRebalItemQtyJob>(_RebalItemQtyJob);
			
			return iRebalItemQtyJobExt;
		}
	}
}
