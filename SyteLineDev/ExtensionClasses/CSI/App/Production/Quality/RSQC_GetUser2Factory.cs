//PROJECT NAME: Production
//CLASS NAME: RSQC_GetUser2Factory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetUser2Factory
	{
		public IRSQC_GetUser2 Create(IApplicationDB appDB)
		{
			var _RSQC_GetUser2 = new Production.Quality.RSQC_GetUser2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetUser2Ext = timerfactory.Create<Production.Quality.IRSQC_GetUser2>(_RSQC_GetUser2);
			
			return iRSQC_GetUser2Ext;
		}
	}
}
