//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateVrmaFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateVrmaFactory
	{
		public IRSQC_CreateVrma Create(IApplicationDB appDB)
		{
			var _RSQC_CreateVrma = new Production.Quality.RSQC_CreateVrma(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateVrmaExt = timerfactory.Create<Production.Quality.IRSQC_CreateVrma>(_RSQC_CreateVrma);
			
			return iRSQC_CreateVrmaExt;
		}
	}
}
