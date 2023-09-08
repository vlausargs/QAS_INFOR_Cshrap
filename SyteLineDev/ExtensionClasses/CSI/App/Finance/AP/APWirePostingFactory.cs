//PROJECT NAME: CSIVendor
//CLASS NAME: APWirePostingFactory.cs

using CSI.MG;

namespace CSI.Finance.AP
{
    public class APWirePostingFactory
    {
        public IAPWirePosting Create(IApplicationDB appDB)
        {
            var _APWirePosting = new APWirePosting(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAPWirePostingExt = timerfactory.Create<IAPWirePosting>(_APWirePosting);

            return iAPWirePostingExt;
        }
    }
}
