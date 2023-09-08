//PROJECT NAME: RFQ
//CLASS NAME: SSSRfqGenSetSelectedFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRfqGenSetSelectedFactory
	{
		public ISSSRfqGenSetSelected Create(IApplicationDB appDB)
		{
			var _SSSRfqGenSetSelected = new RFQ.SSSRfqGenSetSelected(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRfqGenSetSelectedExt = timerfactory.Create<RFQ.ISSSRfqGenSetSelected>(_SSSRfqGenSetSelected);
			
			return iSSSRfqGenSetSelectedExt;
		}
	}
}
