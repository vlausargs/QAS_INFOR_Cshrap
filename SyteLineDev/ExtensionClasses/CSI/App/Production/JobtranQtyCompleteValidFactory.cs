//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranQtyCompleteValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobtranQtyCompleteValidFactory
    {
        public IJobtranQtyCompleteValid Create(IApplicationDB appDB)
        {
            var _JobtranQtyCompleteValid = new JobtranQtyCompleteValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobtranQtyCompleteValidExt = timerfactory.Create<IJobtranQtyCompleteValid>(_JobtranQtyCompleteValid);

            return iJobtranQtyCompleteValidExt;
        }
    }
}
