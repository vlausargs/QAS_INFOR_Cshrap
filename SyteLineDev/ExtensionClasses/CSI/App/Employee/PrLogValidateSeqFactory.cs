//PROJECT NAME: CSIEmployee
//CLASS NAME: PrLogValidateSeqFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PrLogValidateSeqFactory
    {
        public IPrLogValidateSeq Create(IApplicationDB appDB)
        {
            var _PrLogValidateSeq = new PrLogValidateSeq(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPrLogValidateSeqExt = timerfactory.Create<IPrLogValidateSeq>(_PrLogValidateSeq);

            return iPrLogValidateSeqExt;
        }
    }
}
