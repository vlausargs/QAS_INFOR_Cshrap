//PROJECT NAME: Material
//CLASS NAME: ItemAvailabilityFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemAvailabilityFactory
	{
		public IItemAvailability Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemAvailability = new Material.ItemAvailability(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemAvailabilityExt = timerfactory.Create<Material.IItemAvailability>(_ItemAvailability);
			
			return iItemAvailabilityExt;
		}
	}
}
