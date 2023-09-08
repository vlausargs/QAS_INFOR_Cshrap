//PROJECT NAME: CSIProduct
//CLASS NAME: GetItemByJobFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class GetItemByJobFactory
    {
        public IGetItemByJob Create(IApplicationDB appDB)
        {
            var _GetItemByJob = new GetItemByJob(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetItemByJobExt = timerfactory.Create<IGetItemByJob>(_GetItemByJob);

            return iGetItemByJobExt;
        }
    }
}
