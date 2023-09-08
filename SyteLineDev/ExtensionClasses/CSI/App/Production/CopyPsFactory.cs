//PROJECT NAME: CSIProduct
//CLASS NAME: CopyPsFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CopyPsFactory
    {
        public ICopyPs Create(IApplicationDB appDB)
        {
            var _CopyPs = new CopyPs(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCopyPsExt = timerfactory.Create<ICopyPs>(_CopyPs);

            return iCopyPsExt;
        }
    }
}
