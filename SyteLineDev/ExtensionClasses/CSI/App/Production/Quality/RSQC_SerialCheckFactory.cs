//PROJECT NAME: Production
//CLASS NAME: RSQC_SerialCheckFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SerialCheckFactory
	{
		public IRSQC_SerialCheck Create(IApplicationDB appDB)
		{
			var _RSQC_SerialCheck = new Production.Quality.RSQC_SerialCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_SerialCheckExt = timerfactory.Create<Production.Quality.IRSQC_SerialCheck>(_RSQC_SerialCheck);
			
			return iRSQC_SerialCheckExt;
		}
	}
}
