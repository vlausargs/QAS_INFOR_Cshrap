//PROJECT NAME: Production
//CLASS NAME: RSQC_SetVrmaValuesFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetVrmaValuesFactory
	{
		public IRSQC_SetVrmaValues Create(IApplicationDB appDB)
		{
			var _RSQC_SetVrmaValues = new Production.Quality.RSQC_SetVrmaValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_SetVrmaValuesExt = timerfactory.Create<Production.Quality.IRSQC_SetVrmaValues>(_RSQC_SetVrmaValues);
			
			return iRSQC_SetVrmaValuesExt;
		}
	}
}
