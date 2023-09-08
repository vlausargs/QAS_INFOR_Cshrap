//PROJECT NAME: CSIVendor
//CLASS NAME: AptrxrgFactory.cs

using CSI.MG;

namespace CSI.Finance.AP
{
    public class AptrxrgFactory
    {
        public IAptrxrg Create(IApplicationDB appDB)
        {
            var _Aptrxrg = new Aptrxrg(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAptrxrgExt = timerfactory.Create<IAptrxrg>(_Aptrxrg);

            return iAptrxrgExt;
        }
    }
}
