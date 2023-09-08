//PROJECT NAME: Production
//CLASS NAME: RSQC_XRefChangeFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_XRefChangeFactory
	{
		public IRSQC_XRefChange Create(IApplicationDB appDB)
		{
			var _RSQC_XRefChange = new Production.Quality.RSQC_XRefChange(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_XRefChangeExt = timerfactory.Create<Production.Quality.IRSQC_XRefChange>(_RSQC_XRefChange);
			
			return iRSQC_XRefChangeExt;
		}
	}
}
