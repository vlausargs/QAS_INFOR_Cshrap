//PROJECT NAME: Production
//CLASS NAME: RSQC_AutoCreateQCItemFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_AutoCreateQCItemFactory
	{
		public IRSQC_AutoCreateQCItem Create(IApplicationDB appDB)
		{
			var _RSQC_AutoCreateQCItem = new Production.Quality.RSQC_AutoCreateQCItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_AutoCreateQCItemExt = timerfactory.Create<Production.Quality.IRSQC_AutoCreateQCItem>(_RSQC_AutoCreateQCItem);
			
			return iRSQC_AutoCreateQCItemExt;
		}
	}
}
