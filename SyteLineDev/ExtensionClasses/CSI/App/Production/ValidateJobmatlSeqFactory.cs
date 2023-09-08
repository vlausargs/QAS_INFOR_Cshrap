//PROJECT NAME: Production
//CLASS NAME: ValidateJobmatlSeqFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ValidateJobmatlSeqFactory
	{
		public IValidateJobmatlSeq Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateJobmatlSeq = new Production.ValidateJobmatlSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateJobmatlSeqExt = timerfactory.Create<Production.IValidateJobmatlSeq>(_ValidateJobmatlSeq);
			
			return iValidateJobmatlSeqExt;
		}
	}
}
