//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQPOCreateCleanupFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQPOCreateCleanupFactory
	{
		public ISSSRFQPOCreateCleanup Create(IApplicationDB appDB)
		{
			var _SSSRFQPOCreateCleanup = new RFQ.SSSRFQPOCreateCleanup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQPOCreateCleanupExt = timerfactory.Create<RFQ.ISSSRFQPOCreateCleanup>(_SSSRFQPOCreateCleanup);
			
			return iSSSRFQPOCreateCleanupExt;
		}
	}
}
