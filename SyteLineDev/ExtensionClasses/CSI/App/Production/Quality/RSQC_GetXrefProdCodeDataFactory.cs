//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefProdCodeDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefProdCodeDataFactory
	{
		public IRSQC_GetXrefProdCodeData Create(IApplicationDB appDB)
		{
			var _RSQC_GetXrefProdCodeData = new Production.Quality.RSQC_GetXrefProdCodeData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetXrefProdCodeDataExt = timerfactory.Create<Production.Quality.IRSQC_GetXrefProdCodeData>(_RSQC_GetXrefProdCodeData);
			
			return iRSQC_GetXrefProdCodeDataExt;
		}
	}
}
