//PROJECT NAME: Material
//CLASS NAME: PhytagsCountMethodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PhytagsCountMethodFactory
	{
		public IPhytagsCountMethod Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PhytagsCountMethod = new Material.PhytagsCountMethod(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhytagsCountMethodExt = timerfactory.Create<Material.IPhytagsCountMethod>(_PhytagsCountMethod);
			
			return iPhytagsCountMethodExt;
		}
	}
}
