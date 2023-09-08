//PROJECT NAME: Production
//CLASS NAME: ExpandValidateRJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ExpandValidateRJobFactory
	{
		public IExpandValidateRJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ExpandValidateRJob = new Production.ExpandValidateRJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExpandValidateRJobExt = timerfactory.Create<Production.IExpandValidateRJob>(_ExpandValidateRJob);
			
			return iExpandValidateRJobExt;
		}
	}
}
