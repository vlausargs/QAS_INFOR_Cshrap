//PROJECT NAME: Production
//CLASS NAME: JobmatlXrefFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobmatlXrefFactory
	{
		public IJobmatlXref Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobmatlXref = new Production.JobmatlXref(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobmatlXrefExt = timerfactory.Create<Production.IJobmatlXref>(_JobmatlXref);
			
			return iJobmatlXrefExt;
		}
	}
}
