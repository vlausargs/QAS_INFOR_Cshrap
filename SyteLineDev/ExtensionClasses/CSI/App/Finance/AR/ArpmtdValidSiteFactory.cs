//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdValidSiteFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtdValidSiteFactory
    {
        public IArpmtdValidSite Create(IApplicationDB appDB)
        {
            var _ArpmtdValidSite = new ArpmtdValidSite(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtdValidSiteExt = timerfactory.Create<IArpmtdValidSite>(_ArpmtdValidSite);

            return iArpmtdValidSiteExt;
        }
    }
}
