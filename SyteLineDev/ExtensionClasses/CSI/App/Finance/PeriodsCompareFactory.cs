//PROJECT NAME: CSIFinance
//CLASS NAME: PeriodsCompareFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class PeriodsCompareFactory
	{
		public IPeriodsCompare Create(IApplicationDB appDB)
		{
			var _PeriodsCompare = new Finance.PeriodsCompare(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPeriodsCompareExt = timerfactory.Create<Finance.IPeriodsCompare>(_PeriodsCompare);
			
			return iPeriodsCompareExt;
		}
	}
}
