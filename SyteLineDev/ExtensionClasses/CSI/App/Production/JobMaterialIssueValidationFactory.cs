//PROJECT NAME: Production
//CLASS NAME: JobMaterialIssueValidationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobMaterialIssueValidationFactory
	{
		public IJobMaterialIssueValidation Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobMaterialIssueValidation = new Production.JobMaterialIssueValidation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobMaterialIssueValidationExt = timerfactory.Create<Production.IJobMaterialIssueValidation>(_JobMaterialIssueValidation);
			
			return iJobMaterialIssueValidationExt;
		}
	}
}
