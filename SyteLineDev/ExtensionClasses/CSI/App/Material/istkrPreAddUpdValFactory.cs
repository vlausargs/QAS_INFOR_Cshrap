//PROJECT NAME: Material
//CLASS NAME: istkrPreAddUpdValFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class istkrPreAddUpdValFactory
	{
		public IistkrPreAddUpdVal Create(IApplicationDB appDB)
		{
			var _istkrPreAddUpdVal = new Material.istkrPreAddUpdVal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iistkrPreAddUpdValExt = timerfactory.Create<Material.IistkrPreAddUpdVal>(_istkrPreAddUpdVal);
			
			return iistkrPreAddUpdValExt;
		}
	}
}
