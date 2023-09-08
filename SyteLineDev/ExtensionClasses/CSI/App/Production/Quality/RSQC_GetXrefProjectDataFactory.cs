//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefProjectDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefProjectDataFactory
	{
		public IRSQC_GetXrefProjectData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefProjectData = new Production.Quality.RSQC_GetXrefProjectData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefProjectDataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefProjectData>(_RSQC_GetXrefProjectData);
			
			return iRSQC_GetXrefProjectDataExt;
		}
	}
}
