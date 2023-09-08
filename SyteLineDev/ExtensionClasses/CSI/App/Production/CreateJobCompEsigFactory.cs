//PROJECT NAME: Production
//CLASS NAME: CreateJobCompEsigFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CreateJobCompEsigFactory
	{
		public ICreateJobCompEsig Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreateJobCompEsig = new Production.CreateJobCompEsig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateJobCompEsigExt = timerfactory.Create<Production.ICreateJobCompEsig>(_CreateJobCompEsig);
			
			return iCreateJobCompEsigExt;
		}
	}
}
