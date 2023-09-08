//PROJECT NAME: CSIProduct
//CLASS NAME: CoProductSyncRatio2Factory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CoProductSyncRatio2Factory
    {
        public ICoProductSyncRatio2 Create(IApplicationDB appDB)
        {
            var _CoProductSyncRatio2 = new CoProductSyncRatio2(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoProductSyncRatio2Ext = timerfactory.Create<ICoProductSyncRatio2>(_CoProductSyncRatio2);

            return iCoProductSyncRatio2Ext;
        }
    }
}
