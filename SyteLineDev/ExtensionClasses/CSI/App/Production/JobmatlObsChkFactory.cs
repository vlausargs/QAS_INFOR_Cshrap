//PROJECT NAME: Production
//CLASS NAME: JobmatlObsChkFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobmatlObsChkFactory
	{
		public IJobmatlObsChk Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobmatlObsChk = new Production.JobmatlObsChk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobmatlObsChkExt = timerfactory.Create<Production.IJobmatlObsChk>(_JobmatlObsChk);
			
			return iJobmatlObsChkExt;
		}
	}
}
