//PROJECT NAME: Production
//CLASS NAME: SetWorkResourceListSourceFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class SetWorkResourceListSourceFactory
	{
		public ISetWorkResourceListSource Create(IApplicationDB appDB)
		{
			var _SetWorkResourceListSource = new Production.Projects.SetWorkResourceListSource(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetWorkResourceListSourceExt = timerfactory.Create<Production.Projects.ISetWorkResourceListSource>(_SetWorkResourceListSource);
			
			return iSetWorkResourceListSourceExt;
		}
	}
}
