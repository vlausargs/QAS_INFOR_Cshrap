//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQPOCreateFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQPOCreateFactory
	{
		public ISSSRFQPOCreate Create(IApplicationDB appDB)
		{
			var _SSSRFQPOCreate = new RFQ.SSSRFQPOCreate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQPOCreateExt = timerfactory.Create<RFQ.ISSSRFQPOCreate>(_SSSRFQPOCreate);
			
			return iSSSRFQPOCreateExt;
		}
	}
}
