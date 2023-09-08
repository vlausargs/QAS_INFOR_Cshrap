//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckCOCTOFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckCOCTOFactory
	{
		public IRSQC_CheckCOCTO Create(IApplicationDB appDB)
		{
			var _RSQC_CheckCOCTO = new Production.Quality.RSQC_CheckCOCTO(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CheckCOCTOExt = timerfactory.Create<Production.Quality.IRSQC_CheckCOCTO>(_RSQC_CheckCOCTO);
			
			return iRSQC_CheckCOCTOExt;
		}
	}
}
