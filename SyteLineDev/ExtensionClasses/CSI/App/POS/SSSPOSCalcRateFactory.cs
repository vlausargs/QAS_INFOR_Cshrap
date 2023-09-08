//PROJECT NAME: POS
//CLASS NAME: SSSPOSCalcRateFactory.cs

using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSCalcRateFactory
	{
		public ISSSPOSCalcRate Create(IApplicationDB appDB)
		{
			var _SSSPOSCalcRate = new POS.SSSPOSCalcRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSCalcRateExt = timerfactory.Create<POS.ISSSPOSCalcRate>(_SSSPOSCalcRate);
			
			return iSSSPOSCalcRateExt;
		}
	}
}
