//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQGenCleanupFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQGenCleanupFactory
	{
		public ISSSRFQGenCleanup Create(IApplicationDB appDB)
		{
			var _SSSRFQGenCleanup = new RFQ.SSSRFQGenCleanup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQGenCleanupExt = timerfactory.Create<RFQ.ISSSRFQGenCleanup>(_SSSRFQGenCleanup);
			
			return iSSSRFQGenCleanupExt;
		}
	}
}
