//PROJECT NAME: Material
//CLASS NAME: PriceCodeValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PriceCodeValidFactory
	{
		public IPriceCodeValid Create(IApplicationDB appDB)
		{
			var _PriceCodeValid = new Material.PriceCodeValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPriceCodeValidExt = timerfactory.Create<Material.IPriceCodeValid>(_PriceCodeValid);
			
			return iPriceCodeValidExt;
		}
	}
}
