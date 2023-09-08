//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQLineValVendFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQLineValVendFactory
	{
		public ISSSRFQLineValVend Create(IApplicationDB appDB)
		{
			var _SSSRFQLineValVend = new RFQ.SSSRFQLineValVend(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQLineValVendExt = timerfactory.Create<RFQ.ISSSRFQLineValVend>(_SSSRFQLineValVend);
			
			return iSSSRFQLineValVendExt;
		}
	}
}
