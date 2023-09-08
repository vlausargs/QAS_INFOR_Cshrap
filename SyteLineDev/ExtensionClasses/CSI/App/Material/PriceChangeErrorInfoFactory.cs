//PROJECT NAME: CSIMaterial
//CLASS NAME: PriceChangeErrorInfoFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PriceChangeErrorInfoFactory
	{
		public IPriceChangeErrorInfo Create(IApplicationDB appDB)
		{
			var _PriceChangeErrorInfo = new Material.PriceChangeErrorInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPriceChangeErrorInfoExt = timerfactory.Create<Material.IPriceChangeErrorInfo>(_PriceChangeErrorInfo);
			
			return iPriceChangeErrorInfoExt;
		}
	}
}
