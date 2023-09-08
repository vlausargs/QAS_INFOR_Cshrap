//PROJECT NAME: Finance
//CLASS NAME: FinRptLineGenFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class FinRptLineGenFactory
	{
		public IFinRptLineGen Create(IApplicationDB appDB)
		{
			var _FinRptLineGen = new Finance.FinRptLineGen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFinRptLineGenExt = timerfactory.Create<Finance.IFinRptLineGen>(_FinRptLineGen);
			
			return iFinRptLineGenExt;
		}
	}
}
