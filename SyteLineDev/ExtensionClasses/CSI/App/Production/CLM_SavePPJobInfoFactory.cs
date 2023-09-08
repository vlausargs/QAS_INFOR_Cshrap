//PROJECT NAME: Production
//CLASS NAME: CLM_SavePPJobInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CLM_SavePPJobInfoFactory
	{
		public ICLM_SavePPJobInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CLM_SavePPJobInfo = new Production.CLM_SavePPJobInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SavePPJobInfoExt = timerfactory.Create<Production.ICLM_SavePPJobInfo>(_CLM_SavePPJobInfo);
			
			return iCLM_SavePPJobInfoExt;
		}
	}
}
