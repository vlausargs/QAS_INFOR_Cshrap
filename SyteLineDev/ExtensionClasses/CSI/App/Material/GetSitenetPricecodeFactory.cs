//PROJECT NAME: Material
//CLASS NAME: GetSitenetPricecodeFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetSitenetPricecodeFactory
	{
		public IGetSitenetPricecode Create(IApplicationDB appDB)
		{
			var _GetSitenetPricecode = new Material.GetSitenetPricecode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetSitenetPricecodeExt = timerfactory.Create<Material.IGetSitenetPricecode>(_GetSitenetPricecode);
			
			return iGetSitenetPricecodeExt;
		}
	}
}
