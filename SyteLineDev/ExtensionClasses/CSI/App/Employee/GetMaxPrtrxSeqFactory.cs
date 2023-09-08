//PROJECT NAME: CSIEmployee
//CLASS NAME: GetMaxPrtrxSeqFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class GetMaxPrtrxSeqFactory
    {
        public IGetMaxPrtrxSeq Create(IApplicationDB appDB)
        {
            var _GetMaxPrtrxSeq = new GetMaxPrtrxSeq(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetMaxPrtrxSeqExt = timerfactory.Create<IGetMaxPrtrxSeq>(_GetMaxPrtrxSeq);

            return iGetMaxPrtrxSeqExt;
        }
    }
}
