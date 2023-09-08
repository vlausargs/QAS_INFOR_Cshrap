//PROJECT NAME: CSICustomer
//CLASS NAME: ARPaymentImportProcessFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ARPaymentImportProcessFactory
    {
        public IARPaymentImportProcess Create(IApplicationDB appDB)
        {
            var _ARPaymentImportProcess = new ARPaymentImportProcess(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iARPaymentImportProcessExt = timerfactory.Create<IARPaymentImportProcess>(_ARPaymentImportProcess);

            return iARPaymentImportProcessExt;
        }
    }
}
