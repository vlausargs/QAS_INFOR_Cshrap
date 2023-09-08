//PROJECT NAME: Material
//CLASS NAME: ConsignUsageGetLotAndLocFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ConsignUsageGetLotAndLocFactory
	{
		public IConsignUsageGetLotAndLoc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ConsignUsageGetLotAndLoc = new Material.ConsignUsageGetLotAndLoc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iConsignUsageGetLotAndLocExt = timerfactory.Create<Material.IConsignUsageGetLotAndLoc>(_ConsignUsageGetLotAndLoc);
			
			return iConsignUsageGetLotAndLocExt;
		}
	}
}
