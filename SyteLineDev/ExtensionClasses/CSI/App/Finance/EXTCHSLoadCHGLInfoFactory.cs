//PROJECT NAME: Finance
//CLASS NAME: EXTCHSLoadCHGLInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class EXTCHSLoadCHGLInfoFactory
	{
		public IEXTCHSLoadCHGLInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EXTCHSLoadCHGLInfo = new Finance.EXTCHSLoadCHGLInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEXTCHSLoadCHGLInfoExt = timerfactory.Create<Finance.IEXTCHSLoadCHGLInfo>(_EXTCHSLoadCHGLInfo);
			
			return iEXTCHSLoadCHGLInfoExt;
		}
	}
}
