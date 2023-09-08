//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateTesthEsigFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateTesthEsigFactory
	{
		public IRSQC_CreateTesthEsig Create(IApplicationDB appDB)
		{
			var _RSQC_CreateTesthEsig = new Production.Quality.RSQC_CreateTesthEsig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateTesthEsigExt = timerfactory.Create<Production.Quality.IRSQC_CreateTesthEsig>(_RSQC_CreateTesthEsig);
			
			return iRSQC_CreateTesthEsigExt;
		}
	}
}
