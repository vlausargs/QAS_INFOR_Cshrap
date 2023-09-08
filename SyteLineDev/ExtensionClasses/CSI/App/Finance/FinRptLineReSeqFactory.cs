//PROJECT NAME: Finance
//CLASS NAME: FinRptLineReSeqFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class FinRptLineReSeqFactory
	{
		public IFinRptLineReSeq Create(IApplicationDB appDB)
		{
			var _FinRptLineReSeq = new Finance.FinRptLineReSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFinRptLineReSeqExt = timerfactory.Create<Finance.IFinRptLineReSeq>(_FinRptLineReSeq);
			
			return iFinRptLineReSeqExt;
		}
	}
}
