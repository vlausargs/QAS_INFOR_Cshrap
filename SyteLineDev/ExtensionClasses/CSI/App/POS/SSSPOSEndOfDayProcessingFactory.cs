//PROJECT NAME: POS
//CLASS NAME: SSSPOSEndOfDayProcessingFactory.cs

using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSEndOfDayProcessingFactory
	{
		public ISSSPOSEndOfDayProcessing Create(IApplicationDB appDB)
		{
			var _SSSPOSEndOfDayProcessing = new POS.SSSPOSEndOfDayProcessing(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSEndOfDayProcessingExt = timerfactory.Create<POS.ISSSPOSEndOfDayProcessing>(_SSSPOSEndOfDayProcessing);
			
			return iSSSPOSEndOfDayProcessingExt;
		}
	}
}
