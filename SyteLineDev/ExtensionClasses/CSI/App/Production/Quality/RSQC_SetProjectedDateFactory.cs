//PROJECT NAME: Production
//CLASS NAME: RSQC_SetProjectedDateFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetProjectedDateFactory
	{
		public IRSQC_SetProjectedDate Create(IApplicationDB appDB)
		{
			var _RSQC_SetProjectedDate = new Production.Quality.RSQC_SetProjectedDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_SetProjectedDateExt = timerfactory.Create<Production.Quality.IRSQC_SetProjectedDate>(_RSQC_SetProjectedDate);
			
			return iRSQC_SetProjectedDateExt;
		}
	}
}
