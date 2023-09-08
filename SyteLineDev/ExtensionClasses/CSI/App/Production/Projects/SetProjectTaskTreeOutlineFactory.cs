//PROJECT NAME: Production
//CLASS NAME: SetProjectTaskTreeOutlineFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class SetProjectTaskTreeOutlineFactory
	{
		public ISetProjectTaskTreeOutline Create(IApplicationDB appDB)
		{
			var _SetProjectTaskTreeOutline = new Production.Projects.SetProjectTaskTreeOutline(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetProjectTaskTreeOutlineExt = timerfactory.Create<Production.Projects.ISetProjectTaskTreeOutline>(_SetProjectTaskTreeOutline);
			
			return iSetProjectTaskTreeOutlineExt;
		}
	}
}
