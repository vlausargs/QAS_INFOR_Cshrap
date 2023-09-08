//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateItFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateItFactory
	{
		public IRSQC_ValidateIt Create(IApplicationDB appDB)
		{
			var _RSQC_ValidateIt = new Production.Quality.RSQC_ValidateIt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ValidateItExt = timerfactory.Create<Production.Quality.IRSQC_ValidateIt>(_RSQC_ValidateIt);
			
			return iRSQC_ValidateItExt;
		}
	}
}
