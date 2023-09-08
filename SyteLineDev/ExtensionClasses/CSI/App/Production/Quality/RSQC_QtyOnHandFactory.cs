//PROJECT NAME: Production
//CLASS NAME: RSQC_QtyOnHandFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_QtyOnHandFactory
	{
		public IRSQC_QtyOnHand Create(IApplicationDB appDB)
		{
			var _RSQC_QtyOnHand = new Production.Quality.RSQC_QtyOnHand(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_QtyOnHandExt = timerfactory.Create<Production.Quality.IRSQC_QtyOnHand>(_RSQC_QtyOnHand);
			
			return iRSQC_QtyOnHandExt;
		}
	}
}
