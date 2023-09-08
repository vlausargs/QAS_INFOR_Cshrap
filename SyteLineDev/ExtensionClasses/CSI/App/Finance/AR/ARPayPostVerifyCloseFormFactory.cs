//PROJECT NAME: CSICustomer
//CLASS NAME: ARPayPostVerifyCloseFormFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ARPayPostVerifyCloseFormFactory
    {
        public IARPayPostVerifyCloseForm Create(IApplicationDB appDB)
        {
            var _ARPayPostVerifyCloseForm = new ARPayPostVerifyCloseForm(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iARPayPostVerifyCloseFormExt = timerfactory.Create<IARPayPostVerifyCloseForm>(_ARPayPostVerifyCloseForm);

            return iARPayPostVerifyCloseFormExt;
        }
    }
}
