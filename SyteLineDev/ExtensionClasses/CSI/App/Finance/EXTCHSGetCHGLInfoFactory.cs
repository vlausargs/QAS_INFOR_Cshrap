//PROJECT NAME: Finance
//CLASS NAME: EXTCHSGetCHGLInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class EXTCHSGetCHGLInfoFactory
	{
		public IEXTCHSGetCHGLInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EXTCHSGetCHGLInfo = new Finance.EXTCHSGetCHGLInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEXTCHSGetCHGLInfoExt = timerfactory.Create<Finance.IEXTCHSGetCHGLInfo>(_EXTCHSGetCHGLInfo);
			
			return iEXTCHSGetCHGLInfoExt;
		}
	}
}
