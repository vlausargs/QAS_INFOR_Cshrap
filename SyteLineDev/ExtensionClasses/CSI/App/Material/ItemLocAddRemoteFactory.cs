//PROJECT NAME: Material
//CLASS NAME: ItemLocAddRemoteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemLocAddRemoteFactory
	{
		public IItemLocAddRemote Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemLocAddRemote = new Material.ItemLocAddRemote(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemLocAddRemoteExt = timerfactory.Create<Material.IItemLocAddRemote>(_ItemLocAddRemote);
			
			return iItemLocAddRemoteExt;
		}
	}
}
