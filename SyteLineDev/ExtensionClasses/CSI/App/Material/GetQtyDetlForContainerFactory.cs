//PROJECT NAME: Material
//CLASS NAME: GetQtyDetlForContainerFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetQtyDetlForContainerFactory
	{
		public IGetQtyDetlForContainer Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetQtyDetlForContainer = new Material.GetQtyDetlForContainer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetQtyDetlForContainerExt = timerfactory.Create<Material.IGetQtyDetlForContainer>(_GetQtyDetlForContainer);
			
			return iGetQtyDetlForContainerExt;
		}
	}
}
