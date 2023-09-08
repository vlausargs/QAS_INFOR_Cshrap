//PROJECT NAME: Production
//CLASS NAME: ValidateJobDemandIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ValidateJobDemandIdFactory
	{
		public IValidateJobDemandId Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateJobDemandId = new Production.ValidateJobDemandId(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateJobDemandIdExt = timerfactory.Create<Production.IValidateJobDemandId>(_ValidateJobDemandId);
			
			return iValidateJobDemandIdExt;
		}
	}
}
