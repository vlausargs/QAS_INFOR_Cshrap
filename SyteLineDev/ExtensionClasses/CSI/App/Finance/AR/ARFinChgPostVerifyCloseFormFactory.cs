//PROJECT NAME: CSICustomer
//CLASS NAME: ARFinChgPostVerifyCloseFormFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ARFinChgPostVerifyCloseFormFactory
    {
        public IARFinChgPostVerifyCloseForm Create(IApplicationDB appDB)
        {
            var _ARFinChgPostVerifyCloseForm = new ARFinChgPostVerifyCloseForm(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iARFinChgPostVerifyCloseFormExt = timerfactory.Create<IARFinChgPostVerifyCloseForm>(_ARFinChgPostVerifyCloseForm);

            return iARFinChgPostVerifyCloseFormExt;
        }
    }
}
