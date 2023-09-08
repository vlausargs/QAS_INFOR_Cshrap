//PROJECT NAME: Admin
//CLASS NAME: GetOpportunityTaskCountFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Admin
{
	public class GetOpportunityTaskCountFactory
	{
		public IGetOpportunityTaskCount Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetOpportunityTaskCount = new Admin.GetOpportunityTaskCount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetOpportunityTaskCountExt = timerfactory.Create<Admin.IGetOpportunityTaskCount>(_GetOpportunityTaskCount);
			
			return iGetOpportunityTaskCountExt;
		}
	}
}
