//PROJECT NAME: Finance
//CLASS NAME: FinRptLineCheckSeqFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class FinRptLineCheckSeqFactory
	{
		public IFinRptLineCheckSeq Create(IApplicationDB appDB)
		{
			var _FinRptLineCheckSeq = new Finance.FinRptLineCheckSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFinRptLineCheckSeqExt = timerfactory.Create<Finance.IFinRptLineCheckSeq>(_FinRptLineCheckSeq);
			
			return iFinRptLineCheckSeqExt;
		}
	}
}
