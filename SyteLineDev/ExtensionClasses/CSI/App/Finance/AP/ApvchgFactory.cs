//PROJECT NAME: CSIVendor
//CLASS NAME: ApvchgFactory.cs

using CSI.MG;

namespace CSI.Finance.AP
{
    public class ApvchgFactory
    {
        public IApvchg Create(IApplicationDB appDB)
        {
            var _Apvchg = new Apvchg(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApvchgExt = timerfactory.Create<IApvchg>(_Apvchg);

            return iApvchgExt;
        }
    }
}
