//PROJECT NAME: CSIProduct
//CLASS NAME: DeletePendingJobLaborTransFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class DeletePendingJobLaborTransFactory
    {
        public IDeletePendingJobLaborTrans Create(IApplicationDB appDB)
        {
            var _DeletePendingJobLaborTrans = new DeletePendingJobLaborTrans(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDeletePendingJobLaborTransExt = timerfactory.Create<IDeletePendingJobLaborTrans>(_DeletePendingJobLaborTrans);

            return iDeletePendingJobLaborTransExt;
        }
    }
}
