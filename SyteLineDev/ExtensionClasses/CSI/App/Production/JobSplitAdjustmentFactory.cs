//PROJECT NAME: Production
//CLASS NAME: JobSplitAdjustmentFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobSplitAdjustmentFactory
	{
		public IJobSplitAdjustment Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobSplitAdjustment = new Production.JobSplitAdjustment(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobSplitAdjustmentExt = timerfactory.Create<Production.IJobSplitAdjustment>(_JobSplitAdjustment);
			
			return iJobSplitAdjustmentExt;
		}
	}
}
