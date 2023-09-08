//PROJECT NAME: Production
//CLASS NAME: RSQC_GetReceiptValuesFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetReceiptValuesFactory
	{
		public IRSQC_GetReceiptValues Create(IApplicationDB appDB)
		{
			var _RSQC_GetReceiptValues = new Production.Quality.RSQC_GetReceiptValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetReceiptValuesExt = timerfactory.Create<Production.Quality.IRSQC_GetReceiptValues>(_RSQC_GetReceiptValues);
			
			return iRSQC_GetReceiptValuesExt;
		}
	}
}
