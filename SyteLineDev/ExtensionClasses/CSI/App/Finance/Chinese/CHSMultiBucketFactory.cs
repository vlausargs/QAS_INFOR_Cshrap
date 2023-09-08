//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSMultiBucketFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSMultiBucketFactory
    {
        public ICHSMultiBucket Create(IApplicationDB appDB)
        {
            var _CHSMultiBucket = new CHSMultiBucket(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSMultiBucketExt = timerfactory.Create<ICHSMultiBucket>(_CHSMultiBucket);

            return iCHSMultiBucketExt;
        }
    }
}