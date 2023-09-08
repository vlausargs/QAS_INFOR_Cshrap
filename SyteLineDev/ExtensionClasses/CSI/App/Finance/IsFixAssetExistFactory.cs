//PROJECT NAME: CSIFinance
//CLASS NAME: IsFixAssetExistFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class IsFixAssetExistFactory
    {
        public IIsFixAssetExist Create(IApplicationDB appDB)
        {
            var _IsFixAssetExist = new IsFixAssetExist(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFamastersExt = timerfactory.Create<IIsFixAssetExist>(_IsFixAssetExist);

            return iSLFamastersExt;
        }
    }
}
