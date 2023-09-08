//PROJECT NAME: Finance
//CLASS NAME: GlrptlNextSeqFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class GlrptlNextSeqFactory
	{
		public IGlrptlNextSeq Create(IApplicationDB appDB)
		{
			var _GlrptlNextSeq = new Finance.GlrptlNextSeq(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGlrptlNextSeqExt = timerfactory.Create<Finance.IGlrptlNextSeq>(_GlrptlNextSeq);
			
			return iGlrptlNextSeqExt;
		}
	}
}
