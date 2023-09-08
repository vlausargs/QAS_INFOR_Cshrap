//PROJECT NAME: CSIProduct
//CLASS NAME: CompleteJobOperationFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CompleteJobOperationFactory
    {
        public ICompleteJobOperation Create(IApplicationDB appDB)
        {
            var _CompleteJobOperation = new CompleteJobOperation(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCompleteJobOperationExt = timerfactory.Create<ICompleteJobOperation>(_CompleteJobOperation);

            return iCompleteJobOperationExt;
        }
    }
}
