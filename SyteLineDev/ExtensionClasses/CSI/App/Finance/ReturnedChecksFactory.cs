//PROJECT NAME: Finance
//CLASS NAME: ReturnedChecksFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class ReturnedChecksFactory
	{
		public IReturnedChecks Create(IApplicationDB appDB)
		{
			var _ReturnedChecks = new Finance.ReturnedChecks(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReturnedChecksExt = timerfactory.Create<Finance.IReturnedChecks>(_ReturnedChecks);
			
			return iReturnedChecksExt;
		}
	}
}
