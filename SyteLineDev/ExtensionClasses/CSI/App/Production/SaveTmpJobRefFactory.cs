//PROJECT NAME: CSIProduct
//CLASS NAME: SaveTmpJobRefFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class SaveTmpJobRefFactory
    {
        public ISaveTmpJobRef Create(IApplicationDB appDB)
        {
            var _SaveTmpJobRef = new SaveTmpJobRef(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSaveTmpJobRefExt = timerfactory.Create<ISaveTmpJobRef>(_SaveTmpJobRef);

            return iSaveTmpJobRefExt;
        }
    }
}
