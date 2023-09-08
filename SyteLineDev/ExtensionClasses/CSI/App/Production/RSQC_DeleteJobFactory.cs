//PROJECT NAME: Production
//CLASS NAME: RSQC_DeleteJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class RSQC_DeleteJobFactory
	{
		public IRSQC_DeleteJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_DeleteJob = new Production.RSQC_DeleteJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_DeleteJobExt = timerfactory.Create<Production.IRSQC_DeleteJob>(_RSQC_DeleteJob);
			
			return iRSQC_DeleteJobExt;
		}
	}
}
