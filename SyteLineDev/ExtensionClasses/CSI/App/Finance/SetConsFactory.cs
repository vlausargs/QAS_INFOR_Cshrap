//PROJECT NAME: Finance
//CLASS NAME: SetConsFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class SetConsFactory
	{
		public ISetCons Create(IApplicationDB appDB)
		{
			var _SetCons = new Finance.SetCons(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetConsExt = timerfactory.Create<Finance.ISetCons>(_SetCons);
			
			return iSetConsExt;
		}
	}
}
