//PROJECT NAME: Production
//CLASS NAME: ValidateJobRevisionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ValidateJobRevisionFactory
	{
		public IValidateJobRevision Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateJobRevision = new Production.ValidateJobRevision(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateJobRevisionExt = timerfactory.Create<Production.IValidateJobRevision>(_ValidateJobRevision);
			
			return iValidateJobRevisionExt;
		}
	}
}
