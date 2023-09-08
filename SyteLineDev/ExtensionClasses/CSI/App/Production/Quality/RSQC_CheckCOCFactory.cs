//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckCOCFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckCOCFactory
	{
		public IRSQC_CheckCOC Create(IApplicationDB appDB)
		{
			var _RSQC_CheckCOC = new Production.Quality.RSQC_CheckCOC(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CheckCOCExt = timerfactory.Create<Production.Quality.IRSQC_CheckCOC>(_RSQC_CheckCOC);
			
			return iRSQC_CheckCOCExt;
		}
	}
}
