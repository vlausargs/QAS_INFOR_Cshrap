//PROJECT NAME: Production
//CLASS NAME: RSQC_GetNumSamplesFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetNumSamplesFactory
	{
		public IRSQC_GetNumSamples Create(IApplicationDB appDB)
		{
			var _RSQC_GetNumSamples = new Production.Quality.RSQC_GetNumSamples(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetNumSamplesExt = timerfactory.Create<Production.Quality.IRSQC_GetNumSamples>(_RSQC_GetNumSamples);
			
			return iRSQC_GetNumSamplesExt;
		}
	}
}
