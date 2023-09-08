//PROJECT NAME: CSIProduct
//CLASS NAME: EngWBJobmatlFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class EngWBJobmatlFactory
	{
		public IEngWBJobmatl Create(IApplicationDB appDB)
		{
			var _EngWBJobmatl = new Production.EngWBJobmatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEngWBJobmatlExt = timerfactory.Create<Production.IEngWBJobmatl>(_EngWBJobmatl);
			
			return iEngWBJobmatlExt;
		}
	}
}
