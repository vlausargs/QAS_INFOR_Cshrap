//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQPOCreateAddLineFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQPOCreateAddLineFactory
	{
		public ISSSRFQPOCreateAddLine Create(IApplicationDB appDB)
		{
			var _SSSRFQPOCreateAddLine = new RFQ.SSSRFQPOCreateAddLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQPOCreateAddLineExt = timerfactory.Create<RFQ.ISSSRFQPOCreateAddLine>(_SSSRFQPOCreateAddLine);
			
			return iSSSRFQPOCreateAddLineExt;
		}
	}
}
