//PROJECT NAME: Finance
//CLASS NAME: FaCostsNextSeqFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class FaCostsNextSeqFactory
	{
		public IFaCostsNextSeq Create(IApplicationDB appDB)
		{
			var _FaCostsNextSeq = new Finance.FaCostsNextSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFaCostsNextSeqExt = timerfactory.Create<Finance.IFaCostsNextSeq>(_FaCostsNextSeq);
			
			return iFaCostsNextSeqExt;
		}
	}
}
