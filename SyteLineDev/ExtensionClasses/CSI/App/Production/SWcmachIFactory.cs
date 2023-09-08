//PROJECT NAME: CSIProduct
//CLASS NAME: SWcmachIFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class SWcmachIFactory
    {
        public ISWcmachI Create(IApplicationDB appDB)
        {
            var _SWcmachI = new SWcmachI(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSWcmachIExt = timerfactory.Create<ISWcmachI>(_SWcmachI);

            return iSWcmachIExt;
        }
    }
}
