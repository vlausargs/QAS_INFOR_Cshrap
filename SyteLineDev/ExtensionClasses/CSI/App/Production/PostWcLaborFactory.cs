//PROJECT NAME: CSIProduct
//CLASS NAME: PostWcLaborFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PostWcLaborFactory
	{
		public IPostWcLabor Create(IApplicationDB appDB)
		{
			var _PostWcLabor = new Production.PostWcLabor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostWcLaborExt = timerfactory.Create<Production.IPostWcLabor>(_PostWcLabor);
			
			return iPostWcLaborExt;
		}
	}
}
