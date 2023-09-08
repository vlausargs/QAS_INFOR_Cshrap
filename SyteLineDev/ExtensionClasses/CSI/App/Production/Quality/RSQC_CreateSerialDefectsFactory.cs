//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateSerialDefectsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_CreateSerialDefectsFactory
	{
		public IRSQC_CreateSerialDefects Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_CreateSerialDefects = new Production.Quality.RSQC_CreateSerialDefects(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateSerialDefectsExt = timerfactory.Create<Production.Quality.IRSQC_CreateSerialDefects>(_RSQC_CreateSerialDefects);
			
			return iRSQC_CreateSerialDefectsExt;
		}
	}
}
