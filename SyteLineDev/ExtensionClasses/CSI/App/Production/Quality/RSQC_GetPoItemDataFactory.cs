//PROJECT NAME: Production
//CLASS NAME: RSQC_GetPoItemDataFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetPoItemDataFactory
	{
		public IRSQC_GetPoItemData Create(IApplicationDB appDB)
		{
			var _RSQC_GetPoItemData = new Production.Quality.RSQC_GetPoItemData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetPoItemDataExt = timerfactory.Create<Production.Quality.IRSQC_GetPoItemData>(_RSQC_GetPoItemData);
			
			return iRSQC_GetPoItemDataExt;
		}
	}
}
