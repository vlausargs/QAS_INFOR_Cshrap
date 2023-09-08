//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckIPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class RSQC_CheckIPFactory
	{
		public IRSQC_CheckIP Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_CheckIP = new Production.RSQC_CheckIP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CheckIPExt = timerfactory.Create<Production.IRSQC_CheckIP>(_RSQC_CheckIP);
			
			return iRSQC_CheckIPExt;
		}
	}
}
