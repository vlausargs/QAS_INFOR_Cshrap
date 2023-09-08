//PROJECT NAME: Production
//CLASS NAME: ValidateJobmatlReferenceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ValidateJobmatlReferenceFactory
	{
		public IValidateJobmatlReference Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateJobmatlReference = new Production.ValidateJobmatlReference(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateJobmatlReferenceExt = timerfactory.Create<Production.IValidateJobmatlReference>(_ValidateJobmatlReference);
			
			return iValidateJobmatlReferenceExt;
		}
	}
}
