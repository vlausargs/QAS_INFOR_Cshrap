//PROJECT NAME: CSIProduct
//CLASS NAME: EstimateJobRollFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class EstimateJobRollFactory
	{
		public IEstimateJobRoll Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _EstimateJobRoll = new Production.EstimateJobRoll(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstimateJobRollExt = timerfactory.Create<Production.IEstimateJobRoll>(_EstimateJobRoll);
			
			return iEstimateJobRollExt;
		}
	}
}
