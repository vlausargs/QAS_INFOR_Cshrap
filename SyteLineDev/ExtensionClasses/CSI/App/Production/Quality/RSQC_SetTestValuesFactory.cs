//PROJECT NAME: Production
//CLASS NAME: RSQC_SetTestValuesFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetTestValuesFactory
	{
		public IRSQC_SetTestValues Create(IApplicationDB appDB)
		{
			var _RSQC_SetTestValues = new Production.Quality.RSQC_SetTestValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_SetTestValuesExt = timerfactory.Create<Production.Quality.IRSQC_SetTestValues>(_RSQC_SetTestValues);
			
			return iRSQC_SetTestValuesExt;
		}
	}
}
