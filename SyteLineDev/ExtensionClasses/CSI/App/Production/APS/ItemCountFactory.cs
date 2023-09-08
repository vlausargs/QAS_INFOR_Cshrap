//PROJECT NAME: Production
//CLASS NAME: ItemCountFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ItemCountFactory
	{
		public IItemCount Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemCount = new Production.APS.ItemCount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemCountExt = timerfactory.Create<Production.APS.IItemCount>(_ItemCount);
			
			return iItemCountExt;
		}
	}
}
