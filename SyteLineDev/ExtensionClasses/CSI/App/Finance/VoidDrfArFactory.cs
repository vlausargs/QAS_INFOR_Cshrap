//PROJECT NAME: CSIFinance
//CLASS NAME: VoidDrfArFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class VoidDrfArFactory
    {
        public IVoidDrfAr Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _VoidDrfAr = new VoidDrfAr(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLCustdrftsExt = timerfactory.Create<IVoidDrfAr>(_VoidDrfAr);

            return iSLCustdrftsExt;
        }
    }
}
