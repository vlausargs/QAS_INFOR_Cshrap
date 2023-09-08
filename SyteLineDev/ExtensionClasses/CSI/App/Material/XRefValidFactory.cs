//PROJECT NAME: Material
//CLASS NAME: XRefValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class XRefValidFactory
	{
		public IXRefValid Create(IApplicationDB appDB)
		{
			var _XRefValid = new Material.XRefValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iXRefValidExt = timerfactory.Create<Material.IXRefValid>(_XRefValid);
			
			return iXRefValidExt;
		}
	}
}
