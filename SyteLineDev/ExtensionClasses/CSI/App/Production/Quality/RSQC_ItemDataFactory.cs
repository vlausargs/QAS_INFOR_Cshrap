//PROJECT NAME: Production
//CLASS NAME: RSQC_ItemDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ItemDataFactory
	{
		public IRSQC_ItemData Create(IApplicationDB appDB)
		{
			var _RSQC_ItemData = new Production.Quality.RSQC_ItemData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ItemDataExt = timerfactory.Create<Production.Quality.IRSQC_ItemData>(_RSQC_ItemData);
			
			return iRSQC_ItemDataExt;
		}
	}
}
