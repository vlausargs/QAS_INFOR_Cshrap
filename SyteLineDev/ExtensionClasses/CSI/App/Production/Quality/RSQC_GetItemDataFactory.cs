//PROJECT NAME: Production
//CLASS NAME: RSQC_GetItemDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetItemDataFactory
	{
		public IRSQC_GetItemData Create(IApplicationDB appDB)
		{
			var _RSQC_GetItemData = new Production.Quality.RSQC_GetItemData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetItemDataExt = timerfactory.Create<Production.Quality.IRSQC_GetItemData>(_RSQC_GetItemData);
			
			return iRSQC_GetItemDataExt;
		}
	}
}
