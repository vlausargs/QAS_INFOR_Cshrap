//PROJECT NAME: Finance
//CLASS NAME: FinRptLineDefaultSeqFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class FinRptLineDefaultSeqFactory
	{
		public IFinRptLineDefaultSeq Create(IApplicationDB appDB)
		{
			var _FinRptLineDefaultSeq = new Finance.FinRptLineDefaultSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFinRptLineDefaultSeqExt = timerfactory.Create<Finance.IFinRptLineDefaultSeq>(_FinRptLineDefaultSeq);
			
			return iFinRptLineDefaultSeqExt;
		}
	}
}
